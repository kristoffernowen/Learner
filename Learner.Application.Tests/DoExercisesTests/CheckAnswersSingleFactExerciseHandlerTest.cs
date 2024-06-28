using Learner.Application.Contracts.Repos;
using Learner.Application.Helpers;
using Learner.Application.Tests.Fixtures;
using Learner.Application.Tests.Mocks;
using MediatR;
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
                var list = new List<bool>() {one, two, three};
                var result = list.Any(b => b);

                result.ShouldBeFalse();
            }
        }
    }

    public class CheckAnswersSingleFactExerciseHandler(
        ISingleFactExerciseRepository singleFactExerciseRepository
        )
        : IRequestHandler<CheckAnswersSingleFactExerciseQuery, CheckAnswersSingleFactExerciseResultOutputDto>
    {

        public async Task<CheckAnswersSingleFactExerciseResultOutputDto> Handle(CheckAnswersSingleFactExerciseQuery request, CancellationToken cancellationToken)
        {
            var exerciseWithRightAnswers = await singleFactExerciseRepository.GetByIdAsync(request.Id);
            if (exerciseWithRightAnswers is null) throw new Exception("exercise must exist or some logic is faulty");

            var outputDto = new CheckAnswersSingleFactExerciseResultOutputDto()
            {
                Id = exerciseWithRightAnswers.Id
            };
            foreach (var answer in request.AnswersPerFact)
            {
                var fact = exerciseWithRightAnswers?.Facts.First(x => x.Id == answer.Id);
                if (fact == null) throw new Exception("no fact with id for answer");
                var result = new CheckSingleFactExerciseResultPerFactOutputDto()
                {
                    FactName = fact.FactName,
                    CorrectAnswer = fact.FactValue,
                    FactId = fact.Id,
                    GivenAnswer = answer.GivenAnswer
                };
                result.IsCorrect = SingleFactCompareAnswersUtility.AnswersAreEqual(answer.GivenAnswer, fact);
                outputDto.Results.Add(result);
            }

            return outputDto;
        }
    }

    public record CheckAnswersSingleFactExerciseQuery : IRequest<CheckAnswersSingleFactExerciseResultOutputDto>
    {
        public string Id { get; set; } = null!;
        public List<CheckAnswersSingleFactExerciseFactInputDto> AnswersPerFact { get; set; } = null!;
    }

    public record CheckAnswersSingleFactExerciseFactInputDto
    {
        public string Id { get; set; } = null!;
        public string GivenAnswer { get; set; } = null!;
    }

    public record CheckAnswersSingleFactExerciseResultOutputDto
    {
        public string Id { get; set; } = null!;
        public List<CheckSingleFactExerciseResultPerFactOutputDto> Results { get; set; } = [];
    }

    public record CheckSingleFactExerciseResultPerFactOutputDto
    {
        public string FactId { get; set; } = null!;
        public string FactName { get; set; } = null!;
        public string GivenAnswer { get; set; } = null!;
        public string CorrectAnswer { get; set; } = null!;
        public bool IsCorrect { get; set; }
    }
}
