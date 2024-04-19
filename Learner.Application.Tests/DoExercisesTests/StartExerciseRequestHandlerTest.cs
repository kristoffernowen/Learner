using Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise;
using Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise.Dtos;
using Learner.Application.Tests.Fixtures;
using Learner.Application.Tests.Mocks;
using Shouldly;

namespace Learner.Application.Tests.DoExercisesTests
{
    public class StartExerciseRequestHandlerTest
    {
        [Fact]
        public async Task Should_Return_Get_Exercise_Without_Answers_Output_Dto()
        {
            var id = ExercisesFixture.IdOne;
            var mockRepo = MockExerciseRepo.GetExerciseByIdRepo(id);
            var mockMapper = MockMapper.GetMockMapperForStartExerciseTest(id);
            var handler = new StartExerciseQueryHandler(mockRepo.Object, mockMapper.Object);

            var result = await handler.Handle(new StartExerciseQuery(id), CancellationToken.None);

            result.ShouldBeOfType(typeof(GetExerciseWithoutAnswersOutputDto));
        }

        [Fact]
        public async Task Set_Fact_Values_Empty_Utility_Should_Set_Fact_Values_Empty()
        {
            //Arrange
            var id = ExercisesFixture.IdOne;
            var mockRepo = MockExerciseRepo.GetExerciseByIdRepo(id);
            var exercise = await mockRepo.Object.GetByIdAsync(id);
            var shouldNotBeEmptyFactValues = 
                exercise!.FactObjects.SelectMany(x => x.Facts
                    .Select(f => new string(f.FactValue)))
                    .ToList();
            //Act
            var result = SetFactValuesToEmptyUtility.SetToEmpty(exercise);

            //Assert
            foreach (var fact in result.FactObjects.SelectMany(x => x.Facts.Select(f => f)))
            {
                fact.FactValue.ShouldBe("");
            }
            foreach (var fact in shouldNotBeEmptyFactValues)
            {
                fact.ShouldNotBe("");
            }
        }
    }
}
