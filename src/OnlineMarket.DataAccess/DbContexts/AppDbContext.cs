using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataAccess.Configurations;
using OnlineMarket.Domain.Entities.Categories;
using OnlineMarket.Domain.Entities.Employees;
using OnlineMarket.Domain.Entities.Orders;
using OnlineMarket.Domain.Entities.Products;
using OnlineMarket.Domain.Entities.Users;

namespace OnlineMarket.DataAccess.DbContexts;
public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}

	public virtual DbSet<User> Users { get; set; } = default!;
	public virtual DbSet<Administator> Administators { get; set; } = default!;
    public virtual DbSet<Operator> Operators  { get; set; } = default!;
    public virtual DbSet<Deliver> Delivers { get; set; } = default!;
    public virtual DbSet<Category> Categories { get; set; } = default!;
    public virtual DbSet<Product> Products { get; set; } = default!;
    public virtual DbSet<ProductComment> ProductComments { get; set; } = default!;
    public virtual DbSet<ProductDiscount> ProductDiscounts { get; set; } = default!;
    public virtual DbSet<Order> Orders { get; set; } = default!;
    public virtual DbSet<OrderDetail> OrderDetails { get; set; } = default!;
    public virtual DbSet<OrderComment> OrderComments  { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new SuperAdminConfiguration());
    }
}
