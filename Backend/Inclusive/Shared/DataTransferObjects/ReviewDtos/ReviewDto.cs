namespace Shared.DataTransferObjects.ReviewDtos;

public record ReviewDto
{
    public Guid Id { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }
}