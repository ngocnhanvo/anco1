
using System.Data.Entity;
namespace DataAcess
{
    public class EntityContext04table
    {
        public void exec(DbModelBuilder modelBuilder)
        {
            #region Start Code
            modelBuilder.Entity<md_donvitinhsanpham_cddv>().ToTable("md_donvitinhsanpham_cddv");
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
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.md_donvitinhsanpham_cddv_id)
                            .HasColumnName("md_donvitinhsanpham_cddv_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_donvitinhsanpham_cddv>().HasKey<string>(p => p.md_donvitinhsanpham_cddv_id);
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
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_donvitinhsanpham_cddv>()
                            .Property(p => p.saiso_toida)
                            .HasColumnName("saiso_toida")
                            .HasColumnType("decimal").HasPrecision(18, 4);
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
                            .Property(p => p.gia)
                            .HasColumnName("gia")
                            .HasColumnType("numeric").HasPrecision(18, 4);
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
                            .Property(p => p.md_giasanpham_id)
                            .HasColumnName("md_giasanpham_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_giasanpham>().HasKey<string>(p => p.md_giasanpham_id);
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
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_giasanpham>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngach>().ToTable("md_hanngach");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.c_danhsachdathang_id)
                            .HasColumnName("c_danhsachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.md_hanngach_id)
                            .HasColumnName("md_hanngach_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngach>().HasKey<string>(p => p.md_hanngach_id);
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
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.ngaytrinh)
                            .HasColumnName("ngaytrinh")
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
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_hanngach>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngach_chitiet>().ToTable("md_hanngach_chitiet");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.md_hanngach_chitiet_id)
                            .HasColumnName("md_hanngach_chitiet_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngach_chitiet>().HasKey<string>(p => p.md_hanngach_chitiet_id);
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
                            .HasColumnType("int");
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.slgiam)
                            .HasColumnName("slgiam")
                            .HasColumnType("int");
modelBuilder.Entity<md_hanngachPXTo>().ToTable("md_hanngachPXTo");
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
                            .Property(p => p.md_hanngachPXTo_id)
                            .HasColumnName("md_hanngachPXTo_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngachPXTo>().HasKey<string>(p => p.md_hanngachPXTo_id);
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
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
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
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet>()
                            .Property(p => p.md_hanngachPXTo_chitiet_id)
                            .HasColumnName("md_hanngachPXTo_chitiet_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngachPXTo_chitiet>().HasKey<string>(p => p.md_hanngachPXTo_chitiet_id);
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
modelBuilder.Entity<md_hanngachPXTo_chitiet2>().ToTable("md_hanngachPXTo_chitiet2");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hanngachPXTo_chitiet2>()
                            .Property(p => p.md_hanngachPXTo_chitiet2_id)
                            .HasColumnName("md_hanngachPXTo_chitiet2_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hanngachPXTo_chitiet2>().HasKey<string>(p => p.md_hanngachPXTo_chitiet2_id);
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
modelBuilder.Entity<md_hinhthucthanhtoan>().ToTable("md_hinhthucthanhtoan");
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
                            .Property(p => p.md_hinhthucthanhtoan_id)
                            .HasColumnName("md_hinhthucthanhtoan_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_hinhthucthanhtoan>().HasKey<string>(p => p.md_hinhthucthanhtoan_id);
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
                            .Property(p => p.md_hoadon_id)
                            .HasColumnName("md_hoadon_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hoadon>().HasKey<string>(p => p.md_hoadon_id);
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
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.tong_tienhang)
                            .HasColumnName("tong_tienhang")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_hoadon>()
                            .Property(p => p.tong_vat)
                            .HasColumnName("tong_vat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
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
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.md_hoadon_chitiet_id)
                            .HasColumnName("md_hoadon_chitiet_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_hoadon_chitiet>().HasKey<string>(p => p.md_hoadon_chitiet_id);
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
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.thanhtien)
                            .HasColumnName("thanhtien")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.tong_tatca)
                            .HasColumnName("tong_tatca")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_hoadon_chitiet>()
                            .Property(p => p.tong_vat)
                            .HasColumnName("tong_vat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
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
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_kho>().HasKey<string>(p => p.md_kho_id);
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
modelBuilder.Entity<md_kho_ghino>().ToTable("md_kho_ghino");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.lsx_to)
                            .HasColumnName("lsx_to")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.lydo)
                            .HasColumnName("lydo")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.md_kho_ghino_id)
                            .HasColumnName("md_kho_ghino_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_kho_ghino>().HasKey<string>(p => p.md_kho_ghino_id);
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.ngayno)
                            .HasColumnName("ngayno")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.sctlienquan)
                            .HasColumnName("sctlienquan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.soluong_no)
                            .HasColumnName("soluong_no")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.tosx)
                            .HasColumnName("tosx")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_ghino>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_kho_giaodich>().ToTable("md_kho_giaodich");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.dongkiemkho)
                            .HasColumnName("dongkiemkho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.dongnhapxuat)
                            .HasColumnName("dongnhapxuat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.dongsanxuat)
                            .HasColumnName("dongsanxuat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.dongvanchuyen)
                            .HasColumnName("dongvanchuyen")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.giatriVND)
                            .HasColumnName("giatriVND")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.kieuchuyen)
                            .HasColumnName("kieuchuyen")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.md_kho_giaodich_id)
                            .HasColumnName("md_kho_giaodich_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_kho_giaodich>().HasKey<string>(p => p.md_kho_giaodich_id);
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.ngaychuyen)
                            .HasColumnName("ngaychuyen")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.soluong_dichchuyen)
                            .HasColumnName("soluong_dichchuyen")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giaodich>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_kho_giucho>().ToTable("md_kho_giucho");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.lydo)
                            .HasColumnName("lydo")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.md_kho_giucho_id)
                            .HasColumnName("md_kho_giucho_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_kho_giucho>().HasKey<string>(p => p.md_kho_giucho_id);
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.ngaygiu)
                            .HasColumnName("ngaygiu")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.sctlienquan)
                            .HasColumnName("sctlienquan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.soluong_giucho)
                            .HasColumnName("soluong_giucho")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_giucho>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_kho_sanpham>().ToTable("md_kho_sanpham");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.md_kho_sanpham_id)
                            .HasColumnName("md_kho_sanpham_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_kho_sanpham>().HasKey<string>(p => p.md_kho_sanpham_id);
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.ngay_hethan)
                            .HasColumnName("ngay_hethan")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.ngaytinh_tonkhocuoi)
                            .HasColumnName("ngaytinh_tonkhocuoi")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_sanpham>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_kho_sanpham_hansudung>().ToTable("md_kho_sanpham_hansudung");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.md_kho_sanpham_hansudung_id)
                            .HasColumnName("md_kho_sanpham_hansudung_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_kho_sanpham_hansudung>().HasKey<string>(p => p.md_kho_sanpham_hansudung_id);
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.md_kho_sanpham_id)
                            .HasColumnName("md_kho_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.ngay_hethan)
                            .HasColumnName("ngay_hethan")
                            .HasColumnType("date");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_kho_sanpham_hansudung>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
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
                    
                    
            #endregion End Code
        }
    }
}
