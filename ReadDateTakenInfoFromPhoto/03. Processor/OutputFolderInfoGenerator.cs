using System.Collections.Generic;
using System.Linq;
using ReadDateTakenInfoFromPhoto._01._BaseModel;
using ReadDateTakenInfoFromPhoto._04._OutputModel;

namespace ReadDateTakenInfoFromPhoto._03._Processor
{
    internal class OutputFolderInfoGenerator
    {
        private  List<PhotoFolder> _inputStructure;
        private  ISortingAlgorithm _sortingAlgorithm;
        public OutputFolderInfoGenerator(List<PhotoFolder> inputStructure, ISortingAlgorithm sortingAlgorithm)
        {
            _inputStructure = inputStructure;
            _sortingAlgorithm = sortingAlgorithm;

        }
        
        public List<OutputPhotoFolderInfo> GenerateOutputModel()
        {
            var sortedStruct = _sortingAlgorithm.SortStructure(_inputStructure);
            return BuildStructure(sortedStruct);
        }

        private List<OutputPhotoFolderInfo> BuildStructure(List<PhotoFolder> sortedStruct)
        {
            var sortedFolders = new List<OutputPhotoFolderInfo>();
            for (int i = 0; i < sortedStruct.Count(); i++)
            {
                var sortFold = new OutputPhotoFolderInfo()
                {
                    Id = i + 1,
                    ComparableDate = sortedStruct[i].Photos.OrderBy(x=>x.ComparableDate).First().ComparableDate,
                    EarliestDateTaken = sortedStruct[i].Photos.OrderBy(x => x.ComparableDate).First().DateTaken,
                    EarliestPhotoPath = sortedStruct[i].Photos.OrderBy(x => x.ComparableDate).First().FilePath,
                    FolderPath = sortedStruct[i].Path};

                sortedFolders.Add(sortFold);
            }
            return sortedFolders;
        }
    }
}