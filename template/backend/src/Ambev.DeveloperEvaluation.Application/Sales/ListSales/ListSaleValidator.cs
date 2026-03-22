using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales
{
    /// <summary>
    /// Validator for ListSaleCommand that defines validation rules for retrieving a list of sales based on specified criteria.
    /// </summary>
    public class ListSaleValidator : AbstractValidator<ListSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the ListSaleValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Filtering by sale number
        /// - Filtering by customer ID
        /// - Filtering by branch ID
        /// - Pagination
        /// </remarks>
        public ListSaleValidator() 
        {
            RuleFor(sales => sales.SaleNumber).Length(1, 20).When(sales => !string.IsNullOrEmpty(sales.SaleNumber));
            RuleFor(sales => sales.CustomerId).GreaterThan(0).When(sales => sales.CustomerId.HasValue);
            RuleFor(sales => sales.BranchId).GreaterThan(0).When(sales => sales.BranchId.HasValue);
            RuleFor(sales => sales.PageNumber).GreaterThan(0);
            RuleFor(sales => sales.PageSize).GreaterThan(0).LessThanOrEqualTo(100);
        }
    }
}
