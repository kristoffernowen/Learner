using Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create;
using Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create.Dtos;
using Learner.Application.Features.HandleExercises.SingleFactExercise.Queries.GetAll;
using Learner.Application.Features.HandleExercises.SingleFactExercise.Queries.GetById;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await mediator.Send(new GetSingleFactExerciseByIdQuery(id));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetSingleFactExercisesQuery());

            return Ok(result);
        }
    }
}
