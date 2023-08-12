namespace Rectangler.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using DataTransferObjects;

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
		return await _context.Rectangles
			.Select(rect => new RectangleDto
			{
				Left = rect.Left,
				Top = rect.Top,
				Right = rect.Right,
				Bottom = rect.Bottom
			})
			.ToArrayAsync();
	}

	[HttpGet]
	[ActionName("GetRectanglesByPoint")]
	public async Task<IEnumerable<RectangleDto>> GetRectanglesByPoint([FromQuery] PointDto point)
	{
		return await _context.Rectangles
			.Where(rect => point.X >= rect.Left &&
			               point.X <= rect.Right &&
			               point.Y >= rect.Top &&
			               point.Y <= rect.Bottom)
			.Select(rect => new RectangleDto
			{
				Left = rect.Left,
				Top = rect.Top,
				Right = rect.Right,
				Bottom = rect.Bottom
			})
			.ToArrayAsync();
	}

	[HttpPost]
	[ActionName("MatchRectanglesByPointArray")]
	public async IAsyncEnumerable<RectanglesByPointDto> MatchRectanglesByPointArray([FromBody] PointDto[] points)
	{
		foreach (var point in points)
		{
			yield return new RectanglesByPointDto
			{
				Point = point,
				Rectangles = await _context.Rectangles
					.Where(rect => point.X >= rect.Left &&
					               point.X <= rect.Right &&
					               point.Y >= rect.Top &&
					               point.Y <= rect.Bottom)
					.Select(rect => new RectangleDto
					{
						Left = rect.Left,
						Top = rect.Top,
						Right = rect.Right,
						Bottom = rect.Bottom
					})
					.ToArrayAsync()
			};
		}
	}
}