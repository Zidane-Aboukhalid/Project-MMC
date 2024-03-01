using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMCProject;

namespace MMCProject.Application.ViewModel.SubCategory
{
    public class OpUpdateSubCategoryViewModel
    {
        public Guid SubCategoryId { get; set; }
        public string NameSubCategory { get; set; }
        public Guid CategoryId { get; set; }


        //public virtual Domain.Entities.Category Category { get; set; }
    }
}
