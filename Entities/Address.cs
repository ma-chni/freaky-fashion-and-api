namespace FreakyFashion.Entities
{
    public class Address
    {
        public Address(string street, string city, int postcode)
        {
            Street = street;
            City = city;
            Postcode = postcode;
        }

        public Address()
        {

        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Postcode { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}