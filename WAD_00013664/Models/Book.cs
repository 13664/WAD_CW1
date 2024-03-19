using Azure.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAD_00013664.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Please enter a title.")]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public int YearPublication { get; set; }
        [Required(ErrorMessage = "Please enter author name.")]
        public string Author { get; set; }
        [Range(1.0, 1000.0, ErrorMessage = "Price must be between [1-1000].")]
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please select a category.")]

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        //[ForeignKey("CategoryID")]
        public Category? Category { get; set; } = null!;
    }
}
