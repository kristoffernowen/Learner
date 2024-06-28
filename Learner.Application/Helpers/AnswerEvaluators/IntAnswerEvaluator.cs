using Learner.Application.Helpers.ConversionHelpers;
using Learner.Domain.Models;

namespace Learner.Application.Helpers.AnswerEvaluators;

public class IntAnswerEvaluator : AnswerEvaluator
{
    public override bool CheckIfAnswersAreEqual(string givenAnswer, BaseFact fact)
    {
        var givenInt = FactConversion.GetIntFromFact(givenAnswer);
        var correctInt = FactConversion.GetIntFromFact(fact.FactValue);
        var givenMeasure = FactConversion.GetMeasureFromFact(givenAnswer);
        var correctMeasure = FactConversion.GetMeasureFromFact(fact.FactValue);
        return givenInt == correctInt && givenMeasure == correctMeasure;
    }

    public bool IsGreaterThanAnswer()
    {
        throw new NotImplementedException();
    }
    public bool IsLesserThanAnswer()
    {
        throw new NotImplementedException();
    }
}