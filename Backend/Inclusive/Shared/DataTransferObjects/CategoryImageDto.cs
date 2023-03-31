namespace Shared.DataTransferObjects;

public record CategoryImageDto
{
    public Guid Id { get; init; }

    public string? ImageName { get; init; }
    public string? ImagePath { get; init; }
}