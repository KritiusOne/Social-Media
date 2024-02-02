namespace SocialMedia.Core.CustomEntities
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public bool hasPreviousPage => CurrentPage > 1;
        public bool hasNextPage => CurrentPage < TotalPage;
        public int? NextPageNumber => hasNextPage ? CurrentPage + 1 : (int?) null;
        public int? PreviousePageNumber => hasPreviousPage ? CurrentPage - 1 : (int?)null;
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PageCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        public static PagedList<T> CreatePagedList(IEnumerable<T> Source, int pageNumber, int pageSize)
        {
            var count = Source.Count();
            var items = Source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            var returnItems = items.ToList<T>();
            return new PagedList<T>(returnItems, count, pageNumber, pageSize);
        }
    }
}
