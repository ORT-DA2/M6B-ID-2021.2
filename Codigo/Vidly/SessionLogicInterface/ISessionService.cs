using System;
using SessionLogicInterface.Entities;

namespace SessionLogicInterface
{
    public interface ISessionService
    {
        string Login(UserCredentials credentials);
    }
}
