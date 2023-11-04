using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTOGO.Web.Entities.OrderAggregate;
using MTOGO.Web.Entities.RestaurantAggregate;

namespace MTOGO.Web.Data;

public class MtogoContext : DbContext
{
    //Order
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderLine> OrderItems { get; set; } = null!;

    //Restaurant
    public DbSet<MenuItem> MenuItems { get; set; } = null!;
    
    public MtogoContext(DbContextOptions<MtogoContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Set primary keys
        modelBuilder.Entity<Order>().HasKey(o => o.Id);
        modelBuilder.Entity<OrderLine>().HasKey(ol => ol.Id);
        modelBuilder.Entity<MenuItem>().HasKey(m => m.Id);
        
        //Add Value Objects
        modelBuilder.Entity<Address>(ConfigureAddress);


        //Set relationships
        
        //Order > OrderLines
        modelBuilder.Entity<Order>().ToTable("Order")
            .HasMany(o => o.Lines)
            .WithOne(ol => ol.Order)
            .HasForeignKey(ol => ol.OrderId);
        
        //OrderLines > MenuItem
        // OrderLines > MenuItem
        modelBuilder.Entity<OrderLine>()
            .ToTable("OrderLine")
            .HasOne(ol => ol.MenuItem)
            .WithMany()
            .HasForeignKey(ol => ol.MenuItemId);
    }
    
    void ConfigureAddress<T>(EntityTypeBuilder<T> entity) where T : Address
    {
        entity.ToTable("Address", "dbo");

        entity.Property<int>("Id")
            .IsRequired();
        entity.HasKey("Id");
    }
}