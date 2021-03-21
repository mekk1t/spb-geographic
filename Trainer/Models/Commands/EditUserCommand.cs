namespace SUAI.SpbGeographic.Trainer.Models.Commands
{
    public class EditUserCommand
    {
        public User User { get; }

        public EditUserCommand(User user)
        {
            User = user;
        }
    }
}
