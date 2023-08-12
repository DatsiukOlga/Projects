using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rectangler.Database;
using Rectangler.DataTransferObjects;
using Rectangler.Entities;

namespace Rectangler.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class RectanglesController : Controller
	{
		private readonly RectanglerDbContext _context;

		public RectanglesController(RectanglerDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		[ActionName("GetAllRectangles")]
		public async Task<IEnumerable<RectangleDto>> GetAllRectangles()
		{
			return (await _context.Rectangles
					.ToListAsync())
					.Select(rect => new RectangleDto
					{
						Left = rect.Left,
						Top = rect.Top,
						Width = rect.Width,
						Height = rect.Height
					})
					.ToArray();
		}

		[HttpGet]
		[ActionName("GetRectanglesByPoint")]
		public async Task<IEnumerable<RectangleDto>> GetRectanglesByPoint([FromQuery] PointDto point)
		{
			return (await _context.Rectangles
					.ToListAsync())
					.Where(rect => PointMatchesRectangle(point, rect))
					.Select(rect => new RectangleDto
					{
						Left = rect.Left,
						Top = rect.Top,
						Width = rect.Width,
						Height = rect.Height
					})
					.ToArray();
		}

		[HttpPost]
		[ActionName("MatchRectanglesByPointArray")]
		public async Task<IEnumerable<RectanglesByPointDto>> MatchRectanglesByPointArray([FromBody] PointDto[] points)
		{
			var rectangles = await _context.Rectangles.ToListAsync();

			return points
				.Select(point => new RectanglesByPointDto
				{
					Point = point,
					Rectangles = rectangles
						.Where(rect => PointMatchesRectangle(point, rect))
						.Select(rect => new RectangleDto
						{
							Left = rect.Left,
							Top = rect.Top,
							Width = rect.Width,
							Height = rect.Height
						})
						.ToArray()
				}).ToArray();
		}

		private static bool PointMatchesRectangle(PointDto point, Rectangle rectangle)
		{
			return point.X >= rectangle.Left &&
			       point.X <= rectangle.Left + rectangle.Width &&
			       point.Y >= rectangle.Top &&
			       point.Y <= rectangle.Top - rectangle.Height;
		}
	}
}
