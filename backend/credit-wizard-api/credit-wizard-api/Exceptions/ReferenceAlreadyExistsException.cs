namespace credit_wizard_api.Exceptions;

public class ReferenceAlreadyExistsException : Exception
{
    public ReferenceAlreadyExistsException()
    {
    }
    
    public ReferenceAlreadyExistsException(string entityName, string referenceName, string key)
        : base($"{entityName} with reference {referenceName}: {key} already exists and cannot be used")
    {
    }
}