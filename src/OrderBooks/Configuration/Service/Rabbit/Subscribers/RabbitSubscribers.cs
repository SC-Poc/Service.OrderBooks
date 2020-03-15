using JetBrains.Annotations;

namespace OrderBooks.Configuration.Service.Rabbit.Subscribers
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class RabbitSubscribers
    {
        public SubscriberSettings OrderBooks { get; set; }
    }
}
