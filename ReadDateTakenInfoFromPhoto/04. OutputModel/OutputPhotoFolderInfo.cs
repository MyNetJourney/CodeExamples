using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadDateTakenInfoFromPhoto._04._OutputModel
{
    class OutputPhotoFolderInfo
    {
        public int Id { get;  set; }
        public string ComparableDate { get; set; }
        public string EarliestDateTaken { get; set; }
        public string EarliestPhotoPath { get; set; }
        public string FolderPath { get; set; }
    }
}
