using Shared.DataTransferObjects.EstablishmentDtos;

namespace Shared.DataTransferObjects.CategoryDtos;

public class CategoryDto
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }

    public string? Image { get; init; }

    public IEnumerable<EstablishmentDto>? Establishments { get; init; }
}