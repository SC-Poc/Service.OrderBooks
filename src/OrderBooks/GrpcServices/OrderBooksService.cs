using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OrderBooks.Domain.Services;
using Service.OrderBooks.Contracts;

namespace OrderBooks.GrpcServices
{
    public class OrderBooksService : Service.OrderBooks.Contracts.OrderBooks.OrderBooksBase
    {
        private readonly IOrderBooksService _orderBooksService;
        private readonly IMapper _mapper;

        public OrderBooksService(IOrderBooksService orderBooksService, IMapper mapper)
        {
            _orderBooksService = orderBooksService;
            _mapper = mapper;
        }

        public override Task<GetAllOrderBooksResponse> GetAll(Empty request, ServerCallContext context)
        {
            var orderBooks = _orderBooksService.GetAll();

            var response = new GetAllOrderBooksResponse();

            response.OrderBooks.AddRange(_mapper.Map<List<OrderBook>>(orderBooks));

            return Task.FromResult(response);
        }

        public override Task<GetOrderBookByAssetPairIdResponse> GetByAssetPairId(
            GetOrderBookByAssetPairIdRequest request, ServerCallContext context)
        {
            var orderBook = _orderBooksService.GetByAssetPairId(request.AssetPairId);

            var response = new GetOrderBookByAssetPairIdResponse {OrderBook = _mapper.Map<OrderBook>(orderBook)};

            return Task.FromResult(response);
        }
    }
}
