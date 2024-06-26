using Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create.Dtos;
using Learner.Application.Helpers.ConversionHelpers;
using Learner.Domain.Models;

namespace Learner.Application.Factories
{
    public static class SingleFactExerciseFactory
    {
        public static SingleFactExercise Create(ICreateSingleFactExerciseInputDto dto)
        {
            var exercise = new SingleFactExercise()
            {
                Name = dto.Name,
                Id = Guid.NewGuid().ToString(),
                Facts = dto.Facts.Select(CreateSingleFact).ToList()
            };

            return exercise;
        }

        public static SingleFact CreateSingleFact(CreateSingleFactExerciseFactInputDto dto)
        {
            var fact = dto.FactType switch
            {
                "string" => new SingleFact()
                {
                    Id = Guid.NewGuid().ToString(),
                    FactName = dto.FactName,
                    FactType = dto.FactType,
                    FactValue = dto.FactValue,
                },
                "int" => new SingleFact()
                {
                    Id = Guid.NewGuid().ToString(),
                    FactName = dto.FactName,
                    FactType = dto.FactType,
                    FactValue = FactConversion.CheckIfCanBeConvertedToIntWithApprovedMeasure(dto) ?
                        dto.FactValue :
                        throw new ArgumentException($"Value not allowed for {nameof(SingleFact)} with FactType int," +
                                                    " failed to convert to int number and string measure"),
                },
                _ => throw new NotImplementedException()
            };

            return fact;
        }
    }

    public interface ICreateSingleFactExerciseInputDto
    {
        public string Name { get; set; }
        public List<CreateSingleFactExerciseFactInputDto> Facts { get; set; }
    }
}
