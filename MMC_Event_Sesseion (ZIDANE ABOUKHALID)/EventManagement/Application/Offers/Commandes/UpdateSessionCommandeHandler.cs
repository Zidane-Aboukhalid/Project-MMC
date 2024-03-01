using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public class UpdateSessionCommandeHandler : IRequestHandler<UpdateSessionCommandeRequest, bool>
    {
        private readonly IMapper mapper;
        private readonly ISessionRepository sessionRepository;

        public UpdateSessionCommandeHandler(IMapper mapper, ISessionRepository sessionRepository)
        {
            this.mapper = mapper;
            this.sessionRepository = sessionRepository;
        }
        public async Task<bool> Handle(UpdateSessionCommandeRequest request, CancellationToken cancellationToken)
        {
            var session = await sessionRepository.GetByIdAsync(request.Id);

            mapper.Map(request.Session, session);
            await sessionRepository.UpdateAsync(session);
            return true;
        }
    }
}
