using Application.DTO;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public  class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles() 
        { 
            CreateMap<Event,EventDto>().ReverseMap();
            CreateMap<EventDto, Event>().ReverseMap();

            CreateMap<Event, AddEventDto>().ReverseMap();
            CreateMap<AddEventDto, Event>().ReverseMap();
           

            CreateMap<SessionDto, Session>().ReverseMap();
            CreateMap<Session, SessionDto>().ReverseMap();

            CreateMap<AddSessionDto, Session>().ReverseMap();
            CreateMap<Session, AddSessionDto>().ReverseMap();

        }
    }
}
