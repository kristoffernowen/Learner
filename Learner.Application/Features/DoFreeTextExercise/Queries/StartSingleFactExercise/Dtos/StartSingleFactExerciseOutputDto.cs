namespace Learner.Application.Features.DoFreeTextExercise.Queries.StartSingleFactExercise.Dtos;

public class StartSingleFactExerciseOutputDto
{
    public string Name { get; set; } = null!;
    public string Id { get; set; } = null!;
    public List<StartSingleFactExerciseFactOutputDto> Facts { get; set; } = [];

}