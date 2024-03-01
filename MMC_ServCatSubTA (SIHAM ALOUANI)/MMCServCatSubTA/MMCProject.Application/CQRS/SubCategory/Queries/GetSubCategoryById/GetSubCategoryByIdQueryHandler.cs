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

namespace MMCProject.Application.CQRS.SubCategory.Queries.GetSubCategoryById
{
    public class GetSubCategoryByIdQueryHandler : IRequestHandler<GetSubCategoryByIdQuery, SubCategoryViewModel>
    {
        private readonly ISubCategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;

        public GetSubCategoryByIdQueryHandler(ISubCategoryRepository subcategoryRepository, IMapper mapper)
        {
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }
        public async Task<SubCategoryViewModel> Handle(GetSubCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var subCategory = await _subcategoryRepository.GetByIdAsync(request.SubCategoryId);
            return _mapper.Map<SubCategoryViewModel>(subCategory);
        }
    }
}
