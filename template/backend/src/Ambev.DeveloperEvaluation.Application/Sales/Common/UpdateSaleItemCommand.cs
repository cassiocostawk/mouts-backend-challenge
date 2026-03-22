namespace Ambev.DeveloperEvaluation.Application.Sales.Common
{
    /// <summary>
    /// DTO for updating items on a sale.
    /// </summary>
    /// <remarks>
    /// This DTO is used to transfer data when updating items in a sale.
    /// </remarks>
    public class UpdateSaleItemCommand
    {
        /// <summary>
        /// The unique identifier of the sale item being updated. 
        /// </summary>
        /// <remarks>
        /// Optional for new items being added to the sale, 
        /// but required for existing items that are being updated.
        /// </remarks>
        public Guid? Id { get; set; }

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
