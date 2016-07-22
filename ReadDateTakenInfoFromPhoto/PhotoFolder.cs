using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadDateTakenInfoFromPhoto
{
    public class PhotoFolder
    {
        public string Path { get; set; }
        public List<PhotoInfo> Photos {get; set;}
    }
}
