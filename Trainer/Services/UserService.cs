using SUAI.SpbGeographic.Trainer.Abstractions;
using SUAI.SpbGeographic.Trainer.Models;
using System;
using System.Collections.Generic;

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

        public IEnumerable<User> GetAllUsers() => new List<User>();

        public UserDetails GetUserDetails(Guid userId) => new UserDetails();

        public void EditUser(User user) => throw new NotImplementedException();

        public void SetUserAccessLevel(Guid userId, AccessLevel accessLevel) => throw new NotImplementedException();

        public void DeleteUser(Guid userId) => throw new NotImplementedException();
    }
}
