using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadDateTakenInfoFromPhoto
{
    public class PhotoInfo
    {
        public string FileName { get; set; }
        public string DateTaken { get; set; }
        public string CreationTime { get; set; }
        public string ModificationDate { get; set; }
        public string FilePath { get; set; }

        public string ComparableDate
        {
            get { return DateTaken ?? ModificationDate; }
        }
    }
}
