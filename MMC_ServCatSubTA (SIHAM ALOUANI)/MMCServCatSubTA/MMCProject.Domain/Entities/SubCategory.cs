using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Domain.Entities
{
    public class SubCategory
    {
        public Guid SubCategoryId { get; set; }
        public string NameSubCategory { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }  
    }
}
