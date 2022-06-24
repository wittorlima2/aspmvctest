using CadastroVeiculos.Domain.Constants;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Infra.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Domain.Services
{
    public class ProprietarioService : ServiceBase<Proprietario>, IProprietarioService
    {
        private readonly IProprietarioRepository _proprietarioRepository;

        public ProprietarioService(IProprietarioRepository proprietarioRepository) : base(proprietarioRepository)
        {
            _proprietarioRepository = proprietarioRepository;
        }

        public ICollection<Proprietario> GetAllActive() => _proprietarioRepository.GetAllActive();

        public override void Create(Proprietario entity)
        {
            entity.Status = Status.Ativo;
            _proprietarioRepository.Create(entity);
        }

        public bool VerificarDocumento(Proprietario entity)
        {
            if (entity.Id != Guid.Empty)
                return _proprietarioRepository.VerificarDocumentoExiste(entity.Id, entity.Documento);
            else
                return _proprietarioRepository.VerificarDocumentoExiste(entity.Documento);
        }
    }
}
