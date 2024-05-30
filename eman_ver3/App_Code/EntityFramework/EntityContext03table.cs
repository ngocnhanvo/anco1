using System.Data.Entity;
namespace DataAcess
{
    public class EntityContext03table
    {
        public void exec(DbModelBuilder modelBuilder)
        {
            #region Start Code
            modelBuilder.Entity<c_nhucauvattu_ycmvt>().ToTable("c_nhucauvattu_ycmvt");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.c_nhucauvattu_ycmvt_id)
                            .HasColumnName("c_nhucauvattu_ycmvt_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<c_nhucauvattu_ycmvt>().HasKey<string>(p => p.c_nhucauvattu_ycmvt_id);
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.c_nhucauvattu_id)
                            .HasColumnName("c_nhucauvattu_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.dongyeucau)
                            .HasColumnName("dongyeucau")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.sl_duyetmua)
                            .HasColumnName("sl_duyetmua")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_phidathang>().ToTable("c_phidathang");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.c_phidathang_id)
                            .HasColumnName("c_phidathang_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_phidathang>().HasKey<string>(p => p.c_phidathang_id);
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.c_danhsachdathang_id)
                            .HasColumnName("c_danhsachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.isphicong)
                            .HasColumnName("isphicong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.sotien)
                            .HasColumnName("sotien")
                            .HasColumnType("numeric").HasPrecision(18, 8);
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_yeucaumuavt>().ToTable("c_yeucaumuavt");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.c_yeucaumuavt_id)
                            .HasColumnName("c_yeucaumuavt_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<c_yeucaumuavt>().HasKey<string>(p => p.c_yeucaumuavt_id);
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.c_kehoachdathang_id)
                            .HasColumnName("c_kehoachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.c_kehoachmuavt_id)
                            .HasColumnName("c_kehoachmuavt_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.c_nhucauvattu_id)
                            .HasColumnName("c_nhucauvattu_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.khmvt_name)
                            .HasColumnName("khmvt_name")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.khuon)
                            .HasColumnName("khuon")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.md_trangthai_id)
                            .HasColumnName("md_trangthai_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.ncvt_name)
                            .HasColumnName("ncvt_name")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.ngaycan)
                            .HasColumnName("ngaycan")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.ngaylap)
                            .HasColumnName("ngaylap")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.nguoiyeucau)
                            .HasColumnName("nguoiyeucau")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.sct_donhang)
                            .HasColumnName("sct_donhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_yeucaumuavt_cdh>().ToTable("c_yeucaumuavt_cdh");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.c_yeucaumuavt_cdh_id)
                            .HasColumnName("c_yeucaumuavt_cdh_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<c_yeucaumuavt_cdh>().HasKey<string>(p => p.c_yeucaumuavt_cdh_id);
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.c_yeucaumuavt_id)
                            .HasColumnName("c_yeucaumuavt_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.soluong_yeucau)
                            .HasColumnName("soluong_yeucau")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_banggia>().ToTable("md_banggia");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.md_banggia_id)
                            .HasColumnName("md_banggia_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_banggia>().HasKey<string>(p => p.md_banggia_id);
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.banggiaban)
                            .HasColumnName("banggiaban")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.isstandar)
                            .HasColumnName("isstandar")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.lienket_bg)
                            .HasColumnName("lienket_bg")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.md_dongtien_id)
                            .HasColumnName("md_dongtien_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.phongbanId)
                            .HasColumnName("phongbanId")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.ten_banggia)
                            .HasColumnName("ten_banggia")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.tuychon)
                            .HasColumnName("tuychon")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_baotrivthh>().ToTable("md_baotrivthh");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.md_baotrivthh_id)
                            .HasColumnName("md_baotrivthh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_baotrivthh>().HasKey<string>(p => p.md_baotrivthh_id);
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.ngaybaotri)
                            .HasColumnName("ngaybaotri")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_baotrivthh_cdh>().ToTable("md_baotrivthh_cdh");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.md_baotrivthh_cdh_id)
                            .HasColumnName("md_baotrivthh_cdh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_baotrivthh_cdh>().HasKey<string>(p => p.md_baotrivthh_cdh_id);
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.hansudung)
                            .HasColumnName("hansudung")
                            .HasColumnType("date");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.md_baotrivthh_id)
                            .HasColumnName("md_baotrivthh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.soluong_baotri)
                            .HasColumnName("soluong_baotri")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.soluong_daht)
                            .HasColumnName("soluong_daht")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.soluong_dank)
                            .HasColumnName("soluong_dank")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.soluong_daxk)
                            .HasColumnName("soluong_daxk")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_bo>().ToTable("md_bo");
                            modelBuilder.Entity<md_bo>()
                            .Property(p => p.md_bo_id)
                            .HasColumnName("md_bo_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_bo>().HasKey<string>(p => p.md_bo_id);
                            modelBuilder.Entity<md_bo>()
                            .Property(p => p.ghichu)
                            .HasColumnName("ghichu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_bo>()
                            .Property(p => p.ma_bo)
                            .HasColumnName("ma_bo")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo>()
                            .Property(p => p.ma_bo_cha)
                            .HasColumnName("ma_bo_cha")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_bo>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_bo>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo>()
                            .Property(p => p.ten_bo)
                            .HasColumnName("ten_bo")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_bo_chitiet>().ToTable("md_bo_chitiet");
                            modelBuilder.Entity<md_bo_chitiet>()
                            .Property(p => p.md_bo_chitiet_id)
                            .HasColumnName("md_bo_chitiet_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_bo_chitiet>().HasKey<string>(p => p.md_bo_chitiet_id);
                            modelBuilder.Entity<md_bo_chitiet>()
                            .Property(p => p.ghichu)
                            .HasColumnName("ghichu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo_chitiet>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_bo_chitiet>()
                            .Property(p => p.md_bo_detail)
                            .HasColumnName("md_bo_detail")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo_chitiet>()
                            .Property(p => p.md_bo_id)
                            .HasColumnName("md_bo_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo_chitiet>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo_chitiet>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_bo_chitiet>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_bo_chitiet>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo_chitiet>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_cangbien>().ToTable("md_cangbien");
                            modelBuilder.Entity<md_cangbien>()
                            .Property(p => p.md_cangbien_id)
                            .HasColumnName("md_cangbien_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_cangbien>().HasKey<string>(p => p.md_cangbien_id);
                            modelBuilder.Entity<md_cangbien>()
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_cangbien>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_cangbien>()
                            .Property(p => p.ma_cangbien)
                            .HasColumnName("ma_cangbien")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_cangbien>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_cangbien>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_cangbien>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_cangbien>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_cangbien>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_cangbien>()
                            .Property(p => p.ten_cangbien)
                            .HasColumnName("ten_cangbien")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_chungloai>().ToTable("md_chungloai");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.md_chungloai_id)
                            .HasColumnName("md_chungloai_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_chungloai>().HasKey<string>(p => p.md_chungloai_id);
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.code_cl)
                            .HasColumnName("code_cl")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.songaysx)
                            .HasColumnName("songaysx")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.ta_dai)
                            .HasColumnName("ta_dai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.ta_ngan)
                            .HasColumnName("ta_ngan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.tv_dai)
                            .HasColumnName("tv_dai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.tv_ngan)
                            .HasColumnName("tv_ngan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_chungloai_ql>().ToTable("md_chungloai_ql");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.md_chungloai_ql_id)
                            .HasColumnName("md_chungloai_ql_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_chungloai_ql>().HasKey<string>(p => p.md_chungloai_ql_id);
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.ad_user_id)
                            .HasColumnName("ad_user_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.md_chungloai_id)
                            .HasColumnName("md_chungloai_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.value_nguoiql)
                            .HasColumnName("value_nguoiql")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai_ql>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_congthuctrongtinhgia>().ToTable("md_congthuctrongtinhgia");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.md_congthuctrongtinhgia_id)
                            .HasColumnName("md_congthuctrongtinhgia_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_congthuctrongtinhgia>().HasKey<string>(p => p.md_congthuctrongtinhgia_id);
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.congthuc)
                            .HasColumnName("congthuc")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.ten_congthuc)
                            .HasColumnName("ten_congthuc")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_congthuctrongtinhgia_mausac>().ToTable("md_congthuctrongtinhgia_mausac");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.md_congthuctrongtinhgia_mausac_id)
                            .HasColumnName("md_congthuctrongtinhgia_mausac_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_congthuctrongtinhgia_mausac>().HasKey<string>(p => p.md_congthuctrongtinhgia_mausac_id);
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.md_congthuctrongtinhgia_id)
                            .HasColumnName("md_congthuctrongtinhgia_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.md_sanphammausac_id)
                            .HasColumnName("md_sanphammausac_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_dbbiendong>().ToTable("md_dbbiendong");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.md_dbbiendong_id)
                            .HasColumnName("md_dbbiendong_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<md_dbbiendong>().HasKey<string>(p => p.md_dbbiendong_id);
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.table_biendong)
                            .HasColumnName("table_biendong")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.tanso_biendong)
                            .HasColumnName("tanso_biendong")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dbbiendong>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dbbiendong>()
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
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.soluong_dichchuyen)
                            .HasColumnName("soluong_dichchuyen")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.soluong_muonchuyen)
                            .HasColumnName("soluong_muonchuyen")
                            .HasColumnType("decimal").HasPrecision(18, 8);
                            modelBuilder.Entity<md_doimaudodang_dh>()
                            .Property(p => p.soluong_toida)
                            .HasColumnName("soluong_toida")
                            .HasColumnType("decimal").HasPrecision(18, 8);
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
                            .HasColumnType("numeric").HasPrecision(18, 8);
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
            #endregion End Code
        }
    }
}
