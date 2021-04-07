
using System.Data.Entity;
namespace DataAcess
{
    public class EntityContext06table
    {
        public void exec(DbModelBuilder modelBuilder)
        {
            #region Start Code
            modelBuilder.Entity<md_namtaichinh_ky>().ToTable("md_namtaichinh_ky");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.loaiky)
                            .HasColumnName("loaiky")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.ma_ky)
                            .HasColumnName("ma_ky")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.md_namtaichinh_id)
                            .HasColumnName("md_namtaichinh_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.md_namtaichinh_ky_id)
                            .HasColumnName("md_namtaichinh_ky_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_namtaichinh_ky>().HasKey<string>(p => p.md_namtaichinh_ky_id);
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.ngaybatdau)
                            .HasColumnName("ngaybatdau")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.ngayketthuc)
                            .HasColumnName("ngayketthuc")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.soky)
                            .HasColumnName("soky")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.ten_ky)
                            .HasColumnName("ten_ky")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh_ky>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nangluc>().ToTable("md_nangluc");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.hehang)
                            .HasColumnName("hehang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.md_nangluc_id)
                            .HasColumnName("md_nangluc_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nangluc>().HasKey<string>(p => p.md_nangluc_id);
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.nam)
                            .HasColumnName("nam")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.nangsuat)
                            .HasColumnName("nangsuat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.soluongconlai)
                            .HasColumnName("soluongconlai")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.soluongdadat)
                            .HasColumnName("soluongdadat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.tuan)
                            .HasColumnName("tuan")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nangluc>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhanphoisoi>().ToTable("md_nhanphoisoi");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.ma_sp)
                            .HasColumnName("ma_sp")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.md_nhanphoisoi_id)
                            .HasColumnName("md_nhanphoisoi_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_nhanphoisoi>().HasKey<string>(p => p.md_nhanphoisoi_id);
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.nhanphoisoi)
                            .HasColumnName("nhanphoisoi")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhanphoisoi>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkho_ncc>().ToTable("md_nhapkho_ncc");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.c_donmuahang_id)
                            .HasColumnName("c_donmuahang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.check_hieuluc)
                            .HasColumnName("check_hieuluc")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.ketoan)
                            .HasColumnName("ketoan")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.kho)
                            .HasColumnName("kho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.md_nhapkho_ncc_id)
                            .HasColumnName("md_nhapkho_ncc_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkho_ncc>().HasKey<string>(p => p.md_nhapkho_ncc_id);
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.ngaychuyen)
                            .HasColumnName("ngaychuyen")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.ngaydenghi)
                            .HasColumnName("ngaydenghi")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.ngaygiaohang)
                            .HasColumnName("ngaygiaohang")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.nguoidung)
                            .HasColumnName("nguoidung")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.phieugiaohang)
                            .HasColumnName("phieugiaohang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.phieuXNNK)
                            .HasColumnName("phieuXNNK")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.so_donmuahang)
                            .HasColumnName("so_donmuahang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.ten_dtkd)
                            .HasColumnName("ten_dtkd")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkho_ncc_dh>().ToTable("md_nhapkho_ncc_dh");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.c_donmuahang_id)
                            .HasColumnName("c_donmuahang_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.check_kho)
                            .HasColumnName("check_kho")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.ghichu_donvi2)
                            .HasColumnName("ghichu_donvi2")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.giatriVND)
                            .HasColumnName("giatriVND")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.khoden)
                            .HasColumnName("khoden")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.md_nhapkho_ncc_dh_id)
                            .HasColumnName("md_nhapkho_ncc_dh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkho_ncc_dh>().HasKey<string>(p => p.md_nhapkho_ncc_dh_id);
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.md_nhapkho_ncc_id)
                            .HasColumnName("md_nhapkho_ncc_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.mota_tienganh)
                            .HasColumnName("mota_tienganh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.mota_tiengviet)
                            .HasColumnName("mota_tiengviet")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.ngay_hethan)
                            .HasColumnName("ngay_hethan")
                            .HasColumnType("date");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.quycach)
                            .HasColumnName("quycach")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.sl_danhap)
                            .HasColumnName("sl_danhap")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.sl_danhap2)
                            .HasColumnName("sl_danhap2")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.sl_muonnhap)
                            .HasColumnName("sl_muonnhap")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.sl_muonnhap2)
                            .HasColumnName("sl_muonnhap2")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.sl_nhap)
                            .HasColumnName("sl_nhap")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.sl_nhap2)
                            .HasColumnName("sl_nhap2")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.so_dmh)
                            .HasColumnName("so_dmh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.STT)
                            .HasColumnName("STT")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.thue)
                            .HasColumnName("thue")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.tong_sl_dat)
                            .HasColumnName("tong_sl_dat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.tong_sl_dat2)
                            .HasColumnName("tong_sl_dat2")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc_dh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkho_px>().ToTable("md_nhapkho_px");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.check_hieuluc)
                            .HasColumnName("check_hieuluc")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.md_dondathangphanxuong_id)
                            .HasColumnName("md_dondathangphanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.md_nhapkho_px_id)
                            .HasColumnName("md_nhapkho_px_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkho_px>().HasKey<string>(p => p.md_nhapkho_px_id);
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.phieunhapkho)
                            .HasColumnName("phieunhapkho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkho_px_dh>().ToTable("md_nhapkho_px_dh");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.check_kho)
                            .HasColumnName("check_kho")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.khoden)
                            .HasColumnName("khoden")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.md_nhapkho_px_dh_id)
                            .HasColumnName("md_nhapkho_px_dh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkho_px_dh>().HasKey<string>(p => p.md_nhapkho_px_dh_id);
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.md_nhapkho_px_id)
                            .HasColumnName("md_nhapkho_px_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.sl_danhap)
                            .HasColumnName("sl_danhap")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.sl_nhap)
                            .HasColumnName("sl_nhap")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.tong_sl_dat)
                            .HasColumnName("tong_sl_dat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_px_dh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkhonb>().ToTable("md_nhapkhonb");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.baotri_vattu)
                            .HasColumnName("baotri_vattu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.bosung)
                            .HasColumnName("bosung")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.chungtu_lenhsx)
                            .HasColumnName("chungtu_lenhsx")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.denkho)
                            .HasColumnName("denkho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.diachi)
                            .HasColumnName("diachi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.ketoan)
                            .HasColumnName("ketoan")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.khuon)
                            .HasColumnName("khuon")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.md_lenhsanxuat_id)
                            .HasColumnName("md_lenhsanxuat_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.md_lenhsanxuat_tosx_id)
                            .HasColumnName("md_lenhsanxuat_tosx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.md_nhapkhonb_id)
                            .HasColumnName("md_nhapkhonb_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkhonb>().HasKey<string>(p => p.md_nhapkhonb_id);
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.md_xuatkhonb_id)
                            .HasColumnName("md_xuatkhonb_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.ngaychuyen)
                            .HasColumnName("ngaychuyen")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.ngaydenghi)
                            .HasColumnName("ngaydenghi")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.nhaptu)
                            .HasColumnName("nhaptu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.phieuXNNK)
                            .HasColumnName("phieuXNNK")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkhonb_cdh>().ToTable("md_nhapkhonb_cdh");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.check_kho)
                            .HasColumnName("check_kho")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.ghichu_donvi2)
                            .HasColumnName("ghichu_donvi2")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.khoden)
                            .HasColumnName("khoden")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.lsx_to)
                            .HasColumnName("lsx_to")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.md_nhapkhonb_cdh_id)
                            .HasColumnName("md_nhapkhonb_cdh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkhonb_cdh>().HasKey<string>(p => p.md_nhapkhonb_cdh_id);
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.md_nhapkhonb_id)
                            .HasColumnName("md_nhapkhonb_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.ngay_hethan)
                            .HasColumnName("ngay_hethan")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.sl_danhap)
                            .HasColumnName("sl_danhap")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.sl_muonnhap)
                            .HasColumnName("sl_muonnhap")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.sl_nhap)
                            .HasColumnName("sl_nhap")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.sl_toida_trongLSXTo)
                            .HasColumnName("sl_toida_trongLSXTo")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.sl_toida_trongLSXTo2)
                            .HasColumnName("sl_toida_trongLSXTo2")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.tenhang)
                            .HasColumnName("tenhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.tong_sl_dat)
                            .HasColumnName("tong_sl_dat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhonb_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkhoton>().ToTable("md_nhapkhoton");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.denkho)
                            .HasColumnName("denkho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.diachi)
                            .HasColumnName("diachi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.ketoan)
                            .HasColumnName("ketoan")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.khuon)
                            .HasColumnName("khuon")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.md_lenhsanxuat_id)
                            .HasColumnName("md_lenhsanxuat_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.md_lenhsanxuat_tosx_id)
                            .HasColumnName("md_lenhsanxuat_tosx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.md_nhapkhoton_id)
                            .HasColumnName("md_nhapkhoton_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkhoton>().HasKey<string>(p => p.md_nhapkhoton_id);
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.ngaychuyen)
                            .HasColumnName("ngaychuyen")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.ngaydenghi)
                            .HasColumnName("ngaydenghi")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.nhaptu)
                            .HasColumnName("nhaptu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.phieuXNNK)
                            .HasColumnName("phieuXNNK")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkhoton_cdh>().ToTable("md_nhapkhoton_cdh");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.check_kho)
                            .HasColumnName("check_kho")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.ghichu_donvi2)
                            .HasColumnName("ghichu_donvi2")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.khoden)
                            .HasColumnName("khoden")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.md_nhapkhoton_cdh_id)
                            .HasColumnName("md_nhapkhoton_cdh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhapkhoton_cdh>().HasKey<string>(p => p.md_nhapkhoton_cdh_id);
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.md_nhapkhoton_id)
                            .HasColumnName("md_nhapkhoton_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.sl_danhap)
                            .HasColumnName("sl_danhap")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.sl_nhap)
                            .HasColumnName("sl_nhap")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.tong_sl_dat)
                            .HasColumnName("tong_sl_dat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkhoton_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhomnangluc>().ToTable("md_nhomnangluc");
                            modelBuilder.Entity<md_nhomnangluc>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_nhomnangluc>()
                            .Property(p => p.ma_nhom)
                            .HasColumnName("ma_nhom")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhomnangluc>()
                            .Property(p => p.md_nhomnangluc_id)
                            .HasColumnName("md_nhomnangluc_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_nhomnangluc>().HasKey<string>(p => p.md_nhomnangluc_id);
                            modelBuilder.Entity<md_nhomnangluc>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhomnangluc>()
                            .Property(p => p.mota_tiengviet)
                            .HasColumnName("mota_tiengviet")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhomnangluc>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhomnangluc>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_nhomnangluc>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhomnangluc>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhomnangluc>()
                            .Property(p => p.ten_nhom)
                            .HasColumnName("ten_nhom")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhomnangluc>()
                            .Property(p => p.thoigianlamhang)
                            .HasColumnName("thoigianlamhang")
                            .HasColumnType("int");
modelBuilder.Entity<md_phannnhommx>().ToTable("md_phannnhommx");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.dientich_lonnhat)
                            .HasColumnName("dientich_lonnhat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.dientich_nhonhat)
                            .HasColumnName("dientich_nhonhat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.dongia_mauA)
                            .HasColumnName("dongia_mauA")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.dongia_mauB)
                            .HasColumnName("dongia_mauB")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.hinhdang)
                            .HasColumnName("hinhdang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.ketcausoi)
                            .HasColumnName("ketcausoi")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.ma_mx)
                            .HasColumnName("ma_mx")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.md_phannnhommx_id)
                            .HasColumnName("md_phannnhommx_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_phannnhommx>().HasKey<string>(p => p.md_phannnhommx_id);
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.titrong)
                            .HasColumnName("titrong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_phannnhommx_cdpk>().ToTable("md_phannnhommx_cdpk");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.md_phannnhommx_cdpk_id)
                            .HasColumnName("md_phannnhommx_cdpk_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_phannnhommx_cdpk>().HasKey<string>(p => p.md_phannnhommx_cdpk_id);
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.md_phannnhommx_id)
                            .HasColumnName("md_phannnhommx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.md_sanphammausac_id)
                            .HasColumnName("md_sanphammausac_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.tile)
                            .HasColumnName("tile")
                            .HasColumnType("float");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.tile_cdct)
                            .HasColumnName("tile_cdct")
                            .HasColumnType("float");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.tile_v52)
                            .HasColumnName("tile_v52")
                            .HasColumnType("float");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_cdpk>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_phannnhommx_qhd>().ToTable("md_phannnhommx_qhd");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.md_phannnhommx_id)
                            .HasColumnName("md_phannnhommx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.md_phannnhommx_qhd_id)
                            .HasColumnName("md_phannnhommx_qhd_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_phannnhommx_qhd>().HasKey<string>(p => p.md_phannnhommx_qhd_id);
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.tile)
                            .HasColumnName("tile")
                            .HasColumnType("float");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_qhd>()
                            .Property(p => p.vattu_value)
                            .HasColumnName("vattu_value")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_phannnhommx_tlkthh>().ToTable("md_phannnhommx_tlkthh");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.md_phannnhommx_id)
                            .HasColumnName("md_phannnhommx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.md_phannnhommx_tlkthh_id)
                            .HasColumnName("md_phannnhommx_tlkthh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_phannnhommx_tlkthh>().HasKey<string>(p => p.md_phannnhommx_tlkthh_id);
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.md_sanphammausac_id)
                            .HasColumnName("md_sanphammausac_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.tile)
                            .HasColumnName("tile")
                            .HasColumnType("float");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phannnhommx_tlkthh>()
                            .Property(p => p.vattu_value)
                            .HasColumnName("vattu_value")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_phanxuong>().ToTable("md_phanxuong");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.ma_phanxuong)
                            .HasColumnName("ma_phanxuong")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_phanxuong>().HasKey<string>(p => p.md_phanxuong_id);
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.ten_phanxuong)
                            .HasColumnName("ten_phanxuong")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_phanxuong_to>().ToTable("md_phanxuong_to");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.congdoan)
                            .HasColumnName("congdoan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.ma_to)
                            .HasColumnName("ma_to")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_phanxuong_to>().HasKey<string>(p => p.md_to_id);
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.ten_to)
                            .HasColumnName("ten_to")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phanxuong_to>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_phienbangia>().ToTable("md_phienbangia");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.md_banggia_id)
                            .HasColumnName("md_banggia_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.md_phienbangia_id)
                            .HasColumnName("md_phienbangia_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_phienbangia>().HasKey<string>(p => p.md_phienbangia_id);
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.md_trangthai_id)
                            .HasColumnName("md_trangthai_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.ngay_hieuluc)
                            .HasColumnName("ngay_hieuluc")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.ten_phienbangia)
                            .HasColumnName("ten_phienbangia")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_phienbangia>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_quocgia>().ToTable("md_quocgia");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.ma_quocgia)
                            .HasColumnName("ma_quocgia")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.md_quocgia_id)
                            .HasColumnName("md_quocgia_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_quocgia>().HasKey<string>(p => p.md_quocgia_id);
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.ten_quocgia)
                            .HasColumnName("ten_quocgia")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                    
            #endregion End Code
        }
    }
}
