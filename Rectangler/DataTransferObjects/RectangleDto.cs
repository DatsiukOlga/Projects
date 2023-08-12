namespace Rectangler.DataTransferObjects;

public sealed class RectangleDto
{
	public required int Left { get; init; }
	public required int Top { get; init; }
	public required int Right { get; init; }
	public required int Bottom { get; init; }
}