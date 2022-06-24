using CadastroVeiculos.Domain.Entities;
using System.Collections.Generic;

namespace CadastroVeiculos.Domain.Services
{
    public interface IProprietarioService : IServiceBase<Proprietario>
    {
        ICollection<Proprietario> GetAllActive();
        bool VerificarDocumento(Proprietario entity);
    }
}
