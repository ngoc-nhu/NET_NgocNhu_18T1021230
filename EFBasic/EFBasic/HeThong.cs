using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFBasic
{
    public partial class HeThong : Form
    {
        public HeThong()
        {
            InitializeComponent();
        }

       

       

        private void HeThong_Load(object sender, EventArgs e)
        {
           
        }
        private void AddForm(Form f)
        {
            this.pnlContent.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.pnlContent.Controls.Add(f);
            f.Show();
        }

        private void qlsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            AddForm(f1);
        }

        private void qllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmLopHoc lh = new fmLopHoc();
            AddForm(lh);
        }
    }
}
