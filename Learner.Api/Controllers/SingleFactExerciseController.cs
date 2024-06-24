using Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create;
using Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Learner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingleFactExerciseController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<CreateSingleFactExerciseOutputDto> Create(CreateSingleFactExerciseCommand request)
        {
            var result = await mediator.Send(request);

            return result;
        }
    }
}
