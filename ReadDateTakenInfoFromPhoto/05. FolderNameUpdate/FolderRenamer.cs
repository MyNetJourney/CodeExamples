using System;
using System.Collections.Generic;
using System.IO;
using ReadDateTakenInfoFromPhoto._04._OutputModel;

namespace ReadDateTakenInfoFromPhoto
{
    internal class FolderRenamer
    {
        private List<OutputPhotoFolderInfo> _outputFolderStruct ;

        public FolderRenamer(List<OutputPhotoFolderInfo> outputFolderStruct )
        {
            _outputFolderStruct = outputFolderStruct;
        }

        public void Rename()
        {
            // rename attempt
            foreach (var sortedFolder in _outputFolderStruct)
            {
                string basePath = sortedFolder.FolderPath;
                string newPath = CreateNewPath(sortedFolder);

                Directory.Move(basePath, newPath);
            }
        }

        private string CreateNewPath(OutputPhotoFolderInfo sortedFolder)
        {
            string parentPath = Path.GetDirectoryName(sortedFolder.FolderPath);
            string oldfolderName = new DirectoryInfo(sortedFolder.FolderPath).Name;
            string prefix = sortedFolder.Id.ToString().PadLeft(3, '0');
            string newFolderName = prefix + ". " +oldfolderName;
            string newFolderPath = @parentPath +"\\" + newFolderName;

            return newFolderPath;
        }
    }
}