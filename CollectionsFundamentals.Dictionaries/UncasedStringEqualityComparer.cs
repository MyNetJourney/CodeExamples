using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsFundamentals.Dictionaries
{
    internal class UncasedStringEqualityComparer: IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.ToUpper() == y.ToUpper();
        }
        // IMPORTANT: The only purpose of having every object implement GetHashCode is to allow objects being used as dictionary keys!
        public int GetHashCode(string obj)
        {
            // return obj.GetHashCode();
            // IMPORTANT: above line doesn't work because "tb".GetHashCode is different than "TB".GetHashCode
            // Chances are tb and TB are in different "Buckets". We are asking for tb

            return obj.ToUpper().GetHashCode();
        }
    }
}
