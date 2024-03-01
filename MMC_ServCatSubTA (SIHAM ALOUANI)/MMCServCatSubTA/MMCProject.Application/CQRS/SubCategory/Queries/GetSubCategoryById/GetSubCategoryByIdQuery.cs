using MediatR;
using MMCProject.Application.ViewModel.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SubCategory.Queries.GetSubCategoryById
{
    public class GetSubCategoryByIdQuery : IRequest<SubCategoryViewModel>
    {
        public Guid SubCategoryId { get; set; }
    }
}
