namespace farm_api.Responses
{
    public class PagedFarmResponse<T> : FarmResponse<T> where T : class
    {
        public int PageNumber
        {
            get { return PageIndex + 1; }
            set { PageIndex = value - 1; }
        }
        public int PageSize { get; set; }
        public int TotalPage
        {
            get
            {
                var totalpage = TotalItems / PageSize;
                if (PageSize % PageSize > 0)
                {
                    totalpage += 1;
                }
                return totalpage;
            }
        }
        public int TotalItems { get; private set; }
        public bool HasNextPage { get { return PageIndex < TotalPage - 1; } }
        public bool HasPreviousPage { get { return PageIndex > 0; } }
        public bool IsFirstPage { get { return PageIndex <= 0; } }
        public bool IsLastPage { get { return PageIndex >= (TotalPage - 1); } }
        public int PageIndex { get; private set; }
        public PagedFarmResponse(IEnumerable<T> values, int pageNumber, int pageSize, int totalItem) : base(values)
        {
            TotalItems = totalItem;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
