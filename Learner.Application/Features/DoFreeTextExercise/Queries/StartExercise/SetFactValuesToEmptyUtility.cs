using Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise.Dtos;
using Learner.Domain.Models;

namespace Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise
{
    public class SetFactValuesToEmptyUtility
    {
        public static GetExerciseWithoutAnswersOutputDto SetToEmpty(GetExerciseWithoutAnswersOutputDto exercise)
        {
            foreach (var fact in exercise.FactObjects.SelectMany(factObject => factObject.Facts))
            {
                fact.FactValue = "";
            }

            return exercise;
        }
    }
}
