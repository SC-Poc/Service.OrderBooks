using System;
using System.Collections.Generic;
using OrderBooks.Domain.Entities;

namespace OrderBooks.Domain.Handlers
{
    public interface IOrderBooksHandler
    {
        void HandleSell(string assetPairId, DateTime timestamp, IReadOnlyList<LimitOrder> limitOrders);

        void HandleBuy(string assetPairId, DateTime timestamp, IReadOnlyList<LimitOrder> limitOrders);
    }
}
