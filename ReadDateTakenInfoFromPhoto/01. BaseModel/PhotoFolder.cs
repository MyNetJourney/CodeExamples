using System.Collections.Generic;

namespace ReadDateTakenInfoFromPhoto._01._BaseModel
{
    public class PhotoFolder
    {
        public string Path { get; set; }
        public List<PhotoInfo> Photos {get; set;}
    }
}
