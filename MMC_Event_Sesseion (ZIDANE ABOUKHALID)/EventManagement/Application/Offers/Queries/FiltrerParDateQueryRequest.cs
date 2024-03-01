using Application.DTO;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Queries
{
    public  class FiltrerParDateQueryRequest : IRequest<List<EventDto>>
    {
        public DateTime? sortBy;
        public FiltrerParDateQueryRequest(DateTime? sortBy)
        {
            this.sortBy = sortBy;
        }
    }
}
