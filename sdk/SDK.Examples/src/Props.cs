using System;
using System.Collections.Generic;
using System.IO;

namespace SDK.Examples
{
    public class Props
    {
        private static Props instance = null;
        public static Props GetInstance() {
            if (instance == null)
            {
                instance = new Props("signers.properties");
            }
            return instance;
        }

        private Dictionary<string,string> dictionary;

        public Props( String filename )
        {
            dictionary = new Dictionary<string, string>();
            foreach (string line in File.ReadAllLines(filename))
            {
                if ((!string.IsNullOrEmpty(line)) &&
                    (!line.StartsWith(";")) &&
                    (!line.StartsWith("#")) &&
                    (!line.StartsWith("'")) &&
                    (line.Contains("=")))
                {
                    int index = line.IndexOf('=');
                    string key = line.Substring(0, index).Trim();
                    string value = line.Substring(index + 1).Trim();

                    if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                        (value.StartsWith("'") && value.EndsWith("'")))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }
                    dictionary.Add(key, value);
                }
            }
        }

        public string Get( string key ) {
            return dictionary[key];
        }
    }
}

