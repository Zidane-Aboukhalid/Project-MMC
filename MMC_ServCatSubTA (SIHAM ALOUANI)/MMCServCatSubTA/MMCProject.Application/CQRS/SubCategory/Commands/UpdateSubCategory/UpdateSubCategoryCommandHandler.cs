using MediatR;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.Category;
using MMCProject.Application.ViewModel.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SubCategory.Commands.UpdateSubCategory
{
    public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommand, int>
    {
        public ISubCategoryRepository _subcategoryRepository;
        public UpdateSubCategoryCommandHandler(ISubCategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        public async Task<int> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var updateSubCategory = new OpUpdateSubCategoryViewModel()
            {
               NameSubCategory=request.NameSubCategory,
               CategoryId=request.CategoryId,
            };
            await _subcategoryRepository.UpdateAsync(request.SubCategoryId, updateSubCategory);
            return 1;
        }
    }
}               
