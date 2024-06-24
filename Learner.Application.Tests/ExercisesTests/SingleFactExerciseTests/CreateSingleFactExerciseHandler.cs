using AutoMapper;
using MediatR;

namespace Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests;

public class CreateSingleFactExerciseHandler : IRequestHandler<CreateSingleFactExerciseCommand, CreateSingleFactExerciseOutputDto>
{
    private readonly ISingleFactExerciseRepository _singleFactExerciseRepository;
    private readonly IMapper _mapper;

    public CreateSingleFactExerciseHandler(ISingleFactExerciseRepository singleFactExerciseRepository, IMapper mapper)
    {
        _singleFactExerciseRepository = singleFactExerciseRepository;
        _mapper = mapper;
    }
    public async Task<CreateSingleFactExerciseOutputDto> Handle(CreateSingleFactExerciseCommand request, CancellationToken cancellationToken)
    {
        

        var exercise = SingleFact.Create(request);

        var persistedExercise = await _singleFactExerciseRepository.Create(exercise);

        return _mapper.Map<CreateSingleFactExerciseOutputDto>(persistedExercise);
    }
}