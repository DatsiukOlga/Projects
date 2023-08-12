namespace Rectangler.Database;

using Entities;
using Microsoft.EntityFrameworkCore;

public static class RectanglerDbInitializer
{
	private static RectanglerDbContext? _context;
	private static readonly int _rectanglesCount = 200;
	private static readonly int _minX = -1000;
	private static readonly int _maxX = 1000;
	private static readonly int _minY = -1000;
	private static readonly int _maxY = 1000;

	public static void Initialize(RectanglerDbContext context)
	{
		_context = context;

		_context.Database.EnsureCreated();

		if (context.Rectangles.Any())
			return;

		PopulateRectanglesIntoDb(_rectanglesCount);

		_context.SaveChanges();
	}

	private static void PopulateRectanglesIntoDb(int rectanglesCount)
	{
		if (_context == null)
			return;

		for (var i = 0; i < rectanglesCount; i++)
		{
			var left = Random.Shared.Next(_minX, _maxX - 1);
			var top = Random.Shared.Next(_minY, _maxY - 1);
			var width = Random.Shared.Next(1, _maxX - left);
			var height = Random.Shared.Next(1, _maxY - top);

			_context.Rectangles.Add(
				new Rectangle
				{
					Left = left,
					Top = top,
					Width = width,
					Height = height
				});
		}
	}
}