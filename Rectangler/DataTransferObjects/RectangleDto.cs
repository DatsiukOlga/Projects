namespace Rectangler.DataTransferObjects
{
	public sealed class RectangleDto
	{
		public required int Left { get; init; }
		public required int Top { get; init; }
		public required int Width { get; init; }
		public required int Height { get; init; }
	}
}
