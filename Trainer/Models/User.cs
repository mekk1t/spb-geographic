using System;

namespace SUAI.SpbGeographic.Trainer.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
