using CadastroVeiculos.Infra.Data.Context;
using CadastroVeiculos.Infra.Data.Repositories.Interfaces;
using CadastroVeiculos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroVeiculos.Infra.Data.Repositories.Implementations
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        public CadastroVeiculosContext DBContext;


        public RepositoryBase(CadastroVeiculosContext dbContext)
        {
            DBContext = dbContext;
        }

        public virtual void Create(T entity)
        {
            DBContext.Set<T>().Add(entity);
            DBContext.SaveChanges();
        }

        public virtual ICollection<T> GetAll()
        {
            return DBContext.Set<T>().ToList();
        }

        public virtual T GetById(Guid id)
        {
            return DBContext.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public virtual void Update(T entity)
        {
            DBContext.Set<T>().Update(entity);
            DBContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            DBContext.Set<T>().Remove(entity);
            DBContext.SaveChanges();
        }
    }
}
