namespace farm_api.Responses
{
    public class FarmErrrorResponse
    {
        public string Type { get; set; }    
        public IEnumerable<string> Message { get; set; }
        public FarmErrrorResponse(string type, IEnumerable<string> message)
        {
            Type = type;
            Message = message;
        }
    }
}
