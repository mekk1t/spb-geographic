using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Models
{
    public class TestSolution
    {
        public Guid UserId { get; set; }
        public Guid TestId { get; }
        public Dictionary<Guid, string> ExerciseIdToUserAnswers { get; set; }
    }
}
