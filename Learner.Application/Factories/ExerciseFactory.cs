using Learner.Application.Contracts.Dtos;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;
using Learner.Application.Helpers.ConversionHelpers;
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
            var fact = dto.FactType switch
            {
                "string" => new Fact()
                {
                    Id = Guid.NewGuid().ToString(),
                    FactName = dto.FactName,
                    FactType = dto.FactType,
                    FactValue = dto.FactValue,
                    FactObjectId = factObjectId
                },
                "int" => new Fact
                {
                    Id = Guid.NewGuid().ToString(),
                    FactName = dto.FactName,
                    FactType = dto.FactType,
                    FactValue = FactConversion.CheckIfCanBeConvertedToIntWithApprovedMeasure(dto) ?
                        dto.FactValue :
                        throw new ArgumentException("Value not allowed for Fact with FactType int," +
                                                    " failed to convert to int number and string measure"),
                    FactObjectId = factObjectId
                },
                _ => throw new NotImplementedException()
            };

            return fact;
        }
    }
}
