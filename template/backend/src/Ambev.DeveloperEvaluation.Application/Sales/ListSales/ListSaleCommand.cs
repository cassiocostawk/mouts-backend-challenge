using Ambev.DeveloperEvaluation.Application.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales
{
    /// <summary>
    /// Command for retrieving a list of sales.
    /// </summary>
    public class ListSaleCommand : PaginatedCommand, IRequest<PaginatedResult<ListSaleResult>>
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
