using System;
using TechTalk.SpecFlow;

namespace SpecAid
{
    public class RecallAid
    {
        private static RecallAid instance;
        private RecallAid() {}

        public object this[string index]
        {
            get
            {
                string lookup = index.ToLower();

                if (!ScenarioContext.Current.ContainsKey(lookup))
                {
                    throw new Exception(string.Format("error: Given key \"{0}\" not found in dictionary", index));
                }

                return ScenarioContext.Current[lookup];
            }
            set
            {
                string lookup = index.ToLower();
                if (ScenarioContext.Current.ContainsKey(lookup))
                {
                    Console.WriteLine("Caution: ScenarioContext all ready has item: " + index);
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
            string lookup = key.ToLower();
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
                if (instance == null)
                {
                    instance = new RecallAid();
                }
                return instance;
            }
        }
    }
}
