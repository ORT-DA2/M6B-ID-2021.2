using System;
using System.Linq.Expressions;

namespace DataAccessInterface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        bool Exist(Expression<Func<TEntity, bool>> expression);
    }
}