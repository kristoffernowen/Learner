using Learner.Application.Features.DoFreeTextExercise.Commands.CheckSingleFactExerciseAnswers;
using Learner.Application.Features.DoFreeTextExercise.Commands.CheckSingleFactExerciseAnswers.Dtos;
using Learner.Application.Tests.Fixtures;
using Learner.Application.Tests.Mocks;
using Shouldly;

namespace Learner.Application.Tests.DoExercisesTests
{
    public class CheckAnswersSingleFactExerciseHandlerTest
    {
        private readonly CheckAnswersSingleFactExerciseHandler _handler;
        private readonly CheckAnswersSingleFactExerciseQuery _query;

        public CheckAnswersSingleFactExerciseHandlerTest()
        {
            var mockRepo = MockSingleFactExerciseRepo.GetById();
            var exercise = SingleFactExerciseFixture.GetExercises()
                .First(x => x.Id == SingleFactExerciseFixture.GetExerciseOneId());
            _handler = new CheckAnswersSingleFactExerciseHandler(mockRepo.Object);
            _query = new CheckAnswersSingleFactExerciseQuery()
            {
                Id = exercise.Id,
                AnswersPerFact = [
                    new CheckAnswersSingleFactExerciseFactInputDto
                    {
                        Id = exercise.Facts[0].Id,
                        GivenAnswer = exercise.Facts[0].FactValue
                    },
                    new CheckAnswersSingleFactExerciseFactInputDto
                    {
                        Id = exercise.Facts[1].Id,
                        GivenAnswer = exercise.Facts[1].FactValue
                    }
                    ]
            };
        }
        [Fact]
        public async Task Should_Return_Populated_List_Of_Result_Dtos()
        {
            var result = await _handler.Handle(_query, CancellationToken.None);

            result.Results.Count.ShouldBeGreaterThan(1);
        }

        [Fact]
        public async Task Should_Return_IsCorrect_False_If_Given_Answer_Is_Incorrect()
        {
            _query.AnswersPerFact[0].GivenAnswer = "Yabadabadoo!";
            var result = await _handler.Handle(_query, CancellationToken.None);

            result.Results[0].IsCorrect.ShouldBeFalse();
            result.Results[1].IsCorrect.ShouldBeTrue();
        }

        [Fact]
        public async Task Should_Return_Per_Fact_Dtos_With_No_Empty_Values_Except_Possibly_Given_Answer()
        {
            var resultFromHandler = await _handler.Handle(_query, CancellationToken.None);
            foreach (var eachResult in resultFromHandler.Results)
            {
                var one = string.IsNullOrEmpty(eachResult.FactName);
                var two = string.IsNullOrEmpty(eachResult.FactId);
                var three = string.IsNullOrEmpty(eachResult.CorrectAnswer);
                var list = new List<bool>() { one, two, three };
                var result = list.Any(b => b);

                result.ShouldBeFalse();
            }
        }
    }
}
