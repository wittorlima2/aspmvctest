using CadastroVeiculos.Domain.Entities;
using System.Collections.Generic;

namespace CadastroVeiculos.Domain.Services
{
    public interface IMarcaService : IServiceBase<Marca>
    {
        ICollection<Marca> GetAllActive();
        bool VerificarMarca(Marca entity);
    }
}
