using FluentValidation;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;

namespace Learner.Application.Features.HandleExercises.Commands.Create.FluentValidators;

public class CreateFactInExerciseValidator : AbstractValidator<CreateExerciseFactInputDto>
{
    public CreateFactInExerciseValidator()
    {
        RuleFor(q => q.FactName)
            .MaximumLength(25).WithMessage("{PropertyName} must less than 25");
    }
}