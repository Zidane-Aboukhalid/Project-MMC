using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MMCProject;
using MMCProject.Application.ViewModel.SubCategory;

namespace MMCProject.Application.CQRS.SubCategory.Commands.CreateSubCategory
{
    public class CreateSubCategoryCommand : IRequest<OpSubCategoryViewModel>
    {
        [Required, MaxLength(150, ErrorMessage = " MaxLenght is  150 caracters"), MinLength(2)]
        public string NameSubCategory { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        //public virtual Domain.Entities.Category Category { get; set; }
    }
}
