using CadastroVeiculos.Domain.Constants;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Infra.Data.Repositories.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Domain.Services
{
    public class VeiculoService : ServiceBase<Veiculo>, IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IBusControl _bus;

        public VeiculoService(IVeiculoRepository veiculoRepository,
                              IBusControl bus) : base(veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
            _bus = bus;
        }

        public override ICollection<Veiculo> GetAll() => _veiculoRepository.GetAll();

        public override void Create(Veiculo entity)
        {
            entity.Status = StatusVeiculo.Disponivel;
            _veiculoRepository.Create(entity);
            _bus.Publish(entity);
        }

        public bool VerificarRENAVAM(Veiculo entity)
        {
            if (entity.Id != Guid.Empty)
                return _veiculoRepository.VerificarRENAVAMExiste(entity.Id, entity.RENAVAM);
            else
                return _veiculoRepository.VerificarRENAVAMExiste(entity.RENAVAM);
        }

        public bool VerificarStatus(Veiculo entity) => entity.Id != Guid.Empty && entity.Status != StatusVeiculo.Disponivel;
    }
}
