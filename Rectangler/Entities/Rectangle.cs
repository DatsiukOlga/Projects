namespace Rectangler.Entities;

public sealed class Rectangle
{
	public long Id { get; init; }
	public required int TopLeftX { get; init; }
	public required int TopLeftY { get; init; }
	public required int Width { get; init; }
	public required int Height { get; init; }
}