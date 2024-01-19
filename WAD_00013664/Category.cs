namespace WAD_00013664
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

       
    }
}
