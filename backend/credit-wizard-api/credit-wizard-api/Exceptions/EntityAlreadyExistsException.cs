namespace credit_wizard_api.Exceptions;

public class EntityAlreadyExistsException : Exception
{
    public EntityAlreadyExistsException()
    {
    }

    public EntityAlreadyExistsException(string entityName, string primaryKey)
        : base($"{entityName} with primary key {primaryKey} does already exist.")
    {
    }

    public EntityAlreadyExistsException(string entityName, string firstPrimaryKey, string secondPrimaryKey)
        : base($"{entityName} with primary key {firstPrimaryKey} and {secondPrimaryKey} does already exist.")
    {
    }
}