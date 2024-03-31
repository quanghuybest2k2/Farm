using Core.Entities;
using DAL.Context;
using DAL.Repositories.UnitOfWork;
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
            if (_context.Environments.Any())
            {
                return;
            }
            AddDevices(AddFarm());
            AddEnvironments();
            AddCameras();
        }
        private IList<Environment> AddEnvironments()
        {

            #region data environment
            IList<Environment> env = new List<Environment>() {
                new()
                {
                    Temperature = 11,
                    AirQuality = 4,
                    SensorLocation = "Company",
                    Brightness = 1451
                },
    new()
    {
        Temperature = 26,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 1563
    },
    new()
    {
        Temperature = 20,
        AirQuality = 15,
        SensorLocation = "WareHouse",
        Brightness = 861
    },
    new()
    {
        Temperature = 46,
        AirQuality = 0,
        SensorLocation = "WareHouse",
        Brightness = 1356
    },
    new()
    {
        Temperature = 47,
        AirQuality = 34,
        SensorLocation = "WareHouse",
        Brightness = 1376
    },
    new()
    {
        Temperature = 30,
        AirQuality = 67,
        SensorLocation = "Company",
        Brightness = 960
    },
    new()
    {
        Temperature = 7,
        AirQuality = 71,
        SensorLocation = "Company",
        Brightness = 312
    },
    new()
    {
        Temperature = 43,
        AirQuality = 3,
        SensorLocation = "WareHouse",
        Brightness = 662
    },
    new()
    {
        Temperature = 43,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 556
    },
    new()
    {
        Temperature = 36,
        AirQuality = 1,
        SensorLocation = "WareHouse",
        Brightness = 235
    },
    new()
    {
        Temperature = 7,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 743
    },
    new()
    {
        Temperature = 46,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1150
    },
    new()
    {
        Temperature = 8,
        AirQuality = 93,
        SensorLocation = "WareHouse",
        Brightness = 611
    },
    new()
    {
        Temperature = 37,
        AirQuality = 0,
        SensorLocation = "Company",
        Brightness = 409
    },
    new()
    {
        Temperature = 34,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 515
    },
    new()
    {
        Temperature = 48,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 1112
    },
    new()
    {
        Temperature = 26,
        AirQuality = 65,
        SensorLocation = "Office",
        Brightness = 862
    },
    new()
    {
        Temperature = 15,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 1075
    },
    new()
    {
        Temperature = 35,
        AirQuality = 84,
        SensorLocation = "WareHouse",
        Brightness = 1572
    },
    new()
    {
        Temperature = 44,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 296
    },
    new()
    {
        Temperature = 26,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 1088
    },
    new()
    {
        Temperature = 31,
        AirQuality = 14,
        SensorLocation = "Company",
        Brightness = 1013
    },
    new()
    {
        Temperature = 20,
        AirQuality = 19,
        SensorLocation = "Company",
        Brightness = 483
    },
    new()
    {
        Temperature = 28,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 538
    },
    new()
    {
        Temperature = 40,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 1484
    },
    new()
    {
        Temperature = 41,
        AirQuality = 4,
        SensorLocation = "Company",
        Brightness = 713
    },
    new()
    {
        Temperature = 26,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 299
    },
    new()
    {
        Temperature = 22,
        AirQuality = 71,
        SensorLocation = "WareHouse",
        Brightness = 1411
    },
    new()
    {
        Temperature = 51,
        AirQuality = 52,
        SensorLocation = "Company",
        Brightness = 1243
    },
    new()
    {
        Temperature = 9,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 1372
    },
    new()
    {
        Temperature = 11,
        AirQuality = 71,
        SensorLocation = "WareHouse",
        Brightness = 1135
    },
    new()
    {
        Temperature = 51,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 1400
    },
    new()
    {
        Temperature = 12,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 994
    },
    new()
    {
        Temperature = 46,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1115
    },
    new()
    {
        Temperature = 44,
        AirQuality = 33,
        SensorLocation = "Company",
        Brightness = 816
    },
    new()
    {
        Temperature = 13,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 448
    },
    new()
    {
        Temperature = 48,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 616
    },
    new()
    {
        Temperature = 42,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 1025
    },
    new()
    {
        Temperature = 27,
        AirQuality = 62,
        SensorLocation = "WareHouse",
        Brightness = 1238
    },
    new()
    {
        Temperature = 17,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1154
    },
    new()
    {
        Temperature = 24,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 708
    },
    new()
    {
        Temperature = 15,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 230
    },
    new()
    {
        Temperature = 25,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 441
    },
    new()
    {
        Temperature = 46,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 548
    },
    new()
    {
        Temperature = 47,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1097
    },
    new()
    {
        Temperature = 14,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 358
    },
    new()
    {
        Temperature = 36,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1292
    },
    new()
    {
        Temperature = 30,
        AirQuality = 30,
        SensorLocation = "Company",
        Brightness = 1552
    },
    new()
    {
        Temperature = 21,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1089
    },
    new()
    {
        Temperature = 43,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1567
    },
    new()
    {
        Temperature = 36,
        AirQuality = 94,
        SensorLocation = "Company",
        Brightness = 391
    },
    new()
    {
        Temperature = 47,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 288
    },
    new()
    {
        Temperature = 31,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 779
    },
    new()
    {
        Temperature = 52,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 1346
    },
    new()
    {
        Temperature = 16,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 53,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 1079
    },
    new()
    {
        Temperature = 54,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 1316
    },
    new()
    {
        Temperature = 53,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1127
    },
    new()
    {
        Temperature = 13,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 1306
    },
    new()
    {
        Temperature = 28,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 325
    },
    new()
    {
        Temperature = 26,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 595
    },
    new()
    {
        Temperature = 22,
        AirQuality = 46,
        SensorLocation = "WareHouse",
        Brightness = 1530
    },
    new()
    {
        Temperature = 54,
        AirQuality = 12,
        SensorLocation = "Office",
        Brightness = 1585
    },
    new()
    {
        Temperature = 24,
        AirQuality = 64,
        SensorLocation = "WareHouse",
        Brightness = 362
    },
    new()
    {
        Temperature = 26,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 852
    },
    new()
    {
        Temperature = 18,
        AirQuality = 88,
        SensorLocation = "Company",
        Brightness = 1207
    },
    new()
    {
        Temperature = 45,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 636
    },
    new()
    {
        Temperature = 26,
        AirQuality = 78,
        SensorLocation = "Company",
        Brightness = 776
    },
    new()
    {
        Temperature = 22,
        AirQuality = 81,
        SensorLocation = "Company",
        Brightness = 1311
    },
    new()
    {
        Temperature = 25,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 1235
    },
    new()
    {
        Temperature = 26,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 429
    },
    new()
    {
        Temperature = 24,
        AirQuality = 71,
        SensorLocation = "Company",
        Brightness = 1484
    },
    new()
    {
        Temperature = 51,
        AirQuality = 43,
        SensorLocation = "Company",
        Brightness = 1041
    },
    new()
    {
        Temperature = 30,
        AirQuality = 54,
        SensorLocation = "Office",
        Brightness = 876
    },
    new()
    {
        Temperature = 22,
        AirQuality = 26,
        SensorLocation = "Office",
        Brightness = 916
    },
    new()
    {
        Temperature = 38,
        AirQuality = 99,
        SensorLocation = "Company",
        Brightness = 604
    },
    new()
    {
        Temperature = 9,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 1227
    },
    new()
    {
        Temperature = 52,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1195
    },
    new()
    {
        Temperature = 16,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 786
    },
    new()
    {
        Temperature = 18,
        AirQuality = 83,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 52,
        AirQuality = 52,
        SensorLocation = "WareHouse",
        Brightness = 1598
    },
    new()
    {
        Temperature = 36,
        AirQuality = 80,
        SensorLocation = "WareHouse",
        Brightness = 811
    },
    new()
    {
        Temperature = 16,
        AirQuality = 45,
        SensorLocation = "Company",
        Brightness = 1271
    },
    new()
    {
        Temperature = 41,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 948
    },
    new()
    {
        Temperature = 19,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 889
    },
    new()
    {
        Temperature = 34,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 1345
    },
    new()
    {
        Temperature = 15,
        AirQuality = 66,
        SensorLocation = "WareHouse",
        Brightness = 1449
    },
    new()
    {
        Temperature = 36,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 1365
    },
    new()
    {
        Temperature = 21,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 790
    },
    new()
    {
        Temperature = 46,
        AirQuality = 29,
        SensorLocation = "WareHouse",
        Brightness = 1595
    },
    new()
    {
        Temperature = 33,
        AirQuality = 92,
        SensorLocation = "Company",
        Brightness = 1277
    },
    new()
    {
        Temperature = 21,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 761
    },
    new()
    {
        Temperature = 42,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 573
    },
    new()
    {
        Temperature = 39,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 320
    },
    new()
    {
        Temperature = 39,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 1456
    },
    new()
    {
        Temperature = 40,
        AirQuality = 46,
        SensorLocation = "Company",
        Brightness = 516
    },
    new()
    {
        Temperature = 46,
        AirQuality = 18,
        SensorLocation = "Company",
        Brightness = 489
    },
    new()
    {
        Temperature = 53,
        AirQuality = 3,
        SensorLocation = "WareHouse",
        Brightness = 1435
    },
    new()
    {
        Temperature = 25,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 1063
    },
    new()
    {
        Temperature = 44,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 647
    },
    new()
    {
        Temperature = 14,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 1404
    },
    new()
    {
        Temperature = 33,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 863
    },
    new()
    {
        Temperature = 44,
        AirQuality = 66,
        SensorLocation = "Office",
        Brightness = 1073
    },
    new()
    {
        Temperature = 17,
        AirQuality = 89,
        SensorLocation = "WareHouse",
        Brightness = 945
    },
    new()
    {
        Temperature = 22,
        AirQuality = 55,
        SensorLocation = "Company",
        Brightness = 419
    },
    new()
    {
        Temperature = 6,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1141
    },
    new()
    {
        Temperature = 53,
        AirQuality = 100,
        SensorLocation = "Company",
        Brightness = 1049
    },
    new()
    {
        Temperature = 7,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 1050
    },
    new()
    {
        Temperature = 34,
        AirQuality = 45,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 51,
        AirQuality = 57,
        SensorLocation = "WareHouse",
        Brightness = 245
    },
    new()
    {
        Temperature = 17,
        AirQuality = 20,
        SensorLocation = "Company",
        Brightness = 1064
    },
    new()
    {
        Temperature = 30,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 1083
    },
    new()
    {
        Temperature = 46,
        AirQuality = 23,
        SensorLocation = "WareHouse",
        Brightness = 371
    },
    new()
    {
        Temperature = 42,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 1018
    },
    new()
    {
        Temperature = 43,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 1177
    },
    new()
    {
        Temperature = 27,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 766
    },
    new()
    {
        Temperature = 40,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 617
    },
    new()
    {
        Temperature = 21,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 845
    },
    new()
    {
        Temperature = 13,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 373
    },
    new()
    {
        Temperature = 16,
        AirQuality = 12,
        SensorLocation = "Company",
        Brightness = 976
    },
    new()
    {
        Temperature = 33,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1171
    },
    new()
    {
        Temperature = 52,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 939
    },
    new()
    {
        Temperature = 25,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 557
    },
    new()
    {
        Temperature = 42,
        AirQuality = 75,
        SensorLocation = "Office",
        Brightness = 1162
    },
    new()
    {
        Temperature = 9,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 978
    },
    new()
    {
        Temperature = 38,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 353
    },
    new()
    {
        Temperature = 44,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 597
    },
    new()
    {
        Temperature = 11,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 656
    },
    new()
    {
        Temperature = 35,
        AirQuality = 4,
        SensorLocation = "Office",
        Brightness = 1271
    },
    new()
    {
        Temperature = 41,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1222
    },
    new()
    {
        Temperature = 36,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 657
    },
    new()
    {
        Temperature = 52,
        AirQuality = 26,
        SensorLocation = "Company",
        Brightness = 1337
    },
    new()
    {
        Temperature = 35,
        AirQuality = 88,
        SensorLocation = "Office",
        Brightness = 1347
    },
    new()
    {
        Temperature = 37,
        AirQuality = 33,
        SensorLocation = "Company",
        Brightness = 855
    },
    new()
    {
        Temperature = 34,
        AirQuality = 68,
        SensorLocation = "Company",
        Brightness = 337
    },
    new()
    {
        Temperature = 10,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 254
    },
    new()
    {
        Temperature = 43,
        AirQuality = 93,
        SensorLocation = "WareHouse",
        Brightness = 629
    },
    new()
    {
        Temperature = 22,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 821
    },
    new()
    {
        Temperature = 33,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 16,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1574
    },
    new()
    {
        Temperature = 9,
        AirQuality = 77,
        SensorLocation = "Office",
        Brightness = 1553
    },
    new()
    {
        Temperature = 43,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 660
    },
    new()
    {
        Temperature = 14,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 1114
    },
    new()
    {
        Temperature = 10,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 1335
    },
    new()
    {
        Temperature = 48,
        AirQuality = 46,
        SensorLocation = "WareHouse",
        Brightness = 691
    },
    new()
    {
        Temperature = 9,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 1135
    },
    new()
    {
        Temperature = 13,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 645
    },
    new()
    {
        Temperature = 33,
        AirQuality = 20,
        SensorLocation = "Office",
        Brightness = 678
    },
    new()
    {
        Temperature = 23,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 1448
    },
    new()
    {
        Temperature = 49,
        AirQuality = 5,
        SensorLocation = "Company",
        Brightness = 270
    },
    new()
    {
        Temperature = 37,
        AirQuality = 48,
        SensorLocation = "Company",
        Brightness = 323
    },
    new()
    {
        Temperature = 47,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 1370
    },
    new()
    {
        Temperature = 51,
        AirQuality = 17,
        SensorLocation = "WareHouse",
        Brightness = 842
    },
    new()
    {
        Temperature = 28,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 476
    },
    new()
    {
        Temperature = 29,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 1212
    },
    new()
    {
        Temperature = 47,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 882
    },
    new()
    {
        Temperature = 6,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 1397
    },
    new()
    {
        Temperature = 48,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1559
    },
    new()
    {
        Temperature = 22,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1140
    },
    new()
    {
        Temperature = 6,
        AirQuality = 23,
        SensorLocation = "Office",
        Brightness = 252
    },
    new()
    {
        Temperature = 42,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 604
    },
    new()
    {
        Temperature = 40,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 231
    },
    new()
    {
        Temperature = 19,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 523
    },
    new()
    {
        Temperature = 8,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 278
    },
    new()
    {
        Temperature = 38,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 585
    },
    new()
    {
        Temperature = 9,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 1331
    },
    new()
    {
        Temperature = 32,
        AirQuality = 16,
        SensorLocation = "WareHouse",
        Brightness = 615
    },
    new()
    {
        Temperature = 22,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1281
    },
    new()
    {
        Temperature = 42,
        AirQuality = 13,
        SensorLocation = "Office",
        Brightness = 775
    },
    new()
    {
        Temperature = 42,
        AirQuality = 43,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 28,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 946
    },
    new()
    {
        Temperature = 45,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 873
    },
    new()
    {
        Temperature = 35,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1598
    },
    new()
    {
        Temperature = 19,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 936
    },
    new()
    {
        Temperature = 14,
        AirQuality = 17,
        SensorLocation = "WareHouse",
        Brightness = 507
    },
    new()
    {
        Temperature = 14,
        AirQuality = 52,
        SensorLocation = "Office",
        Brightness = 1148
    },
    new()
    {
        Temperature = 28,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 619
    },
    new()
    {
        Temperature = 30,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 873
    },
    new()
    {
        Temperature = 43,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 237
    },
    new()
    {
        Temperature = 45,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 562
    },
    new()
    {
        Temperature = 11,
        AirQuality = 38,
        SensorLocation = "Office",
        Brightness = 1531
    },
    new()
    {
        Temperature = 33,
        AirQuality = 18,
        SensorLocation = "Company",
        Brightness = 330
    },
    new()
    {
        Temperature = 48,
        AirQuality = 4,
        SensorLocation = "Office",
        Brightness = 472
    },
    new()
    {
        Temperature = 14,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 508
    },
    new()
    {
        Temperature = 50,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1474
    },
    new()
    {
        Temperature = 46,
        AirQuality = 27,
        SensorLocation = "Office",
        Brightness = 1263
    },
    new()
    {
        Temperature = 41,
        AirQuality = 73,
        SensorLocation = "WareHouse",
        Brightness = 1545
    },
    new()
    {
        Temperature = 6,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 1108
    },
    new()
    {
        Temperature = 12,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 960
    },
    new()
    {
        Temperature = 46,
        AirQuality = 28,
        SensorLocation = "WareHouse",
        Brightness = 1437
    },
    new()
    {
        Temperature = 22,
        AirQuality = 63,
        SensorLocation = "Office",
        Brightness = 901
    },
    new()
    {
        Temperature = 6,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 436
    },
    new()
    {
        Temperature = 48,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 1055
    },
    new()
    {
        Temperature = 48,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 1558
    },
    new()
    {
        Temperature = 29,
        AirQuality = 28,
        SensorLocation = "WareHouse",
        Brightness = 539
    },
    new()
    {
        Temperature = 24,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1566
    },
    new()
    {
        Temperature = 35,
        AirQuality = 26,
        SensorLocation = "WareHouse",
        Brightness = 398
    },
    new()
    {
        Temperature = 16,
        AirQuality = 87,
        SensorLocation = "WareHouse",
        Brightness = 1064
    },
    new()
    {
        Temperature = 44,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 982
    },
    new()
    {
        Temperature = 33,
        AirQuality = 98,
        SensorLocation = "Office",
        Brightness = 790
    },
    new()
    {
        Temperature = 31,
        AirQuality = 26,
        SensorLocation = "Office",
        Brightness = 677
    },
    new()
    {
        Temperature = 43,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 1224
    },
    new()
    {
        Temperature = 55,
        AirQuality = 32,
        SensorLocation = "Company",
        Brightness = 876
    },
    new()
    {
        Temperature = 46,
        AirQuality = 9,
        SensorLocation = "WareHouse",
        Brightness = 904
    },
    new()
    {
        Temperature = 33,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 1004
    },
    new()
    {
        Temperature = 32,
        AirQuality = 75,
        SensorLocation = "Office",
        Brightness = 492
    },
    new()
    {
        Temperature = 34,
        AirQuality = 13,
        SensorLocation = "Company",
        Brightness = 810
    },
    new()
    {
        Temperature = 26,
        AirQuality = 77,
        SensorLocation = "WareHouse",
        Brightness = 724
    },
    new()
    {
        Temperature = 46,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 375
    },
    new()
    {
        Temperature = 51,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 969
    },
    new()
    {
        Temperature = 9,
        AirQuality = 53,
        SensorLocation = "WareHouse",
        Brightness = 1489
    },
    new()
    {
        Temperature = 46,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1159
    },
    new()
    {
        Temperature = 24,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 582
    },
    new()
    {
        Temperature = 52,
        AirQuality = 64,
        SensorLocation = "Office",
        Brightness = 491
    },
    new()
    {
        Temperature = 50,
        AirQuality = 75,
        SensorLocation = "Company",
        Brightness = 878
    },
    new()
    {
        Temperature = 27,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 204
    },
    new()
    {
        Temperature = 44,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 903
    },
    new()
    {
        Temperature = 55,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 1362
    },
    new()
    {
        Temperature = 30,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 336
    },
    new()
    {
        Temperature = 53,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 371
    },
    new()
    {
        Temperature = 17,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 646
    },
    new()
    {
        Temperature = 54,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 1028
    },
    new()
    {
        Temperature = 32,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1447
    },
    new()
    {
        Temperature = 31,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 1182
    },
    new()
    {
        Temperature = 50,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 474
    },
    new()
    {
        Temperature = 26,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 320
    },
    new()
    {
        Temperature = 35,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 1063
    },
    new()
    {
        Temperature = 39,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 519
    },
    new()
    {
        Temperature = 46,
        AirQuality = 7,
        SensorLocation = "WareHouse",
        Brightness = 1406
    },
    new()
    {
        Temperature = 16,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 733
    },
    new()
    {
        Temperature = 14,
        AirQuality = 30,
        SensorLocation = "Company",
        Brightness = 1261
    },
    new()
    {
        Temperature = 6,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 872
    },
    new()
    {
        Temperature = 17,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 901
    },
    new()
    {
        Temperature = 10,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 1478
    },
    new()
    {
        Temperature = 39,
        AirQuality = 50,
        SensorLocation = "Company",
        Brightness = 1314
    },
    new()
    {
        Temperature = 29,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 501
    },
    new()
    {
        Temperature = 43,
        AirQuality = 22,
        SensorLocation = "Company",
        Brightness = 1340
    },
    new()
    {
        Temperature = 32,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 1274
    },
    new()
    {
        Temperature = 43,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 1000
    },
    new()
    {
        Temperature = 8,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 985
    },
    new()
    {
        Temperature = 11,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 1392
    },
    new()
    {
        Temperature = 21,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 1584
    },
    new()
    {
        Temperature = 50,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 1598
    },
    new()
    {
        Temperature = 11,
        AirQuality = 38,
        SensorLocation = "Office",
        Brightness = 1091
    },
    new()
    {
        Temperature = 18,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 307
    },
    new()
    {
        Temperature = 36,
        AirQuality = 95,
        SensorLocation = "WareHouse",
        Brightness = 1102
    },
    new()
    {
        Temperature = 50,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 509
    },
    new()
    {
        Temperature = 34,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 835
    },
    new()
    {
        Temperature = 25,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 1397
    },
    new()
    {
        Temperature = 18,
        AirQuality = 81,
        SensorLocation = "WareHouse",
        Brightness = 1222
    },
    new()
    {
        Temperature = 9,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 1008
    },
    new()
    {
        Temperature = 51,
        AirQuality = 31,
        SensorLocation = "Office",
        Brightness = 1582
    },
    new()
    {
        Temperature = 43,
        AirQuality = 25,
        SensorLocation = "Office",
        Brightness = 1247
    },
    new()
    {
        Temperature = 38,
        AirQuality = 49,
        SensorLocation = "Company",
        Brightness = 1437
    },
    new()
    {
        Temperature = 29,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 937
    },
    new()
    {
        Temperature = 23,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 466
    },
    new()
    {
        Temperature = 16,
        AirQuality = 7,
        SensorLocation = "WareHouse",
        Brightness = 301
    },
    new()
    {
        Temperature = 30,
        AirQuality = 69,
        SensorLocation = "Company",
        Brightness = 307
    },
    new()
    {
        Temperature = 30,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 641
    },
    new()
    {
        Temperature = 8,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 557
    },
    new()
    {
        Temperature = 55,
        AirQuality = 12,
        SensorLocation = "WareHouse",
        Brightness = 1309
    },
    new()
    {
        Temperature = 7,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 1348
    },
    new()
    {
        Temperature = 14,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 847
    },
    new()
    {
        Temperature = 29,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 666
    },
    new()
    {
        Temperature = 31,
        AirQuality = 65,
        SensorLocation = "Office",
        Brightness = 654
    },
    new()
    {
        Temperature = 19,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 1157
    },
    new()
    {
        Temperature = 18,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 319
    },
    new()
    {
        Temperature = 5,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 1295
    },
    new()
    {
        Temperature = 33,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 530
    },
    new()
    {
        Temperature = 38,
        AirQuality = 45,
        SensorLocation = "WareHouse",
        Brightness = 1392
    },
    new()
    {
        Temperature = 46,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 1137
    },
    new()
    {
        Temperature = 50,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 250
    },
    new()
    {
        Temperature = 19,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 1015
    },
    new()
    {
        Temperature = 14,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 1178
    },
    new()
    {
        Temperature = 19,
        AirQuality = 82,
        SensorLocation = "WareHouse",
        Brightness = 1549
    },
    new()
    {
        Temperature = 10,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 1486
    },
    new()
    {
        Temperature = 18,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 264
    },
    new()
    {
        Temperature = 49,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1295
    },
    new()
    {
        Temperature = 48,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 210
    },
    new()
    {
        Temperature = 43,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1008
    },
    new()
    {
        Temperature = 27,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 1368
    },
    new()
    {
        Temperature = 26,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 1446
    },
    new()
    {
        Temperature = 13,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 484
    },
    new()
    {
        Temperature = 8,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 1579
    },
    new()
    {
        Temperature = 33,
        AirQuality = 49,
        SensorLocation = "Office",
        Brightness = 460
    },
    new()
    {
        Temperature = 20,
        AirQuality = 36,
        SensorLocation = "Office",
        Brightness = 1009
    },
    new()
    {
        Temperature = 42,
        AirQuality = 58,
        SensorLocation = "Office",
        Brightness = 1558
    },
    new()
    {
        Temperature = 29,
        AirQuality = 49,
        SensorLocation = "Office",
        Brightness = 688
    },
    new()
    {
        Temperature = 36,
        AirQuality = 10,
        SensorLocation = "WareHouse",
        Brightness = 1463
    },
    new()
    {
        Temperature = 43,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 980
    },
    new()
    {
        Temperature = 54,
        AirQuality = 87,
        SensorLocation = "Company",
        Brightness = 220
    },
    new()
    {
        Temperature = 43,
        AirQuality = 80,
        SensorLocation = "Company",
        Brightness = 1252
    },
    new()
    {
        Temperature = 24,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 1285
    },
    new()
    {
        Temperature = 47,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 1576
    },
    new()
    {
        Temperature = 25,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 1031
    },
    new()
    {
        Temperature = 39,
        AirQuality = 58,
        SensorLocation = "WareHouse",
        Brightness = 1211
    },
    new()
    {
        Temperature = 25,
        AirQuality = 33,
        SensorLocation = "Office",
        Brightness = 1393
    },
    new()
    {
        Temperature = 32,
        AirQuality = 73,
        SensorLocation = "Office",
        Brightness = 1418
    },
    new()
    {
        Temperature = 35,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 1471
    },
    new()
    {
        Temperature = 50,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 846
    },
    new()
    {
        Temperature = 38,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 1057
    },
    new()
    {
        Temperature = 44,
        AirQuality = 17,
        SensorLocation = "Office",
        Brightness = 439
    },
    new()
    {
        Temperature = 8,
        AirQuality = 40,
        SensorLocation = "Office",
        Brightness = 1488
    },
    new()
    {
        Temperature = 12,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 655
    },
    new()
    {
        Temperature = 18,
        AirQuality = 12,
        SensorLocation = "Office",
        Brightness = 473
    },
    new()
    {
        Temperature = 38,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 422
    },
    new()
    {
        Temperature = 7,
        AirQuality = 17,
        SensorLocation = "Company",
        Brightness = 724
    },
    new()
    {
        Temperature = 43,
        AirQuality = 42,
        SensorLocation = "WareHouse",
        Brightness = 486
    },
    new()
    {
        Temperature = 43,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 1421
    },
    new()
    {
        Temperature = 19,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 992
    },
    new()
    {
        Temperature = 52,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 588
    },
    new()
    {
        Temperature = 12,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 244
    },
    new()
    {
        Temperature = 52,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 1021
    },
    new()
    {
        Temperature = 17,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 1219
    },
    new()
    {
        Temperature = 6,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1029
    },
    new()
    {
        Temperature = 16,
        AirQuality = 57,
        SensorLocation = "WareHouse",
        Brightness = 485
    },
    new()
    {
        Temperature = 18,
        AirQuality = 41,
        SensorLocation = "Office",
        Brightness = 609
    },
    new()
    {
        Temperature = 11,
        AirQuality = 87,
        SensorLocation = "Company",
        Brightness = 320
    },
    new()
    {
        Temperature = 29,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 1119
    },
    new()
    {
        Temperature = 36,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 1472
    },
    new()
    {
        Temperature = 22,
        AirQuality = 56,
        SensorLocation = "Company",
        Brightness = 426
    },
    new()
    {
        Temperature = 23,
        AirQuality = 72,
        SensorLocation = "Office",
        Brightness = 1257
    },
    new()
    {
        Temperature = 26,
        AirQuality = 42,
        SensorLocation = "Company",
        Brightness = 951
    },
    new()
    {
        Temperature = 51,
        AirQuality = 48,
        SensorLocation = "WareHouse",
        Brightness = 1228
    },
    new()
    {
        Temperature = 34,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 740
    },
    new()
    {
        Temperature = 21,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 680
    },
    new()
    {
        Temperature = 31,
        AirQuality = 89,
        SensorLocation = "WareHouse",
        Brightness = 621
    },
    new()
    {
        Temperature = 54,
        AirQuality = 37,
        SensorLocation = "WareHouse",
        Brightness = 330
    },
    new()
    {
        Temperature = 54,
        AirQuality = 80,
        SensorLocation = "WareHouse",
        Brightness = 1392
    },
    new()
    {
        Temperature = 51,
        AirQuality = 89,
        SensorLocation = "Company",
        Brightness = 1376
    },
    new()
    {
        Temperature = 53,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 507
    },
    new()
    {
        Temperature = 5,
        AirQuality = 58,
        SensorLocation = "Company",
        Brightness = 623
    },
    new()
    {
        Temperature = 5,
        AirQuality = 55,
        SensorLocation = "Office",
        Brightness = 1120
    },
    new()
    {
        Temperature = 10,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 240
    },
    new()
    {
        Temperature = 47,
        AirQuality = 87,
        SensorLocation = "Office",
        Brightness = 817
    },
    new()
    {
        Temperature = 44,
        AirQuality = 69,
        SensorLocation = "Office",
        Brightness = 1527
    },
    new()
    {
        Temperature = 45,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 1409
    },
    new()
    {
        Temperature = 30,
        AirQuality = 88,
        SensorLocation = "Company",
        Brightness = 895
    },
    new()
    {
        Temperature = 8,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1034
    },
    new()
    {
        Temperature = 35,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 1546
    },
    new()
    {
        Temperature = 43,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 432
    },
    new()
    {
        Temperature = 16,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 1451
    },
    new()
    {
        Temperature = 7,
        AirQuality = 26,
        SensorLocation = "WareHouse",
        Brightness = 595
    },
    new()
    {
        Temperature = 49,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 495
    },
    new()
    {
        Temperature = 27,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 1038
    },
    new()
    {
        Temperature = 36,
        AirQuality = 35,
        SensorLocation = "Company",
        Brightness = 1260
    },
    new()
    {
        Temperature = 14,
        AirQuality = 31,
        SensorLocation = "Office",
        Brightness = 229
    },
    new()
    {
        Temperature = 50,
        AirQuality = 98,
        SensorLocation = "Company",
        Brightness = 1264
    },
    new()
    {
        Temperature = 30,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 218
    },
    new()
    {
        Temperature = 34,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 389
    },
    new()
    {
        Temperature = 27,
        AirQuality = 67,
        SensorLocation = "Office",
        Brightness = 347
    },
    new()
    {
        Temperature = 16,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 1017
    },
    new()
    {
        Temperature = 11,
        AirQuality = 95,
        SensorLocation = "WareHouse",
        Brightness = 964
    },
    new()
    {
        Temperature = 7,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 674
    },
    new()
    {
        Temperature = 13,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 233
    },
    new()
    {
        Temperature = 7,
        AirQuality = 31,
        SensorLocation = "Company",
        Brightness = 1037
    },
    new()
    {
        Temperature = 54,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 542
    },
    new()
    {
        Temperature = 43,
        AirQuality = 12,
        SensorLocation = "Company",
        Brightness = 330
    },
    new()
    {
        Temperature = 32,
        AirQuality = 10,
        SensorLocation = "Office",
        Brightness = 1166
    },
    new()
    {
        Temperature = 53,
        AirQuality = 47,
        SensorLocation = "WareHouse",
        Brightness = 1072
    },
    new()
    {
        Temperature = 23,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 505
    },
    new()
    {
        Temperature = 38,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1519
    },
    new()
    {
        Temperature = 19,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 771
    },
    new()
    {
        Temperature = 7,
        AirQuality = 39,
        SensorLocation = "WareHouse",
        Brightness = 1132
    },
    new()
    {
        Temperature = 23,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 1459
    },
    new()
    {
        Temperature = 19,
        AirQuality = 81,
        SensorLocation = "Company",
        Brightness = 1001
    },
    new()
    {
        Temperature = 11,
        AirQuality = 5,
        SensorLocation = "WareHouse",
        Brightness = 568
    },
    new()
    {
        Temperature = 11,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 1471
    },
    new()
    {
        Temperature = 40,
        AirQuality = 11,
        SensorLocation = "Office",
        Brightness = 1379
    },
    new()
    {
        Temperature = 28,
        AirQuality = 96,
        SensorLocation = "WareHouse",
        Brightness = 700
    },
    new()
    {
        Temperature = 23,
        AirQuality = 73,
        SensorLocation = "Office",
        Brightness = 660
    },
    new()
    {
        Temperature = 44,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 605
    },
    new()
    {
        Temperature = 32,
        AirQuality = 69,
        SensorLocation = "WareHouse",
        Brightness = 1300
    },
    new()
    {
        Temperature = 29,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 467
    },
    new()
    {
        Temperature = 21,
        AirQuality = 1,
        SensorLocation = "Company",
        Brightness = 1222
    },
    new()
    {
        Temperature = 41,
        AirQuality = 48,
        SensorLocation = "Company",
        Brightness = 983
    },
    new()
    {
        Temperature = 13,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1128
    },
    new()
    {
        Temperature = 36,
        AirQuality = 48,
        SensorLocation = "Office",
        Brightness = 1130
    },
    new()
    {
        Temperature = 27,
        AirQuality = 90,
        SensorLocation = "Office",
        Brightness = 603
    },
    new()
    {
        Temperature = 27,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 1173
    },
    new()
    {
        Temperature = 47,
        AirQuality = 1,
        SensorLocation = "WareHouse",
        Brightness = 568
    },
    new()
    {
        Temperature = 26,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 1071
    },
    new()
    {
        Temperature = 45,
        AirQuality = 2,
        SensorLocation = "WareHouse",
        Brightness = 1157
    },
    new()
    {
        Temperature = 24,
        AirQuality = 96,
        SensorLocation = "WareHouse",
        Brightness = 342
    },
    new()
    {
        Temperature = 24,
        AirQuality = 49,
        SensorLocation = "Company",
        Brightness = 1110
    },
    new()
    {
        Temperature = 40,
        AirQuality = 92,
        SensorLocation = "Company",
        Brightness = 337
    },
    new()
    {
        Temperature = 24,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 442
    },
    new()
    {
        Temperature = 34,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 644
    },
    new()
    {
        Temperature = 44,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1464
    },
    new()
    {
        Temperature = 47,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 1438
    },
    new()
    {
        Temperature = 9,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 1143
    },
    new()
    {
        Temperature = 31,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 1528
    },
    new()
    {
        Temperature = 23,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1346
    },
    new()
    {
        Temperature = 32,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 807
    },
    new()
    {
        Temperature = 14,
        AirQuality = 10,
        SensorLocation = "WareHouse",
        Brightness = 625
    },
    new()
    {
        Temperature = 51,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 702
    },
    new()
    {
        Temperature = 8,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 1121
    },
    new()
    {
        Temperature = 36,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 315
    },
    new()
    {
        Temperature = 29,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 623
    },
    new()
    {
        Temperature = 51,
        AirQuality = 87,
        SensorLocation = "WareHouse",
        Brightness = 1033
    },
    new()
    {
        Temperature = 10,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 1122
    },
    new()
    {
        Temperature = 53,
        AirQuality = 8,
        SensorLocation = "WareHouse",
        Brightness = 893
    },
    new()
    {
        Temperature = 29,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 1505
    },
    new()
    {
        Temperature = 17,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 1480
    },
    new()
    {
        Temperature = 18,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 1321
    },
    new()
    {
        Temperature = 24,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 694
    },
    new()
    {
        Temperature = 54,
        AirQuality = 86,
        SensorLocation = "WareHouse",
        Brightness = 1380
    },
    new()
    {
        Temperature = 10,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1068
    },
    new()
    {
        Temperature = 48,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 467
    },
    new()
    {
        Temperature = 34,
        AirQuality = 90,
        SensorLocation = "Company",
        Brightness = 485
    },
    new()
    {
        Temperature = 21,
        AirQuality = 73,
        SensorLocation = "WareHouse",
        Brightness = 1100
    },
    new()
    {
        Temperature = 28,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 1295
    },
    new()
    {
        Temperature = 43,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 437
    },
    new()
    {
        Temperature = 45,
        AirQuality = 72,
        SensorLocation = "Office",
        Brightness = 535
    },
    new()
    {
        Temperature = 30,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 1258
    },
    new()
    {
        Temperature = 49,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 1213
    },
    new()
    {
        Temperature = 54,
        AirQuality = 42,
        SensorLocation = "WareHouse",
        Brightness = 1169
    },
    new()
    {
        Temperature = 21,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 1003
    },
    new()
    {
        Temperature = 33,
        AirQuality = 85,
        SensorLocation = "WareHouse",
        Brightness = 915
    },
    new()
    {
        Temperature = 39,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 1506
    },
    new()
    {
        Temperature = 47,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 241
    },
    new()
    {
        Temperature = 38,
        AirQuality = 68,
        SensorLocation = "WareHouse",
        Brightness = 1481
    },
    new()
    {
        Temperature = 30,
        AirQuality = 36,
        SensorLocation = "Office",
        Brightness = 1129
    },
    new()
    {
        Temperature = 15,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 682
    },
    new()
    {
        Temperature = 13,
        AirQuality = 85,
        SensorLocation = "Office",
        Brightness = 632
    },
    new()
    {
        Temperature = 39,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 267
    },
    new()
    {
        Temperature = 23,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1408
    },
    new()
    {
        Temperature = 30,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 773
    },
    new()
    {
        Temperature = 6,
        AirQuality = 35,
        SensorLocation = "Company",
        Brightness = 499
    },
    new()
    {
        Temperature = 30,
        AirQuality = 6,
        SensorLocation = "Office",
        Brightness = 557
    },
    new()
    {
        Temperature = 17,
        AirQuality = 67,
        SensorLocation = "Company",
        Brightness = 1294
    },
    new()
    {
        Temperature = 11,
        AirQuality = 16,
        SensorLocation = "Company",
        Brightness = 795
    },
    new()
    {
        Temperature = 23,
        AirQuality = 94,
        SensorLocation = "Office",
        Brightness = 1556
    },
    new()
    {
        Temperature = 8,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 769
    },
    new()
    {
        Temperature = 47,
        AirQuality = 38,
        SensorLocation = "Company",
        Brightness = 1293
    },
    new()
    {
        Temperature = 18,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 848
    },
    new()
    {
        Temperature = 9,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 1232
    },
    new()
    {
        Temperature = 14,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 1429
    },
    new()
    {
        Temperature = 10,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 1371
    },
    new()
    {
        Temperature = 9,
        AirQuality = 86,
        SensorLocation = "WareHouse",
        Brightness = 603
    },
    new()
    {
        Temperature = 29,
        AirQuality = 29,
        SensorLocation = "Office",
        Brightness = 1132
    },
    new()
    {
        Temperature = 22,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 229
    },
    new()
    {
        Temperature = 51,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 989
    },
    new()
    {
        Temperature = 30,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 269
    },
    new()
    {
        Temperature = 20,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 863
    },
    new()
    {
        Temperature = 20,
        AirQuality = 25,
        SensorLocation = "WareHouse",
        Brightness = 1466
    },
    new()
    {
        Temperature = 27,
        AirQuality = 16,
        SensorLocation = "WareHouse",
        Brightness = 658
    },
    new()
    {
        Temperature = 30,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 1559
    },
    new()
    {
        Temperature = 39,
        AirQuality = 24,
        SensorLocation = "Office",
        Brightness = 1136
    },
    new()
    {
        Temperature = 33,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 578
    },
    new()
    {
        Temperature = 40,
        AirQuality = 68,
        SensorLocation = "WareHouse",
        Brightness = 332
    },
    new()
    {
        Temperature = 18,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 1190
    },
    new()
    {
        Temperature = 22,
        AirQuality = 13,
        SensorLocation = "Office",
        Brightness = 444
    },
    new()
    {
        Temperature = 17,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 1338
    },
    new()
    {
        Temperature = 54,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 922
    },
    new()
    {
        Temperature = 46,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 507
    },
    new()
    {
        Temperature = 14,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 260
    },
    new()
    {
        Temperature = 42,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 880
    },
    new()
    {
        Temperature = 42,
        AirQuality = 66,
        SensorLocation = "WareHouse",
        Brightness = 1502
    },
    new()
    {
        Temperature = 16,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1098
    },
    new()
    {
        Temperature = 27,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1142
    },
    new()
    {
        Temperature = 20,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 492
    },
    new()
    {
        Temperature = 33,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 1518
    },
    new()
    {
        Temperature = 13,
        AirQuality = 60,
        SensorLocation = "WareHouse",
        Brightness = 1306
    },
    new()
    {
        Temperature = 27,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 430
    },
    new()
    {
        Temperature = 49,
        AirQuality = 61,
        SensorLocation = "Company",
        Brightness = 888
    },
    new()
    {
        Temperature = 47,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 1509
    },
    new()
    {
        Temperature = 47,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 457
    },
    new()
    {
        Temperature = 34,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 723
    },
    new()
    {
        Temperature = 43,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1061
    },
    new()
    {
        Temperature = 18,
        AirQuality = 8,
        SensorLocation = "WareHouse",
        Brightness = 1550
    },
    new()
    {
        Temperature = 10,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 963
    },
    new()
    {
        Temperature = 8,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 470
    },
    new()
    {
        Temperature = 30,
        AirQuality = 12,
        SensorLocation = "WareHouse",
        Brightness = 386
    },
    new()
    {
        Temperature = 7,
        AirQuality = 64,
        SensorLocation = "Company",
        Brightness = 1515
    },
    new()
    {
        Temperature = 31,
        AirQuality = 41,
        SensorLocation = "WareHouse",
        Brightness = 1007
    },
    new()
    {
        Temperature = 29,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 1185
    },
    new()
    {
        Temperature = 21,
        AirQuality = 24,
        SensorLocation = "WareHouse",
        Brightness = 446
    },
    new()
    {
        Temperature = 37,
        AirQuality = 66,
        SensorLocation = "Office",
        Brightness = 876
    },
    new()
    {
        Temperature = 13,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 305
    },
    new()
    {
        Temperature = 13,
        AirQuality = 37,
        SensorLocation = "WareHouse",
        Brightness = 1478
    },
    new()
    {
        Temperature = 12,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 981
    },
    new()
    {
        Temperature = 5,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 369
    },
    new()
    {
        Temperature = 23,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 1015
    },
    new()
    {
        Temperature = 7,
        AirQuality = 78,
        SensorLocation = "Office",
        Brightness = 1527
    },
    new()
    {
        Temperature = 35,
        AirQuality = 89,
        SensorLocation = "Office",
        Brightness = 716
    },
    new()
    {
        Temperature = 25,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 1220
    },
    new()
    {
        Temperature = 17,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 19,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 1017
    },
    new()
    {
        Temperature = 54,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 1521
    },
    new()
    {
        Temperature = 50,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 488
    },
    new()
    {
        Temperature = 26,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 844
    },
    new()
    {
        Temperature = 21,
        AirQuality = 50,
        SensorLocation = "Company",
        Brightness = 1465
    },
    new()
    {
        Temperature = 31,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 529
    },
    new()
    {
        Temperature = 49,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 1064
    },
    new()
    {
        Temperature = 21,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 729
    },
    new()
    {
        Temperature = 15,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 468
    },
    new()
    {
        Temperature = 40,
        AirQuality = 90,
        SensorLocation = "Company",
        Brightness = 1328
    },
    new()
    {
        Temperature = 46,
        AirQuality = 67,
        SensorLocation = "WareHouse",
        Brightness = 1436
    },
    new()
    {
        Temperature = 21,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 782
    },
     new()
                {
                    Temperature = 11,
                    AirQuality = 4,
                    SensorLocation = "Company",
                    Brightness = 1451
                },
    new()
    {
        Temperature = 26,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 1563
    },
    new()
    {
        Temperature = 20,
        AirQuality = 15,
        SensorLocation = "WareHouse",
        Brightness = 861
    },
    new()
    {
        Temperature = 46,
        AirQuality = 0,
        SensorLocation = "WareHouse",
        Brightness = 1356
    },
    new()
    {
        Temperature = 47,
        AirQuality = 34,
        SensorLocation = "WareHouse",
        Brightness = 1376
    },
    new()
    {
        Temperature = 30,
        AirQuality = 67,
        SensorLocation = "Company",
        Brightness = 960
    },
    new()
    {
        Temperature = 7,
        AirQuality = 71,
        SensorLocation = "Company",
        Brightness = 312
    },
    new()
    {
        Temperature = 43,
        AirQuality = 3,
        SensorLocation = "WareHouse",
        Brightness = 662
    },
    new()
    {
        Temperature = 43,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 556
    },
    new()
    {
        Temperature = 36,
        AirQuality = 1,
        SensorLocation = "WareHouse",
        Brightness = 235
    },
    new()
    {
        Temperature = 7,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 743
    },
    new()
    {
        Temperature = 46,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1150
    },
    new()
    {
        Temperature = 8,
        AirQuality = 93,
        SensorLocation = "WareHouse",
        Brightness = 611
    },
    new()
    {
        Temperature = 37,
        AirQuality = 0,
        SensorLocation = "Company",
        Brightness = 409
    },
    new()
    {
        Temperature = 34,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 515
    },
    new()
    {
        Temperature = 48,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 1112
    },
    new()
    {
        Temperature = 26,
        AirQuality = 65,
        SensorLocation = "Office",
        Brightness = 862
    },
    new()
    {
        Temperature = 15,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 1075
    },
    new()
    {
        Temperature = 35,
        AirQuality = 84,
        SensorLocation = "WareHouse",
        Brightness = 1572
    },
    new()
    {
        Temperature = 44,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 296
    },
    new()
    {
        Temperature = 26,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 1088
    },
    new()
    {
        Temperature = 31,
        AirQuality = 14,
        SensorLocation = "Company",
        Brightness = 1013
    },
    new()
    {
        Temperature = 20,
        AirQuality = 19,
        SensorLocation = "Company",
        Brightness = 483
    },
    new()
    {
        Temperature = 28,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 538
    },
    new()
    {
        Temperature = 40,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 1484
    },
    new()
    {
        Temperature = 41,
        AirQuality = 4,
        SensorLocation = "Company",
        Brightness = 713
    },
    new()
    {
        Temperature = 26,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 299
    },
    new()
    {
        Temperature = 22,
        AirQuality = 71,
        SensorLocation = "WareHouse",
        Brightness = 1411
    },
    new()
    {
        Temperature = 51,
        AirQuality = 52,
        SensorLocation = "Company",
        Brightness = 1243
    },
    new()
    {
        Temperature = 9,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 1372
    },
    new()
    {
        Temperature = 11,
        AirQuality = 71,
        SensorLocation = "WareHouse",
        Brightness = 1135
    },
    new()
    {
        Temperature = 51,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 1400
    },
    new()
    {
        Temperature = 12,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 994
    },
    new()
    {
        Temperature = 46,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1115
    },
    new()
    {
        Temperature = 44,
        AirQuality = 33,
        SensorLocation = "Company",
        Brightness = 816
    },
    new()
    {
        Temperature = 13,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 448
    },
    new()
    {
        Temperature = 48,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 616
    },
    new()
    {
        Temperature = 42,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 1025
    },
    new()
    {
        Temperature = 27,
        AirQuality = 62,
        SensorLocation = "WareHouse",
        Brightness = 1238
    },
    new()
    {
        Temperature = 17,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1154
    },
    new()
    {
        Temperature = 24,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 708
    },
    new()
    {
        Temperature = 15,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 230
    },
    new()
    {
        Temperature = 25,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 441
    },
    new()
    {
        Temperature = 46,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 548
    },
    new()
    {
        Temperature = 47,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1097
    },
    new()
    {
        Temperature = 14,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 358
    },
    new()
    {
        Temperature = 36,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1292
    },
    new()
    {
        Temperature = 30,
        AirQuality = 30,
        SensorLocation = "Company",
        Brightness = 1552
    },
    new()
    {
        Temperature = 21,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1089
    },
    new()
    {
        Temperature = 43,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1567
    },
    new()
    {
        Temperature = 36,
        AirQuality = 94,
        SensorLocation = "Company",
        Brightness = 391
    },
    new()
    {
        Temperature = 47,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 288
    },
    new()
    {
        Temperature = 31,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 779
    },
    new()
    {
        Temperature = 52,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 1346
    },
    new()
    {
        Temperature = 16,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 53,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 1079
    },
    new()
    {
        Temperature = 54,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 1316
    },
    new()
    {
        Temperature = 53,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1127
    },
    new()
    {
        Temperature = 13,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 1306
    },
    new()
    {
        Temperature = 28,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 325
    },
    new()
    {
        Temperature = 26,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 595
    },
    new()
    {
        Temperature = 22,
        AirQuality = 46,
        SensorLocation = "WareHouse",
        Brightness = 1530
    },
    new()
    {
        Temperature = 54,
        AirQuality = 12,
        SensorLocation = "Office",
        Brightness = 1585
    },
    new()
    {
        Temperature = 24,
        AirQuality = 64,
        SensorLocation = "WareHouse",
        Brightness = 362
    },
    new()
    {
        Temperature = 26,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 852
    },
    new()
    {
        Temperature = 18,
        AirQuality = 88,
        SensorLocation = "Company",
        Brightness = 1207
    },
    new()
    {
        Temperature = 45,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 636
    },
    new()
    {
        Temperature = 26,
        AirQuality = 78,
        SensorLocation = "Company",
        Brightness = 776
    },
    new()
    {
        Temperature = 22,
        AirQuality = 81,
        SensorLocation = "Company",
        Brightness = 1311
    },
    new()
    {
        Temperature = 25,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 1235
    },
    new()
    {
        Temperature = 26,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 429
    },
    new()
    {
        Temperature = 24,
        AirQuality = 71,
        SensorLocation = "Company",
        Brightness = 1484
    },
    new()
    {
        Temperature = 51,
        AirQuality = 43,
        SensorLocation = "Company",
        Brightness = 1041
    },
    new()
    {
        Temperature = 30,
        AirQuality = 54,
        SensorLocation = "Office",
        Brightness = 876
    },
    new()
    {
        Temperature = 22,
        AirQuality = 26,
        SensorLocation = "Office",
        Brightness = 916
    },
    new()
    {
        Temperature = 38,
        AirQuality = 99,
        SensorLocation = "Company",
        Brightness = 604
    },
    new()
    {
        Temperature = 9,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 1227
    },
    new()
    {
        Temperature = 52,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1195
    },
    new()
    {
        Temperature = 16,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 786
    },
    new()
    {
        Temperature = 18,
        AirQuality = 83,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 52,
        AirQuality = 52,
        SensorLocation = "WareHouse",
        Brightness = 1598
    },
    new()
    {
        Temperature = 36,
        AirQuality = 80,
        SensorLocation = "WareHouse",
        Brightness = 811
    },
    new()
    {
        Temperature = 16,
        AirQuality = 45,
        SensorLocation = "Company",
        Brightness = 1271
    },
    new()
    {
        Temperature = 41,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 948
    },
    new()
    {
        Temperature = 19,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 889
    },
    new()
    {
        Temperature = 34,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 1345
    },
    new()
    {
        Temperature = 15,
        AirQuality = 66,
        SensorLocation = "WareHouse",
        Brightness = 1449
    },
    new()
    {
        Temperature = 36,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 1365
    },
    new()
    {
        Temperature = 21,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 790
    },
    new()
    {
        Temperature = 46,
        AirQuality = 29,
        SensorLocation = "WareHouse",
        Brightness = 1595
    },
    new()
    {
        Temperature = 33,
        AirQuality = 92,
        SensorLocation = "Company",
        Brightness = 1277
    },
    new()
    {
        Temperature = 21,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 761
    },
    new()
    {
        Temperature = 42,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 573
    },
    new()
    {
        Temperature = 39,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 320
    },
    new()
    {
        Temperature = 39,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 1456
    },
    new()
    {
        Temperature = 40,
        AirQuality = 46,
        SensorLocation = "Company",
        Brightness = 516
    },
    new()
    {
        Temperature = 46,
        AirQuality = 18,
        SensorLocation = "Company",
        Brightness = 489
    },
    new()
    {
        Temperature = 53,
        AirQuality = 3,
        SensorLocation = "WareHouse",
        Brightness = 1435
    },
    new()
    {
        Temperature = 25,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 1063
    },
    new()
    {
        Temperature = 44,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 647
    },
    new()
    {
        Temperature = 14,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 1404
    },
    new()
    {
        Temperature = 33,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 863
    },
    new()
    {
        Temperature = 44,
        AirQuality = 66,
        SensorLocation = "Office",
        Brightness = 1073
    },
    new()
    {
        Temperature = 17,
        AirQuality = 89,
        SensorLocation = "WareHouse",
        Brightness = 945
    },
    new()
    {
        Temperature = 22,
        AirQuality = 55,
        SensorLocation = "Company",
        Brightness = 419
    },
    new()
    {
        Temperature = 6,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1141
    },
    new()
    {
        Temperature = 53,
        AirQuality = 100,
        SensorLocation = "Company",
        Brightness = 1049
    },
    new()
    {
        Temperature = 7,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 1050
    },
    new()
    {
        Temperature = 34,
        AirQuality = 45,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 51,
        AirQuality = 57,
        SensorLocation = "WareHouse",
        Brightness = 245
    },
    new()
    {
        Temperature = 17,
        AirQuality = 20,
        SensorLocation = "Company",
        Brightness = 1064
    },
    new()
    {
        Temperature = 30,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 1083
    },
    new()
    {
        Temperature = 46,
        AirQuality = 23,
        SensorLocation = "WareHouse",
        Brightness = 371
    },
    new()
    {
        Temperature = 42,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 1018
    },
    new()
    {
        Temperature = 43,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 1177
    },
    new()
    {
        Temperature = 27,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 766
    },
    new()
    {
        Temperature = 40,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 617
    },
    new()
    {
        Temperature = 21,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 845
    },
    new()
    {
        Temperature = 13,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 373
    },
    new()
    {
        Temperature = 16,
        AirQuality = 12,
        SensorLocation = "Company",
        Brightness = 976
    },
    new()
    {
        Temperature = 33,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1171
    },
    new()
    {
        Temperature = 52,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 939
    },
    new()
    {
        Temperature = 25,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 557
    },
    new()
    {
        Temperature = 42,
        AirQuality = 75,
        SensorLocation = "Office",
        Brightness = 1162
    },
    new()
    {
        Temperature = 9,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 978
    },
    new()
    {
        Temperature = 38,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 353
    },
    new()
    {
        Temperature = 44,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 597
    },
    new()
    {
        Temperature = 11,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 656
    },
    new()
    {
        Temperature = 35,
        AirQuality = 4,
        SensorLocation = "Office",
        Brightness = 1271
    },
    new()
    {
        Temperature = 41,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1222
    },
    new()
    {
        Temperature = 36,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 657
    },
    new()
    {
        Temperature = 52,
        AirQuality = 26,
        SensorLocation = "Company",
        Brightness = 1337
    },
    new()
    {
        Temperature = 35,
        AirQuality = 88,
        SensorLocation = "Office",
        Brightness = 1347
    },
    new()
    {
        Temperature = 37,
        AirQuality = 33,
        SensorLocation = "Company",
        Brightness = 855
    },
    new()
    {
        Temperature = 34,
        AirQuality = 68,
        SensorLocation = "Company",
        Brightness = 337
    },
    new()
    {
        Temperature = 10,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 254
    },
    new()
    {
        Temperature = 43,
        AirQuality = 93,
        SensorLocation = "WareHouse",
        Brightness = 629
    },
    new()
    {
        Temperature = 22,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 821
    },
    new()
    {
        Temperature = 33,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 16,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1574
    },
    new()
    {
        Temperature = 9,
        AirQuality = 77,
        SensorLocation = "Office",
        Brightness = 1553
    },
    new()
    {
        Temperature = 43,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 660
    },
    new()
    {
        Temperature = 14,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 1114
    },
    new()
    {
        Temperature = 10,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 1335
    },
    new()
    {
        Temperature = 48,
        AirQuality = 46,
        SensorLocation = "WareHouse",
        Brightness = 691
    },
    new()
    {
        Temperature = 9,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 1135
    },
    new()
    {
        Temperature = 13,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 645
    },
    new()
    {
        Temperature = 33,
        AirQuality = 20,
        SensorLocation = "Office",
        Brightness = 678
    },
    new()
    {
        Temperature = 23,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 1448
    },
    new()
    {
        Temperature = 49,
        AirQuality = 5,
        SensorLocation = "Company",
        Brightness = 270
    },
    new()
    {
        Temperature = 37,
        AirQuality = 48,
        SensorLocation = "Company",
        Brightness = 323
    },
    new()
    {
        Temperature = 47,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 1370
    },
    new()
    {
        Temperature = 51,
        AirQuality = 17,
        SensorLocation = "WareHouse",
        Brightness = 842
    },
    new()
    {
        Temperature = 28,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 476
    },
    new()
    {
        Temperature = 29,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 1212
    },
    new()
    {
        Temperature = 47,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 882
    },
    new()
    {
        Temperature = 6,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 1397
    },
    new()
    {
        Temperature = 48,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1559
    },
    new()
    {
        Temperature = 22,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1140
    },
    new()
    {
        Temperature = 6,
        AirQuality = 23,
        SensorLocation = "Office",
        Brightness = 252
    },
    new()
    {
        Temperature = 42,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 604
    },
    new()
    {
        Temperature = 40,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 231
    },
    new()
    {
        Temperature = 19,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 523
    },
    new()
    {
        Temperature = 8,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 278
    },
    new()
    {
        Temperature = 38,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 585
    },
    new()
    {
        Temperature = 9,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 1331
    },
    new()
    {
        Temperature = 32,
        AirQuality = 16,
        SensorLocation = "WareHouse",
        Brightness = 615
    },
    new()
    {
        Temperature = 22,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1281
    },
    new()
    {
        Temperature = 42,
        AirQuality = 13,
        SensorLocation = "Office",
        Brightness = 775
    },
    new()
    {
        Temperature = 42,
        AirQuality = 43,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 28,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 946
    },
    new()
    {
        Temperature = 45,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 873
    },
    new()
    {
        Temperature = 35,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1598
    },
    new()
    {
        Temperature = 19,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 936
    },
    new()
    {
        Temperature = 14,
        AirQuality = 17,
        SensorLocation = "WareHouse",
        Brightness = 507
    },
    new()
    {
        Temperature = 14,
        AirQuality = 52,
        SensorLocation = "Office",
        Brightness = 1148
    },
    new()
    {
        Temperature = 28,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 619
    },
    new()
    {
        Temperature = 30,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 873
    },
    new()
    {
        Temperature = 43,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 237
    },
    new()
    {
        Temperature = 45,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 562
    },
    new()
    {
        Temperature = 11,
        AirQuality = 38,
        SensorLocation = "Office",
        Brightness = 1531
    },
    new()
    {
        Temperature = 33,
        AirQuality = 18,
        SensorLocation = "Company",
        Brightness = 330
    },
    new()
    {
        Temperature = 48,
        AirQuality = 4,
        SensorLocation = "Office",
        Brightness = 472
    },
    new()
    {
        Temperature = 14,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 508
    },
    new()
    {
        Temperature = 50,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1474
    },
    new()
    {
        Temperature = 46,
        AirQuality = 27,
        SensorLocation = "Office",
        Brightness = 1263
    },
    new()
    {
        Temperature = 41,
        AirQuality = 73,
        SensorLocation = "WareHouse",
        Brightness = 1545
    },
    new()
    {
        Temperature = 6,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 1108
    },
    new()
    {
        Temperature = 12,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 960
    },
    new()
    {
        Temperature = 46,
        AirQuality = 28,
        SensorLocation = "WareHouse",
        Brightness = 1437
    },
    new()
    {
        Temperature = 22,
        AirQuality = 63,
        SensorLocation = "Office",
        Brightness = 901
    },
    new()
    {
        Temperature = 6,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 436
    },
    new()
    {
        Temperature = 48,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 1055
    },
    new()
    {
        Temperature = 48,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 1558
    },
    new()
    {
        Temperature = 29,
        AirQuality = 28,
        SensorLocation = "WareHouse",
        Brightness = 539
    },
    new()
    {
        Temperature = 24,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1566
    },
    new()
    {
        Temperature = 35,
        AirQuality = 26,
        SensorLocation = "WareHouse",
        Brightness = 398
    },
    new()
    {
        Temperature = 16,
        AirQuality = 87,
        SensorLocation = "WareHouse",
        Brightness = 1064
    },
    new()
    {
        Temperature = 44,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 982
    },
    new()
    {
        Temperature = 33,
        AirQuality = 98,
        SensorLocation = "Office",
        Brightness = 790
    },
    new()
    {
        Temperature = 31,
        AirQuality = 26,
        SensorLocation = "Office",
        Brightness = 677
    },
    new()
    {
        Temperature = 43,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 1224
    },
    new()
    {
        Temperature = 55,
        AirQuality = 32,
        SensorLocation = "Company",
        Brightness = 876
    },
    new()
    {
        Temperature = 46,
        AirQuality = 9,
        SensorLocation = "WareHouse",
        Brightness = 904
    },
    new()
    {
        Temperature = 33,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 1004
    },
    new()
    {
        Temperature = 32,
        AirQuality = 75,
        SensorLocation = "Office",
        Brightness = 492
    },
    new()
    {
        Temperature = 34,
        AirQuality = 13,
        SensorLocation = "Company",
        Brightness = 810
    },
    new()
    {
        Temperature = 26,
        AirQuality = 77,
        SensorLocation = "WareHouse",
        Brightness = 724
    },
    new()
    {
        Temperature = 46,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 375
    },
    new()
    {
        Temperature = 51,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 969
    },
    new()
    {
        Temperature = 9,
        AirQuality = 53,
        SensorLocation = "WareHouse",
        Brightness = 1489
    },
    new()
    {
        Temperature = 46,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1159
    },
    new()
    {
        Temperature = 24,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 582
    },
    new()
    {
        Temperature = 52,
        AirQuality = 64,
        SensorLocation = "Office",
        Brightness = 491
    },
    new()
    {
        Temperature = 50,
        AirQuality = 75,
        SensorLocation = "Company",
        Brightness = 878
    },
    new()
    {
        Temperature = 27,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 204
    },
    new()
    {
        Temperature = 44,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 903
    },
    new()
    {
        Temperature = 55,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 1362
    },
    new()
    {
        Temperature = 30,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 336
    },
    new()
    {
        Temperature = 53,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 371
    },
    new()
    {
        Temperature = 17,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 646
    },
    new()
    {
        Temperature = 54,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 1028
    },
    new()
    {
        Temperature = 32,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1447
    },
    new()
    {
        Temperature = 31,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 1182
    },
    new()
    {
        Temperature = 50,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 474
    },
    new()
    {
        Temperature = 26,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 320
    },
    new()
    {
        Temperature = 35,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 1063
    },
    new()
    {
        Temperature = 39,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 519
    },
    new()
    {
        Temperature = 46,
        AirQuality = 7,
        SensorLocation = "WareHouse",
        Brightness = 1406
    },
    new()
    {
        Temperature = 16,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 733
    },
    new()
    {
        Temperature = 14,
        AirQuality = 30,
        SensorLocation = "Company",
        Brightness = 1261
    },
    new()
    {
        Temperature = 6,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 872
    },
    new()
    {
        Temperature = 17,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 901
    },
    new()
    {
        Temperature = 10,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 1478
    },
    new()
    {
        Temperature = 39,
        AirQuality = 50,
        SensorLocation = "Company",
        Brightness = 1314
    },
    new()
    {
        Temperature = 29,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 501
    },
    new()
    {
        Temperature = 43,
        AirQuality = 22,
        SensorLocation = "Company",
        Brightness = 1340
    },
    new()
    {
        Temperature = 32,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 1274
    },
    new()
    {
        Temperature = 43,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 1000
    },
    new()
    {
        Temperature = 8,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 985
    },
    new()
    {
        Temperature = 11,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 1392
    },
    new()
    {
        Temperature = 21,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 1584
    },
    new()
    {
        Temperature = 50,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 1598
    },
    new()
    {
        Temperature = 11,
        AirQuality = 38,
        SensorLocation = "Office",
        Brightness = 1091
    },
    new()
    {
        Temperature = 18,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 307
    },
    new()
    {
        Temperature = 36,
        AirQuality = 95,
        SensorLocation = "WareHouse",
        Brightness = 1102
    },
    new()
    {
        Temperature = 50,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 509
    },
    new()
    {
        Temperature = 34,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 835
    },
    new()
    {
        Temperature = 25,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 1397
    },
    new()
    {
        Temperature = 18,
        AirQuality = 81,
        SensorLocation = "WareHouse",
        Brightness = 1222
    },
    new()
    {
        Temperature = 9,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 1008
    },
    new()
    {
        Temperature = 51,
        AirQuality = 31,
        SensorLocation = "Office",
        Brightness = 1582
    },
    new()
    {
        Temperature = 43,
        AirQuality = 25,
        SensorLocation = "Office",
        Brightness = 1247
    },
    new()
    {
        Temperature = 38,
        AirQuality = 49,
        SensorLocation = "Company",
        Brightness = 1437
    },
    new()
    {
        Temperature = 29,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 937
    },
    new()
    {
        Temperature = 23,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 466
    },
    new()
    {
        Temperature = 16,
        AirQuality = 7,
        SensorLocation = "WareHouse",
        Brightness = 301
    },
    new()
    {
        Temperature = 30,
        AirQuality = 69,
        SensorLocation = "Company",
        Brightness = 307
    },
    new()
    {
        Temperature = 30,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 641
    },
    new()
    {
        Temperature = 8,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 557
    },
    new()
    {
        Temperature = 55,
        AirQuality = 12,
        SensorLocation = "WareHouse",
        Brightness = 1309
    },
    new()
    {
        Temperature = 7,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 1348
    },
    new()
    {
        Temperature = 14,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 847
    },
    new()
    {
        Temperature = 29,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 666
    },
    new()
    {
        Temperature = 31,
        AirQuality = 65,
        SensorLocation = "Office",
        Brightness = 654
    },
    new()
    {
        Temperature = 19,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 1157
    },
    new()
    {
        Temperature = 18,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 319
    },
    new()
    {
        Temperature = 5,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 1295
    },
    new()
    {
        Temperature = 33,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 530
    },
    new()
    {
        Temperature = 38,
        AirQuality = 45,
        SensorLocation = "WareHouse",
        Brightness = 1392
    },
    new()
    {
        Temperature = 46,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 1137
    },
    new()
    {
        Temperature = 50,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 250
    },
    new()
    {
        Temperature = 19,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 1015
    },
    new()
    {
        Temperature = 14,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 1178
    },
    new()
    {
        Temperature = 19,
        AirQuality = 82,
        SensorLocation = "WareHouse",
        Brightness = 1549
    },
    new()
    {
        Temperature = 10,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 1486
    },
    new()
    {
        Temperature = 18,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 264
    },
    new()
    {
        Temperature = 49,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1295
    },
    new()
    {
        Temperature = 48,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 210
    },
    new()
    {
        Temperature = 43,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1008
    },
    new()
    {
        Temperature = 27,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 1368
    },
    new()
    {
        Temperature = 26,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 1446
    },
    new()
    {
        Temperature = 13,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 484
    },
    new()
    {
        Temperature = 8,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 1579
    },
    new()
    {
        Temperature = 33,
        AirQuality = 49,
        SensorLocation = "Office",
        Brightness = 460
    },
    new()
    {
        Temperature = 20,
        AirQuality = 36,
        SensorLocation = "Office",
        Brightness = 1009
    },
    new()
    {
        Temperature = 42,
        AirQuality = 58,
        SensorLocation = "Office",
        Brightness = 1558
    },
    new()
    {
        Temperature = 29,
        AirQuality = 49,
        SensorLocation = "Office",
        Brightness = 688
    },
    new()
    {
        Temperature = 36,
        AirQuality = 10,
        SensorLocation = "WareHouse",
        Brightness = 1463
    },
    new()
    {
        Temperature = 43,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 980
    },
    new()
    {
        Temperature = 54,
        AirQuality = 87,
        SensorLocation = "Company",
        Brightness = 220
    },
    new()
    {
        Temperature = 43,
        AirQuality = 80,
        SensorLocation = "Company",
        Brightness = 1252
    },
    new()
    {
        Temperature = 24,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 1285
    },
    new()
    {
        Temperature = 47,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 1576
    },
    new()
    {
        Temperature = 25,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 1031
    },
    new()
    {
        Temperature = 39,
        AirQuality = 58,
        SensorLocation = "WareHouse",
        Brightness = 1211
    },
    new()
    {
        Temperature = 25,
        AirQuality = 33,
        SensorLocation = "Office",
        Brightness = 1393
    },
    new()
    {
        Temperature = 32,
        AirQuality = 73,
        SensorLocation = "Office",
        Brightness = 1418
    },
    new()
    {
        Temperature = 35,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 1471
    },
    new()
    {
        Temperature = 50,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 846
    },
    new()
    {
        Temperature = 38,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 1057
    },
    new()
    {
        Temperature = 44,
        AirQuality = 17,
        SensorLocation = "Office",
        Brightness = 439
    },
    new()
    {
        Temperature = 8,
        AirQuality = 40,
        SensorLocation = "Office",
        Brightness = 1488
    },
    new()
    {
        Temperature = 12,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 655
    },
    new()
    {
        Temperature = 18,
        AirQuality = 12,
        SensorLocation = "Office",
        Brightness = 473
    },
    new()
    {
        Temperature = 38,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 422
    },
    new()
    {
        Temperature = 7,
        AirQuality = 17,
        SensorLocation = "Company",
        Brightness = 724
    },
    new()
    {
        Temperature = 43,
        AirQuality = 42,
        SensorLocation = "WareHouse",
        Brightness = 486
    },
    new()
    {
        Temperature = 43,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 1421
    },
    new()
    {
        Temperature = 19,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 992
    },
    new()
    {
        Temperature = 52,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 588
    },
    new()
    {
        Temperature = 12,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 244
    },
    new()
    {
        Temperature = 52,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 1021
    },
    new()
    {
        Temperature = 17,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 1219
    },
    new()
    {
        Temperature = 6,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1029
    },
    new()
    {
        Temperature = 16,
        AirQuality = 57,
        SensorLocation = "WareHouse",
        Brightness = 485
    },
    new()
    {
        Temperature = 18,
        AirQuality = 41,
        SensorLocation = "Office",
        Brightness = 609
    },
    new()
    {
        Temperature = 11,
        AirQuality = 87,
        SensorLocation = "Company",
        Brightness = 320
    },
    new()
    {
        Temperature = 29,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 1119
    },
    new()
    {
        Temperature = 36,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 1472
    },
    new()
    {
        Temperature = 22,
        AirQuality = 56,
        SensorLocation = "Company",
        Brightness = 426
    },
    new()
    {
        Temperature = 23,
        AirQuality = 72,
        SensorLocation = "Office",
        Brightness = 1257
    },
    new()
    {
        Temperature = 26,
        AirQuality = 42,
        SensorLocation = "Company",
        Brightness = 951
    },
    new()
    {
        Temperature = 51,
        AirQuality = 48,
        SensorLocation = "WareHouse",
        Brightness = 1228
    },
    new()
    {
        Temperature = 34,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 740
    },
    new()
    {
        Temperature = 21,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 680
    },
    new()
    {
        Temperature = 31,
        AirQuality = 89,
        SensorLocation = "WareHouse",
        Brightness = 621
    },
    new()
    {
        Temperature = 54,
        AirQuality = 37,
        SensorLocation = "WareHouse",
        Brightness = 330
    },
    new()
    {
        Temperature = 54,
        AirQuality = 80,
        SensorLocation = "WareHouse",
        Brightness = 1392
    },
    new()
    {
        Temperature = 51,
        AirQuality = 89,
        SensorLocation = "Company",
        Brightness = 1376
    },
    new()
    {
        Temperature = 53,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 507
    },
    new()
    {
        Temperature = 5,
        AirQuality = 58,
        SensorLocation = "Company",
        Brightness = 623
    },
    new()
    {
        Temperature = 5,
        AirQuality = 55,
        SensorLocation = "Office",
        Brightness = 1120
    },
    new()
    {
        Temperature = 10,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 240
    },
    new()
    {
        Temperature = 47,
        AirQuality = 87,
        SensorLocation = "Office",
        Brightness = 817
    },
    new()
    {
        Temperature = 44,
        AirQuality = 69,
        SensorLocation = "Office",
        Brightness = 1527
    },
    new()
    {
        Temperature = 45,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 1409
    },
    new()
    {
        Temperature = 30,
        AirQuality = 88,
        SensorLocation = "Company",
        Brightness = 895
    },
    new()
    {
        Temperature = 8,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1034
    },
    new()
    {
        Temperature = 35,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 1546
    },
    new()
    {
        Temperature = 43,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 432
    },
    new()
    {
        Temperature = 16,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 1451
    },
    new()
    {
        Temperature = 7,
        AirQuality = 26,
        SensorLocation = "WareHouse",
        Brightness = 595
    },
    new()
    {
        Temperature = 49,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 495
    },
    new()
    {
        Temperature = 27,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 1038
    },
    new()
    {
        Temperature = 36,
        AirQuality = 35,
        SensorLocation = "Company",
        Brightness = 1260
    },
    new()
    {
        Temperature = 14,
        AirQuality = 31,
        SensorLocation = "Office",
        Brightness = 229
    },
    new()
    {
        Temperature = 50,
        AirQuality = 98,
        SensorLocation = "Company",
        Brightness = 1264
    },
    new()
    {
        Temperature = 30,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 218
    },
    new()
    {
        Temperature = 34,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 389
    },
    new()
    {
        Temperature = 27,
        AirQuality = 67,
        SensorLocation = "Office",
        Brightness = 347
    },
    new()
    {
        Temperature = 16,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 1017
    },
    new()
    {
        Temperature = 11,
        AirQuality = 95,
        SensorLocation = "WareHouse",
        Brightness = 964
    },
    new()
    {
        Temperature = 7,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 674
    },
    new()
    {
        Temperature = 13,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 233
    },
    new()
    {
        Temperature = 7,
        AirQuality = 31,
        SensorLocation = "Company",
        Brightness = 1037
    },
    new()
    {
        Temperature = 54,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 542
    },
    new()
    {
        Temperature = 43,
        AirQuality = 12,
        SensorLocation = "Company",
        Brightness = 330
    },
    new()
    {
        Temperature = 32,
        AirQuality = 10,
        SensorLocation = "Office",
        Brightness = 1166
    },
    new()
    {
        Temperature = 53,
        AirQuality = 47,
        SensorLocation = "WareHouse",
        Brightness = 1072
    },
    new()
    {
        Temperature = 23,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 505
    },
    new()
    {
        Temperature = 38,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1519
    },
    new()
    {
        Temperature = 19,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 771
    },
    new()
    {
        Temperature = 7,
        AirQuality = 39,
        SensorLocation = "WareHouse",
        Brightness = 1132
    },
    new()
    {
        Temperature = 23,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 1459
    },
    new()
    {
        Temperature = 19,
        AirQuality = 81,
        SensorLocation = "Company",
        Brightness = 1001
    },
    new()
    {
        Temperature = 11,
        AirQuality = 5,
        SensorLocation = "WareHouse",
        Brightness = 568
    },
    new()
    {
        Temperature = 11,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 1471
    },
    new()
    {
        Temperature = 40,
        AirQuality = 11,
        SensorLocation = "Office",
        Brightness = 1379
    },
    new()
    {
        Temperature = 28,
        AirQuality = 96,
        SensorLocation = "WareHouse",
        Brightness = 700
    },
    new()
    {
        Temperature = 23,
        AirQuality = 73,
        SensorLocation = "Office",
        Brightness = 660
    },
    new()
    {
        Temperature = 44,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 605
    },
    new()
    {
        Temperature = 32,
        AirQuality = 69,
        SensorLocation = "WareHouse",
        Brightness = 1300
    },
    new()
    {
        Temperature = 29,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 467
    },
    new()
    {
        Temperature = 21,
        AirQuality = 1,
        SensorLocation = "Company",
        Brightness = 1222
    },
    new()
    {
        Temperature = 41,
        AirQuality = 48,
        SensorLocation = "Company",
        Brightness = 983
    },
    new()
    {
        Temperature = 13,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1128
    },
    new()
    {
        Temperature = 36,
        AirQuality = 48,
        SensorLocation = "Office",
        Brightness = 1130
    },
    new()
    {
        Temperature = 27,
        AirQuality = 90,
        SensorLocation = "Office",
        Brightness = 603
    },
    new()
    {
        Temperature = 27,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 1173
    },
    new()
    {
        Temperature = 47,
        AirQuality = 1,
        SensorLocation = "WareHouse",
        Brightness = 568
    },
    new()
    {
        Temperature = 26,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 1071
    },
    new()
    {
        Temperature = 45,
        AirQuality = 2,
        SensorLocation = "WareHouse",
        Brightness = 1157
    },
    new()
    {
        Temperature = 24,
        AirQuality = 96,
        SensorLocation = "WareHouse",
        Brightness = 342
    },
    new()
    {
        Temperature = 24,
        AirQuality = 49,
        SensorLocation = "Company",
        Brightness = 1110
    },
    new()
    {
        Temperature = 40,
        AirQuality = 92,
        SensorLocation = "Company",
        Brightness = 337
    },
    new()
    {
        Temperature = 24,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 442
    },
    new()
    {
        Temperature = 34,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 644
    },
    new()
    {
        Temperature = 44,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1464
    },
    new()
    {
        Temperature = 47,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 1438
    },
    new()
    {
        Temperature = 9,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 1143
    },
    new()
    {
        Temperature = 31,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 1528
    },
    new()
    {
        Temperature = 23,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1346
    },
    new()
    {
        Temperature = 32,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 807
    },
    new()
    {
        Temperature = 14,
        AirQuality = 10,
        SensorLocation = "WareHouse",
        Brightness = 625
    },
    new()
    {
        Temperature = 51,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 702
    },
    new()
    {
        Temperature = 8,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 1121
    },
    new()
    {
        Temperature = 36,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 315
    },
    new()
    {
        Temperature = 29,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 623
    },
    new()
    {
        Temperature = 51,
        AirQuality = 87,
        SensorLocation = "WareHouse",
        Brightness = 1033
    },
    new()
    {
        Temperature = 10,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 1122
    },
    new()
    {
        Temperature = 53,
        AirQuality = 8,
        SensorLocation = "WareHouse",
        Brightness = 893
    },
    new()
    {
        Temperature = 29,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 1505
    },
    new()
    {
        Temperature = 17,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 1480
    },
    new()
    {
        Temperature = 18,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 1321
    },
    new()
    {
        Temperature = 24,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 694
    },
    new()
    {
        Temperature = 54,
        AirQuality = 86,
        SensorLocation = "WareHouse",
        Brightness = 1380
    },
    new()
    {
        Temperature = 10,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1068
    },
    new()
    {
        Temperature = 48,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 467
    },
    new()
    {
        Temperature = 34,
        AirQuality = 90,
        SensorLocation = "Company",
        Brightness = 485
    },
    new()
    {
        Temperature = 21,
        AirQuality = 73,
        SensorLocation = "WareHouse",
        Brightness = 1100
    },
    new()
    {
        Temperature = 28,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 1295
    },
    new()
    {
        Temperature = 43,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 437
    },
    new()
    {
        Temperature = 45,
        AirQuality = 72,
        SensorLocation = "Office",
        Brightness = 535
    },
    new()
    {
        Temperature = 30,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 1258
    },
    new()
    {
        Temperature = 49,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 1213
    },
    new()
    {
        Temperature = 54,
        AirQuality = 42,
        SensorLocation = "WareHouse",
        Brightness = 1169
    },
    new()
    {
        Temperature = 21,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 1003
    },
    new()
    {
        Temperature = 33,
        AirQuality = 85,
        SensorLocation = "WareHouse",
        Brightness = 915
    },
    new()
    {
        Temperature = 39,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 1506
    },
    new()
    {
        Temperature = 47,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 241
    },
    new()
    {
        Temperature = 38,
        AirQuality = 68,
        SensorLocation = "WareHouse",
        Brightness = 1481
    },
    new()
    {
        Temperature = 30,
        AirQuality = 36,
        SensorLocation = "Office",
        Brightness = 1129
    },
    new()
    {
        Temperature = 15,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 682
    },
    new()
    {
        Temperature = 13,
        AirQuality = 85,
        SensorLocation = "Office",
        Brightness = 632
    },
    new()
    {
        Temperature = 39,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 267
    },
    new()
    {
        Temperature = 23,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1408
    },
    new()
    {
        Temperature = 30,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 773
    },
    new()
    {
        Temperature = 6,
        AirQuality = 35,
        SensorLocation = "Company",
        Brightness = 499
    },
    new()
    {
        Temperature = 30,
        AirQuality = 6,
        SensorLocation = "Office",
        Brightness = 557
    },
    new()
    {
        Temperature = 17,
        AirQuality = 67,
        SensorLocation = "Company",
        Brightness = 1294
    },
    new()
    {
        Temperature = 11,
        AirQuality = 16,
        SensorLocation = "Company",
        Brightness = 795
    },
    new()
    {
        Temperature = 23,
        AirQuality = 94,
        SensorLocation = "Office",
        Brightness = 1556
    },
    new()
    {
        Temperature = 8,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 769
    },
    new()
    {
        Temperature = 47,
        AirQuality = 38,
        SensorLocation = "Company",
        Brightness = 1293
    },
    new()
    {
        Temperature = 18,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 848
    },
    new()
    {
        Temperature = 9,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 1232
    },
    new()
    {
        Temperature = 14,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 1429
    },
    new()
    {
        Temperature = 10,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 1371
    },
    new()
    {
        Temperature = 9,
        AirQuality = 86,
        SensorLocation = "WareHouse",
        Brightness = 603
    },
    new()
    {
        Temperature = 29,
        AirQuality = 29,
        SensorLocation = "Office",
        Brightness = 1132
    },
    new()
    {
        Temperature = 22,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 229
    },
    new()
    {
        Temperature = 51,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 989
    },
    new()
    {
        Temperature = 30,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 269
    },
    new()
    {
        Temperature = 20,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 863
    },
    new()
    {
        Temperature = 20,
        AirQuality = 25,
        SensorLocation = "WareHouse",
        Brightness = 1466
    },
    new()
    {
        Temperature = 27,
        AirQuality = 16,
        SensorLocation = "WareHouse",
        Brightness = 658
    },
    new()
    {
        Temperature = 30,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 1559
    },
    new()
    {
        Temperature = 39,
        AirQuality = 24,
        SensorLocation = "Office",
        Brightness = 1136
    },
    new()
    {
        Temperature = 33,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 578
    },
    new()
    {
        Temperature = 40,
        AirQuality = 68,
        SensorLocation = "WareHouse",
        Brightness = 332
    },
    new()
    {
        Temperature = 18,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 1190
    },
    new()
    {
        Temperature = 22,
        AirQuality = 13,
        SensorLocation = "Office",
        Brightness = 444
    },
    new()
    {
        Temperature = 17,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 1338
    },
    new()
    {
        Temperature = 54,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 922
    },
    new()
    {
        Temperature = 46,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 507
    },
    new()
    {
        Temperature = 14,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 260
    },
    new()
    {
        Temperature = 42,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 880
    },
    new()
    {
        Temperature = 42,
        AirQuality = 66,
        SensorLocation = "WareHouse",
        Brightness = 1502
    },
    new()
    {
        Temperature = 16,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1098
    },
    new()
    {
        Temperature = 27,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1142
    },
    new()
    {
        Temperature = 20,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 492
    },
    new()
    {
        Temperature = 33,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 1518
    },
    new()
    {
        Temperature = 13,
        AirQuality = 60,
        SensorLocation = "WareHouse",
        Brightness = 1306
    },
    new()
    {
        Temperature = 27,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 430
    },
    new()
    {
        Temperature = 49,
        AirQuality = 61,
        SensorLocation = "Company",
        Brightness = 888
    },
    new()
    {
        Temperature = 47,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 1509
    },
    new()
    {
        Temperature = 47,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 457
    },
    new()
    {
        Temperature = 34,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 723
    },
    new()
    {
        Temperature = 43,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1061
    },
    new()
    {
        Temperature = 18,
        AirQuality = 8,
        SensorLocation = "WareHouse",
        Brightness = 1550
    },
    new()
    {
        Temperature = 10,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 963
    },
    new()
    {
        Temperature = 8,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 470
    },
    new()
    {
        Temperature = 30,
        AirQuality = 12,
        SensorLocation = "WareHouse",
        Brightness = 386
    },
    new()
    {
        Temperature = 7,
        AirQuality = 64,
        SensorLocation = "Company",
        Brightness = 1515
    },
    new()
    {
        Temperature = 31,
        AirQuality = 41,
        SensorLocation = "WareHouse",
        Brightness = 1007
    },
    new()
    {
        Temperature = 29,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 1185
    },
    new()
    {
        Temperature = 21,
        AirQuality = 24,
        SensorLocation = "WareHouse",
        Brightness = 446
    },
    new()
    {
        Temperature = 37,
        AirQuality = 66,
        SensorLocation = "Office",
        Brightness = 876
    },
    new()
    {
        Temperature = 13,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 305
    },
    new()
    {
        Temperature = 13,
        AirQuality = 37,
        SensorLocation = "WareHouse",
        Brightness = 1478
    },
    new()
    {
        Temperature = 12,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 981
    },
    new()
    {
        Temperature = 5,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 369
    },
    new()
    {
        Temperature = 23,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 1015
    },
    new()
    {
        Temperature = 7,
        AirQuality = 78,
        SensorLocation = "Office",
        Brightness = 1527
    },
    new()
    {
        Temperature = 35,
        AirQuality = 89,
        SensorLocation = "Office",
        Brightness = 716
    },
    new()
    {
        Temperature = 25,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 1220
    },
    new()
    {
        Temperature = 17,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 19,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 1017
    },
    new()
    {
        Temperature = 54,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 1521
    },
    new()
    {
        Temperature = 50,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 488
    },
    new()
    {
        Temperature = 26,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 844
    },
    new()
    {
        Temperature = 21,
        AirQuality = 50,
        SensorLocation = "Company",
        Brightness = 1465
    },
    new()
    {
        Temperature = 31,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 529
    },
    new()
    {
        Temperature = 49,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 1064
    },
    new()
    {
        Temperature = 21,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 729
    },
    new()
    {
        Temperature = 15,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 468
    },
    new()
    {
        Temperature = 40,
        AirQuality = 90,
        SensorLocation = "Company",
        Brightness = 1328
    },
    new()
    {
        Temperature = 46,
        AirQuality = 67,
        SensorLocation = "WareHouse",
        Brightness = 1436
    },
    new()
    {
        Temperature = 21,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 782
    }
    , new()
                {
                    Temperature = 11,
                    AirQuality = 4,
                    SensorLocation = "Company",
                    Brightness = 1451
                },
    new()
    {
        Temperature = 26,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 1563
    },
    new()
    {
        Temperature = 20,
        AirQuality = 15,
        SensorLocation = "WareHouse",
        Brightness = 861
    },
    new()
    {
        Temperature = 46,
        AirQuality = 0,
        SensorLocation = "WareHouse",
        Brightness = 1356
    },
    new()
    {
        Temperature = 47,
        AirQuality = 34,
        SensorLocation = "WareHouse",
        Brightness = 1376
    },
    new()
    {
        Temperature = 30,
        AirQuality = 67,
        SensorLocation = "Company",
        Brightness = 960
    },
    new()
    {
        Temperature = 7,
        AirQuality = 71,
        SensorLocation = "Company",
        Brightness = 312
    },
    new()
    {
        Temperature = 43,
        AirQuality = 3,
        SensorLocation = "WareHouse",
        Brightness = 662
    },
    new()
    {
        Temperature = 43,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 556
    },
    new()
    {
        Temperature = 36,
        AirQuality = 1,
        SensorLocation = "WareHouse",
        Brightness = 235
    },
    new()
    {
        Temperature = 7,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 743
    },
    new()
    {
        Temperature = 46,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1150
    },
    new()
    {
        Temperature = 8,
        AirQuality = 93,
        SensorLocation = "WareHouse",
        Brightness = 611
    },
    new()
    {
        Temperature = 37,
        AirQuality = 0,
        SensorLocation = "Company",
        Brightness = 409
    },
    new()
    {
        Temperature = 34,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 515
    },
    new()
    {
        Temperature = 48,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 1112
    },
    new()
    {
        Temperature = 26,
        AirQuality = 65,
        SensorLocation = "Office",
        Brightness = 862
    },
    new()
    {
        Temperature = 15,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 1075
    },
    new()
    {
        Temperature = 35,
        AirQuality = 84,
        SensorLocation = "WareHouse",
        Brightness = 1572
    },
    new()
    {
        Temperature = 44,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 296
    },
    new()
    {
        Temperature = 26,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 1088
    },
    new()
    {
        Temperature = 31,
        AirQuality = 14,
        SensorLocation = "Company",
        Brightness = 1013
    },
    new()
    {
        Temperature = 20,
        AirQuality = 19,
        SensorLocation = "Company",
        Brightness = 483
    },
    new()
    {
        Temperature = 28,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 538
    },
    new()
    {
        Temperature = 40,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 1484
    },
    new()
    {
        Temperature = 41,
        AirQuality = 4,
        SensorLocation = "Company",
        Brightness = 713
    },
    new()
    {
        Temperature = 26,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 299
    },
    new()
    {
        Temperature = 22,
        AirQuality = 71,
        SensorLocation = "WareHouse",
        Brightness = 1411
    },
    new()
    {
        Temperature = 51,
        AirQuality = 52,
        SensorLocation = "Company",
        Brightness = 1243
    },
    new()
    {
        Temperature = 9,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 1372
    },
    new()
    {
        Temperature = 11,
        AirQuality = 71,
        SensorLocation = "WareHouse",
        Brightness = 1135
    },
    new()
    {
        Temperature = 51,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 1400
    },
    new()
    {
        Temperature = 12,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 994
    },
    new()
    {
        Temperature = 46,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1115
    },
    new()
    {
        Temperature = 44,
        AirQuality = 33,
        SensorLocation = "Company",
        Brightness = 816
    },
    new()
    {
        Temperature = 13,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 448
    },
    new()
    {
        Temperature = 48,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 616
    },
    new()
    {
        Temperature = 42,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 1025
    },
    new()
    {
        Temperature = 27,
        AirQuality = 62,
        SensorLocation = "WareHouse",
        Brightness = 1238
    },
    new()
    {
        Temperature = 17,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1154
    },
    new()
    {
        Temperature = 24,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 708
    },
    new()
    {
        Temperature = 15,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 230
    },
    new()
    {
        Temperature = 25,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 441
    },
    new()
    {
        Temperature = 46,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 548
    },
    new()
    {
        Temperature = 47,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1097
    },
    new()
    {
        Temperature = 14,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 358
    },
    new()
    {
        Temperature = 36,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1292
    },
    new()
    {
        Temperature = 30,
        AirQuality = 30,
        SensorLocation = "Company",
        Brightness = 1552
    },
    new()
    {
        Temperature = 21,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1089
    },
    new()
    {
        Temperature = 43,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1567
    },
    new()
    {
        Temperature = 36,
        AirQuality = 94,
        SensorLocation = "Company",
        Brightness = 391
    },
    new()
    {
        Temperature = 47,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 288
    },
    new()
    {
        Temperature = 31,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 779
    },
    new()
    {
        Temperature = 52,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 1346
    },
    new()
    {
        Temperature = 16,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 53,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 1079
    },
    new()
    {
        Temperature = 54,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 1316
    },
    new()
    {
        Temperature = 53,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1127
    },
    new()
    {
        Temperature = 13,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 1306
    },
    new()
    {
        Temperature = 28,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 325
    },
    new()
    {
        Temperature = 26,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 595
    },
    new()
    {
        Temperature = 22,
        AirQuality = 46,
        SensorLocation = "WareHouse",
        Brightness = 1530
    },
    new()
    {
        Temperature = 54,
        AirQuality = 12,
        SensorLocation = "Office",
        Brightness = 1585
    },
    new()
    {
        Temperature = 24,
        AirQuality = 64,
        SensorLocation = "WareHouse",
        Brightness = 362
    },
    new()
    {
        Temperature = 26,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 852
    },
    new()
    {
        Temperature = 18,
        AirQuality = 88,
        SensorLocation = "Company",
        Brightness = 1207
    },
    new()
    {
        Temperature = 45,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 636
    },
    new()
    {
        Temperature = 26,
        AirQuality = 78,
        SensorLocation = "Company",
        Brightness = 776
    },
    new()
    {
        Temperature = 22,
        AirQuality = 81,
        SensorLocation = "Company",
        Brightness = 1311
    },
    new()
    {
        Temperature = 25,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 1235
    },
    new()
    {
        Temperature = 26,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 429
    },
    new()
    {
        Temperature = 24,
        AirQuality = 71,
        SensorLocation = "Company",
        Brightness = 1484
    },
    new()
    {
        Temperature = 51,
        AirQuality = 43,
        SensorLocation = "Company",
        Brightness = 1041
    },
    new()
    {
        Temperature = 30,
        AirQuality = 54,
        SensorLocation = "Office",
        Brightness = 876
    },
    new()
    {
        Temperature = 22,
        AirQuality = 26,
        SensorLocation = "Office",
        Brightness = 916
    },
    new()
    {
        Temperature = 38,
        AirQuality = 99,
        SensorLocation = "Company",
        Brightness = 604
    },
    new()
    {
        Temperature = 9,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 1227
    },
    new()
    {
        Temperature = 52,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1195
    },
    new()
    {
        Temperature = 16,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 786
    },
    new()
    {
        Temperature = 18,
        AirQuality = 83,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 52,
        AirQuality = 52,
        SensorLocation = "WareHouse",
        Brightness = 1598
    },
    new()
    {
        Temperature = 36,
        AirQuality = 80,
        SensorLocation = "WareHouse",
        Brightness = 811
    },
    new()
    {
        Temperature = 16,
        AirQuality = 45,
        SensorLocation = "Company",
        Brightness = 1271
    },
    new()
    {
        Temperature = 41,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 948
    },
    new()
    {
        Temperature = 19,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 889
    },
    new()
    {
        Temperature = 34,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 1345
    },
    new()
    {
        Temperature = 15,
        AirQuality = 66,
        SensorLocation = "WareHouse",
        Brightness = 1449
    },
    new()
    {
        Temperature = 36,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 1365
    },
    new()
    {
        Temperature = 21,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 790
    },
    new()
    {
        Temperature = 46,
        AirQuality = 29,
        SensorLocation = "WareHouse",
        Brightness = 1595
    },
    new()
    {
        Temperature = 33,
        AirQuality = 92,
        SensorLocation = "Company",
        Brightness = 1277
    },
    new()
    {
        Temperature = 21,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 761
    },
    new()
    {
        Temperature = 42,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 573
    },
    new()
    {
        Temperature = 39,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 320
    },
    new()
    {
        Temperature = 39,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 1456
    },
    new()
    {
        Temperature = 40,
        AirQuality = 46,
        SensorLocation = "Company",
        Brightness = 516
    },
    new()
    {
        Temperature = 46,
        AirQuality = 18,
        SensorLocation = "Company",
        Brightness = 489
    },
    new()
    {
        Temperature = 53,
        AirQuality = 3,
        SensorLocation = "WareHouse",
        Brightness = 1435
    },
    new()
    {
        Temperature = 25,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 1063
    },
    new()
    {
        Temperature = 44,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 647
    },
    new()
    {
        Temperature = 14,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 1404
    },
    new()
    {
        Temperature = 33,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 863
    },
    new()
    {
        Temperature = 44,
        AirQuality = 66,
        SensorLocation = "Office",
        Brightness = 1073
    },
    new()
    {
        Temperature = 17,
        AirQuality = 89,
        SensorLocation = "WareHouse",
        Brightness = 945
    },
    new()
    {
        Temperature = 22,
        AirQuality = 55,
        SensorLocation = "Company",
        Brightness = 419
    },
    new()
    {
        Temperature = 6,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1141
    },
    new()
    {
        Temperature = 53,
        AirQuality = 100,
        SensorLocation = "Company",
        Brightness = 1049
    },
    new()
    {
        Temperature = 7,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 1050
    },
    new()
    {
        Temperature = 34,
        AirQuality = 45,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 51,
        AirQuality = 57,
        SensorLocation = "WareHouse",
        Brightness = 245
    },
    new()
    {
        Temperature = 17,
        AirQuality = 20,
        SensorLocation = "Company",
        Brightness = 1064
    },
    new()
    {
        Temperature = 30,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 1083
    },
    new()
    {
        Temperature = 46,
        AirQuality = 23,
        SensorLocation = "WareHouse",
        Brightness = 371
    },
    new()
    {
        Temperature = 42,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 1018
    },
    new()
    {
        Temperature = 43,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 1177
    },
    new()
    {
        Temperature = 27,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 766
    },
    new()
    {
        Temperature = 40,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 617
    },
    new()
    {
        Temperature = 21,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 845
    },
    new()
    {
        Temperature = 13,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 373
    },
    new()
    {
        Temperature = 16,
        AirQuality = 12,
        SensorLocation = "Company",
        Brightness = 976
    },
    new()
    {
        Temperature = 33,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1171
    },
    new()
    {
        Temperature = 52,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 939
    },
    new()
    {
        Temperature = 25,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 557
    },
    new()
    {
        Temperature = 42,
        AirQuality = 75,
        SensorLocation = "Office",
        Brightness = 1162
    },
    new()
    {
        Temperature = 9,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 978
    },
    new()
    {
        Temperature = 38,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 353
    },
    new()
    {
        Temperature = 44,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 597
    },
    new()
    {
        Temperature = 11,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 656
    },
    new()
    {
        Temperature = 35,
        AirQuality = 4,
        SensorLocation = "Office",
        Brightness = 1271
    },
    new()
    {
        Temperature = 41,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1222
    },
    new()
    {
        Temperature = 36,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 657
    },
    new()
    {
        Temperature = 52,
        AirQuality = 26,
        SensorLocation = "Company",
        Brightness = 1337
    },
    new()
    {
        Temperature = 35,
        AirQuality = 88,
        SensorLocation = "Office",
        Brightness = 1347
    },
    new()
    {
        Temperature = 37,
        AirQuality = 33,
        SensorLocation = "Company",
        Brightness = 855
    },
    new()
    {
        Temperature = 34,
        AirQuality = 68,
        SensorLocation = "Company",
        Brightness = 337
    },
    new()
    {
        Temperature = 10,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 254
    },
    new()
    {
        Temperature = 43,
        AirQuality = 93,
        SensorLocation = "WareHouse",
        Brightness = 629
    },
    new()
    {
        Temperature = 22,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 821
    },
    new()
    {
        Temperature = 33,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 16,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1574
    },
    new()
    {
        Temperature = 9,
        AirQuality = 77,
        SensorLocation = "Office",
        Brightness = 1553
    },
    new()
    {
        Temperature = 43,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 660
    },
    new()
    {
        Temperature = 14,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 1114
    },
    new()
    {
        Temperature = 10,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 1335
    },
    new()
    {
        Temperature = 48,
        AirQuality = 46,
        SensorLocation = "WareHouse",
        Brightness = 691
    },
    new()
    {
        Temperature = 9,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 1135
    },
    new()
    {
        Temperature = 13,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 645
    },
    new()
    {
        Temperature = 33,
        AirQuality = 20,
        SensorLocation = "Office",
        Brightness = 678
    },
    new()
    {
        Temperature = 23,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 1448
    },
    new()
    {
        Temperature = 49,
        AirQuality = 5,
        SensorLocation = "Company",
        Brightness = 270
    },
    new()
    {
        Temperature = 37,
        AirQuality = 48,
        SensorLocation = "Company",
        Brightness = 323
    },
    new()
    {
        Temperature = 47,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 1370
    },
    new()
    {
        Temperature = 51,
        AirQuality = 17,
        SensorLocation = "WareHouse",
        Brightness = 842
    },
    new()
    {
        Temperature = 28,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 476
    },
    new()
    {
        Temperature = 29,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 1212
    },
    new()
    {
        Temperature = 47,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 882
    },
    new()
    {
        Temperature = 6,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 1397
    },
    new()
    {
        Temperature = 48,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1559
    },
    new()
    {
        Temperature = 22,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1140
    },
    new()
    {
        Temperature = 6,
        AirQuality = 23,
        SensorLocation = "Office",
        Brightness = 252
    },
    new()
    {
        Temperature = 42,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 604
    },
    new()
    {
        Temperature = 40,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 231
    },
    new()
    {
        Temperature = 19,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 523
    },
    new()
    {
        Temperature = 8,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 278
    },
    new()
    {
        Temperature = 38,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 585
    },
    new()
    {
        Temperature = 9,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 1331
    },
    new()
    {
        Temperature = 32,
        AirQuality = 16,
        SensorLocation = "WareHouse",
        Brightness = 615
    },
    new()
    {
        Temperature = 22,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1281
    },
    new()
    {
        Temperature = 42,
        AirQuality = 13,
        SensorLocation = "Office",
        Brightness = 775
    },
    new()
    {
        Temperature = 42,
        AirQuality = 43,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 28,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 946
    },
    new()
    {
        Temperature = 45,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 873
    },
    new()
    {
        Temperature = 35,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1598
    },
    new()
    {
        Temperature = 19,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 936
    },
    new()
    {
        Temperature = 14,
        AirQuality = 17,
        SensorLocation = "WareHouse",
        Brightness = 507
    },
    new()
    {
        Temperature = 14,
        AirQuality = 52,
        SensorLocation = "Office",
        Brightness = 1148
    },
    new()
    {
        Temperature = 28,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 619
    },
    new()
    {
        Temperature = 30,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 873
    },
    new()
    {
        Temperature = 43,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 237
    },
    new()
    {
        Temperature = 45,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 562
    },
    new()
    {
        Temperature = 11,
        AirQuality = 38,
        SensorLocation = "Office",
        Brightness = 1531
    },
    new()
    {
        Temperature = 33,
        AirQuality = 18,
        SensorLocation = "Company",
        Brightness = 330
    },
    new()
    {
        Temperature = 48,
        AirQuality = 4,
        SensorLocation = "Office",
        Brightness = 472
    },
    new()
    {
        Temperature = 14,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 508
    },
    new()
    {
        Temperature = 50,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1474
    },
    new()
    {
        Temperature = 46,
        AirQuality = 27,
        SensorLocation = "Office",
        Brightness = 1263
    },
    new()
    {
        Temperature = 41,
        AirQuality = 73,
        SensorLocation = "WareHouse",
        Brightness = 1545
    },
    new()
    {
        Temperature = 6,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 1108
    },
    new()
    {
        Temperature = 12,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 960
    },
    new()
    {
        Temperature = 46,
        AirQuality = 28,
        SensorLocation = "WareHouse",
        Brightness = 1437
    },
    new()
    {
        Temperature = 22,
        AirQuality = 63,
        SensorLocation = "Office",
        Brightness = 901
    },
    new()
    {
        Temperature = 6,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 436
    },
    new()
    {
        Temperature = 48,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 1055
    },
    new()
    {
        Temperature = 48,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 1558
    },
    new()
    {
        Temperature = 29,
        AirQuality = 28,
        SensorLocation = "WareHouse",
        Brightness = 539
    },
    new()
    {
        Temperature = 24,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1566
    },
    new()
    {
        Temperature = 35,
        AirQuality = 26,
        SensorLocation = "WareHouse",
        Brightness = 398
    },
    new()
    {
        Temperature = 16,
        AirQuality = 87,
        SensorLocation = "WareHouse",
        Brightness = 1064
    },
    new()
    {
        Temperature = 44,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 982
    },
    new()
    {
        Temperature = 33,
        AirQuality = 98,
        SensorLocation = "Office",
        Brightness = 790
    },
    new()
    {
        Temperature = 31,
        AirQuality = 26,
        SensorLocation = "Office",
        Brightness = 677
    },
    new()
    {
        Temperature = 43,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 1224
    },
    new()
    {
        Temperature = 55,
        AirQuality = 32,
        SensorLocation = "Company",
        Brightness = 876
    },
    new()
    {
        Temperature = 46,
        AirQuality = 9,
        SensorLocation = "WareHouse",
        Brightness = 904
    },
    new()
    {
        Temperature = 33,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 1004
    },
    new()
    {
        Temperature = 32,
        AirQuality = 75,
        SensorLocation = "Office",
        Brightness = 492
    },
    new()
    {
        Temperature = 34,
        AirQuality = 13,
        SensorLocation = "Company",
        Brightness = 810
    },
    new()
    {
        Temperature = 26,
        AirQuality = 77,
        SensorLocation = "WareHouse",
        Brightness = 724
    },
    new()
    {
        Temperature = 46,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 375
    },
    new()
    {
        Temperature = 51,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 969
    },
    new()
    {
        Temperature = 9,
        AirQuality = 53,
        SensorLocation = "WareHouse",
        Brightness = 1489
    },
    new()
    {
        Temperature = 46,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1159
    },
    new()
    {
        Temperature = 24,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 582
    },
    new()
    {
        Temperature = 52,
        AirQuality = 64,
        SensorLocation = "Office",
        Brightness = 491
    },
    new()
    {
        Temperature = 50,
        AirQuality = 75,
        SensorLocation = "Company",
        Brightness = 878
    },
    new()
    {
        Temperature = 27,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 204
    },
    new()
    {
        Temperature = 44,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 903
    },
    new()
    {
        Temperature = 55,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 1362
    },
    new()
    {
        Temperature = 30,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 336
    },
    new()
    {
        Temperature = 53,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 371
    },
    new()
    {
        Temperature = 17,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 646
    },
    new()
    {
        Temperature = 54,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 1028
    },
    new()
    {
        Temperature = 32,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1447
    },
    new()
    {
        Temperature = 31,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 1182
    },
    new()
    {
        Temperature = 50,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 474
    },
    new()
    {
        Temperature = 26,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 320
    },
    new()
    {
        Temperature = 35,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 1063
    },
    new()
    {
        Temperature = 39,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 519
    },
    new()
    {
        Temperature = 46,
        AirQuality = 7,
        SensorLocation = "WareHouse",
        Brightness = 1406
    },
    new()
    {
        Temperature = 16,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 733
    },
    new()
    {
        Temperature = 14,
        AirQuality = 30,
        SensorLocation = "Company",
        Brightness = 1261
    },
    new()
    {
        Temperature = 6,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 872
    },
    new()
    {
        Temperature = 17,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 901
    },
    new()
    {
        Temperature = 10,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 1478
    },
    new()
    {
        Temperature = 39,
        AirQuality = 50,
        SensorLocation = "Company",
        Brightness = 1314
    },
    new()
    {
        Temperature = 29,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 501
    },
    new()
    {
        Temperature = 43,
        AirQuality = 22,
        SensorLocation = "Company",
        Brightness = 1340
    },
    new()
    {
        Temperature = 32,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 1274
    },
    new()
    {
        Temperature = 43,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 1000
    },
    new()
    {
        Temperature = 8,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 985
    },
    new()
    {
        Temperature = 11,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 1392
    },
    new()
    {
        Temperature = 21,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 1584
    },
    new()
    {
        Temperature = 50,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 1598
    },
    new()
    {
        Temperature = 11,
        AirQuality = 38,
        SensorLocation = "Office",
        Brightness = 1091
    },
    new()
    {
        Temperature = 18,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 307
    },
    new()
    {
        Temperature = 36,
        AirQuality = 95,
        SensorLocation = "WareHouse",
        Brightness = 1102
    },
    new()
    {
        Temperature = 50,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 509
    },
    new()
    {
        Temperature = 34,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 835
    },
    new()
    {
        Temperature = 25,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 1397
    },
    new()
    {
        Temperature = 18,
        AirQuality = 81,
        SensorLocation = "WareHouse",
        Brightness = 1222
    },
    new()
    {
        Temperature = 9,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 1008
    },
    new()
    {
        Temperature = 51,
        AirQuality = 31,
        SensorLocation = "Office",
        Brightness = 1582
    },
    new()
    {
        Temperature = 43,
        AirQuality = 25,
        SensorLocation = "Office",
        Brightness = 1247
    },
    new()
    {
        Temperature = 38,
        AirQuality = 49,
        SensorLocation = "Company",
        Brightness = 1437
    },
    new()
    {
        Temperature = 29,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 937
    },
    new()
    {
        Temperature = 23,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 466
    },
    new()
    {
        Temperature = 16,
        AirQuality = 7,
        SensorLocation = "WareHouse",
        Brightness = 301
    },
    new()
    {
        Temperature = 30,
        AirQuality = 69,
        SensorLocation = "Company",
        Brightness = 307
    },
    new()
    {
        Temperature = 30,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 641
    },
    new()
    {
        Temperature = 8,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 557
    },
    new()
    {
        Temperature = 55,
        AirQuality = 12,
        SensorLocation = "WareHouse",
        Brightness = 1309
    },
    new()
    {
        Temperature = 7,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 1348
    },
    new()
    {
        Temperature = 14,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 847
    },
    new()
    {
        Temperature = 29,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 666
    },
    new()
    {
        Temperature = 31,
        AirQuality = 65,
        SensorLocation = "Office",
        Brightness = 654
    },
    new()
    {
        Temperature = 19,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 1157
    },
    new()
    {
        Temperature = 18,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 319
    },
    new()
    {
        Temperature = 5,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 1295
    },
    new()
    {
        Temperature = 33,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 530
    },
    new()
    {
        Temperature = 38,
        AirQuality = 45,
        SensorLocation = "WareHouse",
        Brightness = 1392
    },
    new()
    {
        Temperature = 46,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 1137
    },
    new()
    {
        Temperature = 50,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 250
    },
    new()
    {
        Temperature = 19,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 1015
    },
    new()
    {
        Temperature = 14,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 1178
    },
    new()
    {
        Temperature = 19,
        AirQuality = 82,
        SensorLocation = "WareHouse",
        Brightness = 1549
    },
    new()
    {
        Temperature = 10,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 1486
    },
    new()
    {
        Temperature = 18,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 264
    },
    new()
    {
        Temperature = 49,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1295
    },
    new()
    {
        Temperature = 48,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 210
    },
    new()
    {
        Temperature = 43,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1008
    },
    new()
    {
        Temperature = 27,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 1368
    },
    new()
    {
        Temperature = 26,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 1446
    },
    new()
    {
        Temperature = 13,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 484
    },
    new()
    {
        Temperature = 8,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 1579
    },
    new()
    {
        Temperature = 33,
        AirQuality = 49,
        SensorLocation = "Office",
        Brightness = 460
    },
    new()
    {
        Temperature = 20,
        AirQuality = 36,
        SensorLocation = "Office",
        Brightness = 1009
    },
    new()
    {
        Temperature = 42,
        AirQuality = 58,
        SensorLocation = "Office",
        Brightness = 1558
    },
    new()
    {
        Temperature = 29,
        AirQuality = 49,
        SensorLocation = "Office",
        Brightness = 688
    },
    new()
    {
        Temperature = 36,
        AirQuality = 10,
        SensorLocation = "WareHouse",
        Brightness = 1463
    },
    new()
    {
        Temperature = 43,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 980
    },
    new()
    {
        Temperature = 54,
        AirQuality = 87,
        SensorLocation = "Company",
        Brightness = 220
    },
    new()
    {
        Temperature = 43,
        AirQuality = 80,
        SensorLocation = "Company",
        Brightness = 1252
    },
    new()
    {
        Temperature = 24,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 1285
    },
    new()
    {
        Temperature = 47,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 1576
    },
    new()
    {
        Temperature = 25,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 1031
    },
    new()
    {
        Temperature = 39,
        AirQuality = 58,
        SensorLocation = "WareHouse",
        Brightness = 1211
    },
    new()
    {
        Temperature = 25,
        AirQuality = 33,
        SensorLocation = "Office",
        Brightness = 1393
    },
    new()
    {
        Temperature = 32,
        AirQuality = 73,
        SensorLocation = "Office",
        Brightness = 1418
    },
    new()
    {
        Temperature = 35,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 1471
    },
    new()
    {
        Temperature = 50,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 846
    },
    new()
    {
        Temperature = 38,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 1057
    },
    new()
    {
        Temperature = 44,
        AirQuality = 17,
        SensorLocation = "Office",
        Brightness = 439
    },
    new()
    {
        Temperature = 8,
        AirQuality = 40,
        SensorLocation = "Office",
        Brightness = 1488
    },
    new()
    {
        Temperature = 12,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 655
    },
    new()
    {
        Temperature = 18,
        AirQuality = 12,
        SensorLocation = "Office",
        Brightness = 473
    },
    new()
    {
        Temperature = 38,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 422
    },
    new()
    {
        Temperature = 7,
        AirQuality = 17,
        SensorLocation = "Company",
        Brightness = 724
    },
    new()
    {
        Temperature = 43,
        AirQuality = 42,
        SensorLocation = "WareHouse",
        Brightness = 486
    },
    new()
    {
        Temperature = 43,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 1421
    },
    new()
    {
        Temperature = 19,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 992
    },
    new()
    {
        Temperature = 52,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 588
    },
    new()
    {
        Temperature = 12,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 244
    },
    new()
    {
        Temperature = 52,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 1021
    },
    new()
    {
        Temperature = 17,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 1219
    },
    new()
    {
        Temperature = 6,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1029
    },
    new()
    {
        Temperature = 16,
        AirQuality = 57,
        SensorLocation = "WareHouse",
        Brightness = 485
    },
    new()
    {
        Temperature = 18,
        AirQuality = 41,
        SensorLocation = "Office",
        Brightness = 609
    },
    new()
    {
        Temperature = 11,
        AirQuality = 87,
        SensorLocation = "Company",
        Brightness = 320
    },
    new()
    {
        Temperature = 29,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 1119
    },
    new()
    {
        Temperature = 36,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 1472
    },
    new()
    {
        Temperature = 22,
        AirQuality = 56,
        SensorLocation = "Company",
        Brightness = 426
    },
    new()
    {
        Temperature = 23,
        AirQuality = 72,
        SensorLocation = "Office",
        Brightness = 1257
    },
    new()
    {
        Temperature = 26,
        AirQuality = 42,
        SensorLocation = "Company",
        Brightness = 951
    },
    new()
    {
        Temperature = 51,
        AirQuality = 48,
        SensorLocation = "WareHouse",
        Brightness = 1228
    },
    new()
    {
        Temperature = 34,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 740
    },
    new()
    {
        Temperature = 21,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 680
    },
    new()
    {
        Temperature = 31,
        AirQuality = 89,
        SensorLocation = "WareHouse",
        Brightness = 621
    },
    new()
    {
        Temperature = 54,
        AirQuality = 37,
        SensorLocation = "WareHouse",
        Brightness = 330
    },
    new()
    {
        Temperature = 54,
        AirQuality = 80,
        SensorLocation = "WareHouse",
        Brightness = 1392
    },
    new()
    {
        Temperature = 51,
        AirQuality = 89,
        SensorLocation = "Company",
        Brightness = 1376
    },
    new()
    {
        Temperature = 53,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 507
    },
    new()
    {
        Temperature = 5,
        AirQuality = 58,
        SensorLocation = "Company",
        Brightness = 623
    },
    new()
    {
        Temperature = 5,
        AirQuality = 55,
        SensorLocation = "Office",
        Brightness = 1120
    },
    new()
    {
        Temperature = 10,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 240
    },
    new()
    {
        Temperature = 47,
        AirQuality = 87,
        SensorLocation = "Office",
        Brightness = 817
    },
    new()
    {
        Temperature = 44,
        AirQuality = 69,
        SensorLocation = "Office",
        Brightness = 1527
    },
    new()
    {
        Temperature = 45,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 1409
    },
    new()
    {
        Temperature = 30,
        AirQuality = 88,
        SensorLocation = "Company",
        Brightness = 895
    },
    new()
    {
        Temperature = 8,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1034
    },
    new()
    {
        Temperature = 35,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 1546
    },
    new()
    {
        Temperature = 43,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 432
    },
    new()
    {
        Temperature = 16,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 1451
    },
    new()
    {
        Temperature = 7,
        AirQuality = 26,
        SensorLocation = "WareHouse",
        Brightness = 595
    },
    new()
    {
        Temperature = 49,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 495
    },
    new()
    {
        Temperature = 27,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 1038
    },
    new()
    {
        Temperature = 36,
        AirQuality = 35,
        SensorLocation = "Company",
        Brightness = 1260
    },
    new()
    {
        Temperature = 14,
        AirQuality = 31,
        SensorLocation = "Office",
        Brightness = 229
    },
    new()
    {
        Temperature = 50,
        AirQuality = 98,
        SensorLocation = "Company",
        Brightness = 1264
    },
    new()
    {
        Temperature = 30,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 218
    },
    new()
    {
        Temperature = 34,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 389
    },
    new()
    {
        Temperature = 27,
        AirQuality = 67,
        SensorLocation = "Office",
        Brightness = 347
    },
    new()
    {
        Temperature = 16,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 1017
    },
    new()
    {
        Temperature = 11,
        AirQuality = 95,
        SensorLocation = "WareHouse",
        Brightness = 964
    },
    new()
    {
        Temperature = 7,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 674
    },
    new()
    {
        Temperature = 13,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 233
    },
    new()
    {
        Temperature = 7,
        AirQuality = 31,
        SensorLocation = "Company",
        Brightness = 1037
    },
    new()
    {
        Temperature = 54,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 542
    },
    new()
    {
        Temperature = 43,
        AirQuality = 12,
        SensorLocation = "Company",
        Brightness = 330
    },
    new()
    {
        Temperature = 32,
        AirQuality = 10,
        SensorLocation = "Office",
        Brightness = 1166
    },
    new()
    {
        Temperature = 53,
        AirQuality = 47,
        SensorLocation = "WareHouse",
        Brightness = 1072
    },
    new()
    {
        Temperature = 23,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 505
    },
    new()
    {
        Temperature = 38,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1519
    },
    new()
    {
        Temperature = 19,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 771
    },
    new()
    {
        Temperature = 7,
        AirQuality = 39,
        SensorLocation = "WareHouse",
        Brightness = 1132
    },
    new()
    {
        Temperature = 23,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 1459
    },
    new()
    {
        Temperature = 19,
        AirQuality = 81,
        SensorLocation = "Company",
        Brightness = 1001
    },
    new()
    {
        Temperature = 11,
        AirQuality = 5,
        SensorLocation = "WareHouse",
        Brightness = 568
    },
    new()
    {
        Temperature = 11,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 1471
    },
    new()
    {
        Temperature = 40,
        AirQuality = 11,
        SensorLocation = "Office",
        Brightness = 1379
    },
    new()
    {
        Temperature = 28,
        AirQuality = 96,
        SensorLocation = "WareHouse",
        Brightness = 700
    },
    new()
    {
        Temperature = 23,
        AirQuality = 73,
        SensorLocation = "Office",
        Brightness = 660
    },
    new()
    {
        Temperature = 44,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 605
    },
    new()
    {
        Temperature = 32,
        AirQuality = 69,
        SensorLocation = "WareHouse",
        Brightness = 1300
    },
    new()
    {
        Temperature = 29,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 467
    },
    new()
    {
        Temperature = 21,
        AirQuality = 1,
        SensorLocation = "Company",
        Brightness = 1222
    },
    new()
    {
        Temperature = 41,
        AirQuality = 48,
        SensorLocation = "Company",
        Brightness = 983
    },
    new()
    {
        Temperature = 13,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1128
    },
    new()
    {
        Temperature = 36,
        AirQuality = 48,
        SensorLocation = "Office",
        Brightness = 1130
    },
    new()
    {
        Temperature = 27,
        AirQuality = 90,
        SensorLocation = "Office",
        Brightness = 603
    },
    new()
    {
        Temperature = 27,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 1173
    },
    new()
    {
        Temperature = 47,
        AirQuality = 1,
        SensorLocation = "WareHouse",
        Brightness = 568
    },
    new()
    {
        Temperature = 26,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 1071
    },
    new()
    {
        Temperature = 45,
        AirQuality = 2,
        SensorLocation = "WareHouse",
        Brightness = 1157
    },
    new()
    {
        Temperature = 24,
        AirQuality = 96,
        SensorLocation = "WareHouse",
        Brightness = 342
    },
    new()
    {
        Temperature = 24,
        AirQuality = 49,
        SensorLocation = "Company",
        Brightness = 1110
    },
    new()
    {
        Temperature = 40,
        AirQuality = 92,
        SensorLocation = "Company",
        Brightness = 337
    },
    new()
    {
        Temperature = 24,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 442
    },
    new()
    {
        Temperature = 34,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 644
    },
    new()
    {
        Temperature = 44,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1464
    },
    new()
    {
        Temperature = 47,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 1438
    },
    new()
    {
        Temperature = 9,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 1143
    },
    new()
    {
        Temperature = 31,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 1528
    },
    new()
    {
        Temperature = 23,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1346
    },
    new()
    {
        Temperature = 32,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 807
    },
    new()
    {
        Temperature = 14,
        AirQuality = 10,
        SensorLocation = "WareHouse",
        Brightness = 625
    },
    new()
    {
        Temperature = 51,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 702
    },
    new()
    {
        Temperature = 8,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 1121
    },
    new()
    {
        Temperature = 36,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 315
    },
    new()
    {
        Temperature = 29,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 623
    },
    new()
    {
        Temperature = 51,
        AirQuality = 87,
        SensorLocation = "WareHouse",
        Brightness = 1033
    },
    new()
    {
        Temperature = 10,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 1122
    },
    new()
    {
        Temperature = 53,
        AirQuality = 8,
        SensorLocation = "WareHouse",
        Brightness = 893
    },
    new()
    {
        Temperature = 29,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 1505
    },
    new()
    {
        Temperature = 17,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 1480
    },
    new()
    {
        Temperature = 18,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 1321
    },
    new()
    {
        Temperature = 24,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 694
    },
    new()
    {
        Temperature = 54,
        AirQuality = 86,
        SensorLocation = "WareHouse",
        Brightness = 1380
    },
    new()
    {
        Temperature = 10,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1068
    },
    new()
    {
        Temperature = 48,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 467
    },
    new()
    {
        Temperature = 34,
        AirQuality = 90,
        SensorLocation = "Company",
        Brightness = 485
    },
    new()
    {
        Temperature = 21,
        AirQuality = 73,
        SensorLocation = "WareHouse",
        Brightness = 1100
    },
    new()
    {
        Temperature = 28,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 1295
    },
    new()
    {
        Temperature = 43,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 437
    },
    new()
    {
        Temperature = 45,
        AirQuality = 72,
        SensorLocation = "Office",
        Brightness = 535
    },
    new()
    {
        Temperature = 30,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 1258
    },
    new()
    {
        Temperature = 49,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 1213
    },
    new()
    {
        Temperature = 54,
        AirQuality = 42,
        SensorLocation = "WareHouse",
        Brightness = 1169
    },
    new()
    {
        Temperature = 21,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 1003
    },
    new()
    {
        Temperature = 33,
        AirQuality = 85,
        SensorLocation = "WareHouse",
        Brightness = 915
    },
    new()
    {
        Temperature = 39,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 1506
    },
    new()
    {
        Temperature = 47,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 241
    },
    new()
    {
        Temperature = 38,
        AirQuality = 68,
        SensorLocation = "WareHouse",
        Brightness = 1481
    },
    new()
    {
        Temperature = 30,
        AirQuality = 36,
        SensorLocation = "Office",
        Brightness = 1129
    },
    new()
    {
        Temperature = 15,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 682
    },
    new()
    {
        Temperature = 13,
        AirQuality = 85,
        SensorLocation = "Office",
        Brightness = 632
    },
    new()
    {
        Temperature = 39,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 267
    },
    new()
    {
        Temperature = 23,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1408
    },
    new()
    {
        Temperature = 30,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 773
    },
    new()
    {
        Temperature = 6,
        AirQuality = 35,
        SensorLocation = "Company",
        Brightness = 499
    },
    new()
    {
        Temperature = 30,
        AirQuality = 6,
        SensorLocation = "Office",
        Brightness = 557
    },
    new()
    {
        Temperature = 17,
        AirQuality = 67,
        SensorLocation = "Company",
        Brightness = 1294
    },
    new()
    {
        Temperature = 11,
        AirQuality = 16,
        SensorLocation = "Company",
        Brightness = 795
    },
    new()
    {
        Temperature = 23,
        AirQuality = 94,
        SensorLocation = "Office",
        Brightness = 1556
    },
    new()
    {
        Temperature = 8,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 769
    },
    new()
    {
        Temperature = 47,
        AirQuality = 38,
        SensorLocation = "Company",
        Brightness = 1293
    },
    new()
    {
        Temperature = 18,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 848
    },
    new()
    {
        Temperature = 9,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 1232
    },
    new()
    {
        Temperature = 14,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 1429
    },
    new()
    {
        Temperature = 10,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 1371
    },
    new()
    {
        Temperature = 9,
        AirQuality = 86,
        SensorLocation = "WareHouse",
        Brightness = 603
    },
    new()
    {
        Temperature = 29,
        AirQuality = 29,
        SensorLocation = "Office",
        Brightness = 1132
    },
    new()
    {
        Temperature = 22,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 229
    },
    new()
    {
        Temperature = 51,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 989
    },
    new()
    {
        Temperature = 30,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 269
    },
    new()
    {
        Temperature = 20,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 863
    },
    new()
    {
        Temperature = 20,
        AirQuality = 25,
        SensorLocation = "WareHouse",
        Brightness = 1466
    },
    new()
    {
        Temperature = 27,
        AirQuality = 16,
        SensorLocation = "WareHouse",
        Brightness = 658
    },
    new()
    {
        Temperature = 30,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 1559
    },
    new()
    {
        Temperature = 39,
        AirQuality = 24,
        SensorLocation = "Office",
        Brightness = 1136
    },
    new()
    {
        Temperature = 33,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 578
    },
    new()
    {
        Temperature = 40,
        AirQuality = 68,
        SensorLocation = "WareHouse",
        Brightness = 332
    },
    new()
    {
        Temperature = 18,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 1190
    },
    new()
    {
        Temperature = 22,
        AirQuality = 13,
        SensorLocation = "Office",
        Brightness = 444
    },
    new()
    {
        Temperature = 17,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 1338
    },
    new()
    {
        Temperature = 54,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 922
    },
    new()
    {
        Temperature = 46,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 507
    },
    new()
    {
        Temperature = 14,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 260
    },
    new()
    {
        Temperature = 42,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 880
    },
    new()
    {
        Temperature = 42,
        AirQuality = 66,
        SensorLocation = "WareHouse",
        Brightness = 1502
    },
    new()
    {
        Temperature = 16,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1098
    },
    new()
    {
        Temperature = 27,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1142
    },
    new()
    {
        Temperature = 20,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 492
    },
    new()
    {
        Temperature = 33,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 1518
    },
    new()
    {
        Temperature = 13,
        AirQuality = 60,
        SensorLocation = "WareHouse",
        Brightness = 1306
    },
    new()
    {
        Temperature = 27,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 430
    },
    new()
    {
        Temperature = 49,
        AirQuality = 61,
        SensorLocation = "Company",
        Brightness = 888
    },
    new()
    {
        Temperature = 47,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 1509
    },
    new()
    {
        Temperature = 47,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 457
    },
    new()
    {
        Temperature = 34,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 723
    },
    new()
    {
        Temperature = 43,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1061
    },
    new()
    {
        Temperature = 18,
        AirQuality = 8,
        SensorLocation = "WareHouse",
        Brightness = 1550
    },
    new()
    {
        Temperature = 10,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 963
    },
    new()
    {
        Temperature = 8,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 470
    },
    new()
    {
        Temperature = 30,
        AirQuality = 12,
        SensorLocation = "WareHouse",
        Brightness = 386
    },
    new()
    {
        Temperature = 7,
        AirQuality = 64,
        SensorLocation = "Company",
        Brightness = 1515
    },
    new()
    {
        Temperature = 31,
        AirQuality = 41,
        SensorLocation = "WareHouse",
        Brightness = 1007
    },
    new()
    {
        Temperature = 29,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 1185
    },
    new()
    {
        Temperature = 21,
        AirQuality = 24,
        SensorLocation = "WareHouse",
        Brightness = 446
    },
    new()
    {
        Temperature = 37,
        AirQuality = 66,
        SensorLocation = "Office",
        Brightness = 876
    },
    new()
    {
        Temperature = 13,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 305
    },
    new()
    {
        Temperature = 13,
        AirQuality = 37,
        SensorLocation = "WareHouse",
        Brightness = 1478
    },
    new()
    {
        Temperature = 12,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 981
    },
    new()
    {
        Temperature = 5,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 369
    },
    new()
    {
        Temperature = 23,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 1015
    },
    new()
    {
        Temperature = 7,
        AirQuality = 78,
        SensorLocation = "Office",
        Brightness = 1527
    },
    new()
    {
        Temperature = 35,
        AirQuality = 89,
        SensorLocation = "Office",
        Brightness = 716
    },
    new()
    {
        Temperature = 25,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 1220
    },
    new()
    {
        Temperature = 17,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 19,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 1017
    },
    new()
    {
        Temperature = 54,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 1521
    },
    new()
    {
        Temperature = 50,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 488
    },
    new()
    {
        Temperature = 26,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 844
    },
    new()
    {
        Temperature = 21,
        AirQuality = 50,
        SensorLocation = "Company",
        Brightness = 1465
    },
    new()
    {
        Temperature = 31,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 529
    },
    new()
    {
        Temperature = 49,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 1064
    },
    new()
    {
        Temperature = 21,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 729
    },
    new()
    {
        Temperature = 15,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 468
    },
    new()
    {
        Temperature = 40,
        AirQuality = 90,
        SensorLocation = "Company",
        Brightness = 1328
    },
    new()
    {
        Temperature = 46,
        AirQuality = 67,
        SensorLocation = "WareHouse",
        Brightness = 1436
    },
    new()
    {
        Temperature = 21,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 782
    }
    , new()
                {
                    Temperature = 11,
                    AirQuality = 4,
                    SensorLocation = "Company",
                    Brightness = 1451
                },
    new()
    {
        Temperature = 26,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 1563
    },
    new()
    {
        Temperature = 20,
        AirQuality = 15,
        SensorLocation = "WareHouse",
        Brightness = 861
    },
    new()
    {
        Temperature = 46,
        AirQuality = 0,
        SensorLocation = "WareHouse",
        Brightness = 1356
    },
    new()
    {
        Temperature = 47,
        AirQuality = 34,
        SensorLocation = "WareHouse",
        Brightness = 1376
    },
    new()
    {
        Temperature = 30,
        AirQuality = 67,
        SensorLocation = "Company",
        Brightness = 960
    },
    new()
    {
        Temperature = 7,
        AirQuality = 71,
        SensorLocation = "Company",
        Brightness = 312
    },
    new()
    {
        Temperature = 43,
        AirQuality = 3,
        SensorLocation = "WareHouse",
        Brightness = 662
    },
    new()
    {
        Temperature = 43,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 556
    },
    new()
    {
        Temperature = 36,
        AirQuality = 1,
        SensorLocation = "WareHouse",
        Brightness = 235
    },
    new()
    {
        Temperature = 7,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 743
    },
    new()
    {
        Temperature = 46,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1150
    },
    new()
    {
        Temperature = 8,
        AirQuality = 93,
        SensorLocation = "WareHouse",
        Brightness = 611
    },
    new()
    {
        Temperature = 37,
        AirQuality = 0,
        SensorLocation = "Company",
        Brightness = 409
    },
    new()
    {
        Temperature = 34,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 515
    },
    new()
    {
        Temperature = 48,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 1112
    },
    new()
    {
        Temperature = 26,
        AirQuality = 65,
        SensorLocation = "Office",
        Brightness = 862
    },
    new()
    {
        Temperature = 15,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 1075
    },
    new()
    {
        Temperature = 35,
        AirQuality = 84,
        SensorLocation = "WareHouse",
        Brightness = 1572
    },
    new()
    {
        Temperature = 44,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 296
    },
    new()
    {
        Temperature = 26,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 1088
    },
    new()
    {
        Temperature = 31,
        AirQuality = 14,
        SensorLocation = "Company",
        Brightness = 1013
    },
    new()
    {
        Temperature = 20,
        AirQuality = 19,
        SensorLocation = "Company",
        Brightness = 483
    },
    new()
    {
        Temperature = 28,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 538
    },
    new()
    {
        Temperature = 40,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 1484
    },
    new()
    {
        Temperature = 41,
        AirQuality = 4,
        SensorLocation = "Company",
        Brightness = 713
    },
    new()
    {
        Temperature = 26,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 299
    },
    new()
    {
        Temperature = 22,
        AirQuality = 71,
        SensorLocation = "WareHouse",
        Brightness = 1411
    },
    new()
    {
        Temperature = 51,
        AirQuality = 52,
        SensorLocation = "Company",
        Brightness = 1243
    },
    new()
    {
        Temperature = 9,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 1372
    },
    new()
    {
        Temperature = 11,
        AirQuality = 71,
        SensorLocation = "WareHouse",
        Brightness = 1135
    },
    new()
    {
        Temperature = 51,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 1400
    },
    new()
    {
        Temperature = 12,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 994
    },
    new()
    {
        Temperature = 46,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1115
    },
    new()
    {
        Temperature = 44,
        AirQuality = 33,
        SensorLocation = "Company",
        Brightness = 816
    },
    new()
    {
        Temperature = 13,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 448
    },
    new()
    {
        Temperature = 48,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 616
    },
    new()
    {
        Temperature = 42,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 1025
    },
    new()
    {
        Temperature = 27,
        AirQuality = 62,
        SensorLocation = "WareHouse",
        Brightness = 1238
    },
    new()
    {
        Temperature = 17,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1154
    },
    new()
    {
        Temperature = 24,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 708
    },
    new()
    {
        Temperature = 15,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 230
    },
    new()
    {
        Temperature = 25,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 441
    },
    new()
    {
        Temperature = 46,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 548
    },
    new()
    {
        Temperature = 47,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1097
    },
    new()
    {
        Temperature = 14,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 358
    },
    new()
    {
        Temperature = 36,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1292
    },
    new()
    {
        Temperature = 30,
        AirQuality = 30,
        SensorLocation = "Company",
        Brightness = 1552
    },
    new()
    {
        Temperature = 21,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1089
    },
    new()
    {
        Temperature = 43,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1567
    },
    new()
    {
        Temperature = 36,
        AirQuality = 94,
        SensorLocation = "Company",
        Brightness = 391
    },
    new()
    {
        Temperature = 47,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 288
    },
    new()
    {
        Temperature = 31,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 779
    },
    new()
    {
        Temperature = 52,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 1346
    },
    new()
    {
        Temperature = 16,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 53,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 1079
    },
    new()
    {
        Temperature = 54,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 1316
    },
    new()
    {
        Temperature = 53,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1127
    },
    new()
    {
        Temperature = 13,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 1306
    },
    new()
    {
        Temperature = 28,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 325
    },
    new()
    {
        Temperature = 26,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 595
    },
    new()
    {
        Temperature = 22,
        AirQuality = 46,
        SensorLocation = "WareHouse",
        Brightness = 1530
    },
    new()
    {
        Temperature = 54,
        AirQuality = 12,
        SensorLocation = "Office",
        Brightness = 1585
    },
    new()
    {
        Temperature = 24,
        AirQuality = 64,
        SensorLocation = "WareHouse",
        Brightness = 362
    },
    new()
    {
        Temperature = 26,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 852
    },
    new()
    {
        Temperature = 18,
        AirQuality = 88,
        SensorLocation = "Company",
        Brightness = 1207
    },
    new()
    {
        Temperature = 45,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 636
    },
    new()
    {
        Temperature = 26,
        AirQuality = 78,
        SensorLocation = "Company",
        Brightness = 776
    },
    new()
    {
        Temperature = 22,
        AirQuality = 81,
        SensorLocation = "Company",
        Brightness = 1311
    },
    new()
    {
        Temperature = 25,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 1235
    },
    new()
    {
        Temperature = 26,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 429
    },
    new()
    {
        Temperature = 24,
        AirQuality = 71,
        SensorLocation = "Company",
        Brightness = 1484
    },
    new()
    {
        Temperature = 51,
        AirQuality = 43,
        SensorLocation = "Company",
        Brightness = 1041
    },
    new()
    {
        Temperature = 30,
        AirQuality = 54,
        SensorLocation = "Office",
        Brightness = 876
    },
    new()
    {
        Temperature = 22,
        AirQuality = 26,
        SensorLocation = "Office",
        Brightness = 916
    },
    new()
    {
        Temperature = 38,
        AirQuality = 99,
        SensorLocation = "Company",
        Brightness = 604
    },
    new()
    {
        Temperature = 9,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 1227
    },
    new()
    {
        Temperature = 52,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1195
    },
    new()
    {
        Temperature = 16,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 786
    },
    new()
    {
        Temperature = 18,
        AirQuality = 83,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 52,
        AirQuality = 52,
        SensorLocation = "WareHouse",
        Brightness = 1598
    },
    new()
    {
        Temperature = 36,
        AirQuality = 80,
        SensorLocation = "WareHouse",
        Brightness = 811
    },
    new()
    {
        Temperature = 16,
        AirQuality = 45,
        SensorLocation = "Company",
        Brightness = 1271
    },
    new()
    {
        Temperature = 41,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 948
    },
    new()
    {
        Temperature = 19,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 889
    },
    new()
    {
        Temperature = 34,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 1345
    },
    new()
    {
        Temperature = 15,
        AirQuality = 66,
        SensorLocation = "WareHouse",
        Brightness = 1449
    },
    new()
    {
        Temperature = 36,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 1365
    },
    new()
    {
        Temperature = 21,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 790
    },
    new()
    {
        Temperature = 46,
        AirQuality = 29,
        SensorLocation = "WareHouse",
        Brightness = 1595
    },
    new()
    {
        Temperature = 33,
        AirQuality = 92,
        SensorLocation = "Company",
        Brightness = 1277
    },
    new()
    {
        Temperature = 21,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 761
    },
    new()
    {
        Temperature = 42,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 573
    },
    new()
    {
        Temperature = 39,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 320
    },
    new()
    {
        Temperature = 39,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 1456
    },
    new()
    {
        Temperature = 40,
        AirQuality = 46,
        SensorLocation = "Company",
        Brightness = 516
    },
    new()
    {
        Temperature = 46,
        AirQuality = 18,
        SensorLocation = "Company",
        Brightness = 489
    },
    new()
    {
        Temperature = 53,
        AirQuality = 3,
        SensorLocation = "WareHouse",
        Brightness = 1435
    },
    new()
    {
        Temperature = 25,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 1063
    },
    new()
    {
        Temperature = 44,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 647
    },
    new()
    {
        Temperature = 14,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 1404
    },
    new()
    {
        Temperature = 33,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 863
    },
    new()
    {
        Temperature = 44,
        AirQuality = 66,
        SensorLocation = "Office",
        Brightness = 1073
    },
    new()
    {
        Temperature = 17,
        AirQuality = 89,
        SensorLocation = "WareHouse",
        Brightness = 945
    },
    new()
    {
        Temperature = 22,
        AirQuality = 55,
        SensorLocation = "Company",
        Brightness = 419
    },
    new()
    {
        Temperature = 6,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1141
    },
    new()
    {
        Temperature = 53,
        AirQuality = 100,
        SensorLocation = "Company",
        Brightness = 1049
    },
    new()
    {
        Temperature = 7,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 1050
    },
    new()
    {
        Temperature = 34,
        AirQuality = 45,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 51,
        AirQuality = 57,
        SensorLocation = "WareHouse",
        Brightness = 245
    },
    new()
    {
        Temperature = 17,
        AirQuality = 20,
        SensorLocation = "Company",
        Brightness = 1064
    },
    new()
    {
        Temperature = 30,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 1083
    },
    new()
    {
        Temperature = 46,
        AirQuality = 23,
        SensorLocation = "WareHouse",
        Brightness = 371
    },
    new()
    {
        Temperature = 42,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 1018
    },
    new()
    {
        Temperature = 43,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 1177
    },
    new()
    {
        Temperature = 27,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 766
    },
    new()
    {
        Temperature = 40,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 617
    },
    new()
    {
        Temperature = 21,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 845
    },
    new()
    {
        Temperature = 13,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 373
    },
    new()
    {
        Temperature = 16,
        AirQuality = 12,
        SensorLocation = "Company",
        Brightness = 976
    },
    new()
    {
        Temperature = 33,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1171
    },
    new()
    {
        Temperature = 52,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 939
    },
    new()
    {
        Temperature = 25,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 557
    },
    new()
    {
        Temperature = 42,
        AirQuality = 75,
        SensorLocation = "Office",
        Brightness = 1162
    },
    new()
    {
        Temperature = 9,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 978
    },
    new()
    {
        Temperature = 38,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 353
    },
    new()
    {
        Temperature = 44,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 597
    },
    new()
    {
        Temperature = 11,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 656
    },
    new()
    {
        Temperature = 35,
        AirQuality = 4,
        SensorLocation = "Office",
        Brightness = 1271
    },
    new()
    {
        Temperature = 41,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1222
    },
    new()
    {
        Temperature = 36,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 657
    },
    new()
    {
        Temperature = 52,
        AirQuality = 26,
        SensorLocation = "Company",
        Brightness = 1337
    },
    new()
    {
        Temperature = 35,
        AirQuality = 88,
        SensorLocation = "Office",
        Brightness = 1347
    },
    new()
    {
        Temperature = 37,
        AirQuality = 33,
        SensorLocation = "Company",
        Brightness = 855
    },
    new()
    {
        Temperature = 34,
        AirQuality = 68,
        SensorLocation = "Company",
        Brightness = 337
    },
    new()
    {
        Temperature = 10,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 254
    },
    new()
    {
        Temperature = 43,
        AirQuality = 93,
        SensorLocation = "WareHouse",
        Brightness = 629
    },
    new()
    {
        Temperature = 22,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 821
    },
    new()
    {
        Temperature = 33,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 16,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1574
    },
    new()
    {
        Temperature = 9,
        AirQuality = 77,
        SensorLocation = "Office",
        Brightness = 1553
    },
    new()
    {
        Temperature = 43,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 660
    },
    new()
    {
        Temperature = 14,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 1114
    },
    new()
    {
        Temperature = 10,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 1335
    },
    new()
    {
        Temperature = 48,
        AirQuality = 46,
        SensorLocation = "WareHouse",
        Brightness = 691
    },
    new()
    {
        Temperature = 9,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 1135
    },
    new()
    {
        Temperature = 13,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 645
    },
    new()
    {
        Temperature = 33,
        AirQuality = 20,
        SensorLocation = "Office",
        Brightness = 678
    },
    new()
    {
        Temperature = 23,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 1448
    },
    new()
    {
        Temperature = 49,
        AirQuality = 5,
        SensorLocation = "Company",
        Brightness = 270
    },
    new()
    {
        Temperature = 37,
        AirQuality = 48,
        SensorLocation = "Company",
        Brightness = 323
    },
    new()
    {
        Temperature = 47,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 1370
    },
    new()
    {
        Temperature = 51,
        AirQuality = 17,
        SensorLocation = "WareHouse",
        Brightness = 842
    },
    new()
    {
        Temperature = 28,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 476
    },
    new()
    {
        Temperature = 29,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 1212
    },
    new()
    {
        Temperature = 47,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 882
    },
    new()
    {
        Temperature = 6,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 1397
    },
    new()
    {
        Temperature = 48,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1559
    },
    new()
    {
        Temperature = 22,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1140
    },
    new()
    {
        Temperature = 6,
        AirQuality = 23,
        SensorLocation = "Office",
        Brightness = 252
    },
    new()
    {
        Temperature = 42,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 604
    },
    new()
    {
        Temperature = 40,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 231
    },
    new()
    {
        Temperature = 19,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 523
    },
    new()
    {
        Temperature = 8,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 278
    },
    new()
    {
        Temperature = 38,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 585
    },
    new()
    {
        Temperature = 9,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 1331
    },
    new()
    {
        Temperature = 32,
        AirQuality = 16,
        SensorLocation = "WareHouse",
        Brightness = 615
    },
    new()
    {
        Temperature = 22,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1281
    },
    new()
    {
        Temperature = 42,
        AirQuality = 13,
        SensorLocation = "Office",
        Brightness = 775
    },
    new()
    {
        Temperature = 42,
        AirQuality = 43,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 28,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 946
    },
    new()
    {
        Temperature = 45,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 873
    },
    new()
    {
        Temperature = 35,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1598
    },
    new()
    {
        Temperature = 19,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 936
    },
    new()
    {
        Temperature = 14,
        AirQuality = 17,
        SensorLocation = "WareHouse",
        Brightness = 507
    },
    new()
    {
        Temperature = 14,
        AirQuality = 52,
        SensorLocation = "Office",
        Brightness = 1148
    },
    new()
    {
        Temperature = 28,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 619
    },
    new()
    {
        Temperature = 30,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 873
    },
    new()
    {
        Temperature = 43,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 237
    },
    new()
    {
        Temperature = 45,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 562
    },
    new()
    {
        Temperature = 11,
        AirQuality = 38,
        SensorLocation = "Office",
        Brightness = 1531
    },
    new()
    {
        Temperature = 33,
        AirQuality = 18,
        SensorLocation = "Company",
        Brightness = 330
    },
    new()
    {
        Temperature = 48,
        AirQuality = 4,
        SensorLocation = "Office",
        Brightness = 472
    },
    new()
    {
        Temperature = 14,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 508
    },
    new()
    {
        Temperature = 50,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1474
    },
    new()
    {
        Temperature = 46,
        AirQuality = 27,
        SensorLocation = "Office",
        Brightness = 1263
    },
    new()
    {
        Temperature = 41,
        AirQuality = 73,
        SensorLocation = "WareHouse",
        Brightness = 1545
    },
    new()
    {
        Temperature = 6,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 1108
    },
    new()
    {
        Temperature = 12,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 960
    },
    new()
    {
        Temperature = 46,
        AirQuality = 28,
        SensorLocation = "WareHouse",
        Brightness = 1437
    },
    new()
    {
        Temperature = 22,
        AirQuality = 63,
        SensorLocation = "Office",
        Brightness = 901
    },
    new()
    {
        Temperature = 6,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 436
    },
    new()
    {
        Temperature = 48,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 1055
    },
    new()
    {
        Temperature = 48,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 1558
    },
    new()
    {
        Temperature = 29,
        AirQuality = 28,
        SensorLocation = "WareHouse",
        Brightness = 539
    },
    new()
    {
        Temperature = 24,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1566
    },
    new()
    {
        Temperature = 35,
        AirQuality = 26,
        SensorLocation = "WareHouse",
        Brightness = 398
    },
    new()
    {
        Temperature = 16,
        AirQuality = 87,
        SensorLocation = "WareHouse",
        Brightness = 1064
    },
    new()
    {
        Temperature = 44,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 982
    },
    new()
    {
        Temperature = 33,
        AirQuality = 98,
        SensorLocation = "Office",
        Brightness = 790
    },
    new()
    {
        Temperature = 31,
        AirQuality = 26,
        SensorLocation = "Office",
        Brightness = 677
    },
    new()
    {
        Temperature = 43,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 1224
    },
    new()
    {
        Temperature = 55,
        AirQuality = 32,
        SensorLocation = "Company",
        Brightness = 876
    },
    new()
    {
        Temperature = 46,
        AirQuality = 9,
        SensorLocation = "WareHouse",
        Brightness = 904
    },
    new()
    {
        Temperature = 33,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 1004
    },
    new()
    {
        Temperature = 32,
        AirQuality = 75,
        SensorLocation = "Office",
        Brightness = 492
    },
    new()
    {
        Temperature = 34,
        AirQuality = 13,
        SensorLocation = "Company",
        Brightness = 810
    },
    new()
    {
        Temperature = 26,
        AirQuality = 77,
        SensorLocation = "WareHouse",
        Brightness = 724
    },
    new()
    {
        Temperature = 46,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 375
    },
    new()
    {
        Temperature = 51,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 969
    },
    new()
    {
        Temperature = 9,
        AirQuality = 53,
        SensorLocation = "WareHouse",
        Brightness = 1489
    },
    new()
    {
        Temperature = 46,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1159
    },
    new()
    {
        Temperature = 24,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 582
    },
    new()
    {
        Temperature = 52,
        AirQuality = 64,
        SensorLocation = "Office",
        Brightness = 491
    },
    new()
    {
        Temperature = 50,
        AirQuality = 75,
        SensorLocation = "Company",
        Brightness = 878
    },
    new()
    {
        Temperature = 27,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 204
    },
    new()
    {
        Temperature = 44,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 903
    },
    new()
    {
        Temperature = 55,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 1362
    },
    new()
    {
        Temperature = 30,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 336
    },
    new()
    {
        Temperature = 53,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 371
    },
    new()
    {
        Temperature = 17,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 646
    },
    new()
    {
        Temperature = 54,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 1028
    },
    new()
    {
        Temperature = 32,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1447
    },
    new()
    {
        Temperature = 31,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 1182
    },
    new()
    {
        Temperature = 50,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 474
    },
    new()
    {
        Temperature = 26,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 320
    },
    new()
    {
        Temperature = 35,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 1063
    },
    new()
    {
        Temperature = 39,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 519
    },
    new()
    {
        Temperature = 46,
        AirQuality = 7,
        SensorLocation = "WareHouse",
        Brightness = 1406
    },
    new()
    {
        Temperature = 16,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 733
    },
    new()
    {
        Temperature = 14,
        AirQuality = 30,
        SensorLocation = "Company",
        Brightness = 1261
    },
    new()
    {
        Temperature = 6,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 872
    },
    new()
    {
        Temperature = 17,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 901
    },
    new()
    {
        Temperature = 10,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 1478
    },
    new()
    {
        Temperature = 39,
        AirQuality = 50,
        SensorLocation = "Company",
        Brightness = 1314
    },
    new()
    {
        Temperature = 29,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 501
    },
    new()
    {
        Temperature = 43,
        AirQuality = 22,
        SensorLocation = "Company",
        Brightness = 1340
    },
    new()
    {
        Temperature = 32,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 1274
    },
    new()
    {
        Temperature = 43,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 1000
    },
    new()
    {
        Temperature = 8,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 985
    },
    new()
    {
        Temperature = 11,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 1392
    },
    new()
    {
        Temperature = 21,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 1584
    },
    new()
    {
        Temperature = 50,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 1598
    },
    new()
    {
        Temperature = 11,
        AirQuality = 38,
        SensorLocation = "Office",
        Brightness = 1091
    },
    new()
    {
        Temperature = 18,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 307
    },
    new()
    {
        Temperature = 36,
        AirQuality = 95,
        SensorLocation = "WareHouse",
        Brightness = 1102
    },
    new()
    {
        Temperature = 50,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 509
    },
    new()
    {
        Temperature = 34,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 835
    },
    new()
    {
        Temperature = 25,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 1397
    },
    new()
    {
        Temperature = 18,
        AirQuality = 81,
        SensorLocation = "WareHouse",
        Brightness = 1222
    },
    new()
    {
        Temperature = 9,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 1008
    },
    new()
    {
        Temperature = 51,
        AirQuality = 31,
        SensorLocation = "Office",
        Brightness = 1582
    },
    new()
    {
        Temperature = 43,
        AirQuality = 25,
        SensorLocation = "Office",
        Brightness = 1247
    },
    new()
    {
        Temperature = 38,
        AirQuality = 49,
        SensorLocation = "Company",
        Brightness = 1437
    },
    new()
    {
        Temperature = 29,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 937
    },
    new()
    {
        Temperature = 23,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 466
    },
    new()
    {
        Temperature = 16,
        AirQuality = 7,
        SensorLocation = "WareHouse",
        Brightness = 301
    },
    new()
    {
        Temperature = 30,
        AirQuality = 69,
        SensorLocation = "Company",
        Brightness = 307
    },
    new()
    {
        Temperature = 30,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 641
    },
    new()
    {
        Temperature = 8,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 557
    },
    new()
    {
        Temperature = 55,
        AirQuality = 12,
        SensorLocation = "WareHouse",
        Brightness = 1309
    },
    new()
    {
        Temperature = 7,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 1348
    },
    new()
    {
        Temperature = 14,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 847
    },
    new()
    {
        Temperature = 29,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 666
    },
    new()
    {
        Temperature = 31,
        AirQuality = 65,
        SensorLocation = "Office",
        Brightness = 654
    },
    new()
    {
        Temperature = 19,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 1157
    },
    new()
    {
        Temperature = 18,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 319
    },
    new()
    {
        Temperature = 5,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 1295
    },
    new()
    {
        Temperature = 33,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 530
    },
    new()
    {
        Temperature = 38,
        AirQuality = 45,
        SensorLocation = "WareHouse",
        Brightness = 1392
    },
    new()
    {
        Temperature = 46,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 1137
    },
    new()
    {
        Temperature = 50,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 250
    },
    new()
    {
        Temperature = 19,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 1015
    },
    new()
    {
        Temperature = 14,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 1178
    },
    new()
    {
        Temperature = 19,
        AirQuality = 82,
        SensorLocation = "WareHouse",
        Brightness = 1549
    },
    new()
    {
        Temperature = 10,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 1486
    },
    new()
    {
        Temperature = 18,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 264
    },
    new()
    {
        Temperature = 49,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1295
    },
    new()
    {
        Temperature = 48,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 210
    },
    new()
    {
        Temperature = 43,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1008
    },
    new()
    {
        Temperature = 27,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 1368
    },
    new()
    {
        Temperature = 26,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 1446
    },
    new()
    {
        Temperature = 13,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 484
    },
    new()
    {
        Temperature = 8,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 1579
    },
    new()
    {
        Temperature = 33,
        AirQuality = 49,
        SensorLocation = "Office",
        Brightness = 460
    },
    new()
    {
        Temperature = 20,
        AirQuality = 36,
        SensorLocation = "Office",
        Brightness = 1009
    },
    new()
    {
        Temperature = 42,
        AirQuality = 58,
        SensorLocation = "Office",
        Brightness = 1558
    },
    new()
    {
        Temperature = 29,
        AirQuality = 49,
        SensorLocation = "Office",
        Brightness = 688
    },
    new()
    {
        Temperature = 36,
        AirQuality = 10,
        SensorLocation = "WareHouse",
        Brightness = 1463
    },
    new()
    {
        Temperature = 43,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 980
    },
    new()
    {
        Temperature = 54,
        AirQuality = 87,
        SensorLocation = "Company",
        Brightness = 220
    },
    new()
    {
        Temperature = 43,
        AirQuality = 80,
        SensorLocation = "Company",
        Brightness = 1252
    },
    new()
    {
        Temperature = 24,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 1285
    },
    new()
    {
        Temperature = 47,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 1576
    },
    new()
    {
        Temperature = 25,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 1031
    },
    new()
    {
        Temperature = 39,
        AirQuality = 58,
        SensorLocation = "WareHouse",
        Brightness = 1211
    },
    new()
    {
        Temperature = 25,
        AirQuality = 33,
        SensorLocation = "Office",
        Brightness = 1393
    },
    new()
    {
        Temperature = 32,
        AirQuality = 73,
        SensorLocation = "Office",
        Brightness = 1418
    },
    new()
    {
        Temperature = 35,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 1471
    },
    new()
    {
        Temperature = 50,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 846
    },
    new()
    {
        Temperature = 38,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 1057
    },
    new()
    {
        Temperature = 44,
        AirQuality = 17,
        SensorLocation = "Office",
        Brightness = 439
    },
    new()
    {
        Temperature = 8,
        AirQuality = 40,
        SensorLocation = "Office",
        Brightness = 1488
    },
    new()
    {
        Temperature = 12,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 655
    },
    new()
    {
        Temperature = 18,
        AirQuality = 12,
        SensorLocation = "Office",
        Brightness = 473
    },
    new()
    {
        Temperature = 38,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 422
    },
    new()
    {
        Temperature = 7,
        AirQuality = 17,
        SensorLocation = "Company",
        Brightness = 724
    },
    new()
    {
        Temperature = 43,
        AirQuality = 42,
        SensorLocation = "WareHouse",
        Brightness = 486
    },
    new()
    {
        Temperature = 43,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 1421
    },
    new()
    {
        Temperature = 19,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 992
    },
    new()
    {
        Temperature = 52,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 588
    },
    new()
    {
        Temperature = 12,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 244
    },
    new()
    {
        Temperature = 52,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 1021
    },
    new()
    {
        Temperature = 17,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 1219
    },
    new()
    {
        Temperature = 6,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1029
    },
    new()
    {
        Temperature = 16,
        AirQuality = 57,
        SensorLocation = "WareHouse",
        Brightness = 485
    },
    new()
    {
        Temperature = 18,
        AirQuality = 41,
        SensorLocation = "Office",
        Brightness = 609
    },
    new()
    {
        Temperature = 11,
        AirQuality = 87,
        SensorLocation = "Company",
        Brightness = 320
    },
    new()
    {
        Temperature = 29,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 1119
    },
    new()
    {
        Temperature = 36,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 1472
    },
    new()
    {
        Temperature = 22,
        AirQuality = 56,
        SensorLocation = "Company",
        Brightness = 426
    },
    new()
    {
        Temperature = 23,
        AirQuality = 72,
        SensorLocation = "Office",
        Brightness = 1257
    },
    new()
    {
        Temperature = 26,
        AirQuality = 42,
        SensorLocation = "Company",
        Brightness = 951
    },
    new()
    {
        Temperature = 51,
        AirQuality = 48,
        SensorLocation = "WareHouse",
        Brightness = 1228
    },
    new()
    {
        Temperature = 34,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 740
    },
    new()
    {
        Temperature = 21,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 680
    },
    new()
    {
        Temperature = 31,
        AirQuality = 89,
        SensorLocation = "WareHouse",
        Brightness = 621
    },
    new()
    {
        Temperature = 54,
        AirQuality = 37,
        SensorLocation = "WareHouse",
        Brightness = 330
    },
    new()
    {
        Temperature = 54,
        AirQuality = 80,
        SensorLocation = "WareHouse",
        Brightness = 1392
    },
    new()
    {
        Temperature = 51,
        AirQuality = 89,
        SensorLocation = "Company",
        Brightness = 1376
    },
    new()
    {
        Temperature = 53,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 507
    },
    new()
    {
        Temperature = 5,
        AirQuality = 58,
        SensorLocation = "Company",
        Brightness = 623
    },
    new()
    {
        Temperature = 5,
        AirQuality = 55,
        SensorLocation = "Office",
        Brightness = 1120
    },
    new()
    {
        Temperature = 10,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 240
    },
    new()
    {
        Temperature = 47,
        AirQuality = 87,
        SensorLocation = "Office",
        Brightness = 817
    },
    new()
    {
        Temperature = 44,
        AirQuality = 69,
        SensorLocation = "Office",
        Brightness = 1527
    },
    new()
    {
        Temperature = 45,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 1409
    },
    new()
    {
        Temperature = 30,
        AirQuality = 88,
        SensorLocation = "Company",
        Brightness = 895
    },
    new()
    {
        Temperature = 8,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1034
    },
    new()
    {
        Temperature = 35,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 1546
    },
    new()
    {
        Temperature = 43,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 432
    },
    new()
    {
        Temperature = 16,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 1451
    },
    new()
    {
        Temperature = 7,
        AirQuality = 26,
        SensorLocation = "WareHouse",
        Brightness = 595
    },
    new()
    {
        Temperature = 49,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 495
    },
    new()
    {
        Temperature = 27,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 1038
    },
    new()
    {
        Temperature = 36,
        AirQuality = 35,
        SensorLocation = "Company",
        Brightness = 1260
    },
    new()
    {
        Temperature = 14,
        AirQuality = 31,
        SensorLocation = "Office",
        Brightness = 229
    },
    new()
    {
        Temperature = 50,
        AirQuality = 98,
        SensorLocation = "Company",
        Brightness = 1264
    },
    new()
    {
        Temperature = 30,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 218
    },
    new()
    {
        Temperature = 34,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 389
    },
    new()
    {
        Temperature = 27,
        AirQuality = 67,
        SensorLocation = "Office",
        Brightness = 347
    },
    new()
    {
        Temperature = 16,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 1017
    },
    new()
    {
        Temperature = 11,
        AirQuality = 95,
        SensorLocation = "WareHouse",
        Brightness = 964
    },
    new()
    {
        Temperature = 7,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 674
    },
    new()
    {
        Temperature = 13,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 233
    },
    new()
    {
        Temperature = 7,
        AirQuality = 31,
        SensorLocation = "Company",
        Brightness = 1037
    },
    new()
    {
        Temperature = 54,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 542
    },
    new()
    {
        Temperature = 43,
        AirQuality = 12,
        SensorLocation = "Company",
        Brightness = 330
    },
    new()
    {
        Temperature = 32,
        AirQuality = 10,
        SensorLocation = "Office",
        Brightness = 1166
    },
    new()
    {
        Temperature = 53,
        AirQuality = 47,
        SensorLocation = "WareHouse",
        Brightness = 1072
    },
    new()
    {
        Temperature = 23,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 505
    },
    new()
    {
        Temperature = 38,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1519
    },
    new()
    {
        Temperature = 19,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 771
    },
    new()
    {
        Temperature = 7,
        AirQuality = 39,
        SensorLocation = "WareHouse",
        Brightness = 1132
    },
    new()
    {
        Temperature = 23,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 1459
    },
    new()
    {
        Temperature = 19,
        AirQuality = 81,
        SensorLocation = "Company",
        Brightness = 1001
    },
    new()
    {
        Temperature = 11,
        AirQuality = 5,
        SensorLocation = "WareHouse",
        Brightness = 568
    },
    new()
    {
        Temperature = 11,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 1471
    },
    new()
    {
        Temperature = 40,
        AirQuality = 11,
        SensorLocation = "Office",
        Brightness = 1379
    },
    new()
    {
        Temperature = 28,
        AirQuality = 96,
        SensorLocation = "WareHouse",
        Brightness = 700
    },
    new()
    {
        Temperature = 23,
        AirQuality = 73,
        SensorLocation = "Office",
        Brightness = 660
    },
    new()
    {
        Temperature = 44,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 605
    },
    new()
    {
        Temperature = 32,
        AirQuality = 69,
        SensorLocation = "WareHouse",
        Brightness = 1300
    },
    new()
    {
        Temperature = 29,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 467
    },
    new()
    {
        Temperature = 21,
        AirQuality = 1,
        SensorLocation = "Company",
        Brightness = 1222
    },
    new()
    {
        Temperature = 41,
        AirQuality = 48,
        SensorLocation = "Company",
        Brightness = 983
    },
    new()
    {
        Temperature = 13,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1128
    },
    new()
    {
        Temperature = 36,
        AirQuality = 48,
        SensorLocation = "Office",
        Brightness = 1130
    },
    new()
    {
        Temperature = 27,
        AirQuality = 90,
        SensorLocation = "Office",
        Brightness = 603
    },
    new()
    {
        Temperature = 27,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 1173
    },
    new()
    {
        Temperature = 47,
        AirQuality = 1,
        SensorLocation = "WareHouse",
        Brightness = 568
    },
    new()
    {
        Temperature = 26,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 1071
    },
    new()
    {
        Temperature = 45,
        AirQuality = 2,
        SensorLocation = "WareHouse",
        Brightness = 1157
    },
    new()
    {
        Temperature = 24,
        AirQuality = 96,
        SensorLocation = "WareHouse",
        Brightness = 342
    },
    new()
    {
        Temperature = 24,
        AirQuality = 49,
        SensorLocation = "Company",
        Brightness = 1110
    },
    new()
    {
        Temperature = 40,
        AirQuality = 92,
        SensorLocation = "Company",
        Brightness = 337
    },
    new()
    {
        Temperature = 24,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 442
    },
    new()
    {
        Temperature = 34,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 644
    },
    new()
    {
        Temperature = 44,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1464
    },
    new()
    {
        Temperature = 47,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 1438
    },
    new()
    {
        Temperature = 9,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 1143
    },
    new()
    {
        Temperature = 31,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 1528
    },
    new()
    {
        Temperature = 23,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1346
    },
    new()
    {
        Temperature = 32,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 807
    },
    new()
    {
        Temperature = 14,
        AirQuality = 10,
        SensorLocation = "WareHouse",
        Brightness = 625
    },
    new()
    {
        Temperature = 51,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 702
    },
    new()
    {
        Temperature = 8,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 1121
    },
    new()
    {
        Temperature = 36,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 315
    },
    new()
    {
        Temperature = 29,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 623
    },
    new()
    {
        Temperature = 51,
        AirQuality = 87,
        SensorLocation = "WareHouse",
        Brightness = 1033
    },
    new()
    {
        Temperature = 10,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 1122
    },
    new()
    {
        Temperature = 53,
        AirQuality = 8,
        SensorLocation = "WareHouse",
        Brightness = 893
    },
    new()
    {
        Temperature = 29,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 1505
    },
    new()
    {
        Temperature = 17,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 1480
    },
    new()
    {
        Temperature = 18,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 1321
    },
    new()
    {
        Temperature = 24,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 694
    },
    new()
    {
        Temperature = 54,
        AirQuality = 86,
        SensorLocation = "WareHouse",
        Brightness = 1380
    },
    new()
    {
        Temperature = 10,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1068
    },
    new()
    {
        Temperature = 48,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 467
    },
    new()
    {
        Temperature = 34,
        AirQuality = 90,
        SensorLocation = "Company",
        Brightness = 485
    },
    new()
    {
        Temperature = 21,
        AirQuality = 73,
        SensorLocation = "WareHouse",
        Brightness = 1100
    },
    new()
    {
        Temperature = 28,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 1295
    },
    new()
    {
        Temperature = 43,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 437
    },
    new()
    {
        Temperature = 45,
        AirQuality = 72,
        SensorLocation = "Office",
        Brightness = 535
    },
    new()
    {
        Temperature = 30,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 1258
    },
    new()
    {
        Temperature = 49,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 1213
    },
    new()
    {
        Temperature = 54,
        AirQuality = 42,
        SensorLocation = "WareHouse",
        Brightness = 1169
    },
    new()
    {
        Temperature = 21,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 1003
    },
    new()
    {
        Temperature = 33,
        AirQuality = 85,
        SensorLocation = "WareHouse",
        Brightness = 915
    },
    new()
    {
        Temperature = 39,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 1506
    },
    new()
    {
        Temperature = 47,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 241
    },
    new()
    {
        Temperature = 38,
        AirQuality = 68,
        SensorLocation = "WareHouse",
        Brightness = 1481
    },
    new()
    {
        Temperature = 30,
        AirQuality = 36,
        SensorLocation = "Office",
        Brightness = 1129
    },
    new()
    {
        Temperature = 15,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 682
    },
    new()
    {
        Temperature = 13,
        AirQuality = 85,
        SensorLocation = "Office",
        Brightness = 632
    },
    new()
    {
        Temperature = 39,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 267
    },
    new()
    {
        Temperature = 23,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1408
    },
    new()
    {
        Temperature = 30,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 773
    },
    new()
    {
        Temperature = 6,
        AirQuality = 35,
        SensorLocation = "Company",
        Brightness = 499
    },
    new()
    {
        Temperature = 30,
        AirQuality = 6,
        SensorLocation = "Office",
        Brightness = 557
    },
    new()
    {
        Temperature = 17,
        AirQuality = 67,
        SensorLocation = "Company",
        Brightness = 1294
    },
    new()
    {
        Temperature = 11,
        AirQuality = 16,
        SensorLocation = "Company",
        Brightness = 795
    },
    new()
    {
        Temperature = 23,
        AirQuality = 94,
        SensorLocation = "Office",
        Brightness = 1556
    },
    new()
    {
        Temperature = 8,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 769
    },
    new()
    {
        Temperature = 47,
        AirQuality = 38,
        SensorLocation = "Company",
        Brightness = 1293
    },
    new()
    {
        Temperature = 18,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 848
    },
    new()
    {
        Temperature = 9,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 1232
    },
    new()
    {
        Temperature = 14,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 1429
    },
    new()
    {
        Temperature = 10,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 1371
    },
    new()
    {
        Temperature = 9,
        AirQuality = 86,
        SensorLocation = "WareHouse",
        Brightness = 603
    },
    new()
    {
        Temperature = 29,
        AirQuality = 29,
        SensorLocation = "Office",
        Brightness = 1132
    },
    new()
    {
        Temperature = 22,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 229
    },
    new()
    {
        Temperature = 51,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 989
    },
    new()
    {
        Temperature = 30,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 269
    },
    new()
    {
        Temperature = 20,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 863
    },
    new()
    {
        Temperature = 20,
        AirQuality = 25,
        SensorLocation = "WareHouse",
        Brightness = 1466
    },
    new()
    {
        Temperature = 27,
        AirQuality = 16,
        SensorLocation = "WareHouse",
        Brightness = 658
    },
    new()
    {
        Temperature = 30,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 1559
    },
    new()
    {
        Temperature = 39,
        AirQuality = 24,
        SensorLocation = "Office",
        Brightness = 1136
    },
    new()
    {
        Temperature = 33,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 578
    },
    new()
    {
        Temperature = 40,
        AirQuality = 68,
        SensorLocation = "WareHouse",
        Brightness = 332
    },
    new()
    {
        Temperature = 18,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 1190
    },
    new()
    {
        Temperature = 22,
        AirQuality = 13,
        SensorLocation = "Office",
        Brightness = 444
    },
    new()
    {
        Temperature = 17,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 1338
    },
    new()
    {
        Temperature = 54,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 922
    },
    new()
    {
        Temperature = 46,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 507
    },
    new()
    {
        Temperature = 14,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 260
    },
    new()
    {
        Temperature = 42,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 880
    },
    new()
    {
        Temperature = 42,
        AirQuality = 66,
        SensorLocation = "WareHouse",
        Brightness = 1502
    },
    new()
    {
        Temperature = 16,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1098
    },
    new()
    {
        Temperature = 27,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1142
    },
    new()
    {
        Temperature = 20,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 492
    },
    new()
    {
        Temperature = 33,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 1518
    },
    new()
    {
        Temperature = 13,
        AirQuality = 60,
        SensorLocation = "WareHouse",
        Brightness = 1306
    },
    new()
    {
        Temperature = 27,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 430
    },
    new()
    {
        Temperature = 49,
        AirQuality = 61,
        SensorLocation = "Company",
        Brightness = 888
    },
    new()
    {
        Temperature = 47,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 1509
    },
    new()
    {
        Temperature = 47,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 457
    },
    new()
    {
        Temperature = 34,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 723
    },
    new()
    {
        Temperature = 43,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1061
    },
    new()
    {
        Temperature = 18,
        AirQuality = 8,
        SensorLocation = "WareHouse",
        Brightness = 1550
    },
    new()
    {
        Temperature = 10,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 963
    },
    new()
    {
        Temperature = 8,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 470
    },
    new()
    {
        Temperature = 30,
        AirQuality = 12,
        SensorLocation = "WareHouse",
        Brightness = 386
    },
    new()
    {
        Temperature = 7,
        AirQuality = 64,
        SensorLocation = "Company",
        Brightness = 1515
    },
    new()
    {
        Temperature = 31,
        AirQuality = 41,
        SensorLocation = "WareHouse",
        Brightness = 1007
    },
    new()
    {
        Temperature = 29,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 1185
    },
    new()
    {
        Temperature = 21,
        AirQuality = 24,
        SensorLocation = "WareHouse",
        Brightness = 446
    },
    new()
    {
        Temperature = 37,
        AirQuality = 66,
        SensorLocation = "Office",
        Brightness = 876
    },
    new()
    {
        Temperature = 13,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 305
    },
    new()
    {
        Temperature = 13,
        AirQuality = 37,
        SensorLocation = "WareHouse",
        Brightness = 1478
    },
    new()
    {
        Temperature = 12,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 981
    },
    new()
    {
        Temperature = 5,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 369
    },
    new()
    {
        Temperature = 23,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 1015
    },
    new()
    {
        Temperature = 7,
        AirQuality = 78,
        SensorLocation = "Office",
        Brightness = 1527
    },
    new()
    {
        Temperature = 35,
        AirQuality = 89,
        SensorLocation = "Office",
        Brightness = 716
    },
    new()
    {
        Temperature = 25,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 1220
    },
    new()
    {
        Temperature = 17,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 19,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 1017
    },
    new()
    {
        Temperature = 54,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 1521
    },
    new()
    {
        Temperature = 50,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 488
    },
    new()
    {
        Temperature = 26,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 844
    },
    new()
    {
        Temperature = 21,
        AirQuality = 50,
        SensorLocation = "Company",
        Brightness = 1465
    },
    new()
    {
        Temperature = 31,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 529
    },
    new()
    {
        Temperature = 49,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 1064
    },
    new()
    {
        Temperature = 21,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 729
    },
    new()
    {
        Temperature = 15,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 468
    },
    new()
    {
        Temperature = 40,
        AirQuality = 90,
        SensorLocation = "Company",
        Brightness = 1328
    },
    new()
    {
        Temperature = 46,
        AirQuality = 67,
        SensorLocation = "WareHouse",
        Brightness = 1436
    },
    new()
    {
        Temperature = 21,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 782
    }
    , new()
                {
                    Temperature = 11,
                    AirQuality = 4,
                    SensorLocation = "Company",
                    Brightness = 1451
                },
    new()
    {
        Temperature = 26,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 1563
    },
    new()
    {
        Temperature = 20,
        AirQuality = 15,
        SensorLocation = "WareHouse",
        Brightness = 861
    },
    new()
    {
        Temperature = 46,
        AirQuality = 0,
        SensorLocation = "WareHouse",
        Brightness = 1356
    },
    new()
    {
        Temperature = 47,
        AirQuality = 34,
        SensorLocation = "WareHouse",
        Brightness = 1376
    },
    new()
    {
        Temperature = 30,
        AirQuality = 67,
        SensorLocation = "Company",
        Brightness = 960
    },
    new()
    {
        Temperature = 7,
        AirQuality = 71,
        SensorLocation = "Company",
        Brightness = 312
    },
    new()
    {
        Temperature = 43,
        AirQuality = 3,
        SensorLocation = "WareHouse",
        Brightness = 662
    },
    new()
    {
        Temperature = 43,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 556
    },
    new()
    {
        Temperature = 36,
        AirQuality = 1,
        SensorLocation = "WareHouse",
        Brightness = 235
    },
    new()
    {
        Temperature = 7,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 743
    },
    new()
    {
        Temperature = 46,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1150
    },
    new()
    {
        Temperature = 8,
        AirQuality = 93,
        SensorLocation = "WareHouse",
        Brightness = 611
    },
    new()
    {
        Temperature = 37,
        AirQuality = 0,
        SensorLocation = "Company",
        Brightness = 409
    },
    new()
    {
        Temperature = 34,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 515
    },
    new()
    {
        Temperature = 48,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 1112
    },
    new()
    {
        Temperature = 26,
        AirQuality = 65,
        SensorLocation = "Office",
        Brightness = 862
    },
    new()
    {
        Temperature = 15,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 1075
    },
    new()
    {
        Temperature = 35,
        AirQuality = 84,
        SensorLocation = "WareHouse",
        Brightness = 1572
    },
    new()
    {
        Temperature = 44,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 296
    },
    new()
    {
        Temperature = 26,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 1088
    },
    new()
    {
        Temperature = 31,
        AirQuality = 14,
        SensorLocation = "Company",
        Brightness = 1013
    },
    new()
    {
        Temperature = 20,
        AirQuality = 19,
        SensorLocation = "Company",
        Brightness = 483
    },
    new()
    {
        Temperature = 28,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 538
    },
    new()
    {
        Temperature = 40,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 1484
    },
    new()
    {
        Temperature = 41,
        AirQuality = 4,
        SensorLocation = "Company",
        Brightness = 713
    },
    new()
    {
        Temperature = 26,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 299
    },
    new()
    {
        Temperature = 22,
        AirQuality = 71,
        SensorLocation = "WareHouse",
        Brightness = 1411
    },
    new()
    {
        Temperature = 51,
        AirQuality = 52,
        SensorLocation = "Company",
        Brightness = 1243
    },
    new()
    {
        Temperature = 9,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 1372
    },
    new()
    {
        Temperature = 11,
        AirQuality = 71,
        SensorLocation = "WareHouse",
        Brightness = 1135
    },
    new()
    {
        Temperature = 51,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 1400
    },
    new()
    {
        Temperature = 12,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 994
    },
    new()
    {
        Temperature = 46,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1115
    },
    new()
    {
        Temperature = 44,
        AirQuality = 33,
        SensorLocation = "Company",
        Brightness = 816
    },
    new()
    {
        Temperature = 13,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 448
    },
    new()
    {
        Temperature = 48,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 616
    },
    new()
    {
        Temperature = 42,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 1025
    },
    new()
    {
        Temperature = 27,
        AirQuality = 62,
        SensorLocation = "WareHouse",
        Brightness = 1238
    },
    new()
    {
        Temperature = 17,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1154
    },
    new()
    {
        Temperature = 24,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 708
    },
    new()
    {
        Temperature = 15,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 230
    },
    new()
    {
        Temperature = 25,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 441
    },
    new()
    {
        Temperature = 46,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 548
    },
    new()
    {
        Temperature = 47,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1097
    },
    new()
    {
        Temperature = 14,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 358
    },
    new()
    {
        Temperature = 36,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1292
    },
    new()
    {
        Temperature = 30,
        AirQuality = 30,
        SensorLocation = "Company",
        Brightness = 1552
    },
    new()
    {
        Temperature = 21,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1089
    },
    new()
    {
        Temperature = 43,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1567
    },
    new()
    {
        Temperature = 36,
        AirQuality = 94,
        SensorLocation = "Company",
        Brightness = 391
    },
    new()
    {
        Temperature = 47,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 288
    },
    new()
    {
        Temperature = 31,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 779
    },
    new()
    {
        Temperature = 52,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 1346
    },
    new()
    {
        Temperature = 16,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 53,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 1079
    },
    new()
    {
        Temperature = 54,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 1316
    },
    new()
    {
        Temperature = 53,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1127
    },
    new()
    {
        Temperature = 13,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 1306
    },
    new()
    {
        Temperature = 28,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 325
    },
    new()
    {
        Temperature = 26,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 595
    },
    new()
    {
        Temperature = 22,
        AirQuality = 46,
        SensorLocation = "WareHouse",
        Brightness = 1530
    },
    new()
    {
        Temperature = 54,
        AirQuality = 12,
        SensorLocation = "Office",
        Brightness = 1585
    },
    new()
    {
        Temperature = 24,
        AirQuality = 64,
        SensorLocation = "WareHouse",
        Brightness = 362
    },
    new()
    {
        Temperature = 26,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 852
    },
    new()
    {
        Temperature = 18,
        AirQuality = 88,
        SensorLocation = "Company",
        Brightness = 1207
    },
    new()
    {
        Temperature = 45,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 636
    },
    new()
    {
        Temperature = 26,
        AirQuality = 78,
        SensorLocation = "Company",
        Brightness = 776
    },
    new()
    {
        Temperature = 22,
        AirQuality = 81,
        SensorLocation = "Company",
        Brightness = 1311
    },
    new()
    {
        Temperature = 25,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 1235
    },
    new()
    {
        Temperature = 26,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 429
    },
    new()
    {
        Temperature = 24,
        AirQuality = 71,
        SensorLocation = "Company",
        Brightness = 1484
    },
    new()
    {
        Temperature = 51,
        AirQuality = 43,
        SensorLocation = "Company",
        Brightness = 1041
    },
    new()
    {
        Temperature = 30,
        AirQuality = 54,
        SensorLocation = "Office",
        Brightness = 876
    },
    new()
    {
        Temperature = 22,
        AirQuality = 26,
        SensorLocation = "Office",
        Brightness = 916
    },
    new()
    {
        Temperature = 38,
        AirQuality = 99,
        SensorLocation = "Company",
        Brightness = 604
    },
    new()
    {
        Temperature = 9,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 1227
    },
    new()
    {
        Temperature = 52,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1195
    },
    new()
    {
        Temperature = 16,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 786
    },
    new()
    {
        Temperature = 18,
        AirQuality = 83,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 52,
        AirQuality = 52,
        SensorLocation = "WareHouse",
        Brightness = 1598
    },
    new()
    {
        Temperature = 36,
        AirQuality = 80,
        SensorLocation = "WareHouse",
        Brightness = 811
    },
    new()
    {
        Temperature = 16,
        AirQuality = 45,
        SensorLocation = "Company",
        Brightness = 1271
    },
    new()
    {
        Temperature = 41,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 948
    },
    new()
    {
        Temperature = 19,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 889
    },
    new()
    {
        Temperature = 34,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 1345
    },
    new()
    {
        Temperature = 15,
        AirQuality = 66,
        SensorLocation = "WareHouse",
        Brightness = 1449
    },
    new()
    {
        Temperature = 36,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 1365
    },
    new()
    {
        Temperature = 21,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 790
    },
    new()
    {
        Temperature = 46,
        AirQuality = 29,
        SensorLocation = "WareHouse",
        Brightness = 1595
    },
    new()
    {
        Temperature = 33,
        AirQuality = 92,
        SensorLocation = "Company",
        Brightness = 1277
    },
    new()
    {
        Temperature = 21,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 761
    },
    new()
    {
        Temperature = 42,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 573
    },
    new()
    {
        Temperature = 39,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 320
    },
    new()
    {
        Temperature = 39,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 1456
    },
    new()
    {
        Temperature = 40,
        AirQuality = 46,
        SensorLocation = "Company",
        Brightness = 516
    },
    new()
    {
        Temperature = 46,
        AirQuality = 18,
        SensorLocation = "Company",
        Brightness = 489
    },
    new()
    {
        Temperature = 53,
        AirQuality = 3,
        SensorLocation = "WareHouse",
        Brightness = 1435
    },
    new()
    {
        Temperature = 25,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 1063
    },
    new()
    {
        Temperature = 44,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 647
    },
    new()
    {
        Temperature = 14,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 1404
    },
    new()
    {
        Temperature = 33,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 863
    },
    new()
    {
        Temperature = 44,
        AirQuality = 66,
        SensorLocation = "Office",
        Brightness = 1073
    },
    new()
    {
        Temperature = 17,
        AirQuality = 89,
        SensorLocation = "WareHouse",
        Brightness = 945
    },
    new()
    {
        Temperature = 22,
        AirQuality = 55,
        SensorLocation = "Company",
        Brightness = 419
    },
    new()
    {
        Temperature = 6,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1141
    },
    new()
    {
        Temperature = 53,
        AirQuality = 100,
        SensorLocation = "Company",
        Brightness = 1049
    },
    new()
    {
        Temperature = 7,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 1050
    },
    new()
    {
        Temperature = 34,
        AirQuality = 45,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 51,
        AirQuality = 57,
        SensorLocation = "WareHouse",
        Brightness = 245
    },
    new()
    {
        Temperature = 17,
        AirQuality = 20,
        SensorLocation = "Company",
        Brightness = 1064
    },
    new()
    {
        Temperature = 30,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 1083
    },
    new()
    {
        Temperature = 46,
        AirQuality = 23,
        SensorLocation = "WareHouse",
        Brightness = 371
    },
    new()
    {
        Temperature = 42,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 1018
    },
    new()
    {
        Temperature = 43,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 1177
    },
    new()
    {
        Temperature = 27,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 766
    },
    new()
    {
        Temperature = 40,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 617
    },
    new()
    {
        Temperature = 21,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 845
    },
    new()
    {
        Temperature = 13,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 373
    },
    new()
    {
        Temperature = 16,
        AirQuality = 12,
        SensorLocation = "Company",
        Brightness = 976
    },
    new()
    {
        Temperature = 33,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1171
    },
    new()
    {
        Temperature = 52,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 939
    },
    new()
    {
        Temperature = 25,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 557
    },
    new()
    {
        Temperature = 42,
        AirQuality = 75,
        SensorLocation = "Office",
        Brightness = 1162
    },
    new()
    {
        Temperature = 9,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 978
    },
    new()
    {
        Temperature = 38,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 353
    },
    new()
    {
        Temperature = 44,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 597
    },
    new()
    {
        Temperature = 11,
        AirQuality = 63,
        SensorLocation = "WareHouse",
        Brightness = 656
    },
    new()
    {
        Temperature = 35,
        AirQuality = 4,
        SensorLocation = "Office",
        Brightness = 1271
    },
    new()
    {
        Temperature = 41,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1222
    },
    new()
    {
        Temperature = 36,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 657
    },
    new()
    {
        Temperature = 52,
        AirQuality = 26,
        SensorLocation = "Company",
        Brightness = 1337
    },
    new()
    {
        Temperature = 35,
        AirQuality = 88,
        SensorLocation = "Office",
        Brightness = 1347
    },
    new()
    {
        Temperature = 37,
        AirQuality = 33,
        SensorLocation = "Company",
        Brightness = 855
    },
    new()
    {
        Temperature = 34,
        AirQuality = 68,
        SensorLocation = "Company",
        Brightness = 337
    },
    new()
    {
        Temperature = 10,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 254
    },
    new()
    {
        Temperature = 43,
        AirQuality = 93,
        SensorLocation = "WareHouse",
        Brightness = 629
    },
    new()
    {
        Temperature = 22,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 821
    },
    new()
    {
        Temperature = 33,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 617
    },
    new()
    {
        Temperature = 16,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1574
    },
    new()
    {
        Temperature = 9,
        AirQuality = 77,
        SensorLocation = "Office",
        Brightness = 1553
    },
    new()
    {
        Temperature = 43,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 660
    },
    new()
    {
        Temperature = 14,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 1114
    },
    new()
    {
        Temperature = 10,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 1335
    },
    new()
    {
        Temperature = 48,
        AirQuality = 46,
        SensorLocation = "WareHouse",
        Brightness = 691
    },
    new()
    {
        Temperature = 9,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 1135
    },
    new()
    {
        Temperature = 13,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 645
    },
    new()
    {
        Temperature = 33,
        AirQuality = 20,
        SensorLocation = "Office",
        Brightness = 678
    },
    new()
    {
        Temperature = 23,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 1448
    },
    new()
    {
        Temperature = 49,
        AirQuality = 5,
        SensorLocation = "Company",
        Brightness = 270
    },
    new()
    {
        Temperature = 37,
        AirQuality = 48,
        SensorLocation = "Company",
        Brightness = 323
    },
    new()
    {
        Temperature = 47,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 1370
    },
    new()
    {
        Temperature = 51,
        AirQuality = 17,
        SensorLocation = "WareHouse",
        Brightness = 842
    },
    new()
    {
        Temperature = 28,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 476
    },
    new()
    {
        Temperature = 29,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 1212
    },
    new()
    {
        Temperature = 47,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 882
    },
    new()
    {
        Temperature = 6,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 1397
    },
    new()
    {
        Temperature = 48,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1559
    },
    new()
    {
        Temperature = 22,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1140
    },
    new()
    {
        Temperature = 6,
        AirQuality = 23,
        SensorLocation = "Office",
        Brightness = 252
    },
    new()
    {
        Temperature = 42,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 604
    },
    new()
    {
        Temperature = 40,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 231
    },
    new()
    {
        Temperature = 19,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 523
    },
    new()
    {
        Temperature = 8,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 278
    },
    new()
    {
        Temperature = 38,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 585
    },
    new()
    {
        Temperature = 9,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 1331
    },
    new()
    {
        Temperature = 32,
        AirQuality = 16,
        SensorLocation = "WareHouse",
        Brightness = 615
    },
    new()
    {
        Temperature = 22,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1281
    },
    new()
    {
        Temperature = 42,
        AirQuality = 13,
        SensorLocation = "Office",
        Brightness = 775
    },
    new()
    {
        Temperature = 42,
        AirQuality = 43,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 28,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 946
    },
    new()
    {
        Temperature = 45,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 873
    },
    new()
    {
        Temperature = 35,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1598
    },
    new()
    {
        Temperature = 19,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 936
    },
    new()
    {
        Temperature = 14,
        AirQuality = 17,
        SensorLocation = "WareHouse",
        Brightness = 507
    },
    new()
    {
        Temperature = 14,
        AirQuality = 52,
        SensorLocation = "Office",
        Brightness = 1148
    },
    new()
    {
        Temperature = 28,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 619
    },
    new()
    {
        Temperature = 30,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 873
    },
    new()
    {
        Temperature = 43,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 237
    },
    new()
    {
        Temperature = 45,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 562
    },
    new()
    {
        Temperature = 11,
        AirQuality = 38,
        SensorLocation = "Office",
        Brightness = 1531
    },
    new()
    {
        Temperature = 33,
        AirQuality = 18,
        SensorLocation = "Company",
        Brightness = 330
    },
    new()
    {
        Temperature = 48,
        AirQuality = 4,
        SensorLocation = "Office",
        Brightness = 472
    },
    new()
    {
        Temperature = 14,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 508
    },
    new()
    {
        Temperature = 50,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1474
    },
    new()
    {
        Temperature = 46,
        AirQuality = 27,
        SensorLocation = "Office",
        Brightness = 1263
    },
    new()
    {
        Temperature = 41,
        AirQuality = 73,
        SensorLocation = "WareHouse",
        Brightness = 1545
    },
    new()
    {
        Temperature = 6,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 1108
    },
    new()
    {
        Temperature = 12,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 960
    },
    new()
    {
        Temperature = 46,
        AirQuality = 28,
        SensorLocation = "WareHouse",
        Brightness = 1437
    },
    new()
    {
        Temperature = 22,
        AirQuality = 63,
        SensorLocation = "Office",
        Brightness = 901
    },
    new()
    {
        Temperature = 6,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 436
    },
    new()
    {
        Temperature = 48,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 1055
    },
    new()
    {
        Temperature = 48,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 1558
    },
    new()
    {
        Temperature = 29,
        AirQuality = 28,
        SensorLocation = "WareHouse",
        Brightness = 539
    },
    new()
    {
        Temperature = 24,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1566
    },
    new()
    {
        Temperature = 35,
        AirQuality = 26,
        SensorLocation = "WareHouse",
        Brightness = 398
    },
    new()
    {
        Temperature = 16,
        AirQuality = 87,
        SensorLocation = "WareHouse",
        Brightness = 1064
    },
    new()
    {
        Temperature = 44,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 982
    },
    new()
    {
        Temperature = 33,
        AirQuality = 98,
        SensorLocation = "Office",
        Brightness = 790
    },
    new()
    {
        Temperature = 31,
        AirQuality = 26,
        SensorLocation = "Office",
        Brightness = 677
    },
    new()
    {
        Temperature = 43,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 1224
    },
    new()
    {
        Temperature = 55,
        AirQuality = 32,
        SensorLocation = "Company",
        Brightness = 876
    },
    new()
    {
        Temperature = 46,
        AirQuality = 9,
        SensorLocation = "WareHouse",
        Brightness = 904
    },
    new()
    {
        Temperature = 33,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 1004
    },
    new()
    {
        Temperature = 32,
        AirQuality = 75,
        SensorLocation = "Office",
        Brightness = 492
    },
    new()
    {
        Temperature = 34,
        AirQuality = 13,
        SensorLocation = "Company",
        Brightness = 810
    },
    new()
    {
        Temperature = 26,
        AirQuality = 77,
        SensorLocation = "WareHouse",
        Brightness = 724
    },
    new()
    {
        Temperature = 46,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 375
    },
    new()
    {
        Temperature = 51,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 969
    },
    new()
    {
        Temperature = 9,
        AirQuality = 53,
        SensorLocation = "WareHouse",
        Brightness = 1489
    },
    new()
    {
        Temperature = 46,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1159
    },
    new()
    {
        Temperature = 24,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 582
    },
    new()
    {
        Temperature = 52,
        AirQuality = 64,
        SensorLocation = "Office",
        Brightness = 491
    },
    new()
    {
        Temperature = 50,
        AirQuality = 75,
        SensorLocation = "Company",
        Brightness = 878
    },
    new()
    {
        Temperature = 27,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 204
    },
    new()
    {
        Temperature = 44,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 903
    },
    new()
    {
        Temperature = 55,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 1362
    },
    new()
    {
        Temperature = 30,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 336
    },
    new()
    {
        Temperature = 53,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 371
    },
    new()
    {
        Temperature = 17,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 646
    },
    new()
    {
        Temperature = 54,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 1028
    },
    new()
    {
        Temperature = 32,
        AirQuality = 30,
        SensorLocation = "WareHouse",
        Brightness = 1447
    },
    new()
    {
        Temperature = 31,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 1182
    },
    new()
    {
        Temperature = 50,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 474
    },
    new()
    {
        Temperature = 26,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 320
    },
    new()
    {
        Temperature = 35,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 1063
    },
    new()
    {
        Temperature = 39,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 519
    },
    new()
    {
        Temperature = 46,
        AirQuality = 7,
        SensorLocation = "WareHouse",
        Brightness = 1406
    },
    new()
    {
        Temperature = 16,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 733
    },
    new()
    {
        Temperature = 14,
        AirQuality = 30,
        SensorLocation = "Company",
        Brightness = 1261
    },
    new()
    {
        Temperature = 6,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 872
    },
    new()
    {
        Temperature = 17,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 901
    },
    new()
    {
        Temperature = 10,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 1478
    },
    new()
    {
        Temperature = 39,
        AirQuality = 50,
        SensorLocation = "Company",
        Brightness = 1314
    },
    new()
    {
        Temperature = 29,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 501
    },
    new()
    {
        Temperature = 43,
        AirQuality = 22,
        SensorLocation = "Company",
        Brightness = 1340
    },
    new()
    {
        Temperature = 32,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 1274
    },
    new()
    {
        Temperature = 43,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 1000
    },
    new()
    {
        Temperature = 8,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 985
    },
    new()
    {
        Temperature = 11,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 1392
    },
    new()
    {
        Temperature = 21,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 1584
    },
    new()
    {
        Temperature = 50,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 1598
    },
    new()
    {
        Temperature = 11,
        AirQuality = 38,
        SensorLocation = "Office",
        Brightness = 1091
    },
    new()
    {
        Temperature = 18,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 307
    },
    new()
    {
        Temperature = 36,
        AirQuality = 95,
        SensorLocation = "WareHouse",
        Brightness = 1102
    },
    new()
    {
        Temperature = 50,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 509
    },
    new()
    {
        Temperature = 34,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 835
    },
    new()
    {
        Temperature = 25,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 1397
    },
    new()
    {
        Temperature = 18,
        AirQuality = 81,
        SensorLocation = "WareHouse",
        Brightness = 1222
    },
    new()
    {
        Temperature = 9,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 1008
    },
    new()
    {
        Temperature = 51,
        AirQuality = 31,
        SensorLocation = "Office",
        Brightness = 1582
    },
    new()
    {
        Temperature = 43,
        AirQuality = 25,
        SensorLocation = "Office",
        Brightness = 1247
    },
    new()
    {
        Temperature = 38,
        AirQuality = 49,
        SensorLocation = "Company",
        Brightness = 1437
    },
    new()
    {
        Temperature = 29,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 937
    },
    new()
    {
        Temperature = 23,
        AirQuality = 32,
        SensorLocation = "WareHouse",
        Brightness = 466
    },
    new()
    {
        Temperature = 16,
        AirQuality = 7,
        SensorLocation = "WareHouse",
        Brightness = 301
    },
    new()
    {
        Temperature = 30,
        AirQuality = 69,
        SensorLocation = "Company",
        Brightness = 307
    },
    new()
    {
        Temperature = 30,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 641
    },
    new()
    {
        Temperature = 8,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 557
    },
    new()
    {
        Temperature = 55,
        AirQuality = 12,
        SensorLocation = "WareHouse",
        Brightness = 1309
    },
    new()
    {
        Temperature = 7,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 1348
    },
    new()
    {
        Temperature = 14,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 847
    },
    new()
    {
        Temperature = 29,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 666
    },
    new()
    {
        Temperature = 31,
        AirQuality = 65,
        SensorLocation = "Office",
        Brightness = 654
    },
    new()
    {
        Temperature = 19,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 1157
    },
    new()
    {
        Temperature = 18,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 319
    },
    new()
    {
        Temperature = 5,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 1295
    },
    new()
    {
        Temperature = 33,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 530
    },
    new()
    {
        Temperature = 38,
        AirQuality = 45,
        SensorLocation = "WareHouse",
        Brightness = 1392
    },
    new()
    {
        Temperature = 46,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 1137
    },
    new()
    {
        Temperature = 50,
        AirQuality = 75,
        SensorLocation = "WareHouse",
        Brightness = 250
    },
    new()
    {
        Temperature = 19,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 1015
    },
    new()
    {
        Temperature = 14,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 1178
    },
    new()
    {
        Temperature = 19,
        AirQuality = 82,
        SensorLocation = "WareHouse",
        Brightness = 1549
    },
    new()
    {
        Temperature = 10,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 1486
    },
    new()
    {
        Temperature = 18,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 264
    },
    new()
    {
        Temperature = 49,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1295
    },
    new()
    {
        Temperature = 48,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 210
    },
    new()
    {
        Temperature = 43,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 1008
    },
    new()
    {
        Temperature = 27,
        AirQuality = 6,
        SensorLocation = "WareHouse",
        Brightness = 1368
    },
    new()
    {
        Temperature = 26,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 1446
    },
    new()
    {
        Temperature = 13,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 484
    },
    new()
    {
        Temperature = 8,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 1579
    },
    new()
    {
        Temperature = 33,
        AirQuality = 49,
        SensorLocation = "Office",
        Brightness = 460
    },
    new()
    {
        Temperature = 20,
        AirQuality = 36,
        SensorLocation = "Office",
        Brightness = 1009
    },
    new()
    {
        Temperature = 42,
        AirQuality = 58,
        SensorLocation = "Office",
        Brightness = 1558
    },
    new()
    {
        Temperature = 29,
        AirQuality = 49,
        SensorLocation = "Office",
        Brightness = 688
    },
    new()
    {
        Temperature = 36,
        AirQuality = 10,
        SensorLocation = "WareHouse",
        Brightness = 1463
    },
    new()
    {
        Temperature = 43,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 980
    },
    new()
    {
        Temperature = 54,
        AirQuality = 87,
        SensorLocation = "Company",
        Brightness = 220
    },
    new()
    {
        Temperature = 43,
        AirQuality = 80,
        SensorLocation = "Company",
        Brightness = 1252
    },
    new()
    {
        Temperature = 24,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 1285
    },
    new()
    {
        Temperature = 47,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 1576
    },
    new()
    {
        Temperature = 25,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 1031
    },
    new()
    {
        Temperature = 39,
        AirQuality = 58,
        SensorLocation = "WareHouse",
        Brightness = 1211
    },
    new()
    {
        Temperature = 25,
        AirQuality = 33,
        SensorLocation = "Office",
        Brightness = 1393
    },
    new()
    {
        Temperature = 32,
        AirQuality = 73,
        SensorLocation = "Office",
        Brightness = 1418
    },
    new()
    {
        Temperature = 35,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 1471
    },
    new()
    {
        Temperature = 50,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 846
    },
    new()
    {
        Temperature = 38,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 1057
    },
    new()
    {
        Temperature = 44,
        AirQuality = 17,
        SensorLocation = "Office",
        Brightness = 439
    },
    new()
    {
        Temperature = 8,
        AirQuality = 40,
        SensorLocation = "Office",
        Brightness = 1488
    },
    new()
    {
        Temperature = 12,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 655
    },
    new()
    {
        Temperature = 18,
        AirQuality = 12,
        SensorLocation = "Office",
        Brightness = 473
    },
    new()
    {
        Temperature = 38,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 422
    },
    new()
    {
        Temperature = 7,
        AirQuality = 17,
        SensorLocation = "Company",
        Brightness = 724
    },
    new()
    {
        Temperature = 43,
        AirQuality = 42,
        SensorLocation = "WareHouse",
        Brightness = 486
    },
    new()
    {
        Temperature = 43,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 1421
    },
    new()
    {
        Temperature = 19,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 992
    },
    new()
    {
        Temperature = 52,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 588
    },
    new()
    {
        Temperature = 12,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 244
    },
    new()
    {
        Temperature = 52,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 1021
    },
    new()
    {
        Temperature = 17,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 1219
    },
    new()
    {
        Temperature = 6,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1029
    },
    new()
    {
        Temperature = 16,
        AirQuality = 57,
        SensorLocation = "WareHouse",
        Brightness = 485
    },
    new()
    {
        Temperature = 18,
        AirQuality = 41,
        SensorLocation = "Office",
        Brightness = 609
    },
    new()
    {
        Temperature = 11,
        AirQuality = 87,
        SensorLocation = "Company",
        Brightness = 320
    },
    new()
    {
        Temperature = 29,
        AirQuality = 76,
        SensorLocation = "WareHouse",
        Brightness = 1119
    },
    new()
    {
        Temperature = 36,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 1472
    },
    new()
    {
        Temperature = 22,
        AirQuality = 56,
        SensorLocation = "Company",
        Brightness = 426
    },
    new()
    {
        Temperature = 23,
        AirQuality = 72,
        SensorLocation = "Office",
        Brightness = 1257
    },
    new()
    {
        Temperature = 26,
        AirQuality = 42,
        SensorLocation = "Company",
        Brightness = 951
    },
    new()
    {
        Temperature = 51,
        AirQuality = 48,
        SensorLocation = "WareHouse",
        Brightness = 1228
    },
    new()
    {
        Temperature = 34,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 740
    },
    new()
    {
        Temperature = 21,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 680
    },
    new()
    {
        Temperature = 31,
        AirQuality = 89,
        SensorLocation = "WareHouse",
        Brightness = 621
    },
    new()
    {
        Temperature = 54,
        AirQuality = 37,
        SensorLocation = "WareHouse",
        Brightness = 330
    },
    new()
    {
        Temperature = 54,
        AirQuality = 80,
        SensorLocation = "WareHouse",
        Brightness = 1392
    },
    new()
    {
        Temperature = 51,
        AirQuality = 89,
        SensorLocation = "Company",
        Brightness = 1376
    },
    new()
    {
        Temperature = 53,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 507
    },
    new()
    {
        Temperature = 5,
        AirQuality = 58,
        SensorLocation = "Company",
        Brightness = 623
    },
    new()
    {
        Temperature = 5,
        AirQuality = 55,
        SensorLocation = "Office",
        Brightness = 1120
    },
    new()
    {
        Temperature = 10,
        AirQuality = 90,
        SensorLocation = "WareHouse",
        Brightness = 240
    },
    new()
    {
        Temperature = 47,
        AirQuality = 87,
        SensorLocation = "Office",
        Brightness = 817
    },
    new()
    {
        Temperature = 44,
        AirQuality = 69,
        SensorLocation = "Office",
        Brightness = 1527
    },
    new()
    {
        Temperature = 45,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 1409
    },
    new()
    {
        Temperature = 30,
        AirQuality = 88,
        SensorLocation = "Company",
        Brightness = 895
    },
    new()
    {
        Temperature = 8,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1034
    },
    new()
    {
        Temperature = 35,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 1546
    },
    new()
    {
        Temperature = 43,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 432
    },
    new()
    {
        Temperature = 16,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 1451
    },
    new()
    {
        Temperature = 7,
        AirQuality = 26,
        SensorLocation = "WareHouse",
        Brightness = 595
    },
    new()
    {
        Temperature = 49,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 495
    },
    new()
    {
        Temperature = 27,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 1038
    },
    new()
    {
        Temperature = 36,
        AirQuality = 35,
        SensorLocation = "Company",
        Brightness = 1260
    },
    new()
    {
        Temperature = 14,
        AirQuality = 31,
        SensorLocation = "Office",
        Brightness = 229
    },
    new()
    {
        Temperature = 50,
        AirQuality = 98,
        SensorLocation = "Company",
        Brightness = 1264
    },
    new()
    {
        Temperature = 30,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 218
    },
    new()
    {
        Temperature = 34,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 389
    },
    new()
    {
        Temperature = 27,
        AirQuality = 67,
        SensorLocation = "Office",
        Brightness = 347
    },
    new()
    {
        Temperature = 16,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 1017
    },
    new()
    {
        Temperature = 11,
        AirQuality = 95,
        SensorLocation = "WareHouse",
        Brightness = 964
    },
    new()
    {
        Temperature = 7,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 674
    },
    new()
    {
        Temperature = 13,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 233
    },
    new()
    {
        Temperature = 7,
        AirQuality = 31,
        SensorLocation = "Company",
        Brightness = 1037
    },
    new()
    {
        Temperature = 54,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 542
    },
    new()
    {
        Temperature = 43,
        AirQuality = 12,
        SensorLocation = "Company",
        Brightness = 330
    },
    new()
    {
        Temperature = 32,
        AirQuality = 10,
        SensorLocation = "Office",
        Brightness = 1166
    },
    new()
    {
        Temperature = 53,
        AirQuality = 47,
        SensorLocation = "WareHouse",
        Brightness = 1072
    },
    new()
    {
        Temperature = 23,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 505
    },
    new()
    {
        Temperature = 38,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1519
    },
    new()
    {
        Temperature = 19,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 771
    },
    new()
    {
        Temperature = 7,
        AirQuality = 39,
        SensorLocation = "WareHouse",
        Brightness = 1132
    },
    new()
    {
        Temperature = 23,
        AirQuality = 14,
        SensorLocation = "WareHouse",
        Brightness = 1459
    },
    new()
    {
        Temperature = 19,
        AirQuality = 81,
        SensorLocation = "Company",
        Brightness = 1001
    },
    new()
    {
        Temperature = 11,
        AirQuality = 5,
        SensorLocation = "WareHouse",
        Brightness = 568
    },
    new()
    {
        Temperature = 11,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 1471
    },
    new()
    {
        Temperature = 40,
        AirQuality = 11,
        SensorLocation = "Office",
        Brightness = 1379
    },
    new()
    {
        Temperature = 28,
        AirQuality = 96,
        SensorLocation = "WareHouse",
        Brightness = 700
    },
    new()
    {
        Temperature = 23,
        AirQuality = 73,
        SensorLocation = "Office",
        Brightness = 660
    },
    new()
    {
        Temperature = 44,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 605
    },
    new()
    {
        Temperature = 32,
        AirQuality = 69,
        SensorLocation = "WareHouse",
        Brightness = 1300
    },
    new()
    {
        Temperature = 29,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 467
    },
    new()
    {
        Temperature = 21,
        AirQuality = 1,
        SensorLocation = "Company",
        Brightness = 1222
    },
    new()
    {
        Temperature = 41,
        AirQuality = 48,
        SensorLocation = "Company",
        Brightness = 983
    },
    new()
    {
        Temperature = 13,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1128
    },
    new()
    {
        Temperature = 36,
        AirQuality = 48,
        SensorLocation = "Office",
        Brightness = 1130
    },
    new()
    {
        Temperature = 27,
        AirQuality = 90,
        SensorLocation = "Office",
        Brightness = 603
    },
    new()
    {
        Temperature = 27,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 1173
    },
    new()
    {
        Temperature = 47,
        AirQuality = 1,
        SensorLocation = "WareHouse",
        Brightness = 568
    },
    new()
    {
        Temperature = 26,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 1071
    },
    new()
    {
        Temperature = 45,
        AirQuality = 2,
        SensorLocation = "WareHouse",
        Brightness = 1157
    },
    new()
    {
        Temperature = 24,
        AirQuality = 96,
        SensorLocation = "WareHouse",
        Brightness = 342
    },
    new()
    {
        Temperature = 24,
        AirQuality = 49,
        SensorLocation = "Company",
        Brightness = 1110
    },
    new()
    {
        Temperature = 40,
        AirQuality = 92,
        SensorLocation = "Company",
        Brightness = 337
    },
    new()
    {
        Temperature = 24,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 442
    },
    new()
    {
        Temperature = 34,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 644
    },
    new()
    {
        Temperature = 44,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1464
    },
    new()
    {
        Temperature = 47,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 1438
    },
    new()
    {
        Temperature = 9,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 1143
    },
    new()
    {
        Temperature = 31,
        AirQuality = 97,
        SensorLocation = "WareHouse",
        Brightness = 1528
    },
    new()
    {
        Temperature = 23,
        AirQuality = 61,
        SensorLocation = "WareHouse",
        Brightness = 1346
    },
    new()
    {
        Temperature = 32,
        AirQuality = 35,
        SensorLocation = "WareHouse",
        Brightness = 807
    },
    new()
    {
        Temperature = 14,
        AirQuality = 10,
        SensorLocation = "WareHouse",
        Brightness = 625
    },
    new()
    {
        Temperature = 51,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 702
    },
    new()
    {
        Temperature = 8,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 1121
    },
    new()
    {
        Temperature = 36,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 315
    },
    new()
    {
        Temperature = 29,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 623
    },
    new()
    {
        Temperature = 51,
        AirQuality = 87,
        SensorLocation = "WareHouse",
        Brightness = 1033
    },
    new()
    {
        Temperature = 10,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 1122
    },
    new()
    {
        Temperature = 53,
        AirQuality = 8,
        SensorLocation = "WareHouse",
        Brightness = 893
    },
    new()
    {
        Temperature = 29,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 1505
    },
    new()
    {
        Temperature = 17,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 1480
    },
    new()
    {
        Temperature = 18,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 1321
    },
    new()
    {
        Temperature = 24,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 694
    },
    new()
    {
        Temperature = 54,
        AirQuality = 86,
        SensorLocation = "WareHouse",
        Brightness = 1380
    },
    new()
    {
        Temperature = 10,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1068
    },
    new()
    {
        Temperature = 48,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 467
    },
    new()
    {
        Temperature = 34,
        AirQuality = 90,
        SensorLocation = "Company",
        Brightness = 485
    },
    new()
    {
        Temperature = 21,
        AirQuality = 73,
        SensorLocation = "WareHouse",
        Brightness = 1100
    },
    new()
    {
        Temperature = 28,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 1295
    },
    new()
    {
        Temperature = 43,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 437
    },
    new()
    {
        Temperature = 45,
        AirQuality = 72,
        SensorLocation = "Office",
        Brightness = 535
    },
    new()
    {
        Temperature = 30,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 1258
    },
    new()
    {
        Temperature = 49,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 1213
    },
    new()
    {
        Temperature = 54,
        AirQuality = 42,
        SensorLocation = "WareHouse",
        Brightness = 1169
    },
    new()
    {
        Temperature = 21,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 1003
    },
    new()
    {
        Temperature = 33,
        AirQuality = 85,
        SensorLocation = "WareHouse",
        Brightness = 915
    },
    new()
    {
        Temperature = 39,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 1506
    },
    new()
    {
        Temperature = 47,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 241
    },
    new()
    {
        Temperature = 38,
        AirQuality = 68,
        SensorLocation = "WareHouse",
        Brightness = 1481
    },
    new()
    {
        Temperature = 30,
        AirQuality = 36,
        SensorLocation = "Office",
        Brightness = 1129
    },
    new()
    {
        Temperature = 15,
        AirQuality = 44,
        SensorLocation = "WareHouse",
        Brightness = 682
    },
    new()
    {
        Temperature = 13,
        AirQuality = 85,
        SensorLocation = "Office",
        Brightness = 632
    },
    new()
    {
        Temperature = 39,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 267
    },
    new()
    {
        Temperature = 23,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1408
    },
    new()
    {
        Temperature = 30,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 773
    },
    new()
    {
        Temperature = 6,
        AirQuality = 35,
        SensorLocation = "Company",
        Brightness = 499
    },
    new()
    {
        Temperature = 30,
        AirQuality = 6,
        SensorLocation = "Office",
        Brightness = 557
    },
    new()
    {
        Temperature = 17,
        AirQuality = 67,
        SensorLocation = "Company",
        Brightness = 1294
    },
    new()
    {
        Temperature = 11,
        AirQuality = 16,
        SensorLocation = "Company",
        Brightness = 795
    },
    new()
    {
        Temperature = 23,
        AirQuality = 94,
        SensorLocation = "Office",
        Brightness = 1556
    },
    new()
    {
        Temperature = 8,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 769
    },
    new()
    {
        Temperature = 47,
        AirQuality = 38,
        SensorLocation = "Company",
        Brightness = 1293
    },
    new()
    {
        Temperature = 18,
        AirQuality = 79,
        SensorLocation = "WareHouse",
        Brightness = 848
    },
    new()
    {
        Temperature = 9,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 1232
    },
    new()
    {
        Temperature = 14,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 1429
    },
    new()
    {
        Temperature = 10,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 1371
    },
    new()
    {
        Temperature = 9,
        AirQuality = 86,
        SensorLocation = "WareHouse",
        Brightness = 603
    },
    new()
    {
        Temperature = 29,
        AirQuality = 29,
        SensorLocation = "Office",
        Brightness = 1132
    },
    new()
    {
        Temperature = 22,
        AirQuality = 54,
        SensorLocation = "WareHouse",
        Brightness = 229
    },
    new()
    {
        Temperature = 51,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 989
    },
    new()
    {
        Temperature = 30,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 269
    },
    new()
    {
        Temperature = 20,
        AirQuality = 98,
        SensorLocation = "WareHouse",
        Brightness = 863
    },
    new()
    {
        Temperature = 20,
        AirQuality = 25,
        SensorLocation = "WareHouse",
        Brightness = 1466
    },
    new()
    {
        Temperature = 27,
        AirQuality = 16,
        SensorLocation = "WareHouse",
        Brightness = 658
    },
    new()
    {
        Temperature = 30,
        AirQuality = 96,
        SensorLocation = "Office",
        Brightness = 1559
    },
    new()
    {
        Temperature = 39,
        AirQuality = 24,
        SensorLocation = "Office",
        Brightness = 1136
    },
    new()
    {
        Temperature = 33,
        AirQuality = 22,
        SensorLocation = "WareHouse",
        Brightness = 578
    },
    new()
    {
        Temperature = 40,
        AirQuality = 68,
        SensorLocation = "WareHouse",
        Brightness = 332
    },
    new()
    {
        Temperature = 18,
        AirQuality = 31,
        SensorLocation = "WareHouse",
        Brightness = 1190
    },
    new()
    {
        Temperature = 22,
        AirQuality = 13,
        SensorLocation = "Office",
        Brightness = 444
    },
    new()
    {
        Temperature = 17,
        AirQuality = 18,
        SensorLocation = "WareHouse",
        Brightness = 1338
    },
    new()
    {
        Temperature = 54,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 922
    },
    new()
    {
        Temperature = 46,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 507
    },
    new()
    {
        Temperature = 14,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 260
    },
    new()
    {
        Temperature = 42,
        AirQuality = 65,
        SensorLocation = "WareHouse",
        Brightness = 880
    },
    new()
    {
        Temperature = 42,
        AirQuality = 66,
        SensorLocation = "WareHouse",
        Brightness = 1502
    },
    new()
    {
        Temperature = 16,
        AirQuality = 20,
        SensorLocation = "WareHouse",
        Brightness = 1098
    },
    new()
    {
        Temperature = 27,
        AirQuality = 51,
        SensorLocation = "WareHouse",
        Brightness = 1142
    },
    new()
    {
        Temperature = 20,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 492
    },
    new()
    {
        Temperature = 33,
        AirQuality = 11,
        SensorLocation = "WareHouse",
        Brightness = 1518
    },
    new()
    {
        Temperature = 13,
        AirQuality = 60,
        SensorLocation = "WareHouse",
        Brightness = 1306
    },
    new()
    {
        Temperature = 27,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 430
    },
    new()
    {
        Temperature = 49,
        AirQuality = 61,
        SensorLocation = "Company",
        Brightness = 888
    },
    new()
    {
        Temperature = 47,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 1509
    },
    new()
    {
        Temperature = 47,
        AirQuality = 94,
        SensorLocation = "WareHouse",
        Brightness = 457
    },
    new()
    {
        Temperature = 34,
        AirQuality = 13,
        SensorLocation = "WareHouse",
        Brightness = 723
    },
    new()
    {
        Temperature = 43,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 1061
    },
    new()
    {
        Temperature = 18,
        AirQuality = 8,
        SensorLocation = "WareHouse",
        Brightness = 1550
    },
    new()
    {
        Temperature = 10,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 963
    },
    new()
    {
        Temperature = 8,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 470
    },
    new()
    {
        Temperature = 30,
        AirQuality = 12,
        SensorLocation = "WareHouse",
        Brightness = 386
    },
    new()
    {
        Temperature = 7,
        AirQuality = 64,
        SensorLocation = "Company",
        Brightness = 1515
    },
    new()
    {
        Temperature = 31,
        AirQuality = 41,
        SensorLocation = "WareHouse",
        Brightness = 1007
    },
    new()
    {
        Temperature = 29,
        AirQuality = 36,
        SensorLocation = "WareHouse",
        Brightness = 1185
    },
    new()
    {
        Temperature = 21,
        AirQuality = 24,
        SensorLocation = "WareHouse",
        Brightness = 446
    },
    new()
    {
        Temperature = 37,
        AirQuality = 66,
        SensorLocation = "Office",
        Brightness = 876
    },
    new()
    {
        Temperature = 13,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 305
    },
    new()
    {
        Temperature = 13,
        AirQuality = 37,
        SensorLocation = "WareHouse",
        Brightness = 1478
    },
    new()
    {
        Temperature = 12,
        AirQuality = 56,
        SensorLocation = "WareHouse",
        Brightness = 981
    },
    new()
    {
        Temperature = 5,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 369
    },
    new()
    {
        Temperature = 23,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 1015
    },
    new()
    {
        Temperature = 7,
        AirQuality = 78,
        SensorLocation = "Office",
        Brightness = 1527
    },
    new()
    {
        Temperature = 35,
        AirQuality = 89,
        SensorLocation = "Office",
        Brightness = 716
    },
    new()
    {
        Temperature = 25,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 1220
    },
    new()
    {
        Temperature = 17,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1106
    },
    new()
    {
        Temperature = 19,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 1017
    },
    new()
    {
        Temperature = 54,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 1521
    },
    new()
    {
        Temperature = 50,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 488
    },
    new()
    {
        Temperature = 26,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 844
    },
    new()
    {
        Temperature = 21,
        AirQuality = 50,
        SensorLocation = "Company",
        Brightness = 1465
    },
    new()
    {
        Temperature = 31,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 529
    },
    new()
    {
        Temperature = 49,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 1064
    },
    new()
    {
        Temperature = 21,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 729
    },
    new()
    {
        Temperature = 15,
        AirQuality = 33,
        SensorLocation = "WareHouse",
        Brightness = 468
    },
    new()
    {
        Temperature = 40,
        AirQuality = 90,
        SensorLocation = "Company",
        Brightness = 1328
    },
    new()
    {
        Temperature = 46,
        AirQuality = 67,
        SensorLocation = "WareHouse",
        Brightness = 1436
    },
    new()
    {
        Temperature = 21,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 782
    }
};
            #endregion


            _context.AddRange(env);
            _unitOfWork.Save();
            return env;
        }
        private Farm AddFarm()
        {
            Farm farm = new Farm() { Name = "farm-1" };
            _context.Add(farm);
            _unitOfWork.Save();
            return farm;
        }
        private IList<Device> AddDevices(Farm farm)
        {
            #region data devices
            IList<Device> devices = new List<Device>() {
            new(){ Id="sensor-0",Name="S1",Type="sensor",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="L1",Name="L1",Type="light",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="L2",Name="L2",Type="light",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="L3",Name="L3",Type="light",Status=false,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="L4",Name="L4",Type="light",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="L5",Name="L5",Type="light",Status=false,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="L6",Name="L6",Type="light",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="L7",Name="L7",Type="light",Status=true,ConnectionStatus=false,FarmId=farm.Id},
             new(){ Id="F1",Name="F1",Type="fan",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="F2",Name="F2",Type="fan",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="F3",Name="F3",Type="fan",Status=false,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="F4",Name="F4",Type="fan",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="F5",Name="F5",Type="fan",Status=false,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="F6",Name="F6",Type="fan",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="F7",Name="F7",Type="fan",Status=true,ConnectionStatus=false,FarmId=farm.Id},

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
