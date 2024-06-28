using Learner.Application.Features.DoFreeTextExercise.Queries.StartSingleFactExercise;
using Learner.Application.Features.DoFreeTextExercise.Queries.StartSingleFactExercise.Dtos;
using Learner.Application.Tests.Fixtures;
using Learner.Application.Tests.Mocks;
using Shouldly;

namespace Learner.Application.Tests.DoExercisesTests
{
    public class StartSingleFactExerciseQueryHandlerTests
    {
        private readonly StartSingleFactExerciseQueryHandler _handler;
        private readonly StartSingleFactExerciseQuery _query;
        public StartSingleFactExerciseQueryHandlerTests()
        {
            var mockRepo = MockSingleFactExerciseRepo.GetById();
            _query = new StartSingleFactExerciseQuery(SingleFactExerciseFixture.GetExerciseOneId());
            _handler = new StartSingleFactExerciseQueryHandler(mockRepo.Object);
        }
        [Fact]
        public async Task Should_Return_Start_Single_Fact_Exercise_Output_Dto()
        {
            var result = await _handler.Handle(_query, CancellationToken.None);

            result.ShouldBeOfType<StartSingleFactExerciseOutputDto>();
        }

        [Fact]
        public async Task Should_Return_Dto_With_Correct_Values()
        {
            var result = await _handler.Handle(_query, CancellationToken.None);
            result.Id.ShouldBe(SingleFactExerciseFixture.GetExerciseOneId());
            result.Facts.ShouldAllBe(x => x.FactValue == "");
            result.Facts.ShouldAllBe(x => !string.IsNullOrEmpty(x.FactName));
            result.ShouldNotBeNull();
        }
    }
}
