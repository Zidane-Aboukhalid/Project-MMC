using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC_Auth.Application.Roles.Command;

public record AddRoleToUser(Guid id , string RoleName):IRequest<string>;
