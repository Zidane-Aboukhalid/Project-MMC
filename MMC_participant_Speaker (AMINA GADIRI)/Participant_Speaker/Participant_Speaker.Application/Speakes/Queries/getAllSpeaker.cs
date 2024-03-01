﻿using MediatR;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.Speakes.Queries;

public record getAllSpeaker():IRequest<List<SelectSpeake>>;