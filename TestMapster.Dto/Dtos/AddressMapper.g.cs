using System;
using System.Linq.Expressions;
using TestMapster.Dtos.Dtos;
using TestMapster.Library.Models;

namespace TestMapster.Dtos.Dtos
{
    public static partial class AddressMapper
    {
        public static AddressDto AdaptToDto(this Address p1)
        {
            return p1 == null ? null : new AddressDto()
            {
                Id = p1.Id,
                Street = p1.Street,
                City = p1.City,
                Country = p1.Country
            };
        }
        public static AddressDto AdaptTo(this Address p2, AddressDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            AddressDto result = p3 ?? new AddressDto();
            
            result.Id = p2.Id;
            result.Street = p2.Street;
            result.City = p2.City;
            result.Country = p2.Country;
            return result;
            
        }
        public static Expression<Func<Address, AddressDto>> ProjectToDto => p4 => new AddressDto()
        {
            Id = p4.Id,
            Street = p4.Street,
            City = p4.City,
            Country = p4.Country
        };
    }
}