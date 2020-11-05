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
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(x => new { x.OrderId,x.ProductId });
            
            modelBuilder.Entity<Customer>().OwnsOne(x => x.Address)
                .Property(p => p.City).HasColumnName("City");

            modelBuilder.Entity<Customer>().OwnsOne(x => x.Address)
                .Property(p => p.Country).HasColumnName("Country");

            modelBuilder.Entity<Customer>().OwnsOne(x => x.Address)
                .Property(p => p.ProvinceState).HasColumnName("ProvinceState");

            modelBuilder.Entity<Customer>().OwnsOne(x => x.Address)
                .Property(p => p.StreetAdress).HasColumnName("StreetAdress");


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder
                 .UseLazyLoadingProxies(false);
    }
}