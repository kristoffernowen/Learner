using FluentValidation;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;
using Learner.Application.Helpers.ConversionHelpers;

namespace Learner.Application.Features.HandleExercises.Commands.Create.FluentValidators;

public class CreateFactInExerciseValidator : AbstractValidator<CreateExerciseFactInputDto>
{
    public CreateFactInExerciseValidator()
    {
        RuleFor(q => q.FactName)
            .MaximumLength(25).WithMessage("{PropertyName} must less than 25")
            .MinimumLength(1).WithMessage("{PropertyName} must be at least 1 character.")
            .NotEmpty()
            .NotNull();
        RuleFor(x => x.FactType)
            .Must(x => x is "string" or "int")
            .WithMessage("types allowed are string and int");
        RuleFor(x => x)
            .Must(TypeOfValueMatchFactValue).WithMessage("FactValue did not match criteria for FactType.");

    }

    private bool TypeOfValueMatchFactValue(CreateExerciseFactInputDto dto)
    {
        return dto.FactType != "int" || FactConversion.CheckIfCanBeConvertedToIntWithApprovedMeasure(dto);
    }
}