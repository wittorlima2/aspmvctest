using CadastroVeiculos.Application.Services.Interfaces;
using CadastroVeiculos.Domain.Entities;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace CadastroVeiculos.Message.Consurmers
{
    public class CadastroVeiculoConsumer : IConsumer<Veiculo>
    {
        private readonly IEmailService _emailService;

        public CadastroVeiculoConsumer(IEmailService emailService)
        {
            this._emailService = emailService;
        }

        public Task Consume(ConsumeContext<Veiculo> context)
        {
            try
            {
                var veiculo = context.Message;
                _emailService.CadastroVeiculo(veiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.CompletedTask;
        }
    }
}
