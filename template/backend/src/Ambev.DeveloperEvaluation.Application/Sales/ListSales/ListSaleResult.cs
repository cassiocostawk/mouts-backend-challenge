namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales
{
    /// <summary>
    /// Response model for Getting a list of sales.
    /// </summary>
    public class ListSaleResult
    {
        /// <summary>
        /// The unique identifier of the sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The unique sale number for this transaction.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

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
    }
}
