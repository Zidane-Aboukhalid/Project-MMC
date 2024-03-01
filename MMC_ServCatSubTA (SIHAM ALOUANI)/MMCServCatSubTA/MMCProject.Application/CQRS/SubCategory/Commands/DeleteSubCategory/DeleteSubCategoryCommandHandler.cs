using MediatR;
using MMCProject.Application.CQRS.Category.Commands.DeleteCategory;
using MMCProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SubCategory.Commands.DeleteSubCategory
{
    public class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommand, Guid>
    {

        public ISubCategoryRepository _subCategoryRepository;

        public DeleteSubCategoryCommandHandler(ISubCategoryRepository subcategoryRepository)
        {
            _subCategoryRepository = subcategoryRepository;
        }
        public async Task<Guid> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _subCategoryRepository.DeleteAsync(request.SubCategoryId);
        }
    }
}
