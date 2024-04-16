using Core.Entities;
using DAL.Context;
using DAL.Repositories.UnitOfWork;
using farm_api.Ulities;
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
        public Seeder(FarmContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async void InitData()
        {
            _context.Database.EnsureCreated();
            if (_context.Farms.Any())
            {
                return;
            }
            _context.AddRange(MockDataGenerator.GenerateEnvironments(30, 70, "KV2"));
            AddDevices(AddFarm());
            AddCameras();
            _unitOfWork.Save();
        }

        private Farm AddFarm()
        {
            Farm farm = new Farm() { Name = "farm-2", ControllerCode = "esp8266/ledControl", SensorLocation = "KV2" };
            _context.Add(farm);
            _unitOfWork.Save();
            return farm;
        }
        private IList<Device> AddDevices(Farm farm)
        {
            #region data devices
            IList<Device> devices = new List<Device>() {
            new(){ Name="Đèn 1",Type="lamp",Status=false,FarmId=farm.Id,Order=0},
            new(){ Name="Đèn 2",Type="lamp",Status=false,FarmId=farm.Id,Order=1},
            new(){ Name="Đèn 3",Type="lamp",Status=false,FarmId=farm.Id, Order = 2},
            new(){ Name="Đèn 4",Type="lamp",Status=false,FarmId=farm.Id, Order = 3},
            new(){ Name="Quạt 5",Type="fan",Status=false,FarmId=farm.Id ,Order=4 },
            new(){ Name="Quạt 6",Type="fan",Status=false,FarmId=farm.Id,Order=5},
            new(){ Name="Quạt 7",Type="fan",Status=false,FarmId=farm.Id, Order = 6},
            new(){ Name="Quạt 8",Type="fan",Status=false,FarmId=farm.Id, Order = 7},
            };
            #endregion
            _context.AddRange(devices);
            _unitOfWork.Save();
            return devices;
        }
        private IList<Camera> AddCameras()
        {
            #region data devices
            IList<Camera> cameras = new List<Camera>() {
            new(){ Name="Camera khu A",IPAddress="192.168.1.10",Port=8080,Location="Nhà máy chăn nuôi"},
            new(){ Name="Camera khu B",IPAddress="192.168.1.20",Port=8080,Location="Khu vực chuồng gia súc"},
            new(){ Name="Camera khu C",IPAddress="192.168.1.30",Port=8080,Location="Khu vực trang trại"},
            new(){ Name="Camera khu D",IPAddress="192.168.1.40",Port=8080,Location="Khu vực vườn rau"},
            new(){ Name="Camera khu E",IPAddress="192.168.1.50",Port=8080,Location="Khu vực chuồng gia cầm"},

            };
            #endregion
            _context.AddRange(cameras);
            _unitOfWork.Save();
            return cameras;
        }
    }
}
