using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Common
{
    /// <summary>
    /// Validator for UpdateSaleItemCommand that defines validation rules for sale item update command.
    /// </summary>
    public class UpdateSaleItemValidator : AbstractValidator<UpdateSaleItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateSaleItemValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Quantity must be greater than 0.
        /// - UnitPrice must be greater than 0.
        /// - Discount must be greater than 0.
        /// - TotalAmount must be greater than 0.
        /// - ProductId must be greater than 0.
        /// </remarks>
        public UpdateSaleItemValidator()
        {
            RuleFor(item => item.Quantity).GreaterThan(0);
            RuleFor(item => item.UnitPrice).GreaterThan(0);
            RuleFor(item => item.Discount).GreaterThan(0);
            RuleFor(item => item.TotalAmount).GreaterThan(0);
            RuleFor(item => item.ProductId).GreaterThan(0);
        }
    }
}
