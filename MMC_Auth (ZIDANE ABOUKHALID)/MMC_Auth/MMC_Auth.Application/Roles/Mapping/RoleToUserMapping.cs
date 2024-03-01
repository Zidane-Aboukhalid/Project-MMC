using AutoMapper;
using MMC_Auth.Application.Roles.Command;
using MMC_Auth.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC_Auth.Application.Roles.Mapping;

public class RoleToUserMapping:Profile
{
    public RoleToUserMapping()
    {
        CreateMap<AddRoleToUser, RolesToUserModel>()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(des => des.Role, opt => opt.MapFrom(src => src.RoleName));
			
    }
}
