using Ambev.DeveloperEvaluation.Application.Sales.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Command for updating an existing sale.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for updating a sale,
    /// including sale number, sale date, total amount, customer ID, branch ID, 
    /// and the list of items associated with the sale.
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request
    /// that returns a <see cref="UpdateSaleResult"/>.
    /// 
    /// The data provided in this command is validated using the
    /// <see cref="UpdateSaleCommandValidator"/> which extends
    /// <see cref="AbstractValidator{UpdateSaleCommand}"/>. to ensure that the fields are correctly
    /// populated and follow the required rules.
    /// </remarks>
    public class UpdateSaleCommand : IRequest<UpdateSaleResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale to be updated.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique sale number.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time when the sale occurred.
        /// </summary>
        public DateTime SaleDate { get; set; }

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
        public List<UpdateSaleItemCommand> Items { get; set; } = [];
    }
}
