using FluentValidation;
using Learner.Application.Features.HandleExercises.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Learner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController(IMediator mediator, IValidator<CreateExerciseCommand> validator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExerciseCommand request)
        {
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }

            var result = await mediator.Send(request);

            return Ok(result);
        }
    }
}
