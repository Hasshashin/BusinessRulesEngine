namespace BusinessRulesValidationEngine
{
    public interface IRule<T> where T : class
    {
        T Entity { get; }

        bool Validate();
    }
}
