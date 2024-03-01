using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public class CreateSessionCommandeRequest : IRequest<AddSessionDto>
    {
        public AddSessionDto SessionRequest { get; }
        public CreateSessionCommandeRequest(AddSessionDto sessionRequest)
        {
            SessionRequest = sessionRequest;
        }
    }
}
