using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Handler for processing CreateSaleCommand requests
    /// </summary>
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateSaleHandler
        /// </summary>
        /// <param name="saleRepository">The repository used to manage sales</param>
        /// <param name="mapper">The mapper used to map between domain and DTO objects</param>
        public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateSaleCommand request
        /// </summary>
        /// <param name="request">The CreateSaleCommand request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The created user details</returns>
        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingSale = await _saleRepository.GetBySaleNumberAsync(request.SaleNumber, cancellationToken);
            if (existingSale != null)
                throw new InvalidOperationException($"A sale with the number {request.SaleNumber} already exists.");

            var newSale = _mapper.Map<Domain.Entities.Sale>(request);
            var createdSale = await _saleRepository.CreateAsync(newSale, cancellationToken);

            return _mapper.Map<CreateSaleResult>(createdSale);
        }
    }
}
