namespace farm_api.Responses
{
    public class FarmResponse<T>where T : class
    {
        public  IEnumerable<T> Results { get; set; }
        public FarmResponse(IEnumerable<T> results)
        {
            Results = results;
        }   
    }
}
