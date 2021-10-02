using Core.Entities.Utilities.EntityGenerator.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Entities.Utilities.EntityGenerator
{
    public class RandomValueGenerator : IRandomValueGenerator
    {
        #region automatic
        public char GetRandomChar(char end = 'z', char init = 'a')
        {
            if (init>end)
            {
                throw new Exception("min char value can be biggert that max value");
            }
            Random rnd = new Random();
            char randomChar = (char)rnd.Next(init, end);
            return randomChar;
        }

        public char GetRandomChar(List<char> values)
        {
            if (values.Count > 0)
            {
                int n = values.Count;
                Random random = new Random();
                n = random.Next(0, n);
                return values[n];
            }
            throw new Exception("values can't be empty");
        }

        public DateTime GetRandomDate(DateTime? startDate = null, DateTime? finishDate = null)
        {
            int[] month31 = new int[] { 1, 3, 5, 7, 8, 10, 12 };
            int[] month30 = new int[] { 4, 6, 9, 11 };
            Random random = new Random();
            DateTime date;
            int yearStart, monthStart, dayStart, hourStart, minStart, secondStart, milisecondsStart;
            int yearfinish, monthfinish, dayfinish, hourfinish, minfinish, secondfinish, milisecondsfinish;
            if (startDate == null && finishDate == null)
            {
                date = DateTime.Now;
            }
            else
            {
                int year, month, day, hour, min, second, milisecond;
                if (!startDate.HasValue && finishDate.HasValue)
                {
                    startDate = finishDate.Value.AddYears(-10).AddHours(-24).AddMinutes(-60).AddSeconds(-60).AddMilliseconds(-10);
                }
                else if (startDate.HasValue && !finishDate.HasValue)
                {
                    finishDate = startDate.Value.AddYears(10).AddHours(-24).AddMinutes(-60).AddSeconds(-60).AddMilliseconds(-10);
                }
                if (startDate > finishDate)
                {
                    throw new Exception("start date can't be over finishDate");
                }


                yearStart = startDate.Value.Year;
                monthStart = startDate.Value.Month;
                dayStart = startDate.Value.Day;
                hourStart = startDate.Value.Hour;
                minStart = startDate.Value.Minute;
                secondStart = startDate.Value.Second;
                milisecondsStart = startDate.Value.Millisecond;

                yearfinish = finishDate.Value.Year;
                monthfinish = finishDate.Value.Month;
                dayfinish = finishDate.Value.Day;
                hourfinish = finishDate.Value.Hour;

                minfinish = finishDate.Value.Minute;
                secondfinish = finishDate.Value.Second;
                milisecondsfinish = finishDate.Value.Millisecond;

                year = random.Next(yearStart, yearfinish + 1);
                month = monthStart > monthfinish ? random.Next(0, monthfinish + 1) : random.Next(monthStart, monthfinish + 1);
                hour = hourStart > hourfinish ? random.Next(0, hourfinish + 1) : random.Next(hourStart, hourfinish + 1);
                min = minStart > minfinish ? random.Next(0, minfinish + 1) : random.Next(minStart, minfinish + 1);
                second = secondStart > secondfinish ? random.Next(0, secondfinish + 1) : random.Next(secondStart, secondfinish + 1);
                milisecond = milisecondsStart > milisecondsfinish ? random.Next(0, milisecondsfinish + 1) : random.Next(milisecondsStart, milisecondsfinish + 1);
                if (month == 2)
                {
                    dayStart = dayStart > dayfinish ? 0 : dayStart;
                    if (year % 4 == 0)
                    {
                        dayfinish = dayfinish > 29 ? 29 : dayfinish;
                    }
                    else
                    {
                        dayfinish = dayfinish > 28 ? 28 : dayfinish;

                    }

                }
                else
                {

                    if (month31.Any(w => w == month))
                    {
                        dayfinish = dayfinish > 31 ? 31 : dayfinish;
                    }
                    else
                    {
                        dayfinish = dayfinish > 30 ? 30 : dayfinish;
                    }
                }

                day = random.Next(dayStart, dayfinish + 1);
                date = new DateTime(year, month, day, hour, min, second, milisecond);

            }
            return date;

        }

        public DateTime GetRandomDate(List<DateTime> values)
        {
            if (values.Count > 0)
            {
                int n = values.Count;
                Random random = new Random();
                n = random.Next(0, n - 1);
                return values[n];
            }
            throw new Exception("values can't be empty");
        }

        public int GetRandomInt(int maxValue = 10, int minValue = 0)
        {
            Random random = new Random();
            int value = random.Next(minValue, maxValue + 1);

            return value;
        }

        public int GetRandomInt(List<int> values)
        {
            if (values.Count > 0)
            {
                int n = values.Count;
                Random random = new Random();
                n = random.Next(0, n - 1);
                return values[n];
            }
            throw new Exception("values can't be empty");
        }

        public double GetRandomDouble(double maxValue = 10, double minValue = 0)
        {
            Random random = new Random();

            double value = random.NextDouble() * (maxValue + 1 - minValue) + minValue;
            return value;
        }

        public double GetRandomDouble(List<double> values)
        {
            if (values.Count > 0)
            {
                int n = values.Count;
                Random random = new Random();
                n = random.Next(0, n - 1);
                return values[n];
            }
            throw new Exception("values can't be empty");
        }

        public string GetRandomString(TextFormats textFormats = TextFormats.Mixed)
        {
            Random random = new Random();
            string g = GetStringByFormat();
            int n = g.Length;
            n = random.Next(2, n);
            string value = g.Substring(0, n);

            return value;
        }

        public string GetRandomString(string[] values)
        {
            if (values.Length > 0)
            {
                int n = values.Length;
                Random random = new Random();
                n = random.Next(0, n);
                return values[n];
            }
            throw new Exception("values can't be empty");

        }

        public string GetRandomString(int maxLength, int minLength = 0, TextFormats textFormats = TextFormats.Mixed)
        {

            string s =GetStringByFormat(textFormats);
            int lenghtInit = s.Length;
            if (lenghtInit < minLength)
            {
                while (s.Length < minLength)
                {
                    s += GetStringByFormat(textFormats);
                }
            }
            int moreLonge = new Random().Next(0, 2);
            if (moreLonge!=0)
            {
                int lenght = new Random().Next(minLength, maxLength+1);
                while (s.Length<lenght)
                {
                    s += GetStringByFormat(textFormats);
                }
            }
            if (s.Length > maxLength)
            {
                s = s.Substring(0, maxLength);
            }

            return s;
        }

        private string GetStringByFormat(TextFormats textFormats = TextFormats.Mixed)
        {
            string s;
            switch (textFormats)
            {
                case TextFormats.OnlyNums:
                    s = GetStringOfNumber(6);
                    break;
                case TextFormats.OnlyText:
                    s = Guid.NewGuid().ToString().Replace("-", "");
                    s = Regex.Replace(s, @"\d{2,}", "");
                    s = Regex.Replace(s, @"\d", "");
                    break;
                default:
                    s = Guid.NewGuid().ToString().Replace("-", "");
                    break;
            }
            return s;
        }

        public bool GetRandomBool()
        {
            Random random = new Random();
            int n = random.Next(0, 2);
            bool value = n == 0;
            return value;
        }

        public string GetRandomNumberPhone()
        {
            string prefix = $"+{GetStringOfNumber(3)}";
            string numPhone = GetStringOfNumber(9);
            string phone = $"{prefix} {numPhone}";

            return phone;


        }

        public string GetStringOfNumber(int n)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < n; i++)
            {
                s = string.Concat(s, random.Next(10).ToString());
            }

            return s;
        }

        public string GetRandomEmail(TextFormats textFormats = TextFormats.Mixed)
        {
            string g = GetStringByFormat(textFormats);

            while (g.Length<9)
            {
                g += GetStringByFormat(textFormats);
            };

            string email = $"{g.Substring(0, 9)}@mail.com";
            return email;
        }

        #endregion

        #region FromParameters

        public DateTime GetRandomDateFromParameters(IDictionary<string, string> parameters)
        {
            DateTime valueFromParameters;
            if (parameters.ContainsKey("Parameters"))
            {
                string[] vs = parameters["Parameters"].Split(";");
                List<DateTime> vs1 = new List<DateTime>();
                foreach (string s in vs)
                {
                    vs1.Add(Convert.ToDateTime(s));
                }
                valueFromParameters = GetRandomDate(vs1);
            }
            else
            {
                if (parameters.ContainsKey("DateEnd") && parameters.ContainsKey("DateStart"))
                {
                    DateTime dateEnd = Convert.ToDateTime(parameters["DateEnd"]);
                    DateTime dateStart = Convert.ToDateTime(parameters["DateStart"]);
                    if (dateStart > dateEnd)
                    {
                        throw new Exception("Date start can't be highert that Date end");
                    }
                    valueFromParameters = GetRandomDate(dateStart, dateEnd);
                }
                else if (parameters.ContainsKey("DateEnd") && !parameters.ContainsKey("DateStart"))
                {
                    DateTime max = Convert.ToDateTime(parameters["DateEnd"]);
                    valueFromParameters = GetRandomDate(null, max);
                }
                else if (!parameters.ContainsKey("DateEnd") && parameters.ContainsKey("DateStart"))
                {
                    DateTime min = Convert.ToDateTime(parameters["DateStart"]);
                    valueFromParameters = GetRandomDate(min);
                }
                else
                {
                    valueFromParameters = GetRandomDate();
                }
            }

            return valueFromParameters;
        }
        public double GetRandomDoubleFromParameters(IDictionary<string, string> parameters)
        {
            double valueFromParameters;
            if (parameters.ContainsKey("Parameters"))
            {
                string[] vs = parameters["Parameters"].Split(";");
                List<double> vs1 = new List<double>();
                foreach (string s in vs)
                {
                    vs1.Add(Convert.ToDouble(s));
                }
                valueFromParameters = GetRandomDouble(vs1);
            }
            else
            {
                if (parameters.ContainsKey("MaxValue") && parameters.ContainsKey("MinValue"))
                {
                    double max = Convert.ToDouble(parameters["MaxValue"]);
                    double min = Convert.ToDouble(parameters["MinValue"]);
                    if (min > max)
                    {
                        throw new Exception("MinValue can't be highert that MaxValue");
                    }
                    valueFromParameters = GetRandomDouble(max, min);
                }
                else if (parameters.ContainsKey("MaxValue") && !parameters.ContainsKey("MinValue"))
                {
                    double max = Convert.ToDouble(parameters["MaxValue"]);
                    if (max == 0)
                    {
                        throw new Exception("Can be max value 0 if don't determinate a negative min value");
                    }
                    valueFromParameters = GetRandomDouble(max);
                }
                else if (!parameters.ContainsKey("MaxValue") && parameters.ContainsKey("MinValue"))
                {
                    double min = Convert.ToDouble(parameters["MinValue"]);
                    if (min > 10)
                    {
                        throw new Exception("Can be max value highter that 10 if don't determinate a max value");
                    }
                    valueFromParameters = GetRandomDouble(10, min);
                }
                else
                {
                    valueFromParameters = GetRandomDouble();
                }
            }

            return valueFromParameters;
        }
        public int GetRandomIntFromParameters(IDictionary<string, string> parameters)
        {
            int valueFromParameters;
            if (parameters.ContainsKey("Parameters"))
            {
                string[] vs = parameters["Parameters"].Split(";");
                List<int> vs1 = new List<int>();
                foreach (string s in vs)
                {
                    vs1.Add(Convert.ToInt32(s));
                }
                valueFromParameters = GetRandomInt(vs1);
            }
            else
            {
                if (parameters.ContainsKey("MaxValue") && parameters.ContainsKey("MinValue"))
                {
                    int max = Convert.ToInt32(parameters["MaxValue"]);
                    int min = Convert.ToInt32(parameters["MinValue"]);
                    if (min > max)
                    {
                        throw new Exception("MinValue can't be highert that MaxValue");
                    }
                    valueFromParameters = GetRandomInt(max, min);
                }
                else if (parameters.ContainsKey("MaxValue") && !parameters.ContainsKey("MinValue"))
                {
                    int max = Convert.ToInt32(parameters["MaxValue"]);
                    if (max == 0)
                    {
                        throw new Exception("Can be max value 0 if don't determinate a negative min value");
                    }
                    valueFromParameters = GetRandomInt(max);
                }
                else if (!parameters.ContainsKey("MaxValue") && parameters.ContainsKey("MinValue"))
                {
                    int min = Convert.ToInt32(parameters["MinValue"]);
                    if (min > 10)
                    {
                        throw new Exception("Can be max value highter that 10 if don't determinate a max value");
                    }
                    valueFromParameters = GetRandomInt(10, min);
                }
                else
                {
                    valueFromParameters = GetRandomInt();
                }
            }

            return valueFromParameters;
        }
        public char GetRandomCharFromParameters(IDictionary<string, string> parameters)
        {
            string valueFromParameters = string.Empty;
            if (parameters.ContainsKey("Parameters"))
            {
                string[] vs = parameters["Parameters"].Split(";");
                List<char> vs1 = new List<char>();
                foreach (string s in vs)
                {
                    vs1.Add(Convert.ToChar(s));
                }
                valueFromParameters = GetRandomChar(vs1).ToString();
            }
            else if (parameters.ContainsKey("MaxValue") || parameters.ContainsKey("MinValue"))
            {
                char max = Convert.ToChar(parameters["MaxValue"]);
                char min = Convert.ToChar(parameters["MinValue"]);
                valueFromParameters =GetRandomChar(max, min).ToString();
            }


            return Convert.ToChar(valueFromParameters);
        }
        public string GetRandomStringFromParameters(IDictionary<string, string> parameters)
        {
            string valueFromParameters = string.Empty;
            TextFormats textFormats = TextFormats.Mixed;
            bool haveParameters = parameters.ContainsKey("Parameters");
            if (parameters.ContainsKey("TextFormat"))
            {
                textFormats = (TextFormats)Enum.Parse(typeof(TextFormats), parameters["TextFormat"], true);
            }
            if (haveParameters)
            {
                string[] vs = parameters["Parameters"].Split(";");
                valueFromParameters = GetRandomString(vs);
            }
            else
            {
                if (parameters.ContainsKey("IsPhone") || parameters.ContainsKey("IsMail"))
                {
                    if (parameters.ContainsKey("IsPhone"))
                    {
                        bool isPhone = Convert.ToBoolean(parameters["IsPhone"]);
                        if (isPhone)
                        {
                            valueFromParameters = GetRandomNumberPhone();
                        }
                    }
                    else
                    {
                        bool IsMail = Convert.ToBoolean(parameters["IsMail"]);
                        if (IsMail)
                        {
                            valueFromParameters = GetRandomEmail(textFormats);
                        }
                    }
                }
                else
                {
                    if (parameters.ContainsKey("MaxLeng") && parameters.ContainsKey("MinLeng"))
                    {
                        int max = Convert.ToInt32(parameters["MaxLeng"]);
                        int min = Convert.ToInt32(parameters["MinLeng"]);
                        if (min > max)
                        {
                            throw new Exception("MinValue can't be highert that MaxValue");
                        }
                        valueFromParameters = GetRandomString(max, min, textFormats);
                    }
                    else if (parameters.ContainsKey("MaxLeng") && !parameters.ContainsKey("MinLeng"))
                    {
                        int max = Convert.ToInt32(parameters["MaxLeng"]);
                        if (max == 0)
                        {
                            throw new Exception("Can be max value equals 0 ");
                        }
                        valueFromParameters = GetRandomString(max, 0, textFormats);
                    }
                    else if (!parameters.ContainsKey("MaxLeng") && parameters.ContainsKey("MinLeng"))
                    {
                        int min = Convert.ToInt32(parameters["MinLeng"]);
                        int max = min + 10;
                        valueFromParameters = GetRandomString(max, min, textFormats);
                    }
                    else
                    {
                        valueFromParameters = GetRandomString(textFormats);
                    }
                }
              
            }
            


            return valueFromParameters;
        }

       

        #endregion


    }
}
