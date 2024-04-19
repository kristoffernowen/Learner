using Learner.Application.Features.HandleExercises.Queries.GetExerciseById;
using Learner.Application.Features.HandleExercises.Queries.GetExerciseById.Dtos;
using Learner.Application.Tests.Fixtures;
using Learner.Application.Tests.Mocks;
using Shouldly;

namespace Learner.Application.Tests.ExercisesTests
{
    public class GetExerciseByIdQueryHandlerTest
    {
        private readonly GetExerciseByIdQuery _request;
        private readonly GetExerciseByIdQueryHandler _handler;

        public GetExerciseByIdQueryHandlerTest()
        {
            var id = ExercisesFixture.IdOne;
            var mockExerciseRepo = MockExerciseRepo.GetExerciseByIdRepo(id);
            var mockMapper = MockMapper.GetMockMapperForGetExerciseByIdRequestHandlerTest(id);
            _request = new GetExerciseByIdQuery(id);
            _handler = new GetExerciseByIdQueryHandler(mockExerciseRepo.Object, mockMapper.Object);
        }

        [Fact]
        public async Task Should_Return_One_Get_Exercise_By_Id_Output_Dto_With_Right_Id()
        {
            var result = await _handler.Handle(_request, CancellationToken.None);

            result.ShouldBeOfType(typeof(GetExerciseByIdOutputDto));
            result.Id.ShouldBe(ExercisesFixture.IdOne); 
        }
    }
}
