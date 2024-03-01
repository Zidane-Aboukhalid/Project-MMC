using MMCProject.Application.ViewModel.SubCategory;

namespace MMCProject.Application.ViewModel.Category
{
    public class CategoryViewModel
    {
        public Guid CategoryId { get; set; }
        public string NameCategory { get; set; }
        public List<SubCategoryViewModel> SubCategories { get; set; } 
    }
}
