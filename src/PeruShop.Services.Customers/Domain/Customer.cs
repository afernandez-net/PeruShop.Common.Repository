namespace PeruShop.Services.Customers.Domain
{
    using PeruShop.Common.Repository;

    public class Customer : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}