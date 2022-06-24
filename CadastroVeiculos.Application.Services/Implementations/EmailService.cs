using CadastroVeiculos.Application.Services.Interfaces;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Net.Mime;
using System.Net;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Services;

namespace CadastroVeiculos.Application.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IProprietarioService _proprietarioService;
        private readonly IConfiguration _configuration;

        public EmailService(IProprietarioService proprietarioService,IConfiguration configuration)
        {
            this._proprietarioService = proprietarioService;
            this._configuration = configuration;
        }

        private async void SendEmail(string email, string title, string body)
        {
            var emailOrigin = _configuration["EmailConfiguration:Email"];
            var msg = GetMailMessage(emailOrigin, title, true);
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html));
            msg.To.Add(new MailAddress(email));
            Send(msg);
        }

        private MailMessage GetMailMessage(string email, string subject, bool isBodyHtml)
        {
            var msg = new MailMessage()
            {
                From = new MailAddress(email),
                Subject = subject,
                IsBodyHtml = isBodyHtml,
            };
            return msg;
        }

        private async void Send(MailMessage mailMessage)
        {
            try
            {
                var smtpClient = GetClient();
                await Task.Factory.StartNew(() => smtpClient.Send(mailMessage));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "Send Email");
            }
        }

        private SmtpClient GetClient()
        {

            SmtpClient smtpClient = new SmtpClient()
            {
                EnableSsl = bool.Parse(_configuration["EmailConfiguration:EnableSsl"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Host = _configuration["EmailConfiguration:Host"],
                Port = int.Parse(_configuration["EmailConfiguration:Port"]),
                UseDefaultCredentials = bool.Parse(_configuration["EmailConfiguration:UseDefaultCredentials"]),
                Credentials = new NetworkCredential(_configuration["EmailConfiguration:Email"], _configuration["EmailConfiguration:Password"])
            };
            return smtpClient;
        }

        public void CadastroVeiculo(Veiculo veiculo)
        {
            try
            {
                if (veiculo != null)
                {
                    var proprietario = _proprietarioService.GetById(veiculo.ProprietarioId);
                    this.SendEmail(proprietario.Email, $"Cadastro de Veiculo - Sucesso", @$"Veículo cadastrado: Marca {veiculo.Marca} Renavam : {veiculo.RENAVAM}");
                }
            }
            catch (Exception erro)
            {
                Debug.WriteLine(erro.Message, "Error ao enviar email");
            }
        }

    }
}
