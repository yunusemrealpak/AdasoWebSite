using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int ID);

        T GetByIdStr(string firmaTescilId);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        IList<T> GetListStrId(string id);

        void Add(T entity);

        void SP_Add(string param);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int ID);
        int GetMaxId();
    }
}
