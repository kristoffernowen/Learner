using Learner.Application.Factories;
using Learner.Application.Features.HandleExercises.Commands.Create;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;
using Shouldly;

namespace Learner.Application.Tests
{
    public class ExerciseFactoryTests
    {
        [Fact]
        public void Should_Return_Exercise_That_Is_Populated()
        {
            //Arrange
            var factOne = new CreateExerciseFactInputDto()
            {
                FactName = "Namn",
                FactType = "string",
                FactValue = "Tolkien"
            };

            var studyObjectOne = new CreateExerciseFactObjectInputDto()
            {
                Name = "Tolkien",
                Facts = new List<CreateExerciseFactInputDto>()
                {
                    factOne
                }
            };
            var request = new CreateExerciseCommand()
            {
                Name = "Författare",
                FactObjects = new List<CreateExerciseFactObjectInputDto>()
                {
                    studyObjectOne
                }
            };

            //Act
            var result = ExerciseFactory.Create(request);


            //Assert
            result.Name.ShouldBe(request.Name);
            result.FactObjects.ShouldNotBeEmpty();

            if (!result.FactObjects.Any()) return;
            foreach (var factObject in result.FactObjects)
            {
                factObject.Facts.ShouldNotBeEmpty();
            }
        }
    }
}
