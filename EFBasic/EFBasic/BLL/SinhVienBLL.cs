using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFBasic.DALL;

namespace EFBasic.BLL
{
    internal class SinhVienBLL
    {
        /// <summary>
        /// Lấy danh sách sinh viên theo lớp
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns></returns>
        public static List<SinhVien> GetList(long maLop)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var ls = model.SinhViens.Where(e => e.IDLopHoc == maLop).ToList();//select* from SinhVien where IDLopHoc=maLop
            return ls;

        }

        public static int Count(long maLop)
        {
            //dếm trong DB
            QLSinhVienModel model = new QLSinhVienModel();
            var d = model.SinhViens.Where(e => e.IDLopHoc == maLop).Count();
            return d;
            //return 0; lấy dl ra r đêm
        }

        public static void Delete(string idSinhVien)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var sinhVien = model.SinhViens.Where(e => e.IDStudent == idSinhVien).FirstOrDefault();

            model.SinhViens.Remove(sinhVien);
            model.SaveChanges();
            return;
        }

    }
}
