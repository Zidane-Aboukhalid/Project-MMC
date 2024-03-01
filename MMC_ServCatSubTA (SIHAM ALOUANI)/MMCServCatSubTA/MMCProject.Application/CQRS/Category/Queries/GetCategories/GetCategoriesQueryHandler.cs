using AutoMapper;
using MediatR;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.Category.Queries.GetCategories
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<CategoryViewModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoryViewModel>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoriesList = _mapper.Map<List<CategoryViewModel>>(categories);
                
            return categoriesList;
        }
    }
}
    