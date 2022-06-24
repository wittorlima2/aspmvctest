using CadastroVeiculos.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Infra.Data.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        ICollection<T> GetAll();
        T GetById(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
