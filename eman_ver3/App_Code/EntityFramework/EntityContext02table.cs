using System.Data.Entity;
namespace DataAcess
{
    public class EntityContext02table
    {
        public void exec(DbModelBuilder modelBuilder)
        {
            #region Start Code
            modelBuilder.Entity<c_donmuahang_thue>().ToTable("c_donmuahang_thue");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.c_donmuahang_id)
                            .HasColumnName("c_donmuahang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.c_donmuahang_thue_id)
                            .HasColumnName("c_donmuahang_thue_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_donmuahang_thue>().HasKey<string>(p => p.c_donmuahang_thue_id);
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.doanhnghiep)
                            .HasColumnName("doanhnghiep")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.md_thue_sanpham_id)
                            .HasColumnName("md_thue_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.tochuc)
                            .HasColumnName("tochuc")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.tong_tien_chiu_thue)
                            .HasColumnName("tong_tien_chiu_thue")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.tong_tien_thue)
                            .HasColumnName("tong_tien_thue")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_thue>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang>().ToTable("c_kehoachdathang");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.c_doichieuhangton_id)
                            .HasColumnName("c_doichieuhangton_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.c_kehoachdathang_id)
                            .HasColumnName("c_kehoachdathang_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang>().HasKey<string>(p => p.c_kehoachdathang_id);
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.ngaybatdausx)
                            .HasColumnName("ngaybatdausx")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.ngaykehoach)
                            .HasColumnName("ngaykehoach")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.sodonhang)
                            .HasColumnName("sodonhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.ten_kh)
                            .HasColumnName("ten_kh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang>()
                            .Property(p => p.xulykehoach)
                            .HasColumnName("xulykehoach")
                            .HasColumnType("bit");
modelBuilder.Entity<c_kehoachdathang_cdhcd>().ToTable("c_kehoachdathang_cdhcd");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.c_kehoachdathang_cdhcd_id)
                            .HasColumnName("c_kehoachdathang_cdhcd_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang_cdhcd>().HasKey<string>(p => p.c_kehoachdathang_cdhcd_id);
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.c_kehoachdathang_id)
                            .HasColumnName("c_kehoachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.macuoi)
                            .HasColumnName("macuoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.noigiaohang)
                            .HasColumnName("noigiaohang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.sl_candat)
                            .HasColumnName("sl_candat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.sl_phanphoi)
                            .HasColumnName("sl_phanphoi")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_cdhcd>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang_dhcpx>().ToTable("c_kehoachdathang_dhcpx");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.c_kehoachdathang_dhcpx_id)
                            .HasColumnName("c_kehoachdathang_dhcpx_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang_dhcpx>().HasKey<string>(p => p.c_kehoachdathang_dhcpx_id);
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.c_kehoachdathang_id)
                            .HasColumnName("c_kehoachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.dongdathang)
                            .HasColumnName("dongdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.donhang)
                            .HasColumnName("donhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.hdlh)
                            .HasColumnName("hdlh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.hdlhchung)
                            .HasColumnName("hdlhchung")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.ngayHTcham)
                            .HasColumnName("ngayHTcham")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.tinh_ncvt)
                            .HasColumnName("tinh_ncvt")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>().ToTable("c_kehoachdathang_dhcpx_cdh");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.c_kehoachdathang_dhcpx_cdh_id)
                            .HasColumnName("c_kehoachdathang_dhcpx_cdh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>().HasKey<string>(p => p.c_kehoachdathang_dhcpx_cdh_id);
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.c_kehoachdathang_dhcpx_id)
                            .HasColumnName("c_kehoachdathang_dhcpx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.c_kehoachdathang_id)
                            .HasColumnName("c_kehoachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.macuoi)
                            .HasColumnName("macuoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.md_sanpham_bom_id)
                            .HasColumnName("md_sanpham_bom_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.noigiaohang)
                            .HasColumnName("noigiaohang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>().ToTable("c_kehoachdathang_dhcpx_hanngach");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.c_kehoachdathang_dhcpx_hanngach_id)
                            .HasColumnName("c_kehoachdathang_dhcpx_hanngach_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>().HasKey<string>(p => p.c_kehoachdathang_dhcpx_hanngach_id);
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.c_kehoachdathang_dhcpx_id)
                            .HasColumnName("c_kehoachdathang_dhcpx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.c_kehoachdathang_id)
                            .HasColumnName("c_kehoachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_hanngach>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>().ToTable("c_kehoachdathang_dhcpx_vattu");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.c_kehoachdathang_dhcpx_id)
                            .HasColumnName("c_kehoachdathang_dhcpx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.c_kehoachdathang_dhcpx_vattu_id)
                            .HasColumnName("c_kehoachdathang_dhcpx_vattu_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>().HasKey<string>(p => p.c_kehoachdathang_dhcpx_vattu_id);
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.c_kehoachdathang_id)
                            .HasColumnName("c_kehoachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.sl_duyetmua)
                            .HasColumnName("sl_duyetmua")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.sl_hanngach)
                            .HasColumnName("sl_hanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhcpx_vattu>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang_dhncc>().ToTable("c_kehoachdathang_dhncc");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.banggia)
                            .HasColumnName("banggia")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.c_kehoachdathang_dhncc_id)
                            .HasColumnName("c_kehoachdathang_dhncc_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang_dhncc>().HasKey<string>(p => p.c_kehoachdathang_dhncc_id);
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.c_kehoachdathang_id)
                            .HasColumnName("c_kehoachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.chungtu)
                            .HasColumnName("chungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.donhang)
                            .HasColumnName("donhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.thoihan_giaohang)
                            .HasColumnName("thoihan_giaohang")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.thoihan_hoanthanh)
                            .HasColumnName("thoihan_hoanthanh")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>().ToTable("c_kehoachdathang_dhncc_cdh");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.c_kehoachdathang_dhncc_cdh_id)
                            .HasColumnName("c_kehoachdathang_dhncc_cdh_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>().HasKey<string>(p => p.c_kehoachdathang_dhncc_cdh_id);
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.c_kehoachdathang_dhncc_id)
                            .HasColumnName("c_kehoachdathang_dhncc_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.c_kehoachdathang_id)
                            .HasColumnName("c_kehoachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.macuoi)
                            .HasColumnName("macuoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.ngaycan)
                            .HasColumnName("ngaycan")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachdathang_dhncc_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachmuavt>().ToTable("c_kehoachmuavt");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.bophanyc)
                            .HasColumnName("bophanyc")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.bophanyc_value)
                            .HasColumnName("bophanyc_value")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.c_donmuavattu_id)
                            .HasColumnName("c_donmuavattu_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.c_kehoachmuavt_id)
                            .HasColumnName("c_kehoachmuavt_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<c_kehoachmuavt>().HasKey<string>(p => p.c_kehoachmuavt_id);
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.denngay)
                            .HasColumnName("denngay")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.md_trangthai_id)
                            .HasColumnName("md_trangthai_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.ngaykehoach)
                            .HasColumnName("ngaykehoach")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.phieuhangton)
                            .HasColumnName("phieuhangton")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.ten_kehoach)
                            .HasColumnName("ten_kehoach")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.tungay)
                            .HasColumnName("tungay")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachmuavt_cdh>().ToTable("c_kehoachmuavt_cdh");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.c_kehoachmuavt_cdh_id)
                            .HasColumnName("c_kehoachmuavt_cdh_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<c_kehoachmuavt_cdh>().HasKey<string>(p => p.c_kehoachmuavt_cdh_id);
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.c_kehoachmuavt_id)
                            .HasColumnName("c_kehoachmuavt_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.ngayphaico)
                            .HasColumnName("ngayphaico")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.sl_can)
                            .HasColumnName("sl_can")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.sl_canthem)
                            .HasColumnName("sl_canthem")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.sl_conlai)
                            .HasColumnName("sl_conlai")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.sl_denghi)
                            .HasColumnName("sl_denghi")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.sl_duyet)
                            .HasColumnName("sl_duyet")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.sl_layton)
                            .HasColumnName("sl_layton")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.sl_tonkho)
                            .HasColumnName("sl_tonkho")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.sl_tonkho_toithieu)
                            .HasColumnName("sl_tonkho_toithieu")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachmuavt_dklht>().ToTable("c_kehoachmuavt_dklht");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.c_kehoachmuavt_dklht_id)
                            .HasColumnName("c_kehoachmuavt_dklht_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_kehoachmuavt_dklht>().HasKey<string>(p => p.c_kehoachmuavt_dklht_id);
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.c_kehoachmuavt_id)
                            .HasColumnName("c_kehoachmuavt_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.makho)
                            .HasColumnName("makho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.sl_dalayton)
                            .HasColumnName("sl_dalayton")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.sl_layton)
                            .HasColumnName("sl_layton")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.sl_tonkho)
                            .HasColumnName("sl_tonkho")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_kehoachmuavt_dklht>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_nhucauvattu>().ToTable("c_nhucauvattu");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.c_nhucauvattu_id)
                            .HasColumnName("c_nhucauvattu_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<c_nhucauvattu>().HasKey<string>(p => p.c_nhucauvattu_id);
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.c_yeucaumuavt_id)
                            .HasColumnName("c_yeucaumuavt_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.datinh_nhucau)
                            .HasColumnName("datinh_nhucau")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.denngay)
                            .HasColumnName("denngay")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.ngayyeucau)
                            .HasColumnName("ngayyeucau")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.ten_nhucau)
                            .HasColumnName("ten_nhucau")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.tungay)
                            .HasColumnName("tungay")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_nhucauvattu_ddhpx>().ToTable("c_nhucauvattu_ddhpx");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.c_nhucauvattu_ddhpx_id)
                            .HasColumnName("c_nhucauvattu_ddhpx_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<c_nhucauvattu_ddhpx>().HasKey<string>(p => p.c_nhucauvattu_ddhpx_id);
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.c_nhucauvattu_id)
                            .HasColumnName("c_nhucauvattu_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_nhucauvattu_ddhpx>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_nhucauvattu_dhpx>().ToTable("c_nhucauvattu_dhpx");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_nhucauvattu_dhpx>()
                            .Property(p => p.c_nhucauvattu_dhpx_id)
                            .HasColumnName("c_nhucauvattu_dhpx_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<c_nhucauvattu_dhpx>().HasKey<string>(p => p.c_nhucauvattu_dhpx_id);
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
                            .Property(p => p.c_nhucauvattu_ycmvt_id)
                            .HasColumnName("c_nhucauvattu_ycmvt_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<c_nhucauvattu_ycmvt>().HasKey<string>(p => p.c_nhucauvattu_ycmvt_id);
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
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_nhucauvattu_ycmvt>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
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
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.c_danhsachdathang_id)
                            .HasColumnName("c_danhsachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_phidathang>()
                            .Property(p => p.c_phidathang_id)
                            .HasColumnName("c_phidathang_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<c_phidathang>().HasKey<string>(p => p.c_phidathang_id);
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
                            .HasColumnType("numeric").HasPrecision(18, 4);
modelBuilder.Entity<c_yeucaumuavt>().ToTable("c_yeucaumuavt");
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
                            .Property(p => p.c_yeucaumuavt_id)
                            .HasColumnName("c_yeucaumuavt_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<c_yeucaumuavt>().HasKey<string>(p => p.c_yeucaumuavt_id);
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
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
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
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_yeucaumuavt_cdh>()
                            .Property(p => p.c_yeucaumuavt_cdh_id)
                            .HasColumnName("c_yeucaumuavt_cdh_id")
                            .HasColumnType("varchar");
modelBuilder.Entity<c_yeucaumuavt_cdh>().HasKey<string>(p => p.c_yeucaumuavt_cdh_id);
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
                            .HasColumnType("decimal").HasPrecision(18, 4);
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
                            .Property(p => p.banggiaban)
                            .HasColumnName("banggiaban")
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
                            .Property(p => p.md_banggia_id)
                            .HasColumnName("md_banggia_id")
                            .HasColumnType("nvarchar");
modelBuilder.Entity<md_banggia>().HasKey<string>(p => p.md_banggia_id);
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
                            .Property(p => p.ten_banggia)
                            .HasColumnName("ten_banggia")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_banggia>()
                            .Property(p => p.tuychon)
                            .HasColumnName("tuychon")
                            .HasColumnType("nvarchar");
            #endregion End Code
        }
    }
}
