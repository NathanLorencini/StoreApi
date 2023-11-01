using Microsoft.EntityFrameworkCore;
using StoreApi.Models;

namespace StoreApi.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<SalesOrder>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<SalesOrder>()
                .HasOne(x => x.Client)
                .WithMany()
                .HasForeignKey(y => y.ClientId);

            modelBuilder.Entity<SalesOrder>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(y => y.ProductId);



            modelBuilder.Entity<Stock>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Stock>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(y => y.ProductId)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Stock)
                .WithMany()
                .HasForeignKey(y => y.StockId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<Stock> Stocks { get; set; }



    }
}
