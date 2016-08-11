using System;
using System.Collections.Generic;

namespace CollectionsFundamentals.Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            IntroducingDictionary();
            EnumeratingDictionaryItems();
            LookingUpDictionaryItems();
            ModyfyingDictionary();
            ComparingKeysWithIEqualityComparer();
            WritingCustomEqualityComparer();
        }

        private static void WritingCustomEqualityComparer()
        {
            var primeMinisters = new Dictionary<string, PrimeMinister>
            (new UncasedStringEqualityComparer()) // custom EqualityComparer class
            {
                {"JC", new PrimeMinister("James Callaghan", 1976)} ,
                {"MT", new PrimeMinister("Margaret Thatcher", 1979)} ,
                {"TB", new PrimeMinister("Tony Blair", 1997)}
            };

            Console.WriteLine(primeMinisters["tb"]); // Works when IEqualityComparer is passed in constructor

        }

        private static void ComparingKeysWithIEqualityComparer()
        {
            var primeMinisters = new Dictionary<string, PrimeMinister>
            (StringComparer.InvariantCultureIgnoreCase) // passing IEqualityComparer in ctor
            {
                {"JC", new PrimeMinister("James Callaghan", 1976)} ,
                {"MT", new PrimeMinister("Margaret Thatcher", 1979)} ,
                {"TB", new PrimeMinister("Tony Blair", 1997)}
            };

            Console.WriteLine(primeMinisters["tb"]); // Works when IEqualityComparer is passed in constructor

        }

        private static void ModyfyingDictionary()
        {
            var primeMinisters = new Dictionary<string, PrimeMinister>
            {
                {"JC", new PrimeMinister("James Callaghan", 1976)} ,
                {"MT", new PrimeMinister("Margaret Thatcher", 1979)} ,
                {"TB", new PrimeMinister("Tony Blair", 1997)}
            };

            primeMinisters["JC"] = new PrimeMinister("Jim Callaghan", 1976); // NOTE: modyfying dictionary object

            primeMinisters["JM"] = new PrimeMinister("John Major", 1990); // NOTE: add one way
            primeMinisters.Add("GB", new PrimeMinister("Gordon Brown", 2007)); // NOTE: add second way

            primeMinisters.Remove("JC"); // NOTE: removing from dictionary

            foreach (var pm in primeMinisters)
            {
                Console.WriteLine(pm);
            }
        }

        private static void LookingUpDictionaryItems()
        {
            var primeMinisters = new Dictionary<string, PrimeMinister>
            {
                {"JC", new PrimeMinister("James Callaghan", 1976)} ,
                {"MT", new PrimeMinister("Margaret Thatcher", 1979)} ,
                {"TB", new PrimeMinister("Tony Blair", 1997)}
            };

            PrimeMinister pm;
            // NOTE: TryGetValue looks up items that might not be present 
            // Doesn't throw exception
            bool found = primeMinisters.TryGetValue("DC", out pm); // NOTE: out parameter
            if (found)
                Console.WriteLine("value is: " + pm.ToString() + "\r\n");
            else
                Console.WriteLine("value was not found in the dictionary");
        }

        private static void EnumeratingDictionaryItems()

        {
            var primeMinisters = new Dictionary<string, PrimeMinister>
            {
                {"JC", new PrimeMinister("James Callaghan", 1976)} ,
                {"MT", new PrimeMinister("Margaret Thatcher", 1979)} ,
                {"TB", new PrimeMinister("Tony Blair", 1997)}
            };

            foreach (var pm in primeMinisters) // NOTE: foreach gives you KeyValuePairs
            {
                Console.WriteLine(pm); // NOTE: Invoked on a dictionary returns [key, value]
            }

            foreach (var pm in primeMinisters.Values)
            {
                Console.WriteLine(pm);
            }

            foreach (var pm in primeMinisters)
            {
                Console.WriteLine(pm.Value); // or pm.Key
            }
        }

        private static void IntroducingDictionary()
        {
            var primeMinisters = new List<PrimeMinister>
            {
                new PrimeMinister("James Callaghan", 1976),
                new PrimeMinister("Margaret Thatcher", 1979),
                new PrimeMinister("Tony Blair", 1997)
            };

            foreach (var pm in primeMinisters)
            {
                // NOTE: We can do that as we overrode ToString(). 
                // Console.WriteLine invokes ToString()
                Console.WriteLine(pm);
            }
        }
    }
}
