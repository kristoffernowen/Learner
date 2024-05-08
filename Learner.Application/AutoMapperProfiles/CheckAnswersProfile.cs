using AutoMapper;
using Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers.Dtos;
using Learner.Domain.Models.Results;

namespace Learner.Application.AutoMapperProfiles
{
    public class CheckAnswersProfile : Profile
    {
        public CheckAnswersProfile()
        {
            CreateMap<ResultPerExercise, CheckAnswersRequestOutputDto>();
            CreateMap<ResultPerFactObject, ResultPerFactObjectOutputDto>();
            CreateMap<ResultPerFact, ResultPerFactOutputDto>();
        }
    }
}
