using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Infra.Data.Context;
using CadastroVeiculos.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroVeiculos.Infra.Data.Repositories.Implementations
{
    public class VeiculoRepository : RepositoryBase<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(CadastroVeiculosContext cadastroVeiculosContext) : base(cadastroVeiculosContext)
        {

        }

        public override ICollection<Veiculo> GetAll() => DBContext.Veiculos.Include(o => o.Proprietario).Include(o => o.Marca).ToList();
        public bool VerificarRENAVAMExiste(Guid veiculoId, string renavam) => DBContext.Veiculos.Any(p => p.Id != veiculoId && p.RENAVAM.Equals(renavam));
        public bool VerificarRENAVAMExiste(string renavam) => DBContext.Veiculos.Any(p => p.RENAVAM.Equals(renavam));
    }
}
