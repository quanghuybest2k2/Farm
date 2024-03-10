﻿using DAL.Context;
using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Environment = Core.Entities.Environment;

namespace DAL.Seeder
{
    public class Seeder : ISeeder
    {
        private readonly FarmContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public Seeder(FarmContext context,IUnitOfWork unitOfWork )
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async void InitData()
        {
            _context.Database.EnsureCreated();
            if (_context.Environments.Any())
            {
                return;
            }
            AddEnvironments();
        }
        private IList<Environment> AddEnvironments()
        {
            IList<Environment> env = new List<Environment>()
            {
                new Environment(){Temperature=25,AirQuality=100,SensorLocation="Office",Brightness=500 },
                new Environment(){Temperature=28,AirQuality=50,SensorLocation="WareHouse",Brightness=750 },
                new Environment(){Temperature=27,AirQuality=25,SensorLocation="Factory",Brightness=620 },


            };
            _context.AddRange(env);
            _unitOfWork.Save();
            return env;
        }
    }
}
