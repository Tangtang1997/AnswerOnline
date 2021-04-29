using AnswerOnline.Domain.Entities.Participants;
using AutoMapper;

namespace AnswerOnline.Application.Participants.Dto
{
    public class ParticipantMapperProfile : Profile
    {
        public ParticipantMapperProfile()
        {
            CreateMap<Participant, ParticipantTopDto>()
                .ForMember(d => d.Score, o => o.MapFrom(s => s.HighestScore));
        }
    }
}