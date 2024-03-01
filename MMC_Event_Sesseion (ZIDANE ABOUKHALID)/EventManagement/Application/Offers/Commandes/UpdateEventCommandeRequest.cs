using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public class UpdateEventCommandeRequest : IRequest<bool>
    {
        public Guid Id { get; }
        public AddEventDto Event { get; }
        public UpdateEventCommandeRequest(Guid id, AddEventDto events)
        {
            Id = id;
            Event = events;
        }
    }
}
