using SUAI.SpbGeographic.Trainer.Models;
using System;

namespace SUAI.SpbGeographic.Trainer.Abstractions
{
    public interface IAccountService
    {
        void Register(User user);
        void Login(UserCredentials credentials);
        void SetUserAccessLevel(Guid userId, AccessLevel accessLevel);
    }
}
