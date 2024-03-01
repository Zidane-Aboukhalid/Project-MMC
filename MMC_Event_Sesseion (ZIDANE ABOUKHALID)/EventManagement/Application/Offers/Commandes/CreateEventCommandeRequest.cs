using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public class CreateEventCommandeRequest : IRequest<AddEventDto>
    {
        public AddEventDto EventRequest { get; }
        public CreateEventCommandeRequest(AddEventDto eventRequest)
        {
            EventRequest = eventRequest;
        }
    }
}
