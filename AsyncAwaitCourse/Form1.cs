using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitCourse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            LoginAsync();
        }

        private async void LoginAsync()
        {
            var result = await Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Login Succesfull";
            });

            button1.Text = result;
        }

        


    }
}
