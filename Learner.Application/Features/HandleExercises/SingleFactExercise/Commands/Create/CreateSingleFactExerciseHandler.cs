using AutoMapper;
using Learner.Application.Contracts.Repos;
using Learner.Application.Factories;
using Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create.Dtos;
using Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests;
using MediatR;

namespace Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create;

public class CreateSingleFactExerciseHandler(
    ISingleFactExerciseRepository singleFactExerciseRepository,
    IMapper mapper)
    : IRequestHandler<CreateSingleFactExerciseCommand, CreateSingleFactExerciseOutputDto>
{
    public async Task<CreateSingleFactExerciseOutputDto> Handle(CreateSingleFactExerciseCommand request, CancellationToken cancellationToken)
    {
        var exercise = SingleFactExerciseFactory.Create(request);

        var persistedExercise = await singleFactExerciseRepository.CreateAsync(exercise);

        var dto = mapper.Map<CreateSingleFactExerciseOutputDto>(persistedExercise);

        return dto;
    }
}