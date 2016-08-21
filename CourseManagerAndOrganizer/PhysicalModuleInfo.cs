using System.Collections.Generic;

namespace CourseManagerAndOrganizer
{
    internal class PhysicalModuleInfo
    {
        public string FolderName { get; set; }
        public List<PhysicalClipInfo> PhysicalClipInfos { get; set; }
        public int ModuleId { get; set; }
        public string ModuleTitle { get; set; }
    }
}