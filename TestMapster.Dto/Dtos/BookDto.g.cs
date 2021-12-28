using System;
using TestMapster.Dtos.Dtos;

namespace TestMapster.Dtos.Dtos
{
    public partial class BookDto
    {
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public AuthorDto Author { get; set; }
    }
}