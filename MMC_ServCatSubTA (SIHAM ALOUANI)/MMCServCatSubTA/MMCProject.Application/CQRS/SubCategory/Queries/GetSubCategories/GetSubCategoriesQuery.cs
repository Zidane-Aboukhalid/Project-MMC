using MediatR;
using MMCProject.Application.ViewModel.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SubCategory.Queries.GetSubCategories
{
    public class GetSubCategoriesQuery : IRequest<List<SubCategoryViewModel>>
    {
    }
}
