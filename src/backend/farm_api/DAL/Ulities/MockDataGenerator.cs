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
                var date = DateTime.Today.AddDays(-day);

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
                    }); ;
                }
            }

            return environments;
        }

    }
}
