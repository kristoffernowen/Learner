using AutoMapper;
using Learner.Application.Contracts.Repos;
using MediatR;

namespace Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests;

public class CreateSingleFactExerciseHandler(
    ISingleFactExerciseRepository singleFactExerciseRepository,
    IMapper mapper)
    : IRequestHandler<CreateSingleFactExerciseCommand, CreateSingleFactExerciseOutputDto>
{
    public async Task<CreateSingleFactExerciseOutputDto> Handle(CreateSingleFactExerciseCommand request, CancellationToken cancellationToken)
    {
        var exercise = SingleFactExerciseFactory.Create(request);

        var persistedExercise = await singleFactExerciseRepository.CreateAsync(exercise);

        return mapper.Map<CreateSingleFactExerciseOutputDto>(persistedExercise);
    }
}