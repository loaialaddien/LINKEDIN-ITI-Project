using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace ITI.Mvc.LinkedIn.Repository
{
    public class Repository<TEntity, Context> : IRepository<TEntity> where TEntity : class where Context : DbContext, new()
    {
        Context context;
        public Repository(Context context)
        {
            this.context = context;

        }

        public TEntity Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return context.SaveChanges() > 0 ? entity : null;
        }

        public DbSet<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public List<TEntity> GetAllBind()
        {
            return context.Set<TEntity>().ToList();

        }

        public TEntity GetById(params object[] id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {

                return context.Set<TEntity>().Find(id);
            }
        }

        public bool Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return context.SaveChanges() > 0;
        }
        public bool Update(TEntity entity)
        {
           
            context.Set<TEntity>().AddOrUpdate(entity);
            return context.SaveChanges() > 0;
        }

    }
}