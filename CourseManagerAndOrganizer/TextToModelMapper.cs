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

        public List<ModuleInfoInput> MapTextToModel(List<string> cleanedLines)
        {
            return GetModuleList(cleanedLines);
        }

        private List<ModuleInfoInput> GetModuleList(List<string> cleanedLines)
        {
            List<ModuleInfoInput> moduleInfos = new List<ModuleInfoInput>();
            ModuleInfoInput moduleInfoInput;
            List<ClipInfoInput> clipInfos = new List<ClipInfoInput>();

            int lineIndex = 0;
            int moduleIndex = 1;
            int clipIndexInModule = 1;
            foreach (var cleanedLine in cleanedLines)
            {
                if (cleanedLine.StartsWith("------"))
                {
                    clipIndexInModule = 1;
                    moduleInfos.Add(new ModuleInfoInput() {
                        ClipInfos = new List<ClipInfoInput>(),
                        ModuleId = moduleIndex,
                        ModuleTitle = cleanedLine});
                    moduleIndex++;
                    continue;
                }

                if(cleanedLine.Trim().Length < 1)
                    continue;
                
                moduleInfos[moduleIndex-2].ClipInfos.Add(new ClipInfoInput()
                {
                    ClipTitle = cleanedLine,
                    ClipIdInModule = clipIndexInModule,
                    ClipNumber = int.Parse(cleanedLine.Substring(0, cleanedLine.IndexOf(" ", StringComparison.Ordinal)))
                });

                lineIndex++;
                clipIndexInModule++;
            }
            return moduleInfos;
        }
    }
}