using Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise.Dtos;
using Learner.Domain.Models;
using MediatR;

namespace Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise;

public record StartExerciseQuery(string Id) : IRequest<GetExerciseWithoutAnswersOutputDto>;