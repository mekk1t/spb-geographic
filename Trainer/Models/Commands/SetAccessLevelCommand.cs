using System;
namespace SUAI.SpbGeographic.Trainer.Models.Commands
{
    public class SetAccessLevelCommand
    {
        public Guid UserId { get; }
        public AccessLevel AccessLevel { get; }

        public SetAccessLevelCommand(Guid userId, AccessLevel accessLevel)
        {
            UserId = userId;
            AccessLevel = accessLevel;
        }
    }
}
