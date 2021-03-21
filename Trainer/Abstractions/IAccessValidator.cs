using SUAI.SpbGeographic.Trainer.Models;

namespace SUAI.SpbGeographic.Trainer.Abstractions
{
    public interface IAccessValidator
    {
        bool CurrentUserHasAccessLevel(AccessLevel accessLevel);
    }
}
