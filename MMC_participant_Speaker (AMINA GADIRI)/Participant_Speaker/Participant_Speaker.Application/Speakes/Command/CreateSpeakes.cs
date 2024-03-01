using MediatR;
using Microsoft.AspNetCore.Http;

namespace Participant_Speaker.Application.Speakes.Command;

public record CreateSpeakes(
	Guid IdUser,
	bool IsMCT,
	bool IsMVP,
	string Biographi,
	IFormFile FormFile
	) :IRequest<int>;
