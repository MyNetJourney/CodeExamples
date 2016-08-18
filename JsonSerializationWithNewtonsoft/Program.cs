using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonSerializationWithNewtonsoft
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new 
            {
                Date = DateTime.UtcNow,
                Trips = new List<Trip>()
                {
                    new Trip()
                    {
                        TripName = "Trip around the world",
                        TripStart = DateTime.UtcNow,
                        TripEnd = DateTime.UtcNow.AddDays(14),
                        PeopleWhoGo = new Person[]
                        {
                            new Person() {Age = 21, Name = "John Marx", City = "San Francisco"},
                            new Person() {Age = 32, Name = "Clara Morgan", City = "Boston"}
                        }
                    },
                    new Trip()
                    {
                        TripName = "Trip to the moon",
                        TripStart = DateTime.UtcNow.AddDays(21),
                        TripEnd = DateTime.UtcNow.AddDays(36),
                        PeopleWhoGo = new Person[]
                        {
                            new Person() {Age = 61, Name = "Brad Kovalsky", City = "New York"},
                            new Person() {Age = 31, Name = "Megan Kosowski", City = "Warsaw"},
                            new Person() {Age = 25, Name = "Pavel Lisek", City = "Prague"}
                        }
                    }
                }
            };

            var serialized = JsonConvert.SerializeObject(log, Formatting.Indented);
            var deserialized = JsonConvert.DeserializeObject<dynamic>(serialized.ToString());

            var firstTripName = deserialized["Trips"][0]["TripName"];

        }
    }


    public class TripLog
    {
        public DateTime Date { get; set; }
        public List<Trip> Trips { get; set; }
    }

    public class Trip
    {
        public string TripName { get; set; }
        public DateTime TripStart { get; set; }
        public DateTime TripEnd { get; set; }
        public Person[] PeopleWhoGo { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}
