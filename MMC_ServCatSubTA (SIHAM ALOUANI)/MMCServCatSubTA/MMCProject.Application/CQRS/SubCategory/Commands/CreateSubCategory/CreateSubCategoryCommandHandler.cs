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

namespace MMCProject.Application.CQRS.SubCategory.Commands.CreateSubCategory
{
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, OpSubCategoryViewModel>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public CreateSubCategoryCommandHandler(ISubCategoryRepository subcategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }
        public async Task<OpSubCategoryViewModel> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var newsubCategory = new Domain.Entities.SubCategory()
            {
                NameSubCategory = request.NameSubCategory,
                CategoryId=request.CategoryId,

            };
            var opSubCategoryViewModel = _mapper.Map<OpSubCategoryViewModel>(newsubCategory);

            await _subCategoryRepository.CreateAsync(opSubCategoryViewModel);


            return opSubCategoryViewModel;
        }
    }
}
