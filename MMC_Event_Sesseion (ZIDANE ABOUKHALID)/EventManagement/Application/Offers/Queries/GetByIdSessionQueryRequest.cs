using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Queries
{
    public  class GetByIdSessionQueryRequest : IRequest<SessionDto>
    {
        public Guid Id { get; }

        public GetByIdSessionQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
