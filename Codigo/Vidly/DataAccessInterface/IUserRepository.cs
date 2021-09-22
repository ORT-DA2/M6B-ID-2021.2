using System;
using System.Linq.Expressions;
using Domain;

namespace DataAccessInterface
{
    public interface IUserRepository
    {
        bool Exist(Expression<Func<User, bool>> expression);
        User GetById(int id);
    }
}