namespace farm_api.Models.Request
{
    public class ScheduleRequest
    {
        public int Type { get; set; }
        public string Area { get; set; }
        public int Device { get; set; }
        public string AreaSensor { get; set; }
        public bool Status { get; set; }
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
