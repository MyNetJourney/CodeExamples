using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSELECT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MyClass> AgeList = new List<MyClass>()
            {
                new MyClass() {Age = 10, IWantToBeThisAgeOlder = 1},
                new MyClass() { Age = 20, IWantToBeThisAgeOlder = 2},
                new MyClass() {Age = 30, IWantToBeThisAgeOlder = 3}
            };

            List<int> intList = new List<int>() {10,20,30};


            //Projects each element of the list and multiplies the value by three
            var xx = intList.Select(singleInt => new IntMultiplier(singleInt).
            MultiplyByValue(3));

            foreach (var i in xx)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();

        }


    }

    internal class IntMultiplier
    {
        private int _currentInt;

        public IntMultiplier(int currentInt)
        {
            _currentInt = currentInt;
        }

        public int MultiplyByValue(int i)
        {
            return _currentInt*i;
        }
    }

    public class AgeAdder
    {
        private MyClass _singleAge ;
        public AgeAdder(MyClass singleAge)
        {
            _singleAge = singleAge;
        }

        public double MakeThisPersonOlder(double wantToBeThisAgeOlder)
        {
            return _singleAge.Age += wantToBeThisAgeOlder;
        }
    }

    public class MyClass
    {
        public double Age;
        public double IWantToBeThisAgeOlder { get; set; }
    }
}
