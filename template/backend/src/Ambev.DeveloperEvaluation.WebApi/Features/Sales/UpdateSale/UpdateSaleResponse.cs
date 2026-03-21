using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// API response model for updating an existing sale
    /// </summary>
    public class UpdateSaleResponse
    {
        /// <summary>
        /// The unique identifier of the sale item.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The unique sale number for this transaction.
        /// </summary>
        public required string SaleNumber { get; set; }

        /// <summary>
        /// The date and time when the sale occurred.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// The total amount of the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The unique identifier of the customer associated with this sale.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// The unique identifier of the branch where this sale occurred.
        /// </summary>
        public int BranchId { get; set; }

        /// <summary>
        /// The list of items associated with this sale.
        /// </summary>
        public virtual List<SaleItemResponse> Items { get; set; } = [];
    }
}
