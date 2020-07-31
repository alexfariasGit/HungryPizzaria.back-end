using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HungryPizzaria.Domain.Operation.Repository.Common
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        /*void Add(TEntity obj);
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        DbContext getContext();*/

        DbSet<TEntity> entity();

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
