namespace ServerService
{
    public class PagedFilterBase
    {
        const int maxPageSize = 1000;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 100;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}
