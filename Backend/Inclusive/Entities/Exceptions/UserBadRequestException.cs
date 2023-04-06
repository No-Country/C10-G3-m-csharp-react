namespace Entities.Exceptions;

public class UserBadRequestException : BadRequestException
{
    public UserBadRequestException(string id) : base($"El id del usuario que ingreso no fue encontrado o el id no pertenece al usuario.")
    {
    }
}