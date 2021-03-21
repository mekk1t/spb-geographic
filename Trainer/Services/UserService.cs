using SUAI.SpbGeographic.Trainer.Abstractions;
using SUAI.SpbGeographic.Trainer.Models;
using SUAI.SpbGeographic.Trainer.Models.Commands;
using SUAI.SpbGeographic.Trainer.Models.Queries;
using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Services
{
    public class UserService
    {
        private readonly IUserHandler _userHandler;
        private readonly IAccessValidator _accessValidator;
        private readonly ICommand<SetAccessLevelCommand> _setAccessLevelCommand;
        private readonly ICommand<DeleteUserCommand> _deleteUserCommand;
        private readonly ICommand<EditUserCommand> _editUserCommand;
        private readonly IQuery<IEnumerable<User>> _getAllUsersQuery;
        private readonly IQuery<UserDetails, GetUserDetailsQuery> _getUserDetailsQuery;

        public UserService(IUserHandler userHandler, IAccessValidator accessValidator)
        {
            _userHandler = userHandler;
            _accessValidator = accessValidator;
        }

        public void Register(User user) => _userHandler.Register(user);

        public void Login(UserCredentials credentials) => _userHandler.Login(credentials);

        public IEnumerable<User> GetAllUsers() => _getAllUsersQuery.Execute();

        public UserDetails GetUserDetails(GetUserDetailsQuery query) => _getUserDetailsQuery.Execute(query);

        public void EditUser(EditUserCommand command) => _editUserCommand.Execute(command);

        public void SetUserAccessLevel(SetAccessLevelCommand command)
        {
            if (_accessValidator.CurrentUserHasAccessLevel(AccessLevel.Superadmin))
            {
                _setAccessLevelCommand.Execute(command);
                return;
            }

            throw new Exception("Нет права доступа");
        }

        public void DeleteUser(DeleteUserCommand command)
        {
            if (_accessValidator.CurrentUserHasAccessLevel(AccessLevel.Superadmin))
            {
                _deleteUserCommand.Execute(command);
                return;
            }

            throw new Exception("Нет прав доступа");
        }
    }
}
