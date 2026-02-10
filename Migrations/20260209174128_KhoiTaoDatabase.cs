using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhanLuc.Migrations
{
    /// <inheritdoc />
    public partial class KhoiTaoDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isSuperAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChucVuCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuQuanTris",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenMenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViTri = table.Column<int>(type: "int", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuongDan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuQuanTris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuQuanTris_MenuQuanTris_ParentMenuId",
                        column: x => x.ParentMenuId,
                        principalTable: "MenuQuanTris",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhanLoaiNhanSus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhanLoaiCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenPhanLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanLoaiNhanSus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhongBans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaPhongBan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DaoTaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiDungId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TenTruongToChuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NganhHocTenLop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HinhThucHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VanBangChungChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaoTaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaoTaos_AspNetUsers_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuanHeGiaDinhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiDungId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TenNguoiThan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuanHeVoiChuHo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgheNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanHeGiaDinhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuanHeGiaDinhs_AspNetUsers_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoanNganHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiDungId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TenNganHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChiNhanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenChuTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoanNganHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiKhoanNganHangs_AspNetUsers_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrinhDos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiDungId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TrinhDoHocVan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HocHamHocVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LyLuanChinhTri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgoaiNgu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrinhDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrinhDos_AspNetUsers_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VaiTroMenus",
                columns: table => new
                {
                    VaiTroId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTroMenus", x => new { x.VaiTroId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_VaiTroMenus_AspNetRoles_VaiTroId",
                        column: x => x.VaiTroId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaiTroMenus_MenuQuanTris_MenuId",
                        column: x => x.MenuId,
                        principalTable: "MenuQuanTris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanSus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhongBanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanSus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanSus_PhongBans_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinNguoiDungs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    GioiTinhStxt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhongBanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChucVuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NhanSuType = table.Column<int>(type: "int", nullable: true),
                    NhanSuTypeStxt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinNguoiDungs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongTinNguoiDungs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThongTinNguoiDungs_ChucVus_ChucVuId",
                        column: x => x.ChucVuId,
                        principalTable: "ChucVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ThongTinNguoiDungs_PhongBans_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BangLuongs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NhanSuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HeSoLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoNgayCong = table.Column<int>(type: "int", nullable: false),
                    PhuCapAnTrua = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PhuCapXangXe = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PhuCapDienThoai = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PhuCapKhac = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TienThuong = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TienPhat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TienLamThem = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KhauTruBHXH = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KhauTruBHYT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KhauTruBHTN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KhauTruThueNCCT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KhauTruKhac = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TongThuNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TongKhauTru = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LuongThucNhan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NguoiDuyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDuyet = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangLuongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BangLuongs_NhanSus_NhanSuId",
                        column: x => x.NhanSuId,
                        principalTable: "NhanSus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaoHiems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NhanSuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiBaoHiem = table.Column<int>(type: "int", nullable: false),
                    TrangThaiBaoHiem = table.Column<int>(type: "int", nullable: false),
                    SoBHXH = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    SoBHXHCu = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    NgayThamGia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDangKyBHXH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayNhanSoBHXH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTraSoBHXH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayThamGiaBHTN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianDongBHTN = table.Column<int>(type: "int", nullable: false),
                    SoBHYT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NgayCapThe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDangKyKCB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKCB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaTinhBenhVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaTraTheBHYT = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoHiems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaoHiems_NhanSus_NhanSuId",
                        column: x => x.NhanSuId,
                        principalTable: "NhanSus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChamCongs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NhanSuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayChamCong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioVao = table.Column<TimeSpan>(type: "time", nullable: false),
                    GioRa = table.Column<TimeSpan>(type: "time", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamCongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChamCongs_NhanSus_NhanSuId",
                        column: x => x.NhanSuId,
                        principalTable: "NhanSus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HopDongs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHopDong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NhanSuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiHopDong = table.Column<int>(type: "int", nullable: false),
                    NgayKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LuongCoBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    TepDinhKem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDongs_NhanSus_NhanSuId",
                        column: x => x.NhanSuId,
                        principalTable: "NhanSus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KhenThuongKyLuats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaQuyetDinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NhanSuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Loai = table.Column<int>(type: "int", nullable: false),
                    HinhThuc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LyDo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NgayQuyetDinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHieuLuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NguoiDuyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDuyet = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TepDinhKem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhenThuongKyLuats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhenThuongKyLuats_NhanSus_NhanSuId",
                        column: x => x.NhanSuId,
                        principalTable: "NhanSus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LichLamThems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NhanSuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayLamThem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioBatDau = table.Column<TimeSpan>(type: "time", nullable: false),
                    GioKetThuc = table.Column<TimeSpan>(type: "time", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NguoiDuyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichLamThems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichLamThems_NhanSus_NhanSuId",
                        column: x => x.NhanSuId,
                        principalTable: "NhanSus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThuTucHanhChinhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaThuTuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NhanSuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThuTuc = table.Column<int>(type: "int", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NgayNop = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoNgay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NguoiDuyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDuyet = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TepDinhKem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuTucHanhChinhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThuTucHanhChinhs_NhanSus_NhanSuId",
                        column: x => x.NhanSuId,
                        principalTable: "NhanSus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiemDanhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayDiemDanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioDen = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GioVe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemDanhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiemDanhs_ThongTinNguoiDungs_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "ThongTinNguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhiemVus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenNhiemVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HanHoanThanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhiemVus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhiemVus_ThongTinNguoiDungs_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "ThongTinNguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BangLuongs_NhanSuId_Thang_Nam",
                table: "BangLuongs",
                columns: new[] { "NhanSuId", "Thang", "Nam" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaoHiems_NhanSuId",
                table: "BaoHiems",
                column: "NhanSuId");

            migrationBuilder.CreateIndex(
                name: "IX_ChamCongs_NhanSuId",
                table: "ChamCongs",
                column: "NhanSuId");

            migrationBuilder.CreateIndex(
                name: "IX_DaoTaos_NguoiDungId",
                table: "DaoTaos",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_DiemDanhs_NhanVienId",
                table: "DiemDanhs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_MaHopDong",
                table: "HopDongs",
                column: "MaHopDong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_NhanSuId",
                table: "HopDongs",
                column: "NhanSuId");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuongKyLuats_MaQuyetDinh",
                table: "KhenThuongKyLuats",
                column: "MaQuyetDinh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuongKyLuats_NhanSuId",
                table: "KhenThuongKyLuats",
                column: "NhanSuId");

            migrationBuilder.CreateIndex(
                name: "IX_LichLamThems_NhanSuId",
                table: "LichLamThems",
                column: "NhanSuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuQuanTris_ParentMenuId",
                table: "MenuQuanTris",
                column: "ParentMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanSus_MaNhanVien",
                table: "NhanSus",
                column: "MaNhanVien",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhanSus_PhongBanId",
                table: "NhanSus",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_NhiemVus_NhanVienId",
                table: "NhiemVus",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhongBans_MaPhongBan",
                table: "PhongBans",
                column: "MaPhongBan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuanHeGiaDinhs_NguoiDungId",
                table: "QuanHeGiaDinhs",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoanNganHangs_NguoiDungId",
                table: "TaiKhoanNganHangs",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinNguoiDungs_ChucVuId",
                table: "ThongTinNguoiDungs",
                column: "ChucVuId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinNguoiDungs_PhongBanId",
                table: "ThongTinNguoiDungs",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinNguoiDungs_UserId",
                table: "ThongTinNguoiDungs",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ThuTucHanhChinhs_MaThuTuc",
                table: "ThuTucHanhChinhs",
                column: "MaThuTuc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThuTucHanhChinhs_NhanSuId",
                table: "ThuTucHanhChinhs",
                column: "NhanSuId");

            migrationBuilder.CreateIndex(
                name: "IX_TrinhDos_NguoiDungId",
                table: "TrinhDos",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_VaiTroMenus_MenuId",
                table: "VaiTroMenus",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BangLuongs");

            migrationBuilder.DropTable(
                name: "BaoHiems");

            migrationBuilder.DropTable(
                name: "ChamCongs");

            migrationBuilder.DropTable(
                name: "DaoTaos");

            migrationBuilder.DropTable(
                name: "DiemDanhs");

            migrationBuilder.DropTable(
                name: "HopDongs");

            migrationBuilder.DropTable(
                name: "KhenThuongKyLuats");

            migrationBuilder.DropTable(
                name: "LichLamThems");

            migrationBuilder.DropTable(
                name: "NhiemVus");

            migrationBuilder.DropTable(
                name: "PhanLoaiNhanSus");

            migrationBuilder.DropTable(
                name: "QuanHeGiaDinhs");

            migrationBuilder.DropTable(
                name: "TaiKhoanNganHangs");

            migrationBuilder.DropTable(
                name: "ThuTucHanhChinhs");

            migrationBuilder.DropTable(
                name: "TrinhDos");

            migrationBuilder.DropTable(
                name: "VaiTroMenus");

            migrationBuilder.DropTable(
                name: "ThongTinNguoiDungs");

            migrationBuilder.DropTable(
                name: "NhanSus");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "MenuQuanTris");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ChucVus");

            migrationBuilder.DropTable(
                name: "PhongBans");
        }
    }
}
