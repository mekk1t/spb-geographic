using SUAI.SpbGeographic.Trainer.Models;
using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Abstractions
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        UserDetails GetUserDetails(Guid userId);
        void EditUser(User user);
        void DeleteUser(Guid userId);
    }
}
