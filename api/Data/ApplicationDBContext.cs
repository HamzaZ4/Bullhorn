using Microsoft.EntityFrameworkCore;
using api.Models;
namespace api.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Stock> Stocks {get; set;}
    

    public DbSet<Comment> Comments {get; set;}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("stock");
    
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Ticker).HasColumnName("ticker");
                entity.Property(e => e.CompanyName).HasColumnName("company_name");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.LastDiv).HasColumnName("last_div");
                entity.Property(e => e.Industry).HasColumnName("industry");
                entity.Property(e => e.MarketCap).HasColumnName("market_cap");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Content).HasColumnName("content");
                entity.Property(e => e.CreatedOn).HasColumnName("created_on");
                entity.Property(e => e.StockId).HasColumnName("stock_id");
                entity.Property(e => e.Title).HasColumnName("title");
                
                modelBuilder.Entity<Comment>(entity =>
                {
                    entity.ToTable("comment");
                    entity.Property(e => e.Id).HasColumnName("id");
                    entity.Property(e => e.Content).HasColumnName("content");
                    entity.Property(e => e.CreatedOn).HasColumnName("created_on");
                    entity.Property(e => e.StockId).HasColumnName("stock_id");
                    entity.Property(e => e.Title).HasColumnName("title");
                    
                    entity.HasOne(e => e.Stock)
                        .WithMany(s => s.Comments)
                        .HasForeignKey(e => e.StockId);
                });

            });
        }
}