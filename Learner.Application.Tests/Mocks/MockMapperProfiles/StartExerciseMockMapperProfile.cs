using Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise.Dtos;
using Learner.Domain.Models;

namespace Learner.Application.Tests.Mocks.MockMapperProfiles
{
    public class StartExerciseMockMapperProfile
    {
        public static GetExerciseWithoutAnswersOutputDto GetMappedExerciseDto(Exercise exercise)
        {
            var mappedExercise = new GetExerciseWithoutAnswersOutputDto()
            {
                FactObjects = new List<GetExerciseWithoutAnswersFactObjectOutputDto>()
                {
                    new GetExerciseWithoutAnswersFactObjectOutputDto()
                    {
                        Facts = new List<GetExerciseWithoutAnswersFactOutputDto>()
                        {
                            new GetExerciseWithoutAnswersFactOutputDto()
                            {
                                FactValue = "FactInObject One"
                            },
                            new GetExerciseWithoutAnswersFactOutputDto()
                            {
                                FactValue = "FactInObject Two"
                            }
                        }
                    },
                    new GetExerciseWithoutAnswersFactObjectOutputDto()
                    {
                        Facts = new List<GetExerciseWithoutAnswersFactOutputDto>()
                        {
                            new GetExerciseWithoutAnswersFactOutputDto()
                            {
                                FactValue = "FactInObject Three"
                            },
                            new GetExerciseWithoutAnswersFactOutputDto()
                            {
                                FactValue = "FactInObject Four"
                            }
                        }
                    }
                }
            };

            return mappedExercise;
        }
    }
}
