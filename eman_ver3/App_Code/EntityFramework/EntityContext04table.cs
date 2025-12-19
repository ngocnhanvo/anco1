
using System.Data.Entity;
namespace DataAcess
{
    public class EntityContext04table
    {
        public void exec(DbModelBuilder modelBuilder)
        {
            #region Start Code
            modelBuilder.Entity<md_dieukienthanhtoan>().ToTable("md_dieukienthanhtoan");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.md_dieukienthanhtoan_id)
                            .HasColumnName("md_dieukienthanhtoan_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_dieukienthanhtoan>().HasKey<string>(p => p.md_dieukienthanhtoan_id);
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.ma_dieukien)
                            .HasColumnName("ma_dieukien")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.ten_dieukien)
                            .HasColumnName("ten_dieukien")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dieukienthanhtoan>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_doikhodoingay>().ToTable("md_doikhodoingay");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.md_doikhodoingay_id)
                            .HasColumnName("md_doikhodoingay_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_doikhodoingay>().HasKey<string>(p => p.md_doikhodoingay_id);
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.donhang)
                            .HasColumnName("donhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.id_lienquan)
                            .HasColumnName("id_lienquan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.khocu)
                            .HasColumnName("khocu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.khomoi)
                            .HasColumnName("khomoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.loai)
                            .HasColumnName("loai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.ngaycu)
                            .HasColumnName("ngaycu")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.ngayhieuluc)
                            .HasColumnName("ngayhieuluc")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.ngaymoi)
                            .HasColumnName("ngaymoi")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.ngayxacnhan)
                            .HasColumnName("ngayxacnhan")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.sct_lienquan)
                            .HasColumnName("sct_lienquan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_doikhodoingay_cdh>().ToTable("md_doikhodoingay_cdh");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.md_doikhodoingay_cdh_id)
                            .HasColumnName("md_doikhodoingay_cdh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_doikhodoingay_cdh>().HasKey<string>(p => p.md_doikhodoingay_cdh_id);
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.md_doikhodoingay_id)
                            .HasColumnName("md_doikhodoingay_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.soluong_dichchuyen)
                            .HasColumnName("soluong_dichchuyen")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.soluong_muonchuyen)
                            .HasColumnName("soluong_muonchuyen")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.soluong_toida)
                            .HasColumnName("soluong_toida")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doikhodoingay_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_doimaudodang>().ToTable("md_doimaudodang");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.md_doimaudodang_id)
                            .HasColumnName("md_doimaudodang_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_doimaudodang>().HasKey<string>(p => p.md_doimaudodang_id);
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.denkho)
                            .HasColumnName("denkho")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.ketoan)
                            .HasColumnName("ketoan")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.ngaychuyen)
                            .HasColumnName("ngaychuyen")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.tukho)
                            .HasColumnName("tukho")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_doimaudodang_dh>().ToTable("md_doimaudodang_dh");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.md_doimaudodang_dh_id)
                            .HasColumnName("md_doimaudodang_dh_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_doimaudodang_dh>().HasKey<string>(p => p.md_doimaudodang_dh_id);
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.md_doimaudodang_id)
                            .HasColumnName("md_doimaudodang_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.soluong_dachuyen)
                            .HasColumnName("soluong_dachuyen")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.soluong_dichchuyen)
                            .HasColumnName("soluong_dichchuyen")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.soluong_muonchuyen)
                            .HasColumnName("soluong_muonchuyen")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.soluong_toida)
                            .HasColumnName("soluong_toida")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.spcandoi)
                            .HasColumnName("spcandoi")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.spsedoi)
                            .HasColumnName("spsedoi")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_doitackinhdoanh>().ToTable("md_doitackinhdoanh");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_doitackinhdoanh>().HasKey<string>(p => p.md_doitackinhdoanh_id);
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.chucvu)
                            .HasColumnName("chucvu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.daidien)
                            .HasColumnName("daidien")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.diachi)
                            .HasColumnName("diachi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.email)
                            .HasColumnName("email")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.fax)
                            .HasColumnName("fax")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.isdocquyen)
                            .HasColumnName("isdocquyen")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.islienhe)
                            .HasColumnName("islienhe")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.isncc)
                            .HasColumnName("isncc")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.ma_dtkd)
                            .HasColumnName("ma_dtkd")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.masothue)
                            .HasColumnName("masothue")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.md_banggia_id)
                            .HasColumnName("md_banggia_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.md_cangbien_id)
                            .HasColumnName("md_cangbien_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.md_khuvuc_id)
                            .HasColumnName("md_khuvuc_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.md_loaidtkd_id)
                            .HasColumnName("md_loaidtkd_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.md_quocgia_id)
                            .HasColumnName("md_quocgia_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.nganhang)
                            .HasColumnName("nganhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.so_taikhoan)
                            .HasColumnName("so_taikhoan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.tel)
                            .HasColumnName("tel")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.ten_dtkd)
                            .HasColumnName("ten_dtkd")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.tong_congno)
                            .HasColumnName("tong_congno")
                            .HasColumnType("numeric").HasPrecision(18, 2);
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.url)
                            .HasColumnName("url")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_dondathangphanxuong>().ToTable("md_dondathangphanxuong");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.md_dondathangphanxuong_id)
                            .HasColumnName("md_dondathangphanxuong_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_dondathangphanxuong>().HasKey<string>(p => p.md_dondathangphanxuong_id);
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.c_kehoachdathang_dhcpx_id)
                            .HasColumnName("c_kehoachdathang_dhcpx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.c_kehoachdathang_id)
                            .HasColumnName("c_kehoachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.hdlh)
                            .HasColumnName("hdlh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.hdlhchung)
                            .HasColumnName("hdlhchung")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.huongdankhac)
                            .HasColumnName("huongdankhac")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.ketthucDHPX)
                            .HasColumnName("ketthucDHPX")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.md_trangthai_id)
                            .HasColumnName("md_trangthai_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.ngay_hieuluc)
                            .HasColumnName("ngay_hieuluc")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.ngayhoanthanh)
                            .HasColumnName("ngayhoanthanh")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.ngayketthuc)
                            .HasColumnName("ngayketthuc")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.nhomKH)
                            .HasColumnName("nhomKH")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.nhomKHBTP)
                            .HasColumnName("nhomKHBTP")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.phieunhapkho)
                            .HasColumnName("phieunhapkho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.yeucaumuavattu)
                            .HasColumnName("yeucaumuavattu")
                            .HasColumnType("varchar");
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
                            .HasColumnType("decimal").HasPrecision(18, 4);
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
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.sl_hanngach)
                            .HasColumnName("sl_hanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.sl_hoanthanh)
                            .HasColumnName("sl_hoanthanh")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.sl_tamhoanthanh)
                            .HasColumnName("sl_tamhoanthanh")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.tong_sl_dat)
                            .HasColumnName("tong_sl_dat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
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
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>()
                            .Property(p => p.sl_hoanthanh)
                            .HasColumnName("sl_hoanthanh")
                            .HasColumnType("decimal").HasPrecision(18, 4);
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
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.sl_hanngach)
                            .HasColumnName("sl_hanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
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
                            .HasColumnType("decimal").HasPrecision(18, 4);
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
modelBuilder.Entity<md_ghichuhdlh>().ToTable("md_ghichuhdlh");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.md_ghichuhdlh_id)
                            .HasColumnName("md_ghichuhdlh_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_ghichuhdlh>().HasKey<string>(p => p.md_ghichuhdlh_id);
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.doituong_dinhkem)
                            .HasColumnName("doituong_dinhkem")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.ghichu)
                            .HasColumnName("ghichu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.lienket)
                            .HasColumnName("lienket")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.lienket2)
                            .HasColumnName("lienket2")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.loai)
                            .HasColumnName("loai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.ngayxacnhan)
                            .HasColumnName("ngayxacnhan")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_ghichuhdlh>()
                            .Property(p => p.viewed)
                            .HasColumnName("viewed")
                            .HasColumnType("bit");
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
                            .HasColumnType("numeric").HasPrecision(18, 2);
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
                            .HasColumnType("numeric").HasPrecision(18, 2);
                            modelBuilder.Entity<md_giasanpham_giaodich>()
                            .Property(p => p.giamoi)
                            .HasColumnName("giamoi")
                            .HasColumnType("numeric").HasPrecision(18, 2);
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
                            .HasColumnType("decimal").HasPrecision(18, 5);
                            modelBuilder.Entity<md_hanngach_chitiet>()
                            .Property(p => p.slgiam)
                            .HasColumnName("slgiam")
                            .HasColumnType("decimal").HasPrecision(18, 5);
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
                    
                    
            #endregion End Code
        }
    }
}
