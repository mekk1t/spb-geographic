using SUAI.SpbGeographic.Trainer.Models;

namespace SUAI.SpbGeographic.Trainer.Abstractions
{
    public interface IUserHandler
    {
        void Register(User user);
        void Login(UserCredentials credentials);
    }
}
