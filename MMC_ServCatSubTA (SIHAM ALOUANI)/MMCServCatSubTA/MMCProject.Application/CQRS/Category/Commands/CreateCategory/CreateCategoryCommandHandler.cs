using AutoMapper;
using MediatR;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.Category;
using MMCProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, OpCategoryViewModel>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<OpCategoryViewModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCategory = new Domain.Entities.Category()
            {
                NameCategory = request.NameCategory,
                
            };
            var opCategoryViewModel = _mapper.Map<OpCategoryViewModel>(newCategory);

            await _categoryRepository.CreateAsync(opCategoryViewModel);


            return opCategoryViewModel;
        }
    }
}
