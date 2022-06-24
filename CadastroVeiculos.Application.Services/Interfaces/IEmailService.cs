using CadastroVeiculos.Domain.Entities;

namespace CadastroVeiculos.Application.Services.Interfaces
{
    public interface IEmailService
    {
        void CadastroVeiculo(Veiculo veiculo);
    }
}
