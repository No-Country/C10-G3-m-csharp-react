namespace Shared.DataTransferObjects;

public class ReviewDto
{
    public Guid Id { get; set; }

    public Guid EstablishmentId { get; set; }

    public Guid UserId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? Created { get; set; }
}
