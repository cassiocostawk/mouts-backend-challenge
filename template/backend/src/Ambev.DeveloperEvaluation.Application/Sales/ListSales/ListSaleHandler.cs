using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales
{
    /// <summary>
    /// Handler for processing ListSaleCommand requests
    /// </summary>
    public class ListSaleHandler : IRequestHandler<ListSaleCommand, PaginatedResult<ListSaleResult>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of ListSaleHandler
        /// </summary>
        /// <param name="saleRepository">The repository used to manage sales</param>
        /// <param name="mapper">The mapper used to map domain models to DTOs</param>
        public ListSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<ListSaleResult>> Handle(ListSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var (data, totalCount) = await _saleRepository.GetListPaginatedAsync(
                request.PageNumber,
                request.PageSize,
                request.Order,
                request.SaleNumber,
                request.CustomerId,
                request.BranchId,
                cancellationToken);

            return new PaginatedResult<ListSaleResult>
            {
                Data = _mapper.Map<IEnumerable<ListSaleResult>>(data),
                CurrentPage = request.PageNumber,
                TotalPages = (int)Math.Ceiling((double)totalCount / request.PageSize),
                TotalCount = totalCount,
            };
        }
    }
}