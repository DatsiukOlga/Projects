namespace Rectangler.Database;

using Microsoft.EntityFrameworkCore;
using Entities;

public class RectanglerDbContext : DbContext
{
	public RectanglerDbContext(DbContextOptions<RectanglerDbContext> options) : base(options)
	{
	}

	public DbSet<Rectangle> Rectangles => Set<Rectangle>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var builder = modelBuilder.Entity<Rectangle>();
		builder.HasIndex(e => new { e.Left, e.Top, e.Right, e.Bottom});
	}
}