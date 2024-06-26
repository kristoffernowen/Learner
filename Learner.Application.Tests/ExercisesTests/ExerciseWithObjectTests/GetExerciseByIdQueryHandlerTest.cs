using Learner.Application.Features.HandleExercises.Queries.GetExerciseById;
using Learner.Application.Features.HandleExercises.Queries.GetExerciseById.Dtos;
using Learner.Application.Tests.Fixtures;
using Learner.Application.Tests.Mocks;
using Shouldly;

namespace Learner.Application.Tests.ExercisesTests.ExerciseWithObjectTests
{
    public class GetExerciseByIdQueryHandlerTest
    {
        private readonly GetExerciseByIdQuery _request;
        private readonly GetExerciseByIdQueryHandler _handler;
        private readonly string _id;

        public GetExerciseByIdQueryHandlerTest()
        {
            _id = ExercisesFixture.IdOne;
            var mockExerciseRepo = MockExerciseRepo.GetExerciseByIdRepo(_id);
            var mockMapper = MockMapper.GetMockMapperForGetExerciseByIdRequestHandlerTest(_id);
            _request = new GetExerciseByIdQuery(_id);
            _handler = new GetExerciseByIdQueryHandler(mockExerciseRepo.Object, mockMapper.Object);
        }

        [Fact]
        public async Task Should_Return_One_Get_Exercise_By_Id_Output_Dto_With_Right_Id()
        {
            var result = await _handler.Handle(_request, CancellationToken.None);

            result.ShouldBeOfType(typeof(GetExerciseByIdOutputDto));
            result.Id.ShouldBe(_id);
        }
    }
}
