using AutoMapper;
using Learner.Application.Contracts.Repos;
using Learner.Application.Features.HandleExercises.Queries.GetExercises;
using Learner.Domain.Models;
using Moq;
using Shouldly;

namespace Learner.Application.Tests.Exercises
{
    public class GetExercisesQueryHandlerTest
    {
        private readonly GetExercisesQuery _request;
        private readonly GetExercisesQueryHandler _handler;

        public GetExercisesQueryHandlerTest()
        {
            Mock<IExerciseRepository> mockExerciseRepo = new();
            Mock<IMapper> mockMapper = new();
            _request = new GetExercisesQuery();
            _handler = new GetExercisesQueryHandler(mockExerciseRepo.Object, mockMapper.Object);
            var listOfExercisesForMock = new List<Exercise>();
            mockExerciseRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(listOfExercisesForMock);
            mockMapper.Setup(x => x.Map<List<GetExercisesOutputDto>>(listOfExercisesForMock))
                .Returns(
                [
                    new GetExercisesOutputDto()
                        {Id = Guid.NewGuid().ToString(), Name = "Mock output"},

                    new GetExercisesOutputDto()
                        {Id = Guid.NewGuid().ToString(), Name = "Mock output 2"}
                ]);
        }

        [Fact]
        public async Task Should_Return_List_Get_Exercises_Output_Dto()
        {
            var result = await _handler.Handle(_request, CancellationToken.None);

            result.Count.ShouldBe(2);
            result.ShouldAllBe(x => x.GetType() == typeof(GetExercisesOutputDto));
        }

        [Fact]
        public async Task Should_Return_Dtos_With_Values()
        {
            var result = await _handler.Handle(_request, CancellationToken.None);

            result.ShouldAllBe(x => x.Name == "Mock output" || x.Name == "Mock output 2");
            result.ShouldAllBe(x => x.Id != null);
        }
    }
}
