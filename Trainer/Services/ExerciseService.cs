using SUAI.SpbGeographic.Trainer.Models;
using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Services
{
    public class ExerciseService
    {
        public IEnumerable<Exercise> GetAllExercises() => new List<Exercise>();

        public IEnumerable<Exercise> GetExercisesFiltered(ExerciseFilter filter) => throw new NotImplementedException();

        public Exercise GetExerciseById(Guid exerciseId) => throw new NotImplementedException();

        public void CreateNewExercise(Exercise exercise) => throw new NotImplementedException();

        public void EditExercise(Exercise exercise) => throw new NotImplementedException();

        public void DeleteExerciseById(Guid exerciseId) => throw new NotImplementedException();

        public ExerciseHint GetHintByExerciseId(Guid exerciseId) => new ExerciseHint();

        public ExerciseResult GetExerciseResult(ExerciseAnswer answer) => throw new NotImplementedException();
    }
}
