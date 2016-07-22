using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadDateTakenInfoFromPhoto
{
    public class PhotoStructureListBuilder
    {
        public List<PhotoFolder> BuildStructure( string currentFolderPath)
        {
            var allDirectories = new List<string>();
            dirSearch(currentFolderPath, allDirectories);

            var photoFolders = new List<PhotoFolder>();
            foreach (var dir in allDirectories)
            {
                var photoGrabber = new PhotoGrabber();
                var photoFolder = new PhotoFolder
                {
                    Path = dir,
                    Photos = photoGrabber.GetPhotos(dir)
                };
                if (photoFolder.Photos != null)
                    photoFolders.Add(photoFolder);
            }
            return photoFolders;
        }

        private void dirSearch(string sDir, List<string> allDirectories)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    allDirectories.Add(d);
                    dirSearch(d, allDirectories);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
}
