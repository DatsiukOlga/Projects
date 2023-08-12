namespace Rectangler.Entities;

public sealed class Rectangle
{
	public long Id { get; init; }
	public required int Left { get; init; }
	public required int Top { get; init; }
	public required int Width { get; init; }
	public required int Height { get; init; }
}