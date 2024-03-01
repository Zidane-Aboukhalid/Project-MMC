using AutoMapper;
using Participant_Speaker.Domain.Identity;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.Participants.Mapping
{
	public class ParticipantsMapping:Profile
	{
        public ParticipantsMapping()
        {
			CreateMap<Participant, SelectParticipant>()
		   .ForMember(des => des.ParticipantId, opt => opt.MapFrom(src => src.ParticipantId))
		   .ForMember(des => des.IdUser, opt => opt.MapFrom(src => src.IdUser))
		   .ForMember(des => des.IdSession, opt => opt.MapFrom(src => src.IdSession))
		   .ForMember(des => des.DateJoin, opt => opt.MapFrom(src => src.DateJoin)).ReverseMap();
		}
    }
}
