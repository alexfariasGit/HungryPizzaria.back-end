using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizzaria.Data.Operation.Repositories.Common
{
    public class RepositoryBase<TEntity> : IDisposable, Domain.Operation.Repository.Common.IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly Context.CoreDbContext dbCore;
        public readonly DbSet<TEntity> dbSet;
        public RepositoryBase()
        {
            dbCore = new Context.CoreDbContext();
            dbSet = dbCore.Set<TEntity>();
        }

        public DbSet<TEntity> entity()
        {
            return dbSet;
        }

        /*
        public virtual void Add(TEntity obj)
        {
            dbCore.Add(obj);
            dbCore.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbCore.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(int? id)
        {
            return dbCore.Set<TEntity>().Find(id);
        }

        public virtual void Remove(TEntity obj)
        {
            dbCore.Set<TEntity>().Remove(obj);
            dbCore.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            dbCore.Entry(obj).State = EntityState.Modified;
            dbCore.SaveChanges();
        }
        */

        public void Dispose()
        {
            dbCore.Dispose();
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            dbCore.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await dbCore.SaveChangesAsync();
        }
    }
}
