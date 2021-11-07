using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Core.Entities.Utilities.ExpressionsConverter
{
    public static class MappingExpressions
    {
        public static dynamic GetTPropertyExpressionFromStringParameter<T>(string parameter)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "w");
            MemberExpression memberExpression = Expression.Property(parameterExpression, parameter);
            if (typeof(T).GetProperty(parameter) == null)
            {
                throw new Exception($"{nameof(T)} dont have {parameter} property");
            }
            PropertyInfo property = typeof(T).GetProperty(parameter);
            Type type = property.PropertyType;
            TypeCode typeCode = Type.GetTypeCode(type);
            Expression expression = null;
            switch (typeCode)
            {
                case TypeCode.Boolean:
                    expression = Expression.Lambda<Func<T, bool>>(memberExpression, parameterExpression);
                    break;
                case TypeCode.Byte:
                    expression = Expression.Lambda<Func<T, byte>>(memberExpression, parameterExpression);
                    break;
                case TypeCode.Int64:
                case TypeCode.Int32:
                case TypeCode.Int16:
                expression = Expression.Lambda<Func<T, int>>(memberExpression, parameterExpression);
                    break;
                case TypeCode.Single:
                    expression = Expression.Lambda<Func<T, Single>>(memberExpression, parameterExpression);
                    break;
                case TypeCode.Decimal:
                    expression = Expression.Lambda<Func<T, decimal>>(memberExpression, parameterExpression);
                    break;
                case TypeCode.Double:
                    expression = Expression.Lambda<Func<T, double>>(memberExpression, parameterExpression);
                    break;
                case TypeCode.Char:
                    expression = Expression.Lambda<Func<T, char>>(memberExpression, parameterExpression);
                    break;
                case TypeCode.Object:
                    expression = Expression.Lambda<Func<T, object>>(memberExpression, parameterExpression);
                    break;
                case TypeCode.DateTime:
                    expression = Expression.Lambda<Func<T, DateTime>>(memberExpression, parameterExpression);
                    break;
                case TypeCode.String:
                    expression = Expression.Lambda<Func<T, string>>(memberExpression, parameterExpression);
                    break;
                default:
                    expression = Expression.Lambda<Func<T, dynamic>>(memberExpression, parameterExpression);
                    break;
            }
            return expression;
        }

        public static Expression<Func<T, TProperty>> GetTPropertyExpressionFromStringParameter<T, TProperty>(string parameter)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "w");
            MemberExpression memberExpression = Expression.Property(parameterExpression, parameter);
            if (typeof(T).GetProperty(parameter) == null)
            {
                throw new Exception($"{typeof(T).Name} dont have {parameter} property");
            }
            PropertyInfo property = typeof(T).GetProperty(parameter);
            Type type = property.PropertyType;
            TypeCode typeCode = Type.GetTypeCode(type);
            Expression<Func<T, TProperty>> expression = Expression.Lambda<Func<T, TProperty>>(memberExpression, parameterExpression);
            return expression;
        }

        public static dynamic GetTPropertyExpressionFromStringParameter<T>(string value,PropertyList propertyList)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "w");
            MemberExpression memberExpression = Expression.Property(parameter, value);
            if (typeof(T).GetProperty(value) == null)
            {
                throw new Exception($"{nameof(T)} dont have {value} property");
            }
            PropertyInfo property = typeof(T).GetProperty(value);
            Type type = property.PropertyType;
            Expression expression = Expression.Lambda(memberExpression,parameter);
            switch (propertyList)
            {
                case PropertyList.boolean:
                    expression = Expression.Lambda<Func<T, bool>>(memberExpression, parameter);
                    break;
                case PropertyList.bytes:
                    expression = Expression.Lambda<Func<T, byte>>(memberExpression, parameter);
                    break;
                case PropertyList.integer:
                    expression = Expression.Lambda<Func<T, int>>(memberExpression, parameter);
                    break;
                case PropertyList.decimals:
                    expression = Expression.Lambda<Func<T, decimal>>(memberExpression, parameter);
                    break;
                case PropertyList.doubles:
                    expression = Expression.Lambda<Func<T, double>>(memberExpression, parameter);
                    break;
                case PropertyList.chars:
                    expression = Expression.Lambda<Func<T, char>>(memberExpression, parameter);
                    break;
                case PropertyList.objects:
                    expression = Expression.Lambda<Func<T, object>>(memberExpression, parameter);
                    break;
                case PropertyList.Date:
                    expression = Expression.Lambda<Func<T, DateTime>>(memberExpression, parameter);
                    break;
                case PropertyList.strings:
                    expression = Expression.Lambda<Func<T, string>>(memberExpression, parameter);
                    break;
                case PropertyList.floats:
                    expression = Expression.Lambda<Func<T, float>>(memberExpression, parameter);
                    break;
                default:
                    expression = Expression.Lambda<Func<T, dynamic>>(memberExpression, parameter);
                    break;
            }
            return expression;
        }

        public static Expression<Func<T, TProperty>> MapTPropertyExpression<TEntity,TProperty,T>(Expression<Func<TEntity, TProperty>> property)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "w"); // The second parameter is optional.
            MemberExpression propertyMemberExpression = property.Body as MemberExpression;
            string filter = propertyMemberExpression.Member.Name;
            MemberExpression memberExpression = Expression.Property(parameterExpression, filter);
            Expression<Func<T, TProperty>> expression = Expression.Lambda<Func<T, TProperty>>(memberExpression, parameterExpression);
            return expression;
        }
        public enum PropertyList
        {
            boolean,bytes,integer,decimals,doubles,chars,objects,strings,Date,floats
        }
    }
}
