using Learner.Application.Features.HandleExercises.SingleFactExercise.Queries.GetById;
using Learner.Application.Tests.Fixtures;
using Learner.Application.Tests.Mocks;
using Shouldly;

namespace Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests
{
    public class GetSingleFactExerciseByIdQueryHandlerTests
    {
        private readonly GetSingleFactExerciseByIdQuery _request;
        private readonly GetSingleFactExerciseByIdQueryHandler _handler;
        private readonly string _id;

        public GetSingleFactExerciseByIdQueryHandlerTests()
        {
            _id = SingleFactExerciseFixture.GetExerciseOneId();
            var mockExerciseRepo = MockSingleFactExerciseRepo.GetById();
            var mockMapper = MockSingleFactExerciseMapper.GetMockMapperForGetSingleFactExerciseByIdTests();
            _request = new GetSingleFactExerciseByIdQuery(_id);
            _handler = new GetSingleFactExerciseByIdQueryHandler(mockExerciseRepo.Object, mockMapper.Object);
        }

        [Fact]
        public async Task Should_Return_One_Get_Exercise_By_Id_Output_Dto_With_Right_Id()
        {
            var result = await _handler.Handle(_request, CancellationToken.None);

            result.ShouldBeOfType(typeof(GetSingleFactExerciseByIdOutputDto));
            result.Id.ShouldBe(_id);
        }

        [Fact]
        public async Task Should_Return_Dto_With_No_Null_Values_Except_Possibly_Additional_Tags()
        {
            var result = await _handler.Handle(_request, CancellationToken.None);

            result.Name.ShouldNotBeNullOrWhiteSpace();
            result.Id.ShouldNotBeNullOrWhiteSpace();
            foreach (var fact in result.Facts)
            {
                fact.Id.ShouldNotBeNullOrWhiteSpace();
                fact.SingleFactExerciseId.ShouldNotBeNullOrWhiteSpace();
                fact.FactName.ShouldNotBeNullOrWhiteSpace();
                fact.FactType.ShouldNotBeNullOrWhiteSpace();
                fact.FactValue.ShouldNotBeNullOrWhiteSpace();
            }
        }
    }
}
