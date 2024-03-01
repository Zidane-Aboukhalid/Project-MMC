using MediatR;
using Participant_Speaker.Domain.Modales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.Participants.Command;

public record AddParticipant(Guid IdUser,Guid IdSession) : IRequest<int>;

