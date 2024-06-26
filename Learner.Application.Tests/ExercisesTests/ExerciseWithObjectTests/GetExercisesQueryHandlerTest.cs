using Learner.Application.Features.HandleExercises.Queries.GetExercises;
using Learner.Application.Tests.Mocks;
using Shouldly;

namespace Learner.Application.Tests.ExercisesTests.ExerciseWithObjectTests
{
    public class GetExercisesQueryHandlerTest
    {
        private readonly GetExercisesQuery _request;
        private readonly GetExercisesQueryHandler _handler;

        public GetExercisesQueryHandlerTest()
        {
            var mockExerciseRepo = MockExerciseRepo.GetExercisesRepo();
            var mockMapper = MockMapper.GetMockMapperForGetExercisesRequestHandlerTest();
            _request = new GetExercisesQuery();
            _handler = new GetExercisesQueryHandler(mockExerciseRepo.Object, mockMapper.Object);
        }

        [Fact]
        public async Task Should_Return_List_Get_Exercises_Output_Dto()
        {
            var result = await _handler.Handle(_request, CancellationToken.None);

            result.Count.ShouldBe(2);
            result.ShouldAllBe(x => x.GetType() == typeof(GetExercisesOutputDto));
        }

        [Fact]
        public async Task Should_Return_Dtos_With_Values()
        {
            var result = await _handler.Handle(_request, CancellationToken.None);

            result.ShouldAllBe(x => x.Name == "Mock output" || x.Name == "Mock output 2");
            result.ShouldAllBe(x => x.Id != null);
        }
    }
}
