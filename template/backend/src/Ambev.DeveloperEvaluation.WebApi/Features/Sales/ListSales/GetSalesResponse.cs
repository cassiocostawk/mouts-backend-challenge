namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales
{
    /// <summary>
    /// API response model for retrieving sales
    /// </summary>
    public class GetSalesResponse
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
    }
}
