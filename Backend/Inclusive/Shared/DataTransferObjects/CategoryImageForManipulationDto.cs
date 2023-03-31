namespace Shared.DataTransferObjects;

public abstract record CategoryImageForManipulationDto
{
    public string? ImageName { get; set; }
    public string? ImagePath { get; set; }

    public Guid CategoryId { get; set; }
}