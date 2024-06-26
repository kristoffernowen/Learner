using AutoMapper;
using Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create.Dtos;
using Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests;
using Learner.Application.Tests.Fixtures;
using Learner.Domain.Models;
using Moq;

namespace Learner.Application.Tests.Mocks;

public class MockSingleFactExerciseMapper
{
    public static Mock<IMapper> GetMockMapperForCreateSingleFactExerciseTest()
    {
        var mapper = new Mock<IMapper>();
        mapper.Setup(x => x.Map<CreateSingleFactExerciseOutputDto>(It.IsAny<SingleFactExercise>()))
            .Returns(new CreateSingleFactExerciseOutputDto()
            {
                Name = "Test single fact exercise",
                Facts = new List<CreateSingleFactExerciseFactOutputDto>
                {
                    new()
                    {
                        FactName = "Test fact one",
                        FactType = "string",
                        FactValue = "Test value one"
                    },
                    new()
                    {
                        FactName = "Test fact two",
                        FactType = "int",
                        FactValue = "30 km"
                    }
                }
            });
        return mapper;
    }

    public static Mock<IMapper> GetMockMapperForGetAllSingleFactExercisesTest()
    {
        var exercises = SingleFactExerciseFixture.GetExercises();
        var dtos = exercises.Select(x =>
            new GetSingleFactExercisesOutputDto {Id = x.Id, Name = x.Name}).ToList();

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(x => x.Map<List<GetSingleFactExercisesOutputDto>>(It.IsAny<List<SingleFactExercise>>()))
            .Returns(dtos);

        return mockMapper;
    }
}