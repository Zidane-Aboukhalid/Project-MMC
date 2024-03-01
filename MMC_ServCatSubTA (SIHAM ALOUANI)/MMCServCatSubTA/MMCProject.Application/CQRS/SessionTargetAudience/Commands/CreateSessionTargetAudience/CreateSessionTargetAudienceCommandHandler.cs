using AutoMapper;
using MediatR;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.SessionTargetAudience;
using MMCProject.Application.ViewModel.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SessionTargetAudience.Commands.CreateSessionTargetAudience
{
    public class CreateSessionTargetAudienceCommandHandler : IRequestHandler<CreateSessionTargetAudienceCommand, OpSessionTargetAudienceViewModel>
    {

        private readonly ISessionTargetAudienceRepository _sessionTargetAudienceRepository;
        private readonly IMapper _mapper;

        public CreateSessionTargetAudienceCommandHandler(ISessionTargetAudienceRepository sessionTargetAudienceRepository, IMapper mapper)
        {
            _sessionTargetAudienceRepository = sessionTargetAudienceRepository;
            _mapper = mapper;
        }
        public async Task<OpSessionTargetAudienceViewModel> Handle(CreateSessionTargetAudienceCommand request, CancellationToken cancellationToken)
        {
            var newSTA = new Domain.Entities.SessionTargetAudience()
            {
                SessionId=request.SessionId,
                TargetAudienceId=request.TargetAudienceId,

            };
            var opSTAViewModel = _mapper.Map<OpSessionTargetAudienceViewModel>(newSTA);

            await _sessionTargetAudienceRepository.CreateAsync(opSTAViewModel);


            return opSTAViewModel;
        }
    }
}
