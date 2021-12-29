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
using EFBasic.ViewModel;

namespace EFBasic
{
    
    public partial class FmLopChiTiet : Form
    {
        LopHocViewModel lopHoc;
        public FmLopChiTiet(LopHocViewModel lopHoc = null)
        {
            InitializeComponent();
            this.lopHoc = lopHoc;
            if (lopHoc == null)
            {
                this.Text = "Thêm mới lớp học";
            }
            else
            {
                this.Text = "Cập nhật dữ liệu cho lớp học";
                txtTenLop.Text = lopHoc.Name;
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var tenLop = txtTenLop.Text;
            if (string.IsNullOrEmpty(tenLop))
            {
                //MessageBox.Show("Vui long nhạp ten lop")
                errorProvider1.SetError(txtTenLop, "Vui lòng nhập tên lớp");
                return;
            }
            QLSinhVienModel model = new QLSinhVienModel();
            if (lopHoc == null)
            {
                //them mới

                var lh = model.LopHocs.Where(t => t.Name == tenLop).FirstOrDefault();
                if (lh != null)
                {
                    MessageBox.Show("Tên lớp trùng. Vui lòng nhập tên khác", "Chú ý");
                    return;
                }
                else
                {
                    lh = new LopHoc
                    {
                        Name = tenLop
                    };
                    model.LopHocs.Add(lh);
                    model.SaveChanges();
                    DialogResult = DialogResult.OK;

                }
            }
            else
            {
                // cập nhật

                var lh = model.LopHocs.Where(t => t.ID != lopHoc.ID && t.Name == tenLop).FirstOrDefault();
                if (lh != null)
                {
                    MessageBox.Show("Tên lớp trùng. Vui lòng nhập tên khác", "Chú ý");
                    return;
                }
                else
                {
                    lh = model.LopHocs.Where(t => t.ID == lopHoc.ID).FirstOrDefault();
                    lh.Name = tenLop;
                    model.SaveChanges();
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}

