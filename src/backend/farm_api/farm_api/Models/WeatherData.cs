using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace farm_api.Models
{
    #region Class Info
    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Tz_id { get; set; }
        public long Localtime_epoch { get; set; }
        public DateTime Localtime { get; set; }
        public override string ToString()
        {
            return $"location :{Environment.NewLine} Name: {Name} Region: {Region} Country: {Country} Lat : {Lat} Lon : {Lon} Tz_id :{Tz_id} localtime_epoch: {Localtime_epoch} localtime: {Localtime} ";
        }
    }

    public class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public int Code { get; set; }
        public override string ToString()
        {
            return $"Condition : {Environment.NewLine} Text : {Text} Icon :{Icon} Code :{Code}"; 
        }
    }

    public class Current
    {
        public long Last_updated_epoch { get; set; }
        public DateTime Last_updated { get; set; }
        public double Temp_c { get; set; }
        public double Temp_f { get; set; }
        public int Is_day { get; set; }
        public Condition Condition { get; set; }
        public double Wind_mph { get; set; }
        public double Wind_kph { get; set; }
        public int Wind_degree { get; set; }
        public string Wind_dir { get; set; }
        public int Pressure_mb { get; set; }
        public double Pressure_in { get; set; }
        public int Precip_mm { get; set; }
        public int Precip_in { get; set; }
        public int Humidity { get; set; }
        public int Cloud { get; set; }
        public double Feelslike_c { get; set; }
        public double Feelslike_f { get; set; }
        public int Vis_km { get; set; }
        public int Vis_miles { get; set; }
        public double Gust_mph { get; set; }
        public double Gust_kph { get; set; }
        public override string ToString()
        {
            return $"Current : {Environment.NewLine} Last_updated_epoch : {Last_updated_epoch} " +
                $"Last_updated :{Last_updated} Temp_c :{Temp_c}" +
                $"Temp_f : {Temp_f} Is_day :{Is_day} Condition :{Condition.ToString()}" +
                $"Wind_mph : {Wind_mph} Pressure_mb :{Pressure_mb} Pressure_in :{Pressure_in}" +
                $"Precip_mm : {Precip_mm} Precip_in :{Precip_in} Humidity :{Humidity}" +
                $"Cloud : {Cloud} Feelslike_c :{Feelslike_c} Feelslike_f :{Feelslike_f}" +
                $"Vis_km : {Vis_km} Vis_miles :{Vis_miles} Gust_mph :{Gust_kph}" +
                $"Gust_kph : {Gust_kph} ";
        }
    }

    public class WeatherData
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
        public override string ToString()
        {
            return $"WeatherData : {Environment.NewLine} Location :{Location.ToString()} Current: {Current.ToString()}";
        }
    }
    #endregion
}
