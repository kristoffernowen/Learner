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

        public static Mock<IExerciseRepository> GetExercisesRepo()
        {
            var listOfExercises = ExercisesFixture.GetExercises();

            Mock<IExerciseRepository> mockExerciseRepo = new();

            mockExerciseRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(listOfExercises);

            return mockExerciseRepo;
        }

        public static Mock<IExerciseRepository> DeleteExerciseRepo(string id)
        {
            Mock<IExerciseRepository> mockRepository = new();

            mockRepository.Setup(x => x.DeleteAsync(id)).Returns(Task.CompletedTask);

            return mockRepository;
        }
    }
}
