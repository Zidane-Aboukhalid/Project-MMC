using AutoMapper;
using Participant_Speaker.Domain.Identity;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.LinkSms.Mapping
{
	public class LinkSmMappings:Profile
	{
        public LinkSmMappings()
        {
			CreateMap<LinkSm, SelectLinkSm>()
		   .ForMember(des => des.SpeakerId, opt => opt.MapFrom(src => src.SpeakerId))
		   .ForMember(des => des.LinkSmId, opt => opt.MapFrom(src => src.LinkSmId))
		   .ForMember(des => des.Type, opt => opt.MapFrom(src => src.Type))
		   .ForMember(des => des.Url, opt => opt.MapFrom(src => src.Url)).ReverseMap();
		}
    }
}
