using System.Collections.Generic;

using System.Data.Entity;

namespace ITI.Mvc.LinkedIn.Repository
{
    interface IRepository<TEntity> where TEntity : class
        
    {
        
        List<TEntity> GetAllBind();
        
        TEntity GetById(params object[] id);
        TEntity Add(TEntity entity);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);

        DbSet<TEntity> GetAll();
    }
}
