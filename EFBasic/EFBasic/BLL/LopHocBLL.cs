using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFBasic.DALL;
using EFBasic.ViewModel;

namespace EFBasic.BLL
{
    internal class LopHocBLL //Business logic layer
    {
        /// <summary>
        /// Lấy tất cả lớp học có trong CSDL
        /// </summary>
        /// <returns></returns>
        public static List<LopHoc> GetList()
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var ls = model.LopHocs.ToList();//select* from LopHoc
            return ls;

        }


        public static List<LopHocViewModel> GetListViewModel()
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var ls = model.LopHocs.Select(e => new LopHocViewModel
            {
                ID = e.ID,
                Name = e.Name,
                TotalStudent = e.SinhViens.Count,
            }).ToList();
            return ls;
        }

        public static bool Delete(long idLophoc)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var lopHoc = model.LopHocs.Where(e => e.ID == idLophoc).FirstOrDefault();
            if (lopHoc.SinhViens.Count == 0)
            {
                model.LopHocs.Remove(lopHoc);
                model.SaveChanges();
                return true;
            }
            else return false;
        }


    }
}
