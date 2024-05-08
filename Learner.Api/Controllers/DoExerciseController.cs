using Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers;
using Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Learner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoExerciseController(IMediator mediator) : ControllerBase
    {
        
        [HttpGet("StartExercise/{id}")]
        public async Task<IActionResult> StartExercise(string id)
        {
            var result = await mediator.Send(new StartExerciseQuery(id));

            return result != null ? Ok(result) : NotFound(id);
        }

        
        [HttpPost("CheckAnswers")]
        public async Task<IActionResult> CheckAnswers([FromBody] CheckAnswersRequest request)
        {
            var result = await mediator.Send(request);

            return result != null ? Ok(result) : BadRequest();
        }
    }
}
