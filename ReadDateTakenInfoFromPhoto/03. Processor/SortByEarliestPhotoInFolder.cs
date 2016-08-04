using System.Collections.Generic;
using System.Linq;
using ReadDateTakenInfoFromPhoto._01._BaseModel;

namespace ReadDateTakenInfoFromPhoto._03._Processor
{
    internal class SortByEarliestPhotoInFolder : ISortingAlgorithm
    {
        public List<PhotoFolder> SortStructure(List<PhotoFolder> inputStructure)
        {
            // TODO: check if new version is working
            //var query2 = (from p in _inputStructure
            //              where p.Photos.Count > 0
            //              select new
            //              {
            //                  folderPath = p.Path,
            //                  earliestDateTaken = p.Photos.OrderBy(x => x.ComparableDate).First().DateTaken,
            //                  comparableDate = p.Photos.OrderBy(x => x.ComparableDate).First().ComparableDate
            //              }).OrderBy(x => x.comparableDate).ToList();

            return inputStructure.
                OrderBy(x => x.Photos.
                OrderBy(y => y.ComparableDate).
                First().DateTaken).ToList();
        } 
    }
}