using Ambev.DeveloperEvaluation.Application.Sales.Common;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Validator for CreateSaleCommand that defines validation rules for sale creation command.
    /// </summary>
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - SaleNumber must not be empty and have a length between 1 and 20 characters.
        /// - SaleDate must be less than or equal to the current date and time.
        /// - CustomerId must be greater than 0.
        /// - BranchId must be greater than 0.
        /// - Each sale item must pass the CreateSaleItemValidator rules.
        /// </remarks>
        public CreateSaleValidator()
        {
            RuleFor(sale => sale.SaleNumber).NotEmpty().Length(1, 20);
            RuleFor(sale => sale.SaleDate).LessThanOrEqualTo(DateTime.UtcNow);
            RuleFor(sale => sale.CustomerId).GreaterThan(0);
            RuleFor(sale => sale.BranchId).GreaterThan(0);
            RuleForEach(sale => sale.Items).SetValidator(new CreateSaleItemValidator());
        }
    }
}
