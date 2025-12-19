using System.Data.Entity;
namespace DataAcess
{
    public class EntityContext03table
    {
        public void exec(DbModelBuilder modelBuilder)
        {
            #region Start Code
            modelBuilder.Entity<c_nhucauvattu_dhpx>().ToTable("c_nhucauvattu_dhpx");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.c_nhucauvattu_dhpx_id)
                            .HasColumnName("c_nhucauvattu_dhpx_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<c_nhucauvattu_dhpx>().HasKey<string>(p => p.c_nhucauvattu_dhpx_id);
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.c_kehoachdathang_id)
                            .HasColumnName("c_kehoachdathang_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.c_nhucauvattu_id)
                            .HasColumnName("c_nhucauvattu_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.md_dondathangphanxuong_id)
                            .HasColumnName("md_dondathangphanxuong_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.md_lenhsanxuat_id)
                            .HasColumnName("md_lenhsanxuat_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
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
                            .HasColumnType("decimal").HasPrecision(18, 5);
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 5);
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
                            .HasColumnType("numeric").HasPrecision(18, 2);
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
                            .Property(p => p.denngay)
                            .HasColumnName("denngay")
                            .HasColumnType("datetime");
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
                            .Property(p => p.ten_yc)
                            .HasColumnName("ten_yc")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_yeucaumuavt>()
                            .Property(p => p.tungay)
                            .HasColumnName("tungay")
                            .HasColumnType("datetime");
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
                            .HasColumnType("decimal").HasPrecision(18, 2);
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
//Unable to generate entity type for table 'dbo.cpip_11042025022007838PM'. table have no primary key
//Unable to generate entity type for table 'dbo.cpip_12042025030514526PM'. table have no primary key
//Unable to generate entity type for table 'dbo.cpip_17072025045729602PM'. table have no primary key
//Unable to generate entity type for table 'dbo.cpip_27052025104827390AM'. table have no primary key
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
                            .Property(p => p.check1)
                            .HasColumnName("check1")
                            .HasColumnType("bit");
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
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
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
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.soluong_daht)
                            .HasColumnName("soluong_daht")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.soluong_dank)
                            .HasColumnName("soluong_dank")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_baotrivthh_cdh>()
                            .Property(p => p.soluong_daxk)
                            .HasColumnName("soluong_daxk")
                            .HasColumnType("decimal").HasPrecision(18, 4);
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
            #endregion End Code
        }
    }
}
