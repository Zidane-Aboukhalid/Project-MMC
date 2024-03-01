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
    public class DeleteSessionCommandeHandler : IRequestHandler<DeleteSessionCommandeRequest, bool>
    {
        private readonly IMapper mapper;
        private readonly ISessionRepository sessionRepository;
        public DeleteSessionCommandeHandler(IMapper mapper, ISessionRepository sessionRepository)
        {
            this.mapper = mapper;
            this.sessionRepository = sessionRepository;
        }
        public async Task<bool> Handle(DeleteSessionCommandeRequest request, CancellationToken cancellationToken)
        {
            var session = await sessionRepository.GetByIdAsync(request.Id);
            if (session == null)
            {
                return false;
            }

            await sessionRepository.DeleteAsync(request.Id);

            return true;
        }
    }
}
