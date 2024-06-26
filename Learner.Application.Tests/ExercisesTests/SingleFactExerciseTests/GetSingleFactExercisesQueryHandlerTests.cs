using AutoMapper;
using Learner.Application.Contracts.Repos;
using Learner.Application.Tests.Mocks;
using MediatR;
using Shouldly;

namespace Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests
{
    public class GetSingleFactExercisesQueryHandlerTests
    {
        private readonly GetSingleFactExercisesQuery _request;
        private readonly GetSingleFactExercisesQueryHandler _handler;
        public GetSingleFactExercisesQueryHandlerTests()
        {
            var mockRepo = MockSingleFactExerciseRepo.GetAll();
            var mockMapper = MockSingleFactExerciseMapper.GetMockMapperForGetAllSingleFactExercisesTest();
            _request = new GetSingleFactExercisesQuery();
            _handler = new GetSingleFactExercisesQueryHandler(mockRepo.Object, mockMapper.Object);
        }
        [Fact]
        public async void Should_Return_List_Of_Get_Single_Fact_Exercises_Output_Dtos()
        {
            var result = await _handler.Handle(_request, CancellationToken.None);

            result.Count.ShouldBe(2);
            result.ShouldBeOfType<List<GetSingleFactExercisesOutputDto>>();
        }
        [Fact]
        public async void Should_Return_Dtos_With_Values()
        {
            var result = await _handler.Handle(_request, CancellationToken.None);

            result.ShouldAllBe(x => x.Name == "SingleFactExercise output 1" || x.Name == "SingleFactExercise output 2");
            result.ShouldAllBe(x => x.Id != null);
        }
    }

    public class GetSingleFactExercisesQueryHandler(
        ISingleFactExerciseRepository singleFactExerciseRepository,
        IMapper mapper)
        : IRequestHandler<GetSingleFactExercisesQuery, List<GetSingleFactExercisesOutputDto>>
    {
        public async Task<List<GetSingleFactExercisesOutputDto>> Handle(GetSingleFactExercisesQuery request, CancellationToken cancellationToken)
        {
            var singleFactExercises = await singleFactExerciseRepository.GetAllAsync();

            return mapper.Map<List<GetSingleFactExercisesOutputDto>>(singleFactExercises);
        }
    }

    public record GetSingleFactExercisesQuery : IRequest<List<GetSingleFactExercisesOutputDto>>;

    public class GetSingleFactExercisesOutputDto
    {
        public string Name { get; set; } = null!;
        public string Id { get; set; } = null!;
    }
}
