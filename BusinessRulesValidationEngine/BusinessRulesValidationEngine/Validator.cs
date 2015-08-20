using System;
using System.Collections.Generic;

namespace BusinessRulesValidationEngine
{
    public class Validator<T> where T : class
    {
        private  T _entity;
        private readonly List<IRule<T>> _rules = new List<IRule<T>>();

        public Validator<T> Of(T entity)
        {
            _entity = entity;

            return this;
        }

        public Validator<T> WithBusinessRule<TR>() where TR : IRule<T>
        {
            var rule = (TR) Activator.CreateInstance(typeof(TR),new {_entity});
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
}