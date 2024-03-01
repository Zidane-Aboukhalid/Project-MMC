using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<int> 
    {
        public Guid CategoryId { get; set; }
        public string NameCategory { get; set; }
    }
}
