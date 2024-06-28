using Learner.Application.Features.DoFreeTextExercise.Commands.CheckSingleFactExerciseAnswers.Dtos;
using MediatR;

namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckSingleFactExerciseAnswers;

public record CheckAnswersSingleFactExerciseQuery : IRequest<CheckAnswersSingleFactExerciseResultOutputDto>
{
    public string Id { get; set; } = null!;
    public List<CheckAnswersSingleFactExerciseFactInputDto> AnswersPerFact { get; set; } = null!;
}