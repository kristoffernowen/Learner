using Learner.Application.Factories;
using Learner.Application.Features.HandleExercises.Commands.Create;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Output;
using Learner.Domain.Models;
using Shouldly;

namespace Learner.Application.Tests.ExercisesTests
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

        [Fact]
        public void Should_Return_Int_Facts_When_Fact_Type_Int()
        {
            var intFactWeight = new CreateExerciseFactInputDto()
            {
                FactName = "Vikt",
                FactType = "int",
                FactValue = "200,kg"
            };

            var intFactLength = new CreateExerciseFactInputDto()
            {
                FactName = "Längd",
                FactType = "int",
                FactValue = "250,cm"
            };

            var studyObject = new CreateExerciseFactObjectInputDto()
            {
                Name = "Lejon",
                Facts = [intFactWeight, intFactLength]
            };

            var request = new CreateExerciseCommand
            {
                Name = "Djur",
                FactObjects = [studyObject]
            };

            var result = ExerciseFactory.Create(request);

            var theWeightFact = result.FactObjects.First(x => x.Name == "Lejon").Facts.First(x => x.FactName == "Vikt");
            theWeightFact.ShouldBeOfType(typeof(IntFact));
            theWeightFact.FactValue.ShouldBe("200,kg");
            (theWeightFact as IntFact)?.MeasureUnit.ShouldBe("kg");
            (theWeightFact as IntFact).MeasureUnit.ShouldNotBeNull();
            (theWeightFact as IntFact).IntValue.ShouldBe(200);

            var theLengthFact = result.FactObjects.First(x => x.Name == "Lejon").Facts.First(x => x.FactName == "Längd");
            theLengthFact.ShouldBeOfType(typeof(IntFact));
            theLengthFact.FactValue.ShouldBe("250,cm");
            (theLengthFact as IntFact)?.MeasureUnit.ShouldBe("cm");
            (theLengthFact as IntFact).MeasureUnit.ShouldNotBeNull();
            (theLengthFact as IntFact).IntValue.ShouldBe(250);
        }
    }
}
