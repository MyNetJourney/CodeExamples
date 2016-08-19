using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseManagerAndOrganizer
{
    internal class TextToModelMapper
    {
        public TextToModelMapper()
        {
        }

        public List<ModuleInfo> MapTextToModel(List<string> cleanedLines)
        {
            var moduleList = new List<ModuleInfo>();
            moduleList = GetModuleList(cleanedLines);
            return moduleList;
        }

        private List<ModuleInfo> GetModuleList(List<string> cleanedLines)
        {
            List<ModuleInfo> moduleInfos = new List<ModuleInfo>();
            ModuleInfo moduleInfo;
            List<ClipInfo> clipInfos = new List<ClipInfo>();

            int lineIndex = 0;
            int moduleIndex = 1;
            int clipIndexInModule = 1;
            foreach (var cleanedLine in cleanedLines)
            {
                if (cleanedLine.StartsWith("------"))
                {
                    clipIndexInModule = 1;
                    moduleInfos.Add(new ModuleInfo() {
                        ClipInfos = new List<ClipInfo>(),
                        ModuleId = moduleIndex,
                        ModuleTitle = cleanedLine});
                    moduleIndex++;
                    continue;
                }

                if(cleanedLine.Trim().Length < 1)
                    continue;

                moduleInfos[moduleIndex-2].ClipInfos.Add(new ClipInfo()
                {
                    ClipTitle = cleanedLine,
                    ClipIdInModule = clipIndexInModule,
                    ClipNumber = cleanedLine.Substring(0, cleanedLine.IndexOf(" ", StringComparison.Ordinal))
                });

                lineIndex++;
                clipIndexInModule++;
            }
            return moduleInfos;
        }
    }
}