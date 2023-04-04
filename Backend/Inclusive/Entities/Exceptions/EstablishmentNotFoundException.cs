namespace Entities.Exceptions;

public class EstablishmentNotFoundException : NotFoundException
{
    public EstablishmentNotFoundException(Guid id) : base($"Establishment with id: {id} was not found")
    {
    }
}