using AutoMapper;
using Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers.Dtos;
using Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise.Dtos;
using Learner.Application.Features.HandleExercises.Queries.GetExerciseById.Dtos;
using Learner.Application.Features.HandleExercises.Queries.GetExercises;
using Learner.Application.Tests.Fixtures;
using Learner.Application.Tests.Mocks.MockMapperProfiles;
using Learner.Domain.Models.Results;
using Moq;

namespace Learner.Application.Tests.Mocks
{
    public class MockMapper
    {
        public static Mock<IMapper> GetMockMapperForGetExercisesRequestHandlerTest()
        {
            var exercisesList = ExercisesFixture.GetExercises();
            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.Map<List<GetExercisesOutputDto>>(exercisesList))
                .Returns([
                    new GetExercisesOutputDto()
                        {Id = Guid.NewGuid().ToString(), Name = "Mock output"},

                    new GetExercisesOutputDto()
                        {Id = Guid.NewGuid().ToString(), Name = "Mock output 2"}
                ]);
            return mapper;
        }
        public static Mock<IMapper> GetMockMapperForGetExerciseByIdRequestHandlerTest(string id)
        {
            var exerciseList = ExercisesFixture.GetExercises();
            var exerciseToMap = exerciseList.First(x => x.Id == id);
            var mappedExercise = GetExerciseByIdMockMapperProfile.GetMappedExerciseDto(exerciseToMap);
            
            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.Map<GetExerciseByIdOutputDto>(exerciseToMap))
                .Returns(mappedExercise);

            return mapper;
        }

        public static Mock<IMapper> GetMockMapperForStartExerciseTest(string id)
        {
            var exerciseList = ExercisesFixture.GetExercises();
            var exerciseToMap = exerciseList.First(x => x.Id == id);
            var mappedExercise = StartExerciseMockMapperProfile.GetMappedExerciseDto(exerciseToMap);

            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.Map<GetExerciseWithoutAnswersOutputDto>(exerciseToMap))
                .Returns(mappedExercise);

            return mapper;
        }

        public static Mock<IMapper> GetMockMapperForCheckAnswersTest()
        {
            var mapper = new Mock<IMapper>();
            
            mapper.Setup(x => x.Map<CheckAnswersRequestOutputDto>(It.IsAny<ResultPerExercise>()))
                .Returns(new CheckAnswersRequestOutputDto()
                {
                    PerFactObjects = new List<ResultPerFactObjectOutputDto>()
                    {
                        new ResultPerFactObjectOutputDto()
                        {
                            PerFacts = new List<ResultPerFactOutputDto>()
                            {
                                new()
                                {
                                    IsCorrect = false
                                }
                            }
                        }
                    }
                });
            return mapper;
        }
    }
}
