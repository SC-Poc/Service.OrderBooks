using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using OrderBooks.Client.Models.OrderBooks;
using OrderBooks.Domain.Entities;

namespace OrderBooks
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OrderBook, Service.OrderBooks.Contracts.OrderBook>(MemberList.Destination)
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp.ToTimestamp()))
                .ForMember(dest => dest.LimitOrders, opt => opt.Ignore())
                .AfterMap((src, dest, context) =>
                    dest.LimitOrders.AddRange(
                        context.Mapper.Map<List<Service.OrderBooks.Contracts.LimitOrder>>(src.LimitOrders)));

            CreateMap<LimitOrder, Service.OrderBooks.Contracts.LimitOrder>(MemberList.Destination)
                .ForMember(dest => dest.Price,
                    opt => opt.MapFrom(src => src.Price.ToString(CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Volume,
                    opt => opt.MapFrom(src => src.Volume.ToString(CultureInfo.InvariantCulture)));

            CreateMap<OrderBook, OrderBookModel>(MemberList.Destination);

            CreateMap<LimitOrder, LimitOrderModel>(MemberList.Destination);
        }
    }
}
