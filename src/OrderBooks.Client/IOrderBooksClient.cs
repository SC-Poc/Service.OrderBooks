using OrderBooks.Client.Api;

namespace OrderBooks.Client
{
    /// <summary>
    /// Order books service client.
    /// </summary>
    public interface IOrderBooksClient
    {
        /// <summary>
        /// Order books API.
        /// </summary>
        IOrderBookApi OrderBooks { get; }
    }
}
