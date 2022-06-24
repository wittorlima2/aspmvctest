using CadastroVeiculos.Infra.Data.Context;
using CadastroVeiculos.Infra.Data.Repositories.Interfaces;
using CadastroVeiculos.Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using CadastroVeiculos.Domain.Constants;

namespace CadastroVeiculos.Infra.Data.Repositories.Implementations
{
    public class MarcaRepository : RepositoryBase<Marca>, IMarcaRepository
    {
        public MarcaRepository(CadastroVeiculosContext context) : base(context)
        {

        }
        public ICollection<Marca> GetAllActive() => DBContext.Marcas.Where(o => o.Status == Status.Ativo).ToList();
        public bool VerificarMarcaExiste(Guid marcaId, string nome) => DBContext.Marcas.Any(p => p.Id != marcaId && p.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper()));
        public bool VerificarMarcaExiste(string nome) => DBContext.Marcas.Any(p => p.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper()));
    }
}
