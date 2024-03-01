using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public class DeleteSessionCommandeRequest : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteSessionCommandeRequest(Guid id)
        {
            Id = id;
        }
    }
}
