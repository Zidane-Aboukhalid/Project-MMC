using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.LinkSms.Command;

public record UpdateLinkSm(Guid LinkSmId, Guid SpeakerId, string Url, string Type) : IRequest<int>;
