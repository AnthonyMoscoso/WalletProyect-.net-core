using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core.Entities.Utilities.EntityGenerator.Abstracts
{
    public interface IRandomValueGenerator
    {
        /// <summary>
        /// Generate a random char
        /// </summary>
        /// <returns>a random char</returns>
        char GetRandomChar(char init = 'a',char end='z');
        /// <summary>
        /// Generate a random char from a collection of char
        /// </summary>
        /// <param name="values"></param>
        /// <returns>random char</returns>
        char GetRandomChar(List<char> values);

        /// <summary>
        /// Generate a random Datetime
        /// </summary>
        /// <param name="startDate">min date for generate</param>
        /// <param name="finishDate">max date for generate</param>
        /// <returns>a random Date/returns>
        DateTime GetRandomDate(DateTime? startDate = null, DateTime? finishDate = null);
        /// <summary>
        /// Generate a random Datetime from a list 
        /// </summary>
        /// <param name="values">list of datetime</param>
        /// <returns>random datetime</returns>
        DateTime GetRandomDate(List<DateTime> values);
        /// <summary>
        /// Genetare a random int from max or minValue
        /// </summary>
        /// <param name="maxValue">max value</param>
        /// <param name="minValue">min value</param>
        /// <returns>random int</returns>
        int GetRandomInt(int maxValue = 10, int minValue = 0);
        /// <summary>
        /// Take a random int fron a list of values
        /// </summary>
        /// <param name="values">list of int</param>
        /// <returns>one of list entities</returns>
        int GetRandomInt(List<int> values);
        /// <summary>
        /// Generate a random double
        /// </summary>
        /// <param name="maxValue">max value</param>
        /// <param name="minValue">min value</param>
        /// <returns>a random double</returns>
        double GetRandomDouble(double maxValue = 10, double minValue = 0);
        /// <summary>
        ///  Generate a random double
        /// </summary>
        /// <param name="values">list to get a double</param>
        /// <returns>double from list</returns>
        double GetRandomDouble(List<double> values);
        /// <summary>
        /// Generate a random string
        /// </summary>
        /// <param name="textFormats">format of text</param>
        /// <returns>random string</returns>
        string GetRandomString(TextFormats textFormats = TextFormats.Mixed);
        /// <summary>
        /// Generate a random string from a list
        /// </summary>
        /// <param name="values">list of string</param>
        /// <returns>random string from list</returns>
        string GetRandomString(string[] values);
        /// <summary>
        /// Generate a random string 
        /// </summary>
        /// <param name="maxLength">max lenght to string</param>
        /// <param name="minLength">min lenght to string </param>
        /// <param name="textFormats">text format</param>
        /// <returns>random string</returns>
        string GetRandomString(int maxLength, int minLength = 0, TextFormats textFormats = TextFormats.Mixed);
        /// <summary>
        /// Generate a random bool
        /// </summary>
        /// <returns>random bool</returns>
        bool GetRandomBool();
        /// <summary>
        /// Generate a random Phone number
        /// </summary>
        /// <returns>phone number</returns>
        string GetRandomNumberPhone();
        /// <summary>
        /// Generate a random string of numbers
        /// </summary>
        /// <param name="n">string only with numbers</param>
        /// <returns></returns>
        string GetStringOfNumber(int n);
        /// <summary>
        /// Generate a random email
        /// </summary>
        /// <param name="textFormats">type of text</param>
        /// <returns>email</returns>
        string GetRandomEmail(TextFormats textFormats = TextFormats.Mixed);

        #region From parameters
        /// <summary>
        /// Generate a random date from parameters in a dictionary
        /// </summary>
        /// <param name="parameters">keys and value for rules to generate a random date</param>
        /// <returns>the random date generate</returns>
        DateTime GetRandomDateFromParameters(IDictionary<string, string> parameters);
        /// <summary>
        /// Generate a random Double from parameters in a dictionary
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        double GetRandomDoubleFromParameters(IDictionary<string, string> parameters);
        /// <summary>
        /// Generate a random Int from parameters in a dictionary
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int GetRandomIntFromParameters(IDictionary<string, string> parameters);
        /// <summary>
        /// Generate a random Char from parameters in a dictionary
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        char GetRandomCharFromParameters(IDictionary<string, string> parameters);
        /// <summary>
        /// Generate a random string from parameters in a dictionary
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        string GetRandomStringFromParameters(IDictionary<string, string> parameters);


        #endregion;
    }
}
