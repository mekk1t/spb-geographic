using System.Collections.Generic;
using System.Linq;

namespace SUAI.SpbGeographic.Trainer.Models
{
    public class UserStats
    {
        public Dictionary<Test, bool> TestsCondition { get; set; }
        public Dictionary<Exercise, bool> ExercisesCondition { get; set; }

        public int ExercisesCompleted => ExercisesCondition.Where(ec => ec.Value == true).Count();
        public int TestsCompleted => TestsCondition.Where(tc => tc.Value == true).Count();
    }
}
