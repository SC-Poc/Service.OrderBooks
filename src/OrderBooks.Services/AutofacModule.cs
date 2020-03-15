using Autofac;
using OrderBooks.Domain.Handlers;
using OrderBooks.Domain.Services;

namespace OrderBooks.Services
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderBooksService>()
                .As<IOrderBooksService>()
                .SingleInstance();

            builder.RegisterType<OrderBooksHandler>()
                .As<IOrderBooksHandler>()
                .SingleInstance();
        }
    }
}
