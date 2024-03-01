﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC_Auth.Application.Users.Queries;

public record GetEmailById(string id):IRequest<string>;