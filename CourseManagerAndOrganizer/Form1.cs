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
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var tocPath = Path.GetDirectoryName(assemblyPath) + "\\toc.txt";
            string[] readText = File.ReadAllLines(tocPath);
            List<string> cleanedLines = CleanDirtyLines(readText);

            var modelMapper = new TextToModelMapper();
            List<ModuleInfo> moduleInfos = modelMapper.MapTextToModel(cleanedLines);

            string[] myArr = new[] {"myText (4).mp4", "myText (1).mp4", "myText.mp4"};


            var ordered = myArr.OrderBy(x => x).ToList();

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
