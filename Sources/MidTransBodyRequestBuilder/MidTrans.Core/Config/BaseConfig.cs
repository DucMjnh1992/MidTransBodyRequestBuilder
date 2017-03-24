using System;
using System.Collections.Generic;
using System.Configuration;

namespace MidTrans.Core
{
    public class BaseConfig
    {
        public const char MULTI_VALUE_SEPERATOR = ',';

        public static string ReadAppSettingValue(string key, string defaultValue = default(string))
        {
            try
            {
                string value = ConfigurationManager.AppSettings[key];

                if (string.IsNullOrWhiteSpace(value))
                {
                    value = defaultValue;
                }

                return value;
            }
            catch
            {
            }

            return defaultValue;
        }

        public static IList<string> ReadAppSettingListStringValue(string key, IList<string> defaultValue = default(IList<string>))
        {
            try
            {
                string value = ReadAppSettingValue(key);

                if (string.IsNullOrWhiteSpace(value))
                {
                    return defaultValue;
                }

                IList<string> values = Split(value);

                return values;
            }
            catch
            {
            }

            return defaultValue;
        }

        public static IList<int> ReadAppSettingListIntValue(string key, IList<int> defaultValue = default(IList<int>))
        {
            try
            {
                string value = ReadAppSettingValue(key);

                if (string.IsNullOrWhiteSpace(value))
                {
                    return defaultValue;
                }

                IList<string> values = Split(value);
                IList<int> results = new List<int>();

                foreach (string item in values)
                {
                    int outItem = 0;

                    if (!int.TryParse(item, out outItem))
                    {
                        continue;
                    }

                    results.Add(outItem);
                }

                return results;
            }
            catch
            {
            }

            return defaultValue;
        }

        public static bool ReadAppSettingBoolValue(string key, bool defaultValue = default(bool))
        {
            try
            {
                string value = ReadAppSettingValue(key);

                if (string.IsNullOrWhiteSpace(value))
                {
                    return defaultValue;
                }

                bool result = defaultValue;

                if (!bool.TryParse(value, out result))
                {
                    return defaultValue;
                }

                return result;
            }
            catch
            {
            }

            return defaultValue;
        }

        public static int ReadAppSettingIntValue(string key, int defaultValue = default(int))
        {
            try
            {
                string value = ReadAppSettingValue(key);

                if (string.IsNullOrWhiteSpace(value))
                {
                    return defaultValue;
                }

                int result = defaultValue;

                if (!int.TryParse(value, out result))
                {
                    return defaultValue;
                }

                return result;
            }
            catch
            {
            }

            return defaultValue;
        }

        public static IList<string> Split(string value, char separator = MULTI_VALUE_SEPERATOR, IList<string> defaultValue = null)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            string[] values = value.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);

            return values;
        }
    }
}
