namespace Rectangler.DataTransferObjects
{
	public sealed class RectangleDto
	{
		public required int TopLeftX { get; init; }
		public required int TopLeftY { get; init; }
		public required int Width { get; init; }
		public required int Height { get; init; }
	}
}
