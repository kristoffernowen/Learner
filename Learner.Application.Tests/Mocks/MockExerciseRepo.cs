using Learner.Application.Contracts.Repos;
using Learner.Application.Tests.Fixtures;
using Moq;

namespace Learner.Application.Tests.Mocks
{
    public class MockExerciseRepo
    {
        public static Mock<IExerciseRepository> GetExerciseByIdRepo(string id)
        {
            var listOfExercises = ExercisesFixture.GetExercises();

            Mock<IExerciseRepository> mockExerciseRepo = new();

            mockExerciseRepo.Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(listOfExercises.First(x => x.Id == id));

            return mockExerciseRepo;
        }
    }
}
