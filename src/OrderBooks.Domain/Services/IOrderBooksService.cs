using System.Collections.Generic;
using OrderBooks.Domain.Entities;

namespace OrderBooks.Domain.Services
{
    public interface IOrderBooksService
    {
        IReadOnlyList<OrderBook> GetAll();

        OrderBook GetByAssetPairId(string assetPairId);

        void Update(OrderBook orderBook);
    }
}
