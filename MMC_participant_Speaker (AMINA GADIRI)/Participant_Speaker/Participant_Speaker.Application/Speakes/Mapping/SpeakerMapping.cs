using AutoMapper;
using Participant_Speaker.Domain.Identity;
using Participant_Speaker.Domain.Modales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.Speakes.Mapping;

public class SpeakerMapping : Profile
{
    public SpeakerMapping()
    {
        CreateMap<Speaker, SelectSpeake>()
            .ForMember(des => des.SpeakerID, opt => opt.MapFrom(src => src.SpeakerID))
            .ForMember(des => des.IdUser, opt => opt.MapFrom(src => src.IdUser))
            .ForMember(des => des.UrlImag, opt => opt.MapFrom(src => src.UrlImag))
			.ForMember(des => des.Biographi, opt => opt.MapFrom(src => src.Biographi))
            .ForMember(des => des.IsMCT, opt => opt.MapFrom(src => src.IsMCT))
            .ForMember(des => des.IsMVP, opt => opt.MapFrom(src => src.IsMVP))
            .ForMember(des => des.CreateAt, opt => opt.MapFrom(src => src.CreateAt)).ReverseMap();



	}
}
