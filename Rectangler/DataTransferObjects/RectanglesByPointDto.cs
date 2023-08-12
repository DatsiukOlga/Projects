namespace Rectangler.DataTransferObjects
{
	public sealed class RectanglesByPointDto
	{
		public required PointDto Point { get; init; }
		public required RectangleDto[] Rectangles { get; init; }
	}
}
