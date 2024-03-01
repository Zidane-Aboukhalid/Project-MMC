using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.Speakes.Command
{
public record UpdateSpeakes(
	Guid SpeakerID,
	Guid IdUser,
	bool IsMCT,
	bool IsMVP,
	IFormFile File,
	string Biographi) :IRequest<int>;
}
