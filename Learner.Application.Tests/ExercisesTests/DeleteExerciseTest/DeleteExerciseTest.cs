using Learner.Application.Tests.Mocks;
using Moq;

namespace Learner.Application.Tests.ExercisesTests.DeleteExerciseTest
{
    public class DeleteExerciseTest
    {
        [Fact]
        public async Task Should_Remove_Exercise_With_Id()
        {
            const string id = "deleteMe";
            var mockRepo = MockExerciseRepo.DeleteExerciseRepo(id);
            var sut = new DeleteExerciseRequestHandler(mockRepo.Object);
            var request = new DeleteExerciseRequest(id);

            await sut.Handle(request, CancellationToken.None);

            mockRepo.Verify(x => x.DeleteAsync(id), Times.Exactly(1));
        }
    }
}
