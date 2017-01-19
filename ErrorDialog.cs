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
    public partial class ErrorDialog : Form
    {
        public string ErrorLabel
        {
            get { return labelError.Text; }
            set { labelError.Text = value; }
        }

        public string ErrorText
        {
            get { return textBoxError.Text; }
            set { textBoxError.Text = value; }
        }

        public ErrorDialog(string labelText, string error)
        {
            InitializeComponent();

            labelError.Text = labelText;
            textBoxError.Text = error.Replace("\n", "\r\n");
            textBoxError.Select(0, 0);
        }
    }
}
