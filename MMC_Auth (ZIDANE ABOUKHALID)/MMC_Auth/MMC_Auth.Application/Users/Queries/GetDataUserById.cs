using MediatR;
using MMC_Auth.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC_Auth.Application.Users.Queries;

public record GetDataUserById(string id):IRequest<userData>;
