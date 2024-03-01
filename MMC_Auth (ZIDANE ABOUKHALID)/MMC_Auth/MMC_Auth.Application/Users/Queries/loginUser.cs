using MediatR;
using MMC_Auth.Domain.models;

namespace MMC_Auth.Application.Users.Queries;

public record loginUser(string Email ,String Password):IRequest<AuthModel>;
