using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.Speakes.Command;

public record DeleteSpeakes(Guid Id):IRequest<int>;

