using System;

namespace CourseManagerAndOrganizer
{
    public class DownloadedClip
    {
        public string OldFileName { get; set; }
        public DateTime CreationTime { get; set; }
        public string NewFileName { get; set; }
        public string ModuleFolderName { get; set; }
        public string FilePathBeforeRenaming { get; set; }
        public string FilePathAfterRenaming { get; set; }
    }
}