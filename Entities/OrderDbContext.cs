using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
