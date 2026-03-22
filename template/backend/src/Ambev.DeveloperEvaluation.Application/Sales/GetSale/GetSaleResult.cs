using Ambev.DeveloperEvaluation.Application.Sales.Common;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Response model for Sale.
    /// </summary>
    public class GetSaleResult
    {
        /// <summary>
        /// The unique identifier of the sale
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
        /// </summary>
        public int BranchId { get; set; }

        /// <summary>
        /// The list of items associated with this sale.
        /// </summary>
        public virtual List<SaleItemResult> Items { get; set; } = [];
    }
}
