using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CourseManagerAndOrganizer
{
    internal static class InputModelToPhysicalMapper
    {
        public static List<PhysicalModuleInfo> GetPhysicalModuleInfos(List<ModuleInfoInput> inputModuleInfos, List<DownloadedClip> downloadedClips)
        {
            var physicalModuleInfos = new List<PhysicalModuleInfo>();

            foreach (var moduleInfoInput in inputModuleInfos)
            {
                var physicalModuleInfo = new PhysicalModuleInfo();
                physicalModuleInfo.ModuleId = moduleInfoInput.ModuleId;
                physicalModuleInfo.ModuleTitle = moduleInfoInput.ModuleTitle;
                physicalModuleInfo.PhysicalClipInfos = GetPhysicalClipInfos(moduleInfoInput, downloadedClips);
                physicalModuleInfo.FolderName = moduleInfoInput.FolderName;

            }

            return physicalModuleInfos;
        }

        private static List<PhysicalClipInfo> GetPhysicalClipInfos(ModuleInfoInput moduleInfoInput, List<DownloadedClip> downloadedClips )
        {
            List<PhysicalClipInfo> physicalClipInfos = new List<PhysicalClipInfo>();
            var minModuleInfoId = moduleInfoInput.ClipInfos.OrderBy(x => x.ClipNumber).First().ClipNumber;
            var howManyClipsInModule = moduleInfoInput.ClipInfos.Count;

            var clipsForModule = downloadedClips.Skip(minModuleInfoId - 1).Take(howManyClipsInModule).ToList();

            MapInputClipsToPhysicalInfos(clipsForModule, physicalClipInfos);
        }

        private static void MapInputClipsToPhysicalInfos(List<DownloadedClip> clipsForModule, List<PhysicalClipInfo> physicalClipInfos)
        {
            if (clipsForModule.Count == 0)
                return;

            if (clipsForModule.Count != moduleInfoInput.ClipInfos.Count)
                throw new InvalidDataException($"Different clip count for module: {moduleInfoInput.ModuleTitle}");
            foreach (var clipForModule in clipsForModule)
            {
                var physicalClip = new PhysicalClipInfo();
                physicalClip.OldFileName = 
            }
        }
    }
}