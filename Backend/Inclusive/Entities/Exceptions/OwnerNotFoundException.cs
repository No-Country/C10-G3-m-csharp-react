namespace Entities.Exceptions;

public class OwnerNotFoundException : NotFoundException
{
    public OwnerNotFoundException(Guid id) : base($"Owner with id: {id} was not exists")
    {
    }
}