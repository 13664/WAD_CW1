using System.ComponentModel.DataAnnotations;

namespace BookCatalogMVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter category name.")]
        public string Title { get; set; } = string.Empty;
    }
}
