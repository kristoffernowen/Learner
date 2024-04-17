using Learner.Application.Contracts.Dtos;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;
using Learner.Domain.Models;

namespace Learner.Application.Factories
{
    public static class ExerciseFactory
    {
        public static Exercise Create(ICreateExerciseDto dto)
        {
            var exercise = new Exercise()
            {
                Id = Guid.NewGuid().ToString(),
                Name = dto.Name
            };

            foreach (var factObject in dto.FactObjects)
            {
                var newFactObject = CreateFactObject(factObject, exercise.Id);

                foreach (var fact in factObject.Facts)
                {
                    var newFact = CreateFact(fact, newFactObject.Id);
                    newFactObject.Facts.Add(newFact);
                }

                exercise.FactObjects.Add(newFactObject);
            }

            return exercise;
        }

        private static FactObject CreateFactObject(CreateExerciseFactObjectInputDto dto, string exerciseId)
        {
            var factObject = new FactObject()
            {
                Id = Guid.NewGuid().ToString(),
                ExerciseId = exerciseId,
                Name = dto.Name
            };

            return factObject;
        }

        private static Fact CreateFact(CreateExerciseFactInputDto dto, string factObjectId)
        {
            var fact = new Fact()
            {
                Id = Guid.NewGuid().ToString(),
                FactName = dto.FactName,
                FactType = dto.FactType,
                FactValue = dto.FactValue,
                FactObjectId = factObjectId
            };

            return fact;
        }
    }
}
