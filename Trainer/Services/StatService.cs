using SUAI.SpbGeographic.Trainer.Models;
using SUAI.SpbGeographic.Trainer.Models.Stats;
using System;

namespace SUAI.SpbGeographic.Trainer.Services
{
    public class StatService
    {
        public UserStats GetUserStats(Guid userId)
            => new UserStats();

        public TestStats GetTestStats(Guid testId)
            => new TestStats();
    }
}
