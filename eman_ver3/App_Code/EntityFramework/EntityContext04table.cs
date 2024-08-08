
using System.Data.Entity;
namespace DataAcess
{
    public class EntityContext04table
    {
        public void exec(DbModelBuilder modelBuilder)
        {
            #region Start Code
            modelBuilder.Entity<md_dondathangphanxuong_cdh>().ToTable("md_dondathangphanxuong_cdh");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.md_dondathangphanxuong_cdh_id)
                            .HasColumnName("md_dondathangphanxuong_cdh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_dondathangphanxuong_cdh>().HasKey<string>(p => p.md_dondathangphanxuong_cdh_id);
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.c_danhsachdathang_id)
                            .HasColumnName("c_danhsachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.hanngach)
                            .HasColumnName("hanngach")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.macuoi)
                            .HasColumnName("macuoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.md_dondathangphanxuong_id)
                            .HasColumnName("md_dondathangphanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.md_phanxuong_to_id)
                            .HasColumnName("md_phanxuong_to_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.noigiaohang)
                            .HasColumnName("noigiaohang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.sl_chiato)
                            .HasColumnName("sl_chiato")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.sl_hanngach)
                            .HasColumnName("sl_hanngach")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.sl_hoanthanh)
                            .HasColumnName("sl_hoanthanh")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.sl_tamhoanthanh)
                            .HasColumnName("sl_tamhoanthanh")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.tong_sl_dat)
                            .HasColumnName("tong_sl_dat")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>().ToTable("md_dondathangphanxuong_tinhhinh");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.md_dondathangphanxuong_tinhhinh_id)
                            .HasColumnName("md_dondathangphanxuong_tinhhinh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>().HasKey<string>(p => p.md_dondathangphanxuong_tinhhinh_id);
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.macuoi)
                            .HasColumnName("macuoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.md_dondathangphanxuong_id)
                            .HasColumnName("md_dondathangphanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.ngayhoanthanh)
                            .HasColumnName("ngayhoanthanh")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.noigiaohang)
                            .HasColumnName("noigiaohang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.sl_dat)
                            .HasColumnName("sl_dat")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.sl_hoanthanh)
                            .HasColumnName("sl_hoanthanh")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_dondathangphanxuong_vattu>().ToTable("md_dondathangphanxuong_vattu");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.md_dondathangphanxuong_vattu_id)
                            .HasColumnName("md_dondathangphanxuong_vattu_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_dondathangphanxuong_vattu>().HasKey<string>(p => p.md_dondathangphanxuong_vattu_id);
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.md_dondathangphanxuong_cdh_id)
                            .HasColumnName("md_dondathangphanxuong_cdh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.md_dondathangphanxuong_id)
                            .HasColumnName("md_dondathangphanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.mota_tienganh)
                            .HasColumnName("mota_tienganh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.mota_tiengviet)
                            .HasColumnName("mota_tiengviet")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.sl_hanngach)
                            .HasColumnName("sl_hanngach")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_dongtien>().ToTable("md_dongtien");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.md_dongtien_id)
                            .HasColumnName("md_dongtien_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_dongtien>().HasKey<string>(p => p.md_dongtien_id);
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.bieutuong)
                            .HasColumnName("bieutuong")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.ma_iso)
                            .HasColumnName("ma_iso")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_donvitinh>().ToTable("md_donvitinh");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.md_donvitinh_id)
                            .HasColumnName("md_donvitinh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_donvitinh>().HasKey<string>(p => p.md_donvitinh_id);
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.ma_edi)
                            .HasColumnName("ma_edi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.ten_dvt)
                            .HasColumnName("ten_dvt")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_donvitinhsanpham>().ToTable("md_donvitinhsanpham");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_donvitinhsanpham>().HasKey<string>(p => p.md_donvitinhsanpham_id);
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.ma_edi)
                            .HasColumnName("ma_edi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.ten_dvt)
                            .HasColumnName("ten_dvt")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_donvitinhsanpham_cddv>().ToTable("md_donvitinhsanpham_cddv");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.md_donvitinhsanpham_cddv_id)
                            .HasColumnName("md_donvitinhsanpham_cddv_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_donvitinhsanpham_cddv>().HasKey<string>(p => p.md_donvitinhsanpham_cddv_id);
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.chiacho)
                            .HasColumnName("chiacho")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.md_dvtsp_id)
                            .HasColumnName("md_dvtsp_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.nhanvoi)
                            .HasColumnName("nhanvoi")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.saiso_toida)
                            .HasColumnName("saiso_toida")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_giasanpham>().ToTable("md_giasanpham");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.md_giasanpham_id)
                            .HasColumnName("md_giasanpham_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_giasanpham>().HasKey<string>(p => p.md_giasanpham_id);
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.gia)
                            .HasColumnName("gia")
                            .HasColumnType("numeric").HasPrecision(18, 8);
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.md_banggia_id)
                            .HasColumnName("md_banggia_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.md_phienbangia_id)
                            .HasColumnName("md_phienbangia_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_giasanpham_giaodich>().ToTable("md_giasanpham_giaodich");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.md_giasanpham_giaodich_id)
                            .HasColumnName("md_giasanpham_giaodich_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_giasanpham_giaodich>().HasKey<string>(p => p.md_giasanpham_giaodich_id);
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.giacu)
                            .HasColumnName("giacu")
                            .HasColumnType("numeric").HasPrecision(18, 8);
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.giamoi)
                            .HasColumnName("giamoi")
                            .HasColumnType("numeric").HasPrecision(18, 8);
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.md_banggia_id)
                            .HasColumnName("md_banggia_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.md_giasanpham_id)
                            .HasColumnName("md_giasanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.md_phienbangia_id)
                            .HasColumnName("md_phienbangia_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.ngaydenghi)
                            .HasColumnName("ngaydenghi")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.ngayduyet)
                            .HasColumnName("ngayduyet")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.sapxepso)
                            .HasColumnName("sapxepso")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngach>().ToTable("md_hanngach");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.md_hanngach_id)
                            .HasColumnName("md_hanngach_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngach>().HasKey<string>(p => p.md_hanngach_id);
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.c_danhsachdathang_id)
                            .HasColumnName("c_danhsachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.ngayduyet)
                            .HasColumnName("ngayduyet")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.ngayhieuluc)
                            .HasColumnName("ngayhieuluc")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.ngaytrinh)
                            .HasColumnName("ngaytrinh")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.ngayxacnhan)
                            .HasColumnName("ngayxacnhan")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngach_chitiet>().ToTable("md_hanngach_chitiet");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.md_hanngach_chitiet_id)
                            .HasColumnName("md_hanngach_chitiet_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngach_chitiet>().HasKey<string>(p => p.md_hanngach_chitiet_id);
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.md_hanngach_id)
                            .HasColumnName("md_hanngach_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.sanpham_value)
                            .HasColumnName("sanpham_value")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.sldonhang)
                            .HasColumnName("sldonhang")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.slgiam)
                            .HasColumnName("slgiam")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngachPXTo>().ToTable("md_hanngachPXTo");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.md_hanngachPXTo_id)
                            .HasColumnName("md_hanngachPXTo_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngachPXTo>().HasKey<string>(p => p.md_hanngachPXTo_id);
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.lsxtsxId)
                            .HasColumnName("lsxtsxId")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.md_dondathangphanxuong_id)
                            .HasColumnName("md_dondathangphanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.md_hanngach_id)
                            .HasColumnName("md_hanngach_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.ngayduyet)
                            .HasColumnName("ngayduyet")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.ngaytrinh)
                            .HasColumnName("ngaytrinh")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.pxtoId)
                            .HasColumnName("pxtoId")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.ten_phanxuong)
                            .HasColumnName("ten_phanxuong")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.ten_to)
                            .HasColumnName("ten_to")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngachPXTo_chitiet>().ToTable("md_hanngachPXTo_chitiet");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.md_hanngachPXTo_chitiet_id)
                            .HasColumnName("md_hanngachPXTo_chitiet_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngachPXTo_chitiet>().HasKey<string>(p => p.md_hanngachPXTo_chitiet_id);
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.md_hanngachPXTo_id)
                            .HasColumnName("md_hanngachPXTo_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.sanpham_value)
                            .HasColumnName("sanpham_value")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.slcansanxuat)
                            .HasColumnName("slcansanxuat")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.slgiam)
                            .HasColumnName("slgiam")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.slgioihan)
                            .HasColumnName("slgioihan")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.slkhoton)
                            .HasColumnName("slkhoton")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.sllayton)
                            .HasColumnName("sllayton")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.sllaytonTP)
                            .HasColumnName("sllaytonTP")
                            .HasColumnType("int");
modelBuilder.Entity<md_hanngachPXTo_chitiet2>().ToTable("md_hanngachPXTo_chitiet2");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.md_hanngachPXTo_chitiet2_id)
                            .HasColumnName("md_hanngachPXTo_chitiet2_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngachPXTo_chitiet2>().HasKey<string>(p => p.md_hanngachPXTo_chitiet2_id);
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.md_hanngachPXTo_id)
                            .HasColumnName("md_hanngachPXTo_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.sanpham_value)
                            .HasColumnName("sanpham_value")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.slcansanxuat)
                            .HasColumnName("slcansanxuat")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.slgiam)
                            .HasColumnName("slgiam")
                            .HasColumnType("int");
modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>().ToTable("md_hanngachPXTo_chuyenvekhoton");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.md_hanngachPXTo_chuyenvekhoton_id)
                            .HasColumnName("md_hanngachPXTo_chuyenvekhoton_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>().HasKey<string>(p => p.md_hanngachPXTo_chuyenvekhoton_id);
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.md_hanngachPXTo_chitiet_id)
                            .HasColumnName("md_hanngachPXTo_chitiet_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.md_hanngachPXTo_id)
                            .HasColumnName("md_hanngachPXTo_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.slchuyen)
                            .HasColumnName("slchuyen")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.sldachuyen)
                            .HasColumnName("sldachuyen")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.sldagiao)
                            .HasColumnName("sldagiao")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.sldanhan)
                            .HasColumnName("sldanhan")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.sltoida)
                            .HasColumnName("sltoida")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.stt)
                            .HasColumnName("stt")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.toId)
                            .HasColumnName("toId")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngachPXTo_chuyenvekhoton>()
                            .Property(p => p.tosxId)
                            .HasColumnName("tosxId")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hinhthucthanhtoan>().ToTable("md_hinhthucthanhtoan");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.md_hinhthucthanhtoan_id)
                            .HasColumnName("md_hinhthucthanhtoan_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_hinhthucthanhtoan>().HasKey<string>(p => p.md_hinhthucthanhtoan_id);
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.ten)
                            .HasColumnName("ten")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hinhthucthanhtoan>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hoadon>().ToTable("md_hoadon");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.md_hoadon_id)
                            .HasColumnName("md_hoadon_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hoadon>().HasKey<string>(p => p.md_hoadon_id);
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.chu_tong_tatca)
                            .HasColumnName("chu_tong_tatca")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.diachi)
                            .HasColumnName("diachi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.maso)
                            .HasColumnName("maso")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.masothue)
                            .HasColumnName("masothue")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.md_trangthai_id)
                            .HasColumnName("md_trangthai_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.ngaylap)
                            .HasColumnName("ngaylap")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.phieunhapkho)
                            .HasColumnName("phieunhapkho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.sct_thamchieu)
                            .HasColumnName("sct_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.so_taikhoan)
                            .HasColumnName("so_taikhoan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.tel)
                            .HasColumnName("tel")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.tong_tatca)
                            .HasColumnName("tong_tatca")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.tong_tienhang)
                            .HasColumnName("tong_tienhang")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.tong_vat)
                            .HasColumnName("tong_vat")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.vat)
                            .HasColumnName("vat")
                            .HasColumnType("int");
modelBuilder.Entity<md_hoadon_chitiet>().ToTable("md_hoadon_chitiet");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.md_hoadon_chitiet_id)
                            .HasColumnName("md_hoadon_chitiet_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hoadon_chitiet>().HasKey<string>(p => p.md_hoadon_chitiet_id);
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.dongiamua)
                            .HasColumnName("dongiamua")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.md_hoadon_id)
                            .HasColumnName("md_hoadon_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.thanhtien)
                            .HasColumnName("thanhtien")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.tong_tatca)
                            .HasColumnName("tong_tatca")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.tong_vat)
                            .HasColumnName("tong_vat")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.vat)
                            .HasColumnName("vat")
                            .HasColumnType("int");
modelBuilder.Entity<md_kho>().ToTable("md_kho");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_kho>().HasKey<string>(p => p.md_kho_id);
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.diachi_kho)
                            .HasColumnName("diachi_kho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.hangton)
                            .HasColumnName("hangton")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.ma_kho)
                            .HasColumnName("ma_kho")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.phongbanId)
                            .HasColumnName("phongbanId")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.ten_kho)
                            .HasColumnName("ten_kho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho>()
                            .Property(p => p.vattu)
                            .HasColumnName("vattu")
                            .HasColumnType("bit");
modelBuilder.Entity<md_kho_dasudung>().ToTable("md_kho_dasudung");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.md_kho_dasudung_id)
                            .HasColumnName("md_kho_dasudung_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_kho_dasudung>().HasKey<string>(p => p.md_kho_dasudung_id);
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.lsx_to)
                            .HasColumnName("lsx_to")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.lydo)
                            .HasColumnName("lydo")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.ngaydung)
                            .HasColumnName("ngaydung")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.sctlienquan)
                            .HasColumnName("sctlienquan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.soluong_dadung)
                            .HasColumnName("soluong_dadung")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.soluong_dadung2)
                            .HasColumnName("soluong_dadung2")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.tosx)
                            .HasColumnName("tosx")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_dasudung>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                    
            #endregion End Code
        }
    }
}
