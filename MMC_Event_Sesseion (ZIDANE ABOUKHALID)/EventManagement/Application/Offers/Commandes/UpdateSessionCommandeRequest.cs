using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public  class UpdateSessionCommandeRequest :IRequest<bool>
    {
        public Guid Id { get; }
        public AddSessionDto Session { get; }
        public UpdateSessionCommandeRequest(Guid id, AddSessionDto session)
        {
            Id = id;
            Session = session;
        }
    }
}
