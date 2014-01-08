using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;

namespace K12Code.Management.Module
{
    public partial class NotepadForm : BaseForm
    {
        public NotepadForm(string log)
        {
            InitializeComponent();

            textBoxX1.Text = log;
            textBoxX1.SelectAll();
        }

        private void NotepadForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxX1.Text);
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX2_MouseMove(object sender, MouseEventArgs e)
        {
            labelX1.Visible = true;
        }

        private void buttonX2_MouseLeave(object sender, EventArgs e)
        {
            labelX1.Visible = false;
        }
    }
}
