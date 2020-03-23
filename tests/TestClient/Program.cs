using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OrderBooks.Client;

namespace TestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press enter to start");
            Console.ReadLine();
            
            var client = new OrderBooksClient(new OrderBooksClientSettings {ServiceAddress = "http://localhost:5001"});

            var orderBooks = await client.OrderBooks.GetAllAsync();

            foreach (var orderBook in orderBooks)
            {
                Console.WriteLine($"{orderBook.AssetPairId}\t{orderBook.Timestamp}");

                foreach (var limitOrder in orderBook.LimitOrders)
                {
                    Console.WriteLine($"{limitOrder.Id}\t{limitOrder.Price}\t{limitOrder.Volume}\t{limitOrder.WalletId}");    
                }
            }

            Console.WriteLine("Press enter to start");
            Console.ReadLine();
        }
    }
}
