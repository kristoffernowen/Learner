using AutoMapper;
using Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create.Dtos;
using Learner.Application.Features.HandleExercises.SingleFactExercise.Queries.GetById;
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

    public static Mock<IMapper> GetMockMapperForGetSingleFactExerciseByIdTests()
    {
        var exercise = SingleFactExerciseFixture.GetExercises()
            .First(x => x.Id == SingleFactExerciseFixture.GetExerciseOneId());
        var facts = exercise.Facts.Select(x => new GetSingleFactByIdOutputDto
        {
            Id = x.Id,
            SingleFactExerciseId = x.SingleFactExerciseId,
            FactName = x.FactName,
            FactType = x.FactType,
            FactValue = x.FactValue,
            AdditionalTags = x.AdditionalTags
        }).ToList();
        var dto = new GetSingleFactExerciseByIdOutputDto
        {
            Name = exercise.Name,
            Id = exercise.Id,
            Facts = facts
        };
        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(x => x.Map<GetSingleFactExerciseByIdOutputDto>(It.IsAny<SingleFactExercise>()))
            .Returns(dto);

        return mockMapper;
    }
}