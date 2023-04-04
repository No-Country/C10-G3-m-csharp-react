using Shared.DataTransferObjects.EstablishmentDtos;

namespace Shared.DataTransferObjects.OwnerDtos;

public record OwnerDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? SurNames { get; init; }
    public string? Dni { get; init; }
    public GenderEnum? Gender { get; init; }
    public NationalityEnum Nationality { get; init; }
    public string? TramitNumber { get; init; }
    public DateTime BirthDate { get; init; }
    public string? PhoneCode { get; init; }
    public string? PhoneNumber { get; init; }
    public MaritalStatusEnum MaritalStatus { get; init; }
    public char? Pep { get; init; }
    public EstablishmentDto? Establishment { get; init; }
}