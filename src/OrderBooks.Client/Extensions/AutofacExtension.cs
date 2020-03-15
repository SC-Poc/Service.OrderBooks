using System;
using System.Diagnostics.CodeAnalysis;
using Autofac;

namespace OrderBooks.Client.Extensions
{
    /// <summary>
    /// Extension for client registration.
    /// </summary>
    public static class AutofacExtension
    {
        /// <summary>
        /// Registers <see cref="IOrderBooksClient"/> in Autofac container using <see cref="OrderBooksClientSettings"/>.
        /// </summary>
        /// <param name="builder">Autofac container builder.</param>
        /// <param name="settings">Matching engine client settings.</param>
        public static void RegisterOrderBooksClient(
            [NotNull] this ContainerBuilder builder,
            [NotNull] OrderBooksClientSettings settings)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            builder.RegisterInstance(new OrderBooksClient(settings))
                .As<IOrderBooksClient>()
                .SingleInstance();
        }
    }
}
