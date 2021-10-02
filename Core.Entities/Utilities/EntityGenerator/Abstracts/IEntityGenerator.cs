using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Entities.Utilities.EntityGenerator.Abstracts
{
    public interface IEntityGenerator<T>
    {
        /// <summary>
        /// Generate a list of entities
        /// </summary>
        /// <param name="n">quantity of enties to generate</param>
        /// <returns>automatic list of entities</returns>
        ICollection<T> GenerateEntities(int n = 1);
        IPropertyBuilderConfig AddRuleForParameter<TProperty>(Expression<Func<T, TProperty>> expression);
    }
}
