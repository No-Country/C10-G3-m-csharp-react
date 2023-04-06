namespace Entities.Exceptions;

public class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException(Guid id) : base($"Category with id {id} was not found.")
    {
    }
}