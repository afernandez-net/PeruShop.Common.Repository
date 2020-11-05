namespace PeruShop.Services.Customers.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using PeruShop.Services.Customers.Domain;

    public class CustomersDbContext : DbContext
    {
        public CustomersDbContext(DbContextOptions<CustomersDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(x => new { x.CustomerId,x.ProductId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder
                 .UseLazyLoadingProxies(false);
    }
}