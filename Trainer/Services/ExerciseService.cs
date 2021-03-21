using SUAI.SpbGeographic.Trainer.Abstractions;
using SUAI.SpbGeographic.Trainer.Extensions;
using SUAI.SpbGeographic.Trainer.Models;
using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Services
{
    public class ExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IAccessValidator _accessValidator;

        public ExerciseService(IExerciseRepository exerciseRepository, IAccessValidator accessValidator)
        {
            _exerciseRepository = exerciseRepository;
            _accessValidator = accessValidator;
        }

        public IEnumerable<Exercise> GetAllExercises() => _exerciseRepository.GetAllExercises();

        public IEnumerable<Exercise> GetFilteredExercises(ExerciseFilter filter) => _exerciseRepository.GetFilteredExercises(filter);

        public Exercise GetExerciseById(Guid exerciseId) => _exerciseRepository.GetExercise(exerciseId);

        public void CreateNewExercise(Exercise exercise)
        {
            if (_accessValidator.CurrentUserHasAccessLevel(AccessLevel.Administrator))
            {
                _exerciseRepository.CreateExercise(exercise);
                return;
            }

            throw new ForbiddenException();
        }

        public void EditExercise(Exercise exercise)
        {
            if (_accessValidator.CurrentUserHasAccessLevel(AccessLevel.Administrator))
            {
                _exerciseRepository.EditExercise(exercise);
                return;
            }

            throw new ForbiddenException();
        }

        public void DeleteExerciseById(Guid exerciseId)
        {
            if (_accessValidator.CurrentUserHasAccessLevel(AccessLevel.Administrator))
            {
                _exerciseRepository.DeleteExercise(exerciseId);
                return;
            }

            throw new ForbiddenException();
        }

        public ExerciseHint GetHintByExerciseId(Guid exerciseId)
        {
            var exercise = _exerciseRepository.GetExercise(exerciseId);
            return exercise.Hint;
        }

        public ExerciseResult GetExerciseResult(ExerciseAnswer answer)
        {
            var exercise = _exerciseRepository.GetExercise(answer.ExerciseId);

            bool isCorrectAnswer = false;
            if (exercise.CorrectAnswer.EqualsIgnoreCase(answer.Answer))
            {
                isCorrectAnswer = true;
            }

            return new ExerciseResult(isCorrectAnswer);
        }
    }
}
