using System;
using System.Linq.Expressions;
using TestMapster.Dtos.Dtos;
using TestMapster.Library.Models;

namespace TestMapster.Dtos.Dtos
{
    public static partial class BookMapper
    {
        public static BookDto AdaptToDto(this Book p1)
        {
            return p1 == null ? null : new BookDto()
            {
                Title = p1.Title,
                PublishedDate = p1.PublishedDate,
                AuthorId = p1.AuthorId,
                Author = p1.Author == null ? null : new AuthorDto()
                {
                    Firstname = p1.Author.Firstname,
                    Lastname = p1.Author.Lastname
                }
            };
        }
        public static BookDto AdaptTo(this Book p2, BookDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            BookDto result = p3 ?? new BookDto();
            
            result.Title = p2.Title;
            result.PublishedDate = p2.PublishedDate;
            result.AuthorId = p2.AuthorId;
            result.Author = funcMain1(p2.Author, result.Author);
            return result;
            
        }
        public static Expression<Func<Book, BookDto>> ProjectToDto => p6 => new BookDto()
        {
            Title = p6.Title,
            PublishedDate = p6.PublishedDate,
            AuthorId = p6.AuthorId,
            Author = p6.Author == null ? null : new AuthorDto()
            {
                Firstname = p6.Author.Firstname,
                Lastname = p6.Author.Lastname
            }
        };
        
        private static AuthorDto funcMain1(Author p4, AuthorDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            AuthorDto result = p5 ?? new AuthorDto();
            
            result.Firstname = p4.Firstname;
            result.Lastname = p4.Lastname;
            return result;
            
        }
    }
}