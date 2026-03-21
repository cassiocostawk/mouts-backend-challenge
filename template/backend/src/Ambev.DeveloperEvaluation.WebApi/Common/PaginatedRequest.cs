namespace Ambev.DeveloperEvaluation.WebApi.Common
{
    /// <summary>
    /// DTO for paginated requests, used to capture pagination parameters such as page number and page size.
    /// </summary>
    public class PaginatedRequest
    {
        /// <summary>
        /// The page number to retrieve. (optional)
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// The number of items per page. (optional)
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// The order in which to sort the items. (optional)
        /// Example: "SaleDate desc" or "TotalAmount asc"
        /// </summary>
        public string Order { get; set; } = string.Empty;
    }
}
