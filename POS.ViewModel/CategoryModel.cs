using System.ComponentModel.DataAnnotations;

namespace POS.ViewModel
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Picture { get; set; }
    }
}