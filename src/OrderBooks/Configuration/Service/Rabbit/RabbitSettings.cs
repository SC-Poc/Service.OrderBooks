using JetBrains.Annotations;
using OrderBooks.Configuration.Service.Rabbit.Subscribers;

namespace OrderBooks.Configuration.Service.Rabbit
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class RabbitSettings
    {
        public RabbitSubscribers Subscribers { get; set; }
    }
}
