using Ambev.DeveloperEvaluation.Application.Sales.Common;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Validator for UpdateSaleCommand that defines validation rules for updating an existing sale.
    /// </summary>
    public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateSaleValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Sale ID must not be empty.
        /// - Sale number must not be empty and have a length between 1 and 20.
        /// - Sale date must be less than or equal to the current date and time.
        /// - Total amount must be greater than 0.
        /// - Customer ID must be greater than 0.
        /// - Branch ID must be greater than 0.
        /// - Each sale item must pass the UpdateSaleItemValidator rules.
        /// </remarks>
        public UpdateSaleValidator() 
        {
            RuleFor(sale => sale.Id)
                .NotEmpty()
                .WithMessage("Sale ID is required");

            RuleFor(sale => sale.SaleNumber).NotEmpty().Length(1, 20);
            RuleFor(sale => sale.SaleDate).LessThanOrEqualTo(DateTime.UtcNow);
            RuleFor(sale => sale.TotalAmount).GreaterThan(0);
            RuleFor(sale => sale.CustomerId).GreaterThan(0);
            RuleFor(sale => sale.BranchId).GreaterThan(0);
            RuleForEach(sale => sale.Items).SetValidator(new UpdateSaleItemValidator());
        }
    }
}
