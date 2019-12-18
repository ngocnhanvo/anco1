
using System.Data.Entity;
namespace DataAcess
{
    public class EntityContext05table
    {
        public void exec(DbModelBuilder modelBuilder)
        {
            #region Start Code
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
                            .Property(p => p.phieulayht)
                            .HasColumnName("phieulayht")
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
                            .Property(p => p.tolayton)
                            .HasColumnName("tolayton")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.tolaytonId)
                            .HasColumnName("tolaytonId")
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
modelBuilder.Entity<md_namtaichinh>().ToTable("md_namtaichinh");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.giatri)
                            .HasColumnName("giatri")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.ma_namtaichinh)
                            .HasColumnName("ma_namtaichinh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.md_namtaichinh_id)
                            .HasColumnName("md_namtaichinh_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_namtaichinh>().HasKey<string>(p => p.md_namtaichinh_id);
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.ten_namtaichinh)
                            .HasColumnName("ten_namtaichinh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_namtaichinh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
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
                    
                    
            #endregion End Code
        }
    }
}
