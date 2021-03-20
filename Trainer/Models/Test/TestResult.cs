using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Models
{
    public class TestResult
    {
        public Guid UserId { get; }
        public Guid TestId { get; }
        public int SuccessPercent { get; }
        public Dictionary<string, string> UserAnswersCorrectAnswers { get; }
    }
}
