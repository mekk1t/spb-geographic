using SUAI.SpbGeographic.Trainer.Abstractions;
using SUAI.SpbGeographic.Trainer.Models;
using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Services
{
    public class UserService
    {
        private readonly IAccountService _accountService;
        private readonly IAccessValidator _accessValidator;
        private readonly IUserRepository _userRepository;

        public UserService(IAccountService accountService, IAccessValidator accessValidator, IUserRepository userRepository)
        {
            _accountService = accountService;
            _accessValidator = accessValidator;
            _userRepository = userRepository;
        }

        public void Register(User user) => _accountService.Register(user);

        public void Login(UserCredentials credentials) => _accountService.Login(credentials);

        public IEnumerable<User> GetAllUsers() => _userRepository.GetAllUsers();

        public UserDetails GetUserDetails(Guid userId) => _userRepository.GetUserDetails(userId);

        public void EditUser(User user) => _userRepository.EditUser(user);

        public void SetUserAccessLevel(Guid userId, AccessLevel accessLevel)
        {
            if (_accessValidator.CurrentUserHasAccessLevel(AccessLevel.Superadmin))
            {
                _accountService.SetUserAccessLevel(userId, accessLevel);
                return;
            }

            throw new ForbiddenException();
        }

        public void DeleteUser(Guid userId)
        {
            if (_accessValidator.CurrentUserHasAccessLevel(AccessLevel.Superadmin))
            {
                _userRepository.DeleteUser(userId);
                return;
            }

            throw new ForbiddenException();
        }
    }
}
