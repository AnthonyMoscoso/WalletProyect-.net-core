using Core.Entities.Utilities.EntityGenerator.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Core.Entities.Utilities.EntityGenerator
{
    public abstract class BaseGeneratorProfile<T> : IEntityGenerator<T>
        where T : class, new()
    {
        private readonly IRandomValueGenerator _valueGenerator;
        readonly ICollection<IPropertyBuilderConfig> builderConfigs;
        private readonly ICollection<T> entitiesGenerates;
        private int numEntitiesToGenerate;
        int aux = 0;
        int oldAux;
        public BaseGeneratorProfile()
        {
            builderConfigs = new List<IPropertyBuilderConfig>();
            _valueGenerator = new RandomValueGenerator();
            entitiesGenerates = new List<T>();
        }

        private T GenerateEntity()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            T entity = new T();
            if (properties.Length > 0)
            {
                if (builderConfigs.Count > 0)
                {
                    foreach (PropertyInfo property in properties)
                    {

                        IPropertyBuilderConfig searchBuilder = builderConfigs.SingleOrDefault(w => w.PropertyName.Equals(property.Name));

                        if (searchBuilder != null)
                        {

                            if (searchBuilder.Parameters.Count > 0)
                            {
                                KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>("IsUnique", "True");
                                if (searchBuilder.Parameters.Contains(keyValuePair))
                                {
                                    GenerateUniqueValueFromConfig(property, searchBuilder.Parameters, entity, entitiesGenerates);
                                }
                                else
                                {
                                    GenerateValueFromConfig(property, entity, searchBuilder.Parameters);
                                }

                            }
                            else
                            {
                                GenerateAutomaticValue(property, entity);
                            }
                        }
                        else
                        {
                            GenerateAutomaticValue(property, entity);
                        }

                    }
                    return entity;
                }
                else
                {
                    return GenerateEntityWhithoutConfig();
                }

            }
            throw new Exception("entity dont have properties");

        }
        private T GenerateEntityWhithoutConfig()
        {
            T entity = new T();
            Type type = typeof(T);
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (type.GetProperty(property.Name) != null)
                {

                    GenerateAutomaticValue(property, entity);
                }
            }
            return entity;
        }
        public ICollection<T> GenerateEntities(int n = 1)
        {
            for (int i = 0; i < n; i++)
            {
                numEntitiesToGenerate = n;
                entitiesGenerates.Add(GenerateEntity());
            }
            return entitiesGenerates;
        }

        protected IPropertyBuilderConfig RuleForParameter<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            MemberExpression expressions = expression.Body as MemberExpression;
            string name = expressions.Member.Name;
            PropertyBuilderConfig<TProperty> entityBuilderConfig = new PropertyBuilderConfig<TProperty>(name);
            builderConfigs.Add(entityBuilderConfig);
            return entityBuilderConfig;

        }

        public IPropertyBuilderConfig AddRuleForParameter<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            MemberExpression expressions = expression.Body as MemberExpression;
            string name = expressions.Member.Name;
            IPropertyBuilderConfig entityBuilderConfig = builderConfigs.SingleOrDefault(w => w.PropertyName.Equals(name));
            if (entityBuilderConfig == null)
            {
                entityBuilderConfig = new PropertyBuilderConfig<TProperty>(name);
                builderConfigs.Add(entityBuilderConfig);
            }
            return entityBuilderConfig;
        }
        #region GeneraterValues
        private void GenerateValueFromConfig(PropertyInfo property, T entity, IDictionary<string, string> parameters)
        {
            TypeCode typeCode = Type.GetTypeCode(property.PropertyType);
            switch (typeCode)
            {
                case TypeCode.Boolean:
                    property.SetValue(entity, _valueGenerator.GetRandomBool());
                    break;
                case TypeCode.Char:
                    property.SetValue(entity, _valueGenerator.GetRandomCharFromParameters(parameters));
                    break;
                case TypeCode.DateTime:
                    property.SetValue(entity, _valueGenerator.GetRandomDateFromParameters(parameters));
                    break;
                case TypeCode.Decimal:
                    property.SetValue(entity, (decimal)_valueGenerator.GetRandomDoubleFromParameters(parameters));
                    break;
                case TypeCode.Double:

                    property.SetValue(entity, _valueGenerator.GetRandomDoubleFromParameters(parameters));
                    break;
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    property.SetValue(entity, _valueGenerator.GetRandomIntFromParameters(parameters));
                    break;
                case TypeCode.String:
                    property.SetValue(entity, _valueGenerator.GetRandomStringFromParameters(parameters));
                    break;
                case TypeCode.Single:
                    property.SetValue(entity, (float)_valueGenerator.GetRandomDoubleFromParameters(parameters));
                    break;

            }
        }
        private void GenerateUniqueValueFromConfig(PropertyInfo property, IDictionary<string, string> parameters, T entity, ICollection<T> entities)
        {
            TypeCode typeCode = Type.GetTypeCode(property.PropertyType);
            switch (typeCode)
            {
                case TypeCode.Single:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    GenerateUniqueIntKeyFromParameters(property, parameters, entity, entities);
                    break;
                case TypeCode.String:
                    GenerateUniqueStringKeyFromParameters(property, parameters, entity, entities);
                    break;
                default:
                    throw new Exception($"Unique key not is permit for  type {property.PropertyType} in parameter {property.Name} ");
            }
        }
        private void GenerateAutomaticValue(PropertyInfo property, T entity)
        {
            TypeCode typeCode = Type.GetTypeCode(property.PropertyType);
            switch (typeCode)
            {
                case TypeCode.Boolean:
                    property.SetValue(entity, _valueGenerator.GetRandomBool());
                    break;
                case TypeCode.Char:
                    property.SetValue(entity, _valueGenerator.GetRandomChar());
                    break;
                case TypeCode.DateTime:
                    property.SetValue(entity, _valueGenerator.GetRandomDate());
                    break;
                case TypeCode.Decimal:
                    property.SetValue(entity, (decimal)_valueGenerator.GetRandomDouble());
                    break;
                case TypeCode.Double:
                    property.SetValue(entity, _valueGenerator.GetRandomDouble());
                    break;
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    property.SetValue(entity, _valueGenerator.GetRandomInt());
                    break;
                case TypeCode.String:
                    property.SetValue(entity, _valueGenerator.GetRandomString());
                    break;
                case TypeCode.Single:
                    property.SetValue(entity, (float)_valueGenerator.GetRandomDouble());
                    break;
            }
        }
        #endregion
        private void GenerateUniqueIntKeyFromParameters(PropertyInfo property, IDictionary<string, string> parameters, T entity, ICollection<T> entities)
        {

            if (Type.GetTypeCode(property.PropertyType) == TypeCode.Int32)
            {
                bool containsMaxValue = parameters.ContainsKey("MaxValue");
                bool containsMinValue = parameters.ContainsKey("MinValue");
                if (containsMaxValue && containsMinValue)
                {

                    int max = Convert.ToInt32(parameters["MaxValue"]);
                    int min = Convert.ToInt32(parameters["MinValue"]);
                    int rest = max - min;
                    if (rest < numEntitiesToGenerate)
                    {
                        throw new Exception($"The num of entities are biggert the restriction max: {max}-min:{min}  when the parameter is unique");
                    }
                    else
                    {
                        oldAux = aux;
                        aux = min;
                        if (oldAux == aux)
                        {
                            aux = oldAux + 1;
                        }
                        while (oldAux >= aux)
                        {
                            aux++;
                        }
                        property.SetValue(entity, aux);

                    }
                }
                else if (containsMaxValue && !containsMinValue)
                {
                    int max = Convert.ToInt32(parameters["MaxValue"]);
                    int min = max - numEntitiesToGenerate;
                    oldAux = aux;
                    aux = min;
                    if (oldAux == aux)
                    {
                        aux = oldAux + 1;
                    }
                    while (oldAux >= aux)
                    {
                        aux++;
                    }
                    property.SetValue(entity, aux);
                }
                else if (!containsMaxValue && containsMinValue)
                {
                    int min = Convert.ToInt32(parameters["MinValue"]);
                    // int max = min + numEntitiesToGenerate;
                    oldAux = aux;
                    aux = min;
                    if (oldAux == aux)
                    {
                        aux = oldAux + 1;
                    }
                    while (oldAux >= aux)
                    {
                        aux++;
                    }
                    property.SetValue(entity, aux);
                }
                else
                {
                    oldAux = aux;
                    aux = 1;
                    if (oldAux == aux)
                    {
                        aux = oldAux + 1;
                    }
                    while (oldAux >= aux)
                    {
                        aux++;
                    }
                    property.SetValue(entity, aux);
                }
            }


        }

        private void GenerateUniqueStringKeyFromParameters(PropertyInfo property, IDictionary<string, string> parameters, T entity, ICollection<T> entities)
        {
            string key = GetUniqueString(property, parameters, entities);
            property.SetValue(entity, key);

        }

        private string GetUniqueString(PropertyInfo property, IDictionary<string, string> parameters, ICollection<T> entities)
        {
            string key = _valueGenerator.GetRandomStringFromParameters(parameters);
            foreach (T entity in entities)
            {
                if (property.GetValue(entity).ToString().ToUpper().Equals(key))
                {
                    key = GetUniqueString(property, parameters, entities);
                }
            }
            return key;
        }


    }


}
