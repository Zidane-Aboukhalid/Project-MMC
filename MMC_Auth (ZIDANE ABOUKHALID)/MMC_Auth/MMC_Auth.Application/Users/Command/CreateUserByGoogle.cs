using MediatR;
using MMC_Auth.Domain.models;

namespace MMC_Auth.Application.Users.Command
{
	public  record  CreateUserByGoogle(string fullname, string username, string email) :IRequest<AuthModel>;
}
