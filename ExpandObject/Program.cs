using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExpandObject
{
    class Program
    {
        // https://www.oreilly.com/learning/building-c-objects-dynamically
        // This example shows how to add properties to object dynamically

        static void Main(string[] args)
        {
            dynamic expando = new ExpandoObject();

            expando.Name = "Krzysztof";
            expando.Country = "Poland";

            // At this point there are only two properties of expando object

            AddProperty(expando, "Language", "Polish"); // Language added

            Console.WriteLine($"My name is {expando.Name} and my language is {expando.Language}");
        }

        static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }
    }
}
