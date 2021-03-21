using System;

namespace SUAI.SpbGeographic.Trainer.Models.Commands
{
    public class DeleteUserCommand
    {
        public Guid UserId { get; }

        public DeleteUserCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
