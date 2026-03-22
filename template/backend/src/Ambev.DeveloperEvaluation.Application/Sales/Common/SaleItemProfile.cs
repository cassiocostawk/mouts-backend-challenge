using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Common
{
    /// <summary>
    /// Profile for mapping between SaleItem and SaleItemCommands/SaleItemResult
    /// </summary>
    public class SaleItemProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for SaleItem
        /// </summary>
        public SaleItemProfile()
        {
            CreateMap<CreateSaleItemCommand, SaleItem>();
            CreateMap<UpdateSaleItemCommand, SaleItem>();
            CreateMap<SaleItem, SaleItemResult>();
        }
    }
}
