using MediatR;
using MMCProject.Application.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<OpCategoryViewModel>
    {
        [Required, MaxLength(150, ErrorMessage =" MaxLenght is  150 caracters") , MinLength(3)]
        public string NameCategory { get; set; }
    }
}
