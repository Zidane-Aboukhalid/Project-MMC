using AutoMapper;
using Participant_Speaker.Domain.Identity;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.SpeakerSessions.Mapping;

public class SpeakerSessionMapping:Profile
{
    public SpeakerSessionMapping()
    {
		CreateMap<SpeakerSession, SelectSpeakerSession>()
		   .ForMember(des => des.SpeakerSessionId, opt => opt.MapFrom(src => src.SpeakerSessionId))
		   .ForMember(des => des.SessionId, opt => opt.MapFrom(src => src.SessionId))
		   .ForMember(des => des.SpeakerId, opt => opt.MapFrom(src => src.SpeakerId))
		   .ForMember(des => des.CreateAt, opt => opt.MapFrom(src => src.CreateAt)).ReverseMap();
	}
}
