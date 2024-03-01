using AutoMapper;
using MMCProject.Application.ViewModel.Category;
using MMCProject.Application.ViewModel.SessionTargetAudience;
using MMCProject.Application.ViewModel.SubCategory;
using MMCProject.Application.ViewModel.TargetAudience;
using MMCProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Category,CategoryViewModel>().ReverseMap();   
            CreateMap<Category,OpCategoryViewModel>().ReverseMap();
            CreateMap<Category,OpUpdateCategoryViewModel>().ReverseMap();


            CreateMap<SubCategory,SubCategoryViewModel>().ReverseMap();
            CreateMap<SubCategory, OpSubCategoryViewModel>().ReverseMap();
            CreateMap<SubCategory, OpUpdateSubCategoryViewModel>().ReverseMap();


            CreateMap<TargetAudience,TargetAudienceViewModel>().ReverseMap();
            CreateMap<TargetAudience,OpTargetAudienceViewModel>().ReverseMap();
            CreateMap<TargetAudience,OpUpdateTargetAudienceViewModel>().ReverseMap();

                            
            CreateMap<SessionTargetAudience, SessionTargetAudienceViewModel>().ReverseMap();
            CreateMap<SessionTargetAudience, OpSessionTargetAudienceViewModel>().ReverseMap();
            CreateMap<SessionTargetAudience, OpUpdateSessionTargetAudienceViewModel>().ReverseMap();
        }
    }
}
