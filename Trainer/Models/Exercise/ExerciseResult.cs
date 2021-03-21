namespace SUAI.SpbGeographic.Trainer.Models
{
    public class ExerciseResult
    {
        public bool IsCorrect { get; }

        public ExerciseResult(bool result)
        {
            IsCorrect = result;
        }
    }
}
