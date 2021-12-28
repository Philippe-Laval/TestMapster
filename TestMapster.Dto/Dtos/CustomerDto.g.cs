using System.Collections.Generic;
using TestMapster.Dtos.Dtos;
using TestMapster.Library.Models;

namespace TestMapster.Dtos.Dtos
{
    public partial class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Credit { get; set; }
        public AddressDto? Address { get; set; }
        public AddressDto? HomeAddress { get; set; }
        public Address?[]? Addresses { get; set; }
        public ICollection<AddressDto?>? WorkAddresses { get; set; }
    }
}