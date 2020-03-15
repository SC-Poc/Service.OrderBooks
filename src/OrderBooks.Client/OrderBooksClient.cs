using System;
using OrderBooks.Client.Api;
using OrderBooks.Client.Grpc;

namespace OrderBooks.Client
{
    /// <inheritdoc />
    public class OrderBooksClient : IOrderBooksClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="OrderBooksClient"/>.
        /// </summary>
        /// <param name="settings">The client settings.</param>
        public OrderBooksClient(OrderBooksClientSettings settings)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            OrderBooks = new OrderBookApi(settings.ServiceAddress);
        }

        /// <inheritdoc />
        public IOrderBookApi OrderBooks { get; }
    }
}
