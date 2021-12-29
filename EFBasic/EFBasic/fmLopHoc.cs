using EFBasic.BLL;
using EFBasic.ViewModel;
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
    public partial class fmLopHoc : Form
    {
        public fmLopHoc()
        {
            InitializeComponent();
            NapLopHoc();
        }

        void NapLopHoc()
        {
            var ls = LopHocBLL.GetListViewModel();
            lopHocViewModelBindingSource.DataSource = ls;
            dataGridView1.DataSource = lopHocViewModelBindingSource;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var lopHoc = lopHocViewModelBindingSource.Current as LopHocViewModel;
            if (lopHoc != null)
            {
                var rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    if (LopHocBLL.Delete(lopHoc.ID))
                    {
                        lopHocViewModelBindingSource.RemoveCurrent();
                        MessageBox.Show("Đã xóa thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Đã xóa không thành công", "Thông báo");
                    }

                }
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            var f = new FmLopChiTiet();
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                NapLopHoc();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var lopHoc = lopHocViewModelBindingSource.Current as LopHocViewModel;
            if (lopHoc != null)
            {
                var f = new FmLopChiTiet(lopHoc);
                var rs = f.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    NapLopHoc();
                }

            }
        }
    }
}