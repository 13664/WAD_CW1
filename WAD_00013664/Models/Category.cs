using System.ComponentModel.DataAnnotations;

namespace WAD_00013664.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } 
        [Required(ErrorMessage = "Please enter category name.")]
        public string Title { get; set; } = string.Empty;
        //public ICollection<Book>? Books { get; set; }


    }
}
