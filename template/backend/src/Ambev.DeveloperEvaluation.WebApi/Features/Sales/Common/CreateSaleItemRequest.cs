namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Common
{
    /// <summary>
    /// Request model for creating a SaleItem in the API.
    /// </summary>
    public class CreateSaleItemRequest
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
