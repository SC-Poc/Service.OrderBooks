using System.Collections.Generic;
using System.Threading.Tasks;
using OrderBooks.Client.Models.OrderBooks;

namespace OrderBooks.Client.Api
{
    /// <summary>
    /// Provides methods for work with order books API.
    /// </summary>
    public interface IOrderBookApi
    {
        /// <summary>
        /// Returns all order books.
        /// </summary>
        /// <returns>A collection of order books.</returns>
        Task<IReadOnlyList<OrderBookModel>> GetAllAsync();

        /// <summary>
        /// Returns an order book by asset pair identifier.
        /// </summary>
        /// <param name="assetPairId">The asset identifier.</param>
        /// <returns>Order book.</returns>
        Task<OrderBookModel> GetByAssetPairIdAsync(string assetPairId);
    }
}
