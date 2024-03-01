using MediatR;
namespace MMC_Auth.Application.Users.Queries;

public record GetCountUsers():IRequest<int>;
