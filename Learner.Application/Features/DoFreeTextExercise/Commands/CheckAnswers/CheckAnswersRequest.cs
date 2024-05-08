using Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers.Dtos;
using MediatR;

namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers;

public record CheckAnswersRequest : IRequest<CheckAnswersRequestOutputDto>
{
    public string Id { get; set; } = null!;
    public List<CheckAnswersFactInputDto> AnswersPerFact { get; set; } = [];
}