using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Domain.Entities
{
    public class Category
    {
        
        public Guid CategoryId { get; set; }
        public string NameCategory { get; set; }
        public  List<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
      
    }
}
