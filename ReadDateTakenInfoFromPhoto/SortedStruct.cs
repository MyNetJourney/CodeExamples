using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadDateTakenInfoFromPhoto
{
    public class SortedFolder
    {
        public int id { get; set; }
        public string idPadded => id.ToString().PadLeft(3, '0');
        public string folderPath { get; set; }
        public string newFolderPath => $"{idPadded}. {Path.GetFileName(folderPath)}";
        public string dateTaken { get; set; }
        public string comparableDate { get; set; }
    }
}
