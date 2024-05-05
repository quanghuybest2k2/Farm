using System.Globalization;
using Environments = Core.Entities.Environment;
namespace farm_api.Ulities
{
    public static class MockDataGenerator
    {
        public static List<Environments> GenerateEnvironments(int numberOfDays, int recordsPerDay, string sensorLocation)
        {
            var environments = new List<Environments>();
            var random = new Random();

            for (int day = 0; day < numberOfDays; day++)
            {
                // Sử dụng ngày hiện tại trừ đi số ngày, chuyển đổi sang giờ Việt Nam
                var date = ConvertToVietnamTime(DateTime.SpecifyKind(DateTime.UtcNow.AddDays(-day), DateTimeKind.Utc));

                for (int record = 0; record < recordsPerDay; record++)
                {
                    var updateTime = date.AddHours(random.Next(0, 24)).AddMinutes(random.Next(0, 60));

                    environments.Add(new Environments
                    {
                        Temperature = random.Next(20, 35) + (float)random.NextDouble(), // Temperature from 20 to 35 degrees Celsius
                        SensorLocation = sensorLocation,
                        Humidity = random.Next(30, 80), // Humidity from 30% to 80%
                        Brightness = random.Next(100, 1000), // Brightness from 100 to 1000 lux
                        CreateAt = updateTime,
                        UpdateAt = updateTime
                    });
                }
            }

            return environments;
        }

        public static DateTime ConvertToVietnamTime(DateTime dateTime)
        {
            TimeZoneInfo vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, vnTimeZone);
        }
        public static DateTime ConvertToDateTime(string dateStr)
        {
            string[] formats = { "yyyy/M/d HH:mm:ss", "yyyy/MM/dd HH:mm:ss", "yyyy/MM/d HH:mm:ss", "yyyy/M/dd HH:mm:ss" };
            // Phân tích chuỗi ngày tháng với các định dạng linh hoạt và giả sử là UTC
            if (DateTime.TryParseExact(dateStr, "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                // Chỉ định rằng DateTime là UTC
                date = DateTime.SpecifyKind(date, DateTimeKind.Unspecified);
                return date;
            }
            return DateTime.MinValue;  // Trả về giá trị mặc định nếu parsing thất bại
        }

    }
}
