using System;
using System.Linq.Expressions;
using DataAccessInterface;
using Domain;

namespace DataAccess
{
    public class UserRepository : IRepository<User>
    {
        public bool Exist(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}