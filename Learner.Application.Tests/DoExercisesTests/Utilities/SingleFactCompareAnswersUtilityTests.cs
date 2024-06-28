using Learner.Application.Helpers;
using Learner.Application.Tests.Fixtures;
using Shouldly;

namespace Learner.Application.Tests.DoExercisesTests.Utilities
{
    public class SingleFactCompareAnswersUtilityTests
    {
        [Fact]
        public void Should_Return_True_If_Answers_Are_Identical()
        {
            var exerciseOne = SingleFactExerciseFixture.GetExercises()
                .First(x => x.Id == SingleFactExerciseFixture.GetExerciseOneId());
            var factOne = exerciseOne.Facts[0];
            var factTwo = exerciseOne.Facts[1];

            var resultOne = SingleFactCompareAnswersUtility.AnswersAreEqual("Value one", factOne);
            var resultTwo = SingleFactCompareAnswersUtility.AnswersAreEqual("2m", factTwo);

            resultOne.ShouldBeTrue();
            resultTwo.ShouldBeTrue();
        }
    }
}
