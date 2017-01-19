using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Latex4CorelDraw
{
    public partial class OptionsDialog : Form
    {
        public string MiktexPath
        {
            get { return textBoxMiktex.Text; }
            set { textBoxMiktex.Text = value; }
        }

//         public string GSPath
//         {
//             get { return textBoxGS.Text; }
//             set { textBoxGS.Text = value; }
//         }

        public OptionsDialog()
        {
            InitializeComponent();
        }

        private void buttonMiktex_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = textBoxMiktex.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxMiktex.Text = dialog.SelectedPath;
            }
        } 
    }
}
