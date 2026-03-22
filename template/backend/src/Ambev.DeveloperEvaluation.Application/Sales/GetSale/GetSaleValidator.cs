using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Validator for GetSaleCommand
    /// </summary>
    public class GetSaleValidator : AbstractValidator<GetSaleCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetSaleCommand
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Sale ID must not be empty.
        /// </remarks>
        public GetSaleValidator()
        {
            RuleFor(sale => sale.Id)
                .NotEmpty()
                .WithMessage("Sale ID is required");
        }
    }
}
