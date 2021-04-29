using AnswerOnline.Domain.Entities.Questions;
using AutoMapper;

namespace AnswerOnline.Application.Questions.Dto
{
    public class QuestionMapperProfile : Profile
    {
        public QuestionMapperProfile()
        {
            CreateMap<Question, QuestionDto>();

            CreateMap<QuestionChoiceOption, QuestionChoiceOptionDto>();
        }
    }
}