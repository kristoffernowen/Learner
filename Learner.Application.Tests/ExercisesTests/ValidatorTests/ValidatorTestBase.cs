using FluentValidation;
using FluentValidation.TestHelper;

namespace Learner.Application.Tests.ExercisesTests.ValidatorTests
{
    public abstract class ValidatorTestBase<TModel>
    {
        //courtesy Karoly Ozsvart unit testing in validators in c# 20240618
        protected abstract TModel CreateValidObject();

        protected TestValidationResult<TModel> Validate(Action<TModel> mutate)
        {
            var model = CreateValidObject();
            mutate(model);
            var validator = CreateValidator();

            return validator.TestValidate(model);
        }

        protected abstract IValidator<TModel> CreateValidator();
    }
}
