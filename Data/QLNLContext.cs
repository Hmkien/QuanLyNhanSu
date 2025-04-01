using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Models.Entities;

namespace QuanLyNhanLuc.Data
{
    public class QLNLContext : IdentityDbContext<NguoiDung, VaiTro, string>
    {
        public QLNLContext(DbContextOptions<QLNLContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<NguoiDung> NguoiDungs { get; set; } = null!;
        public DbSet<ThongTinNguoiDung> ThongTinNguoiDungs { get; set; } = null!;
        public DbSet<ChucVu> ChucVus { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<MenuQuanTri> MenuQuanTris { get; set; } = null!;
        public DbSet<VaiTro> VaiTros { get; set; } = null!;
        public DbSet<VaiTroMenu> VaiTroMenus { get; set; } = null!;
        public DbSet<NhiemVu> NhiemVus { get; set; }
        public DbSet<DiemDanh> DiemDanhs { get; set; }
        public DbSet<ChamCong> ChamCongs { get; set; }
        public DbSet<LichLamThem> LichLamThems { get; set; }
        public DbSet<NhanSu> NhanSus { get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<BaoHiem> BaoHiems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ThongTinNguoiDung>()
                .HasOne(t => t.Department)
                .WithMany(d => d.NhanSus)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<ThongTinNguoiDung>()
                .HasOne(t => t.ChucVu)
                .WithMany(c => c.NhanSus)
                .HasForeignKey(t => t.ChucVuId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<VaiTroMenu>()
                .HasKey(vm => new { vm.VaiTroId, vm.MenuId });

            builder.Entity<NguoiDung>()
                .HasOne(u => u.ThongTinNguoiDung)
                .WithOne(t => t.User)
                .HasForeignKey<ThongTinNguoiDung>(t => t.UserId);

            // Cấu hình PhongBan
            builder.Entity<PhongBan>()
                .HasIndex(p => p.MaPhongBan)
                .IsUnique();

            // Cấu hình NhanSu
            builder.Entity<NhanSu>()
                .HasIndex(n => n.MaNhanVien)
                .IsUnique();

            builder.Entity<NhanSu>()
                .HasOne(n => n.PhongBan)
                .WithMany(p => p.NhanSus)
                .HasForeignKey(n => n.PhongBanId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình ChamCong
            builder.Entity<ChamCong>()
                .HasOne(c => c.NhanSu)
                .WithMany(n => n.ChamCongs)
                .HasForeignKey(c => c.NhanSuId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình LichLamThem
            builder.Entity<LichLamThem>()
                .HasOne(l => l.NhanSu)
                .WithMany(n => n.LichLamThems)
                .HasForeignKey(l => l.NhanSuId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}