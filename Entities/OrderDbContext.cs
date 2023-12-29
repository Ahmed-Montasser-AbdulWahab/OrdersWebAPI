using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Entities
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options) { }
        

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasOne<Order>(oi => oi.Order).WithMany(o => o.Items).HasForeignKey(oi => oi.OrderId);
            });
        }
    }

    //public class OrderDbContextFactory : IDesignTimeDbContextFactory<OrderDbContext>
    //{
        
    //    public OrderDbContext CreateDbContext(string[] args)
    //    {

    //        var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();
    //        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=OrderDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    //        return new OrderDbContext(optionsBuilder.Options);
    //    }
    //}
}
