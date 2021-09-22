using Domain;

namespace BusinessLogicInterface
{
    public interface IUserLogic
    {
        User GetById(int id);
        bool Exist(User user);
        bool Exist(int id);
    }
}