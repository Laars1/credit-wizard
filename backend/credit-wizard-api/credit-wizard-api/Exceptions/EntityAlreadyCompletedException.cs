namespace credit_wizard_api.Exceptions
{
    public class EntityAlreadyCompletedException : Exception
    {
        public EntityAlreadyCompletedException(string entityName, string degreeName) :
            base($"{entityName} in {degreeName} is already completed for this degree")
        {
        }
    }
}
