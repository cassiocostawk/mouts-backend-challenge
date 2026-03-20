using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Represents a request to create a new sale in the system.
    /// </summary>
    public class CreateSaleRequest
    {
        /// <summary>
        /// Gets or sets the unique sale number.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time when the sale occurred.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }

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
        public List<SaleItemRequest> Items { get; set; } = [];
    }
}
