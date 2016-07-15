using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace ReadDateTakenInfoFromPhoto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetDateTakenButton_Click(object sender, EventArgs e)
        {
            List<string> imagesPaths = new List<string>()
            {
                @"D:\DSC_2883.JPG"
            }; // Here you get the image path

            var fileInfoList = new List<FileInfo>();
            foreach (var imagePath in imagesPaths)
            {
                fileInfoList.Add(GetFileInfo(imagePath));
            }

           var dateTakenList = new List<string>();
            foreach (var fileInfo in fileInfoList)
            {
                dateTakenList.Add(GetDate(fileInfo));
            }



        }

        private FileInfo GetFileInfo(string imagesPath)
        {
            return new FileInfo(imagesPath);
        }

        static string GetDate(FileInfo f)
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
