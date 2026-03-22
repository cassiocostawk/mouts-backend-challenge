namespace Ambev.DeveloperEvaluation.Application.Common
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Data { get; set; } = [];
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
