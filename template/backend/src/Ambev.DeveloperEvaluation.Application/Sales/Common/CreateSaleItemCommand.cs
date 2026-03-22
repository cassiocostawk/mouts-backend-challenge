namespace Ambev.DeveloperEvaluation.Application.Sales.Common
{
    /// <summary>
    /// DTO for updating items on a sale.
    /// </summary>
    /// <remarks>
    /// This DTO is used to transfer data when creating items in a sale.
    /// </remarks>
    public class CreateSaleItemCommand
    {
        /// <summary>
        /// The quantity of the item in the sale.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The unit price of the item in the sale.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Indicates whether the item in the sale is cancelled.
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// The unique identifier of the product associated with this item.
        /// </summary>
        public int ProductId { get; set; }
    }
}
