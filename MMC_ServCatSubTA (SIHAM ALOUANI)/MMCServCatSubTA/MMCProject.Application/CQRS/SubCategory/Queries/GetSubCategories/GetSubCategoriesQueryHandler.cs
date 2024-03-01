using AutoMapper;
using MediatR;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.Category;
using MMCProject.Application.ViewModel.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SubCategory.Queries.GetSubCategories
{
    public class GetSubCategoriesQueryHandler : IRequestHandler<GetSubCategoriesQuery, List<SubCategoryViewModel>>
    {
        private readonly ISubCategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;
        public GetSubCategoriesQueryHandler(ISubCategoryRepository subcategoryRepository, IMapper mapper)
        {
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }
        public async Task<List<SubCategoryViewModel>> Handle(GetSubCategoriesQuery request, CancellationToken cancellationToken)
        {
            var subCategories = await _subcategoryRepository.GetAllAsync();
            var subCategoriesList = _mapper.Map<List<SubCategoryViewModel>>(subCategories);

            return subCategoriesList;
        }
    }
}
