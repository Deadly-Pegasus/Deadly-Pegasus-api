using Deadly.Pegasus.Domain.Catalog;
using Deadly.Pegasus.Domain.Orders;
using Microsoft.EntityFrameworkCore;


namespace Deadly.Pegasus.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DbInitializer.Initialize(builder);
        }
    }
}
    

