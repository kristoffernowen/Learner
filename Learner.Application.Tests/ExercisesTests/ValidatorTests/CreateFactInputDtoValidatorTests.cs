using FluentValidation;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;
using Learner.Application.Features.HandleExercises.Commands.Create.FluentValidators;

namespace Learner.Application.Tests.ExercisesTests.ValidatorTests
{
    public class CreateFactInputDtoValidatorTests : ValidatorTestBase<CreateExerciseFactInputDto>
    {
        [Fact]
        public void Validator_Should_Accept_Fact_Value_When_Fact_Type_Int_If_Convertible()
        {
            var result = Validate(Mutation);
            result.ShouldNotHaveValidationErrorFor(x => x);
            return;

            static void Mutation(CreateExerciseFactInputDto x) {}
        }
        [Theory]
        [InlineData("")]
        [InlineData("ca 70 kg")]
        [InlineData("kg 70")]
        public void Validator_Should_Set_Error_When_Fact_Type_Int_Fact_Value_Not_Convertible_To_Int_With_Helper(string factValue)
        {
            //Action<CreateExerciseFactInputDto> mutation = x => x.FactValue = factValue; resharper suggests local function instead

            var result = Validate(Mutation);

            result.ShouldHaveValidationErrorFor(x => x);
            return;

            void Mutation(CreateExerciseFactInputDto x) => x.FactValue = factValue;
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Validator_Should_Set_Error_If_FactName_Is_Empty(string factName)
        {
            var result = Validate(Mutation);

            result.ShouldHaveValidationErrorFor(x => x.FactName);
            return;

            void Mutation(CreateExerciseFactInputDto x) => x.FactName = factName;
        }

        protected override CreateExerciseFactInputDto CreateValidObject()
        {
            return new()
            {
                FactName = "Vikt",
                FactType = "int",
                FactValue = "25kg"
            };
        }

        protected override IValidator<CreateExerciseFactInputDto> CreateValidator()
        {
            return new CreateFactInExerciseValidator();
        }
    }
}
