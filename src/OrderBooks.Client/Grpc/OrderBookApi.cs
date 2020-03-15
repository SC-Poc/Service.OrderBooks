using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using OrderBooks.Client.Api;
using OrderBooks.Client.Models.OrderBooks;

namespace OrderBooks.Client.Grpc
{
    internal class OrderBookApi : IOrderBookApi
    {
        private readonly Service.OrderBooks.Contracts.OrderBooks.OrderBooksClient _client;

        public OrderBookApi(string address)
        {
            var balancesServiceChannel = GrpcChannel.ForAddress(address);
            _client = new Service.OrderBooks.Contracts.OrderBooks.OrderBooksClient(balancesServiceChannel);
        }

        public async Task<IReadOnlyList<OrderBookModel>> GetAllAsync()
        {
            var response = await _client.GetAllAsync(new Empty());

            return response.OrderBooks
                .Select(orderBook => new OrderBookModel
                {
                    AssetPairId = orderBook.AssetPairId,
                    Timestamp = orderBook.Timestamp.ToDateTime(),
                    LimitOrders = orderBook.LimitOrders
                        .Select(ToModel)
                        .ToList()
                })
                .ToList();
        }

        public async Task<OrderBookModel> GetByAssetPairIdAsync(string assetPairId)
        {
            var response = await _client.GetByAssetPairIdAsync(
                new Service.OrderBooks.Contracts.GetOrderBookByAssetPairIdRequest {AssetPairId = assetPairId});

            return response.OrderBook != null ? ToModel(response.OrderBook) : null;
        }

        private static OrderBookModel ToModel(Service.OrderBooks.Contracts.OrderBook orderBook)
        {
            return new OrderBookModel
            {
                AssetPairId = orderBook.AssetPairId,
                Timestamp = orderBook.Timestamp.ToDateTime(),
                LimitOrders = orderBook.LimitOrders
                    .Select(ToModel)
                    .ToList()
            };
        }

        private static LimitOrderModel ToModel(Service.OrderBooks.Contracts.LimitOrder limitOrder)
        {
            return new LimitOrderModel
            {
                Id = Guid.Parse(limitOrder.Id),
                Price = decimal.Parse(limitOrder.Price),
                Volume = decimal.Parse(limitOrder.Volume),
                Type = ToModel(limitOrder.Type)
            };
        }

        private static LimitOrderType ToModel(Service.OrderBooks.Contracts.LimitOrderType limitOrderType)
        {
            switch (limitOrderType)
            {
                case Service.OrderBooks.Contracts.LimitOrderType.None:
                    return LimitOrderType.None;
                case Service.OrderBooks.Contracts.LimitOrderType.Sell:
                    return LimitOrderType.Sell;
                case Service.OrderBooks.Contracts.LimitOrderType.Buy:
                    return LimitOrderType.Buy;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}
