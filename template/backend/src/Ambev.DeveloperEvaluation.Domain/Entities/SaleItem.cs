using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents an item in a sale transaction.
    /// This entity includes details about the item such as the quantity, unit price, discount, total amount, and associated sale.
    /// </summary>
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale associated with this item.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item in the sale.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the item in the sale.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the item in the sale.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the item in the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item in the sale is cancelled.
        /// </summary>
        public bool IsCancelled { get; set; }

        // External Identities
        /// <summary>
        /// Gets or sets the unique identifier of the product associated with this item.
        /// </summary>
        public int ProductId { get; set; }

        //Navigation Properties
        /// <summary>
        /// Gets or sets the sale associated with this item.
        /// </summary>
        public virtual Sale? Sale { get; set; }
    }
}
