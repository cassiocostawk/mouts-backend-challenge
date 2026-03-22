using Ambev.DeveloperEvaluation.Application.Sales.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Common
{
    /// <summary>
    /// Profile for mapping between Application and API SaleItem requests and responses
    /// </summary>
    public class SaleItemProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for SaleItem related features
        /// </summary>
        public SaleItemProfile()
        {
            CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
            CreateMap<UpdateSaleItemRequest, UpdateSaleItemCommand>();
            CreateMap<SaleItemResult, SaleItemResponse>();
        }
    }
}
