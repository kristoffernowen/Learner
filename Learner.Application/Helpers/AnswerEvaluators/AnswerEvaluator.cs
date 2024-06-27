using Learner.Domain.Models;

namespace Learner.Application.Helpers.AnswerEvaluators;

public abstract class AnswerEvaluator
{
    public virtual bool CheckIfAnswersAreEqual(string givenAnswer, BaseFact fact)
    {
        var result = givenAnswer == fact.FactValue;
        return result;
    }
}