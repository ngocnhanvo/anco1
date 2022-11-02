
using System.Data.Entity;
namespace DataAcess
{
    public class EntityContext05table
    {
        public void exec(DbModelBuilder modelBuilder)
        {
            #region Start Code
            modelBuilder.Entity<md_kho_the>().ToTable("md_kho_the");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.dongchuyen)
                            .HasColumnName("dongchuyen")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.dongkiem)
                            .HasColumnName("dongkiem")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.dongsx)
                            .HasColumnName("dongsx")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.dongxuat)
                            .HasColumnName("dongxuat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.dualq)
                            .HasColumnName("dualq")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.kieuxuatnhap)
                            .HasColumnName("kieuxuatnhap")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.md_donvidh_id)
                            .HasColumnName("md_donvidh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.md_donvido_id)
                            .HasColumnName("md_donvido_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.md_thekho_id)
                            .HasColumnName("md_thekho_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_kho_the>().HasKey<string>(p => p.md_thekho_id);
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.ngaychuyen)
                            .HasColumnName("ngaychuyen")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.soluongdc)
                            .HasColumnName("soluongdc")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.soluongdh)
                            .HasColumnName("soluongdh")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.thongsobtt)
                            .HasColumnName("thongsobtt")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_the>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_khuvuc>().ToTable("md_khuvuc");
                            modelBuilder.Entity<md_khuvuc>()
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_khuvuc>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_khuvuc>()
                            .Property(p => p.ma_khuvuc)
                            .HasColumnName("ma_khuvuc")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_khuvuc>()
                            .Property(p => p.md_khuvuc_id)
                            .HasColumnName("md_khuvuc_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_khuvuc>().HasKey<string>(p => p.md_khuvuc_id);
                            modelBuilder.Entity<md_khuvuc>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_khuvuc>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_khuvuc>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_khuvuc>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_khuvuc>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_khuvuc>()
                            .Property(p => p.ten_khuvuc)
                            .HasColumnName("ten_khuvuc")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_kiemke>().ToTable("md_kiemke");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.ma_kiemke)
                            .HasColumnName("ma_kiemke")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.md_kiemke_id)
                            .HasColumnName("md_kiemke_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_kiemke>().HasKey<string>(p => p.md_kiemke_id);
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.ngay_kiemke)
                            .HasColumnName("ngay_kiemke")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.ngaydenghi)
                            .HasColumnName("ngaydenghi")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.ten_kiemke)
                            .HasColumnName("ten_kiemke")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_kiemke_cdh>().ToTable("md_kiemke_cdh");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.ma_sanpham)
                            .HasColumnName("ma_sanpham")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.md_kiemke_cdh_id)
                            .HasColumnName("md_kiemke_cdh_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_kiemke_cdh>().HasKey<string>(p => p.md_kiemke_cdh_id);
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.md_kiemke_id)
                            .HasColumnName("md_kiemke_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.mota_tiengviet)
                            .HasColumnName("mota_tiengviet")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.sl_demduoc)
                            .HasColumnName("sl_demduoc")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.sl_sosach)
                            .HasColumnName("sl_sosach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kiemke_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhdonggoi>().ToTable("md_lenhdonggoi");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.c_danhsachdathang_id)
                            .HasColumnName("c_danhsachdathang_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.md_lenhdonggoi_id)
                            .HasColumnName("md_lenhdonggoi_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_lenhdonggoi>().HasKey<string>(p => p.md_lenhdonggoi_id);
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.md_trangthai_id)
                            .HasColumnName("md_trangthai_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.ngayhoanthanh)
                            .HasColumnName("ngayhoanthanh")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.ngayketthuc)
                            .HasColumnName("ngayketthuc")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.ngaylap)
                            .HasColumnName("ngaylap")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhdonggoi_dh>().ToTable("md_lenhdonggoi_dh");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.bomdonggoi_id)
                            .HasColumnName("bomdonggoi_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.md_lenhdonggoi_dh_id)
                            .HasColumnName("md_lenhdonggoi_dh_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_lenhdonggoi_dh>().HasKey<string>(p => p.md_lenhdonggoi_dh_id);
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.md_lenhdonggoi_id)
                            .HasColumnName("md_lenhdonggoi_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.ngayhoanthanh)
                            .HasColumnName("ngayhoanthanh")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.ngayketthuc)
                            .HasColumnName("ngayketthuc")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.ngaylap)
                            .HasColumnName("ngaylap")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.sl_donggoi)
                            .HasColumnName("sl_donggoi")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.sl_donhang)
                            .HasColumnName("sl_donhang")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_dh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhdonggoi_vattu>().ToTable("md_lenhdonggoi_vattu");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.md_lenhdonggoi_id)
                            .HasColumnName("md_lenhdonggoi_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.md_lenhdonggoi_vattu_id)
                            .HasColumnName("md_lenhdonggoi_vattu_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_lenhdonggoi_vattu>().HasKey<string>(p => p.md_lenhdonggoi_vattu_id);
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.soluong_dagiao)
                            .HasColumnName("soluong_dagiao")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhdonggoi_vattu>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat>().ToTable("md_lenhsanxuat");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.check_dtvt)
                            .HasColumnName("check_dtvt")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.lydogiaosom_tre)
                            .HasColumnName("lydogiaosom_tre")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.md_dondathangphanxuong_id)
                            .HasColumnName("md_dondathangphanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.md_lenhsanxuat_id)
                            .HasColumnName("md_lenhsanxuat_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat>().HasKey<string>(p => p.md_lenhsanxuat_id);
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.md_trangthai_id)
                            .HasColumnName("md_trangthai_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.ngaydkgiaotp)
                            .HasColumnName("ngaydkgiaotp")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.ngayhoanthanh)
                            .HasColumnName("ngayhoanthanh")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.ngayketthuc)
                            .HasColumnName("ngayketthuc")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.ngaylap)
                            .HasColumnName("ngaylap")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.ngayxlhangton)
                            .HasColumnName("ngayxlhangton")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.phieuXK)
                            .HasColumnName("phieuXK")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_ddsx>().ToTable("md_lenhsanxuat_ddsx");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.check_hoanthanh)
                            .HasColumnName("check_hoanthanh")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.md_lenhsanxuat_ddsx_id)
                            .HasColumnName("md_lenhsanxuat_ddsx_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_ddsx>().HasKey<string>(p => p.md_lenhsanxuat_ddsx_id);
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.md_lenhsanxuat_id)
                            .HasColumnName("md_lenhsanxuat_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.sl_canlam)
                            .HasColumnName("sl_canlam")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.sl_dalam)
                            .HasColumnName("sl_dalam")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.sl_dk_khuon)
                            .HasColumnName("sl_dk_khuon")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.sl_dukien)
                            .HasColumnName("sl_dukien")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.sl_khuon)
                            .HasColumnName("sl_khuon")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.songay)
                            .HasColumnName("songay")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_ddsx>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx>().ToTable("md_lenhsanxuat_tosx");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.check_hoanthanh)
                            .HasColumnName("check_hoanthanh")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.ma_to)
                            .HasColumnName("ma_to")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.md_lenhsanxuat_id)
                            .HasColumnName("md_lenhsanxuat_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.md_lenhsanxuat_tosx_id)
                            .HasColumnName("md_lenhsanxuat_tosx_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx>().HasKey<string>(p => p.md_lenhsanxuat_tosx_id);
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.md_phanxuong_to_id)
                            .HasColumnName("md_phanxuong_to_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.ngaybatdausx)
                            .HasColumnName("ngaybatdausx")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.ngaydkht)
                            .HasColumnName("ngaydkht")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.ngaygiao)
                            .HasColumnName("ngaygiao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.ngayhoanthanh)
                            .HasColumnName("ngayhoanthanh")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.phieudoimau)
                            .HasColumnName("phieudoimau")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.phieulayht)
                            .HasColumnName("phieulayht")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.phieulayhttp)
                            .HasColumnName("phieulayhttp")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.phongbanId)
                            .HasColumnName("phongbanId")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.stt)
                            .HasColumnName("stt")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.tinhhangton)
                            .HasColumnName("tinhhangton")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.tinhhangtontp)
                            .HasColumnName("tinhhangtontp")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.tolayton)
                            .HasColumnName("tolayton")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.tolaytonId)
                            .HasColumnName("tolaytonId")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.tolaytontpId)
                            .HasColumnName("tolaytontpId")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>().ToTable("md_lenhsanxuat_tosx_cdh");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.gianhancong)
                            .HasColumnName("gianhancong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.macuoi)
                            .HasColumnName("macuoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.mathaydoi)
                            .HasColumnName("mathaydoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.md_lenhsanxuat_tosx_cdh_id)
                            .HasColumnName("md_lenhsanxuat_tosx_cdh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>().HasKey<string>(p => p.md_lenhsanxuat_tosx_cdh_id);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.md_lenhsanxuat_tosx_id)
                            .HasColumnName("md_lenhsanxuat_tosx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.ngayhoanthanh)
                            .HasColumnName("ngayhoanthanh")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.nhanphoisoi)
                            .HasColumnName("nhanphoisoi")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.nhomnangluc)
                            .HasColumnName("nhomnangluc")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.noigiaohang)
                            .HasColumnName("noigiaohang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_chiato)
                            .HasColumnName("sl_chiato")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_chiato2)
                            .HasColumnName("sl_chiato2")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_chophepnkton)
                            .HasColumnName("sl_chophepnkton")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_dagiao)
                            .HasColumnName("sl_dagiao")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_dahoanthanh)
                            .HasColumnName("sl_dahoanthanh")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_danhapkho)
                            .HasColumnName("sl_danhapkho")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_dat)
                            .HasColumnName("sl_dat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_hoanthanh)
                            .HasColumnName("sl_hoanthanh")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_layton)
                            .HasColumnName("sl_layton")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_laytondu)
                            .HasColumnName("sl_laytondu")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_nhapkho)
                            .HasColumnName("sl_nhapkho")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_nkton)
                            .HasColumnName("sl_nkton")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_tamgiao)
                            .HasColumnName("sl_tamgiao")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.sl_tinhvattu)
                            .HasColumnName("sl_tinhvattu")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>().ToTable("md_lenhsanxuat_tosx_dklht");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.macuoi)
                            .HasColumnName("macuoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.md_lenhsanxuat_tosx_dklht_id)
                            .HasColumnName("md_lenhsanxuat_tosx_dklht_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>().HasKey<string>(p => p.md_lenhsanxuat_tosx_dklht_id);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.md_lenhsanxuat_tosx_id)
                            .HasColumnName("md_lenhsanxuat_tosx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.sl_layton)
                            .HasColumnName("sl_layton")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.sl_lsx)
                            .HasColumnName("sl_lsx")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.sl_tonkho)
                            .HasColumnName("sl_tonkho")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklht>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>().ToTable("md_lenhsanxuat_tosx_dklhttp");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.macuoi)
                            .HasColumnName("macuoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.md_lenhsanxuat_tosx_dklht_id)
                            .HasColumnName("md_lenhsanxuat_tosx_dklht_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.md_lenhsanxuat_tosx_dklhttp_id)
                            .HasColumnName("md_lenhsanxuat_tosx_dklhttp_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>().HasKey<string>(p => p.md_lenhsanxuat_tosx_dklhttp_id);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.md_lenhsanxuat_tosx_id)
                            .HasColumnName("md_lenhsanxuat_tosx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.sl_layton)
                            .HasColumnName("sl_layton")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.sl_lsx)
                            .HasColumnName("sl_lsx")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.sl_tonkho)
                            .HasColumnName("sl_tonkho")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_dklhttp>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>().ToTable("md_lenhsanxuat_tosx_tonkho");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.macungkieudang)
                            .HasColumnName("macungkieudang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.md_lenhsanxuat_tosx_id)
                            .HasColumnName("md_lenhsanxuat_tosx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.md_lenhsanxuat_tosx_tonkho_id)
                            .HasColumnName("md_lenhsanxuat_tosx_tonkho_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>().HasKey<string>(p => p.md_lenhsanxuat_tosx_tonkho_id);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.sl_tonkho)
                            .HasColumnName("sl_tonkho")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_tonkho>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>().ToTable("md_lenhsanxuat_tosx_vattu");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.md_lenhsanxuat_tosx_id)
                            .HasColumnName("md_lenhsanxuat_tosx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.md_lenhsanxuat_tosx_vattu_id)
                            .HasColumnName("md_lenhsanxuat_tosx_vattu_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>().HasKey<string>(p => p.md_lenhsanxuat_tosx_vattu_id);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.sl_backup)
                            .HasColumnName("sl_backup")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.sl_hanngach)
                            .HasColumnName("sl_hanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattu>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>().ToTable("md_lenhsanxuat_tosx_vattuBackup");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.md_lenhsanxuat_tosx_id)
                            .HasColumnName("md_lenhsanxuat_tosx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.md_lenhsanxuat_tosx_vattuBackup_id)
                            .HasColumnName("md_lenhsanxuat_tosx_vattuBackup_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>().HasKey<string>(p => p.md_lenhsanxuat_tosx_vattuBackup_id);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.sp)
                            .HasColumnName("sp")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx_vattuBackup>()
                            .Property(p => p.vt)
                            .HasColumnName("vt")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_vattu>().ToTable("md_lenhsanxuat_vattu");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.bosung)
                            .HasColumnName("bosung")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.md_dondathangphanxuong_id)
                            .HasColumnName("md_dondathangphanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.md_lenhsanxuat_id)
                            .HasColumnName("md_lenhsanxuat_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.md_lenhsanxuat_tosx_id)
                            .HasColumnName("md_lenhsanxuat_tosx_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.md_lenhsanxuat_vattu_id)
                            .HasColumnName("md_lenhsanxuat_vattu_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_lenhsanxuat_vattu>().HasKey<string>(p => p.md_lenhsanxuat_vattu_id);
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.mota_tienganh)
                            .HasColumnName("mota_tienganh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.mota_tiengviet)
                            .HasColumnName("mota_tiengviet")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.sl_canxuat)
                            .HasColumnName("sl_canxuat")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.sl_daxuat)
                            .HasColumnName("sl_daxuat")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_vattu>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_loaicont>().ToTable("md_loaicont");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.md_loaicont_id)
                            .HasColumnName("md_loaicont_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_loaicont>().HasKey<string>(p => p.md_loaicont_id);
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.soluongCBM)
                            .HasColumnName("soluongCBM")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.ten_cont)
                            .HasColumnName("ten_cont")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_loaicont>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_loaidtkd>().ToTable("md_loaidtkd");
                            modelBuilder.Entity<md_loaidtkd>()
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_loaidtkd>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_loaidtkd>()
                            .Property(p => p.ma_loaidtkd)
                            .HasColumnName("ma_loaidtkd")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_loaidtkd>()
                            .Property(p => p.md_loaidtkd_id)
                            .HasColumnName("md_loaidtkd_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_loaidtkd>().HasKey<string>(p => p.md_loaidtkd_id);
                            modelBuilder.Entity<md_loaidtkd>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_loaidtkd>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_loaidtkd>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_loaidtkd>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_loaidtkd>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_loaidtkd>()
                            .Property(p => p.ten_loaidtkd)
                            .HasColumnName("ten_loaidtkd")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_modongky>().ToTable("md_modongky");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.hieuluc)
                            .HasColumnName("hieuluc")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.ky)
                            .HasColumnName("ky")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.ky_hoatdong)
                            .HasColumnName("ky_hoatdong")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.loai_baocao)
                            .HasColumnName("loai_baocao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.md_modongky_id)
                            .HasColumnName("md_modongky_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_modongky>().HasKey<string>(p => p.md_modongky_id);
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.md_namtaichinh_id)
                            .HasColumnName("md_namtaichinh_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.md_namtaichinh_ky_id)
                            .HasColumnName("md_namtaichinh_ky_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.nam)
                            .HasColumnName("nam")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_modongky>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                    
            #endregion End Code
        }
    }
}
