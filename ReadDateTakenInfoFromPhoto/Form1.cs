using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ReadDateTakenInfoFromPhoto._01._BaseModel;
using ReadDateTakenInfoFromPhoto._02._StructGetter;
using ReadDateTakenInfoFromPhoto._03._Processor;
using ReadDateTakenInfoFromPhoto._04._OutputModel;

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
            if (string.IsNullOrWhiteSpace(_currentFolderPath))
                return;

            // gather information about photos from folder
            var structureBuilder = new PhotoStructureListBuilder();
            var inputPhotoStruct = structureBuilder.BuildStructure(_currentFolderPath);

            // generate output model. List of folder objects with specified properties
            var outputFolderInfoGenerator = new OutputFolderInfoGenerator(inputPhotoStruct, new SortByEarliestPhotoInFolder());
            var outputFolderInfoStruct = outputFolderInfoGenerator.GenerateOutputModel();

            // rename folders according to specified algorithm
            var folderRenamer = new FolderRenamer(outputFolderInfoStruct);
            folderRenamer.Rename();
        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            _currentFolderPath = fbd.SelectedPath;
            currentPhotoPathTextBox.Text = _currentFolderPath;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _currentFolderPath = String.Empty;
            currentPhotoPathTextBox.Text = String.Empty;
        }
    }
}
