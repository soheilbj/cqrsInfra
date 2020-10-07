using Microsoft.EntityFrameworkCore;
using CQRSInfra.Domain.Customers;
using CQRSInfra.Domain.Payments;
using CQRSInfra.Domain.Products;
using CQRSInfra.Infrastructure.Processing.InternalCommands;
using CQRSInfra.Infrastructure.Processing.Outbox;

namespace CQRSInfra.Infrastructure.Database
{
    public class OrdersContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public DbSet<InternalCommand> InternalCommands { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public OrdersContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersContext).Assembly);
        }
    }
}
