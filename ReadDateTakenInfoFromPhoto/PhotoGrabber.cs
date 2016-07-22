using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ReadDateTakenInfoFromPhoto
{
    public class PhotoGrabber
    {
        public List<PhotoInfo> GetPhotos(string path)
        {
            var photoInfos = new List<PhotoInfo>();
            var filePathsList = Directory.GetFiles(path);

            if (filePathsList.Length < 1)
                return null;

            foreach (var filePath in filePathsList)
            {
                var fileName = Path.GetFileName(filePath);
                if (fileName != null && fileName.StartsWith("."))
                    continue;
                if(fileName != null && fileName.EndsWith(".MOV"))
                    continue;

                var photoInfo = GetPhotoInfo(filePath);
                photoInfos.Add(photoInfo);
            }

            return photoInfos;
        }

        private PhotoInfo GetPhotoInfo(string filePath)
        {
            var fileInfo = GetFileInfo(filePath);
            
            return new PhotoInfo()
            {
                FileName = Path.GetFileName(filePath),
                CreationTime = fileInfo.CreationTime.ToString(),
                DateTaken = GetDate(fileInfo),
                FilePath = filePath,
                ModificationDate = fileInfo.LastWriteTime.ToString()
            };
        }

       

        private FileInfo GetFileInfo(string imagesPath)
        {
            return new FileInfo(imagesPath);
        }

        private string GetDate(FileInfo f)
        {
            using (FileStream fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                BitmapSource img = BitmapFrame.Create(fs);
                BitmapMetadata md = (BitmapMetadata)img.Metadata;
                string date = md.DateTaken;
                Console.WriteLine(date);
                return date;
            }
        }

       
    }
}
