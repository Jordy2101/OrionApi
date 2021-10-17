using Microsoft.EntityFrameworkCore;
using ORIONDEV.DATA.Base.Interface;
using ORIONDEV.DATA.DBContexts;
using ORIONDEV.ENTITY.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ORIONDEV.DATA.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected OrionDevDataContext RepositoryContext { get; set; }
        protected readonly DbSet<T> entities;
        public BaseRepository(OrionDevDataContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
            entities = RepositoryContext.Set<T>();
        }
        public virtual int Create(T entity)
        {
            entity.IsActive = true;
            entity.CreateDate = DateTime.Now;
            var result = entities.Add(entity);
            this.RepositoryContext.SaveChanges();
            return Convert.ToInt32(result.Property("Id").CurrentValue.ToString());
        }
        public async Task<int> CommitChanges() => await this.RepositoryContext.SaveChangesAsync();
        private int Save => this.RepositoryContext.SaveChanges();
        public virtual void Delete(int Id)
        {
            var entity = this.GetOne(Id);
            entity.IsActive = false;
            this.Update(entity);
        }

        public virtual IQueryable<T> FindAll()
        {
            var result = this.entities.OrderByDescending(c => c.Id).AsNoTracking();
            return result;
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public virtual T GetOne(int Id)
        {
            return this.RepositoryContext.Set<T>().Find(Id);
        }

        public virtual T Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            this.RepositoryContext.SaveChanges();
            return entity;
        }

        public bool Exist(Expression<Func<T, bool>> expression) => (this.RepositoryContext.Set<T>().Any(expression));

    }
}
