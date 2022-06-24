using CadastroVeiculos.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Infra.Data.Repositories.Interfaces
{
    public interface IProprietarioRepository : IRepositoryBase<Proprietario>
    {
        ICollection<Proprietario> GetAllActive();
        bool VerificarDocumentoExiste(string documento);
        bool VerificarDocumentoExiste(Guid proprietarioId, string documento);
    }
}
