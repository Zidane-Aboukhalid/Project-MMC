using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Guid>
    {
        public Guid CategoryId { get; set; }
    }
}
