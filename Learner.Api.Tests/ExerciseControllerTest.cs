using FluentValidation;
using FluentValidation.Results;
using Learner.Api.Controllers;
using Learner.Application.Features.HandleExercises.Commands.Create;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Output;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;

namespace Learner.Api.Tests
{
    public class ExerciseControllerTest
    {
        private readonly ExerciseController _controller;
        private readonly Mock<IValidator<CreateExerciseCommand>> _validator;
        private readonly Mock<IMediator> _mediator;
        private readonly CreateExerciseCommand _request;

        public ExerciseControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _validator = new Mock<IValidator<CreateExerciseCommand>>();
            _controller = new ExerciseController(_mediator.Object, _validator.Object);
            _request = new CreateExerciseCommand();
            var outPutDto = new CreateExerciseOutputDto();

            _mediator.Setup(x => x.Send(_request, CancellationToken.None)).ReturnsAsync(outPutDto);
        }

        [Fact]
        
        public async Task Should_Call_Mediator_When_Valid()
        {
            _validator.Setup(v => v.ValidateAsync(_request, CancellationToken.None))
                .ReturnsAsync(new ValidationResult());
            
            await _controller.Create(_request);

            _mediator.Verify(x => x.Send(_request, CancellationToken.None), Times.Exactly(1));
        }

        [Fact]
        public async Task Should_Not_Call_Mediator_When_Invalid()
        {
            _validator.Setup(v => v.ValidateAsync(_request, CancellationToken.None))
                .ReturnsAsync(new ValidationResult(){Errors = new List<ValidationFailure>(){new ValidationFailure(){PropertyName = "FactName", ErrorMessage = "must be something"}}});

            await _controller.Create(_request);

            _mediator.Verify(x => x.Send(_request, CancellationToken.None), Times.Exactly(0));
        }

        [Fact]
        public async Task Should_Return_Bad_Request_Object_Result()
        {
            _validator.Setup(v => v.ValidateAsync(_request, CancellationToken.None))
                .ReturnsAsync(new ValidationResult() { Errors = new List<ValidationFailure>() { new ValidationFailure() { PropertyName = "FactName", ErrorMessage = "must be something" } } });

            var result = await _controller.Create(_request);

            result.ShouldBeOfType(typeof(BadRequestObjectResult));
        }
    }
}
