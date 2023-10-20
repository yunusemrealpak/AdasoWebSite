using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }


        public void SP_Add(string sp_Syntax)
        {
            using (var context = new TContext())
            {

                context.Database.ExecuteSqlCommand(sp_Syntax);
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void DeleteById(int ID)
        {
            using (var context = new TContext())
            {
                var entity = Get(x => x.ID == ID);
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public TEntity GetById(int ID)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(x => x.ID == ID);

            }
        }

        public TEntity GetByIdStr(string strID)
        {
            using (var context = new TContext())
            {

                return context.Set<TEntity>().FirstOrDefault(x => x.strID == strID);

            }
        }
        public int GetMaxId()
        {
            using (var context = new TContext())
            {
                int result = context.Set<TEntity>().Select(s => s.ID).Max();
                return result;
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public IList<TEntity> GetListStrId(string id)
        {
            using (var context = new TContext())
            {
                return id == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(x => x.strID == id).ToList();

            }
        }
        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}