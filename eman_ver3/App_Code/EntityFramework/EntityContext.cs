
            using System;
            using System.Data.Entity;
            using System.Data.Entity.ModelConfiguration.Conventions;
            namespace DataAcess
            {
                public partial class EntityContext : DbContext
                {
                    public EntityContext() : base("edoc2014ConnectionString")
                    {
                    }

                    
                            public virtual DbSet<ad_autoload> ad_autoload { get; set; }
                        
                            public virtual DbSet<ad_autoload_mmc> ad_autoload_mmc { get; set; }
                        
                            public virtual DbSet<ad_avariableSQL> ad_avariableSQL { get; set; }
                        
                            public virtual DbSet<ad_case> ad_case { get; set; }
                        
                            public virtual DbSet<ad_clearcache> ad_clearcache { get; set; }
                        
                            public virtual DbSet<ad_column> ad_column { get; set; }
                        
                            public virtual DbSet<ad_department> ad_department { get; set; }
                        
                            public virtual DbSet<ad_editstyle> ad_editstyle { get; set; }
                        
                            public virtual DbSet<ad_formatter> ad_formatter { get; set; }
                        
                            public virtual DbSet<ad_import> ad_import { get; set; }
                        
                            public virtual DbSet<ad_import_ava> ad_import_ava { get; set; }
                        
                            public virtual DbSet<ad_import_column> ad_import_column { get; set; }
                        
                            public virtual DbSet<ad_import_ex> ad_import_ex { get; set; }
                        
                            public virtual DbSet<ad_log> ad_log { get; set; }
                        
                            public virtual DbSet<ad_menu> ad_menu { get; set; }
                        
                            public virtual DbSet<ad_module> ad_module { get; set; }
                        
                            public virtual DbSet<ad_remove> ad_remove { get; set; }
                        
                            public virtual DbSet<ad_removeline> ad_removeline { get; set; }
                        
                            public virtual DbSet<ad_role> ad_role { get; set; }
                        
                            public virtual DbSet<ad_role_mmc> ad_role_mmc { get; set; }
                        
                            public virtual DbSet<ad_role_where> ad_role_where { get; set; }
                        
                            public virtual DbSet<ad_selectop_save> ad_selectop_save { get; set; }
                        
                            public virtual DbSet<ad_selectoption> ad_selectoption { get; set; }
                        
                            public virtual DbSet<ad_status> ad_status { get; set; }
                        
                            public virtual DbSet<ad_systemconfig> ad_systemconfig { get; set; }
                        
                            public virtual DbSet<ad_table_manager> ad_table_manager { get; set; }
                        
                            public virtual DbSet<ad_user> ad_user { get; set; }
                        
                            public virtual DbSet<ad_user_role> ad_user_role { get; set; }
                        
                            public virtual DbSet<c_danhsachdathang> c_danhsachdathang { get; set; }
                        
                            public virtual DbSet<c_danhsachdathang_nangluc> c_danhsachdathang_nangluc { get; set; }
                        
                            public virtual DbSet<c_doichieuhangton> c_doichieuhangton { get; set; }
                        
                            public virtual DbSet<c_doichieuhangton_cddh> c_doichieuhangton_cddh { get; set; }
                        
                            public virtual DbSet<c_doichieuhangton_dkdh> c_doichieuhangton_dkdh { get; set; }
                        
                            public virtual DbSet<c_doichieuhangton_dklht> c_doichieuhangton_dklht { get; set; }
                        
                            public virtual DbSet<c_doichieuhangton_thdh> c_doichieuhangton_thdh { get; set; }
                        
                            public virtual DbSet<c_doichieuhangton_tk> c_doichieuhangton_tk { get; set; }
                        
                            public virtual DbSet<c_doichieuhangton_tkkd> c_doichieuhangton_tkkd { get; set; }
                        
                            public virtual DbSet<c_dongdsdh> c_dongdsdh { get; set; }
                        
                            public virtual DbSet<c_donmuahang> c_donmuahang { get; set; }
                        
                            public virtual DbSet<c_donmuahang_cdmh> c_donmuahang_cdmh { get; set; }
                        
                            public virtual DbSet<c_donmuahang_thue> c_donmuahang_thue { get; set; }
                        
                            public virtual DbSet<c_kehoachdathang> c_kehoachdathang { get; set; }
                        
                            public virtual DbSet<c_kehoachdathang_cdhcd> c_kehoachdathang_cdhcd { get; set; }
                        
                            public virtual DbSet<c_kehoachdathang_dhcpx> c_kehoachdathang_dhcpx { get; set; }
                        
                            public virtual DbSet<c_kehoachdathang_dhcpx_cdh> c_kehoachdathang_dhcpx_cdh { get; set; }
                        
                            public virtual DbSet<c_kehoachdathang_dhcpx_vattu> c_kehoachdathang_dhcpx_vattu { get; set; }
                        
                            public virtual DbSet<c_kehoachdathang_dhncc> c_kehoachdathang_dhncc { get; set; }
                        
                            public virtual DbSet<c_kehoachdathang_dhncc_cdh> c_kehoachdathang_dhncc_cdh { get; set; }
                        
                            public virtual DbSet<c_kehoachmuavt> c_kehoachmuavt { get; set; }
                        
                            public virtual DbSet<c_kehoachmuavt_cdh> c_kehoachmuavt_cdh { get; set; }
                        
                            public virtual DbSet<c_kehoachmuavt_dklht> c_kehoachmuavt_dklht { get; set; }
                        
                            public virtual DbSet<c_nhucauvattu> c_nhucauvattu { get; set; }
                        
                            public virtual DbSet<c_nhucauvattu_ddhpx> c_nhucauvattu_ddhpx { get; set; }
                        
                            public virtual DbSet<c_nhucauvattu_dhpx> c_nhucauvattu_dhpx { get; set; }
                        
                            public virtual DbSet<c_nhucauvattu_ycmvt> c_nhucauvattu_ycmvt { get; set; }
                        
                            public virtual DbSet<c_phidathang> c_phidathang { get; set; }
                        
                            public virtual DbSet<c_yeucaumuavt> c_yeucaumuavt { get; set; }
                        
                            public virtual DbSet<c_yeucaumuavt_cdh> c_yeucaumuavt_cdh { get; set; }
                        
                            public virtual DbSet<md_banggia> md_banggia { get; set; }
                        
                            public virtual DbSet<md_baotrivthh> md_baotrivthh { get; set; }
                        
                            public virtual DbSet<md_baotrivthh_cdh> md_baotrivthh_cdh { get; set; }
                        
                            public virtual DbSet<md_bo> md_bo { get; set; }
                        
                            public virtual DbSet<md_bo_chitiet> md_bo_chitiet { get; set; }
                        
                            public virtual DbSet<md_cangbien> md_cangbien { get; set; }
                        
                            public virtual DbSet<md_chungloai> md_chungloai { get; set; }
                        
                            public virtual DbSet<md_chungloai_ql> md_chungloai_ql { get; set; }
                        
                            public virtual DbSet<md_congthuctrongtinhgia> md_congthuctrongtinhgia { get; set; }
                        
                            public virtual DbSet<md_congthuctrongtinhgia_mausac> md_congthuctrongtinhgia_mausac { get; set; }
                        
                            public virtual DbSet<md_dbbiendong> md_dbbiendong { get; set; }
                        
                            public virtual DbSet<md_doitackinhdoanh> md_doitackinhdoanh { get; set; }
                        
                            public virtual DbSet<md_dondathangphanxuong> md_dondathangphanxuong { get; set; }
                        
                            public virtual DbSet<md_dondathangphanxuong_cdh> md_dondathangphanxuong_cdh { get; set; }
                        
                            public virtual DbSet<md_dondathangphanxuong_tinhhinh> md_dondathangphanxuong_tinhhinh { get; set; }
                        
                            public virtual DbSet<md_dondathangphanxuong_vattu> md_dondathangphanxuong_vattu { get; set; }
                        
                            public virtual DbSet<md_dongtien> md_dongtien { get; set; }
                        
                            public virtual DbSet<md_donvitinh> md_donvitinh { get; set; }
                        
                            public virtual DbSet<md_donvitinhsanpham> md_donvitinhsanpham { get; set; }
                        
                            public virtual DbSet<md_donvitinhsanpham_cddv> md_donvitinhsanpham_cddv { get; set; }
                        
                            public virtual DbSet<md_giasanpham> md_giasanpham { get; set; }
                        
                            public virtual DbSet<md_hanngach> md_hanngach { get; set; }
                        
                            public virtual DbSet<md_hanngach_chitiet> md_hanngach_chitiet { get; set; }
                        
                            public virtual DbSet<md_hanngachPXTo> md_hanngachPXTo { get; set; }
                        
                            public virtual DbSet<md_hanngachPXTo_chitiet> md_hanngachPXTo_chitiet { get; set; }
                        
                            public virtual DbSet<md_hoadon> md_hoadon { get; set; }
                        
                            public virtual DbSet<md_hoadon_chitiet> md_hoadon_chitiet { get; set; }
                        
                            public virtual DbSet<md_kho> md_kho { get; set; }
                        
                            public virtual DbSet<md_kho_ghino> md_kho_ghino { get; set; }
                        
                            public virtual DbSet<md_kho_giaodich> md_kho_giaodich { get; set; }
                        
                            public virtual DbSet<md_kho_giucho> md_kho_giucho { get; set; }
                        
                            public virtual DbSet<md_kho_sanpham> md_kho_sanpham { get; set; }
                        
                            public virtual DbSet<md_kho_sanpham_hansudung> md_kho_sanpham_hansudung { get; set; }
                        
                            public virtual DbSet<md_kho_the> md_kho_the { get; set; }
                        
                            public virtual DbSet<md_khuvuc> md_khuvuc { get; set; }
                        
                            public virtual DbSet<md_kiemke> md_kiemke { get; set; }
                        
                            public virtual DbSet<md_kiemke_cdh> md_kiemke_cdh { get; set; }
                        
                            public virtual DbSet<md_lenhsanxuat> md_lenhsanxuat { get; set; }
                        
                            public virtual DbSet<md_lenhsanxuat_ddsx> md_lenhsanxuat_ddsx { get; set; }
                        
                            public virtual DbSet<md_lenhsanxuat_tosx> md_lenhsanxuat_tosx { get; set; }
                        
                            public virtual DbSet<md_lenhsanxuat_tosx_cdh> md_lenhsanxuat_tosx_cdh { get; set; }
                        
                            public virtual DbSet<md_lenhsanxuat_tosx_vattu> md_lenhsanxuat_tosx_vattu { get; set; }
                        
                            public virtual DbSet<md_lenhsanxuat_vattu> md_lenhsanxuat_vattu { get; set; }
                        
                            public virtual DbSet<md_loaicont> md_loaicont { get; set; }
                        
                            public virtual DbSet<md_loaidtkd> md_loaidtkd { get; set; }
                        
                            public virtual DbSet<md_modongky> md_modongky { get; set; }
                        
                            public virtual DbSet<md_namtaichinh> md_namtaichinh { get; set; }
                        
                            public virtual DbSet<md_namtaichinh_ky> md_namtaichinh_ky { get; set; }
                        
                            public virtual DbSet<md_nangluc> md_nangluc { get; set; }
                        
                            public virtual DbSet<md_nhapkho_ncc> md_nhapkho_ncc { get; set; }
                        
                            public virtual DbSet<md_nhapkho_ncc_dh> md_nhapkho_ncc_dh { get; set; }
                        
                            public virtual DbSet<md_nhapkho_px> md_nhapkho_px { get; set; }
                        
                            public virtual DbSet<md_nhapkho_px_dh> md_nhapkho_px_dh { get; set; }
                        
                            public virtual DbSet<md_nhapkhonb> md_nhapkhonb { get; set; }
                        
                            public virtual DbSet<md_nhapkhonb_cdh> md_nhapkhonb_cdh { get; set; }
                        
                            public virtual DbSet<md_nhapkhoton> md_nhapkhoton { get; set; }
                        
                            public virtual DbSet<md_nhapkhoton_cdh> md_nhapkhoton_cdh { get; set; }
                        
                            public virtual DbSet<md_nhomnangluc> md_nhomnangluc { get; set; }
                        
                            public virtual DbSet<md_phannnhommx> md_phannnhommx { get; set; }
                        
                            public virtual DbSet<md_phannnhommx_cdpk> md_phannnhommx_cdpk { get; set; }
                        
                            public virtual DbSet<md_phannnhommx_qhd> md_phannnhommx_qhd { get; set; }
                        
                            public virtual DbSet<md_phannnhommx_tlkthh> md_phannnhommx_tlkthh { get; set; }
                        
                            public virtual DbSet<md_phanxuong> md_phanxuong { get; set; }
                        
                            public virtual DbSet<md_phanxuong_to> md_phanxuong_to { get; set; }
                        
                            public virtual DbSet<md_phienbangia> md_phienbangia { get; set; }
                        
                            public virtual DbSet<md_quocgia> md_quocgia { get; set; }
                        
                            public virtual DbSet<md_sanpham> md_sanpham { get; set; }
                        
                            public virtual DbSet<md_sanpham_bom> md_sanpham_bom { get; set; }
                        
                            public virtual DbSet<md_sanpham_bom_vattu> md_sanpham_bom_vattu { get; set; }
                        
                            public virtual DbSet<md_sanphamhinhdang> md_sanphamhinhdang { get; set; }
                        
                            public virtual DbSet<md_sanphammausac> md_sanphammausac { get; set; }
                        
                            public virtual DbSet<md_sanphammausac_phatron> md_sanphammausac_phatron { get; set; }
                        
                            public virtual DbSet<md_sochungtu> md_sochungtu { get; set; }
                        
                            public virtual DbSet<md_taphopgia> md_taphopgia { get; set; }
                        
                            public virtual DbSet<md_taphopgia_cdh> md_taphopgia_cdh { get; set; }
                        
                            public virtual DbSet<md_taptin> md_taptin { get; set; }
                        
                            public virtual DbSet<md_thue_sanpham> md_thue_sanpham { get; set; }
                        
                            public virtual DbSet<md_tonghopcongno> md_tonghopcongno { get; set; }
                        
                            public virtual DbSet<md_tonghopkho> md_tonghopkho { get; set; }
                        
                            public virtual DbSet<md_tygia> md_tygia { get; set; }
                        
                            public virtual DbSet<md_vanchuyennoibo> md_vanchuyennoibo { get; set; }
                        
                            public virtual DbSet<md_vanchuyennoibo_cdvc> md_vanchuyennoibo_cdvc { get; set; }
                        
                            public virtual DbSet<md_vattutrongtinhbom> md_vattutrongtinhbom { get; set; }
                        
                            public virtual DbSet<md_xuatban> md_xuatban { get; set; }
                        
                            public virtual DbSet<md_xuatban_cdh> md_xuatban_cdh { get; set; }
                        
                            public virtual DbSet<md_xuatkhonb> md_xuatkhonb { get; set; }
                        
                            public virtual DbSet<md_xuatkhonb_cdh> md_xuatkhonb_cdh { get; set; }
                        
                            public virtual DbSet<md_xuatkhonb_sanpham> md_xuatkhonb_sanpham { get; set; }
                        
                    internal object Set()
                    {
                        throw new NotImplementedException();
                    }
                
                
                    protected override void OnModelCreating(DbModelBuilder modelBuilder)
                    {
                        
                        modelBuilder.Entity<ad_autoload>().ToTable("ad_autoload");
                        
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.ad_autoload_id)
                            .HasColumnName("ad_autoload_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload>().HasKey<string>(p => p.ad_autoload_id);
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.ma_autoload)
                            .HasColumnName("ma_autoload")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.tanso)
                            .HasColumnName("tanso")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.ten_autoload)
                            .HasColumnName("ten_autoload")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_autoload_mmc>().ToTable("ad_autoload_mmc");
                        
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.ad_autoload_id)
                            .HasColumnName("ad_autoload_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.ad_autoload_mmc_id)
                            .HasColumnName("ad_autoload_mmc_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload_mmc>().HasKey<string>(p => p.ad_autoload_mmc_id);
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.ad_module_id)
                            .HasColumnName("ad_module_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.ma_menu)
                            .HasColumnName("ma_menu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.ma_module)
                            .HasColumnName("ma_module")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_autoload_mmc>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_avariableSQL>().ToTable("ad_avariableSQL");
                        
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.ad_avariableSQL_id)
                            .HasColumnName("ad_avariableSQL_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_avariableSQL>().HasKey<string>(p => p.ad_avariableSQL_id);
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.iscode)
                            .HasColumnName("iscode")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.value)
                            .HasColumnName("value")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.value_replace)
                            .HasColumnName("value_replace")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_avariableSQL>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_case>().ToTable("ad_case");
                        
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.ad_case_id)
                            .HasColumnName("ad_case_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>().HasKey<string>(p => p.ad_case_id);
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.ad_module_id)
                            .HasColumnName("ad_module_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.canhgiua)
                            .HasColumnName("canhgiua")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.docaoForm)
                            .HasColumnName("docaoForm")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.dodaiForm)
                            .HasColumnName("dodaiForm")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.hamxuly)
                            .HasColumnName("hamxuly")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.hidden_modify)
                            .HasColumnName("hidden_modify")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.id_parent)
                            .HasColumnName("id_parent")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.isview)
                            .HasColumnName("isview")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.logo)
                            .HasColumnName("logo")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.ma_case)
                            .HasColumnName("ma_case")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.ma_menu)
                            .HasColumnName("ma_menu")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.ma_module)
                            .HasColumnName("ma_module")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.ten_case)
                            .HasColumnName("ten_case")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.thuake)
                            .HasColumnName("thuake")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.tieude)
                            .HasColumnName("tieude")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_case>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_clearcache>().ToTable("ad_clearcache");
                        
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.ad_clearcache_id)
                            .HasColumnName("ad_clearcache_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_clearcache>().HasKey<string>(p => p.ad_clearcache_id);
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.url_cache)
                            .HasColumnName("url_cache")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_clearcache>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_column>().ToTable("ad_column");
                        
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.ad_column_id)
                            .HasColumnName("ad_column_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>().HasKey<string>(p => p.ad_column_id);
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.ad_module_id)
                            .HasColumnName("ad_module_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.align)
                            .HasColumnName("align")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.colspan)
                            .HasColumnName("colspan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.disable_modify)
                            .HasColumnName("disable_modify")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.editable)
                            .HasColumnName("editable")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.editoptions)
                            .HasColumnName("editoptions")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.editrules)
                            .HasColumnName("editrules")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.edittype)
                            .HasColumnName("edittype")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.@fixed)
                            .HasColumnName("fixed")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.focus)
                            .HasColumnName("focus")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.formatoptions)
                            .HasColumnName("formatoptions")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.formatter)
                            .HasColumnName("formatter")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.formoptions)
                            .HasColumnName("formoptions")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.frozen)
                            .HasColumnName("frozen")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.hidden)
                            .HasColumnName("hidden")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.important)
                            .HasColumnName("important")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.index_cot)
                            .HasColumnName("index_cot")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.key_cot)
                            .HasColumnName("key_cot")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.label)
                            .HasColumnName("label")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.ma_column)
                            .HasColumnName("ma_column")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.ma_edittype)
                            .HasColumnName("ma_edittype")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.ma_menu)
                            .HasColumnName("ma_menu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.ma_module)
                            .HasColumnName("ma_module")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.reset_modify)
                            .HasColumnName("reset_modify")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.searchoptions)
                            .HasColumnName("searchoptions")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.sopt)
                            .HasColumnName("sopt")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.stype)
                            .HasColumnName("stype")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.ten_column)
                            .HasColumnName("ten_column")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.unformat)
                            .HasColumnName("unformat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_column>()
                            .Property(p => p.width)
                            .HasColumnName("width")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_department>().ToTable("ad_department");
                        
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.ma_phongban)
                            .HasColumnName("ma_phongban")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.md_phongban_id)
                            .HasColumnName("md_phongban_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_department>().HasKey<string>(p => p.md_phongban_id);
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.ten_phongban)
                            .HasColumnName("ten_phongban")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_department>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_editstyle>().ToTable("ad_editstyle");
                        
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.ad_editstyle_id)
                            .HasColumnName("ad_editstyle_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_editstyle>().HasKey<string>(p => p.ad_editstyle_id);
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.ad_module_id)
                            .HasColumnName("ad_module_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.ma_editstyle)
                            .HasColumnName("ma_editstyle")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.ma_module)
                            .HasColumnName("ma_module")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("ntext");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.ten_editstyle)
                            .HasColumnName("ten_editstyle")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.value_editoption)
                            .HasColumnName("value_editoption")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.value_editstyle)
                            .HasColumnName("value_editstyle")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.value_formatoptions)
                            .HasColumnName("value_formatoptions")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.value_formatter)
                            .HasColumnName("value_formatter")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.value_searchoptions)
                            .HasColumnName("value_searchoptions")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_editstyle>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_formatter>().ToTable("ad_formatter");
                        
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.ad_formatter_id)
                            .HasColumnName("ad_formatter_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_formatter>().HasKey<string>(p => p.ad_formatter_id);
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.ma_formatter)
                            .HasColumnName("ma_formatter")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_formatter>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_import>().ToTable("ad_import");
                        
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.ad_import_id)
                            .HasColumnName("ad_import_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import>().HasKey<string>(p => p.ad_import_id);
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.column_del)
                            .HasColumnName("column_del")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.ma_import)
                            .HasColumnName("ma_import")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.mau_import)
                            .HasColumnName("mau_import")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.table_del)
                            .HasColumnName("table_del")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.ten_import)
                            .HasColumnName("ten_import")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.ten_table)
                            .HasColumnName("ten_table")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.value_header)
                            .HasColumnName("value_header")
                            .HasColumnType("int");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.value_row)
                            .HasColumnName("value_row")
                            .HasColumnType("int");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_import_ava>().ToTable("ad_import_ava");
                        
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.ad_import_ava_id)
                            .HasColumnName("ad_import_ava_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ava>().HasKey<string>(p => p.ad_import_ava_id);
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.ad_import_id)
                            .HasColumnName("ad_import_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.ava_name)
                            .HasColumnName("ava_name")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.select_sql)
                            .HasColumnName("select_sql")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ava>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_import_column>().ToTable("ad_import_column");
                        
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.ad_import_column_id)
                            .HasColumnName("ad_import_column_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_column>().HasKey<string>(p => p.ad_import_column_id);
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.ad_import_id)
                            .HasColumnName("ad_import_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.function_sql)
                            .HasColumnName("function_sql")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.imported)
                            .HasColumnName("imported")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.ma_import_column)
                            .HasColumnName("ma_import_column")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.primary_key)
                            .HasColumnName("primary_key")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.select_sql)
                            .HasColumnName("select_sql")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.select_sql_cp)
                            .HasColumnName("select_sql_cp")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.ten_import_column)
                            .HasColumnName("ten_import_column")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_column>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_import_ex>().ToTable("ad_import_ex");
                        
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.ad_import_ex_id)
                            .HasColumnName("ad_import_ex_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ex>().HasKey<string>(p => p.ad_import_ex_id);
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.ad_import_id)
                            .HasColumnName("ad_import_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.row_ex)
                            .HasColumnName("row_ex")
                            .HasColumnType("int");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.value_replace)
                            .HasColumnName("value_replace")
                            .HasColumnType("int");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_import_ex>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_log>().ToTable("ad_log");
                        
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.ad_case_id)
                            .HasColumnName("ad_case_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.ad_log_id)
                            .HasColumnName("ad_log_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_log>().HasKey<string>(p => p.ad_log_id);
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.ad_module_id)
                            .HasColumnName("ad_module_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_log>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_menu>().ToTable("ad_menu");
                        
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.ad_menu_id)
                            .HasColumnName("ad_menu_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_menu>().HasKey<string>(p => p.ad_menu_id);
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.capmenu)
                            .HasColumnName("capmenu")
                            .HasColumnType("int");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.loai_menu)
                            .HasColumnName("loai_menu")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.logo)
                            .HasColumnName("logo")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.ma_menu)
                            .HasColumnName("ma_menu")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.ma_menucha)
                            .HasColumnName("ma_menucha")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.ma_module_count)
                            .HasColumnName("ma_module_count")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.taomodule)
                            .HasColumnName("taomodule")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.ten_menu)
                            .HasColumnName("ten_menu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.url)
                            .HasColumnName("url")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_menu>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_module>().ToTable("ad_module");
                        
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.ad_menu_id)
                            .HasColumnName("ad_menu_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.ad_module_id)
                            .HasColumnName("ad_module_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_module>().HasKey<string>(p => p.ad_module_id);
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.capmodule)
                            .HasColumnName("capmodule")
                            .HasColumnType("int");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.double_click)
                            .HasColumnName("double_click")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.from_sql)
                            .HasColumnName("from_sql")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.header_grid)
                            .HasColumnName("header_grid")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.Join_sql)
                            .HasColumnName("Join_sql")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.loai_module)
                            .HasColumnName("loai_module")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.loaithuake)
                            .HasColumnName("loaithuake")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.ma_menu)
                            .HasColumnName("ma_menu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.ma_module)
                            .HasColumnName("ma_module")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.ma_modulecha)
                            .HasColumnName("ma_modulecha")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.mutil_select)
                            .HasColumnName("mutil_select")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.orderby_sql)
                            .HasColumnName("orderby_sql")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.procedure_sql)
                            .HasColumnName("procedure_sql")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.row_count)
                            .HasColumnName("row_count")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.select_sql)
                            .HasColumnName("select_sql")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.soluong_mod)
                            .HasColumnName("soluong_mod")
                            .HasColumnType("int");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.ten_module)
                            .HasColumnName("ten_module")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.thuake)
                            .HasColumnName("thuake")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.update_linq)
                            .HasColumnName("update_linq")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.url)
                            .HasColumnName("url")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_module>()
                            .Property(p => p.where_sql)
                            .HasColumnName("where_sql")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_remove>().ToTable("ad_remove");
                        
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.ad_remove_id)
                            .HasColumnName("ad_remove_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_remove>().HasKey<string>(p => p.ad_remove_id);
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.ten_key)
                            .HasColumnName("ten_key")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.ten_table)
                            .HasColumnName("ten_table")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_remove>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_removeline>().ToTable("ad_removeline");
                        
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.ad_remove_id)
                            .HasColumnName("ad_remove_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.ad_removeline_id)
                            .HasColumnName("ad_removeline_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_removeline>().HasKey<string>(p => p.ad_removeline_id);
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.ten_key)
                            .HasColumnName("ten_key")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.ten_table)
                            .HasColumnName("ten_table")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_removeline>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_role>().ToTable("ad_role");
                        
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.ad_role_id)
                            .HasColumnName("ad_role_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role>().HasKey<string>(p => p.ad_role_id);
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.ma_role)
                            .HasColumnName("ma_role")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.role_thuake)
                            .HasColumnName("role_thuake")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.ten_role)
                            .HasColumnName("ten_role")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_role_mmc>().ToTable("ad_role_mmc");
                        
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.ad_case_id)
                            .HasColumnName("ad_case_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.ad_menu_id)
                            .HasColumnName("ad_menu_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.ad_module_id)
                            .HasColumnName("ad_module_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.ad_role_id)
                            .HasColumnName("ad_role_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.ad_role_mmc_id)
                            .HasColumnName("ad_role_mmc_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_mmc>().HasKey<string>(p => p.ad_role_mmc_id);
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.chophep)
                            .HasColumnName("chophep")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.ten_case)
                            .HasColumnName("ten_case")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_mmc>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_role_where>().ToTable("ad_role_where");
                        
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.ad_menu_id)
                            .HasColumnName("ad_menu_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.ad_module_id)
                            .HasColumnName("ad_module_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.ad_role_id)
                            .HasColumnName("ad_role_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.ad_role_where_id)
                            .HasColumnName("ad_role_where_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_where>().HasKey<string>(p => p.ad_role_where_id);
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.ma_module)
                            .HasColumnName("ma_module")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_role_where>()
                            .Property(p => p.where_sql)
                            .HasColumnName("where_sql")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_selectop_save>().ToTable("ad_selectop_save");
                        
                            modelBuilder.Entity<ad_selectop_save>()
                            .Property(p => p.ad_selectop_save_id)
                            .HasColumnName("ad_selectop_save_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_selectop_save>().HasKey<string>(p => p.ad_selectop_save_id);
                            modelBuilder.Entity<ad_selectop_save>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_selectop_save>()
                            .Property(p => p.ten_table)
                            .HasColumnName("ten_table")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_selectoption>().ToTable("ad_selectoption");
                        
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.ad_selectoption_id)
                            .HasColumnName("ad_selectoption_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_selectoption>().HasKey<string>(p => p.ad_selectoption_id);
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.display_member)
                            .HasColumnName("display_member")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.from_sql)
                            .HasColumnName("from_sql")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.ma_selectoption)
                            .HasColumnName("ma_selectoption")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.orderby_sql)
                            .HasColumnName("orderby_sql")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.select_sql)
                            .HasColumnName("select_sql")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.ten_selectoption)
                            .HasColumnName("ten_selectoption")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.value_selectoption)
                            .HasColumnName("value_selectoption")
                            .HasColumnType("ntext");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_selectoption>()
                            .Property(p => p.where_sql)
                            .HasColumnName("where_sql")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_status>().ToTable("ad_status");
                        
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.ad_module_id)
                            .HasColumnName("ad_module_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.ad_status_id)
                            .HasColumnName("ad_status_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_status>().HasKey<string>(p => p.ad_status_id);
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.ma_status)
                            .HasColumnName("ma_status")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.ten_status)
                            .HasColumnName("ten_status")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_status>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_systemconfig>().ToTable("ad_systemconfig");
                        
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.ad_systemconfig_id)
                            .HasColumnName("ad_systemconfig_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_systemconfig>().HasKey<string>(p => p.ad_systemconfig_id);
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.connectstring_anco)
                            .HasColumnName("connectstring_anco")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.date_import)
                            .HasColumnName("date_import")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.diachi)
                            .HasColumnName("diachi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.domain)
                            .HasColumnName("domain")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.email_hotro)
                            .HasColumnName("email_hotro")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.emailserver)
                            .HasColumnName("emailserver")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.fax)
                            .HasColumnName("fax")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.format_ngay)
                            .HasColumnName("format_ngay")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.format_so)
                            .HasColumnName("format_so")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.logo)
                            .HasColumnName("logo")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.logo_trangchu)
                            .HasColumnName("logo_trangchu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.mausac)
                            .HasColumnName("mausac")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.passemail)
                            .HasColumnName("passemail")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.phone)
                            .HasColumnName("phone")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.port)
                            .HasColumnName("port")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.soluong_grid)
                            .HasColumnName("soluong_grid")
                            .HasColumnType("int");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.soluong_grid_2)
                            .HasColumnName("soluong_grid_2")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.taikhoanemail)
                            .HasColumnName("taikhoanemail")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.ten_canhbao)
                            .HasColumnName("ten_canhbao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.ten_connectstring)
                            .HasColumnName("ten_connectstring")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.ten_db)
                            .HasColumnName("ten_db")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.ten_linq)
                            .HasColumnName("ten_linq")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.tencongty)
                            .HasColumnName("tencongty")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.url_lichtuan)
                            .HasColumnName("url_lichtuan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.url_linq)
                            .HasColumnName("url_linq")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_systemconfig>()
                            .Property(p => p.website)
                            .HasColumnName("website")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_table_manager>().ToTable("ad_table_manager");
                        
                            modelBuilder.Entity<ad_table_manager>()
                            .Property(p => p.ad_table_manager_id)
                            .HasColumnName("ad_table_manager_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_table_manager>().HasKey<string>(p => p.ad_table_manager_id);
                            modelBuilder.Entity<ad_table_manager>()
                            .Property(p => p.data_core)
                            .HasColumnName("data_core")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_table_manager>()
                            .Property(p => p.delete_data)
                            .HasColumnName("delete_data")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_table_manager>()
                            .Property(p => p.system)
                            .HasColumnName("system")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_table_manager>()
                            .Property(p => p.table_name)
                            .HasColumnName("table_name")
                            .HasColumnType("varchar");
                    
                        modelBuilder.Entity<ad_user>().ToTable("ad_user");
                        
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.ad_role_id)
                            .HasColumnName("ad_role_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.ad_user_id)
                            .HasColumnName("ad_user_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user>().HasKey<string>(p => p.ad_user_id);
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.diachi)
                            .HasColumnName("diachi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.duyet_sms)
                            .HasColumnName("duyet_sms")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.email)
                            .HasColumnName("email")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.fax)
                            .HasColumnName("fax")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.hoten)
                            .HasColumnName("hoten")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.ma_user)
                            .HasColumnName("ma_user")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.matkhau)
                            .HasColumnName("matkhau")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.md_phongban_id)
                            .HasColumnName("md_phongban_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.phone)
                            .HasColumnName("phone")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<ad_user_role>().ToTable("ad_user_role");
                        
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.ad_role_id)
                            .HasColumnName("ad_role_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.ad_user_id)
                            .HasColumnName("ad_user_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.ad_user_role_id)
                            .HasColumnName("ad_user_role_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user_role>().HasKey<string>(p => p.ad_user_role_id);
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.macdinh)
                            .HasColumnName("macdinh")
                            .HasColumnType("bit");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.md_phongban_id)
                            .HasColumnName("md_phongban_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<ad_user_role>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<c_danhsachdathang>().ToTable("c_danhsachdathang");
                        
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.c_danhsachdathang_id)
                            .HasColumnName("c_danhsachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>().HasKey<string>(p => p.c_danhsachdathang_id);
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.c_donhang_id)
                            .HasColumnName("c_donhang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.check_nangluc)
                            .HasColumnName("check_nangluc")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.dg_nangluc)
                            .HasColumnName("dg_nangluc")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.diachigiaohang)
                            .HasColumnName("diachigiaohang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.discount)
                            .HasColumnName("discount")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.grandtotal)
                            .HasColumnName("grandtotal")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.hangiaohang_po)
                            .HasColumnName("hangiaohang_po")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.huongdanlamhang)
                            .HasColumnName("huongdanlamhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.huongdanlamhangchung)
                            .HasColumnName("huongdanlamhangchung")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.isgui_hdlh)
                            .HasColumnName("isgui_hdlh")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.khachhang)
                            .HasColumnName("khachhang")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.md_trangthai_id)
                            .HasColumnName("md_trangthai_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.ngay_tigia)
                            .HasColumnName("ngay_tigia")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.ngaybatdau)
                            .HasColumnName("ngaybatdau")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.ngayhoanthanh)
                            .HasColumnName("ngayhoanthanh")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.ngaylap)
                            .HasColumnName("ngaylap")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.nguoi_dathang)
                            .HasColumnName("nguoi_dathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.nguoi_phutrach)
                            .HasColumnName("nguoi_phutrach")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.so_po)
                            .HasColumnName("so_po")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.thoigiansx)
                            .HasColumnName("thoigiansx")
                            .HasColumnType("int");
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.total)
                            .HasColumnName("total")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_danhsachdathang>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<c_danhsachdathang_nangluc>().ToTable("c_danhsachdathang_nangluc");
                        
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.c_danhsachdathang_id)
                            .HasColumnName("c_danhsachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.c_danhsachdathang_nangluc_id)
                            .HasColumnName("c_danhsachdathang_nangluc_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang_nangluc>().HasKey<string>(p => p.c_danhsachdathang_nangluc_id);
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.CBMdatduoc)
                            .HasColumnName("CBMdatduoc")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.danhgia)
                            .HasColumnName("danhgia")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.dauma)
                            .HasColumnName("dauma")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.thoigiandukien)
                            .HasColumnName("thoigiandukien")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.thoigianyeucau)
                            .HasColumnName("thoigianyeucau")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.tongCBM)
                            .HasColumnName("tongCBM")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_danhsachdathang_nangluc>()
                            .Property(p => p.tuanthu)
                            .HasColumnName("tuanthu")
                            .HasColumnType("int");
                    
                        modelBuilder.Entity<c_doichieuhangton>().ToTable("c_doichieuhangton");
                        
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.c_danhsachdathang_id)
                            .HasColumnName("c_danhsachdathang_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.c_doichieuhangton_id)
                            .HasColumnName("c_doichieuhangton_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton>().HasKey<string>(p => p.c_doichieuhangton_id);
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.doichieuht)
                            .HasColumnName("doichieuht")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.kehoach)
                            .HasColumnName("kehoach")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.ngayhoanthanh)
                            .HasColumnName("ngayhoanthanh")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.ngaykehoach)
                            .HasColumnName("ngaykehoach")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.phieuhangton)
                            .HasColumnName("phieuhangton")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.phieutonkho)
                            .HasColumnName("phieutonkho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.so_donhang)
                            .HasColumnName("so_donhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.ten_donhang)
                            .HasColumnName("ten_donhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<c_doichieuhangton_cddh>().ToTable("c_doichieuhangton_cddh");
                        
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.c_doichieuhangton_cddh_id)
                            .HasColumnName("c_doichieuhangton_cddh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>().HasKey<string>(p => p.c_doichieuhangton_cddh_id);
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.c_doichieuhangton_id)
                            .HasColumnName("c_doichieuhangton_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.mota_tienganh)
                            .HasColumnName("mota_tienganh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.mota_tiengviet)
                            .HasColumnName("mota_tiengviet")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.sl_dathang)
                            .HasColumnName("sl_dathang")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_cddh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<c_doichieuhangton_dkdh>().ToTable("c_doichieuhangton_dkdh");
                        
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.c_doichieuhangton_dkdh_id)
                            .HasColumnName("c_doichieuhangton_dkdh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>().HasKey<string>(p => p.c_doichieuhangton_dkdh_id);
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.c_doichieuhangton_id)
                            .HasColumnName("c_doichieuhangton_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.issanpham)
                            .HasColumnName("issanpham")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.macuoi)
                            .HasColumnName("macuoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.macuoi_id)
                            .HasColumnName("macuoi_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.phukien)
                            .HasColumnName("phukien")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.sl_conlai)
                            .HasColumnName("sl_conlai")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.sl_dat)
                            .HasColumnName("sl_dat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.sl_dathang)
                            .HasColumnName("sl_dathang")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.sl_dathang_cp)
                            .HasColumnName("sl_dathang_cp")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dkdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<c_doichieuhangton_dklht>().ToTable("c_doichieuhangton_dklht");
                        
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.c_doichieuhangton_dklht_id)
                            .HasColumnName("c_doichieuhangton_dklht_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>().HasKey<string>(p => p.c_doichieuhangton_dklht_id);
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.c_doichieuhangton_id)
                            .HasColumnName("c_doichieuhangton_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.issanpham)
                            .HasColumnName("issanpham")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.macuoi)
                            .HasColumnName("macuoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.macuoi_id)
                            .HasColumnName("macuoi_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.makho)
                            .HasColumnName("makho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.mota_tienganh)
                            .HasColumnName("mota_tienganh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.mota_tiengviet)
                            .HasColumnName("mota_tiengviet")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.sl_conlai)
                            .HasColumnName("sl_conlai")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.sl_dalay)
                            .HasColumnName("sl_dalay")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.sl_lay)
                            .HasColumnName("sl_lay")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_dklht>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<c_doichieuhangton_thdh>().ToTable("c_doichieuhangton_thdh");
                        
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.c_doichieuhangton_id)
                            .HasColumnName("c_doichieuhangton_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.c_doichieuhangton_thdh_id)
                            .HasColumnName("c_doichieuhangton_thdh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>().HasKey<string>(p => p.c_doichieuhangton_thdh_id);
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.sl_damua)
                            .HasColumnName("sl_damua")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.sl_dasanxuat)
                            .HasColumnName("sl_dasanxuat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.sl_datmua)
                            .HasColumnName("sl_datmua")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.sl_donhang)
                            .HasColumnName("sl_donhang")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.sl_layhangton)
                            .HasColumnName("sl_layhangton")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.sl_sanxuat)
                            .HasColumnName("sl_sanxuat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.sl_thieu)
                            .HasColumnName("sl_thieu")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_thdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<c_doichieuhangton_tk>().ToTable("c_doichieuhangton_tk");
                        
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.c_doichieuhangton_id)
                            .HasColumnName("c_doichieuhangton_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.c_doichieuhangton_tk_id)
                            .HasColumnName("c_doichieuhangton_tk_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>().HasKey<string>(p => p.c_doichieuhangton_tk_id);
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.inbaocao)
                            .HasColumnName("inbaocao")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.macuoi)
                            .HasColumnName("macuoi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.macuoi_id)
                            .HasColumnName("macuoi_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.makho)
                            .HasColumnName("makho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.mota_tienganh)
                            .HasColumnName("mota_tienganh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.mota_tiengviet)
                            .HasColumnName("mota_tiengviet")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.sanpham)
                            .HasColumnName("sanpham")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.sl_conlai)
                            .HasColumnName("sl_conlai")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.sl_dathang)
                            .HasColumnName("sl_dathang")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.sl_giucho)
                            .HasColumnName("sl_giucho")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.sl_trongkho)
                            .HasColumnName("sl_trongkho")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.tachbom)
                            .HasColumnName("tachbom")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tk>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<c_doichieuhangton_tkkd>().ToTable("c_doichieuhangton_tkkd");
                        
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.c_doichieuhangton_id)
                            .HasColumnName("c_doichieuhangton_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.c_doichieuhangton_tkkd_id)
                            .HasColumnName("c_doichieuhangton_tkkd_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>().HasKey<string>(p => p.c_doichieuhangton_tkkd_id);
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.kieudang)
                            .HasColumnName("kieudang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_doichieuhangton_tkkd>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<c_dongdsdh>().ToTable("c_dongdsdh");
                        
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.c_danhsachdathang_id)
                            .HasColumnName("c_danhsachdathang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.c_dongdonhang_id)
                            .HasColumnName("c_dongdonhang_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.c_dongdsdh_id)
                            .HasColumnName("c_dongdsdh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>().HasKey<string>(p => p.c_dongdsdh_id);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.dvt_inner)
                            .HasColumnName("dvt_inner")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.dvt_outer)
                            .HasColumnName("dvt_outer")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.ghichu_vachngan)
                            .HasColumnName("ghichu_vachngan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.gianhap)
                            .HasColumnName("gianhap")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.h1)
                            .HasColumnName("h1")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.h2)
                            .HasColumnName("h2")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.han_giaohang)
                            .HasColumnName("han_giaohang")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.huongdan_dathang)
                            .HasColumnName("huongdan_dathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.l1)
                            .HasColumnName("l1")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.l2)
                            .HasColumnName("l2")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.ma_sanpham_khach)
                            .HasColumnName("ma_sanpham_khach")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.md_donggoi_id)
                            .HasColumnName("md_donggoi_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.md_sanpham_bom_id)
                            .HasColumnName("md_sanpham_bom_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.mota_tienganh)
                            .HasColumnName("mota_tienganh")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.mota_tiengviet)
                            .HasColumnName("mota_tiengviet")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.sl_conlai)
                            .HasColumnName("sl_conlai")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.sl_cont)
                            .HasColumnName("sl_cont")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.sl_dagiao)
                            .HasColumnName("sl_dagiao")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.sl_dathang)
                            .HasColumnName("sl_dathang")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.sl_giamhanngach)
                            .HasColumnName("sl_giamhanngach")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.sl_hanngach)
                            .HasColumnName("sl_hanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.sl_huy)
                            .HasColumnName("sl_huy")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.sl_inner)
                            .HasColumnName("sl_inner")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.sl_outer)
                            .HasColumnName("sl_outer")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.sothutu)
                            .HasColumnName("sothutu")
                            .HasColumnType("int");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.tem_dan)
                            .HasColumnName("tem_dan")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.v2)
                            .HasColumnName("v2")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.vd)
                            .HasColumnName("vd")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.vl)
                            .HasColumnName("vl")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.vn)
                            .HasColumnName("vn")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.w1)
                            .HasColumnName("w1")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<c_dongdsdh>()
                            .Property(p => p.w2)
                            .HasColumnName("w2")
                            .HasColumnType("numeric").HasPrecision(18, 4);
                    
                        modelBuilder.Entity<c_donmuahang>().ToTable("c_donmuahang");
                        
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.bosung)
                            .HasColumnName("bosung")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.c_donmuahang_id)
                            .HasColumnName("c_donmuahang_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>().HasKey<string>(p => p.c_donmuahang_id);
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.c_kehoachdathang_dhncc_id)
                            .HasColumnName("c_kehoachdathang_dhncc_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.c_kehoachmuavt_id)
                            .HasColumnName("c_kehoachmuavt_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.chu_tong_tatca)
                            .HasColumnName("chu_tong_tatca")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.chu_tong_tienhang)
                            .HasColumnName("chu_tong_tienhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.diadiem_giaohang)
                            .HasColumnName("diadiem_giaohang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.huongdan_lamhang)
                            .HasColumnName("huongdan_lamhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.md_banggia_id)
                            .HasColumnName("md_banggia_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.md_dongtien_id)
                            .HasColumnName("md_dongtien_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.md_phienbangia_id)
                            .HasColumnName("md_phienbangia_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.md_trangthai_id)
                            .HasColumnName("md_trangthai_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.ngaydonhang)
                            .HasColumnName("ngaydonhang")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.ngaygiaohang)
                            .HasColumnName("ngaygiaohang")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.nguoilienhe)
                            .HasColumnName("nguoilienhe")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.phieunhapkho)
                            .HasColumnName("phieunhapkho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.phieuXNNK)
                            .HasColumnName("phieuXNNK")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.sctkehoach)
                            .HasColumnName("sctkehoach")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.tong_tatca)
                            .HasColumnName("tong_tatca")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.tong_tienhang)
                            .HasColumnName("tong_tienhang")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.tygiaVND)
                            .HasColumnName("tygiaVND")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<c_donmuahang_cdmh>().ToTable("c_donmuahang_cdmh");
                        
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.c_donmuahang_cdmh_id)
                            .HasColumnName("c_donmuahang_cdmh_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>().HasKey<string>(p => p.c_donmuahang_cdmh_id);
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.c_donmuahang_id)
                            .HasColumnName("c_donmuahang_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.dongiamua)
                            .HasColumnName("dongiamua")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.giachuan)
                            .HasColumnName("giachuan")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.ngay_hethan)
                            .HasColumnName("ngay_hethan")
                            .HasColumnType("date");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.saiso)
                            .HasColumnName("saiso")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.sl_dadat)
                            .HasColumnName("sl_dadat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.sl_dadat2)
                            .HasColumnName("sl_dadat2")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.sl_hanngach)
                            .HasColumnName("sl_hanngach")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.thanhtien)
                            .HasColumnName("thanhtien")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.thue)
                            .HasColumnName("thue")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<c_donmuahang_cdmh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
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
                    
                        modelBuilder.Entity<md_baotrivthh>().ToTable("md_baotrivthh");
                        
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
                            .Property(p => p.md_baotrivthh_id)
                            .HasColumnName("md_baotrivthh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh>().HasKey<string>(p => p.md_baotrivthh_id);
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
                            .Property(p => p.md_baotrivthh_cdh_id)
                            .HasColumnName("md_baotrivthh_cdh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_baotrivthh_cdh>().HasKey<string>(p => p.md_baotrivthh_cdh_id);
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
                            .Property(p => p.md_bo_id)
                            .HasColumnName("md_bo_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo>().HasKey<string>(p => p.md_bo_id);
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
                            .Property(p => p.ghichu)
                            .HasColumnName("ghichu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo_chitiet>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_bo_chitiet>()
                            .Property(p => p.md_bo_chitiet_id)
                            .HasColumnName("md_bo_chitiet_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_bo_chitiet>().HasKey<string>(p => p.md_bo_chitiet_id);
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
                            .Property(p => p.md_cangbien_id)
                            .HasColumnName("md_cangbien_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_cangbien>().HasKey<string>(p => p.md_cangbien_id);
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
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.code_cl)
                            .HasColumnName("code_cl")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_chungloai>()
                            .Property(p => p.md_chungloai_id)
                            .HasColumnName("md_chungloai_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_chungloai>().HasKey<string>(p => p.md_chungloai_id);
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
                    
                        modelBuilder.Entity<md_chungloai_ql>().ToTable("md_chungloai_ql");
                        
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
                            .Property(p => p.md_chungloai_ql_id)
                            .HasColumnName("md_chungloai_ql_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_chungloai_ql>().HasKey<string>(p => p.md_chungloai_ql_id);
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
                            .Property(p => p.md_congthuctrongtinhgia_id)
                            .HasColumnName("md_congthuctrongtinhgia_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia>().HasKey<string>(p => p.md_congthuctrongtinhgia_id);
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
                            .Property(p => p.md_congthuctrongtinhgia_mausac_id)
                            .HasColumnName("md_congthuctrongtinhgia_mausac_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_congthuctrongtinhgia_mausac>().HasKey<string>(p => p.md_congthuctrongtinhgia_mausac_id);
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
                            .Property(p => p.md_dbbiendong_id)
                            .HasColumnName("md_dbbiendong_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dbbiendong>().HasKey<string>(p => p.md_dbbiendong_id);
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
                    
                        modelBuilder.Entity<md_doitackinhdoanh>().ToTable("md_doitackinhdoanh");
                        
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
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
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>().HasKey<string>(p => p.md_doitackinhdoanh_id);
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
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
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
                            .HasColumnType("numeric").HasPrecision(18, 4);
                            modelBuilder.Entity<md_doitackinhdoanh>()
                            .Property(p => p.url)
                            .HasColumnName("url")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<md_dondathangphanxuong>().ToTable("md_dondathangphanxuong");
                        
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
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
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
                            .Property(p => p.md_dondathangphanxuong_id)
                            .HasColumnName("md_dondathangphanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>().HasKey<string>(p => p.md_dondathangphanxuong_id);
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
                            .Property(p => p.phieunhapkho)
                            .HasColumnName("phieunhapkho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
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
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
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
                            .Property(p => p.md_dondathangphanxuong_cdh_id)
                            .HasColumnName("md_dondathangphanxuong_cdh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_cdh>().HasKey<string>(p => p.md_dondathangphanxuong_cdh_id);
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
                            .Property(p => p.md_dondathangphanxuong_tinhhinh_id)
                            .HasColumnName("md_dondathangphanxuong_tinhhinh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_tinhhinh>().HasKey<string>(p => p.md_dondathangphanxuong_tinhhinh_id);
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
                            .Property(p => p.md_dondathangphanxuong_vattu_id)
                            .HasColumnName("md_dondathangphanxuong_vattu_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dondathangphanxuong_vattu>().HasKey<string>(p => p.md_dondathangphanxuong_vattu_id);
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
                            .Property(p => p.bieutuong)
                            .HasColumnName("bieutuong")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.ma_iso)
                            .HasColumnName("ma_iso")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.md_dongtien_id)
                            .HasColumnName("md_dongtien_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dongtien>().HasKey<string>(p => p.md_dongtien_id);
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
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_dongtien>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<md_donvitinh>().ToTable("md_donvitinh");
                        
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.ma_edi)
                            .HasColumnName("ma_edi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.md_donvitinh_id)
                            .HasColumnName("md_donvitinh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinh>().HasKey<string>(p => p.md_donvitinh_id);
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
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinh>()
                            .Property(p => p.ten_dvt)
                            .HasColumnName("ten_dvt")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<md_donvitinhsanpham>().ToTable("md_donvitinhsanpham");
                        
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.ma_edi)
                            .HasColumnName("ma_edi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham>().HasKey<string>(p => p.md_donvitinhsanpham_id);
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
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_donvitinhsanpham>()
                            .Property(p => p.ten_dvt)
                            .HasColumnName("ten_dvt")
                            .HasColumnType("nvarchar");
                    
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
                            .Property(p => p.md_dondathangphanxuong_id)
                            .HasColumnName("md_dondathangphanxuong_id")
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
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.ngaydkht)
                            .HasColumnName("ngaydkht")
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
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_lenhsanxuat_tosx>()
                            .Property(p => p.stt)
                            .HasColumnName("stt")
                            .HasColumnType("int");
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
                            .Property(p => p.phieuXNNK)
                            .HasColumnName("phieuXNNK")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_nhapkho_ncc>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
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
                            .Property(p => p.STT)
                            .HasColumnName("STT")
                            .HasColumnType("int");
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
                    
                        modelBuilder.Entity<md_quocgia>().ToTable("md_quocgia");
                        
                            modelBuilder.Entity<md_quocgia>()
                            .Property(p => p.anco_check)
                            .HasColumnName("anco_check")
                            .HasColumnType("bit");
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
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_sanpham>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
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
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_tygia>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("nvarchar");
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
                            .Property(p => p.loaichuyen)
                            .HasColumnName("loaichuyen")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vanchuyennoibo>()
                            .Property(p => p.loaichuyen_id)
                            .HasColumnName("loaichuyen_id")
                            .HasColumnType("varchar");
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
                            .Property(p => p.dachuyenhet)
                            .HasColumnName("dachuyenhet")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.denkho)
                            .HasColumnName("denkho")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_vanchuyennoibo_cdvc>()
                            .Property(p => p.lsx_to)
                            .HasColumnName("lsx_to")
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
                    
                        modelBuilder.Entity<md_vattutrongtinhbom>().ToTable("md_vattutrongtinhbom");
                        
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.md_vattutrongtinhbom_id)
                            .HasColumnName("md_vattutrongtinhbom_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>().HasKey<string>(p => p.md_vattutrongtinhbom_id);
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.sapxep)
                            .HasColumnName("sapxep")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_vattutrongtinhbom>()
                            .Property(p => p.vattu_value)
                            .HasColumnName("vattu_value")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<md_xuatban>().ToTable("md_xuatban");
                        
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.c_danhsachdathang_id)
                            .HasColumnName("c_danhsachdathang_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.diachi)
                            .HasColumnName("diachi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.md_xuatban_id)
                            .HasColumnName("md_xuatban_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>().HasKey<string>(p => p.md_xuatban_id);
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.ngaychuyen)
                            .HasColumnName("ngaychuyen")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.ngaydonhang)
                            .HasColumnName("ngaydonhang")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.phieuXNNK)
                            .HasColumnName("phieuXNNK")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.tukho)
                            .HasColumnName("tukho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban>()
                            .Property(p => p.xuat_thanhly)
                            .HasColumnName("xuat_thanhly")
                            .HasColumnType("int");
                    
                        modelBuilder.Entity<md_xuatban_cdh>().ToTable("md_xuatban_cdh");
                        
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.check_kho)
                            .HasColumnName("check_kho")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.ghichu_donvi2)
                            .HasColumnName("ghichu_donvi2")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.md_xuatban_cdh_id)
                            .HasColumnName("md_xuatban_cdh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban_cdh>().HasKey<string>(p => p.md_xuatban_cdh_id);
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.md_xuatban_id)
                            .HasColumnName("md_xuatban_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.sl_daxuat)
                            .HasColumnName("sl_daxuat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.sl_muonxuat)
                            .HasColumnName("sl_muonxuat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.sl_xuat)
                            .HasColumnName("sl_xuat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.tenhang)
                            .HasColumnName("tenhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.tong_sl_xuat)
                            .HasColumnName("tong_sl_xuat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.tukho)
                            .HasColumnName("tukho")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatban_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<md_xuatkhonb>().ToTable("md_xuatkhonb");
                        
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.banggiaNC)
                            .HasColumnName("banggiaNC")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.baotri_vattu)
                            .HasColumnName("baotri_vattu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.bosung)
                            .HasColumnName("bosung")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.chungtu_lenhsx)
                            .HasColumnName("chungtu_lenhsx")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.chungtuthamchieu)
                            .HasColumnName("chungtuthamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.diachi)
                            .HasColumnName("diachi")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.donhang_thamchieu)
                            .HasColumnName("donhang_thamchieu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.kh_ddhpx)
                            .HasColumnName("kh_ddhpx")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.khuon)
                            .HasColumnName("khuon")
                            .HasColumnType("int");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.md_doitackinhdoanh_id)
                            .HasColumnName("md_doitackinhdoanh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.md_lenhsanxuat_id)
                            .HasColumnName("md_lenhsanxuat_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.md_lenhsanxuat_tosx_id)
                            .HasColumnName("md_lenhsanxuat_tosx_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.md_phanxuong_id)
                            .HasColumnName("md_phanxuong_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.md_to_id)
                            .HasColumnName("md_to_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.md_xuatkhonb_id)
                            .HasColumnName("md_xuatkhonb_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>().HasKey<string>(p => p.md_xuatkhonb_id);
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.ngaychuyen)
                            .HasColumnName("ngaychuyen")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.phienbangiaNC)
                            .HasColumnName("phienbangiaNC")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.phieuXNNK)
                            .HasColumnName("phieuXNNK")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.sctdathang)
                            .HasColumnName("sctdathang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.sochungtu)
                            .HasColumnName("sochungtu")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.trangthai)
                            .HasColumnName("trangthai")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.tukho)
                            .HasColumnName("tukho")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb>()
                            .Property(p => p.xuatden)
                            .HasColumnName("xuatden")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<md_xuatkhonb_cdh>().ToTable("md_xuatkhonb_cdh");
                        
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.check_kho)
                            .HasColumnName("check_kho")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.dangno)
                            .HasColumnName("dangno")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.ghichu_donvi2)
                            .HasColumnName("ghichu_donvi2")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.ghino)
                            .HasColumnName("ghino")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.lsx_to)
                            .HasColumnName("lsx_to")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.md_donvitinhsanpham_id)
                            .HasColumnName("md_donvitinhsanpham_id")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.md_donvitinhsanpham_id2)
                            .HasColumnName("md_donvitinhsanpham_id2")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.md_kho_id)
                            .HasColumnName("md_kho_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.md_xuatkhonb_cdh_id)
                            .HasColumnName("md_xuatkhonb_cdh_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>().HasKey<string>(p => p.md_xuatkhonb_cdh_id);
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.md_xuatkhonb_id)
                            .HasColumnName("md_xuatkhonb_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.saiso)
                            .HasColumnName("saiso")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.sl_daxuat)
                            .HasColumnName("sl_daxuat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.sl_muonxuat)
                            .HasColumnName("sl_muonxuat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.sl_thucxuat)
                            .HasColumnName("sl_thucxuat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.sl_toida_trongLSXTo)
                            .HasColumnName("sl_toida_trongLSXTo")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.sl_toida_trongLSXTo2)
                            .HasColumnName("sl_toida_trongLSXTo2")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.sl_xuat)
                            .HasColumnName("sl_xuat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.sl_xuat2)
                            .HasColumnName("sl_xuat2")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.tenhang)
                            .HasColumnName("tenhang")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.tong_sl_xuat)
                            .HasColumnName("tong_sl_xuat")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.truno)
                            .HasColumnName("truno")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_cdh>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                        modelBuilder.Entity<md_xuatkhonb_sanpham>().ToTable("md_xuatkhonb_sanpham");
                        
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.bophancapnhat)
                            .HasColumnName("bophancapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.bophantao)
                            .HasColumnName("bophantao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.hoatdong)
                            .HasColumnName("hoatdong")
                            .HasColumnType("bit");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.md_sanpham_id)
                            .HasColumnName("md_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.md_xuatkhonb_id)
                            .HasColumnName("md_xuatkhonb_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.md_xuatkhonb_sanpham_id)
                            .HasColumnName("md_xuatkhonb_sanpham_id")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>().HasKey<string>(p => p.md_xuatkhonb_sanpham_id);
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.mota)
                            .HasColumnName("mota")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.ngaycapnhat)
                            .HasColumnName("ngaycapnhat")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.ngaytao)
                            .HasColumnName("ngaytao")
                            .HasColumnType("datetime");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.nguoicapnhat)
                            .HasColumnName("nguoicapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.nguoitao)
                            .HasColumnName("nguoitao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.soluong)
                            .HasColumnName("soluong")
                            .HasColumnType("decimal").HasPrecision(18, 4);
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.vaitrocapnhat)
                            .HasColumnName("vaitrocapnhat")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.vaitrotao)
                            .HasColumnName("vaitrotao")
                            .HasColumnType("varchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.value_bophancapnhat)
                            .HasColumnName("value_bophancapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.value_bophantao)
                            .HasColumnName("value_bophantao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.value_nguoicapnhat)
                            .HasColumnName("value_nguoicapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.value_nguoitao)
                            .HasColumnName("value_nguoitao")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.value_vaitrocapnhat)
                            .HasColumnName("value_vaitrocapnhat")
                            .HasColumnType("nvarchar");
                            modelBuilder.Entity<md_xuatkhonb_sanpham>()
                            .Property(p => p.value_vaitrotao)
                            .HasColumnName("value_vaitrotao")
                            .HasColumnType("nvarchar");
                    
                    }
                }
            }
            