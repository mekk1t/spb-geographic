using SUAI.SpbGeographic.Trainer.Extensions;
using System;

namespace SUAI.SpbGeographic.Trainer.Models
{
    public class User
    {
        public Guid Id { get; }
        public string Username { get; }
        public string PasswordHash { get; }

        public User(string username, string password)
        {
            Id = Guid.NewGuid();
            Username = username;
            PasswordHash = password.Hash();
        }
    }
}
