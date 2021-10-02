using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.EntityGenerator.Abstracts
{
    public interface IPropertyBuilderConfig
    {
        /// <summary>
        /// Dictionary to parameters
        /// </summary>
        IDictionary<string, string> Parameters { get; set; }
        /// <summary>
        /// PropertyName
        /// </summary>
        string PropertyName { get; set; }
        /// <summary>
        /// determinate is the value is unique only permit in strings and int values
        /// </summary>
        /// <param name="unique">bool</param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig IsUnique(bool unique = true);
        /// <summary>
        /// Determinate max lenght in property value
        /// </summary>
        /// <param name="max">max value</param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig MaxLeng(int max);
        /// <summary>
        /// Determinate a min lenght in property value
        /// </summary>
        /// <param name="min">min value</param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig MinLeng(int min);
        /// <summary>
        /// Determinate a min double value 
        /// </summary>
        /// <param name="value">double value</param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig MinValue(double value);
        /// <summary>
        /// Determinate a max double value
        /// </summary>
        /// <param name="value">double value</param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig MaxValue(double value);
        /// <summary>
        /// Determinate a min Datetime value
        /// </summary>
        /// <param name="dateTime">datetime value</param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig DateStart(DateTime dateTime);
        /// <summary>
        /// Determinate a max Datetime value
        /// </summary>
        /// <param name="dateTime">Datetime value</param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig DateEnd(DateTime dateTime);
        /// <summary>
        /// Determinate a min char value
        /// </summary>
        /// <param name="value">cha</param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig MinValue(char value);
        /// <summary>
        /// Determinate a max char value
        /// </summary>
        /// <param name="value">char</param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig MaxValue(char value);
        /// <summary>
        /// Determinate if value is a phone
        /// </summary>
        /// <param name="isPhone">true or false</param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig IsPhoneNumber(bool isPhone = true);
        /// <summary>
        /// Determinate if value is a email
        /// </summary>
        /// <param name="isEmail"></param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig IsEmail(bool isEmail = true);
        /// <summary>
        /// Determinate parameters to filter
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig ParamsFilter(ICollection<string> parameters);
        /// <summary>
        /// Determinate if value is enum
        /// </summary>
        /// <param name="enumType">type of enum</param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig IsEnum(Type enumType);
        /// <summary>
        /// Determinate textFormat for string
        /// </summary>
        /// <param name="textFormats"></param>
        /// <returns>IProperyBuilderConfig with parameters</returns>
        IPropertyBuilderConfig TextFormat(TextFormats textFormats);
    }
}
