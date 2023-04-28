namespace credit_wizard_api.Exceptions
{
    public class ReferenceNotExistsException : Exception
    {
        public ReferenceNotExistsException(string entityName, string referencedEntityName, string referencedName) :
            base($"{entityName} with reference {referencedEntityName} ({referencedName}) does not exist")
        {
        }
    }
}
