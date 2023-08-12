namespace Rectangler.Database;

using Entities;

public static class RectanglerDbInitializer
{
	private static RectanglerDbContext? _context;
	private const int RectanglesCount = 200;
	private const int MinX = 0;
	private const int MaxX = 2000;
	private const int MinY = 0;
	private const int MaxY = 2000;

	public static void Initialize(RectanglerDbContext context)
	{
		_context = context;

		_context.Database.EnsureCreated();

		if (context.Rectangles.Any())
			return;

		PopulateRectanglesIntoDb(RectanglesCount);

		_context.SaveChanges();
	}

	private static void PopulateRectanglesIntoDb(int rectanglesCount)
	{
		if (_context == null)
			return;

		for (var i = 0; i < rectanglesCount; i++)
		{
			var left = Random.Shared.Next(MinX, MaxX);
			var top = Random.Shared.Next(MinY, MaxY);
			var right = Random.Shared.Next(left + 1, MaxX + 1);
			var bottom = Random.Shared.Next(top + 1, MaxY + 1);

			_context.Rectangles.Add(
				new Rectangle
				{
					Left = left,
					Top = top,
					Right = right,
					Bottom = bottom
				});
		}
	}
}