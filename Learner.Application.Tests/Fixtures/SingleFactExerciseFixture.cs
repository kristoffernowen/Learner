using Learner.Domain.Models;

namespace Learner.Application.Tests.Fixtures
{
    internal static class SingleFactExerciseFixture
    {
        private static readonly List<SingleFactExercise> Exercises =
        [
            new SingleFactExercise
            {
                Name = "SingleFactExercise output 1",
                Id = "2a747159-ce0a-4930-9a12-54bc90be4cac",
                Facts =
                [
                    new SingleFact
                    {
                        Id = "159aa004-db71-4eab-bb1c-42f970f4ceee",
                        FactName = "Fact One",
                        FactType = "string",
                        FactValue = "Value one"
                    },
                    new SingleFact
                    {
                        Id = "d8e1e102-cb7c-444d-93fc-3e4f41791d83",
                        FactName = "Fact Two",
                        FactType = "int",
                        FactValue = "2m"
                    }
                ]
            },
            new SingleFactExercise
            {
                Name = "SingleFactExercise output 2",
                Id = "2aeaf33f-e2a3-4ca3-ac11-9d5006390d4e",
                Facts =
                [
                    new SingleFact
                    {
                        Id = "f8634020-e8c1-46c0-9f43-e62bac92fe42",
                        FactName = "Fact Three",
                        FactType = "string",
                        FactValue = "Value three"
                    },
                    new SingleFact
                    {
                        Id = "eed7bb17-365c-4efe-a528-2a62c7590650",
                        FactName = "Fact Four",
                        FactType = "int",
                        FactValue = "4m"
                    }
                ]
            }
        ];

        internal static List<SingleFactExercise> GetExercises()
        {
            return Exercises;
        }
    }
}
