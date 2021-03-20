using SUAI.SpbGeographic.Trainer.Abstractions;
using SUAI.SpbGeographic.Trainer.Models;

namespace SUAI.SpbGeographic.Trainer.Services
{
    public class UserService
    {
        private readonly IUserHandler _userHandler;

        public UserService(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        public void Register(User user) => _userHandler.Register(user);

        public void Login(UserCredentials credentials) => _userHandler.Login(credentials);
    }
}
