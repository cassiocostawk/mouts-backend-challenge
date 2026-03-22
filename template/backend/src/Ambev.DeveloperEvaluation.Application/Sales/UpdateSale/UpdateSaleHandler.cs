using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Handler for processing UpdateSaleCommand requests
    /// </summary>
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of UpdateSaleHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="mapper">The mapper</param>
        public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var saleDB = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
            if (saleDB == null)
                throw new InvalidOperationException($"Sale not found");

            if (saleDB.SaleNumber != request.SaleNumber)
            {
                var existingSale = await _saleRepository.GetBySaleNumberAsync(request.SaleNumber, cancellationToken);
                if (existingSale != null)
                    throw new InvalidOperationException($"Sale with number {request.SaleNumber} already exists");
            }

            var updatedSale = _mapper.Map(request, saleDB);

            // Remove items that are not in the request
            var itemsToRemove = updatedSale.Items.Where(i => !request.Items.Any(ri => ri.Id == i.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                updatedSale.Items.Remove(item);
            }

            // Add or update items from the request
            foreach (var item in request.Items)
            {
                var existingItem = updatedSale.Items.FirstOrDefault(i => i.Id == item.Id);
                if (existingItem != null)
                {
                    _mapper.Map(item, existingItem);
                }
                else
                {
                    var newItem = _mapper.Map<SaleItem>(item);
                    updatedSale.Items.Add(newItem);
                }
            }

            await _saleRepository.UpdateAsync(updatedSale, cancellationToken);

            return _mapper.Map<UpdateSaleResult>(updatedSale);
        }
    }
}
