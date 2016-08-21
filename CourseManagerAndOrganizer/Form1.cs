using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace CourseManagerAndOrganizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OrganizeButton_Click(object sender, EventArgs e)
        {
            // Create model based on text file with toc
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var tocPath = Path.GetDirectoryName(assemblyPath) + "\\toc.txt";
            string[] readText = File.ReadAllLines(tocPath);
            List<string> cleanedLines = CleanDirtyLines(readText);

            // Get physical files model from download folder
            var coursePath = @"D:\Pluarldown\";
            List<DownloadedClip> downloadedClips = fileManager.GetDownloadedClips(coursePath);

            var modelMapper = new TextToModelMapper();
            List<ModuleInfoInput> moduleInfos = modelMapper.MapTextToModel(cleanedLines);

            List<PhysicalModuleInfo> physicalModuleInfos = InputModelToPhysicalMapper.GetPhysicalModuleInfos(
                moduleInfos, downloadedClips);


            //ValidateDurationTime(physicalModuleInfos moduleInfos);


            // Organize downloaded files into folders
            fileManager.RenameFiles(downloadedClips, moduleInfos);
            fileManager.MoveFilesToFolders(downloadedClips, moduleInfos, coursePath);

           

            // TODO:
            // Add time validation (each module has right duration)
        }

        private void ValidateDurationTime(List<DownloadedClip> downloadedClips,  List<ModuleInfoInput> moduleInfos)
        {
            foreach (var moduleInfo in moduleInfos)
            {
                foreach (var downloadedClip in downloadedClips.Where(x=>x.ModuleFolderName == moduleInfo.FolderName))
                {
                    
                }
            }

            foreach (var downloadedClip in downloadedClips)
            {
                WindowsMediaPlayer wmp = new WindowsMediaPlayerClass();
                IWMPMedia mediainfo = wmp.newMedia(downloadedClip.FilePathBeforeRenaming);
                var xx = mediainfo.duration;
            }
        }

        private List<string> CleanDirtyLines(string[] readText)
        {
            var cleanedText = new List<string>();
            foreach (var line in readText)
            {
                var firstSpaceOccurenceIndex = line.IndexOf(" ", StringComparison.Ordinal);
                var newLine = line.Substring(firstSpaceOccurenceIndex+1, line.Length - (firstSpaceOccurenceIndex+1));
                cleanedText.Add(newLine);
            }

            return cleanedText;
        }
    }
}
