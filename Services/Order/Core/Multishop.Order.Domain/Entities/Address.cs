namespace Multishop.Order.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
    }
}
