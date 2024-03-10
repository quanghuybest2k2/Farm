namespace farm_api.Responses
{
    public class PagedFarmResponse<T>:FarmResponse<T> where T : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PagedFarmResponse(IEnumerable<T> values,int pageNumber, int pageSize):base(values)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
