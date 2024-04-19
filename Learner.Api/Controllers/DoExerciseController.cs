using Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise;
using Learner.Application.Features.HandleExercises.Queries.GetExerciseById;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Learner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoExerciseController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> StartExercise(string id)
        {
            var result = await mediator.Send(new StartExerciseQuery(id));

            return result != null ? Ok(result) : NotFound(id);
        }
    }
}
