using CadastroVeiculos.Domain.Constants;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Infra.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Domain.Services
{
    public class MarcaService : ServiceBase<Marca>, IMarcaService
    {
        public readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository) : base(marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }


        public ICollection<Marca> GetAllActive() => _marcaRepository.GetAllActive();

        public override void Create(Marca entity)
        {
            entity.Status = Status.Ativo;
            _marcaRepository.Create(entity);
        }

        public bool VerificarMarca(Marca entity)
        {
            if (entity.Id != Guid.Empty)
                return _marcaRepository.VerificarMarcaExiste(entity.Id, entity.Nome);
            else
                return _marcaRepository.VerificarMarcaExiste(entity.Nome);
        }
    }
}
