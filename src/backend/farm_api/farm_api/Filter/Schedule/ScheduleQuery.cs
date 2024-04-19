namespace farm_api.Filter.Schedule
{
    public class ScheduleQuery
    {
        public int Type { get; set; }
        public string Area { get; set; }
        public string AreaSensor { get; set; }
        public int Device { get; set; }
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public bool IsActive { get; set; }
    }
}
