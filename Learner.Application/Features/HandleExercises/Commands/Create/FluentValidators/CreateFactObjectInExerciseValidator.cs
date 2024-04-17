using FluentValidation;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;

namespace Learner.Application.Features.HandleExercises.Commands.Create.FluentValidators;

public class CreateFactObjectInExerciseValidator : AbstractValidator<CreateExerciseFactObjectInputDto>
{
    public CreateFactObjectInExerciseValidator()
    {
        RuleFor(q => q.Name)
            .MaximumLength(25).WithMessage("{PropertyName} must less than 25");
        RuleForEach(q => q.Facts)
            .SetValidator(new CreateFactInExerciseValidator());
    }
}