using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EFBasic.DALL
{
    public partial class QLSinhVienModel : DbContext
    {
        public QLSinhVienModel()
            : base("name=AppConnectionString")
        {
        }

        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.SinhViens)
                .WithOptional(e => e.LopHoc)
                .HasForeignKey(e => e.IDLopHoc);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.IDStudent)
                .IsUnicode(false);
        }
    }
}