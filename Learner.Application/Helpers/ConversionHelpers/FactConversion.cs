using System.Text.RegularExpressions;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;

namespace Learner.Application.Helpers.ConversionHelpers
{
    public static class FactConversion
    {
        private static readonly List<string> AllowedMeasures = ["mm", "cm", "dm", "m", "km", "g", "kg"];
        public static bool CheckIfCanBeConvertedToIntWithApprovedMeasure(ICreateExerciseFactInputDto dto)
        {
            var intendedInt = GetIntFromFact(dto.FactValue);
            if (intendedInt == null)
                return false;

            var measure = GetMeasureFromFact(dto.FactValue);
            return AllowedMeasures.Contains(measure);
        }

        public static int? GetIntFromFact(string factValue)
        {
            var factValueWithoutWhitespace = RemoveWhitespace(factValue);
            var indexMeasureStart = GetIndexOfMeasure(factValueWithoutWhitespace);
            var intendedNumber = factValueWithoutWhitespace[..indexMeasureStart];
            return int.TryParse(intendedNumber, out var numberAsInt) ? numberAsInt : null;
        }

        public static string GetMeasureFromFact(string factValue)
        {
            var factValueWithoutWhitespace = RemoveWhitespace(factValue);
            var indexMeasureStart = GetIndexOfMeasure(factValueWithoutWhitespace);
            return factValueWithoutWhitespace[indexMeasureStart..];
        }

        private static string RemoveWhitespace(string factValue)
        {
            var removeWhiteSpaceRegex = new Regex(@"\s+");
            return removeWhiteSpaceRegex.Replace(factValue, "");
        }
        private static int GetIndexOfMeasure(string factValue)
        {
            var charDigits = factValue.TakeWhile(char.IsDigit);
            return charDigits.Count();
        }
    }
}
