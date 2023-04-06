namespace Entities.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string id) : base($"User with id {id} was not found.")
    {
    }

    public UserNotFoundException(string email, bool isEmail) : base($"User with email {email} was not found.")
    {
    }
}