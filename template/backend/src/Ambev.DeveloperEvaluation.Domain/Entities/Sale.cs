using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale transaction.
    /// This entity includes details about the sale such as the sale number, date, total amount, and associated items.
    /// </summary>
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique sale number for this transaction.
        /// </summary>
        public required string SaleNumber { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the sale occurred.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }

        //External Identities
        /// <summary>
        /// CustomerId represents the unique identifier of the customer associated with this sale.
        /// int based on External Identity and docs
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// BranchId represents the unique identifier of the branch where this sale occurred.
        /// int based on External Identity and docs
        /// </summary>
        public int BranchId { get; set; }

        /// <summary>
        /// Gets or sets the list of items associated with this sale.
        /// </summary>
        public virtual List<SaleItem> Items { get; set; } = [];
    }
}
