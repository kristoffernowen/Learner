using AutoMapper;
using Learner.Application.Features.HandleExercises.Queries.GetExerciseById.Dtos;
using Learner.Application.Tests.Fixtures;
using Moq;

namespace Learner.Application.Tests.Mocks
{
    public class MockMapper
    {
        public static Mock<IMapper> GetMockMapperForGetExerciseByIdRequestHandlerTest(string id)
        {
            var exerciseList = ExercisesFixture.GetExercises();
            var exerciseToMap = exerciseList.First(x => x.Id == id);

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
                            new GetExerciseByIdFactOutputDto
                            {
                                Id = exerciseToMap.FactObjects[0].Facts[0].Id,
                                FactObjectId = exerciseToMap.FactObjects[0].Id,
                                FactName = exerciseToMap.FactObjects[0].Facts[0].FactName,
                                FactType = exerciseToMap.FactObjects[0].Facts[0].FactType,
                                FactValue = exerciseToMap.FactObjects[0].Facts[0].FactValue
                            },
                            new GetExerciseByIdFactOutputDto
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
                            new GetExerciseByIdFactOutputDto
                            {
                                Id = exerciseToMap.FactObjects[1].Facts[0].Id,
                                FactObjectId = exerciseToMap.FactObjects[1].Id,
                                FactName = exerciseToMap.FactObjects[1].Facts[0].FactName,
                                FactType = exerciseToMap.FactObjects[1].Facts[0].FactType,
                                FactValue = exerciseToMap.FactObjects[1].Facts[0].FactValue
                            },
                            new GetExerciseByIdFactOutputDto
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

            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.Map<GetExerciseByIdOutputDto>(exerciseToMap)).Returns(mappedExercise);
            return mapper;
        }
    }
}
