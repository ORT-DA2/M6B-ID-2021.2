using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public bool Exist(User user)
        {
            bool existUser = this._userRepository.Exist(user => user.Name == user.Name);

            return existUser;
        }

        public bool Exist(int id)
        {
            bool existUser = this._userRepository.Exist(user => user.Id == id);

            return existUser;
        }

        public User GetById(int id)
        {
            User user = this._userRepository.GetById(id);

            return user;
        }
    }
}