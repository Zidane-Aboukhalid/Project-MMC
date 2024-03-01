using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public class DeleteImageCommandeRequest : IRequest<bool>
    {   
        public Guid Id { get; }
        public DeleteImageCommandeRequest(Guid id)
        {

            Id = id;

        }
    }
}
