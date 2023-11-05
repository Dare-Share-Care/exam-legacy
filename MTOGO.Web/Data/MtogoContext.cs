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
        //Order Aggregates
        modelBuilder.Entity<Order>().HasKey(o => o.Id);
        modelBuilder.Entity<OrderLine>().HasKey(ol => ol.Id);
        
        //Restaurant Aggregates
        modelBuilder.Entity<Restaurant>().HasKey(r => r.Id);
        modelBuilder.Entity<MenuItem>().HasKey(mi => mi.Id);
        
        //Add Value Objects
        modelBuilder.Entity<Address>(ConfigureAddress);

        //Entity properties
        modelBuilder.Entity<MenuItem>()
            .Property(p => p.Price).HasColumnType("decimal(18,2)");


        //Set relationships
        //Order > OrderLines
        modelBuilder.Entity<Order>().ToTable("Order")
            .HasMany(o => o.Lines)
            .WithOne(ol => ol.Order)
            .HasForeignKey(ol => ol.OrderId);
        
        //OrderLine > MenuItem
        modelBuilder.Entity<OrderLine>()
            .HasOne(ol => ol.MenuItem)
            .WithMany()
            .HasForeignKey(ol => ol.MenuItemId);
        
        //Restaurant > MenuItems
        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.MenuItems)
            .WithOne(mi => mi.Restaurant)
            .HasForeignKey(mi => mi.RestaurantId);
    }
    
    //Address value object
    void ConfigureAddress<T>(EntityTypeBuilder<T> entity) where T : Address
    {
        entity.ToTable("Address", "dbo");

        entity.Property<int>("Id")
            .IsRequired();
        entity.HasKey("Id");
    }
}