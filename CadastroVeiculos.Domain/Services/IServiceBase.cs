using CadastroVeiculos.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Domain.Services
{
    public interface IServiceBase<T> where T : EntityBase
    {
        ICollection<T> GetAll();

        T GetById(Guid id);

        void Create(T entity);

        void Update(T entity);

        void Delete(Guid id);
    }
}
