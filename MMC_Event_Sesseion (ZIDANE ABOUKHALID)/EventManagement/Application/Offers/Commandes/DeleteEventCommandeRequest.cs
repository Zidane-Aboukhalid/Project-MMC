using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public class DeleteEventCommandeRequest : IRequest<bool>
    {
        public Guid Id { get; }
       
        public DeleteEventCommandeRequest(Guid id)
        {
            Id = id;
           
        }
    }
}
