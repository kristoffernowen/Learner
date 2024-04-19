using Learner.Application.Features.HandleExercises.Queries.GetExerciseById.Dtos;
using Learner.Domain.Models;

namespace Learner.Application.Tests.Mocks.MockMapperProfiles
{
    public class GetExerciseByIdMockMapperProfile
    {
        public static GetExerciseByIdOutputDto GetMappedExerciseDto(Exercise exerciseToMap)
        {
            var mappedExercise = new GetExerciseByIdOutputDto()
            {
                Name = exerciseToMap.Name,
                Id = exerciseToMap.Id,
                FactObjects =
                [
                    new GetExerciseByIdFactObjectOutputDto
                    {
                        Id = exerciseToMap.FactObjects[0].Id,
                        Name = exerciseToMap.FactObjects[0].Name,
                        ExerciseId = exerciseToMap.Id,
                        Facts =
                        [
                            new GetExerciseByIdFactBaseDtoOutputDto
                            {
                                Id = exerciseToMap.FactObjects[0].Facts[0].Id,
                                FactObjectId = exerciseToMap.FactObjects[0].Id,
                                FactName = exerciseToMap.FactObjects[0].Facts[0].FactName,
                                FactType = exerciseToMap.FactObjects[0].Facts[0].FactType,
                                FactValue = exerciseToMap.FactObjects[0].Facts[0].FactValue
                            },
                            new GetExerciseByIdFactBaseDtoOutputDto
                            {
                                Id = exerciseToMap.FactObjects[0].Facts[1].Id,
                                FactObjectId = exerciseToMap.FactObjects[0].Id,
                                FactName = exerciseToMap.FactObjects[0].Facts[1].FactName,
                                FactType = exerciseToMap.FactObjects[0].Facts[1].FactType,
                                FactValue = exerciseToMap.FactObjects[0].Facts[1].FactValue
                            }
                        ]
                    },
                    new GetExerciseByIdFactObjectOutputDto
                    {
                        Id = exerciseToMap.FactObjects[1].Id,
                        Name = exerciseToMap.FactObjects[1].Name,
                        ExerciseId = exerciseToMap.Id,
                        Facts =
                        [
                            new GetExerciseByIdFactBaseDtoOutputDto
                            {
                                Id = exerciseToMap.FactObjects[1].Facts[0].Id,
                                FactObjectId = exerciseToMap.FactObjects[1].Id,
                                FactName = exerciseToMap.FactObjects[1].Facts[0].FactName,
                                FactType = exerciseToMap.FactObjects[1].Facts[0].FactType,
                                FactValue = exerciseToMap.FactObjects[1].Facts[0].FactValue
                            },
                            new GetExerciseByIdFactBaseDtoOutputDto
                            {
                                Id = exerciseToMap.FactObjects[1].Facts[1].Id,
                                FactObjectId = exerciseToMap.FactObjects[1].Id,
                                FactName = exerciseToMap.FactObjects[1].Facts[1].FactName,
                                FactType = exerciseToMap.FactObjects[1].Facts[1].FactType,
                                FactValue = exerciseToMap.FactObjects[1].Facts[1].FactValue
                            }
                        ]
                    }
                ]
            };

            return mappedExercise;
        }
    }
}
