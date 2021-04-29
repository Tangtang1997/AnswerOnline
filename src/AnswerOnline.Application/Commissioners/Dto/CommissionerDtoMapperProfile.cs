using AnswerOnline.Domain.Entities.Commissioners;
using AutoMapper;

namespace AnswerOnline.Application.Commissioners.Dto
{
    public class CommissionerDtoMapperProfile : Profile
    {
        public CommissionerDtoMapperProfile()
        {
            CreateMap<Commissioner, CommissionerDto>();
        }
    }
}