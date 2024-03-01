
using MMCProject.Application.ViewModel.Category;

namespace MMCProject.Application.ViewModel.SubCategory
{
    public class SubCategoryViewModel
    {
        public Guid SubCategoryId { get; set; }
        public string NameSubCategory { get; set; }
        public Guid CategoryId { get; set; }


        //public CategoryViewModel Category { get; set; }
    }
}
