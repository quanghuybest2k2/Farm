using Environments = Core.Entities.Environment;
namespace farm_api.Ulities
{
    public static class MockDataGenerator
    {
        public static List<Environments> GenerateEnvironments(int numberOfDays, string sensorLocation)
        {
            var environments = new List<Environments>();
            var random = new Random();

            for (int day = 0; day < numberOfDays; day++)
            {
                var date = DateTime.Today.AddDays(-day);

                environments.Add(new Environments
                {
                    Temperature = random.Next(20, 35) + (float)random.NextDouble(), // Nhiệt độ từ 20 đến 35 độ C
                    SensorLocation = sensorLocation,
                    Humidity = random.Next(30, 80), // Độ ẩm từ 30% đến 80%
                    Brightness = random.Next(100, 1000), // Cường độ ánh sáng từ 100 đến 1000 lux
                    CreateAt = date,
                    UpdateAt = date.AddHours(random.Next(1, 24)) // Giả sử update sau vài giờ trong cùng ngày
                });
            }

            return environments;
        }
    }
}
