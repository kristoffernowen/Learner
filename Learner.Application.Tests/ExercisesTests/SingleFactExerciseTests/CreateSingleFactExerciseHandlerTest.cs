using Learner.Application.Tests.Mocks;
using Learner.Domain.Models;
using Shouldly;

namespace Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests
{
    public class CreateSingleFactExerciseHandlerTest
    {
        private readonly CreateSingleFactExerciseHandler _handler;
        private readonly CreateSingleFactExerciseCommand _request;

        public CreateSingleFactExerciseHandlerTest()
        {
            var repo = MockSingleFactExerciseRepo.Create(new SingleFactExercise());
            var mapper = MockSingleFactExerciseMapper.GetMockMapperForCreateSingleFactExerciseTest();
            _handler = new CreateSingleFactExerciseHandler(repo.Object, mapper.Object);
            _request = new CreateSingleFactExerciseCommand
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
        }
        [Fact]
        public async Task Should_Return_Create_Single_Fact_Exercise_Output_Dto()
        {
            var result = await _handler.Handle(_request, CancellationToken.None);

            result.ShouldBeOfType<CreateSingleFactExerciseOutputDto>();
            result.Facts.Count.ShouldBeGreaterThan(1);
            result.Facts.ShouldContain(x => x.FactName == "Test fact two" && 
                                            x.FactType == "int" && 
                                            x.FactValue == "30 km");
        }

        [Fact]
        public async Task Should_Throw_Exception()
        {
            var request = _request;
            request.Facts[1].FactValue = "km30";

            var exception = await Should.ThrowAsync<ArgumentException>(async () =>
            {
                await _handler.Handle(request, CancellationToken.None);
            });

            exception.Message.ShouldBe($"Value not allowed for {nameof(SingleFact)} with FactType int," +
                                       " failed to convert to int number and string measure");
        }
    }
}
