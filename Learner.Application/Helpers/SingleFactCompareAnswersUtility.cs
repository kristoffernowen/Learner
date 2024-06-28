using System.Reflection;
using Learner.Application.Helpers.AnswerEvaluators;
using Learner.Domain.Models;

namespace Learner.Application.Helpers;

public static class SingleFactCompareAnswersUtility
{
    public static bool AnswersAreEqual(string givenAnswer, BaseFact fact)
    {
        var evaluator = GetAnswerEvaluator(fact.FactType);
        var result = evaluator.CheckIfAnswersAreEqual(givenAnswer, fact);
        
        return result;
    }

    private static AnswerEvaluator GetAnswerEvaluator(string factType)
    {
        factType = char.ToUpper(factType[0]) + factType[1..].ToLower();
        var evaluatorNamespace = typeof(AnswerEvaluator).Namespace;
        var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        var evaluatorTypeName = $"{evaluatorNamespace}.{factType}{nameof(AnswerEvaluator)}, {assemblyName}";
        var type = Type.GetType(evaluatorTypeName);
        if (type == null)
        {
            throw new ArgumentException($"Type '{evaluatorTypeName}' not found. Are the evaluator for {factType} still kept in" +
                                        $" the same folder as {nameof(AnswerEvaluator)}, because they must share the same namespace?");
        }
        var evaluatorAsObject = Activator.CreateInstance(type);
        if (evaluatorAsObject is not AnswerEvaluator evaluator)
        {
            throw new InvalidCastException($"Cannot cast '{evaluatorTypeName}' to AnswerEvaluator");
        }
        return evaluator;
    }
}