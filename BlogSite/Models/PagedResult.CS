namespace BlogSite.Models
{
    public class PagedResult<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        public PagedResult(List<T> items,int Count,int pageIndex, int pageSize, int pageCount)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(Count/ (double)pageSize);
            TotalCount = pageCount;
            this.AddRange(items);
        }
        public bool HasExitPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static PagedResult<T> Create(List<T> source, int pageIndex, int pageSize, int TotalCount) 
        { 
            var count = source.Count;
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PagedResult<T>(items, count, pageIndex, pageSize, TotalCount);
        }
    }
}
