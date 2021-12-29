using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFBasic.BLL;
using EFBasic.DALL;


namespace EFBasic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var ls = LopHocBLL.GetList();
            // dataGridView1.DataSource = ls;
            comboBox1.DataSource = ls;
            comboBox1.DisplayMember = "Name";

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lopHoc = comboBox1.SelectedItem as LopHoc;
            if (lopHoc != null)
            {
                var maLop = lopHoc.ID;
                var ls = SinhVienBLL.GetList(maLop);

                sinhVienBindingSource.DataSource = ls;
                dataGridView1.DataSource = sinhVienBindingSource;
                //đếm trong DB
                var total = SinhVienBLL.Count(maLop);
                lblTongSoSV.Text = $"{total} sinh viên";
                //lblTongSoSV.Text= $"{ls.Count} sinh viên"; lấy dl ra r mới đếm
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            var f = new FmSinhVienChiTiet();
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                var lopHoc = comboBox1.SelectedItem as LopHoc;
                if (lopHoc != null)
                {
                    var maLop = lopHoc.ID;
                    var ls = SinhVienBLL.GetList(maLop);

                    sinhVienBindingSource.DataSource = ls;
                    dataGridView1.DataSource = sinhVienBindingSource;

                    var total = SinhVienBLL.Count(maLop);
                    lblTongSoSV.Text = $"{total} sinh viên";
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var sinhVien = sinhVienBindingSource.Current as SinhVien;
            if (sinhVien != null)
            {
                var f = new FmSinhVienChiTiet(sinhVien);
                var rs = f.ShowDialog();
                var lopHoc = comboBox1.SelectedItem as LopHoc;
                if (rs == DialogResult.OK)
                {
                    var maLop = lopHoc.ID;
                    var ls = SinhVienBLL.GetList(maLop);

                    sinhVienBindingSource.DataSource = ls;
                    dataGridView1.DataSource = sinhVienBindingSource;

                    var total = SinhVienBLL.Count(maLop);
                    lblTongSoSV.Text = $"{total} sinh viên";
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var sinhVien = sinhVienBindingSource.Current as SinhVien;
            if (sinhVien != null)
            {
                var rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    SinhVienBLL.Delete(sinhVien.IDStudent);
                    sinhVienBindingSource.RemoveCurrent();
                    MessageBox.Show("Đã xóa thành công", "Thông báo");

                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
