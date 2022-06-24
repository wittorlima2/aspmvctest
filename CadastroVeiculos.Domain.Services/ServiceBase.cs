using CadastroVeiculos.Infra.Data.Repositories.Interfaces;
using CadastroVeiculos.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : EntityBase
    {
        public readonly IRepositoryBase<T> Repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            Repository = repository;
        }

        public virtual void Create(T entity)
        {
            Repository.Create(entity);
        }

        public virtual void Delete(Guid id)
        {
            Repository.Delete(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual T GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        public virtual void Update(T entity)
        {
            Repository.Update(entity);
        }
    }
}
