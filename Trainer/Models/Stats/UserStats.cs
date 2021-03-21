using System;
using System.Collections.Generic;
using System.Linq;

namespace SUAI.SpbGeographic.Trainer.Models
{
    public class UserStats
    {
        public Guid UserId { get; }
        public Dictionary<Exercise, bool> ExercisesCondition { get; set; }

        public int ExercisesCompleted => ExercisesCondition.Where(ec => ec.Value == true).Count();
    }
}
