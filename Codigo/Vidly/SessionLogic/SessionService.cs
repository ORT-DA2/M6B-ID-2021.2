using System;
using SessionLogicInterface;
using SessionLogicInterface.Entities;

namespace SessionLogic
{
    public class SessionService : ISessionService
    {
        private readonly ITokenProvider _tokenProvider;

        public SessionService(ITokenProvider tokenProvider)
        {

        }
        
        public string Login(UserCredentials credentials)
        {
            //Chequear credenciales

            string token = this._tokenProvider.GenerateToken();

            return token;
        }
    }
}
