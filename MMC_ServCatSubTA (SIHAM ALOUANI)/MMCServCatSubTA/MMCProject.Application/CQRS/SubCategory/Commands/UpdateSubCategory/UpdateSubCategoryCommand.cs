using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMCProject;

namespace MMCProject.Application.CQRS.SubCategory.Commands.UpdateSubCategory
{
    public class UpdateSubCategoryCommand : IRequest<int>
    {
        public Guid SubCategoryId { get; set; }
        public string NameSubCategory { get; set; }
        public Guid CategoryId { get; set; }
        //public virtual Domain.Entities.Category Category { get; set; }
    }
}
