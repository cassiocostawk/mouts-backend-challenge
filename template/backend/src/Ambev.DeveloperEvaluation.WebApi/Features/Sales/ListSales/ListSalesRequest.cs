using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales
{
    /// <summary>
    /// Request model for getting sales.
    /// </summary>
    public class ListSalesRequest : PaginatedRequest
    {
        /// <summary>
        /// The sale number to filter by. (optional)
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// The unique identifier of the customer to filter by. (optional)
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// The unique identifier of the branch to filter by. (optional)
        /// </summary>
        public int? BranchId { get; set; }
    }
}
