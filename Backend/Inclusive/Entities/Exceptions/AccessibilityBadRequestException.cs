namespace Entities.Exceptions;

public class AccessibilityBadRequestException : BadRequestException
{
    public AccessibilityBadRequestException(string id) : 
        base($"No se puede crear un establecimiento sin accesibilidad. Debe seleccionar características de accesibilidad")
    {
    }
}