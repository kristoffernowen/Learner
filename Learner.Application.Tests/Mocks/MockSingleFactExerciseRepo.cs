using Learner.Application.Contracts.Repos;
using Learner.Domain.Models;
using Moq;

namespace Learner.Application.Tests.Mocks;

public class MockSingleFactExerciseRepo
{
    public static Mock<ISingleFactExerciseRepository> Create(SingleFactExercise singleFactExercise)
    {
        var returnExercise = new SingleFactExercise()
        {
            Name = "Test single fact exercise",
            Facts = new List<SingleFact>
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
        };

        var mockRepository = new Mock<ISingleFactExerciseRepository>();
        mockRepository.Setup(x => x.CreateAsync(new SingleFactExercise())).ReturnsAsync(returnExercise);

        return mockRepository;
    }
}