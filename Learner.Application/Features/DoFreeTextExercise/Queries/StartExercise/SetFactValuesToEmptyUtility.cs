using Learner.Domain.Models;

namespace Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise
{
    public class SetFactValuesToEmptyUtility
    {
        public static Exercise SetToEmpty(Exercise exercise)
        {
            foreach (var fact in exercise.FactObjects.SelectMany(factObject => factObject.Facts))
            {
                fact.FactValue = "";
            }

            return exercise;
        }
    }
}
