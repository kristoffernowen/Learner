using Learner.Application.Contracts.Repos;
using Learner.Application.Tests.Fixtures;
using Learner.Application.Tests.Mocks;
using MediatR;
using Shouldly;

namespace Learner.Application.Tests.DoExercisesTests
{
    public class StartSingleFactExerciseQueryHandlerTests
    {
        private readonly StartSingleFactExerciseQueryHandler _handler;
        private readonly StartSingleFactExerciseQuery _query;
        public StartSingleFactExerciseQueryHandlerTests()
        {
            var mockRepo = MockSingleFactExerciseRepo.GetById();
            _query = new StartSingleFactExerciseQuery(SingleFactExerciseFixture.GetExerciseOneId());
            _handler = new StartSingleFactExerciseQueryHandler(mockRepo.Object);
        }
        [Fact]
        public async Task Should_Return_Start_Single_Fact_Exercise_Output_Dto()
        {
            var result = await _handler.Handle(_query, CancellationToken.None);

            result.ShouldBeOfType<StartSingleFactExerciseOutputDto>();
        }

        [Fact]
        public async Task Should_Return_Dto_With_Correct_Values()
        {
            var result = await _handler.Handle(_query, CancellationToken.None);
            result.Id.ShouldBe(SingleFactExerciseFixture.GetExerciseOneId());
            result.Facts.ShouldAllBe(x => x.FactValue == "");
            result.Facts.ShouldAllBe(x => !string.IsNullOrEmpty(x.FactName));
            result.ShouldNotBeNull();
        }
    }

    public record StartSingleFactExerciseQuery(string Id) : IRequest<StartSingleFactExerciseOutputDto>;
    

    

    public class StartSingleFactExerciseQueryHandler(ISingleFactExerciseRepository singleFactExerciseRepository) : IRequestHandler<StartSingleFactExerciseQuery, StartSingleFactExerciseOutputDto>
    {
        public async Task<StartSingleFactExerciseOutputDto> Handle(StartSingleFactExerciseQuery request, CancellationToken cancellationToken)
        {
            var exercise = await singleFactExerciseRepository.GetByIdAsync(request.Id);

            if (exercise is null) throw new NullReferenceException();

            var outputFactsWithoutAnswers = exercise.Facts.Select(x => new StartSingleFactExerciseFactOutputDto
            {
                Id = x.Id,
                FactName = x.FactName,
                FactType = x.FactType,
                FactValue = "",
                AdditionalTags = x.AdditionalTags
            }).ToList();

            return new StartSingleFactExerciseOutputDto
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Facts = outputFactsWithoutAnswers
            };
        }
    }

    public class StartSingleFactExerciseOutputDto
    {
        public string Name { get; set; } = null!;
        public string Id { get; set; } = null!;
        public List<StartSingleFactExerciseFactOutputDto> Facts { get; set; } = [];

    }
    public class StartSingleFactExerciseFactOutputDto
    {
        public string Id { get; set; } = null!;
        public string FactName { get; set; } = null!;
        public string FactType { get; set; } = null!;
        public string FactValue { get; set; } = null!;
        public List<string> AdditionalTags { get; set; } = [];
    }
}
