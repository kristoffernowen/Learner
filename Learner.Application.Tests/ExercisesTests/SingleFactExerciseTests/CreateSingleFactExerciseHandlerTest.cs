using AutoMapper;
using Learner.Application.Contracts.Repos;
using Shouldly;

namespace Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests
{
    public class CreateSingleFactExerciseHandlerTest(
        ISingleFactExerciseRepository singleFactExerciseRepository,
        IMapper mapper)
    {
        [Fact]
        public async Task Should_Return_Create_Single_Fact_Exercise_Output_Dto()
        {
            var handler = new CreateSingleFactExerciseHandler(singleFactExerciseRepository, mapper);
            var request = new CreateSingleFactExerciseCommand
            {
                Name = "Test single fact exercise",
                Facts = new List<CreateSingleFactExerciseFactInputDto>
                {
                    new CreateSingleFactExerciseFactInputDto
                    {
                        FactName = "Test fact one",
                        FactType = "string",
                        FactValue = "Test value one"
                    },
                    new CreateSingleFactExerciseFactInputDto
                    {
                        FactName = "Test fact two",
                        FactType = "int",
                        FactValue = "30 km"
                    }
                }
            };

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<CreateSingleFactExerciseOutputDto>();
            result.Facts.Count.ShouldBeGreaterThan(2);
            result.Facts.ShouldContain(new CreateSingleFactExerciseFactOutputDto()
            {
                FactName = "Test fact two",
                FactType = "int",
                FactValue = "30 km"
            });
        }
    }
}
