using Core.Entities.Utilities.EntityGenerator.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.EntityGenerator
{
    public class PropertyBuilderConfig<TProperty> : IPropertyBuilderConfig
    {
        public IDictionary<string, string> Parameters { get; set; }
        public string PropertyName { get; set; }
        public PropertyBuilderConfig(string propertyName, IDictionary<string, string> parameters = null)
        {
            PropertyName = propertyName;

            if (parameters == null)
            {
                Parameters = new Dictionary<string, string>();
            }
            else
            {
                Parameters = parameters;
            }

        }

        public IPropertyBuilderConfig IsEmail(bool isEmail = true)
        {

            if (Parameters.ContainsKey("IsMail"))
            {
                Parameters["IsMail"] = isEmail.ToString();
            }
            else
            {
                Parameters.Add("IsMail", isEmail.ToString());
            }
            return this;
        }
        public IPropertyBuilderConfig IsPhoneNumber(bool isPhone = true)
        {
            if (Parameters.ContainsKey("IsPhone"))
            {
                Parameters["IsPhone"] = isPhone.ToString();
            }
            else
            {

                Parameters.Add("IsPhone", isPhone.ToString());

            }

            return this;
        }
        public IPropertyBuilderConfig IsUnique(bool unique = true)
        {
            if (Parameters.ContainsKey("IsUnique"))
            {
                Parameters["IsUnique"] = unique.ToString();
            }
            else
            {

                Parameters.Add("IsUnique", unique.ToString());

            }
            return this;

        }
        public IPropertyBuilderConfig MaxLeng(int max)
        {
            if (Parameters.ContainsKey("MaxLeng"))
            {
                Parameters["MaxLeng"] = max.ToString();
            }
            else
            {


                Parameters.Add("MaxLeng", max.ToString());

            }

            return this;
        }
        public IPropertyBuilderConfig MaxValue(double value)
        {
            if (Parameters.ContainsKey("MaxValue"))
            {
                Parameters["MaxValue"] = value.ToString();
            }
            else
            {


                Parameters.Add("MaxValue", value.ToString());

            }

            return this;
        }
        public IPropertyBuilderConfig DateEnd(DateTime dateTime)
        {
            if (Parameters.ContainsKey("DateEnd"))
            {
                Parameters["DateEnd"] = dateTime.ToString();
            }
            else
            {
                if (Parameters.ContainsKey("DateEnd"))
                {
                    Parameters["DateEnd"] = dateTime.ToString();
                }
                else
                {
                    Parameters.Add("DateEnd", dateTime.ToString());
                }
            }

            return this;
        }
        public IPropertyBuilderConfig MaxValue(char value)
        {
            if (Parameters.ContainsKey("MaxValue"))
            {
                Parameters["MaxValue"] = value.ToString();
            }
            else
            {
                Parameters.Add("MaxValue", value.ToString());
            }
            return this;
        }
        public IPropertyBuilderConfig MinLeng(int min)
        {
            if (Parameters.ContainsKey("MinLeng"))
            {
                Parameters["MinLeng"] = min.ToString();
            }
            else
            {
                Parameters.Add("MinLeng", min.ToString());
            }
            return this;
        }
        public IPropertyBuilderConfig MinValue(double value)
        {
            if (Parameters.ContainsKey("MinValue"))
            {
                Parameters["MinValue"] = value.ToString();
            }
            else
            {
                Parameters.Add("MinValue", value.ToString());
            }
            return this;
        }
        public IPropertyBuilderConfig DateStart(DateTime dateTime)
        {
            if (Parameters.ContainsKey("DateStart"))
            {
                Parameters["DateStart"] = dateTime.ToString();
            }
            else
            {
                Parameters.Add("DateStart", dateTime.ToString());
            }
            return this;
        }
        public IPropertyBuilderConfig MinValue(char value)
        {
            if (Parameters.ContainsKey("MinValue"))
            {
                Parameters["MinValue"] = value.ToString();
            }
            else
            {
                Parameters.Add("MinValue", value.ToString());
            }
            return this;
        }
        public IPropertyBuilderConfig IsEnum(Type enumType)
        {

            Array enumValues = Enum.GetValues(enumType);
            if (Parameters.ContainsKey("MaxValue"))
            {
                Parameters["MaxValue"] = (enumValues.Length - 1).ToString();
            }
            else
            {
                Parameters.Add("MaxValue", (enumValues.Length - 1).ToString());
            }
            if (!Parameters.ContainsKey("MinValue"))
            {
                Parameters.Add("MinValue", "0");
            }

            return this;
        }
        public IPropertyBuilderConfig ParamsFilter(ICollection<string> parameters)
        {
            string filters = string.Empty;
            foreach (string s in parameters)
            {
                filters += s + ";";
            }
            filters = filters.Remove(filters.Length - 1);
            if (Parameters.ContainsKey("Parameters"))
            {
                Parameters["Parameters"] = filters;
            }
            else
            {
                if (Parameters.ContainsKey("Parameters"))
                {
                    Parameters["Parameters"] = filters;
                }
                else
                {
                    Parameters.Add("Parameters", filters);
                }
            }

            return this;
        }
        public IPropertyBuilderConfig TextFormat(TextFormats textFormats)
        {
            if (Parameters.ContainsKey("TextFormat"))
            {
                Parameters["TextFormat"] = textFormats.ToString();
            }
            else
            {
                Parameters.Add("TextFormat", textFormats.ToString());
            }
            return this;
        }
    }
}
