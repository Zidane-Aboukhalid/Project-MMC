using MediatR;
using MMCProject.Application.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.Category.Queries.GetCategories
{
    public class GetCategoryQuery : IRequest<List<CategoryViewModel>>
    {
        
    }
}
    