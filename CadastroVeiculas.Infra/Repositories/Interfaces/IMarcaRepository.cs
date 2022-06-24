using CadastroVeiculos.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Infra.Data.Repositories.Interfaces
{
    public interface IMarcaRepository : IRepositoryBase<Marca>
    {
        ICollection<Marca> GetAllActive();
        bool VerificarMarcaExiste(Guid marcaId, string nome);
        bool VerificarMarcaExiste(string nome);
    }
}
