using MediatR;
using MMCProject.Application.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery:IRequest<CategoryViewModel>
    {
        public Guid CategoryId { get; set; }
    }
}
