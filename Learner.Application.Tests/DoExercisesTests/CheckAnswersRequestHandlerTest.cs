using AutoMapper;
using Learner.Application.Contracts.Repos;
using Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers;
using Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers.Dtos;
using Learner.Application.Tests.Fixtures;
using Learner.Application.Tests.Mocks;
using Learner.Domain.Models;
using Learner.Domain.Models.Results;
using Moq;
using Shouldly;

namespace Learner.Application.Tests.DoExercisesTests
{
    public class CheckAnswersRequestHandlerTest
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IExerciseRepository> _mockExerciseRepo;
        private readonly CheckAnswersRequest _request;
        private readonly Exercise _exerciseWithRightAnswers;

        public CheckAnswersRequestHandlerTest()
        {
            var id = ExercisesFixture.IdOne;
            var exercisesList = ExercisesFixture.GetExercises();
            _exerciseWithRightAnswers = exercisesList[0];
            _mockMapper = MockMapper.GetMockMapperForCheckAnswersTest();
            _mockExerciseRepo = MockExerciseRepo.GetExerciseByIdRepo(id);
            _request = new CheckAnswersRequest()
            {
                Id = _exerciseWithRightAnswers.Id,
                AnswersPerFact = new()
                {
                    new CheckAnswersFactInputDto()
                    {
                        Id = _exerciseWithRightAnswers.FactObjects[0].Facts[0].Id,
                        FactObjectId = _exerciseWithRightAnswers.FactObjects[0].Facts[0].FactObjectId,
                        GivenAnswer = "Fact Four"  // wrong
                    },
                    new CheckAnswersFactInputDto()
                    {
                        Id = _exerciseWithRightAnswers.FactObjects[0].Facts[1].Id,
                        FactObjectId = _exerciseWithRightAnswers.FactObjects[0].Facts[1].FactObjectId,
                        GivenAnswer = "Fat"  // wrong
                    },
                    new CheckAnswersFactInputDto()
                    {
                        Id = _exerciseWithRightAnswers.FactObjects[1].Facts[0].Id,
                        FactObjectId = _exerciseWithRightAnswers.FactObjects[1].Facts[0].FactObjectId,
                        GivenAnswer = "Fact Two"  // correct
                    },
                    new CheckAnswersFactInputDto()
                    {
                        Id = _exerciseWithRightAnswers.FactObjects[1].Facts[1].Id,
                        FactObjectId = _exerciseWithRightAnswers.FactObjects[1].Facts[1].FactObjectId,
                        GivenAnswer = "Small"  // correct
                    },
                }
            };
        }
        [Fact]
        public async Task Should_Return_Check_Answers_Request_Output_Dto()
        {
            var sut = new CheckAnswersRequestHandler(_mockExerciseRepo.Object, _mockMapper.Object);

            var result = await sut.Handle(_request, CancellationToken.None);

            _mockMapper.Verify(x => x.Map<CheckAnswersRequestOutputDto>(It.IsAny<ResultPerExercise>()), Times.Exactly(1));

            result.ShouldBeOfType(typeof(CheckAnswersRequestOutputDto));
            
        }

        [Fact]
        public async Task Should_Return_Dto_With_Result_Per_Fact_Output_Dto_Per_Fact()
        {
            var sut = new CheckAnswersRequestHandler(_mockExerciseRepo.Object, _mockMapper.Object);

            var result = await sut.Handle(_request, CancellationToken.None);

            foreach (var factObject in result.PerFactObjects)
            {
                factObject.PerFacts.ShouldNotBeEmpty();
                foreach (var fact in factObject.PerFacts)
                {
                    fact.ShouldBeOfType(typeof(ResultPerFactOutputDto));
                }
            }
        }

        [Fact]
        public void Check_Answers_Utility_Free_Text_Should_Mark_False_If_Answer_Is_Not_Right_For_Each_Fact()
        {
            var listOfRightAnswers = (from rightAnswer in _exerciseWithRightAnswers.FactObjects
                from fact in rightAnswer.Facts
                select fact).ToList();

            var result = CompareAnswersUtility.FreeTextComparison(_request.AnswersPerFact, listOfRightAnswers);

            result[0].IsCorrect.ShouldBe(false);
            result[1].IsCorrect.ShouldBe(false);
            result[2].IsCorrect.ShouldBe(true);
            result[3].IsCorrect.ShouldBe(true);
        }
    }
}
