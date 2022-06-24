using CadastroVeiculos.Domain.Constants;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Infra.Data.Context;
using CadastroVeiculos.Infra.Data.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CadastroVeiculos.Infra.Data.Repositories.Implementations
{
    public class ProprietarioRepository : RepositoryBase<Proprietario>, IProprietarioRepository
    {
        public ProprietarioRepository(CadastroVeiculosContext context) : base(context)
        {

        }

        public ICollection<Proprietario> GetAllActive() => DBContext.Proprietarios.Where(o => o.Status == Status.Ativo).ToList();

        public bool VerificarDocumentoExiste(Guid proprietarioId, string documento) => DBContext.Proprietarios.Any(p => p.Id != proprietarioId && p.Documento.Equals(documento));
        public bool VerificarDocumentoExiste(string documento) => DBContext.Proprietarios.Any(p => p.Documento.Equals(documento));
    }
}
