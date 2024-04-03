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
            IList<Environment> env = new List<Environment>()  {
    new() {
        Temperature = 74,
        AirQuality = 18,
        SensorLocation = "WareHourse",
        Brightness = 1117,
        Humidity = 60
    },
    new() {
        Temperature = 77,
        AirQuality = 40,
        SensorLocation = "WareHourse",
        Brightness = 422,
        Humidity = 34
    },
    new() {
        Temperature = 37,
        AirQuality = 38,
        SensorLocation = "Office",
        Brightness = 1116,
        Humidity = 97
    },
    new() {
        Temperature = 22,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 1328,
        Humidity = 85
    },
    new() {
        Temperature = 15,
        AirQuality = 43,
        SensorLocation = "Company",
        Brightness = 584,
        Humidity = 47
    },
    new() {
        Temperature = 28,
        AirQuality = 86,
        SensorLocation = "WareHourse",
        Brightness = 701,
        Humidity = 88
    },
    new() {
        Temperature = 14,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 629,
        Humidity = 90
    },
    new() {
        Temperature = 26,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 606,
        Humidity = 32
    },
    new() {
        Temperature = 95,
        AirQuality = 50,
        SensorLocation = "Company",
        Brightness = 1447,
        Humidity = 99
    },
    new() {
        Temperature = 71,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 1105,
        Humidity = 85
    },
    new() {
        Temperature = 71,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 619,
        Humidity = 38
    },
    new() {
        Temperature = 59,
        AirQuality = 52,
        SensorLocation = "Office",
        Brightness = 508,
        Humidity = 96
    },
    new() {
        Temperature = 17,
        AirQuality = 43,
        SensorLocation = "WareHourse",
        Brightness = 230,
        Humidity = 93
    },
    new() {
        Temperature = 70,
        AirQuality = 84,
        SensorLocation = "Office",
        Brightness = 1103,
        Humidity = 36
    },
    new() {
        Temperature = 20,
        AirQuality = 66,
        SensorLocation = "WareHourse",
        Brightness = 1397,
        Humidity = 54
    },
    new() {
        Temperature = 37,
        AirQuality = 52,
        SensorLocation = "Office",
        Brightness = 1212,
        Humidity = 33
    },
    new() {
        Temperature = 80,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 853,
        Humidity = 41
    },
    new() {
        Temperature = 59,
        AirQuality = 3,
        SensorLocation = "WareHourse",
        Brightness = 1060,
        Humidity = 78
    },
    new() {
        Temperature = 64,
        AirQuality = 19,
        SensorLocation = "Company",
        Brightness = 325,
        Humidity = 43
    },
    new() {
        Temperature = 18,
        AirQuality = 71,
        SensorLocation = "Office",
        Brightness = 1489,
        Humidity = 39
    },
    new() {
        Temperature = 11,
        AirQuality = 41,
        SensorLocation = "Office",
        Brightness = 695,
        Humidity = 32
    },
    new() {
        Temperature = 24,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 1321,
        Humidity = 34
    },
    new() {
        Temperature = 5,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 656,
        Humidity = 100
    },
    new() {
        Temperature = 53,
        AirQuality = 80,
        SensorLocation = "Company",
        Brightness = 1456,
        Humidity = 46
    },
    new() {
        Temperature = 87,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 342,
        Humidity = 70
    },
    new() {
        Temperature = 64,
        AirQuality = 88,
        SensorLocation = "Company",
        Brightness = 1381,
        Humidity = 96
    },
    new() {
        Temperature = 2,
        AirQuality = 94,
        SensorLocation = "WareHourse",
        Brightness = 1134,
        Humidity = 95
    },
    new() {
        Temperature = 1,
        AirQuality = 58,
        SensorLocation = "WareHourse",
        Brightness = 218,
        Humidity = 86
    },
    new() {
        Temperature = 92,
        AirQuality = 18,
        SensorLocation = "WareHourse",
        Brightness = 1346,
        Humidity = 72
    },
    new() {
        Temperature = 26,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 1409,
        Humidity = 64
    },
    new() {
        Temperature = 78,
        AirQuality = 63,
        SensorLocation = "Office",
        Brightness = 222,
        Humidity = 68
    },
    new() {
        Temperature = 78,
        AirQuality = 28,
        SensorLocation = "WareHourse",
        Brightness = 358,
        Humidity = 88
    },
    new() {
        Temperature = 84,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 454,
        Humidity = 47
    },
    new() {
        Temperature = 39,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 790,
        Humidity = 59
    },
    new() {
        Temperature = 18,
        AirQuality = 37,
        SensorLocation = "WareHourse",
        Brightness = 1065,
        Humidity = 60
    },
    new() {
        Temperature = 25,
        AirQuality = 59,
        SensorLocation = "WareHourse",
        Brightness = 606,
        Humidity = 39
    },
    new() {
        Temperature = 71,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 1156,
        Humidity = 55
    },
    new() {
        Temperature = 61,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 1366,
        Humidity = 66
    },
    new() {
        Temperature = 71,
        AirQuality = 17,
        SensorLocation = "Office",
        Brightness = 379,
        Humidity = 42
    },
    new() {
        Temperature = 68,
        AirQuality = 46,
        SensorLocation = "Company",
        Brightness = 972,
        Humidity = 43
    },
    new() {
        Temperature = 75,
        AirQuality = 88,
        SensorLocation = "Company",
        Brightness = 1235,
        Humidity = 63
    },
    new() {
        Temperature = 86,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 579,
        Humidity = 38
    },
    new() {
        Temperature = 16,
        AirQuality = 31,
        SensorLocation = "Company",
        Brightness = 1187,
        Humidity = 39
    },
    new() {
        Temperature = 69,
        AirQuality = 26,
        SensorLocation = "Office",
        Brightness = 616,
        Humidity = 46
    },
    new() {
        Temperature = 44,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1438,
        Humidity = 87
    },
    new() {
        Temperature = 90,
        AirQuality = 73,
        SensorLocation = "Office",
        Brightness = 1461,
        Humidity = 83
    },
    new() {
        Temperature = 24,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 865,
        Humidity = 64
    },
    new() {
        Temperature = 72,
        AirQuality = 73,
        SensorLocation = "Office",
        Brightness = 251,
        Humidity = 41
    },
    new() {
        Temperature = 1,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 1297,
        Humidity = 77
    },
    new() {
        Temperature = 26,
        AirQuality = 48,
        SensorLocation = "WareHourse",
        Brightness = 226,
        Humidity = 58
    },
    new() {
        Temperature = 61,
        AirQuality = 30,
        SensorLocation = "WareHourse",
        Brightness = 1263,
        Humidity = 59
    },
    new() {
        Temperature = 12,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1238,
        Humidity = 79
    },
    new() {
        Temperature = 3,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 1436,
        Humidity = 67
    },
    new() {
        Temperature = 14,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 947,
        Humidity = 35
    },
    new() {
        Temperature = 47,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1347,
        Humidity = 82
    },
    new() {
        Temperature = 34,
        AirQuality = 64,
        SensorLocation = "Company",
        Brightness = 522,
        Humidity = 99
    },
    new() {
        Temperature = 46,
        AirQuality = 65,
        SensorLocation = "WareHourse",
        Brightness = 972,
        Humidity = 58
    },
    new() {
        Temperature = 4,
        AirQuality = 73,
        SensorLocation = "WareHourse",
        Brightness = 1063,
        Humidity = 77
    },
    new() {
        Temperature = 67,
        AirQuality = 43,
        SensorLocation = "Office",
        Brightness = 793,
        Humidity = 41
    },
    new() {
        Temperature = 31,
        AirQuality = 33,
        SensorLocation = "Office",
        Brightness = 1420,
        Humidity = 98
    },
    new() {
        Temperature = 90,
        AirQuality = 48,
        SensorLocation = "Office",
        Brightness = 628,
        Humidity = 76
    },
    new() {
        Temperature = 61,
        AirQuality = 12,
        SensorLocation = "Company",
        Brightness = 1471,
        Humidity = 31
    },
    new() {
        Temperature = 7,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 752,
        Humidity = 88
    },
    new() {
        Temperature = 56,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 950,
        Humidity = 93
    },
    new() {
        Temperature = 33,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 150,
        Humidity = 34
    },
    new() {
        Temperature = 89,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 1142,
        Humidity = 52
    },
    new() {
        Temperature = 43,
        AirQuality = 9,
        SensorLocation = "WareHourse",
        Brightness = 526,
        Humidity = 86
    },
    new() {
        Temperature = 15,
        AirQuality = 78,
        SensorLocation = "WareHourse",
        Brightness = 925,
        Humidity = 41
    },
    new() {
        Temperature = 77,
        AirQuality = 34,
        SensorLocation = "WareHourse",
        Brightness = 539,
        Humidity = 74
    },
    new() {
        Temperature = 6,
        AirQuality = 27,
        SensorLocation = "Office",
        Brightness = 805,
        Humidity = 34
    },
    new() {
        Temperature = 87,
        AirQuality = 6,
        SensorLocation = "WareHourse",
        Brightness = 412,
        Humidity = 78
    },
    new() {
        Temperature = 72,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 784,
        Humidity = 48
    },
    new() {
        Temperature = 25,
        AirQuality = 48,
        SensorLocation = "Office",
        Brightness = 124,
        Humidity = 33
    },
    new() {
        Temperature = 66,
        AirQuality = 25,
        SensorLocation = "WareHourse",
        Brightness = 539,
        Humidity = 30
    },
    new() {
        Temperature = 93,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 867,
        Humidity = 78
    },
    new() {
        Temperature = 6,
        AirQuality = 65,
        SensorLocation = "WareHourse",
        Brightness = 1131,
        Humidity = 61
    },
    new() {
        Temperature = 70,
        AirQuality = 52,
        SensorLocation = "Office",
        Brightness = 501,
        Humidity = 97
    },
    new() {
        Temperature = 18,
        AirQuality = 67,
        SensorLocation = "Company",
        Brightness = 554,
        Humidity = 49
    },
    new() {
        Temperature = 76,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 1067,
        Humidity = 44
    },
    new() {
        Temperature = 65,
        AirQuality = 32,
        SensorLocation = "Office",
        Brightness = 828,
        Humidity = 32
    },
    new() {
        Temperature = 81,
        AirQuality = 16,
        SensorLocation = "Office",
        Brightness = 739,
        Humidity = 96
    },
    new() {
        Temperature = 89,
        AirQuality = 25,
        SensorLocation = "WareHourse",
        Brightness = 1272,
        Humidity = 92
    },
    new() {
        Temperature = 53,
        AirQuality = 99,
        SensorLocation = "WareHourse",
        Brightness = 1167,
        Humidity = 74
    },
    new() {
        Temperature = 44,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 859,
        Humidity = 74
    },
    new() {
        Temperature = 23,
        AirQuality = 52,
        SensorLocation = "WareHourse",
        Brightness = 1061,
        Humidity = 57
    },
    new() {
        Temperature = 13,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 157,
        Humidity = 58
    },
    new() {
        Temperature = 57,
        AirQuality = 99,
        SensorLocation = "Company",
        Brightness = 1141,
        Humidity = 59
    },
    new() {
        Temperature = 38,
        AirQuality = 4,
        SensorLocation = "WareHourse",
        Brightness = 632,
        Humidity = 96
    },
    new() {
        Temperature = 80,
        AirQuality = 13,
        SensorLocation = "Office",
        Brightness = 676,
        Humidity = 55
    },
    new() {
        Temperature = 65,
        AirQuality = 43,
        SensorLocation = "Company",
        Brightness = 961,
        Humidity = 88
    },
    new() {
        Temperature = 17,
        AirQuality = 2,
        SensorLocation = "Office",
        Brightness = 953,
        Humidity = 50
    },
    new() {
        Temperature = 17,
        AirQuality = 49,
        SensorLocation = "WareHourse",
        Brightness = 1322,
        Humidity = 46
    },
    new() {
        Temperature = 39,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 1235,
        Humidity = 63
    },
    new() {
        Temperature = 58,
        AirQuality = 41,
        SensorLocation = "WareHourse",
        Brightness = 733,
        Humidity = 43
    },
    new() {
        Temperature = 92,
        AirQuality = 56,
        SensorLocation = "Office",
        Brightness = 127,
        Humidity = 67
    },
    new() {
        Temperature = 32,
        AirQuality = 99,
        SensorLocation = "Office",
        Brightness = 830,
        Humidity = 92
    },
    new() {
        Temperature = 94,
        AirQuality = 15,
        SensorLocation = "WareHourse",
        Brightness = 538,
        Humidity = 51
    },
    new() {
        Temperature = 8,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 1101,
        Humidity = 96
    },
    new() {
        Temperature = 60,
        AirQuality = 38,
        SensorLocation = "Office",
        Brightness = 723,
        Humidity = 60
    },
    new() {
        Temperature = 60,
        AirQuality = 88,
        SensorLocation = "Office",
        Brightness = 199,
        Humidity = 80
    },
    new() {
        Temperature = 26,
        AirQuality = 33,
        SensorLocation = "WareHourse",
        Brightness = 1200,
        Humidity = 53
    },
    new() {
        Temperature = 72,
        AirQuality = 76,
        SensorLocation = "Company",
        Brightness = 184,
        Humidity = 40
    },
    new() {
        Temperature = 83,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 1213,
        Humidity = 80
    },
    new() {
        Temperature = 21,
        AirQuality = 27,
        SensorLocation = "Office",
        Brightness = 931,
        Humidity = 90
    },
    new() {
        Temperature = 8,
        AirQuality = 85,
        SensorLocation = "WareHourse",
        Brightness = 1160,
        Humidity = 84
    },
    new() {
        Temperature = 96,
        AirQuality = 64,
        SensorLocation = "WareHourse",
        Brightness = 235,
        Humidity = 35
    },
    new() {
        Temperature = 16,
        AirQuality = 98,
        SensorLocation = "WareHourse",
        Brightness = 778,
        Humidity = 95
    },
    new() {
        Temperature = 81,
        AirQuality = 24,
        SensorLocation = "Company",
        Brightness = 1212,
        Humidity = 75
    },
    new() {
        Temperature = 70,
        AirQuality = 85,
        SensorLocation = "Office",
        Brightness = 1014,
        Humidity = 36
    },
    new() {
        Temperature = 27,
        AirQuality = 80,
        SensorLocation = "Office",
        Brightness = 1288,
        Humidity = 75
    },
    new() {
        Temperature = 22,
        AirQuality = 44,
        SensorLocation = "WareHourse",
        Brightness = 1055,
        Humidity = 63
    },
    new() {
        Temperature = 79,
        AirQuality = 92,
        SensorLocation = "WareHourse",
        Brightness = 1085,
        Humidity = 73
    },
    new() {
        Temperature = 46,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 1257,
        Humidity = 47
    },
    new() {
        Temperature = 59,
        AirQuality = 6,
        SensorLocation = "WareHourse",
        Brightness = 1209,
        Humidity = 93
    },
    new() {
        Temperature = 84,
        AirQuality = 39,
        SensorLocation = "Company",
        Brightness = 508,
        Humidity = 89
    },
    new() {
        Temperature = 31,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 158,
        Humidity = 75
    },
    new() {
        Temperature = 58,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 1155,
        Humidity = 68
    },
    new() {
        Temperature = 2,
        AirQuality = 17,
        SensorLocation = "WareHourse",
        Brightness = 1352,
        Humidity = 84
    },
    new() {
        Temperature = 83,
        AirQuality = 76,
        SensorLocation = "Company",
        Brightness = 1376,
        Humidity = 69
    },
    new() {
        Temperature = 15,
        AirQuality = 18,
        SensorLocation = "Company",
        Brightness = 1229,
        Humidity = 75
    },
    new() {
        Temperature = 43,
        AirQuality = 69,
        SensorLocation = "WareHourse",
        Brightness = 971,
        Humidity = 37
    },
    new() {
        Temperature = 91,
        AirQuality = 93,
        SensorLocation = "Company",
        Brightness = 697,
        Humidity = 92
    },
    new() {
        Temperature = 71,
        AirQuality = 54,
        SensorLocation = "WareHourse",
        Brightness = 920,
        Humidity = 85
    },
    new() {
        Temperature = 83,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 777,
        Humidity = 65
    },
    new() {
        Temperature = 78,
        AirQuality = 60,
        SensorLocation = "Office",
        Brightness = 1222,
        Humidity = 39
    },
    new() {
        Temperature = 70,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 689,
        Humidity = 99
    },
    new() {
        Temperature = 68,
        AirQuality = 94,
        SensorLocation = "Company",
        Brightness = 308,
        Humidity = 67
    },
    new() {
        Temperature = 84,
        AirQuality = 9,
        SensorLocation = "WareHourse",
        Brightness = 755,
        Humidity = 91
    },
    new() {
        Temperature = 32,
        AirQuality = 81,
        SensorLocation = "WareHourse",
        Brightness = 1014,
        Humidity = 30
    },
    new() {
        Temperature = 43,
        AirQuality = 69,
        SensorLocation = "WareHourse",
        Brightness = 227,
        Humidity = 98
    },
    new() {
        Temperature = 6,
        AirQuality = 61,
        SensorLocation = "Company",
        Brightness = 665,
        Humidity = 95
    },
    new() {
        Temperature = 43,
        AirQuality = 100,
        SensorLocation = "Office",
        Brightness = 168,
        Humidity = 42
    },
    new() {
        Temperature = 12,
        AirQuality = 49,
        SensorLocation = "WareHourse",
        Brightness = 747,
        Humidity = 40
    },
    new() {
        Temperature = 27,
        AirQuality = 99,
        SensorLocation = "WareHourse",
        Brightness = 288,
        Humidity = 84
    },
    new() {
        Temperature = 73,
        AirQuality = 12,
        SensorLocation = "Company",
        Brightness = 1262,
        Humidity = 66
    },
    new() {
        Temperature = 88,
        AirQuality = 90,
        SensorLocation = "Company",
        Brightness = 1130,
        Humidity = 83
    },
    new() {
        Temperature = 22,
        AirQuality = 72,
        SensorLocation = "WareHourse",
        Brightness = 448,
        Humidity = 52
    },
    new() {
        Temperature = 7,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 241,
        Humidity = 85
    },
    new() {
        Temperature = 78,
        AirQuality = 100,
        SensorLocation = "Office",
        Brightness = 501,
        Humidity = 61
    },
    new() {
        Temperature = 12,
        AirQuality = 88,
        SensorLocation = "Office",
        Brightness = 360,
        Humidity = 53
    },
    new() {
        Temperature = 57,
        AirQuality = 88,
        SensorLocation = "WareHourse",
        Brightness = 1138,
        Humidity = 55
    },
    new() {
        Temperature = 65,
        AirQuality = 28,
        SensorLocation = "Company",
        Brightness = 673,
        Humidity = 98
    },
    new() {
        Temperature = 16,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 1314,
        Humidity = 50
    },
    new() {
        Temperature = 4,
        AirQuality = 45,
        SensorLocation = "WareHourse",
        Brightness = 821,
        Humidity = 82
    },
    new() {
        Temperature = 72,
        AirQuality = 99,
        SensorLocation = "Company",
        Brightness = 1043,
        Humidity = 74
    },
    new() {
        Temperature = 27,
        AirQuality = 89,
        SensorLocation = "Office",
        Brightness = 1131,
        Humidity = 64
    },
    new() {
        Temperature = 29,
        AirQuality = 17,
        SensorLocation = "WareHourse",
        Brightness = 823,
        Humidity = 90
    },
    new() {
        Temperature = 51,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 360,
        Humidity = 83
    },
    new() {
        Temperature = 77,
        AirQuality = 75,
        SensorLocation = "Company",
        Brightness = 370,
        Humidity = 32
    },
    new() {
        Temperature = 90,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 930,
        Humidity = 44
    },
    new() {
        Temperature = 23,
        AirQuality = 16,
        SensorLocation = "Office",
        Brightness = 193,
        Humidity = 80
    },
    new() {
        Temperature = 75,
        AirQuality = 46,
        SensorLocation = "WareHourse",
        Brightness = 628,
        Humidity = 46
    },
    new() {
        Temperature = 85,
        AirQuality = 96,
        SensorLocation = "WareHourse",
        Brightness = 1265,
        Humidity = 90
    },
    new() {
        Temperature = 25,
        AirQuality = 35,
        SensorLocation = "WareHourse",
        Brightness = 784,
        Humidity = 41
    },
    new() {
        Temperature = 86,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 841,
        Humidity = 72
    },
    new() {
        Temperature = 41,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 367,
        Humidity = 92
    },
    new() {
        Temperature = 20,
        AirQuality = 30,
        SensorLocation = "WareHourse",
        Brightness = 1016,
        Humidity = 89
    },
    new() {
        Temperature = 94,
        AirQuality = 29,
        SensorLocation = "Company",
        Brightness = 334,
        Humidity = 35
    },
    new() {
        Temperature = 36,
        AirQuality = 72,
        SensorLocation = "Company",
        Brightness = 747,
        Humidity = 62
    },
    new() {
        Temperature = 22,
        AirQuality = 94,
        SensorLocation = "Office",
        Brightness = 1385,
        Humidity = 51
    },
    new() {
        Temperature = 83,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1500,
        Humidity = 59
    },
    new() {
        Temperature = 45,
        AirQuality = 56,
        SensorLocation = "Company",
        Brightness = 1465,
        Humidity = 78
    },
    new() {
        Temperature = 13,
        AirQuality = 92,
        SensorLocation = "WareHourse",
        Brightness = 1406,
        Humidity = 70
    },
    new() {
        Temperature = 10,
        AirQuality = 45,
        SensorLocation = "Office",
        Brightness = 239,
        Humidity = 66
    },
    new() {
        Temperature = 69,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 391,
        Humidity = 99
    },
    new() {
        Temperature = 77,
        AirQuality = 22,
        SensorLocation = "WareHourse",
        Brightness = 1475,
        Humidity = 83
    },
    new() {
        Temperature = 33,
        AirQuality = 66,
        SensorLocation = "Office",
        Brightness = 1288,
        Humidity = 44
    },
    new() {
        Temperature = 44,
        AirQuality = 26,
        SensorLocation = "Company",
        Brightness = 877,
        Humidity = 99
    },
    new() {
        Temperature = 18,
        AirQuality = 87,
        SensorLocation = "Company",
        Brightness = 333,
        Humidity = 95
    },
    new() {
        Temperature = 61,
        AirQuality = 16,
        SensorLocation = "WareHourse",
        Brightness = 752,
        Humidity = 49
    },
    new() {
        Temperature = 30,
        AirQuality = 24,
        SensorLocation = "Office",
        Brightness = 384,
        Humidity = 83
    },
    new() {
        Temperature = 90,
        AirQuality = 24,
        SensorLocation = "WareHourse",
        Brightness = 858,
        Humidity = 53
    },
    new() {
        Temperature = 34,
        AirQuality = 89,
        SensorLocation = "Company",
        Brightness = 838,
        Humidity = 66
    },
    new() {
        Temperature = 33,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 937,
        Humidity = 38
    },
    new() {
        Temperature = 14,
        AirQuality = 19,
        SensorLocation = "Office",
        Brightness = 1069,
        Humidity = 97
    },
    new() {
        Temperature = 76,
        AirQuality = 80,
        SensorLocation = "Company",
        Brightness = 1248,
        Humidity = 81
    },
    new() {
        Temperature = 49,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 278,
        Humidity = 46
    },
    new() {
        Temperature = 40,
        AirQuality = 4,
        SensorLocation = "Office",
        Brightness = 1494,
        Humidity = 67
    },
    new() {
        Temperature = 23,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 794,
        Humidity = 63
    },
    new() {
        Temperature = 95,
        AirQuality = 51,
        SensorLocation = "Company",
        Brightness = 663,
        Humidity = 43
    },
    new() {
        Temperature = 52,
        AirQuality = 97,
        SensorLocation = "Company",
        Brightness = 1030,
        Humidity = 31
    },
    new() {
        Temperature = 54,
        AirQuality = 57,
        SensorLocation = "Company",
        Brightness = 1365,
        Humidity = 69
    },
    new() {
        Temperature = 84,
        AirQuality = 38,
        SensorLocation = "WareHourse",
        Brightness = 248,
        Humidity = 80
    },
    new() {
        Temperature = 67,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 960,
        Humidity = 51
    },
    new() {
        Temperature = 75,
        AirQuality = 58,
        SensorLocation = "Company",
        Brightness = 417,
        Humidity = 32
    },
    new() {
        Temperature = 30,
        AirQuality = 50,
        SensorLocation = "Company",
        Brightness = 891,
        Humidity = 43
    },
    new() {
        Temperature = 67,
        AirQuality = 94,
        SensorLocation = "WareHourse",
        Brightness = 1382,
        Humidity = 70
    },
    new() {
        Temperature = 86,
        AirQuality = 15,
        SensorLocation = "WareHourse",
        Brightness = 988,
        Humidity = 78
    },
    new() {
        Temperature = 40,
        AirQuality = 16,
        SensorLocation = "Company",
        Brightness = 628,
        Humidity = 49
    },
    new() {
        Temperature = 29,
        AirQuality = 63,
        SensorLocation = "WareHourse",
        Brightness = 672,
        Humidity = 73
    },
    new() {
        Temperature = 8,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 518,
        Humidity = 43
    },
    new() {
        Temperature = 86,
        AirQuality = 53,
        SensorLocation = "WareHourse",
        Brightness = 883,
        Humidity = 68
    },
    new() {
        Temperature = 40,
        AirQuality = 28,
        SensorLocation = "WareHourse",
        Brightness = 120,
        Humidity = 65
    },
    new() {
        Temperature = 19,
        AirQuality = 27,
        SensorLocation = "WareHourse",
        Brightness = 606,
        Humidity = 77
    },
    new() {
        Temperature = 27,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 582,
        Humidity = 60
    },
    new() {
        Temperature = 87,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 595,
        Humidity = 57
    },
    new() {
        Temperature = 57,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 179,
        Humidity = 100
    },
    new() {
        Temperature = 27,
        AirQuality = 11,
        SensorLocation = "Office",
        Brightness = 1296,
        Humidity = 98
    },
    new() {
        Temperature = 11,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 563,
        Humidity = 65
    },
    new() {
        Temperature = 35,
        AirQuality = 88,
        SensorLocation = "Office",
        Brightness = 765,
        Humidity = 31
    },
    new() {
        Temperature = 46,
        AirQuality = 38,
        SensorLocation = "Company",
        Brightness = 873,
        Humidity = 46
    },
    new() {
        Temperature = 55,
        AirQuality = 99,
        SensorLocation = "Office",
        Brightness = 297,
        Humidity = 47
    },
    new() {
        Temperature = 65,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 832,
        Humidity = 57
    },
    new() {
        Temperature = 66,
        AirQuality = 80,
        SensorLocation = "WareHourse",
        Brightness = 238,
        Humidity = 36
    },
    new() {
        Temperature = 55,
        AirQuality = 58,
        SensorLocation = "WareHourse",
        Brightness = 822,
        Humidity = 41
    },
    new() {
        Temperature = 20,
        AirQuality = 50,
        SensorLocation = "WareHourse",
        Brightness = 1100,
        Humidity = 53
    },
    new() {
        Temperature = 11,
        AirQuality = 5,
        SensorLocation = "Company",
        Brightness = 1038,
        Humidity = 86
    },
    new() {
        Temperature = 44,
        AirQuality = 38,
        SensorLocation = "WareHourse",
        Brightness = 623,
        Humidity = 95
    },
    new() {
        Temperature = 11,
        AirQuality = 2,
        SensorLocation = "WareHourse",
        Brightness = 512,
        Humidity = 94
    },
    new() {
        Temperature = 5,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 511,
        Humidity = 93
    },
    new() {
        Temperature = 6,
        AirQuality = 24,
        SensorLocation = "WareHourse",
        Brightness = 1467,
        Humidity = 73
    },
    new() {
        Temperature = 79,
        AirQuality = 58,
        SensorLocation = "Office",
        Brightness = 552,
        Humidity = 96
    },
    new() {
        Temperature = 6,
        AirQuality = 5,
        SensorLocation = "Office",
        Brightness = 543,
        Humidity = 99
    },
    new() {
        Temperature = 67,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 1067,
        Humidity = 68
    },
    new() {
        Temperature = 5,
        AirQuality = 96,
        SensorLocation = "WareHourse",
        Brightness = 902,
        Humidity = 35
    },
    new() {
        Temperature = 49,
        AirQuality = 38,
        SensorLocation = "Company",
        Brightness = 290,
        Humidity = 32
    },
    new() {
        Temperature = 66,
        AirQuality = 27,
        SensorLocation = "Company",
        Brightness = 614,
        Humidity = 88
    },
    new() {
        Temperature = 88,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 659,
        Humidity = 74
    },
    new() {
        Temperature = 96,
        AirQuality = 71,
        SensorLocation = "Company",
        Brightness = 707,
        Humidity = 78
    },
    new() {
        Temperature = 78,
        AirQuality = 10,
        SensorLocation = "Office",
        Brightness = 1219,
        Humidity = 46
    },
    new() {
        Temperature = 79,
        AirQuality = 2,
        SensorLocation = "Office",
        Brightness = 225,
        Humidity = 39
    },
    new() {
        Temperature = 43,
        AirQuality = 4,
        SensorLocation = "WareHourse",
        Brightness = 788,
        Humidity = 41
    },
    new() {
        Temperature = 59,
        AirQuality = 85,
        SensorLocation = "Office",
        Brightness = 377,
        Humidity = 67
    },
    new() {
        Temperature = 64,
        AirQuality = 52,
        SensorLocation = "WareHourse",
        Brightness = 1500,
        Humidity = 37
    },
    new() {
        Temperature = 6,
        AirQuality = 64,
        SensorLocation = "Office",
        Brightness = 361,
        Humidity = 39
    },
    new() {
        Temperature = 87,
        AirQuality = 90,
        SensorLocation = "Office",
        Brightness = 1383,
        Humidity = 53
    },
    new() {
        Temperature = 83,
        AirQuality = 63,
        SensorLocation = "WareHourse",
        Brightness = 846,
        Humidity = 68
    },
    new() {
        Temperature = 47,
        AirQuality = 18,
        SensorLocation = "WareHourse",
        Brightness = 1484,
        Humidity = 57
    },
    new() {
        Temperature = 16,
        AirQuality = 79,
        SensorLocation = "WareHourse",
        Brightness = 1285,
        Humidity = 82
    },
    new() {
        Temperature = 40,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 726,
        Humidity = 50
    },
    new() {
        Temperature = 77,
        AirQuality = 40,
        SensorLocation = "WareHourse",
        Brightness = 1116,
        Humidity = 84
    },
    new() {
        Temperature = 72,
        AirQuality = 18,
        SensorLocation = "WareHourse",
        Brightness = 1122,
        Humidity = 74
    },
    new() {
        Temperature = 45,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 1443,
        Humidity = 44
    },
    new() {
        Temperature = 96,
        AirQuality = 21,
        SensorLocation = "Company",
        Brightness = 1137,
        Humidity = 97
    },
    new() {
        Temperature = 35,
        AirQuality = 49,
        SensorLocation = "Office",
        Brightness = 483,
        Humidity = 96
    },
    new() {
        Temperature = 40,
        AirQuality = 31,
        SensorLocation = "WareHourse",
        Brightness = 582,
        Humidity = 65
    },
    new() {
        Temperature = 52,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 832,
        Humidity = 45
    },
    new() {
        Temperature = 87,
        AirQuality = 49,
        SensorLocation = "WareHourse",
        Brightness = 351,
        Humidity = 43
    },
    new() {
        Temperature = 38,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 1316,
        Humidity = 33
    },
    new() {
        Temperature = 59,
        AirQuality = 55,
        SensorLocation = "WareHourse",
        Brightness = 663,
        Humidity = 69
    },
    new() {
        Temperature = 64,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 680,
        Humidity = 51
    },
    new() {
        Temperature = 95,
        AirQuality = 43,
        SensorLocation = "Office",
        Brightness = 840,
        Humidity = 86
    },
    new() {
        Temperature = 98,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 500,
        Humidity = 93
    },
    new() {
        Temperature = 44,
        AirQuality = 3,
        SensorLocation = "Office",
        Brightness = 442,
        Humidity = 77
    },
    new() {
        Temperature = 100,
        AirQuality = 28,
        SensorLocation = "WareHourse",
        Brightness = 549,
        Humidity = 40
    },
    new() {
        Temperature = 44,
        AirQuality = 68,
        SensorLocation = "WareHourse",
        Brightness = 1303,
        Humidity = 56
    },
    new() {
        Temperature = 86,
        AirQuality = 18,
        SensorLocation = "Company",
        Brightness = 904,
        Humidity = 68
    },
    new() {
        Temperature = 23,
        AirQuality = 14,
        SensorLocation = "Company",
        Brightness = 715,
        Humidity = 94
    },
    new() {
        Temperature = 24,
        AirQuality = 11,
        SensorLocation = "WareHourse",
        Brightness = 1115,
        Humidity = 76
    },
    new() {
        Temperature = 93,
        AirQuality = 91,
        SensorLocation = "WareHourse",
        Brightness = 809,
        Humidity = 75
    },
    new() {
        Temperature = 63,
        AirQuality = 9,
        SensorLocation = "Company",
        Brightness = 849,
        Humidity = 74
    },
    new() {
        Temperature = 45,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 664,
        Humidity = 50
    },
    new() {
        Temperature = 57,
        AirQuality = 72,
        SensorLocation = "WareHourse",
        Brightness = 1125,
        Humidity = 47
    },
    new() {
        Temperature = 25,
        AirQuality = 13,
        SensorLocation = "Office",
        Brightness = 1122,
        Humidity = 75
    },
    new() {
        Temperature = 63,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 639,
        Humidity = 72
    },
    new() {
        Temperature = 23,
        AirQuality = 28,
        SensorLocation = "Office",
        Brightness = 831,
        Humidity = 73
    },
    new() {
        Temperature = 2,
        AirQuality = 14,
        SensorLocation = "Company",
        Brightness = 432,
        Humidity = 66
    },
    new() {
        Temperature = 89,
        AirQuality = 85,
        SensorLocation = "Office",
        Brightness = 632,
        Humidity = 38
    },
    new() {
        Temperature = 12,
        AirQuality = 55,
        SensorLocation = "Company",
        Brightness = 1193,
        Humidity = 88
    },
    new() {
        Temperature = 99,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 387,
        Humidity = 67
    },
    new() {
        Temperature = 74,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 1440,
        Humidity = 69
    },
    new() {
        Temperature = 3,
        AirQuality = 44,
        SensorLocation = "WareHourse",
        Brightness = 106,
        Humidity = 83
    },
    new() {
        Temperature = 37,
        AirQuality = 10,
        SensorLocation = "WareHourse",
        Brightness = 1072,
        Humidity = 54
    },
    new() {
        Temperature = 55,
        AirQuality = 9,
        SensorLocation = "WareHourse",
        Brightness = 724,
        Humidity = 58
    },
    new() {
        Temperature = 13,
        AirQuality = 39,
        SensorLocation = "Company",
        Brightness = 622,
        Humidity = 98
    },
    new() {
        Temperature = 80,
        AirQuality = 79,
        SensorLocation = "WareHourse",
        Brightness = 163,
        Humidity = 76
    },
    new() {
        Temperature = 38,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 164,
        Humidity = 47
    },
    new() {
        Temperature = 76,
        AirQuality = 1,
        SensorLocation = "WareHourse",
        Brightness = 1434,
        Humidity = 88
    },
    new() {
        Temperature = 39,
        AirQuality = 23,
        SensorLocation = "Office",
        Brightness = 251,
        Humidity = 76
    },
    new() {
        Temperature = 25,
        AirQuality = 50,
        SensorLocation = "WareHourse",
        Brightness = 1200,
        Humidity = 97
    },
    new() {
        Temperature = 74,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 193,
        Humidity = 34
    },
    new() {
        Temperature = 84,
        AirQuality = 98,
        SensorLocation = "Company",
        Brightness = 582,
        Humidity = 65
    },
    new() {
        Temperature = 31,
        AirQuality = 67,
        SensorLocation = "WareHourse",
        Brightness = 644,
        Humidity = 82
    },
    new() {
        Temperature = 49,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 751,
        Humidity = 44
    },
    new() {
        Temperature = 66,
        AirQuality = 84,
        SensorLocation = "Office",
        Brightness = 1493,
        Humidity = 38
    },
    new() {
        Temperature = 26,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 1382,
        Humidity = 58
    },
    new() {
        Temperature = 51,
        AirQuality = 21,
        SensorLocation = "Company",
        Brightness = 170,
        Humidity = 92
    },
    new() {
        Temperature = 83,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 986,
        Humidity = 81
    },
    new() {
        Temperature = 41,
        AirQuality = 60,
        SensorLocation = "WareHourse",
        Brightness = 147,
        Humidity = 52
    },
    new() {
        Temperature = 48,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 1381,
        Humidity = 35
    },
    new() {
        Temperature = 55,
        AirQuality = 82,
        SensorLocation = "WareHourse",
        Brightness = 325,
        Humidity = 63
    },
    new() {
        Temperature = 85,
        AirQuality = 17,
        SensorLocation = "WareHourse",
        Brightness = 639,
        Humidity = 38
    },
    new() {
        Temperature = 6,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 1277,
        Humidity = 81
    },
    new() {
        Temperature = 60,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 1087,
        Humidity = 74
    },
    new() {
        Temperature = 58,
        AirQuality = 45,
        SensorLocation = "Office",
        Brightness = 1378,
        Humidity = 33
    },
    new() {
        Temperature = 2,
        AirQuality = 22,
        SensorLocation = "Company",
        Brightness = 738,
        Humidity = 43
    },
    new() {
        Temperature = 21,
        AirQuality = 31,
        SensorLocation = "Company",
        Brightness = 864,
        Humidity = 84
    },
    new() {
        Temperature = 14,
        AirQuality = 4,
        SensorLocation = "Office",
        Brightness = 1301,
        Humidity = 61
    },
    new() {
        Temperature = 59,
        AirQuality = 67,
        SensorLocation = "Office",
        Brightness = 448,
        Humidity = 97
    },
    new() {
        Temperature = 3,
        AirQuality = 77,
        SensorLocation = "Office",
        Brightness = 1202,
        Humidity = 76
    },
    new() {
        Temperature = 58,
        AirQuality = 44,
        SensorLocation = "WareHourse",
        Brightness = 1412,
        Humidity = 94
    },
    new() {
        Temperature = 6,
        AirQuality = 85,
        SensorLocation = "Office",
        Brightness = 177,
        Humidity = 51
    },
    new() {
        Temperature = 25,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 266,
        Humidity = 44
    },
    new() {
        Temperature = 99,
        AirQuality = 74,
        SensorLocation = "WareHourse",
        Brightness = 228,
        Humidity = 61
    },
    new() {
        Temperature = 74,
        AirQuality = 98,
        SensorLocation = "Office",
        Brightness = 731,
        Humidity = 73
    },
    new() {
        Temperature = 59,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 1335,
        Humidity = 98
    },
    new() {
        Temperature = 45,
        AirQuality = 38,
        SensorLocation = "Company",
        Brightness = 136,
        Humidity = 30
    },
    new() {
        Temperature = 52,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 1438,
        Humidity = 71
    },
    new() {
        Temperature = 38,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 355,
        Humidity = 76
    },
    new() {
        Temperature = 4,
        AirQuality = 77,
        SensorLocation = "Company",
        Brightness = 1190,
        Humidity = 34
    },
    new() {
        Temperature = 89,
        AirQuality = 89,
        SensorLocation = "Office",
        Brightness = 438,
        Humidity = 82
    },
    new() {
        Temperature = 77,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 931,
        Humidity = 36
    },
    new() {
        Temperature = 23,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 129,
        Humidity = 83
    },
    new() {
        Temperature = 4,
        AirQuality = 67,
        SensorLocation = "Company",
        Brightness = 344,
        Humidity = 53
    },
    new() {
        Temperature = 94,
        AirQuality = 5,
        SensorLocation = "Company",
        Brightness = 437,
        Humidity = 82
    },
    new() {
        Temperature = 44,
        AirQuality = 65,
        SensorLocation = "Office",
        Brightness = 847,
        Humidity = 96
    },
    new() {
        Temperature = 31,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 971,
        Humidity = 68
    },
    new() {
        Temperature = 4,
        AirQuality = 28,
        SensorLocation = "WareHourse",
        Brightness = 206,
        Humidity = 46
    },
    new() {
        Temperature = 27,
        AirQuality = 76,
        SensorLocation = "WareHourse",
        Brightness = 1140,
        Humidity = 52
    },
    new() {
        Temperature = 46,
        AirQuality = 80,
        SensorLocation = "Company",
        Brightness = 526,
        Humidity = 54
    },
    new() {
        Temperature = 73,
        AirQuality = 93,
        SensorLocation = "WareHourse",
        Brightness = 686,
        Humidity = 55
    },
    new() {
        Temperature = 37,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 932,
        Humidity = 73
    },
    new() {
        Temperature = 97,
        AirQuality = 69,
        SensorLocation = "WareHourse",
        Brightness = 494,
        Humidity = 34
    },
    new() {
        Temperature = 59,
        AirQuality = 9,
        SensorLocation = "WareHourse",
        Brightness = 1398,
        Humidity = 60
    },
    new() {
        Temperature = 81,
        AirQuality = 72,
        SensorLocation = "Company",
        Brightness = 460,
        Humidity = 58
    },
    new() {
        Temperature = 3,
        AirQuality = 40,
        SensorLocation = "Office",
        Brightness = 568,
        Humidity = 34
    },
    new() {
        Temperature = 23,
        AirQuality = 27,
        SensorLocation = "Office",
        Brightness = 454,
        Humidity = 81
    },
    new() {
        Temperature = 19,
        AirQuality = 98,
        SensorLocation = "WareHourse",
        Brightness = 293,
        Humidity = 84
    },
    new() {
        Temperature = 44,
        AirQuality = 80,
        SensorLocation = "WareHourse",
        Brightness = 627,
        Humidity = 65
    },
    new() {
        Temperature = 50,
        AirQuality = 99,
        SensorLocation = "Office",
        Brightness = 493,
        Humidity = 89
    },
    new() {
        Temperature = 69,
        AirQuality = 5,
        SensorLocation = "Company",
        Brightness = 1132,
        Humidity = 46
    },
    new() {
        Temperature = 7,
        AirQuality = 13,
        SensorLocation = "Office",
        Brightness = 1201,
        Humidity = 80
    },
    new() {
        Temperature = 21,
        AirQuality = 2,
        SensorLocation = "Office",
        Brightness = 410,
        Humidity = 98
    },
    new() {
        Temperature = 6,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 312,
        Humidity = 69
    },
    new() {
        Temperature = 67,
        AirQuality = 71,
        SensorLocation = "Office",
        Brightness = 321,
        Humidity = 33
    },
    new() {
        Temperature = 33,
        AirQuality = 28,
        SensorLocation = "WareHourse",
        Brightness = 679,
        Humidity = 95
    },
    new() {
        Temperature = 52,
        AirQuality = 64,
        SensorLocation = "Company",
        Brightness = 1492,
        Humidity = 58
    },
    new() {
        Temperature = 71,
        AirQuality = 46,
        SensorLocation = "WareHourse",
        Brightness = 1069,
        Humidity = 37
    },
    new() {
        Temperature = 2,
        AirQuality = 61,
        SensorLocation = "Company",
        Brightness = 1058,
        Humidity = 81
    },
    new() {
        Temperature = 34,
        AirQuality = 98,
        SensorLocation = "WareHourse",
        Brightness = 1260,
        Humidity = 62
    },
    new() {
        Temperature = 80,
        AirQuality = 4,
        SensorLocation = "WareHourse",
        Brightness = 694,
        Humidity = 31
    },
    new() {
        Temperature = 52,
        AirQuality = 17,
        SensorLocation = "WareHourse",
        Brightness = 248,
        Humidity = 67
    },
    new() {
        Temperature = 29,
        AirQuality = 99,
        SensorLocation = "Office",
        Brightness = 767,
        Humidity = 51
    },
    new() {
        Temperature = 27,
        AirQuality = 6,
        SensorLocation = "Office",
        Brightness = 403,
        Humidity = 46
    },
    new() {
        Temperature = 28,
        AirQuality = 78,
        SensorLocation = "WareHourse",
        Brightness = 856,
        Humidity = 76
    },
    new() {
        Temperature = 28,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 423,
        Humidity = 98
    },
    new() {
        Temperature = 48,
        AirQuality = 29,
        SensorLocation = "Company",
        Brightness = 478,
        Humidity = 95
    },
    new() {
        Temperature = 54,
        AirQuality = 80,
        SensorLocation = "Company",
        Brightness = 851,
        Humidity = 50
    },
    new() {
        Temperature = 38,
        AirQuality = 9,
        SensorLocation = "Company",
        Brightness = 1176,
        Humidity = 57
    },
    new() {
        Temperature = 76,
        AirQuality = 64,
        SensorLocation = "Company",
        Brightness = 803,
        Humidity = 62
    },
    new() {
        Temperature = 23,
        AirQuality = 100,
        SensorLocation = "Company",
        Brightness = 235,
        Humidity = 36
    },
    new() {
        Temperature = 9,
        AirQuality = 89,
        SensorLocation = "Company",
        Brightness = 806,
        Humidity = 62
    },
    new() {
        Temperature = 68,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 318,
        Humidity = 77
    },
    new() {
        Temperature = 59,
        AirQuality = 42,
        SensorLocation = "WareHourse",
        Brightness = 583,
        Humidity = 99
    },
    new() {
        Temperature = 19,
        AirQuality = 23,
        SensorLocation = "WareHourse",
        Brightness = 114,
        Humidity = 48
    },
    new() {
        Temperature = 84,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 1217,
        Humidity = 100
    },
    new() {
        Temperature = 28,
        AirQuality = 10,
        SensorLocation = "Company",
        Brightness = 1226,
        Humidity = 63
    },
    new() {
        Temperature = 27,
        AirQuality = 94,
        SensorLocation = "Company",
        Brightness = 1098,
        Humidity = 65
    },
    new() {
        Temperature = 99,
        AirQuality = 69,
        SensorLocation = "Company",
        Brightness = 1222,
        Humidity = 50
    },
    new() {
        Temperature = 17,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 390,
        Humidity = 82
    },
    new() {
        Temperature = 40,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 1414,
        Humidity = 57
    },
    new() {
        Temperature = 44,
        AirQuality = 1,
        SensorLocation = "WareHourse",
        Brightness = 235,
        Humidity = 93
    },
    new() {
        Temperature = 85,
        AirQuality = 9,
        SensorLocation = "Company",
        Brightness = 446,
        Humidity = 65
    },
    new() {
        Temperature = 75,
        AirQuality = 100,
        SensorLocation = "Office",
        Brightness = 742,
        Humidity = 49
    },
    new() {
        Temperature = 18,
        AirQuality = 74,
        SensorLocation = "Office",
        Brightness = 1184,
        Humidity = 72
    },
    new() {
        Temperature = 55,
        AirQuality = 25,
        SensorLocation = "Office",
        Brightness = 1306,
        Humidity = 52
    },
    new() {
        Temperature = 19,
        AirQuality = 72,
        SensorLocation = "Company",
        Brightness = 877,
        Humidity = 91
    },
    new() {
        Temperature = 48,
        AirQuality = 10,
        SensorLocation = "Office",
        Brightness = 125,
        Humidity = 61
    },
    new() {
        Temperature = 89,
        AirQuality = 71,
        SensorLocation = "WareHourse",
        Brightness = 525,
        Humidity = 33
    },
    new() {
        Temperature = 80,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 733,
        Humidity = 60
    },
    new() {
        Temperature = 49,
        AirQuality = 39,
        SensorLocation = "Office",
        Brightness = 1391,
        Humidity = 55
    },
    new() {
        Temperature = 74,
        AirQuality = 67,
        SensorLocation = "WareHourse",
        Brightness = 892,
        Humidity = 82
    },
    new() {
        Temperature = 65,
        AirQuality = 16,
        SensorLocation = "Office",
        Brightness = 921,
        Humidity = 88
    },
    new() {
        Temperature = 87,
        AirQuality = 64,
        SensorLocation = "Office",
        Brightness = 281,
        Humidity = 62
    },
    new() {
        Temperature = 73,
        AirQuality = 74,
        SensorLocation = "WareHourse",
        Brightness = 415,
        Humidity = 89
    },
    new() {
        Temperature = 74,
        AirQuality = 77,
        SensorLocation = "WareHourse",
        Brightness = 1311,
        Humidity = 92
    },
    new() {
        Temperature = 48,
        AirQuality = 44,
        SensorLocation = "Company",
        Brightness = 933,
        Humidity = 72
    },
    new() {
        Temperature = 36,
        AirQuality = 86,
        SensorLocation = "WareHourse",
        Brightness = 1273,
        Humidity = 95
    },
    new() {
        Temperature = 60,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 993,
        Humidity = 93
    },
    new() {
        Temperature = 33,
        AirQuality = 2,
        SensorLocation = "Office",
        Brightness = 1469,
        Humidity = 43
    },
    new() {
        Temperature = 40,
        AirQuality = 76,
        SensorLocation = "Company",
        Brightness = 1363,
        Humidity = 51
    },
    new() {
        Temperature = 61,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 736,
        Humidity = 32
    },
    new() {
        Temperature = 43,
        AirQuality = 31,
        SensorLocation = "Office",
        Brightness = 282,
        Humidity = 45
    },
    new() {
        Temperature = 54,
        AirQuality = 52,
        SensorLocation = "Office",
        Brightness = 1196,
        Humidity = 95
    },
    new() {
        Temperature = 98,
        AirQuality = 8,
        SensorLocation = "WareHourse",
        Brightness = 1140,
        Humidity = 42
    },
    new() {
        Temperature = 17,
        AirQuality = 35,
        SensorLocation = "Company",
        Brightness = 1388,
        Humidity = 50
    },
    new() {
        Temperature = 52,
        AirQuality = 22,
        SensorLocation = "Company",
        Brightness = 262,
        Humidity = 94
    },
    new() {
        Temperature = 75,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 303,
        Humidity = 91
    },
    new() {
        Temperature = 30,
        AirQuality = 77,
        SensorLocation = "WareHourse",
        Brightness = 1251,
        Humidity = 42
    },
    new() {
        Temperature = 23,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 178,
        Humidity = 32
    },
    new() {
        Temperature = 85,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 493,
        Humidity = 63
    },
    new() {
        Temperature = 60,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 568,
        Humidity = 98
    },
    new() {
        Temperature = 88,
        AirQuality = 10,
        SensorLocation = "Company",
        Brightness = 290,
        Humidity = 61
    },
    new() {
        Temperature = 2,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 680,
        Humidity = 46
    },
    new() {
        Temperature = 59,
        AirQuality = 60,
        SensorLocation = "Company",
        Brightness = 937,
        Humidity = 61
    },
    new() {
        Temperature = 52,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 1410,
        Humidity = 56
    },
    new() {
        Temperature = 12,
        AirQuality = 33,
        SensorLocation = "Company",
        Brightness = 1072,
        Humidity = 84
    },
    new() {
        Temperature = 54,
        AirQuality = 27,
        SensorLocation = "WareHourse",
        Brightness = 552,
        Humidity = 84
    },
    new() {
        Temperature = 67,
        AirQuality = 68,
        SensorLocation = "WareHourse",
        Brightness = 358,
        Humidity = 83
    },
    new() {
        Temperature = 86,
        AirQuality = 11,
        SensorLocation = "WareHourse",
        Brightness = 428,
        Humidity = 45
    },
    new() {
        Temperature = 36,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 322,
        Humidity = 95
    },
    new() {
        Temperature = 29,
        AirQuality = 98,
        SensorLocation = "WareHourse",
        Brightness = 422,
        Humidity = 54
    },
    new() {
        Temperature = 55,
        AirQuality = 81,
        SensorLocation = "Office",
        Brightness = 308,
        Humidity = 92
    },
    new() {
        Temperature = 31,
        AirQuality = 22,
        SensorLocation = "WareHourse",
        Brightness = 1177,
        Humidity = 33
    },
    new() {
        Temperature = 50,
        AirQuality = 43,
        SensorLocation = "Office",
        Brightness = 797,
        Humidity = 53
    },
    new() {
        Temperature = 44,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 648,
        Humidity = 41
    },
    new() {
        Temperature = 16,
        AirQuality = 26,
        SensorLocation = "Company",
        Brightness = 949,
        Humidity = 83
    },
    new() {
        Temperature = 35,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 818,
        Humidity = 87
    },
    new() {
        Temperature = 43,
        AirQuality = 14,
        SensorLocation = "WareHourse",
        Brightness = 948,
        Humidity = 94
    },
    new() {
        Temperature = 86,
        AirQuality = 12,
        SensorLocation = "WareHourse",
        Brightness = 176,
        Humidity = 84
    },
    new() {
        Temperature = 71,
        AirQuality = 70,
        SensorLocation = "Company",
        Brightness = 934,
        Humidity = 52
    },
    new() {
        Temperature = 84,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 379,
        Humidity = 58
    },
    new() {
        Temperature = 28,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 895,
        Humidity = 33
    },
    new() {
        Temperature = 65,
        AirQuality = 87,
        SensorLocation = "Office",
        Brightness = 941,
        Humidity = 41
    },
    new() {
        Temperature = 69,
        AirQuality = 93,
        SensorLocation = "WareHourse",
        Brightness = 1119,
        Humidity = 98
    },
    new() {
        Temperature = 20,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 1487,
        Humidity = 96
    },
    new() {
        Temperature = 77,
        AirQuality = 44,
        SensorLocation = "WareHourse",
        Brightness = 1355,
        Humidity = 93
    },
    new() {
        Temperature = 5,
        AirQuality = 75,
        SensorLocation = "Company",
        Brightness = 483,
        Humidity = 66
    },
    new() {
        Temperature = 5,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 1165,
        Humidity = 47
    },
    new() {
        Temperature = 40,
        AirQuality = 5,
        SensorLocation = "Company",
        Brightness = 380,
        Humidity = 66
    },
    new() {
        Temperature = 47,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 999,
        Humidity = 55
    },
    new() {
        Temperature = 18,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 561,
        Humidity = 39
    },
    new() {
        Temperature = 50,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 1248,
        Humidity = 32
    },
    new() {
        Temperature = 30,
        AirQuality = 31,
        SensorLocation = "Company",
        Brightness = 981,
        Humidity = 44
    },
    new() {
        Temperature = 42,
        AirQuality = 17,
        SensorLocation = "Office",
        Brightness = 417,
        Humidity = 32
    },
    new() {
        Temperature = 86,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1412,
        Humidity = 42
    },
    new() {
        Temperature = 69,
        AirQuality = 52,
        SensorLocation = "Company",
        Brightness = 333,
        Humidity = 33
    },
    new() {
        Temperature = 31,
        AirQuality = 69,
        SensorLocation = "WareHourse",
        Brightness = 788,
        Humidity = 72
    },
    new() {
        Temperature = 38,
        AirQuality = 8,
        SensorLocation = "WareHourse",
        Brightness = 910,
        Humidity = 37
    },
    new() {
        Temperature = 95,
        AirQuality = 93,
        SensorLocation = "Company",
        Brightness = 1340,
        Humidity = 93
    },
    new() {
        Temperature = 88,
        AirQuality = 78,
        SensorLocation = "Company",
        Brightness = 1095,
        Humidity = 81
    },
    new() {
        Temperature = 61,
        AirQuality = 54,
        SensorLocation = "Office",
        Brightness = 495,
        Humidity = 92
    },
    new() {
        Temperature = 11,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 242,
        Humidity = 82
    },
    new() {
        Temperature = 45,
        AirQuality = 99,
        SensorLocation = "Company",
        Brightness = 1261,
        Humidity = 82
    },
    new() {
        Temperature = 31,
        AirQuality = 61,
        SensorLocation = "WareHourse",
        Brightness = 483,
        Humidity = 33
    },
    new() {
        Temperature = 17,
        AirQuality = 60,
        SensorLocation = "Office",
        Brightness = 737,
        Humidity = 81
    },
    new() {
        Temperature = 79,
        AirQuality = 23,
        SensorLocation = "WareHourse",
        Brightness = 1193,
        Humidity = 91
    },
    new() {
        Temperature = 84,
        AirQuality = 78,
        SensorLocation = "WareHourse",
        Brightness = 994,
        Humidity = 64
    },
    new() {
        Temperature = 51,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 1459,
        Humidity = 49
    },
    new() {
        Temperature = 66,
        AirQuality = 92,
        SensorLocation = "Office",
        Brightness = 570,
        Humidity = 81
    },
    new() {
        Temperature = 51,
        AirQuality = 99,
        SensorLocation = "WareHourse",
        Brightness = 1292,
        Humidity = 54
    },
    new() {
        Temperature = 56,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 1420,
        Humidity = 79
    },
    new() {
        Temperature = 14,
        AirQuality = 68,
        SensorLocation = "WareHourse",
        Brightness = 404,
        Humidity = 49
    },
    new() {
        Temperature = 48,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 796,
        Humidity = 65
    },
    new() {
        Temperature = 80,
        AirQuality = 4,
        SensorLocation = "Company",
        Brightness = 625,
        Humidity = 59
    },
    new() {
        Temperature = 48,
        AirQuality = 78,
        SensorLocation = "WareHourse",
        Brightness = 205,
        Humidity = 73
    },
    new() {
        Temperature = 36,
        AirQuality = 25,
        SensorLocation = "WareHourse",
        Brightness = 393,
        Humidity = 98
    },
    new() {
        Temperature = 21,
        AirQuality = 26,
        SensorLocation = "Company",
        Brightness = 941,
        Humidity = 60
    },
    new() {
        Temperature = 22,
        AirQuality = 16,
        SensorLocation = "Office",
        Brightness = 1055,
        Humidity = 52
    },
    new() {
        Temperature = 65,
        AirQuality = 64,
        SensorLocation = "Company",
        Brightness = 305,
        Humidity = 45
    },
    new() {
        Temperature = 91,
        AirQuality = 72,
        SensorLocation = "WareHourse",
        Brightness = 741,
        Humidity = 60
    },
    new() {
        Temperature = 94,
        AirQuality = 3,
        SensorLocation = "Company",
        Brightness = 966,
        Humidity = 52
    },
    new() {
        Temperature = 21,
        AirQuality = 78,
        SensorLocation = "Company",
        Brightness = 1128,
        Humidity = 98
    },
    new() {
        Temperature = 70,
        AirQuality = 4,
        SensorLocation = "WareHourse",
        Brightness = 856,
        Humidity = 67
    },
    new() {
        Temperature = 94,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 1108,
        Humidity = 59
    },
    new() {
        Temperature = 82,
        AirQuality = 73,
        SensorLocation = "Company",
        Brightness = 352,
        Humidity = 31
    },
    new() {
        Temperature = 2,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 775,
        Humidity = 46
    },
    new() {
        Temperature = 93,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 846,
        Humidity = 63
    },
    new() {
        Temperature = 88,
        AirQuality = 25,
        SensorLocation = "Office",
        Brightness = 1021,
        Humidity = 43
    },
    new() {
        Temperature = 29,
        AirQuality = 3,
        SensorLocation = "Office",
        Brightness = 624,
        Humidity = 98
    },
    new() {
        Temperature = 55,
        AirQuality = 90,
        SensorLocation = "Office",
        Brightness = 254,
        Humidity = 48
    },
    new() {
        Temperature = 35,
        AirQuality = 48,
        SensorLocation = "Company",
        Brightness = 1100,
        Humidity = 86
    },
    new() {
        Temperature = 83,
        AirQuality = 78,
        SensorLocation = "Office",
        Brightness = 866,
        Humidity = 75
    },
    new() {
        Temperature = 10,
        AirQuality = 72,
        SensorLocation = "Company",
        Brightness = 689,
        Humidity = 61
    },
    new() {
        Temperature = 90,
        AirQuality = 54,
        SensorLocation = "Office",
        Brightness = 144,
        Humidity = 42
    },
    new() {
        Temperature = 68,
        AirQuality = 34,
        SensorLocation = "Office",
        Brightness = 1020,
        Humidity = 69
    },
    new() {
        Temperature = 56,
        AirQuality = 32,
        SensorLocation = "Office",
        Brightness = 644,
        Humidity = 92
    },
    new() {
        Temperature = 25,
        AirQuality = 36,
        SensorLocation = "WareHourse",
        Brightness = 194,
        Humidity = 45
    },
    new() {
        Temperature = 34,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 1490,
        Humidity = 63
    },
    new() {
        Temperature = 5,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 1037,
        Humidity = 80
    },
    new() {
        Temperature = 85,
        AirQuality = 59,
        SensorLocation = "WareHourse",
        Brightness = 1231,
        Humidity = 69
    },
    new() {
        Temperature = 25,
        AirQuality = 25,
        SensorLocation = "Office",
        Brightness = 992,
        Humidity = 91
    },
    new() {
        Temperature = 82,
        AirQuality = 95,
        SensorLocation = "WareHourse",
        Brightness = 188,
        Humidity = 32
    },
    new() {
        Temperature = 70,
        AirQuality = 75,
        SensorLocation = "WareHourse",
        Brightness = 567,
        Humidity = 37
    },
    new() {
        Temperature = 46,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1131,
        Humidity = 59
    },
    new() {
        Temperature = 20,
        AirQuality = 3,
        SensorLocation = "WareHourse",
        Brightness = 1220,
        Humidity = 31
    },
    new() {
        Temperature = 71,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1215,
        Humidity = 32
    },
    new() {
        Temperature = 11,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 640,
        Humidity = 72
    },
    new() {
        Temperature = 99,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 672,
        Humidity = 40
    },
    new() {
        Temperature = 20,
        AirQuality = 66,
        SensorLocation = "Office",
        Brightness = 621,
        Humidity = 55
    },
    new() {
        Temperature = 52,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 164,
        Humidity = 86
    },
    new() {
        Temperature = 12,
        AirQuality = 41,
        SensorLocation = "WareHourse",
        Brightness = 764,
        Humidity = 90
    },
    new() {
        Temperature = 70,
        AirQuality = 81,
        SensorLocation = "WareHourse",
        Brightness = 336,
        Humidity = 62
    },
    new() {
        Temperature = 18,
        AirQuality = 9,
        SensorLocation = "Company",
        Brightness = 299,
        Humidity = 86
    },
    new() {
        Temperature = 84,
        AirQuality = 60,
        SensorLocation = "Company",
        Brightness = 380,
        Humidity = 94
    },
    new() {
        Temperature = 95,
        AirQuality = 46,
        SensorLocation = "Company",
        Brightness = 1289,
        Humidity = 66
    },
    new() {
        Temperature = 19,
        AirQuality = 39,
        SensorLocation = "Company",
        Brightness = 375,
        Humidity = 52
    },
    new() {
        Temperature = 70,
        AirQuality = 80,
        SensorLocation = "Company",
        Brightness = 345,
        Humidity = 75
    },
    new() {
        Temperature = 88,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 958,
        Humidity = 76
    },
    new() {
        Temperature = 35,
        AirQuality = 61,
        SensorLocation = "Company",
        Brightness = 861,
        Humidity = 58
    },
    new() {
        Temperature = 98,
        AirQuality = 38,
        SensorLocation = "WareHourse",
        Brightness = 1492,
        Humidity = 98
    },
    new() {
        Temperature = 61,
        AirQuality = 52,
        SensorLocation = "Office",
        Brightness = 1192,
        Humidity = 99
    },
    new() {
        Temperature = 27,
        AirQuality = 54,
        SensorLocation = "WareHourse",
        Brightness = 241,
        Humidity = 38
    },
    new() {
        Temperature = 83,
        AirQuality = 94,
        SensorLocation = "Office",
        Brightness = 1399,
        Humidity = 86
    },
    new() {
        Temperature = 97,
        AirQuality = 22,
        SensorLocation = "WareHourse",
        Brightness = 1433,
        Humidity = 91
    },
    new() {
        Temperature = 80,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 496,
        Humidity = 84
    },
    new() {
        Temperature = 69,
        AirQuality = 6,
        SensorLocation = "WareHourse",
        Brightness = 643,
        Humidity = 54
    },
    new() {
        Temperature = 30,
        AirQuality = 35,
        SensorLocation = "Office",
        Brightness = 690,
        Humidity = 44
    },
    new() {
        Temperature = 50,
        AirQuality = 67,
        SensorLocation = "Office",
        Brightness = 636,
        Humidity = 56
    },
    new() {
        Temperature = 26,
        AirQuality = 92,
        SensorLocation = "WareHourse",
        Brightness = 646,
        Humidity = 33
    },
    new() {
        Temperature = 47,
        AirQuality = 97,
        SensorLocation = "Company",
        Brightness = 917,
        Humidity = 73
    },
    new() {
        Temperature = 80,
        AirQuality = 87,
        SensorLocation = "Office",
        Brightness = 554,
        Humidity = 56
    },
    new() {
        Temperature = 42,
        AirQuality = 54,
        SensorLocation = "Company",
        Brightness = 1354,
        Humidity = 32
    },
    new() {
        Temperature = 63,
        AirQuality = 87,
        SensorLocation = "WareHourse",
        Brightness = 302,
        Humidity = 68
    },
    new() {
        Temperature = 22,
        AirQuality = 10,
        SensorLocation = "WareHourse",
        Brightness = 983,
        Humidity = 63
    },
    new() {
        Temperature = 10,
        AirQuality = 89,
        SensorLocation = "Office",
        Brightness = 1217,
        Humidity = 63
    },
    new() {
        Temperature = 68,
        AirQuality = 87,
        SensorLocation = "Office",
        Brightness = 1054,
        Humidity = 70
    },
    new() {
        Temperature = 82,
        AirQuality = 18,
        SensorLocation = "WareHourse",
        Brightness = 1495,
        Humidity = 62
    },
    new() {
        Temperature = 94,
        AirQuality = 4,
        SensorLocation = "WareHourse",
        Brightness = 129,
        Humidity = 76
    },
    new() {
        Temperature = 22,
        AirQuality = 94,
        SensorLocation = "Office",
        Brightness = 1304,
        Humidity = 50
    }
    ,
    new() {
        Temperature = 7,
        AirQuality = 88,
        SensorLocation = "Office",
        Brightness = 1413,
        Humidity = 54
    },
    new() {
        Temperature = 92,
        AirQuality = 47,
        SensorLocation = "WareHourse",
        Brightness = 1480,
        Humidity = 65
    },
    new() {
        Temperature = 81,
        AirQuality = 50,
        SensorLocation = "WareHourse",
        Brightness = 114,
        Humidity = 79
    },
    new() {
        Temperature = 9,
        AirQuality = 33,
        SensorLocation = "Office",
        Brightness = 683,
        Humidity = 63
    },
    new() {
        Temperature = 88,
        AirQuality = 78,
        SensorLocation = "WareHourse",
        Brightness = 1026,
        Humidity = 38
    },
    new() {
        Temperature = 9,
        AirQuality = 15,
        SensorLocation = "Office",
        Brightness = 1118,
        Humidity = 98
    },
    new() {
        Temperature = 11,
        AirQuality = 97,
        SensorLocation = "Office",
        Brightness = 418,
        Humidity = 99
    },
    new() {
        Temperature = 32,
        AirQuality = 84,
        SensorLocation = "WareHourse",
        Brightness = 443,
        Humidity = 32
    },
    new() {
        Temperature = 50,
        AirQuality = 88,
        SensorLocation = "Office",
        Brightness = 1116,
        Humidity = 86
    },
    new() {
        Temperature = 84,
        AirQuality = 1,
        SensorLocation = "Office",
        Brightness = 360,
        Humidity = 74
    },
    new() {
        Temperature = 46,
        AirQuality = 77,
        SensorLocation = "WareHourse",
        Brightness = 161,
        Humidity = 54
    },
    new() {
        Temperature = 63,
        AirQuality = 54,
        SensorLocation = "Office",
        Brightness = 1081,
        Humidity = 100
    },
    new() {
        Temperature = 99,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 122,
        Humidity = 45
    },
    new() {
        Temperature = 88,
        AirQuality = 29,
        SensorLocation = "Office",
        Brightness = 1295,
        Humidity = 62
    },
    new() {
        Temperature = 57,
        AirQuality = 92,
        SensorLocation = "Office",
        Brightness = 756,
        Humidity = 80
    },
    new() {
        Temperature = 33,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 1294,
        Humidity = 74
    },
    new() {
        Temperature = 18,
        AirQuality = 71,
        SensorLocation = "Company",
        Brightness = 1071,
        Humidity = 49
    },
    new() {
        Temperature = 30,
        AirQuality = 23,
        SensorLocation = "Office",
        Brightness = 1447,
        Humidity = 58
    },
    new() {
        Temperature = 38,
        AirQuality = 54,
        SensorLocation = "WareHourse",
        Brightness = 488,
        Humidity = 52
    },
    new() {
        Temperature = 43,
        AirQuality = 39,
        SensorLocation = "Company",
        Brightness = 944,
        Humidity = 80
    },
    new() {
        Temperature = 36,
        AirQuality = 94,
        SensorLocation = "Company",
        Brightness = 712,
        Humidity = 87
    },
    new() {
        Temperature = 65,
        AirQuality = 86,
        SensorLocation = "WareHourse",
        Brightness = 1112,
        Humidity = 53
    },
    new() {
        Temperature = 39,
        AirQuality = 63,
        SensorLocation = "WareHourse",
        Brightness = 1009,
        Humidity = 64
    },
    new() {
        Temperature = 91,
        AirQuality = 16,
        SensorLocation = "Company",
        Brightness = 1224,
        Humidity = 55
    },
    new() {
        Temperature = 55,
        AirQuality = 75,
        SensorLocation = "WareHourse",
        Brightness = 649,
        Humidity = 62
    },
    new() {
        Temperature = 41,
        AirQuality = 5,
        SensorLocation = "WareHourse",
        Brightness = 117,
        Humidity = 68
    },
    new() {
        Temperature = 95,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 668,
        Humidity = 34
    },
    new() {
        Temperature = 54,
        AirQuality = 53,
        SensorLocation = "WareHourse",
        Brightness = 573,
        Humidity = 60
    },
    new() {
        Temperature = 84,
        AirQuality = 85,
        SensorLocation = "WareHourse",
        Brightness = 487,
        Humidity = 87
    },
    new() {
        Temperature = 37,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 140,
        Humidity = 39
    },
    new() {
        Temperature = 52,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 540,
        Humidity = 39
    },
    new() {
        Temperature = 15,
        AirQuality = 8,
        SensorLocation = "WareHourse",
        Brightness = 454,
        Humidity = 48
    },
    new() {
        Temperature = 40,
        AirQuality = 75,
        SensorLocation = "Office",
        Brightness = 1352,
        Humidity = 44
    },
    new() {
        Temperature = 37,
        AirQuality = 58,
        SensorLocation = "Company",
        Brightness = 1034,
        Humidity = 38
    },
    new() {
        Temperature = 43,
        AirQuality = 71,
        SensorLocation = "Office",
        Brightness = 453,
        Humidity = 76
    },
    new() {
        Temperature = 21,
        AirQuality = 67,
        SensorLocation = "WareHourse",
        Brightness = 640,
        Humidity = 58
    },
    new() {
        Temperature = 99,
        AirQuality = 85,
        SensorLocation = "Company",
        Brightness = 594,
        Humidity = 94
    },
    new() {
        Temperature = 28,
        AirQuality = 6,
        SensorLocation = "Office",
        Brightness = 942,
        Humidity = 38
    },
    new() {
        Temperature = 86,
        AirQuality = 24,
        SensorLocation = "Company",
        Brightness = 647,
        Humidity = 36
    },
    new() {
        Temperature = 2,
        AirQuality = 23,
        SensorLocation = "Office",
        Brightness = 1122,
        Humidity = 73
    },
    new() {
        Temperature = 11,
        AirQuality = 95,
        SensorLocation = "Office",
        Brightness = 1280,
        Humidity = 52
    },
    new() {
        Temperature = 78,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 1228,
        Humidity = 57
    },
    new() {
        Temperature = 34,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 1190,
        Humidity = 65
    },
    new() {
        Temperature = 99,
        AirQuality = 14,
        SensorLocation = "Company",
        Brightness = 983,
        Humidity = 68
    },
    new() {
        Temperature = 75,
        AirQuality = 76,
        SensorLocation = "Office",
        Brightness = 724,
        Humidity = 85
    },
    new() {
        Temperature = 34,
        AirQuality = 25,
        SensorLocation = "WareHourse",
        Brightness = 572,
        Humidity = 88
    },
    new() {
        Temperature = 43,
        AirQuality = 11,
        SensorLocation = "Office",
        Brightness = 1268,
        Humidity = 36
    },
    new() {
        Temperature = 41,
        AirQuality = 48,
        SensorLocation = "Company",
        Brightness = 538,
        Humidity = 60
    },
    new() {
        Temperature = 15,
        AirQuality = 17,
        SensorLocation = "Office",
        Brightness = 781,
        Humidity = 75
    },
    new() {
        Temperature = 80,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 522,
        Humidity = 44
    },
    new() {
        Temperature = 32,
        AirQuality = 75,
        SensorLocation = "WareHourse",
        Brightness = 788,
        Humidity = 81
    },
    new() {
        Temperature = 48,
        AirQuality = 73,
        SensorLocation = "WareHourse",
        Brightness = 194,
        Humidity = 93
    },
    new() {
        Temperature = 13,
        AirQuality = 7,
        SensorLocation = "WareHourse",
        Brightness = 1356,
        Humidity = 92
    },
    new() {
        Temperature = 28,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 751,
        Humidity = 94
    },
    new() {
        Temperature = 62,
        AirQuality = 97,
        SensorLocation = "WareHourse",
        Brightness = 698,
        Humidity = 70
    },
    new() {
        Temperature = 33,
        AirQuality = 66,
        SensorLocation = "Office",
        Brightness = 1085,
        Humidity = 77
    },
    new() {
        Temperature = 73,
        AirQuality = 80,
        SensorLocation = "Company",
        Brightness = 344,
        Humidity = 47
    },
    new() {
        Temperature = 38,
        AirQuality = 45,
        SensorLocation = "WareHourse",
        Brightness = 1100,
        Humidity = 75
    },
    new() {
        Temperature = 87,
        AirQuality = 57,
        SensorLocation = "WareHourse",
        Brightness = 1210,
        Humidity = 62
    },
    new() {
        Temperature = 83,
        AirQuality = 10,
        SensorLocation = "Company",
        Brightness = 931,
        Humidity = 63
    },
    new() {
        Temperature = 97,
        AirQuality = 17,
        SensorLocation = "Office",
        Brightness = 631,
        Humidity = 63
    },
    new() {
        Temperature = 34,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 795,
        Humidity = 50
    },
    new() {
        Temperature = 2,
        AirQuality = 52,
        SensorLocation = "Company",
        Brightness = 727,
        Humidity = 76
    },
    new() {
        Temperature = 25,
        AirQuality = 38,
        SensorLocation = "Company",
        Brightness = 605,
        Humidity = 46
    },
    new() {
        Temperature = 80,
        AirQuality = 74,
        SensorLocation = "WareHourse",
        Brightness = 602,
        Humidity = 81
    },
    new() {
        Temperature = 2,
        AirQuality = 77,
        SensorLocation = "WareHourse",
        Brightness = 670,
        Humidity = 45
    },
    new() {
        Temperature = 10,
        AirQuality = 69,
        SensorLocation = "WareHourse",
        Brightness = 623,
        Humidity = 83
    },
    new() {
        Temperature = 39,
        AirQuality = 2,
        SensorLocation = "Office",
        Brightness = 369,
        Humidity = 61
    },
    new() {
        Temperature = 56,
        AirQuality = 41,
        SensorLocation = "WareHourse",
        Brightness = 1476,
        Humidity = 56
    },
    new() {
        Temperature = 51,
        AirQuality = 22,
        SensorLocation = "WareHourse",
        Brightness = 250,
        Humidity = 96
    },
    new() {
        Temperature = 70,
        AirQuality = 87,
        SensorLocation = "Office",
        Brightness = 885,
        Humidity = 36
    },
    new() {
        Temperature = 7,
        AirQuality = 15,
        SensorLocation = "Company",
        Brightness = 893,
        Humidity = 100
    },
    new() {
        Temperature = 66,
        AirQuality = 98,
        SensorLocation = "Company",
        Brightness = 130,
        Humidity = 59
    },
    new() {
        Temperature = 84,
        AirQuality = 100,
        SensorLocation = "Office",
        Brightness = 353,
        Humidity = 57
    },
    new() {
        Temperature = 1,
        AirQuality = 94,
        SensorLocation = "Office",
        Brightness = 1387,
        Humidity = 92
    },
    new() {
        Temperature = 65,
        AirQuality = 87,
        SensorLocation = "WareHourse",
        Brightness = 1001,
        Humidity = 83
    },
    new() {
        Temperature = 84,
        AirQuality = 32,
        SensorLocation = "WareHourse",
        Brightness = 1177,
        Humidity = 81
    },
    new() {
        Temperature = 67,
        AirQuality = 9,
        SensorLocation = "Company",
        Brightness = 476,
        Humidity = 52
    },
    new() {
        Temperature = 13,
        AirQuality = 45,
        SensorLocation = "Company",
        Brightness = 455,
        Humidity = 78
    },
    new() {
        Temperature = 84,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 920,
        Humidity = 50
    },
    new() {
        Temperature = 61,
        AirQuality = 74,
        SensorLocation = "WareHourse",
        Brightness = 1098,
        Humidity = 37
    },
    new() {
        Temperature = 92,
        AirQuality = 5,
        SensorLocation = "Company",
        Brightness = 149,
        Humidity = 98
    },
    new() {
        Temperature = 98,
        AirQuality = 95,
        SensorLocation = "Company",
        Brightness = 1268,
        Humidity = 72
    },
    new() {
        Temperature = 63,
        AirQuality = 5,
        SensorLocation = "Office",
        Brightness = 1007,
        Humidity = 58
    },
    new() {
        Temperature = 68,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 652,
        Humidity = 100
    },
    new() {
        Temperature = 91,
        AirQuality = 58,
        SensorLocation = "Office",
        Brightness = 1405,
        Humidity = 52
    },
    new() {
        Temperature = 10,
        AirQuality = 89,
        SensorLocation = "WareHourse",
        Brightness = 608,
        Humidity = 80
    },
    new() {
        Temperature = 63,
        AirQuality = 31,
        SensorLocation = "Office",
        Brightness = 282,
        Humidity = 61
    },
    new() {
        Temperature = 37,
        AirQuality = 35,
        SensorLocation = "Company",
        Brightness = 715,
        Humidity = 86
    },
    new() {
        Temperature = 84,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 1434,
        Humidity = 44
    },
    new() {
        Temperature = 46,
        AirQuality = 12,
        SensorLocation = "Office",
        Brightness = 443,
        Humidity = 77
    },
    new() {
        Temperature = 52,
        AirQuality = 84,
        SensorLocation = "Office",
        Brightness = 442,
        Humidity = 99
    },
    new() {
        Temperature = 10,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 460,
        Humidity = 61
    },
    new() {
        Temperature = 20,
        AirQuality = 47,
        SensorLocation = "WareHourse",
        Brightness = 511,
        Humidity = 73
    },
    new() {
        Temperature = 65,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 1122,
        Humidity = 44
    },
    new() {
        Temperature = 80,
        AirQuality = 31,
        SensorLocation = "Office",
        Brightness = 1185,
        Humidity = 41
    },
    new() {
        Temperature = 53,
        AirQuality = 94,
        SensorLocation = "WareHourse",
        Brightness = 397,
        Humidity = 48
    },
    new() {
        Temperature = 97,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 150,
        Humidity = 51
    },
    new() {
        Temperature = 64,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 632,
        Humidity = 50
    },
    new() {
        Temperature = 40,
        AirQuality = 20,
        SensorLocation = "Company",
        Brightness = 227,
        Humidity = 82
    },
    new() {
        Temperature = 2,
        AirQuality = 81,
        SensorLocation = "Company",
        Brightness = 412,
        Humidity = 37
    },
    new() {
        Temperature = 68,
        AirQuality = 77,
        SensorLocation = "WareHourse",
        Brightness = 1397,
        Humidity = 84
    },
    new() {
        Temperature = 42,
        AirQuality = 36,
        SensorLocation = "WareHourse",
        Brightness = 1292,
        Humidity = 54
    },
    new() {
        Temperature = 81,
        AirQuality = 20,
        SensorLocation = "WareHourse",
        Brightness = 1303,
        Humidity = 88
    },
    new() {
        Temperature = 29,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 902,
        Humidity = 49
    },
    new() {
        Temperature = 30,
        AirQuality = 34,
        SensorLocation = "WareHourse",
        Brightness = 1417,
        Humidity = 52
    },
    new() {
        Temperature = 69,
        AirQuality = 21,
        SensorLocation = "Company",
        Brightness = 107,
        Humidity = 87
    },
    new() {
        Temperature = 31,
        AirQuality = 88,
        SensorLocation = "Company",
        Brightness = 228,
        Humidity = 65
    },
    new() {
        Temperature = 2,
        AirQuality = 29,
        SensorLocation = "WareHourse",
        Brightness = 1232,
        Humidity = 83
    },
    new() {
        Temperature = 86,
        AirQuality = 87,
        SensorLocation = "WareHourse",
        Brightness = 111,
        Humidity = 66
    },
    new() {
        Temperature = 28,
        AirQuality = 98,
        SensorLocation = "WareHourse",
        Brightness = 1444,
        Humidity = 58
    },
    new() {
        Temperature = 90,
        AirQuality = 39,
        SensorLocation = "Company",
        Brightness = 1047,
        Humidity = 92
    },
    new() {
        Temperature = 66,
        AirQuality = 31,
        SensorLocation = "Company",
        Brightness = 1347,
        Humidity = 44
    },
    new() {
        Temperature = 8,
        AirQuality = 12,
        SensorLocation = "WareHourse",
        Brightness = 1025,
        Humidity = 85
    },
    new() {
        Temperature = 27,
        AirQuality = 42,
        SensorLocation = "Office",
        Brightness = 526,
        Humidity = 79
    },
    new() {
        Temperature = 62,
        AirQuality = 68,
        SensorLocation = "WareHourse",
        Brightness = 373,
        Humidity = 100
    },
    new() {
        Temperature = 42,
        AirQuality = 33,
        SensorLocation = "WareHourse",
        Brightness = 1369,
        Humidity = 50
    },
    new() {
        Temperature = 44,
        AirQuality = 94,
        SensorLocation = "Company",
        Brightness = 1048,
        Humidity = 78
    },
    new() {
        Temperature = 7,
        AirQuality = 20,
        SensorLocation = "Company",
        Brightness = 1122,
        Humidity = 41
    },
    new() {
        Temperature = 41,
        AirQuality = 32,
        SensorLocation = "Office",
        Brightness = 1201,
        Humidity = 74
    },
    new() {
        Temperature = 15,
        AirQuality = 87,
        SensorLocation = "Office",
        Brightness = 1112,
        Humidity = 93
    },
    new() {
        Temperature = 54,
        AirQuality = 76,
        SensorLocation = "Office",
        Brightness = 1318,
        Humidity = 63
    },
    new() {
        Temperature = 91,
        AirQuality = 93,
        SensorLocation = "WareHourse",
        Brightness = 576,
        Humidity = 82
    },
    new() {
        Temperature = 26,
        AirQuality = 64,
        SensorLocation = "Office",
        Brightness = 598,
        Humidity = 92
    },
    new() {
        Temperature = 67,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 369,
        Humidity = 71
    },
    new() {
        Temperature = 17,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 185,
        Humidity = 61
    },
    new() {
        Temperature = 9,
        AirQuality = 32,
        SensorLocation = "WareHourse",
        Brightness = 1082,
        Humidity = 82
    },
    new() {
        Temperature = 71,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 871,
        Humidity = 57
    },
    new() {
        Temperature = 82,
        AirQuality = 77,
        SensorLocation = "Office",
        Brightness = 449,
        Humidity = 76
    },
    new() {
        Temperature = 95,
        AirQuality = 9,
        SensorLocation = "Company",
        Brightness = 221,
        Humidity = 56
    },
    new() {
        Temperature = 41,
        AirQuality = 15,
        SensorLocation = "Company",
        Brightness = 1411,
        Humidity = 68
    },
    new() {
        Temperature = 7,
        AirQuality = 62,
        SensorLocation = "WareHourse",
        Brightness = 274,
        Humidity = 100
    },
    new() {
        Temperature = 26,
        AirQuality = 78,
        SensorLocation = "Company",
        Brightness = 839,
        Humidity = 73
    },
    new() {
        Temperature = 37,
        AirQuality = 95,
        SensorLocation = "WareHourse",
        Brightness = 451,
        Humidity = 63
    },
    new() {
        Temperature = 90,
        AirQuality = 48,
        SensorLocation = "Company",
        Brightness = 1424,
        Humidity = 67
    },
    new() {
        Temperature = 83,
        AirQuality = 43,
        SensorLocation = "Office",
        Brightness = 282,
        Humidity = 49
    },
    new() {
        Temperature = 80,
        AirQuality = 20,
        SensorLocation = "WareHourse",
        Brightness = 890,
        Humidity = 80
    },
    new() {
        Temperature = 58,
        AirQuality = 92,
        SensorLocation = "Company",
        Brightness = 1291,
        Humidity = 45
    },
    new() {
        Temperature = 75,
        AirQuality = 37,
        SensorLocation = "Company",
        Brightness = 276,
        Humidity = 81
    },
    new() {
        Temperature = 93,
        AirQuality = 57,
        SensorLocation = "Office",
        Brightness = 381,
        Humidity = 89
    },
    new() {
        Temperature = 40,
        AirQuality = 5,
        SensorLocation = "Company",
        Brightness = 1214,
        Humidity = 55
    },
    new() {
        Temperature = 53,
        AirQuality = 27,
        SensorLocation = "Company",
        Brightness = 383,
        Humidity = 95
    },
    new() {
        Temperature = 13,
        AirQuality = 7,
        SensorLocation = "WareHourse",
        Brightness = 858,
        Humidity = 78
    },
    new() {
        Temperature = 21,
        AirQuality = 29,
        SensorLocation = "WareHourse",
        Brightness = 1498,
        Humidity = 83
    },
    new() {
        Temperature = 32,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 791,
        Humidity = 66
    },
    new() {
        Temperature = 11,
        AirQuality = 16,
        SensorLocation = "Office",
        Brightness = 306,
        Humidity = 90
    },
    new() {
        Temperature = 49,
        AirQuality = 80,
        SensorLocation = "Office",
        Brightness = 401,
        Humidity = 67
    },
    new() {
        Temperature = 50,
        AirQuality = 4,
        SensorLocation = "Company",
        Brightness = 674,
        Humidity = 42
    },
    new() {
        Temperature = 26,
        AirQuality = 73,
        SensorLocation = "WareHourse",
        Brightness = 1152,
        Humidity = 62
    },
    new() {
        Temperature = 81,
        AirQuality = 89,
        SensorLocation = "WareHourse",
        Brightness = 162,
        Humidity = 68
    },
    new() {
        Temperature = 86,
        AirQuality = 4,
        SensorLocation = "Company",
        Brightness = 607,
        Humidity = 81
    },
    new() {
        Temperature = 85,
        AirQuality = 12,
        SensorLocation = "Office",
        Brightness = 1482,
        Humidity = 52
    },
    new() {
        Temperature = 54,
        AirQuality = 11,
        SensorLocation = "Office",
        Brightness = 414,
        Humidity = 55
    },
    new() {
        Temperature = 27,
        AirQuality = 72,
        SensorLocation = "Company",
        Brightness = 1102,
        Humidity = 34
    },
    new() {
        Temperature = 24,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 1089,
        Humidity = 47
    },
    new() {
        Temperature = 62,
        AirQuality = 84,
        SensorLocation = "WareHourse",
        Brightness = 440,
        Humidity = 44
    },
    new() {
        Temperature = 18,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 805,
        Humidity = 65
    },
    new() {
        Temperature = 72,
        AirQuality = 40,
        SensorLocation = "Company",
        Brightness = 348,
        Humidity = 67
    },
    new() {
        Temperature = 54,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 959,
        Humidity = 52
    },
    new() {
        Temperature = 3,
        AirQuality = 80,
        SensorLocation = "Office",
        Brightness = 460,
        Humidity = 50
    },
    new() {
        Temperature = 76,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 677,
        Humidity = 66
    },
    new() {
        Temperature = 3,
        AirQuality = 82,
        SensorLocation = "WareHourse",
        Brightness = 747,
        Humidity = 44
    },
    new() {
        Temperature = 2,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 425,
        Humidity = 47
    },
    new() {
        Temperature = 15,
        AirQuality = 22,
        SensorLocation = "WareHourse",
        Brightness = 998,
        Humidity = 53
    },
    new() {
        Temperature = 6,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 1499,
        Humidity = 74
    },
    new() {
        Temperature = 60,
        AirQuality = 58,
        SensorLocation = "Office",
        Brightness = 648,
        Humidity = 87
    },
    new() {
        Temperature = 69,
        AirQuality = 88,
        SensorLocation = "Office",
        Brightness = 506,
        Humidity = 73
    },
    new() {
        Temperature = 12,
        AirQuality = 33,
        SensorLocation = "Company",
        Brightness = 279,
        Humidity = 72
    },
    new() {
        Temperature = 16,
        AirQuality = 70,
        SensorLocation = "Company",
        Brightness = 1322,
        Humidity = 87
    },
    new() {
        Temperature = 67,
        AirQuality = 21,
        SensorLocation = "WareHourse",
        Brightness = 942,
        Humidity = 82
    },
    new() {
        Temperature = 10,
        AirQuality = 93,
        SensorLocation = "Company",
        Brightness = 779,
        Humidity = 70
    },
    new() {
        Temperature = 11,
        AirQuality = 79,
        SensorLocation = "WareHourse",
        Brightness = 144,
        Humidity = 41
    },
    new() {
        Temperature = 63,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 1140,
        Humidity = 33
    },
    new() {
        Temperature = 2,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 1031,
        Humidity = 56
    },
    new() {
        Temperature = 2,
        AirQuality = 31,
        SensorLocation = "WareHourse",
        Brightness = 1385,
        Humidity = 58
    },
    new() {
        Temperature = 80,
        AirQuality = 10,
        SensorLocation = "Company",
        Brightness = 729,
        Humidity = 49
    },
    new() {
        Temperature = 49,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 216,
        Humidity = 49
    },
    new() {
        Temperature = 60,
        AirQuality = 52,
        SensorLocation = "Company",
        Brightness = 1497,
        Humidity = 51
    },
    new() {
        Temperature = 57,
        AirQuality = 68,
        SensorLocation = "WareHourse",
        Brightness = 1100,
        Humidity = 75
    },
    new() {
        Temperature = 74,
        AirQuality = 22,
        SensorLocation = "Company",
        Brightness = 409,
        Humidity = 33
    },
    new() {
        Temperature = 93,
        AirQuality = 52,
        SensorLocation = "WareHourse",
        Brightness = 1467,
        Humidity = 97
    },
    new() {
        Temperature = 70,
        AirQuality = 92,
        SensorLocation = "Company",
        Brightness = 690,
        Humidity = 53
    },
    new() {
        Temperature = 73,
        AirQuality = 18,
        SensorLocation = "Company",
        Brightness = 808,
        Humidity = 50
    },
    new() {
        Temperature = 24,
        AirQuality = 99,
        SensorLocation = "Office",
        Brightness = 656,
        Humidity = 75
    },
    new() {
        Temperature = 22,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 759,
        Humidity = 36
    },
    new() {
        Temperature = 64,
        AirQuality = 89,
        SensorLocation = "Office",
        Brightness = 681,
        Humidity = 57
    },
    new() {
        Temperature = 54,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 464,
        Humidity = 97
    },
    new() {
        Temperature = 64,
        AirQuality = 17,
        SensorLocation = "WareHourse",
        Brightness = 327,
        Humidity = 61
    },
    new() {
        Temperature = 46,
        AirQuality = 22,
        SensorLocation = "Office",
        Brightness = 391,
        Humidity = 74
    },
    new() {
        Temperature = 89,
        AirQuality = 49,
        SensorLocation = "WareHourse",
        Brightness = 190,
        Humidity = 92
    },
    new() {
        Temperature = 75,
        AirQuality = 74,
        SensorLocation = "Office",
        Brightness = 1377,
        Humidity = 77
    },
    new() {
        Temperature = 15,
        AirQuality = 22,
        SensorLocation = "Company",
        Brightness = 1225,
        Humidity = 63
    },
    new() {
        Temperature = 86,
        AirQuality = 55,
        SensorLocation = "Company",
        Brightness = 495,
        Humidity = 83
    },
    new() {
        Temperature = 40,
        AirQuality = 14,
        SensorLocation = "Company",
        Brightness = 1214,
        Humidity = 72
    },
    new() {
        Temperature = 88,
        AirQuality = 90,
        SensorLocation = "Office",
        Brightness = 1424,
        Humidity = 84
    },
    new() {
        Temperature = 98,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 838,
        Humidity = 40
    },
    new() {
        Temperature = 53,
        AirQuality = 28,
        SensorLocation = "Office",
        Brightness = 448,
        Humidity = 62
    },
    new() {
        Temperature = 16,
        AirQuality = 80,
        SensorLocation = "WareHourse",
        Brightness = 637,
        Humidity = 49
    },
    new() {
        Temperature = 70,
        AirQuality = 80,
        SensorLocation = "Company",
        Brightness = 132,
        Humidity = 67
    },
    new() {
        Temperature = 18,
        AirQuality = 27,
        SensorLocation = "Company",
        Brightness = 1149,
        Humidity = 91
    },
    new() {
        Temperature = 36,
        AirQuality = 97,
        SensorLocation = "Company",
        Brightness = 1068,
        Humidity = 62
    },
    new() {
        Temperature = 35,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 1293,
        Humidity = 84
    },
    new() {
        Temperature = 95,
        AirQuality = 88,
        SensorLocation = "Office",
        Brightness = 1349,
        Humidity = 77
    },
    new() {
        Temperature = 18,
        AirQuality = 86,
        SensorLocation = "WareHourse",
        Brightness = 713,
        Humidity = 54
    },
    new() {
        Temperature = 71,
        AirQuality = 47,
        SensorLocation = "Office",
        Brightness = 870,
        Humidity = 43
    },
    new() {
        Temperature = 44,
        AirQuality = 86,
        SensorLocation = "WareHourse",
        Brightness = 1240,
        Humidity = 69
    },
    new() {
        Temperature = 55,
        AirQuality = 20,
        SensorLocation = "WareHourse",
        Brightness = 1185,
        Humidity = 55
    },
    new() {
        Temperature = 38,
        AirQuality = 9,
        SensorLocation = "WareHourse",
        Brightness = 1020,
        Humidity = 100
    },
    new() {
        Temperature = 11,
        AirQuality = 95,
        SensorLocation = "WareHourse",
        Brightness = 1123,
        Humidity = 62
    },
    new() {
        Temperature = 4,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 521,
        Humidity = 94
    },
    new() {
        Temperature = 55,
        AirQuality = 39,
        SensorLocation = "Company",
        Brightness = 1282,
        Humidity = 31
    },
    new() {
        Temperature = 42,
        AirQuality = 75,
        SensorLocation = "WareHourse",
        Brightness = 801,
        Humidity = 39
    },
    new() {
        Temperature = 52,
        AirQuality = 6,
        SensorLocation = "WareHourse",
        Brightness = 562,
        Humidity = 76
    },
    new() {
        Temperature = 28,
        AirQuality = 17,
        SensorLocation = "Office",
        Brightness = 563,
        Humidity = 43
    },
    new() {
        Temperature = 40,
        AirQuality = 63,
        SensorLocation = "Office",
        Brightness = 1209,
        Humidity = 65
    },
    new() {
        Temperature = 26,
        AirQuality = 97,
        SensorLocation = "Company",
        Brightness = 519,
        Humidity = 32
    },
    new() {
        Temperature = 17,
        AirQuality = 26,
        SensorLocation = "WareHourse",
        Brightness = 1378,
        Humidity = 49
    },
    new() {
        Temperature = 62,
        AirQuality = 67,
        SensorLocation = "Office",
        Brightness = 794,
        Humidity = 95
    },
    new() {
        Temperature = 66,
        AirQuality = 43,
        SensorLocation = "Company",
        Brightness = 1244,
        Humidity = 62
    },
    new() {
        Temperature = 10,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 925,
        Humidity = 44
    },
    new() {
        Temperature = 68,
        AirQuality = 11,
        SensorLocation = "WareHourse",
        Brightness = 1281,
        Humidity = 98
    },
    new() {
        Temperature = 4,
        AirQuality = 8,
        SensorLocation = "Office",
        Brightness = 700,
        Humidity = 80
    },
    new() {
        Temperature = 11,
        AirQuality = 71,
        SensorLocation = "Company",
        Brightness = 450,
        Humidity = 52
    },
    new() {
        Temperature = 3,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 728,
        Humidity = 86
    },
    new() {
        Temperature = 86,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 737,
        Humidity = 61
    },
    new() {
        Temperature = 76,
        AirQuality = 84,
        SensorLocation = "WareHourse",
        Brightness = 868,
        Humidity = 49
    },
    new() {
        Temperature = 42,
        AirQuality = 91,
        SensorLocation = "Office",
        Brightness = 1031,
        Humidity = 75
    },
    new() {
        Temperature = 84,
        AirQuality = 80,
        SensorLocation = "Office",
        Brightness = 1250,
        Humidity = 83
    },
    new() {
        Temperature = 51,
        AirQuality = 41,
        SensorLocation = "Office",
        Brightness = 1199,
        Humidity = 30
    },
    new() {
        Temperature = 15,
        AirQuality = 4,
        SensorLocation = "Office",
        Brightness = 1375,
        Humidity = 62
    },
    new() {
        Temperature = 11,
        AirQuality = 16,
        SensorLocation = "Office",
        Brightness = 1114,
        Humidity = 75
    },
    new() {
        Temperature = 77,
        AirQuality = 5,
        SensorLocation = "Company",
        Brightness = 132,
        Humidity = 61
    },
    new() {
        Temperature = 83,
        AirQuality = 79,
        SensorLocation = "WareHourse",
        Brightness = 867,
        Humidity = 100
    },
    new() {
        Temperature = 16,
        AirQuality = 61,
        SensorLocation = "WareHourse",
        Brightness = 713,
        Humidity = 78
    },
    new() {
        Temperature = 14,
        AirQuality = 71,
        SensorLocation = "Office",
        Brightness = 1208,
        Humidity = 44
    },
    new() {
        Temperature = 6,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 969,
        Humidity = 92
    },
    new() {
        Temperature = 63,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 469,
        Humidity = 32
    },
    new() {
        Temperature = 99,
        AirQuality = 43,
        SensorLocation = "Office",
        Brightness = 302,
        Humidity = 45
    },
    new() {
        Temperature = 83,
        AirQuality = 77,
        SensorLocation = "WareHourse",
        Brightness = 1194,
        Humidity = 98
    },
    new() {
        Temperature = 43,
        AirQuality = 99,
        SensorLocation = "WareHourse",
        Brightness = 794,
        Humidity = 65
    },
    new() {
        Temperature = 35,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 1412,
        Humidity = 89
    },
    new() {
        Temperature = 51,
        AirQuality = 83,
        SensorLocation = "WareHourse",
        Brightness = 1194,
        Humidity = 36
    },
    new() {
        Temperature = 82,
        AirQuality = 14,
        SensorLocation = "Company",
        Brightness = 940,
        Humidity = 33
    },
    new() {
        Temperature = 21,
        AirQuality = 26,
        SensorLocation = "WareHourse",
        Brightness = 1408,
        Humidity = 90
    },
    new() {
        Temperature = 91,
        AirQuality = 87,
        SensorLocation = "WareHourse",
        Brightness = 1148,
        Humidity = 57
    },
    new() {
        Temperature = 11,
        AirQuality = 99,
        SensorLocation = "WareHourse",
        Brightness = 608,
        Humidity = 94
    },
    new() {
        Temperature = 35,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 662,
        Humidity = 35
    },
    new() {
        Temperature = 70,
        AirQuality = 92,
        SensorLocation = "Company",
        Brightness = 1181,
        Humidity = 76
    },
    new() {
        Temperature = 9,
        AirQuality = 14,
        SensorLocation = "Company",
        Brightness = 1055,
        Humidity = 53
    },
    new() {
        Temperature = 60,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 1011,
        Humidity = 79
    },
    new() {
        Temperature = 57,
        AirQuality = 58,
        SensorLocation = "WareHourse",
        Brightness = 314,
        Humidity = 39
    },
    new() {
        Temperature = 76,
        AirQuality = 27,
        SensorLocation = "WareHourse",
        Brightness = 1398,
        Humidity = 77
    },
    new() {
        Temperature = 17,
        AirQuality = 7,
        SensorLocation = "WareHourse",
        Brightness = 1305,
        Humidity = 83
    },
    new() {
        Temperature = 70,
        AirQuality = 80,
        SensorLocation = "WareHourse",
        Brightness = 1347,
        Humidity = 52
    },
    new() {
        Temperature = 18,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 192,
        Humidity = 90
    },
    new() {
        Temperature = 68,
        AirQuality = 87,
        SensorLocation = "Office",
        Brightness = 120,
        Humidity = 63
    },
    new() {
        Temperature = 96,
        AirQuality = 6,
        SensorLocation = "Company",
        Brightness = 1371,
        Humidity = 72
    },
    new() {
        Temperature = 66,
        AirQuality = 75,
        SensorLocation = "WareHourse",
        Brightness = 185,
        Humidity = 44
    },
    new() {
        Temperature = 31,
        AirQuality = 64,
        SensorLocation = "Company",
        Brightness = 110,
        Humidity = 98
    },
    new() {
        Temperature = 53,
        AirQuality = 45,
        SensorLocation = "Company",
        Brightness = 300,
        Humidity = 93
    },
    new() {
        Temperature = 14,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 227,
        Humidity = 36
    },
    new() {
        Temperature = 54,
        AirQuality = 11,
        SensorLocation = "Company",
        Brightness = 544,
        Humidity = 97
    },
    new() {
        Temperature = 39,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 271,
        Humidity = 64
    },
    new() {
        Temperature = 30,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 291,
        Humidity = 74
    },
    new() {
        Temperature = 94,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 281,
        Humidity = 44
    },
    new() {
        Temperature = 45,
        AirQuality = 80,
        SensorLocation = "WareHourse",
        Brightness = 966,
        Humidity = 74
    },
    new() {
        Temperature = 25,
        AirQuality = 45,
        SensorLocation = "Office",
        Brightness = 870,
        Humidity = 69
    },
    new() {
        Temperature = 87,
        AirQuality = 38,
        SensorLocation = "Company",
        Brightness = 1313,
        Humidity = 77
    },
    new() {
        Temperature = 55,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 1093,
        Humidity = 90
    },
    new() {
        Temperature = 17,
        AirQuality = 4,
        SensorLocation = "Company",
        Brightness = 419,
        Humidity = 32
    },
    new() {
        Temperature = 33,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 269,
        Humidity = 95
    },
    new() {
        Temperature = 72,
        AirQuality = 64,
        SensorLocation = "WareHourse",
        Brightness = 1382,
        Humidity = 75
    },
    new() {
        Temperature = 52,
        AirQuality = 27,
        SensorLocation = "Company",
        Brightness = 150,
        Humidity = 49
    },
    new() {
        Temperature = 80,
        AirQuality = 45,
        SensorLocation = "WareHourse",
        Brightness = 461,
        Humidity = 46
    },
    new() {
        Temperature = 18,
        AirQuality = 71,
        SensorLocation = "Office",
        Brightness = 941,
        Humidity = 69
    },
    new() {
        Temperature = 53,
        AirQuality = 46,
        SensorLocation = "Office",
        Brightness = 860,
        Humidity = 52
    },
    new() {
        Temperature = 11,
        AirQuality = 58,
        SensorLocation = "WareHourse",
        Brightness = 362,
        Humidity = 43
    },
    new() {
        Temperature = 40,
        AirQuality = 50,
        SensorLocation = "WareHourse",
        Brightness = 407,
        Humidity = 49
    },
    new() {
        Temperature = 48,
        AirQuality = 48,
        SensorLocation = "WareHourse",
        Brightness = 1380,
        Humidity = 31
    },
    new() {
        Temperature = 96,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 956,
        Humidity = 37
    },
    new() {
        Temperature = 40,
        AirQuality = 9,
        SensorLocation = "Office",
        Brightness = 668,
        Humidity = 49
    },
    new() {
        Temperature = 29,
        AirQuality = 73,
        SensorLocation = "WareHourse",
        Brightness = 596,
        Humidity = 85
    },
    new() {
        Temperature = 33,
        AirQuality = 46,
        SensorLocation = "Company",
        Brightness = 1314,
        Humidity = 70
    },
    new() {
        Temperature = 55,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 901,
        Humidity = 31
    },
    new() {
        Temperature = 70,
        AirQuality = 17,
        SensorLocation = "Office",
        Brightness = 102,
        Humidity = 33
    },
    new() {
        Temperature = 40,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 261,
        Humidity = 95
    },
    new() {
        Temperature = 59,
        AirQuality = 23,
        SensorLocation = "WareHourse",
        Brightness = 513,
        Humidity = 80
    },
    new() {
        Temperature = 49,
        AirQuality = 33,
        SensorLocation = "Office",
        Brightness = 703,
        Humidity = 63
    },
    new() {
        Temperature = 21,
        AirQuality = 100,
        SensorLocation = "Company",
        Brightness = 253,
        Humidity = 57
    },
    new() {
        Temperature = 53,
        AirQuality = 49,
        SensorLocation = "WareHourse",
        Brightness = 505,
        Humidity = 31
    },
    new() {
        Temperature = 31,
        AirQuality = 85,
        SensorLocation = "WareHourse",
        Brightness = 1087,
        Humidity = 35
    },
    new() {
        Temperature = 12,
        AirQuality = 40,
        SensorLocation = "WareHourse",
        Brightness = 1465,
        Humidity = 39
    },
    new() {
        Temperature = 17,
        AirQuality = 45,
        SensorLocation = "WareHourse",
        Brightness = 983,
        Humidity = 34
    },
    new() {
        Temperature = 37,
        AirQuality = 89,
        SensorLocation = "Office",
        Brightness = 1004,
        Humidity = 64
    },
    new() {
        Temperature = 71,
        AirQuality = 58,
        SensorLocation = "Office",
        Brightness = 1147,
        Humidity = 68
    },
    new() {
        Temperature = 49,
        AirQuality = 53,
        SensorLocation = "Office",
        Brightness = 955,
        Humidity = 42
    },
    new() {
        Temperature = 96,
        AirQuality = 38,
        SensorLocation = "Company",
        Brightness = 1053,
        Humidity = 72
    },
    new() {
        Temperature = 92,
        AirQuality = 29,
        SensorLocation = "Office",
        Brightness = 1240,
        Humidity = 80
    },
    new() {
        Temperature = 83,
        AirQuality = 88,
        SensorLocation = "Office",
        Brightness = 878,
        Humidity = 84
    },
    new() {
        Temperature = 70,
        AirQuality = 71,
        SensorLocation = "Office",
        Brightness = 1187,
        Humidity = 90
    },
    new() {
        Temperature = 92,
        AirQuality = 84,
        SensorLocation = "Company",
        Brightness = 472,
        Humidity = 94
    },
    new() {
        Temperature = 72,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 821,
        Humidity = 79
    },
    new() {
        Temperature = 81,
        AirQuality = 30,
        SensorLocation = "WareHourse",
        Brightness = 798,
        Humidity = 36
    },
    new() {
        Temperature = 27,
        AirQuality = 45,
        SensorLocation = "Office",
        Brightness = 933,
        Humidity = 53
    },
    new() {
        Temperature = 27,
        AirQuality = 29,
        SensorLocation = "Company",
        Brightness = 795,
        Humidity = 98
    },
    new() {
        Temperature = 14,
        AirQuality = 68,
        SensorLocation = "WareHourse",
        Brightness = 431,
        Humidity = 70
    },
    new() {
        Temperature = 63,
        AirQuality = 12,
        SensorLocation = "Office",
        Brightness = 206,
        Humidity = 92
    },
    new() {
        Temperature = 76,
        AirQuality = 24,
        SensorLocation = "Office",
        Brightness = 184,
        Humidity = 87
    },
    new() {
        Temperature = 3,
        AirQuality = 15,
        SensorLocation = "Company",
        Brightness = 492,
        Humidity = 69
    },
    new() {
        Temperature = 100,
        AirQuality = 85,
        SensorLocation = "WareHourse",
        Brightness = 1101,
        Humidity = 65
    },
    new() {
        Temperature = 18,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 700,
        Humidity = 48
    },
    new() {
        Temperature = 92,
        AirQuality = 10,
        SensorLocation = "Office",
        Brightness = 590,
        Humidity = 49
    },
    new() {
        Temperature = 20,
        AirQuality = 41,
        SensorLocation = "Company",
        Brightness = 1314,
        Humidity = 78
    },
    new() {
        Temperature = 60,
        AirQuality = 84,
        SensorLocation = "WareHourse",
        Brightness = 208,
        Humidity = 69
    },
    new() {
        Temperature = 23,
        AirQuality = 28,
        SensorLocation = "WareHourse",
        Brightness = 1334,
        Humidity = 65
    },
    new() {
        Temperature = 93,
        AirQuality = 59,
        SensorLocation = "Office",
        Brightness = 988,
        Humidity = 56
    },
    new() {
        Temperature = 8,
        AirQuality = 79,
        SensorLocation = "WareHourse",
        Brightness = 1077,
        Humidity = 78
    },
    new() {
        Temperature = 90,
        AirQuality = 25,
        SensorLocation = "Company",
        Brightness = 647,
        Humidity = 36
    },
    new() {
        Temperature = 62,
        AirQuality = 23,
        SensorLocation = "WareHourse",
        Brightness = 741,
        Humidity = 83
    },
    new() {
        Temperature = 3,
        AirQuality = 61,
        SensorLocation = "WareHourse",
        Brightness = 1098,
        Humidity = 32
    },
    new() {
        Temperature = 57,
        AirQuality = 33,
        SensorLocation = "Company",
        Brightness = 687,
        Humidity = 50
    },
    new() {
        Temperature = 46,
        AirQuality = 84,
        SensorLocation = "WareHourse",
        Brightness = 1013,
        Humidity = 98
    },
    new() {
        Temperature = 45,
        AirQuality = 75,
        SensorLocation = "Office",
        Brightness = 1200,
        Humidity = 53
    },
    new() {
        Temperature = 43,
        AirQuality = 49,
        SensorLocation = "Office",
        Brightness = 1437,
        Humidity = 60
    },
    new() {
        Temperature = 88,
        AirQuality = 91,
        SensorLocation = "Company",
        Brightness = 745,
        Humidity = 88
    },
    new() {
        Temperature = 81,
        AirQuality = 60,
        SensorLocation = "Company",
        Brightness = 846,
        Humidity = 40
    },
    new() {
        Temperature = 45,
        AirQuality = 70,
        SensorLocation = "WareHourse",
        Brightness = 1160,
        Humidity = 96
    },
    new() {
        Temperature = 8,
        AirQuality = 1,
        SensorLocation = "Office",
        Brightness = 380,
        Humidity = 77
    },
    new() {
        Temperature = 8,
        AirQuality = 97,
        SensorLocation = "Office",
        Brightness = 462,
        Humidity = 78
    },
    new() {
        Temperature = 51,
        AirQuality = 36,
        SensorLocation = "Company",
        Brightness = 817,
        Humidity = 86
    },
    new() {
        Temperature = 39,
        AirQuality = 13,
        SensorLocation = "WareHourse",
        Brightness = 591,
        Humidity = 84
    },
    new() {
        Temperature = 53,
        AirQuality = 14,
        SensorLocation = "Office",
        Brightness = 686,
        Humidity = 39
    },
    new() {
        Temperature = 26,
        AirQuality = 6,
        SensorLocation = "Office",
        Brightness = 701,
        Humidity = 35
    },
    new() {
        Temperature = 2,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 963,
        Humidity = 39
    },
    new() {
        Temperature = 32,
        AirQuality = 75,
        SensorLocation = "WareHourse",
        Brightness = 583,
        Humidity = 96
    },
    new() {
        Temperature = 67,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 1055,
        Humidity = 54
    },
    new() {
        Temperature = 7,
        AirQuality = 74,
        SensorLocation = "Company",
        Brightness = 1417,
        Humidity = 41
    },
    new() {
        Temperature = 5,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 1251,
        Humidity = 82
    },
    new() {
        Temperature = 50,
        AirQuality = 5,
        SensorLocation = "WareHourse",
        Brightness = 1166,
        Humidity = 43
    },
    new() {
        Temperature = 56,
        AirQuality = 89,
        SensorLocation = "Office",
        Brightness = 941,
        Humidity = 48
    },
    new() {
        Temperature = 11,
        AirQuality = 83,
        SensorLocation = "Office",
        Brightness = 1388,
        Humidity = 30
    },
    new() {
        Temperature = 44,
        AirQuality = 85,
        SensorLocation = "WareHourse",
        Brightness = 164,
        Humidity = 32
    },
    new() {
        Temperature = 65,
        AirQuality = 22,
        SensorLocation = "Company",
        Brightness = 1046,
        Humidity = 40
    },
    new() {
        Temperature = 11,
        AirQuality = 99,
        SensorLocation = "WareHourse",
        Brightness = 668,
        Humidity = 38
    },
    new() {
        Temperature = 89,
        AirQuality = 64,
        SensorLocation = "WareHourse",
        Brightness = 726,
        Humidity = 73
    },
    new() {
        Temperature = 30,
        AirQuality = 11,
        SensorLocation = "Office",
        Brightness = 349,
        Humidity = 42
    },
    new() {
        Temperature = 59,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 461,
        Humidity = 87
    },
    new() {
        Temperature = 59,
        AirQuality = 54,
        SensorLocation = "WareHourse",
        Brightness = 770,
        Humidity = 70
    },
    new() {
        Temperature = 67,
        AirQuality = 100,
        SensorLocation = "Office",
        Brightness = 642,
        Humidity = 58
    },
    new() {
        Temperature = 92,
        AirQuality = 76,
        SensorLocation = "WareHourse",
        Brightness = 736,
        Humidity = 67
    },
    new() {
        Temperature = 19,
        AirQuality = 39,
        SensorLocation = "WareHourse",
        Brightness = 819,
        Humidity = 53
    },
    new() {
        Temperature = 34,
        AirQuality = 82,
        SensorLocation = "Office",
        Brightness = 126,
        Humidity = 83
    },
    new() {
        Temperature = 7,
        AirQuality = 93,
        SensorLocation = "Office",
        Brightness = 873,
        Humidity = 52
    },
    new() {
        Temperature = 45,
        AirQuality = 37,
        SensorLocation = "WareHourse",
        Brightness = 773,
        Humidity = 95
    },
    new() {
        Temperature = 31,
        AirQuality = 89,
        SensorLocation = "Office",
        Brightness = 532,
        Humidity = 30
    },
    new() {
        Temperature = 92,
        AirQuality = 78,
        SensorLocation = "Company",
        Brightness = 312,
        Humidity = 64
    },
    new() {
        Temperature = 95,
        AirQuality = 78,
        SensorLocation = "Office",
        Brightness = 381,
        Humidity = 90
    },
    new() {
        Temperature = 17,
        AirQuality = 64,
        SensorLocation = "Office",
        Brightness = 699,
        Humidity = 83
    },
    new() {
        Temperature = 75,
        AirQuality = 79,
        SensorLocation = "WareHourse",
        Brightness = 826,
        Humidity = 80
    },
    new() {
        Temperature = 72,
        AirQuality = 78,
        SensorLocation = "WareHourse",
        Brightness = 755,
        Humidity = 31
    },
    new() {
        Temperature = 62,
        AirQuality = 31,
        SensorLocation = "WareHourse",
        Brightness = 687,
        Humidity = 89
    },
    new() {
        Temperature = 13,
        AirQuality = 14,
        SensorLocation = "Company",
        Brightness = 278,
        Humidity = 77
    },
    new() {
        Temperature = 36,
        AirQuality = 97,
        SensorLocation = "Company",
        Brightness = 1420,
        Humidity = 42
    },
    new() {
        Temperature = 87,
        AirQuality = 61,
        SensorLocation = "Office",
        Brightness = 997,
        Humidity = 77
    },
    new() {
        Temperature = 11,
        AirQuality = 19,
        SensorLocation = "Company",
        Brightness = 1457,
        Humidity = 37
    },
    new() {
        Temperature = 78,
        AirQuality = 93,
        SensorLocation = "WareHourse",
        Brightness = 354,
        Humidity = 80
    },
    new() {
        Temperature = 100,
        AirQuality = 6,
        SensorLocation = "Office",
        Brightness = 1166,
        Humidity = 37
    },
    new() {
        Temperature = 26,
        AirQuality = 43,
        SensorLocation = "WareHourse",
        Brightness = 1167,
        Humidity = 58
    },
    new() {
        Temperature = 43,
        AirQuality = 5,
        SensorLocation = "Office",
        Brightness = 696,
        Humidity = 43
    },
    new() {
        Temperature = 78,
        AirQuality = 72,
        SensorLocation = "WareHourse",
        Brightness = 1392,
        Humidity = 89
    },
    new() {
        Temperature = 58,
        AirQuality = 27,
        SensorLocation = "WareHourse",
        Brightness = 647,
        Humidity = 92
    },
    new() {
        Temperature = 71,
        AirQuality = 96,
        SensorLocation = "Company",
        Brightness = 1379,
        Humidity = 68
    },
    new() {
        Temperature = 63,
        AirQuality = 36,
        SensorLocation = "Office",
        Brightness = 248,
        Humidity = 58
    },
    new() {
        Temperature = 19,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 418,
        Humidity = 35
    },
    new() {
        Temperature = 44,
        AirQuality = 64,
        SensorLocation = "Company",
        Brightness = 302,
        Humidity = 62
    },
    new() {
        Temperature = 54,
        AirQuality = 97,
        SensorLocation = "Company",
        Brightness = 716,
        Humidity = 40
    },
    new() {
        Temperature = 75,
        AirQuality = 89,
        SensorLocation = "Company",
        Brightness = 512,
        Humidity = 74
    },
    new() {
        Temperature = 60,
        AirQuality = 36,
        SensorLocation = "Office",
        Brightness = 1355,
        Humidity = 79
    },
    new() {
        Temperature = 52,
        AirQuality = 86,
        SensorLocation = "Office",
        Brightness = 325,
        Humidity = 53
    },
    new() {
        Temperature = 49,
        AirQuality = 16,
        SensorLocation = "Office",
        Brightness = 1354,
        Humidity = 91
    },
    new() {
        Temperature = 94,
        AirQuality = 66,
        SensorLocation = "WareHourse",
        Brightness = 751,
        Humidity = 35
    },
    new() {
        Temperature = 78,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 380,
        Humidity = 53
    },
    new() {
        Temperature = 32,
        AirQuality = 62,
        SensorLocation = "Company",
        Brightness = 128,
        Humidity = 37
    },
    new() {
        Temperature = 94,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 203,
        Humidity = 56
    },
    new() {
        Temperature = 26,
        AirQuality = 16,
        SensorLocation = "WareHourse",
        Brightness = 846,
        Humidity = 58
    },
    new() {
        Temperature = 4,
        AirQuality = 53,
        SensorLocation = "Company",
        Brightness = 776,
        Humidity = 35
    },
    new() {
        Temperature = 19,
        AirQuality = 95,
        SensorLocation = "WareHourse",
        Brightness = 464,
        Humidity = 48
    },
    new() {
        Temperature = 43,
        AirQuality = 90,
        SensorLocation = "WareHourse",
        Brightness = 788,
        Humidity = 34
    },
    new() {
        Temperature = 15,
        AirQuality = 90,
        SensorLocation = "WareHourse",
        Brightness = 865,
        Humidity = 36
    },
    new() {
        Temperature = 8,
        AirQuality = 89,
        SensorLocation = "Office",
        Brightness = 1355,
        Humidity = 87
    },
    new() {
        Temperature = 63,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 100,
        Humidity = 39
    },
    new() {
        Temperature = 10,
        AirQuality = 50,
        SensorLocation = "Office",
        Brightness = 1293,
        Humidity = 83
    },
    new() {
        Temperature = 7,
        AirQuality = 96,
        SensorLocation = "WareHourse",
        Brightness = 796,
        Humidity = 54
    },
    new() {
        Temperature = 25,
        AirQuality = 65,
        SensorLocation = "WareHourse",
        Brightness = 650,
        Humidity = 97
    },
    new() {
        Temperature = 74,
        AirQuality = 43,
        SensorLocation = "Office",
        Brightness = 1179,
        Humidity = 60
    },
    new() {
        Temperature = 20,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 785,
        Humidity = 58
    },
    new() {
        Temperature = 9,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 396,
        Humidity = 82
    },
    new() {
        Temperature = 90,
        AirQuality = 19,
        SensorLocation = "WareHourse",
        Brightness = 1054,
        Humidity = 71
    },
    new() {
        Temperature = 60,
        AirQuality = 47,
        SensorLocation = "Company",
        Brightness = 594,
        Humidity = 88
    },
    new() {
        Temperature = 44,
        AirQuality = 79,
        SensorLocation = "Office",
        Brightness = 333,
        Humidity = 77
    },
    new() {
        Temperature = 96,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 445,
        Humidity = 70
    },
    new() {
        Temperature = 36,
        AirQuality = 4,
        SensorLocation = "WareHourse",
        Brightness = 1257,
        Humidity = 55
    },
    new() {
        Temperature = 7,
        AirQuality = 22,
        SensorLocation = "Company",
        Brightness = 517,
        Humidity = 91
    },
    new() {
        Temperature = 8,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 210,
        Humidity = 85
    },
    new() {
        Temperature = 44,
        AirQuality = 51,
        SensorLocation = "Office",
        Brightness = 1061,
        Humidity = 91
    },
    new() {
        Temperature = 53,
        AirQuality = 61,
        SensorLocation = "Company",
        Brightness = 358,
        Humidity = 37
    },
    new() {
        Temperature = 78,
        AirQuality = 70,
        SensorLocation = "Office",
        Brightness = 737,
        Humidity = 49
    },
    new() {
        Temperature = 19,
        AirQuality = 20,
        SensorLocation = "WareHourse",
        Brightness = 1266,
        Humidity = 51
    },
    new() {
        Temperature = 38,
        AirQuality = 24,
        SensorLocation = "Office",
        Brightness = 958,
        Humidity = 61
    },
    new() {
        Temperature = 23,
        AirQuality = 9,
        SensorLocation = "Company",
        Brightness = 778,
        Humidity = 98
    },
    new() {
        Temperature = 51,
        AirQuality = 90,
        SensorLocation = "Office",
        Brightness = 166,
        Humidity = 68
    },
    new() {
        Temperature = 9,
        AirQuality = 7,
        SensorLocation = "Company",
        Brightness = 1058,
        Humidity = 56
    },
    new() {
        Temperature = 1,
        AirQuality = 2,
        SensorLocation = "Company",
        Brightness = 1381,
        Humidity = 52
    },
    new() {
        Temperature = 6,
        AirQuality = 34,
        SensorLocation = "Company",
        Brightness = 1157,
        Humidity = 96
    },
    new() {
        Temperature = 79,
        AirQuality = 36,
        SensorLocation = "WareHourse",
        Brightness = 1240,
        Humidity = 90
    },
    new() {
        Temperature = 97,
        AirQuality = 69,
        SensorLocation = "Company",
        Brightness = 610,
        Humidity = 89
    },
    new() {
        Temperature = 86,
        AirQuality = 31,
        SensorLocation = "WareHourse",
        Brightness = 493,
        Humidity = 43
    },
    new() {
        Temperature = 19,
        AirQuality = 87,
        SensorLocation = "Company",
        Brightness = 906,
        Humidity = 95
    },
    new() {
        Temperature = 52,
        AirQuality = 65,
        SensorLocation = "Company",
        Brightness = 690,
        Humidity = 89
    },
    new() {
        Temperature = 66,
        AirQuality = 51,
        SensorLocation = "Company",
        Brightness = 1279,
        Humidity = 62
    },
    new() {
        Temperature = 6,
        AirQuality = 61,
        SensorLocation = "WareHourse",
        Brightness = 793,
        Humidity = 66
    },
    new() {
        Temperature = 81,
        AirQuality = 68,
        SensorLocation = "Company",
        Brightness = 970,
        Humidity = 31
    },
    new() {
        Temperature = 65,
        AirQuality = 94,
        SensorLocation = "Company",
        Brightness = 513,
        Humidity = 48
    },
    new() {
        Temperature = 91,
        AirQuality = 97,
        SensorLocation = "Office",
        Brightness = 380,
        Humidity = 79
    },
    new() {
        Temperature = 94,
        AirQuality = 21,
        SensorLocation = "Office",
        Brightness = 1335,
        Humidity = 74
    },
    new() {
        Temperature = 12,
        AirQuality = 44,
        SensorLocation = "Office",
        Brightness = 1254,
        Humidity = 39
    },
    new() {
        Temperature = 36,
        AirQuality = 11,
        SensorLocation = "Office",
        Brightness = 120,
        Humidity = 98
    },
    new() {
        Temperature = 71,
        AirQuality = 97,
        SensorLocation = "Company",
        Brightness = 1165,
        Humidity = 67
    },
    new() {
        Temperature = 73,
        AirQuality = 81,
        SensorLocation = "Company",
        Brightness = 1017,
        Humidity = 84
    },
    new() {
        Temperature = 10,
        AirQuality = 68,
        SensorLocation = "WareHourse",
        Brightness = 415,
        Humidity = 30
    },
    new() {
        Temperature = 84,
        AirQuality = 100,
        SensorLocation = "Office",
        Brightness = 1217,
        Humidity = 80
    },
    new() {
        Temperature = 26,
        AirQuality = 82,
        SensorLocation = "Company",
        Brightness = 1230,
        Humidity = 35
    },
    new() {
        Temperature = 65,
        AirQuality = 48,
        SensorLocation = "Office",
        Brightness = 273,
        Humidity = 79
    },
    new() {
        Temperature = 64,
        AirQuality = 60,
        SensorLocation = "Office",
        Brightness = 1350,
        Humidity = 92
    },
    new() {
        Temperature = 31,
        AirQuality = 63,
        SensorLocation = "Company",
        Brightness = 282,
        Humidity = 37
    },
    new() {
        Temperature = 87,
        AirQuality = 62,
        SensorLocation = "Office",
        Brightness = 490,
        Humidity = 83
    },
    new() {
        Temperature = 54,
        AirQuality = 82,
        SensorLocation = "WareHourse",
        Brightness = 822,
        Humidity = 91
    },
    new() {
        Temperature = 65,
        AirQuality = 60,
        SensorLocation = "Company",
        Brightness = 1352,
        Humidity = 57
    },
    new() {
        Temperature = 49,
        AirQuality = 46,
        SensorLocation = "WareHourse",
        Brightness = 770,
        Humidity = 69
    },
    new() {
        Temperature = 89,
        AirQuality = 3,
        SensorLocation = "Office",
        Brightness = 1314,
        Humidity = 92
    },
    new() {
        Temperature = 85,
        AirQuality = 41,
        SensorLocation = "Office",
        Brightness = 225,
        Humidity = 32
    },
    new() {
        Temperature = 61,
        AirQuality = 38,
        SensorLocation = "Company",
        Brightness = 1288,
        Humidity = 76
    },
    new() {
        Temperature = 80,
        AirQuality = 92,
        SensorLocation = "WareHourse",
        Brightness = 679,
        Humidity = 52
    },
    new() {
        Temperature = 12,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 471,
        Humidity = 68
    },
    new() {
        Temperature = 1,
        AirQuality = 83,
        SensorLocation = "Company",
        Brightness = 994,
        Humidity = 83
    },
    new() {
        Temperature = 96,
        AirQuality = 49,
        SensorLocation = "Company",
        Brightness = 691,
        Humidity = 87
    },
    new() {
        Temperature = 93,
        AirQuality = 90,
        SensorLocation = "Office",
        Brightness = 190,
        Humidity = 82
    },
    new() {
        Temperature = 45,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 322,
        Humidity = 38
    },
    new() {
        Temperature = 2,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 1085,
        Humidity = 76
    },
    new() {
        Temperature = 95,
        AirQuality = 23,
        SensorLocation = "Company",
        Brightness = 511,
        Humidity = 47
    },
    new() {
        Temperature = 76,
        AirQuality = 19,
        SensorLocation = "Company",
        Brightness = 922,
        Humidity = 88
    },
    new() {
        Temperature = 21,
        AirQuality = 90,
        SensorLocation = "Company",
        Brightness = 280,
        Humidity = 31
    },
    new() {
        Temperature = 13,
        AirQuality = 75,
        SensorLocation = "WareHourse",
        Brightness = 472,
        Humidity = 65
    },
    new() {
        Temperature = 88,
        AirQuality = 18,
        SensorLocation = "Office",
        Brightness = 1268,
        Humidity = 65
    },
    new() {
        Temperature = 51,
        AirQuality = 60,
        SensorLocation = "WareHourse",
        Brightness = 661,
        Humidity = 90
    },
    new() {
        Temperature = 21,
        AirQuality = 8,
        SensorLocation = "Company",
        Brightness = 1108,
        Humidity = 46
    },
    new() {
        Temperature = 27,
        AirQuality = 4,
        SensorLocation = "WareHourse",
        Brightness = 1389,
        Humidity = 93
    },
    new() {
        Temperature = 16,
        AirQuality = 28,
        SensorLocation = "Office",
        Brightness = 525,
        Humidity = 92
    },
    new() {
        Temperature = 10,
        AirQuality = 65,
        SensorLocation = "WareHourse",
        Brightness = 729,
        Humidity = 35
    },
    new() {
        Temperature = 51,
        AirQuality = 36,
        SensorLocation = "WareHourse",
        Brightness = 1256,
        Humidity = 41
    },
    new() {
        Temperature = 73,
        AirQuality = 28,
        SensorLocation = "Office",
        Brightness = 918,
        Humidity = 55
    },
    new() {
        Temperature = 61,
        AirQuality = 69,
        SensorLocation = "Office",
        Brightness = 1181,
        Humidity = 96
    },
    new() {
        Temperature = 11,
        AirQuality = 27,
        SensorLocation = "WareHourse",
        Brightness = 612,
        Humidity = 56
    },
    new() {
        Temperature = 71,
        AirQuality = 78,
        SensorLocation = "Company",
        Brightness = 868,
        Humidity = 78
    },
    new() {
        Temperature = 27,
        AirQuality = 23,
        SensorLocation = "WareHourse",
        Brightness = 1233,
        Humidity = 43
    },
    new() {
        Temperature = 56,
        AirQuality = 33,
        SensorLocation = "Office",
        Brightness = 538,
        Humidity = 43
    },
    new() {
        Temperature = 27,
        AirQuality = 34,
        SensorLocation = "WareHourse",
        Brightness = 1009,
        Humidity = 67
    },
    new() {
        Temperature = 25,
        AirQuality = 37,
        SensorLocation = "Office",
        Brightness = 1036,
        Humidity = 41
    },
    new() {
        Temperature = 40,
        AirQuality = 48,
        SensorLocation = "Office",
        Brightness = 835,
        Humidity = 51
    },
    new() {
        Temperature = 19,
        AirQuality = 88,
        SensorLocation = "WareHourse",
        Brightness = 443,
        Humidity = 80
    },
    new() {
        Temperature = 53,
        AirQuality = 7,
        SensorLocation = "Office",
        Brightness = 694,
        Humidity = 42
    },
    new() {
        Temperature = 16,
        AirQuality = 13,
        SensorLocation = "Company",
        Brightness = 612,
        Humidity = 37
    },
    new() {
        Temperature = 27,
        AirQuality = 39,
        SensorLocation = "Company",
        Brightness = 202,
        Humidity = 49
    },
    new() {
        Temperature = 77,
        AirQuality = 59,
        SensorLocation = "Company",
        Brightness = 1328,
        Humidity = 32
    },
    new() {
        Temperature = 6,
        AirQuality = 10,
        SensorLocation = "WareHourse",
        Brightness = 1257,
        Humidity = 46
    },
    new() {
        Temperature = 28,
        AirQuality = 78,
        SensorLocation = "Office",
        Brightness = 718,
        Humidity = 86
    },
    new() {
        Temperature = 79,
        AirQuality = 33,
        SensorLocation = "Office",
        Brightness = 402,
        Humidity = 61
    },
    new() {
        Temperature = 26,
        AirQuality = 12,
        SensorLocation = "WareHourse",
        Brightness = 450,
        Humidity = 37
    },
    new() {
        Temperature = 5,
        AirQuality = 49,
        SensorLocation = "Office",
        Brightness = 150,
        Humidity = 47
    },
    new() {
        Temperature = 15,
        AirQuality = 99,
        SensorLocation = "WareHourse",
        Brightness = 1010,
        Humidity = 92
    },
    new() {
        Temperature = 10,
        AirQuality = 79,
        SensorLocation = "Company",
        Brightness = 1400,
        Humidity = 69
    },
    new() {
        Temperature = 72,
        AirQuality = 48,
        SensorLocation = "WareHourse",
        Brightness = 1293,
        Humidity = 44
    },
    new() {
        Temperature = 66,
        AirQuality = 86,
        SensorLocation = "WareHourse",
        Brightness = 499,
        Humidity = 99
    },
    new() {
        Temperature = 43,
        AirQuality = 38,
        SensorLocation = "Company",
        Brightness = 1123,
        Humidity = 83
    },
    new() {
        Temperature = 58,
        AirQuality = 47,
        SensorLocation = "WareHourse",
        Brightness = 667,
        Humidity = 47
    },
    new() {
        Temperature = 60,
        AirQuality = 73,
        SensorLocation = "WareHourse",
        Brightness = 531,
        Humidity = 89
    },
    new() {
        Temperature = 44,
        AirQuality = 55,
        SensorLocation = "WareHourse",
        Brightness = 878,
        Humidity = 87
    },
    new() {
        Temperature = 70,
        AirQuality = 51,
        SensorLocation = "Company",
        Brightness = 699,
        Humidity = 38
    },
    new() {
        Temperature = 35,
        AirQuality = 68,
        SensorLocation = "Office",
        Brightness = 374,
        Humidity = 72
    },
    new() {
        Temperature = 57,
        AirQuality = 99,
        SensorLocation = "Office",
        Brightness = 113,
        Humidity = 44
    },
    new() {
        Temperature = 36,
        AirQuality = 97,
        SensorLocation = "WareHourse",
        Brightness = 289,
        Humidity = 47
    },
    new() {
        Temperature = 85,
        AirQuality = 46,
        SensorLocation = "Office",
        Brightness = 1484,
        Humidity = 98
    },
    new() {
        Temperature = 34,
        AirQuality = 66,
        SensorLocation = "Company",
        Brightness = 979,
        Humidity = 66
    },
    new() {
        Temperature = 48,
        AirQuality = 86,
        SensorLocation = "Company",
        Brightness = 385,
        Humidity = 79
    },
    new() {
        Temperature = 76,
        AirQuality = 73,
        SensorLocation = "Office",
        Brightness = 303,
        Humidity = 73
    },
    new() {
        Temperature = 27,
        AirQuality = 20,
        SensorLocation = "WareHourse",
        Brightness = 910,
        Humidity = 83
    },
    new() {
        Temperature = 6,
        AirQuality = 37,
        SensorLocation = "WareHourse",
        Brightness = 583,
        Humidity = 50
    },
    new() {
        Temperature = 73,
        AirQuality = 9,
        SensorLocation = "Company",
        Brightness = 1392,
        Humidity = 91
    },
    new() {
        Temperature = 99,
        AirQuality = 30,
        SensorLocation = "Office",
        Brightness = 682,
        Humidity = 74
    },
    new() {
        Temperature = 5,
        AirQuality = 10,
        SensorLocation = "WareHourse",
        Brightness = 498,
        Humidity = 34
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
            new(){ Id="l1",Name="L1",Type="light",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="l2",Name="L2",Type="light",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="l3",Name="L3",Type="light",Status=false,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="l4",Name="L4",Type="light",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="l5",Name="L5",Type="light",Status=false,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="l6",Name="L6",Type="light",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="l7",Name="L7",Type="light",Status=true,ConnectionStatus=false,FarmId=farm.Id},
             new(){ Id="f1",Name="F1",Type="fan",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="f2",Name="F2",Type="fan",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="f3",Name="F3",Type="fan",Status=false,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="f4",Name="F4",Type="fan",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="f5",Name="F5",Type="fan",Status=false,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="f6",Name="F6",Type="fan",Status=true,ConnectionStatus=false,FarmId=farm.Id},
            new(){ Id="f7",Name="F7",Type="fan",Status=true,ConnectionStatus=false,FarmId=farm.Id},
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
