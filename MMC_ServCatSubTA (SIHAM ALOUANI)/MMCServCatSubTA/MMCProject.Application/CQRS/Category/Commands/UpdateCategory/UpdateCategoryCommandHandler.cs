using MediatR;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
    {
        public ICategoryRepository _categoryRepository;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var updateCategory = new OpUpdateCategoryViewModel()
            {
                NameCategory=request.NameCategory,
            };
            return await _categoryRepository.UpdateAsync(request.CategoryId, updateCategory);
        }
    }
}
