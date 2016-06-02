using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoFileCreationTimeOriginalFromMetadata;

namespace tesingform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {               
                FileInfo[] a = ofd.FileNames.Select(f => new FileInfo(f)).ToArray() ; // found stack overflow thread advising against using fileinfo array. Not sure why...
                Video v = new Video(a);
            }
        }
    }
}
