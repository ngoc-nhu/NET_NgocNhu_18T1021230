using EFBasic.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFBasic.DALL;
namespace EFBasic
{
    public partial class FmSinhVienChiTiet : Form
    {
        SinhVien sinhVien;
        public FmSinhVienChiTiet(SinhVien sinhVien = null)
        {
            InitializeComponent();
            var ls = LopHocBLL.GetList();
            comboBox1.DataSource = ls;
            comboBox1.DisplayMember = "Name";

            this.sinhVien = sinhVien;
            if (sinhVien == null)
            {
                this.Text = "Thêm mới sinh viên";

            }
            else
            {
                this.Text = "Cập nhật dữ liệu cho sinh viên";
                txtMaSV.Text = sinhVien.IDStudent;
                txtHo.Text = sinhVien.LastName;
                txtTen.Text = sinhVien.FirstName;
                dtpNgaySinh.Value = (DateTime)sinhVien.DOB;
                txtNoiSinh.Text = sinhVien.POB;
                //comboBox1.SelectedIndex = (int) sinhVien.IDLopHoc;
                //comboBox1.SelectedItem = sinhVien.LopHoc.Name;

            }

        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var maSV = txtMaSV.Text;
            if (string.IsNullOrEmpty(maSV))
            {
                //MessageBox.Show("Vui long nhạp ten lop")
                errorProvider1.SetError(txtMaSV, "Vui lòng nhập mã sinh viên");
                //errorProvider1.SetError(txtHo, "Vui lòng nhập họ sinh viên");
                //errorProvider1.SetError(txtTen, "Vui lòng nhập tên sinh viên");
                // errorProvider1.SetError(txtNoiSinh, "Vui lòng nhập nơi sinh");
                return;
            }
            var ho = txtHo.Text;
            if (string.IsNullOrEmpty(ho))
            {
                errorProvider1.SetError(txtHo, "Vui lòng nhập họ sinh viên");
                return;
            }
            var ten = txtTen.Text;
            if (string.IsNullOrEmpty(ten))
            {
                errorProvider1.SetError(txtTen, "Vui lòng nhập tên sinh viên");
                return;
            }
            var ngaySinh = dtpNgaySinh.Value;
            var noiSinh = txtNoiSinh.Text;
            if (string.IsNullOrEmpty(noiSinh))
            {
                errorProvider1.SetError(txtNoiSinh, "Vui lòng nhập nơi sinh");
                return;
            }


            var lopHoc = comboBox1.SelectedItem as LopHoc;

            QLSinhVienModel model = new QLSinhVienModel();
            if (sinhVien == null)
            {
                //thêm mới
                var sv = model.SinhViens.Where(s => s.IDStudent == maSV).FirstOrDefault();
                if (sv != null)
                {
                    MessageBox.Show("Mã sinh viên trùng. Vui lòng nhập mã khác", "Chú ý");
                    return;
                }
                else
                {
                    sv = new SinhVien
                    {
                        IDStudent = maSV,
                        FirstName = ten,
                        LastName = ho,
                        DOB = ngaySinh,
                        POB = noiSinh,
                        IDLopHoc = lopHoc.ID,

                    };
                    model.SinhViens.Add(sv);
                    model.SaveChanges();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                // cập nhật
                var lh = model.SinhViens.Where(s => s.ID != sinhVien.ID && s.IDStudent == maSV).FirstOrDefault();
                if (lh != null)
                {
                    MessageBox.Show("Mã sinh viên trùng. Vui lòng nhập mã sinh viên khác", "Chú ý");
                    return;
                }
                else
                {
                    lh = model.SinhViens.Where(s => s.ID == sinhVien.ID).FirstOrDefault();
                    lh.IDStudent = maSV;
                    lh.FirstName = ten;
                    lh.LastName = ho;
                    lh.DOB = ngaySinh;
                    lh.POB = noiSinh;
                    lh.IDLopHoc = lopHoc.ID;
                    model.SaveChanges();
                    DialogResult = DialogResult.OK;
                }
            }

        }
    }
}