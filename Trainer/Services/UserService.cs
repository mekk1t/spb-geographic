using SUAI.SpbGeographic.Trainer.Abstractions;
using SUAI.SpbGeographic.Trainer.Models;
using SUAI.SpbGeographic.Trainer.Models.Commands;
using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Services
{
    public class UserService
    {
        private readonly IUserHandler _userHandler;
        private readonly IAccessValidator _accessValidator;
        private readonly ICommand<SetAccessLevelCommand> _setAccessLevelCommand;

        public UserService(IUserHandler userHandler, IAccessValidator accessValidator)
        {
            _userHandler = userHandler;
            _accessValidator = accessValidator;
        }

        public void Register(User user) => _userHandler.Register(user);

        public void Login(UserCredentials credentials) => _userHandler.Login(credentials);

        public IEnumerable<User> GetAllUsers() => new List<User>();

        public UserDetails GetUserDetails(Guid userId) => new UserDetails();

        public void EditUser(User user) => throw new NotImplementedException();

        public void SetUserAccessLevel(SetAccessLevelCommand command)
        {
            if (_accessValidator.CurrentUserHasAccessLevel(AccessLevel.Superadmin))
            {
                _setAccessLevelCommand.Execute(command);
                return;
            }

            throw new Exception("Нет права доступа");
        }

        public void DeleteUser(Guid userId) => throw new NotImplementedException();
    }
}
