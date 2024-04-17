using FluentValidation;

namespace Learner.Application.Features.HandleExercises.Commands.Create.FluentValidators
{
    public class CreateExerciseCommandValidator : AbstractValidator<CreateExerciseCommand>
    {
        public CreateExerciseCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} must be fewer than 25 characters");

            RuleFor(p => p)
                .Must(MustNotHaveNameHerbert)
                .WithMessage("Not Herbert in name");

            RuleForEach(q => q.FactObjects)
                .SetValidator(new CreateFactObjectInExerciseValidator());
        }

        private static bool MustNotHaveNameHerbert(CreateExerciseCommand request)
        {
            // stupid example to explore
            if (request.Name == "Herbert")
            {
                throw new Exception("No Herbert");
            }

            return true;
        }
    }
}
