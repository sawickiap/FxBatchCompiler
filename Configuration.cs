using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FXBC
{
    // Represents application configuration loaded to memory
    static class Configuration
    {
        // Dictionary Key => Value
        private static System.Collections.Specialized.StringDictionary m_Data;

        // Return name of configuration file with full path
        private static string GetFileName()
        {
            return Path.Combine(System.Windows.Forms.Application.StartupPath, "Config.dat");
        }

        // Load configuration from file
        // Call at startup.
        public static void Load()
        {
            m_Data = new System.Collections.Specialized.StringDictionary();

            using (System.IO.StreamReader File = new System.IO.StreamReader(GetFileName()))
            {
                string Line;
                while ((Line = File.ReadLine()) != null)
                {
                    Line = Line.Trim();
                    if (Line.Length == 0)
                        continue;

                    int EqPos = Line.IndexOf('=');
                    if (EqPos == -1)
                        throw new Exception("Error in configuration file: " + GetFileName());
                    string Key = Line.Substring(0, EqPos);
                    string Value = Line.Substring(EqPos + 1);
                    if (Key.Length == 0)
                        throw new Exception("Error in configuration file: " + GetFileName());
                    m_Data.Add(Key, Value);
                }
            }
        }

        // Save configuration to file
        // Call after configuration change.
        public static void Save()
        {
            using (System.IO.StreamWriter File = new System.IO.StreamWriter(GetFileName()))
            {
                foreach (System.Collections.DictionaryEntry de in m_Data)
                    File.WriteLine(de.Key + "=" + de.Value);
            }
        }

        // Returns true if key with given name exists in the configuration
        public static bool KeyExists(string Key)
        {
            return m_Data.ContainsKey(Key);
        }

        // Returns value of configuration entry with given key name
        // If there isn't such key, throws exception.
        public static string GetString(string Key)
        {
            string R = m_Data[Key];
            if (R == null)
                throw new Exception(string.Format("Configuration.GetString: Key {0} not found", Key));
            return R;
        }

        // Sets value of configuration entry with given key
        // If there is no such key, creates one. If there is one, replaces its value.
        public static void SetString(string Key, string Value)
        {
            m_Data[Key] = Value;
        }

        // Returns value of configuration entry with given key name parsed as integer
        // On error (conversion error, among others) throws exception.
        public static int GetInt(string Key)
        {
            return int.Parse(GetString(Key));
        }

        // Sets value of configuration entry with given key to given numeric value
        public static void SetInt(string Key, int Value)
        {
            SetString(Key, Value.ToString());
        }
    }
}
