namespace farm_api.Responses
{
    public class FarmErrrorResponse
    {
        public string Type { get; set; }    
        public string Message { get; set; }
        public FarmErrrorResponse(string type, string message)
        {
            Type = type;
            Message = message;
        }
    }
}
