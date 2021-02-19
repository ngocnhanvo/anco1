
using System.Data.Entity;
namespace DataAcess
{
    public class EntityContext07table
    {
        public void exec(DbModelBuilder modelBuilder)
        {
            #region Start Code
            modelBuilder.Entity<md_sanpham>().ToTable("md_sanpham");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.ban_thanhpham)
                            .HasColumnName("ban_thanhpham")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.co_ngayhethan)
                            .HasColumnName("co_ngayhethan")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.dientich)
                            .HasColumnName("dientich")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.dinhkhoan)
                            .HasColumnName("dinhkhoan")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.dokho)
                            .HasColumnName("dokho")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.ghichu)
                            .HasColumnName("ghichu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.giabinhquan)
                            .HasColumnName("giabinhquan")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.h_cm)
                            .HasColumnName("h_cm")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.h_inch)
                            .HasColumnName("h_inch")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.heso)
                            .HasColumnName("heso")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.khomacdinh)
                            .HasColumnName("khomacdinh")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.khoton)
                            .HasColumnName("khoton")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.khuon)
                            .HasColumnName("khuon")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.l_cm)
                            .HasColumnName("l_cm")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.l_inch)
                            .HasColumnName("l_inch")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.ma_sanpham)
                            .HasColumnName("ma_sanpham")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.ma_sanphamcu)
                            .HasColumnName("ma_sanphamcu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.ma_vach)
                            .HasColumnName("ma_vach")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.md_cangbien_id)
                            .HasColumnName("md_cangbien_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.md_chucnang_id)
                            .HasColumnName("md_chucnang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.md_chungloai_id)
                            .HasColumnName("md_chungloai_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.md_hscode_id)
                            .HasColumnName("md_hscode_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.md_kieudang_id)
                            .HasColumnName("md_kieudang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.md_nhomnangluc_id)
                            .HasColumnName("md_nhomnangluc_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.md_phanloaihh_id)
                            .HasColumnName("md_phanloaihh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_sanpham>().HasKey<string>(p => p.md_sanpham_id);
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.md_thue_sanpham_id)
                            .HasColumnName("md_thue_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.mota_tienganh)
                            .HasColumnName("mota_tienganh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.mota_tiengviet)
                            .HasColumnName("mota_tiengviet")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.muangoai)
                            .HasColumnName("muangoai")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.nhacungung)
                            .HasColumnName("nhacungung")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.noigiaohang)
                            .HasColumnName("noigiaohang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.quycachdonggoi)
                            .HasColumnName("quycachdonggoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.sanpham)
                            .HasColumnName("sanpham")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.sl_tonkho_toithieu)
                            .HasColumnName("sl_tonkho_toithieu")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.son)
                            .HasColumnName("son")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.trongluong)
                            .HasColumnName("trongluong")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.v2)
                            .HasColumnName("v2")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.vattu)
                            .HasColumnName("vattu")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.w_cm)
                            .HasColumnName("w_cm")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.w_inch)
                            .HasColumnName("w_inch")
                            .HasColumnType("numeric").HasPrecision(18, 4);
modelBuilder.Entity<md_sanpham_bom>().ToTable("md_sanpham_bom");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.bom_donggoi)
                            .HasColumnName("bom_donggoi")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.bom_tam)
                            .HasColumnName("bom_tam")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.md_sanpham_bom_id)
                            .HasColumnName("md_sanpham_bom_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_sanpham_bom>().HasKey<string>(p => p.md_sanpham_bom_id);
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.ngay_hieuluc)
                            .HasColumnName("ngay_hieuluc")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("float");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.ten_phienban)
                            .HasColumnName("ten_phienban")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_sanpham_bom_vattu>().ToTable("md_sanpham_bom_vattu");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.md_sanpham_bom_id)
                            .HasColumnName("md_sanpham_bom_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.md_sanpham_bom_vattu_id)
                            .HasColumnName("md_sanpham_bom_vattu_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_sanpham_bom_vattu>().HasKey<string>(p => p.md_sanpham_bom_vattu_id);
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.sanphamId)
                            .HasColumnName("sanphamId")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("float");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.tam)
                            .HasColumnName("tam")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham_bom_vattu>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_sanphamhinhdang>().ToTable("md_sanphamhinhdang");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.ma_hinhdang)
                            .HasColumnName("ma_hinhdang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.md_sanphamhinhdang_id)
                            .HasColumnName("md_sanphamhinhdang_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_sanphamhinhdang>().HasKey<string>(p => p.md_sanphamhinhdang_id);
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.ten_hinhdang)
                            .HasColumnName("ten_hinhdang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphamhinhdang>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_sanphammausac>().ToTable("md_sanphammausac");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.ma_mausac)
                            .HasColumnName("ma_mausac")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.md_sanphammausac_id)
                            .HasColumnName("md_sanphammausac_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_sanphammausac>().HasKey<string>(p => p.md_sanphammausac_id);
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.ten_mausac)
                            .HasColumnName("ten_mausac")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_sanphammausac_phatron>().ToTable("md_sanphammausac_phatron");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.md_sanphammausac_id)
                            .HasColumnName("md_sanphammausac_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.md_sanphammausac_phatron_id)
                            .HasColumnName("md_sanphammausac_phatron_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_sanphammausac_phatron>().HasKey<string>(p => p.md_sanphammausac_phatron_id);
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.tile)
                            .HasColumnName("tile")
                            .HasColumnType("float");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanphammausac_phatron>()
                            .Property(p => p.vattu_value)
                            .HasColumnName("vattu_value")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_sochungtu>().ToTable("md_sochungtu");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.buocnhay)
                            .HasColumnName("buocnhay")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.giatri_namtruoc)
                            .HasColumnName("giatri_namtruoc")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.giatri_thaydoi)
                            .HasColumnName("giatri_thaydoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.khuonmau)
                            .HasColumnName("khuonmau")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.ma_sochungtu)
                            .HasColumnName("ma_sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.mau_hienthi)
                            .HasColumnName("mau_hienthi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.md_sochungtu_id)
                            .HasColumnName("md_sochungtu_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_sochungtu>().HasKey<string>(p => p.md_sochungtu_id);
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.md_trangthai_id)
                            .HasColumnName("md_trangthai_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.namnay)
                            .HasColumnName("namnay")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.namtruoc)
                            .HasColumnName("namtruoc")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.object_id)
                            .HasColumnName("object_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.ten_sochungtu)
                            .HasColumnName("ten_sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtu>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_sochungtudaxoa>().ToTable("md_sochungtudaxoa");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.md_sochungtudaxoa_id)
                            .HasColumnName("md_sochungtudaxoa_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_sochungtudaxoa>().HasKey<string>(p => p.md_sochungtudaxoa_id);
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.value)
                            .HasColumnName("value")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sochungtudaxoa>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_taphopgia>().ToTable("md_taphopgia");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.denngay)
                            .HasColumnName("denngay")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.ma_taphop)
                            .HasColumnName("ma_taphop")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.md_namtaichinh_ky_id)
                            .HasColumnName("md_namtaichinh_ky_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.md_taphopgia_id)
                            .HasColumnName("md_taphopgia_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_taphopgia>().HasKey<string>(p => p.md_taphopgia_id);
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.md_trangthai_id)
                            .HasColumnName("md_trangthai_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.nam)
                            .HasColumnName("nam")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.soky)
                            .HasColumnName("soky")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.ten_taphop)
                            .HasColumnName("ten_taphop")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.tungay)
                            .HasColumnName("tungay")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_taphopgia_cdh>().ToTable("md_taphopgia_cdh");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.gia)
                            .HasColumnName("gia")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.md_banggia_id)
                            .HasColumnName("md_banggia_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.md_dongtien_id)
                            .HasColumnName("md_dongtien_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.md_phienbangia_id)
                            .HasColumnName("md_phienbangia_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.md_taphopgia_cdh_id)
                            .HasColumnName("md_taphopgia_cdh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_taphopgia_cdh>().HasKey<string>(p => p.md_taphopgia_cdh_id);
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.md_taphopgia_id)
                            .HasColumnName("md_taphopgia_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.ngay_pbghl)
                            .HasColumnName("ngay_pbghl")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.quydoi)
                            .HasColumnName("quydoi")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.tygia)
                            .HasColumnName("tygia")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taphopgia_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_taptin>().ToTable("md_taptin");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.doituong_dinhkem)
                            .HasColumnName("doituong_dinhkem")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.md_taptin_id)
                            .HasColumnName("md_taptin_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_taptin>().HasKey<string>(p => p.md_taptin_id);
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.mimetype)
                            .HasColumnName("mimetype")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.path)
                            .HasColumnName("path")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.size)
                            .HasColumnName("size")
                            .HasColumnType("bigint");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.tentaptin)
                            .HasColumnName("tentaptin")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_taptin>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_thongbao>().ToTable("md_thongbao");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.ma_thongbao)
                            .HasColumnName("ma_thongbao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.md_thongbao_id)
                            .HasColumnName("md_thongbao_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_thongbao>().HasKey<string>(p => p.md_thongbao_id);
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.nguoinhan)
                            .HasColumnName("nguoinhan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.noidung)
                            .HasColumnName("noidung")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.tieude)
                            .HasColumnName("tieude")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_thongbao>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_thue_sanpham>().ToTable("md_thue_sanpham");
                            modelBuilder.Entity<md_thue_sanpham>()
                            .Property(p => p.giatri)
                            .HasColumnName("giatri")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_thue_sanpham>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_thue_sanpham>()
                            .Property(p => p.macdinh)
                            .HasColumnName("macdinh")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_thue_sanpham>()
                            .Property(p => p.md_thue_sanpham_id)
                            .HasColumnName("md_thue_sanpham_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_thue_sanpham>().HasKey<string>(p => p.md_thue_sanpham_id);
                            modelBuilder.Entity<md_thue_sanpham>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_thue_sanpham>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_thue_sanpham>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_thue_sanpham>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_thue_sanpham>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_thue_sanpham>()
                            .Property(p => p.ten_thue_sanpham)
                            .HasColumnName("ten_thue_sanpham")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_tonghopcongno>().ToTable("md_tonghopcongno");
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.cocuoiky)
                            .HasColumnName("cocuoiky")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.cocuoiky_usd)
                            .HasColumnName("cocuoiky_usd")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.codauky)
                            .HasColumnName("codauky")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.codauky_usd)
                            .HasColumnName("codauky_usd")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.cotrongky)
                            .HasColumnName("cotrongky")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.cotrongky_usd)
                            .HasColumnName("cotrongky_usd")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.iskh)
                            .HasColumnName("iskh")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.isncc)
                            .HasColumnName("isncc")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.ma_dtkd)
                            .HasColumnName("ma_dtkd")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.md_namtaichinh_id)
                            .HasColumnName("md_namtaichinh_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.md_namtaichinh_ky_id)
                            .HasColumnName("md_namtaichinh_ky_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.md_tonghopcongno_id)
                            .HasColumnName("md_tonghopcongno_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_tonghopcongno>().HasKey<string>(p => p.md_tonghopcongno_id);
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.nam)
                            .HasColumnName("nam")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.nocuoiky)
                            .HasColumnName("nocuoiky")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.nocuoiky_usd)
                            .HasColumnName("nocuoiky_usd")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.nodauky)
                            .HasColumnName("nodauky")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.nodauky_usd)
                            .HasColumnName("nodauky_usd")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.notrongky)
                            .HasColumnName("notrongky")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.notrongky_usd)
                            .HasColumnName("notrongky_usd")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.soky)
                            .HasColumnName("soky")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.ten_dtkd)
                            .HasColumnName("ten_dtkd")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tonghopcongno>()
                            .Property(p => p.tygia)
                            .HasColumnName("tygia")
                            .HasColumnType("decimal").HasPrecision(18, 4);
modelBuilder.Entity<md_tonghopkho>().ToTable("md_tonghopkho");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.ma_sanpham)
                            .HasColumnName("ma_sanpham")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.md_namtaichinh_id)
                            .HasColumnName("md_namtaichinh_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.md_namtaichinh_ky_id)
                            .HasColumnName("md_namtaichinh_ky_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.md_tonghopkho_id)
                            .HasColumnName("md_tonghopkho_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_tonghopkho>().HasKey<string>(p => p.md_tonghopkho_id);
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.nam)
                            .HasColumnName("nam")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.sl_cuoiky)
                            .HasColumnName("sl_cuoiky")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.sl_dauky)
                            .HasColumnName("sl_dauky")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.sl_nhaptrongky)
                            .HasColumnName("sl_nhaptrongky")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.sl_xuattrongky)
                            .HasColumnName("sl_xuattrongky")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.soky)
                            .HasColumnName("soky")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tonghopkho>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_tygia>().ToTable("md_tygia");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.chia_cho)
                            .HasColumnName("chia_cho")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.hieuluc_denngay)
                            .HasColumnName("hieuluc_denngay")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.hieuluc_tungay)
                            .HasColumnName("hieuluc_tungay")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.md_tygia_id)
                            .HasColumnName("md_tygia_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_tygia>().HasKey<string>(p => p.md_tygia_id);
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.nhan_voi)
                            .HasColumnName("nhan_voi")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.sang_dongtien_id)
                            .HasColumnName("sang_dongtien_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.ten_tygia)
                            .HasColumnName("ten_tygia")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.tu_dongtien_id)
                            .HasColumnName("tu_dongtien_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_vanchuyennoibo>().ToTable("md_vanchuyennoibo");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.banggiaNC)
                            .HasColumnName("banggiaNC")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.c_doichieuhangton_id)
                            .HasColumnName("c_doichieuhangton_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.chungtu_lenhsx)
                            .HasColumnName("chungtu_lenhsx")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.chungtuthamchieu)
                            .HasColumnName("chungtuthamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.denkho)
                            .HasColumnName("denkho")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.ketoan)
                            .HasColumnName("ketoan")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.loaichuyen)
                            .HasColumnName("loaichuyen")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.loaichuyen_id)
                            .HasColumnName("loaichuyen_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.loaiphieuHN)
                            .HasColumnName("loaiphieuHN")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.md_lenhsanxuat_tosx_id)
                            .HasColumnName("md_lenhsanxuat_tosx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.md_trangthai_id)
                            .HasColumnName("md_trangthai_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.md_vanchuyennoibo_id)
                            .HasColumnName("md_vanchuyennoibo_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_vanchuyennoibo>().HasKey<string>(p => p.md_vanchuyennoibo_id);
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.ngaychuyen)
                            .HasColumnName("ngaychuyen")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.ngaydenghi)
                            .HasColumnName("ngaydenghi")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.ngayhieuluc)
                            .HasColumnName("ngayhieuluc")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.phienbangiaNC)
                            .HasColumnName("phienbangiaNC")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.phieugiamHN)
                            .HasColumnName("phieugiamHN")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.tiencongDG)
                            .HasColumnName("tiencongDG")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.tukho)
                            .HasColumnName("tukho")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_vanchuyennoibo_cdvc>().ToTable("md_vanchuyennoibo_cdvc");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.chuyenton)
                            .HasColumnName("chuyenton")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.dachuyenhet)
                            .HasColumnName("dachuyenhet")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.denkho)
                            .HasColumnName("denkho")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.dento)
                            .HasColumnName("dento")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.gianhancong)
                            .HasColumnName("gianhancong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.lsx_to)
                            .HasColumnName("lsx_to")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.lsxId)
                            .HasColumnName("lsxId")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.ma_tukho)
                            .HasColumnName("ma_tukho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.md_vanchuyennoibo_cdvc_id)
                            .HasColumnName("md_vanchuyennoibo_cdvc_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_vanchuyennoibo_cdvc>().HasKey<string>(p => p.md_vanchuyennoibo_cdvc_id);
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.md_vanchuyennoibo_id)
                            .HasColumnName("md_vanchuyennoibo_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.ngay_hethan)
                            .HasColumnName("ngay_hethan")
                            .HasColumnType("date");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.soluong_dachuyen)
                            .HasColumnName("soluong_dachuyen")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.soluong_dichchuyen)
                            .HasColumnName("soluong_dichchuyen")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.soluong_muonchuyen)
                            .HasColumnName("soluong_muonchuyen")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.soluong_toida)
                            .HasColumnName("soluong_toida")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.tenhang)
                            .HasColumnName("tenhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.tukho)
                            .HasColumnName("tukho")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.tuto)
                            .HasColumnName("tuto")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_vanchuyennoibo_dalayton>().ToTable("md_vanchuyennoibo_dalayton");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.gianhancong)
                            .HasColumnName("gianhancong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.lsx)
                            .HasColumnName("lsx")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.md_vanchuyennoibo_dalayton_id)
                            .HasColumnName("md_vanchuyennoibo_dalayton_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_vanchuyennoibo_dalayton>().HasKey<string>(p => p.md_vanchuyennoibo_dalayton_id);
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.md_vanchuyennoibo_id)
                            .HasColumnName("md_vanchuyennoibo_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.sldalay)
                            .HasColumnName("sldalay")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.soluong_layton)
                            .HasColumnName("soluong_layton")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.tongsoluong)
                            .HasColumnName("tongsoluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.tosx)
                            .HasColumnName("tosx")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo_dalayton>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_vattukhoan>().ToTable("md_vattukhoan");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.md_vattukhoan_id)
                            .HasColumnName("md_vattukhoan_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_vattukhoan>().HasKey<string>(p => p.md_vattukhoan_id);
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.nam)
                            .HasColumnName("nam")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.thang)
                            .HasColumnName("thang")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.tienvtkhoan)
                            .HasColumnName("tienvtkhoan")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.tienvtvipham)
                            .HasColumnName("tienvtvipham")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattukhoan>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                    
            #endregion End Code
        }
    }
}
