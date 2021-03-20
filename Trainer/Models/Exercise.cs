using System;

namespace SUAI.SpbGeographic.Trainer.Models
{
    public class Exercise
    {
        public Guid Id { get; }
        public string CorrectAnswer { get; }
        public string ImageBase64 { get; }

        public Exercise(string correctAnswer, string imageBase64)
        {
            Id = Guid.NewGuid();
            CorrectAnswer = correctAnswer;
            ImageBase64 = imageBase64;
        }
    }
}
