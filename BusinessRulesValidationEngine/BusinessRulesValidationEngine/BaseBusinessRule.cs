namespace BusinessRulesValidationEngine
{
    public class BaseBusinessRule<T> : IRule<T> where T : class
    {
        public BaseBusinessRule(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; }

        public bool Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}