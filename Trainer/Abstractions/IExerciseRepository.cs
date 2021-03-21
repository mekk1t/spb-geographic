using SUAI.SpbGeographic.Trainer.Models;
using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Abstractions
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetAllExercises();
        IEnumerable<Exercise> GetFilteredExercises(ExerciseFilter filter);
        Exercise GetExercise(Guid exerciseId);
        void CreateExercise(Exercise exercise);
        void EditExercise(Exercise exercise);
        void DeleteExercise(Guid exerciseId);
    }
}
