using System;
using System.Linq.Expressions;
using TestMapster.Dtos.Dtos;
using TestMapster.Library.Models;

namespace TestMapster.Dtos.Dtos
{
    public static partial class AuthorMapper
    {
        public static AuthorDto AdaptToDto(this Author p1)
        {
            return p1 == null ? null : new AuthorDto()
            {
                Firstname = p1.Firstname,
                Lastname = p1.Lastname
            };
        }
        public static AuthorDto AdaptTo(this Author p2, AuthorDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            AuthorDto result = p3 ?? new AuthorDto();
            
            result.Firstname = p2.Firstname;
            result.Lastname = p2.Lastname;
            return result;
            
        }
        public static Expression<Func<Author, AuthorDto>> ProjectToDto => p4 => new AuthorDto()
        {
            Firstname = p4.Firstname,
            Lastname = p4.Lastname
        };
    }
}