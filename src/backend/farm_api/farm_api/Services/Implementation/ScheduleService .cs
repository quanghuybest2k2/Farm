﻿using AutoMapper;
using Core.Entities;
using DAL.Repositories.Interface;
using DAL.Repositories.UnitOfWork;
using farm_api.Job;
using farm_api.Models;
using farm_api.Models.Request;
using farm_api.Services.Interface;
using Quartz;
using System;
using Microsoft.Extensions.Logging;
using farm_api.Responses;
using farm_api.Filter.Schedule;
using Core.Constract;
using Core.Queries;
using DAL.Repositories.Implementation;
using farm_api.Filter.Farm;

namespace farm_api.Services.Implementation
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repository;
        private readonly ISchedulerFactory _schedulerFactory;
        private  IScheduler _scheduler;
        private readonly ILogger<ScheduleService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private  IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of the ScheduleService with necessary dependencies.
        /// </summary>
        /// <param name="repository">The schedule repository.</param>
        /// <param name="schedulerFactory">The factory for creating scheduler instances.</param>
        /// <param name="logger">The logger for logging information.</param>
        /// <param name="unitOfWork">The unit of work for transaction management.</param>
        /// <param name="mapper">The mapper for object transformations.</param>
        public ScheduleService(IScheduleRepository repository, ISchedulerFactory schedulerFactory, ILogger<ScheduleService> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _schedulerFactory = schedulerFactory;
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            InitializeScheduler();
            _logger.LogDebug("Initialized ScheduleService with necessary dependencies.");
        }
        /// <summary>
        /// Initializes the scheduler asynchronously.
        /// </summary>
        private async void InitializeScheduler()
        {
            _scheduler = await _schedulerFactory.GetScheduler();
        }
        /// <summary>
        /// Creates a new schedule asynchronously and schedules jobs if active.
        /// </summary>
        /// <param name="scheduleRequest">The schedule request data.</param>
        /// <param name="cancellationToken">Cancellation token for async operations.</param>
        public async Task CreateScheduleAsync(ScheduleRequest scheduleRequest, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Creating schedule.");
            var schedule = _mapper.Map<Schedule>(scheduleRequest);
            _repository.Insert(schedule);
            _unitOfWork.Save();
            _logger.LogInformation("Schedule created and saved.");

            if (schedule.IsActive)
            {
                _logger.LogInformation("Schedule is active. Scheduling job.");
                await ScheduleJob(schedule, cancellationToken);
            }
            else
            {
                _logger.LogInformation("Schedule is not active. No job scheduled.");
            }
        }
        /// <summary>
        /// Updates an existing schedule asynchronously and manages job scheduling based on activation status.
        /// </summary>
        /// <param name="id">The ID of the schedule to update.</param>
        /// <param name="scheduleRequest">The updated schedule data.</param>
        /// <param name="cancellationToken">Cancellation token for async operations.</param>
        public async Task UpdateScheduleAsync(Guid id, ScheduleRequest scheduleRequest, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Updating schedule {ScheduleId}.", id);
            var schedule = await _repository.GetByIdAsync(id);
            if (schedule == null)
            {
                _logger.LogWarning("Schedule {ScheduleId} not found.", id);
                throw new KeyNotFoundException("Schedule not found");
            }

            // Ghi nhận trạng thái hoạt động trước cập nhật
            bool wasActive = schedule.IsActive;

            // Áp dụng các cập nhật vào lịch trình
            _mapper.Map(scheduleRequest, schedule);
            _repository.Update(schedule);
            _unitOfWork.Save();
            _logger.LogInformation("Schedule updated.");

            // Xóa công việc hiện tại nếu nó đã tồn tại
            if (await _scheduler.CheckExists(new JobKey(id.ToString())))
            {
                await _scheduler.DeleteJob(new JobKey(id.ToString()));
            }

            // Lên lịch công việc mới nếu lịch trình đang hoạt động
            if (schedule.IsActive)
            {
                _logger.LogInformation("Scheduling job for updated schedule.");
                await ScheduleJob(schedule, cancellationToken);
            }
        }

        /// <summary>
        /// Deletes a schedule asynchronously and unschedules any associated jobs.
        /// </summary>
        /// <param name="id">The ID of the schedule to delete.</param>
        /// <param name="cancellationToken">Cancellation token for async operations.</param>
        public async Task DeleteScheduleAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Deleting schedule {ScheduleId}.", id);
            var schedule = await _repository.GetByIdAsync(id);
            if (schedule != null)
            {
                await _repository.DeleteAsync(schedule);
                _unitOfWork.Save();
                _logger.LogInformation("Schedule deleted. Unscheduling job.");
                await UnscheduleJob(id, cancellationToken);
            }
            else
            {
                _logger.LogWarning("Attempted to delete a non-existing schedule {ScheduleId}.", id);
            }
        }
        /// <summary>
        /// Retrieves a schedule by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the schedule to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token for async operations.</param>
        /// <returns>A data transfer object representing the schedule.</returns>
        public async Task<ScheduleDTO> GetScheduleByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Retrieving schedule by ID {ScheduleId}.", id);
            return _mapper.Map<ScheduleDTO>(await _repository.GetByIdAsync(id));
        }
        /// <summary>
        /// Retrieves all schedules asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token for async operations.</param>
        /// <returns>A collection of schedule data transfer objects.</returns>
        public async Task<IEnumerable<ScheduleDTO>> GetAllSchedulesAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Retrieving all schedules.");
            return _mapper.Map<IEnumerable<ScheduleDTO>>(await _repository.GetAllAsync());
        }
        /// <summary>
        /// Schedules a job for a given schedule asynchronously.
        /// </summary>
        /// <param name="schedule">The schedule for which to schedule the job.</param>
        /// <param name="cancellationToken">Cancellation token for async operations.</param>
        private async Task ScheduleJob(Schedule schedule, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Scheduling job for schedule {ScheduleId}.", schedule.Id);
            var jobKey = new JobKey(schedule.Id.ToString());
            IJobDetail job = JobBuilder.Create<ExecuteJob>()
                                       .WithIdentity(jobKey)
                                       .UsingJobData("Type", schedule.Type)
                                       .UsingJobData("Area", schedule.Area)
                                       .UsingJobData("AreaSensor", schedule.AreaSensor)
                                       .UsingJobData("Device", schedule.Device)
                                       .UsingJobData("StartValue", schedule.StartValue)
                                       .UsingJobData("Status",schedule.Status)
                                       .UsingJobData("EndValue", schedule.EndValue)
                                       .Build();
            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity($"Trigger-{schedule.Id}")
                                             .StartAt(schedule.StartDate)
                                             .EndAt(schedule.EndDate)
                                             .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).RepeatForever())
                                             .Build();

            await _scheduler.ScheduleJob(job, trigger);
            _logger.LogInformation("Job scheduled for schedule {ScheduleId}.", schedule.Id);
        }
        /// <summary>
        /// Unschedules a job associated with a specific schedule ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the schedule for which to unschedule the job.</param>
        /// <param name="cancellationToken">Cancellation token for async operations.</param>
        private async Task UnscheduleJob(Guid id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Unscheduling job for schedule {ScheduleId}.", id);
            var jobKey = new JobKey(id.ToString());
            if (await _scheduler.CheckExists(jobKey))
            {
                await _scheduler.DeleteJob(jobKey);
                _logger.LogInformation("Job unscheduled for schedule {ScheduleId}.", id);
            }
        }

        /// <summary>
        /// Retrieves a paginated list of schedules based on the provided query and paging parameters.
        /// </summary>
        /// <param name="scheduleQuery">The query parameters to filter schedules.</param>
        /// <param name="pagingParams">The paging parameters to paginate the result.</param>
        /// <param name="cancellationToken">Cancellation token for async operations.</param>
        /// <returns>A paginated response containing a list of schedules.</returns>
        public async Task<PagedFarmResponse<ScheduleDTO>> GetAllAsync(ScheduleQuery scheduleQuery, IPagingParams pagingParams, CancellationToken cancellationToken = default)
        {
            var mapper = _mapper.Map<ScheduleQueryDTO>(scheduleQuery);
            var result = await _repository.GetAllAsync(mapper, cancellationToken);
            var totalItems = result.Count();
            var itemPage = result.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                                .Take(pagingParams.PageSize)
                                .ToList();
            return new PagedFarmResponse<ScheduleDTO>(itemPage.Select(x => _mapper.Map<ScheduleDTO>(x)), pagingParams.PageNumber, pagingParams.PageSize, totalItems);
        }
    }
}