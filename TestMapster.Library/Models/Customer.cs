namespace TestMapster.Library.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal? Credit { get; set; }
        public Address? Address { get; set; }
        public Address? HomeAddress { get; set; }
        public Address[]? Addresses { get; set; }
        public ICollection<Address>? WorkAddresses { get; set; }
    }
}
