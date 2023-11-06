using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTOGO.Web.Entities.CustomerAggregate;
using MTOGO.Web.Entities.OrderAggregate;
using MTOGO.Web.Entities.RestaurantAggregate;

namespace MTOGO.Web.Data;

public class MtogoContext : DbContext
{
    //User
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;

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
        
        //Decimal precision on price
        modelBuilder.Entity<MenuItem>()
            .Property(p => p.Price).HasColumnType("decimal(18,2)");
        
        modelBuilder.Entity<OrderLine>()
            .Property(p => p.Price).HasColumnType("decimal(18,2)");

        //Unique Email
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        
        // //Unique Phone Number
        modelBuilder.Entity<Restaurant>()
            .HasIndex(r => r.PhoneNumber)
            .IsUnique();

        //Set relationships
        
        //Order > OrderLines
        modelBuilder.Entity<Order>().ToTable("Order")
            .HasMany(o => o.Lines)
            .WithOne(ol => ol.Order)
            .HasForeignKey(ol => ol.OrderId);
        
        //Order > User
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany()
            .HasForeignKey(o => o.UserId);

        //OrderLine > MenuItem
        modelBuilder.Entity<OrderLine>()
            .HasOne(ol => ol.MenuItem)
            .WithMany()
            .HasForeignKey(ol => ol.MenuItemId);

        //Restaurant > MenuItems
        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Menu)
            .WithOne(mi => mi.Restaurant)
            .HasForeignKey(mi => mi.RestaurantId);

        //User > Roles
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);
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