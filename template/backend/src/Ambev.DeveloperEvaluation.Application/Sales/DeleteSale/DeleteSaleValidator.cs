using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Validator for DeleteSaleCommand
    /// </summary>
    public class DeleteSaleValidator : AbstractValidator<DeleteSaleCommand>
    {
        /// <summary>
        /// Initializes validation rules for DeleteSaleCommand
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Sale ID must not be empty.
        /// </remarks>
        public DeleteSaleValidator()
        {
            RuleFor(sale => sale.Id)
                .NotEmpty()
                .WithMessage("Sale ID is required");
        }
    }
}
