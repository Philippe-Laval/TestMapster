namespace TestMapster.Library.Models
{
    public class Book
    {
        public string Title { get; set; } = String.Empty;
        public DateTime PublishedDate { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}