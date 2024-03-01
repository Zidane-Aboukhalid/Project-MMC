using MediatR;
using MMCProject.Application.ViewModel.TargetAudience;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.TargetAudience.Commands.CreateTargetAudience
{
    public class CreateTargetAudienceCommand : IRequest<OpTargetAudienceViewModel>
    {
        [Required, MaxLength(150, ErrorMessage = " MaxLenght is  150 caracters"), MinLength(3)]
        public string NameTargetAudience { get; set; }
    }
}
