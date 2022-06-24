using CadastroVeiculos.Domain.Entities;

namespace CadastroVeiculos.Domain.Services
{
    public interface IVeiculoService : IServiceBase<Veiculo>
    {
        bool VerificarRENAVAM(Veiculo entity);
        bool VerificarStatus(Veiculo entity);
    }
}
