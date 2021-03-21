using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Models.Stats
{
    public class TestStats
    {
        public IEnumerable<UserDetails> UsersAttemptedThisTest { get; }
        public IEnumerable<UserDetails> UsersPassedThisTest { get; }
    }
}
