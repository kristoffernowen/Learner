using Learner.Domain.Models;

namespace Learner.Application.Tests.Fixtures
{
    public static class ExercisesFixture
    {
        private static readonly List<Exercise> Exercises =
        [
            new Exercise()
            {
                Id = IdOne,
                Name = "Exercise one",
                FactObjects =
                [
                    new FactObject()
                    {
                        Id = "dd026425-9209-4254-8d1b-28b43f78ca61",
                        Name = "Fact Object One",
                        ExerciseId = IdOne,
                        Facts =
                        [
                            new()
                            {
                                FactName = "Name",
                                FactType = "string",
                                FactValue = "Fact One",
                                Id = "178057a5-f00e-4b1f-a4d4-8ea3e57859bd",
                                FactObjectId = "dd026425-9209-4254-8d1b-28b43f78ca61"
                            },
                            new()
                            {
                                FactName = "Size",
                                FactType = "string",
                                FactValue = "Big",
                                Id = "2bb52b30-a4c4-4bd8-932e-2e5ce7d32598",
                                FactObjectId = "dd026425-9209-4254-8d1b-28b43f78ca61"
                            }
                        ]
                    },
                    new FactObject()
                    {
                        Id = "d1854772-faa1-4f59-bc1f-8fcccc545efc",
                        Name = "Fact Object Two",
                        ExerciseId = IdOne,
                        Facts =
                        [
                            new()
                            {
                                FactName = "Name",
                                FactType = "string",
                                FactValue = "Fact Two",
                                Id = "2bfbf68e-50fc-4022-bfac-86dece465b8e",
                                FactObjectId = "d1854772-faa1-4f59-bc1f-8fcccc545efc"
                            },
                            new()
                            {
                                FactName = "Size",
                                FactType = "string",
                                FactValue = "Small",
                                Id = "b95d58dc-b9f0-4e10-b4b6-2b65110f1826",
                                FactObjectId = "d1854772-faa1-4f59-bc1f-8fcccc545efc"
                            }
                        ]
                    }
                ]
            },

            new Exercise()
            {
                Id = IdTwo,
                Name = "Exercise Two",
                FactObjects =
                [
                    new FactObject()
                    {
                        Id = "ee46f0e1-6735-4b5a-9ec1-0c77a3e61fd1",
                        Name = "Fact Object Three",
                        ExerciseId = IdTwo,
                        Facts =
                        [
                            new()
                            {
                                FactName = "Name",
                                FactType = "string",
                                FactValue = "Fact Three",
                                Id = "178057a5-f00e-4b1f-a4d4-8ea3e57859bd",
                                FactObjectId = "ee46f0e1-6735-4b5a-9ec1-0c77a3e61fd1"
                            },
                            new()
                            {
                                FactName = "Size",
                                FactType = "string",
                                FactValue = "Big",
                                Id = "2bb52b30-a4c4-4bd8-932e-2e5ce7d32598",
                                FactObjectId = "ee46f0e1-6735-4b5a-9ec1-0c77a3e61fd1"
                            }
                        ]
                    },
                    new FactObject()
                    {
                        Id = "45348ea3-dbda-4cda-a8a8-4663fbbf9e72",
                        Name = "Fact Object Four",
                        ExerciseId = IdTwo,
                        Facts =
                        [
                            new()
                            {
                                FactName = "Name",
                                FactType = "string",
                                FactValue = "Fact Four",
                                Id = "4b5fed66-42df-4b89-aee3-dfcc3b388dd1",
                                FactObjectId = "45348ea3-dbda-4cda-a8a8-4663fbbf9e72"
                            },
                            new()
                            {
                                FactName = "Size",
                                FactType = "string",
                                FactValue = "Small",
                                Id = "582a8154-2b2f-415c-b251-863771bc0fa8",
                                FactObjectId = "45348ea3-dbda-4cda-a8a8-4663fbbf9e72"
                            }
                        ]
                    }
                ]
            }
        ];

        public static string IdOne => "93805e57-572b-48dc-87d9-44db3e3ea6ef";
        public static string IdTwo => "2dbf88fc-0f15-4dd7-88b9-56dbccadb762";

        public static List<Exercise> GetExercises()
        {
            return Exercises;
        }
    }

}
