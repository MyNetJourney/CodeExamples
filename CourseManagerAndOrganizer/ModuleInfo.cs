using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagerAndOrganizer
{
    internal class ModuleInfo
    {
        public int ModuleId { get; set; }
        public string ModuleTitle { get; set; }
        public List<ClipInfo> ClipInfos { get; set; } 
    }
}
