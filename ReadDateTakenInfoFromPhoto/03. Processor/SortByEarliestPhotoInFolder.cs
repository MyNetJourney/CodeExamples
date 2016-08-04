using System.Collections.Generic;
using System.Linq;
using ReadDateTakenInfoFromPhoto._01._BaseModel;

namespace ReadDateTakenInfoFromPhoto._03._Processor
{
    internal class SortByEarliestPhotoInFolder : ISortingAlgorithm
    {
        public List<PhotoFolder> SortStructure(List<PhotoFolder> inputStructure)
        {
            return inputStructure.
                Where(x=>x.Photos.Count>0).
                OrderBy(x => x.Photos.
                OrderBy(y => y.ComparableDate).
                First().ComparableDate).ToList();
        } 
    }
}