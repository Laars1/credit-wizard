namespace credit_wizard_api.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName, string property, string key) : base($"{entityName} with {property} '{key}' not found")
    {
    }

    public EntityNotFoundException(string message) :
        base(message)
    {
    }
}