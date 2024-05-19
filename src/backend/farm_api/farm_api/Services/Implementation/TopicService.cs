using DAL.Repositories.Interface;
using farm_api.Services.Interface;
using Quartz.Impl.Triggers;

namespace farm_api.Services.Implementation
{
    public class TopicService : ITopicService
    {
        private readonly IFarmRepositorty _farmRepositorty;
        public TopicService(IFarmRepositorty farmRepositorty)
        {
            _farmRepositorty = farmRepositorty;
        }
        public async Task<IEnumerable<string>> GetAllTopicAsync(CancellationToken cancellationToken = default)
        {
            var topic = new List<string>();
            var farms = await _farmRepositorty.GetAllAsync(cancellationToken);
            foreach (var farm in farms)
            {
                if (!string.IsNullOrEmpty(farm.SensorLocation))
                {
                    topic.Add(farm.SensorLocation);
                }
                if (!string.IsNullOrEmpty(farm.DeviceStatusCode))
                {
                    topic.Add(farm.DeviceStatusCode);
                }
            }
            return topic;
        }
    }
}
