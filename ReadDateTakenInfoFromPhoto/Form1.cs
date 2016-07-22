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

            //var query = (from p in photoStruct
            //    from q in p.Photos
            //    where q.ComparableDate == null
            //    select q).ToList();




        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            _currentFolderPath = fbd.SelectedPath;
            


        }

        
    }
}
