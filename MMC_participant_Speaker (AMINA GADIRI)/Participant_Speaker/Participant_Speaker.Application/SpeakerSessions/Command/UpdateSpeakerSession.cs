using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.SpeakerSessions.Command;

public record UpdateSpeakerSession(
	Guid SpeakerSessionId,
	Guid SessionId,
	Guid SpeakerId
	) :IRequest<int>;

