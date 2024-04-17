using AutoMapper;
using Learner.Application.Contracts.Repos;
using Learner.Application.Factories;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Output;
using MediatR;

namespace Learner.Application.Features.HandleExercises.Commands.Create
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, CreateExerciseOutputDto>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public CreateExerciseCommandHandler(
            IExerciseRepository exerciseRepository,
            IMapper mapper
            )
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }
        public async Task<CreateExerciseOutputDto> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = ExerciseFactory.Create(request);

            var persistedExercise = await _exerciseRepository.CreateAsync(exercise);

            var outputDto = _mapper.Map<CreateExerciseOutputDto>(persistedExercise);

            return outputDto;
        }
    }
}
