using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ReadDateTakenInfoFromPhoto
{
    public partial class Form1 : Form
    {
        private string _currentFolderPath;

        public Form1()
        {
            InitializeComponent();
        }

        private void GetDateTakenButton_Click(object sender, EventArgs e)
        {
            _currentFolderPath = @"D:\Temp pics";
            if (string.IsNullOrWhiteSpace(_currentFolderPath))
                return;
            var structureBuilder = new PhotoStructureListBuilder();
            var photoStruct = structureBuilder.BuildStructure(_currentFolderPath);
            
            var query2 = (from p in photoStruct
                          where p.Photos.Count > 0
                select new
                {
                    folderPath = p.Path,
                    earliestDateTaken = p.Photos.OrderBy(x=>x.ComparableDate).First().DateTaken,
                    comparableDate = p.Photos.OrderBy(x=>x.ComparableDate).First().ComparableDate
                }).OrderBy(x=>x.comparableDate).ToList();

            var sortedFolders = new List<SortedFolder>();
            for (int i=0; i<query2.Count; i++)
            {
                var sortFold = new SortedFolder()
                {
                    id = i+1,
                    comparableDate = query2[i].comparableDate,
                    dateTaken = query2[i].earliestDateTaken,
                    folderPath = query2[i].folderPath
                };
                
                sortedFolders.Add(sortFold);
            }

            // rename attempt
            foreach (var sortedFolder in sortedFolders)
            {
                string basePath = "";
                string newPath = "";

                Directory.Move(basePath,newPath);
            }

            //from q in p.Photos
            //where q.ComparableDate != null
            //orderby q.ComparableDate ascending
            //select new
            //{
            //    fileName = q.FileName,
            //    folder = Path.GetDirectoryName(q.FilePath),
            //    dateTaken = q.DateTaken
            //};

            



        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            _currentFolderPath = fbd.SelectedPath;
        }

        
    }
}
