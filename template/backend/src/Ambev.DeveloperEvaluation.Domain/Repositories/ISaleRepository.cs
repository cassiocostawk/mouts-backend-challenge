using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Sale entity operations
    /// </summary>
    public interface ISaleRepository
    {
        /// <summary>
        /// List the sales with pagination support
        /// </summary>
        /// <param name="pageNumber">The page number</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="order">The order by field and direction (optional)</param>
        /// <param name="saleNumber">The sale number filter (optional)</param>
        /// <param name="customerId">The customer ID filter (optional)</param>
        /// <param name="branchId">The branch ID filter (optional)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of sales</returns>
        Task<(IEnumerable<Sale> Data, int TotalCount)> GetListPaginatedAsync(
            int pageNumber, 
            int pageSize, 
            string? order, 
            string? saleNumber, 
            int? customerId, 
            int? branchId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a sale by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a new sale in the repository
        /// </summary>
        /// <param name="sale">The sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale</returns>
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update an existing sale in the repository
        /// </summary>
        /// <param name="sale">The sale to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated sale</returns>
        Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a sale by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale was deleted, false if not found</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a sale by its sale number
        /// </summary>
        /// <param name="saleNumber">The sale number of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        Task<Sale?> GetBySaleNumberAsync(string saleNumber, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the total count of sales
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The total count of sales</returns>
        Task<int> GetTotalCountAsync(CancellationToken cancellationToken = default);
    }
}
