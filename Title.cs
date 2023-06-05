using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Woooordle
{
    public partial class Title : Form
    {

        private const string creditText = "C# Programming Class [003]\n\n" +
            "Created By: 21011799 Kim Jihun\n" +
            "Originated From New York Times";

        public Title()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void startNormalBtn_Click(object sender, EventArgs e)
        {
            var frm = new NormalGame
            {
                Location = this.Location,
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private void startCustomBtn_Click(object sender, EventArgs e)
        {
            var frm = new CustomGame
            {
                Location = this.Location,
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private void openFinderBtn_Click(object sender, EventArgs e)
        {
            var frm = new Finder
            {
                Location = this.Location,
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };
            frm.FormClosing += delegate
            {
                this.Enabled = true;
                this.Focus();
            };
            this.Enabled = false;
            frm.Show();
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(creditText, "App Info");
        }
    }
}
