using System;
using System.Collections.Generic;

namespace BusinessRulesValidationEngine
{
    public class Validator<T> where T : class
    {
        private readonly List<IRule<T>> _rules = new List<IRule<T>>();

        public Validator<T> Of(T entity)
        {
            return this;
        }

        public Validator<T> WithBusinessRule<TR>() where TR : IRule<T>
        {
            var rule = (TR) Activator.CreateInstance(typeof(TR));
            _rules.Add(rule);

            return this;
        }

        public BusinessValidationResult Validate()
        {
            var businessVaidationResult = new BusinessValidationResult();

            foreach (var rule in _rules)
            {
                rule.Validate();
            }

            return businessVaidationResult;
        }
    }

    public interface IRule<T> where T : class
    {
        T Entity { get; }

        bool Validate();
    }

    public class BusinessValidationResult
    {
    }
}
