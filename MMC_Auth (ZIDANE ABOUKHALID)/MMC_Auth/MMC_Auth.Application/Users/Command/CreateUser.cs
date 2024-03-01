using MediatR;
using MMC_Auth.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC_Auth.Application.Users.Command;

public record CreateUser(string fullname , string username , string email , string password):IRequest<AuthModel>;

