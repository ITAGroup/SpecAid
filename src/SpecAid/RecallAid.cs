using System;
using SpecAid.Helper;
using TechTalk.SpecFlow;

namespace SpecAid
{
    public class RecallAid
    {
        private static RecallAid _instance;
        private RecallAid() {}

        public object this[string key]
        {
            get
            {
                var lookup = NormalizeKey(key);

                if (!ScenarioContext.Current.ContainsKey(lookup))
                {
                    throw new Exception(string.Format("error: Given key \"{0}\" not found in dictionary", key));
                }

                return ScenarioContext.Current[lookup];
            }
            set
            {
                var lookup = NormalizeKey(key);

                if (ScenarioContext.Current.ContainsKey(lookup))
                {
                    Console.WriteLine("Caution: ScenarioContext all ready has item: " + key);
                }
                ScenarioContext.Current[lookup] = value;
            }
        }

        public object this[Type type]
        {
            get
            {
                return this[type.ToString()];
            }
            set
            {
                string stuff = type.ToString();
                this[stuff] = value;
            }
        }

        public bool ContainsKey(string key)
        {
            var lookup = NormalizeKey(key);
            return ScenarioContext.Current.ContainsKey(lookup);
        }

        public bool ContainsKey(Type type)
        {
            return ContainsKey(type.ToString());
        }

        public void Remove(string key)
        {
            string lookup = key.ToLower();
            ScenarioContext.Current.Remove(lookup);
        }

        public void Remove(Type type)
        {
            Remove(type.ToString());
        }

        public static RecallAid It
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RecallAid();
                }
                return _instance;
            }
        }

        private string NormalizeKey(string key)
        {
            var keyLower = key.ToLowerInvariant();
            var tagNormal = TagHelper.Normalizer(keyLower);
            return tagNormal;
        }
    }
}
