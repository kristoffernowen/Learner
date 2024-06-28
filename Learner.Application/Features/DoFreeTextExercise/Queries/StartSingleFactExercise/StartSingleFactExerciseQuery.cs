using Learner.Application.Features.DoFreeTextExercise.Queries.StartSingleFactExercise.Dtos;
using MediatR;

namespace Learner.Application.Features.DoFreeTextExercise.Queries.StartSingleFactExercise;

public record StartSingleFactExerciseQuery(string Id) : IRequest<StartSingleFactExerciseOutputDto>;