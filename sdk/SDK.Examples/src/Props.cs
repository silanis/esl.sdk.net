using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SDK.Examples
{
    public class Props
    {
        private static Props _instance;
        public static Props GetInstance()
            {
            return _instance ?? (_instance = new Props("signers.json"));
            }

        private readonly Dictionary<string, string> _dictionary;

        public Props(string filename)
        {
            var json = File.ReadAllText(filename);
            _dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public string Get(string key)
                    {
            return _dictionary[key];
        }

        public string this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value; }
        }
    }
}
