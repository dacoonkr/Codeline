using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Codeline
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog createDialog = new SaveFileDialog();

            createDialog.Filter = "LineCount files (*.lncnt)|*.lncnt|All files (*.*)|*.*";
            createDialog.FileName = "linecount";
            createDialog.RestoreDirectory = true;

            if (createDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = createDialog.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }
    }
}