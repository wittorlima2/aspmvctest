using CadastroVeiculos.Message.Consurmers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroVeiculos.Message.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMessageProjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<CadastroVeiculoConsumer>();
                cfg.UsingRabbitMq((context, config) =>
                {
                    config.ReceiveEndpoint(configuration["MessageConfiguration:ReceiveEndpoint"], e =>
                    {
                        e.ConfigureConsumer<CadastroVeiculoConsumer>(context);
                    });

                    config.Host(configuration["MessageConfiguration:Host"], "/", h =>
                    {
                        h.Username(configuration["MessageConfiguration:Username"]);
                        h.Password(configuration["MessageConfiguration:Password"]);
                    });
                });
            });

            services.AddMassTransitHostedService();
        }
    }
}
