using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SubCategory.Commands.DeleteSubCategory
{
    public class DeleteSubCategoryCommand : IRequest<Guid>
    {
        public Guid SubCategoryId { get; set; }
    }
}
