using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagerAndOrganizer
{
    internal class ModuleInfoInput
    {
        public int ModuleId { get; set; }
        public string ModuleTitle { get; set; }
        public List<ClipInfoInput> ClipInfos { get; set; }

        public string FolderName
            => ModuleId.ToString().PadLeft(2, '0') + ". " + ModuleTitle.Replace("------", "").Trim();
    }
}
