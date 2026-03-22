using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new sale in the database
        /// </summary>
        /// <param name="sale">The sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale</returns>
        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        /// <summary>
        /// Deletes a sale from the database
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sale = await GetByIdAsync(id, cancellationToken);
            if (sale == null)
                return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// List all sales from the database with pagination support
        /// </summary>
        /// <param name="pageNumber">The page number</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="order">The order by field and direction</param>
        /// <param name="saleNumber">The sale number filter</param>
        /// <param name="customerId">The customer ID filter</param>
        /// <param name="branchId">The branch ID filter</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of sales</returns>
        public async Task<(IEnumerable<Sale> Data, int TotalCount)> GetListPaginatedAsync(
            int pageNumber, 
            int pageSize, 
            string? order, 
            string? saleNumber, 
            int? customerId, 
            int? branchId,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Sales.AsQueryable();

            if (!string.IsNullOrEmpty(saleNumber))
                query = query.Where(s => s.SaleNumber.Contains(saleNumber));

            if (customerId.HasValue)
                query = query.Where(s => s.CustomerId == customerId.Value);

            if (branchId.HasValue)
                query = query.Where(s => s.BranchId == branchId.Value);

            if (!string.IsNullOrWhiteSpace(order))
            {
                var orderParts = order.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var property = typeof(Sale).GetProperty(
                    orderParts[0], 
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                var direction = orderParts.Length > 1 ? orderParts[1].ToLower() : "asc";

                if (property != null)
                {
                    query = direction == "desc" 
                        ? query.OrderByDescending(s => EF.Property<object>(s, property.Name)) 
                        : query.OrderBy(s => EF.Property<object>(s, property.Name));
                }
                else
                {
                    query = query.OrderByDescending(s => s.SaleDate);
                }
            }
            else 
            {
                query = query.OrderByDescending(s => s.SaleDate);
            }

            var sales = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync(cancellationToken); 

            var totalCount = await _context.Sales.CountAsync(cancellationToken);

            return (sales, totalCount);
        }

        /// <summary>
        /// Retrieves a sale by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        /// <summary>
        /// Retrieves a sale by its sale number
        /// </summary>
        /// <param name="saleNumber">The sale number of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        public async Task<Sale?> GetBySaleNumberAsync(string saleNumber, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.FirstOrDefaultAsync(s => s.SaleNumber == saleNumber, cancellationToken);
        }

        /// <summary>
        /// Updates an existing sale in the database
        /// </summary>
        /// <param name="sale">The sale to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated sale</returns>
        public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        /// <summary>
        /// Get the total count of sales
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The total count of sales</returns>
        public async Task<int> GetTotalCountAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Sales.CountAsync(cancellationToken);
        }
    }
}
