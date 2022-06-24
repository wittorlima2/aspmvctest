using CadastroVeiculos.Domain.Entities;
using System;

namespace CadastroVeiculos.Infra.Data.Repositories.Interfaces
{
    public interface IVeiculoRepository : IRepositoryBase<Veiculo>
    {
        bool VerificarRENAVAMExiste(Guid veiculoId, string renavam);
        bool VerificarRENAVAMExiste(string renavam);
    }
}
