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
            try
            {
                var result = await LoginAsync();
                button1.Text = result;
            }
            catch (Exception ex)
            {
                button1.Text = "Login Failed!";
            }
        }

        private async Task<string> LoginAsync()
        {
           
            try
            {
                var result = await Task.Run(() =>
                {
                    // throw new UnauthorizedAccessException();
                    Thread.Sleep(2000);
                    return "Login Succesful!";
                });

                return result;
            }
            catch (Exception ex)
            {
                return "Login Failed!";
            }
           
        }

        


    }
}
