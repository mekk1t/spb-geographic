using SUAI.SpbGeographic.Trainer.Models;
using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Abstractions
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        UserDetails GetUserDetails(Guid userId);
        void EditUser(Guid userId, UserDetails details);
        void DeleteUser(Guid userId);
    }
}
