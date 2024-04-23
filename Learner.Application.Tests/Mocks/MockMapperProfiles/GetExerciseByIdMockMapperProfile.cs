using Learner.Application.Features.HandleExercises.Queries.GetExerciseById.Dtos;
using Learner.Domain.Models;

namespace Learner.Application.Tests.Mocks.MockMapperProfiles;

public class GetExerciseByIdMockMapperProfile
{
    public static GetExerciseByIdOutputDto GetMappedExerciseDto(Exercise exerciseToMap)
    {
        var mappedDto = new GetExerciseByIdOutputDto()
        {
            Id = exerciseToMap.Id,
            Name = exerciseToMap.Name,
            FactObjects = exerciseToMap.FactObjects.Select(x =>
                new GetExerciseByIdFactObjectOutputDto()
                {
                    Id = x.Id,
                    ExerciseId = x.ExerciseId,
                    Name = x.Name,
                    Facts = x.Facts.Select(f => new GetExerciseByIdFactOutputDto()
                    {
                        Id = f.Id,
                        FactObjectId = f.FactObjectId,
                        FactName = f.FactName,
                        FactType = f.FactType,
                        FactValue = f.FactValue
                    }).ToList()
                }).ToList()
        };

        return mappedDto;
    }
}