﻿using MediatR;
using Participant_Speaker.Domain.Modales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.LinkSms.Queries;

public record GetLinkSmsBySpeaker(Guid id):IRequest<List<SelectLinkSm>>;
