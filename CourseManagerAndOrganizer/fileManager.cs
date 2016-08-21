using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace CourseManagerAndOrganizer
{
    internal class fileManager
    {
        public static List<DownloadedClip> GetDownloadedClips(string coursePath)
        {
            var filePathsList = Directory.GetFiles(coursePath, "*.mp4");
            var downloadedClips = new List<DownloadedClip>();

            foreach (var filePath in filePathsList)
            {
                var downloadedClip = new DownloadedClip
                {
                    FilePathBeforeRenaming = filePath,
                    CreationTime = File.GetCreationTime(filePath),
                    OldFileName = Path.GetFileName(filePath)
                };
                downloadedClips.Add(downloadedClip);
            }
            
            return downloadedClips.OrderBy(x=>x.CreationTime).ToList();
        }

        public static void RenameFiles(List<DownloadedClip> downloadedClips, List<ModuleInfoInput> moduleInfos)
        {
            foreach (var moduleInfo in moduleInfos)
            {
                var moduleClips = GetModuleClips(moduleInfo, downloadedClips);
                AddNewNamesToEachClip(moduleClips, moduleInfo);
                //PerformRenaming(moduleClips, moduleInfo);

            }
        }

        public static void MoveFilesToFolders(List<DownloadedClip> downloadedClips, List<ModuleInfoInput> moduleInfos, string coursePath  )
        {
            CreateFolders(moduleInfos, coursePath);
            MoveClipsToFolders(downloadedClips);


        }

        private static void MoveClipsToFolders(List<DownloadedClip> downloadedClips)
        {
            foreach (var downloadedClip in downloadedClips)
            {
                string pathToMove = Path.GetDirectoryName(downloadedClip.FilePathAfterRenaming) + "\\" +
                                    downloadedClip.ModuleFolderName + "\\" +downloadedClip.NewFileName;

                //File.Move(downloadedClip.FilePathAfterRenaming, pathToMove);
                
                
            }
        }

        private static void CreateFolders(List<ModuleInfoInput> moduleInfos, string coursePath)
        {
            foreach (var moduleInfo in moduleInfos)
            {
                Directory.CreateDirectory(coursePath + moduleInfo.FolderName);
            }
           
        }

        private static void PerformRenaming(List<DownloadedClip> moduleClips, ModuleInfoInput moduleInfoInput)
        {
            foreach (var downloadedClip in moduleClips)
            {
                var oldPath = downloadedClip.FilePathBeforeRenaming;
                var newPath = Path.GetDirectoryName(downloadedClip.FilePathBeforeRenaming) + "\\" + downloadedClip.NewFileName;
                downloadedClip.FilePathAfterRenaming = newPath;
                File.Move(oldPath, newPath);
            }
        }

        private static void AddNewNamesToEachClip(List<DownloadedClip> moduleClips, ModuleInfoInput moduleInfoInput )
        {
            if(moduleClips.Count == 0)
                return;

            if(moduleClips.Count != moduleInfoInput.ClipInfos.Count)
                throw new InvalidDataException($"Different clip count for module: {moduleInfoInput.ModuleTitle}");

            for (int i = 0; i < moduleClips.Count; i++)
            {
                var currentClipCorrectNewName = GetValidFileName(moduleInfoInput.ClipInfos[i].ClipTitle);
                moduleClips[i].NewFileName = currentClipCorrectNewName + ".mp4";
                moduleClips[i].ModuleFolderName = moduleInfoInput.FolderName;
            }

        }

        private static string GetValidFileName(string clipTitle)
        {
            clipTitle.Replace("<", "[");
            clipTitle.Replace(">", "]");
            clipTitle.Replace("?", "");
            clipTitle.Replace("!", "");
            clipTitle.Replace(":", "-");

            return clipTitle;
        }

        private static List<DownloadedClip> GetModuleClips(ModuleInfoInput moduleInfoInput, List<DownloadedClip > downloadedClips )
        {
            var minModuleInfoId = moduleInfoInput.ClipInfos.OrderBy(x => x.ClipNumber).First().ClipNumber;
            var howManyClipsInModule = moduleInfoInput.ClipInfos.Count;
            return downloadedClips.Skip(minModuleInfoId - 1).Take(howManyClipsInModule).ToList();
        }
    }
}