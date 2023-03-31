namespace Entities.Exceptions;

public class CategoryImageNotFoundException : NotFoundException
{
    public CategoryImageNotFoundException(Guid id) : base($"CategoryImage with id {id} was not found.")
    {
    }
}