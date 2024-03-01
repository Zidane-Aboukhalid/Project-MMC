using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Queries
{
    public class GetByIdEventQueryRequest : IRequest<EventDto>
    {
        public Guid Id { get; }

        public GetByIdEventQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
