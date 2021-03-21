using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Models
{
    public class Test
    {
        public Guid Id { get; }
        public ICollection<Exercise> Exercises { get; }
        public string Author { get; }

        public Test(ICollection<Exercise> exercises, string author)
        {
            Exercises = exercises;
            Author = author;
        }
    }
}
