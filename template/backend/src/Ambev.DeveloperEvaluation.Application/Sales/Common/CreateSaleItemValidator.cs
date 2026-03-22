using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Common
{
    /// <summary>
    /// Validator for CreateSaleItemCommand that defines validation rules for sale item creation command.
    /// </summary>
    public class CreateSaleItemValidator : AbstractValidator<CreateSaleItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleItemValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - ProductId must be greater than 0.
        /// - Quantity must be greater than 0.
        /// - UnitPrice must be greater than 0.
        /// - Discount must be greater than 0.
        /// - TotalAmount must be greater than 0.
        /// </remarks>
        public CreateSaleItemValidator()
        {
            RuleFor(item => item.Quantity).GreaterThan(0);
            RuleFor(item => item.UnitPrice).GreaterThan(0);
            RuleFor(item => item.Discount).GreaterThan(0);
            RuleFor(item => item.TotalAmount).GreaterThan(0);
            RuleFor(item => item.ProductId).GreaterThan(0);
        }
    }
}
