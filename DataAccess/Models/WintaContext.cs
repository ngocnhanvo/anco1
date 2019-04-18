
            using System;
            using Microsoft.EntityFrameworkCore;
            using Microsoft.EntityFrameworkCore.Metadata;
            using DataAcess.StoredProcedure;
            namespace DataAcess
            {
                public partial class WintaContext : DbContext
                {
                    public WintaContext(DbContextOptions<WintaContext> options): base(options)
                    {
                    }

                    
                    //Unable to generate DBset for table 'dbo.DM_BAN'. table have no primary key
                
                    public virtual DbSet<DM_BARCODE> DM_BARCODE { get; set; }
                    
                    public virtual DbSet<DM_CA_LV> DM_CA_LV { get; set; }
                    
                    public virtual DbSet<DM_CacKhoanBT> DM_CacKhoanBT { get; set; }
                    
                    public virtual DbSet<DM_CAP_PHAT_TS> DM_CAP_PHAT_TS { get; set; }
                    
                    public virtual DbSet<DM_CHI_NHANH> DM_CHI_NHANH { get; set; }
                    
                    public virtual DbSet<DM_CHIPHI> DM_CHIPHI { get; set; }
                    
                    public virtual DbSet<DM_CHUNG_KHAC> DM_CHUNG_KHAC { get; set; }
                    
                    public virtual DbSet<DM_CHUNG_TU> DM_CHUNG_TU { get; set; }
                    
                    public virtual DbSet<DM_DUAN> DM_DUAN { get; set; }
                    
                    public virtual DbSet<DM_DUAN_CT> DM_DUAN_CT { get; set; }
                    
                    public virtual DbSet<DM_DVT> DM_DVT { get; set; }
                    
                    public virtual DbSet<DM_HOPDONG_NVI> DM_HOPDONG_NVI { get; set; }
                    
                    public virtual DbSet<DM_KETCHUYEN> DM_KETCHUYEN { get; set; }
                    
                    public virtual DbSet<DM_KHACHHANG> DM_KHACHHANG { get; set; }
                    
                    public virtual DbSet<DM_KHEN_THUONG> DM_KHEN_THUONG { get; set; }
                    
                    public virtual DbSet<DM_KHOHANG> DM_KHOHANG { get; set; }
                    
                    public virtual DbSet<DM_KHUVUC> DM_KHUVUC { get; set; }
                    
                    public virtual DbSet<DM_LOAI_THE> DM_LOAI_THE { get; set; }
                    
                    public virtual DbSet<DM_LOTDATE> DM_LOTDATE { get; set; }
                    
                    public virtual DbSet<DM_NGHANH> DM_NGHANH { get; set; }
                    
                    public virtual DbSet<DM_NGHIEPVU> DM_NGHIEPVU { get; set; }
                    
                    public virtual DbSet<DM_NHANVIEN> DM_NHANVIEN { get; set; }
                    
                    public virtual DbSet<DM_NHAXE> DM_NHAXE { get; set; }
                    
                    public virtual DbSet<DM_PHUONGTHUCVC> DM_PHUONGTHUCVC { get; set; }
                    
                    //Unable to generate DBset for table 'dbo.DM_PTHUC TTOAN'. table have no primary key
                
                    public virtual DbSet<DM_SU_CO> DM_SU_CO { get; set; }
                    
                    public virtual DbSet<DM_TAIKHOAN> DM_TAIKHOAN { get; set; }
                    
                    public virtual DbSet<DM_TAKCHUNG> DM_TAKCHUNG { get; set; }
                    
                    public virtual DbSet<DM_THONGKE> DM_THONGKE { get; set; }
                    
                    public virtual DbSet<DM_TKNGANHANG> DM_TKNGANHANG { get; set; }
                    
                    public virtual DbSet<DM_TO_KHAI_HQ> DM_TO_KHAI_HQ { get; set; }
                    
                    public virtual DbSet<DM_TYGIA> DM_TYGIA { get; set; }
                    
                    public virtual DbSet<DM_VANDON> DM_VANDON { get; set; }
                    
                    public virtual DbSet<DM_VANDON_PMB> DM_VANDON_PMB { get; set; }
                    
                    public virtual DbSet<DM_VATTU> DM_VATTU { get; set; }
                    
                    public virtual DbSet<DM_VATTU_QD> DM_VATTU_QD { get; set; }
                    
                    public virtual DbSet<DM_VI_TRI_CV> DM_VI_TRI_CV { get; set; }
                    
                    public virtual DbSet<ImportExcel> ImportExcel { get; set; }
                    
                    public virtual DbSet<L01_FIELDS> L01_FIELDS { get; set; }
                    
                    public virtual DbSet<L02_COMMON> L02_COMMON { get; set; }
                    
                    public virtual DbSet<L04_MESSAGES> L04_MESSAGES { get; set; }
                    
                    public virtual DbSet<L06_MENU> L06_MENU { get; set; }
                    
                    public virtual DbSet<L06_REPORT> L06_REPORT { get; set; }
                    
                    public virtual DbSet<P11THU_CHI> P11THU_CHI { get; set; }
                    
                    public virtual DbSet<P12_DK_THU_CHI> P12_DK_THU_CHI { get; set; }
                    
                    public virtual DbSet<P13_CHI_TIET_DK> P13_CHI_TIET_DK { get; set; }
                    
                    public virtual DbSet<P21_NHAP_XUAT> P21_NHAP_XUAT { get; set; }
                    
                    public virtual DbSet<P22_CHI_TIET> P22_CHI_TIET { get; set; }
                    
                    public virtual DbSet<P23_CHI_TIET_FIFO> P23_CHI_TIET_FIFO { get; set; }
                    
                    public virtual DbSet<P23_DINH_KHOAN> P23_DINH_KHOAN { get; set; }
                    
                    public virtual DbSet<P31_BAN_HANG> P31_BAN_HANG { get; set; }
                    
                    public virtual DbSet<P31TMP_BAN_HANG> P31TMP_BAN_HANG { get; set; }
                    
                    public virtual DbSet<P32_CHI_TIET> P32_CHI_TIET { get; set; }
                    
                    public virtual DbSet<P32TMP_CHI_TIET> P32TMP_CHI_TIET { get; set; }
                    
                    public virtual DbSet<P33_DINH_KHOAN> P33_DINH_KHOAN { get; set; }
                    
                    public virtual DbSet<P34_CHI_TIET_VC> P34_CHI_TIET_VC { get; set; }
                    
                    public virtual DbSet<P41_SO_TONG_HOP> P41_SO_TONG_HOP { get; set; }
                    
                    public virtual DbSet<P42_CHI_TIET_TH> P42_CHI_TIET_TH { get; set; }
                    
                    public virtual DbSet<P43_CHI_TIET_TS> P43_CHI_TIET_TS { get; set; }
                    
                    public virtual DbSet<P51_BANG_GIA> P51_BANG_GIA { get; set; }
                    
                    public virtual DbSet<P52_CHI_TIET> P52_CHI_TIET { get; set; }
                    
                    public virtual DbSet<P52Detail_ChiTiet> P52Detail_ChiTiet { get; set; }
                    
                    public virtual DbSet<P53_DIEU_KIEN> P53_DIEU_KIEN { get; set; }
                    
                    //Unable to generate DBset for table 'dbo.P61 DAT PHONG'. table have no primary key
                
                    public virtual DbSet<P71_DINH_MUC> P71_DINH_MUC { get; set; }
                    
                    public virtual DbSet<P72_CHI_TIET> P72_CHI_TIET { get; set; }
                    
                    public virtual DbSet<P73_DINH_MUC_SX> P73_DINH_MUC_SX { get; set; }
                    
                    public virtual DbSet<P73_TINH_GIA_THANH> P73_TINH_GIA_THANH { get; set; }
                    
                    public virtual DbSet<P74_CONG_DOAN_SX> P74_CONG_DOAN_SX { get; set; }
                    
                    public virtual DbSet<P75_KY_TINH_GT> P75_KY_TINH_GT { get; set; }
                    
                    public virtual DbSet<P75_ZCHI_TIET_CP> P75_ZCHI_TIET_CP { get; set; }
                    
                    public virtual DbSet<P75_ZCHI_TIET_GT> P75_ZCHI_TIET_GT { get; set; }
                    
                    public virtual DbSet<P76_DT_TAP_HOP_CP> P76_DT_TAP_HOP_CP { get; set; }
                    
                    public virtual DbSet<P76_ZCHI_TIET> P76_ZCHI_TIET { get; set; }
                    
                    public virtual DbSet<P77_PHAN_BO_CP> P77_PHAN_BO_CP { get; set; }
                    
                    public virtual DbSet<P77_ZCHI_TIET_PB> P77_ZCHI_TIET_PB { get; set; }
                    
                    public virtual DbSet<P81_BIEU_THUE_TN> P81_BIEU_THUE_TN { get; set; }
                    
                    public virtual DbSet<P81_KHOAN_TN_KT> P81_KHOAN_TN_KT { get; set; }
                    
                    public virtual DbSet<P81_KY_HIEU_CCONG> P81_KY_HIEU_CCONG { get; set; }
                    
                    public virtual DbSet<P81_LOAI_BAO_HIEM> P81_LOAI_BAO_HIEM { get; set; }
                    
                    public virtual DbSet<P81_MUC_LUONG> P81_MUC_LUONG { get; set; }
                    
                    public virtual DbSet<P81_CAP_PHAT_TSNS> P81_CAP_PHAT_TSNS { get; set; }
                    
                    public virtual DbSet<P81_DC_CHI_TIET_TGNS> P81_DC_CHI_TIET_TGNS { get; set; }
                    
                    public virtual DbSet<P81_DIEU_CHINH_TGNS> P81_DIEU_CHINH_TGNS { get; set; }
                    
                    public virtual DbSet<P81_LICH_SU_LUONG> P81_LICH_SU_LUONG { get; set; }
                    
                    public virtual DbSet<P81_LICH_SU_LUONG_TMP> P81_LICH_SU_LUONG_TMP { get; set; }
                    
                    public virtual DbSet<P812_CHI_TIET> P812_CHI_TIET { get; set; }
                    
                    //Unable to generate DBset for table 'dbo.P84 KHEN THUONG KL'. table have no primary key
                
                    public virtual DbSet<P85_CHAM_CONG> P85_CHAM_CONG { get; set; }
                    
                    public virtual DbSet<P85_CHI_TIET> P85_CHI_TIET { get; set; }
                    
                    public virtual DbSet<P89_BANG_LUONG> P89_BANG_LUONG { get; set; }
                    
                    public virtual DbSet<P89_CHI_TIET> P89_CHI_TIET { get; set; }
                    
                    //Unable to generate DBset for table 'dbo.P89 LUONG CONG'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.P91 TAI SAN'. table have no primary key
                
                    public virtual DbSet<P92_CTIET_TSAN> P92_CTIET_TSAN { get; set; }
                    
                    public virtual DbSet<P93_DIEU_CHUYEN> P93_DIEU_CHUYEN { get; set; }
                    
                    public virtual DbSet<P93_ZCHI_TIET> P93_ZCHI_TIET { get; set; }
                    
                    public virtual DbSet<PALL_LENH_DX> PALL_LENH_DX { get; set; }
                    
                    public virtual DbSet<PALL_TO_KHAI_CT> PALL_TO_KHAI_CT { get; set; }
                    
                    public virtual DbSet<PALL_VAT_BAN_RA> PALL_VAT_BAN_RA { get; set; }
                    
                    public virtual DbSet<PALL_VAT_MUA_VAO> PALL_VAT_MUA_VAO { get; set; }
                    
                    public virtual DbSet<PALL_VAN_DON_CT> PALL_VAN_DON_CT { get; set; }
                    
                    public virtual DbSet<PG11_CHUNG_TU_GS> PG11_CHUNG_TU_GS { get; set; }
                    
                    public virtual DbSet<PG12_CHI_TIET> PG12_CHI_TIET { get; set; }
                    
                    //Unable to generate DBset for table 'dbo.PG21 LIST CT'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.PG21 LIST CTTH'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.PNX CHON LOT'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.PTC CHON TTOAN '. table have no primary key
                
                    public virtual DbSet<PZ11_KIEM_KE> PZ11_KIEM_KE { get; set; }
                    
                    public virtual DbSet<PZ12_CHI_TIET> PZ12_CHI_TIET { get; set; }
                    
                    public virtual DbSet<PZ21_SO_DU> PZ21_SO_DU { get; set; }
                    
                    public virtual DbSet<PZ22_CHI_TIET> PZ22_CHI_TIET { get; set; }
                    
                    public virtual DbSet<PZP_CHI_TIET> PZP_CHI_TIET { get; set; }
                    
                    public virtual DbSet<PZP_TONG_HOP> PZP_TONG_HOP { get; set; }
                    
                    //Unable to generate DBset for table 'dbo.PZR IN PLIEN'. table have no primary key
                
                    public virtual DbSet<PZT_CHI_TIET_LDX> PZT_CHI_TIET_LDX { get; set; }
                    
                    public virtual DbSet<PZT_LENH_DX> PZT_LENH_DX { get; set; }
                    
                    public virtual DbSet<R99_TEN_REPORT> R99_TEN_REPORT { get; set; }
                    
                    //Unable to generate DBset for table 'dbo.RP BAO CAO TS'. table have no primary key
                
                    public virtual DbSet<RP_BCKQKD> RP_BCKQKD { get; set; }
                    
                    public virtual DbSet<RP_BCKQKD_200> RP_BCKQKD_200 { get; set; }
                    
                    public virtual DbSet<RP_BCKQKD_48> RP_BCKQKD_48 { get; set; }
                    
                    //Unable to generate DBset for table 'dbo.RP CAN DOI PS'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP CAN DOI PS TMP'. table have no primary key
                
                    public virtual DbSet<RP_CD_KE_TOAN> RP_CD_KE_TOAN { get; set; }
                    
                    public virtual DbSet<RP_CD_KE_TOAN_200> RP_CD_KE_TOAN_200 { get; set; }
                    
                    public virtual DbSet<RP_CD_KE_TOAN_48> RP_CD_KE_TOAN_48 { get; set; }
                    
                    public virtual DbSet<RP_LUU_CHUYEN_TTE> RP_LUU_CHUYEN_TTE { get; set; }
                    
                    public virtual DbSet<RP_LUU_CHUYEN_TTE_200> RP_LUU_CHUYEN_TTE_200 { get; set; }
                    
                    //Unable to generate DBset for table 'dbo.RP NHAT KY CHUNG'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP SO CAI'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP SO CAI TONG HOP'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP THUEVAT RA'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP THUEVAT VAO'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP TRUY VAN ALL'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP11 CHI TIET'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP12SOQUY'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP21 CHI TIET'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP22 CHUNG TU'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP31 CHI TIET'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP32 CHUNG TU'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP33 BAO CAO'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP33 BAO CAO TMP'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP33_BAO_CAO_VC'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP34 THONG KE'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP35 PTBHANG '. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP35 PTBHANG TMP'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP42 CHUNG TU'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP51 CHI TIET NXT'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP51 TON KHO'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP51 TON KHO TMP'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP61 CNO CTRINH'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP61 CONG NO'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP61 CONG NO TMP'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP71 BC SAN XUAT'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP79 THE TINH GT'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP81 CHI TIET'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RP89 CHI TIET'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RPG CHUNG TU GS'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.RZP BAO CAO'. table have no primary key
                
                    public virtual DbSet<S01_USERS> S01_USERS { get; set; }
                    
                    public virtual DbSet<S02_PHANQUYEN> S02_PHANQUYEN { get; set; }
                    
                    public virtual DbSet<S02_THIETLAP> S02_THIETLAP { get; set; }
                    
                    //Unable to generate DBset for table 'dbo.S03_HISTORY'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.S04_USERLOG'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.S06_GENSET'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.S06_RESET'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.S07_DATA BACKUP'. table have no primary key
                
                    public virtual DbSet<S07_SET_HOP_DATA> S07_SET_HOP_DATA { get; set; }
                    
                    public virtual DbSet<S07_SET_HOP_SERVER> S07_SET_HOP_SERVER { get; set; }
                    
                    public virtual DbSet<S08_DK_KHOA_SO> S08_DK_KHOA_SO { get; set; }
                    
                    public virtual DbSet<S11_KIEM_TRA_DB> S11_KIEM_TRA_DB { get; set; }
                    
                    public virtual DbSet<S12_CONG_THU> S12_CONG_THU { get; set; }
                    
                    public virtual DbSet<S13_VIEW_FIELD> S13_VIEW_FIELD { get; set; }
                    
                    public virtual DbSet<S14_FILES_DATA> S14_FILES_DATA { get; set; }
                    
                    public virtual DbSet<S15_IMPORT_INFO> S15_IMPORT_INFO { get; set; }
                    
                    //Unable to generate DBset for table 'dbo.SUMTONGTMP'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.TABLE_AUTO'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.TABLETMP_AUTO'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.tempsum'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.THONG TIN DV'. table have no primary key
                
                    //Unable to generate DBset for table 'dbo.ZFILTERDATA'. table have no primary key
                
                    internal object Set()
                    {
                        throw new NotImplementedException();
                    }
                
                
                    protected override void OnModelCreating(ModelBuilder modelBuilder)
                    {
                        
                    //Unable to generate entity type for table 'dbo.DM_BAN'. table have no primary key
                    
                    modelBuilder.Entity<DM_BARCODE>(entity =>
                    {
                        entity.HasKey(e => e.IDBC);
                        entity.ToTable("DM_BARCODE");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.Barcode).HasColumnName("Barcode").HasMaxLength(50);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.IDBC).HasColumnName("IDBC");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenNhan).HasColumnName("TenNhan").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<DM_CA_LV>(entity =>
                    {
                        entity.HasKey(e => e.IDCA);
                        entity.ToTable("DM_CA_LV");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.BatDauLuc).HasColumnName("BatDauLuc").HasMaxLength(50);
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.IDCA).HasColumnName("IDCA");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.KetThucLuc).HasColumnName("KetThucLuc").HasMaxLength(50);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.MaCa).HasColumnName("MaCa").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVienPhuTrach).HasColumnName("MaNVienPhuTrach").HasMaxLength(50);
                        
                            entity.Property(e => e.NhomCa).HasColumnName("NhomCa").HasMaxLength(150);
                        
                            entity.Property(e => e.NhomCap).HasColumnName("NhomCap");
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenCa).HasColumnName("TenCa").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<DM_CacKhoanBT>(entity =>
                    {
                        entity.HasKey(e => e.IDBT);
                        entity.ToTable("DM_CacKhoanBT");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(-1);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(-1);
                        
                            entity.Property(e => e.IDBT).HasColumnName("IDBT");
                        
                            entity.Property(e => e.LoaiSC).HasColumnName("LoaiSC").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(150);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSuCo).HasColumnName("MaSuCo").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSuCoLQ).HasColumnName("MaSuCoLQ").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayNhan).HasColumnName("NgayNhan");
                        
                            entity.Property(e => e.NgayTra).HasColumnName("NgayTra");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NguonBoiThuong).HasColumnName("NguonBoiThuong").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiSayRa).HasColumnName("NoiSayRa").HasMaxLength(250);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                    });
                    
                    modelBuilder.Entity<DM_CAP_PHAT_TS>(entity =>
                    {
                        entity.HasKey(e => e.MaCP);
                        entity.ToTable("DM_CAP PHAT TS");
                        
                            entity.Property(e => e.CapPhat).HasColumnName("CapPhat");
                        
                            entity.Property(e => e.CPTSNTruong1).HasColumnName("CPTSNTruong1");
                        
                            entity.Property(e => e.CPTSNTruong2).HasColumnName("CPTSNTruong2");
                        
                            entity.Property(e => e.CPTSNTruong3).HasColumnName("CPTSNTruong3");
                        
                            entity.Property(e => e.CPTSNTruong4).HasColumnName("CPTSNTruong4");
                        
                            entity.Property(e => e.CPTSNTruong5).HasColumnName("CPTSNTruong5");
                        
                            entity.Property(e => e.CPTSSTruong1).HasColumnName("CPTSSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.CPTSSTruong2).HasColumnName("CPTSSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.CPTSSTruong3).HasColumnName("CPTSSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.CPTSSTruong4).HasColumnName("CPTSSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.CPTSSTruong5).HasColumnName("CPTSSTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.DonViCTac).HasColumnName("DonViCTac").HasMaxLength(250);
                        
                            entity.Property(e => e.FileDinhKem).HasColumnName("FileDinhKem").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(-1);
                        
                            entity.Property(e => e.GioiTinh).HasColumnName("GioiTinh").HasMaxLength(150);
                        
                            entity.Property(e => e.HinhThuc).HasColumnName("HinhThuc").HasMaxLength(100);
                        
                            entity.Property(e => e.HoVaTen).HasColumnName("HoVaTen").HasMaxLength(150);
                        
                            entity.Property(e => e.KichCo).HasColumnName("KichCo").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiCP).HasColumnName("LoaiCP").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(150);
                        
                            entity.Property(e => e.LyDo).HasColumnName("LyDo").HasMaxLength(-1);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCP).HasColumnName("MaCP").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDotCP).HasColumnName("MaDotCP").HasMaxLength(150);
                        
                            entity.Property(e => e.MaDPBHLD).HasColumnName("MaDPBHLD").HasMaxLength(200);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTS).HasColumnName("MaTS").HasMaxLength(100);
                        
                            entity.Property(e => e.MauSac).HasColumnName("MauSac").HasMaxLength(100);
                        
                            entity.Property(e => e.Ngay).HasColumnName("Ngay");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgungTheoDoi).HasColumnName("NgungTheoDoi");
                        
                            entity.Property(e => e.NhomCP).HasColumnName("NhomCP").HasMaxLength(150);
                        
                            entity.Property(e => e.NhomDPBHLD).HasColumnName("NhomDPBHLD").HasMaxLength(200);
                        
                            entity.Property(e => e.NhomTS).HasColumnName("NhomTS").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenDinhKem).HasColumnName("TenDinhKem").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDPBHLD).HasColumnName("TenDPBHLD").HasMaxLength(200);
                        
                            entity.Property(e => e.TenTS).HasColumnName("TenTS").HasMaxLength(250);
                        
                            entity.Property(e => e.TrangThai).HasColumnName("TrangThai").HasMaxLength(100);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.ViTriCViec).HasColumnName("ViTriCViec").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<DM_CHI_NHANH>(entity =>
                    {
                        entity.HasKey(e => e.IDCN);
                        entity.ToTable("DM_CHI NHANH");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CNCKTruong1).HasColumnName("CNCKTruong1");
                        
                            entity.Property(e => e.CNCKTruong2).HasColumnName("CNCKTruong2");
                        
                            entity.Property(e => e.CNCKTruong3).HasColumnName("CNCKTruong3");
                        
                            entity.Property(e => e.CNDTruong1).HasColumnName("CNDTruong1");
                        
                            entity.Property(e => e.CNDTruong2).HasColumnName("CNDTruong2");
                        
                            entity.Property(e => e.CNDTruong3).HasColumnName("CNDTruong3");
                        
                            entity.Property(e => e.CNNTruong1).HasColumnName("CNNTruong1");
                        
                            entity.Property(e => e.CNNTruong2).HasColumnName("CNNTruong2");
                        
                            entity.Property(e => e.CNNTruong3).HasColumnName("CNNTruong3");
                        
                            entity.Property(e => e.CNNTruong4).HasColumnName("CNNTruong4");
                        
                            entity.Property(e => e.CNNTruong5).HasColumnName("CNNTruong5");
                        
                            entity.Property(e => e.CNSTruong1).HasColumnName("CNSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.CNSTruong2).HasColumnName("CNSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.CNSTruong3).HasColumnName("CNSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.CNSTruong4).HasColumnName("CNSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.CNSTruong5).HasColumnName("CNSTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DienThoai).HasColumnName("DienThoai").HasMaxLength(150);
                        
                            entity.Property(e => e.Fax).HasColumnName("Fax").HasMaxLength(150);
                        
                            entity.Property(e => e.HachToanDocLap).HasColumnName("HachToanDocLap");
                        
                            entity.Property(e => e.IDCN).HasColumnName("IDCN");
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(150);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.NguoiQuanLy).HasColumnName("NguoiQuanLy").HasMaxLength(250);
                        
                            entity.Property(e => e.NhomCN).HasColumnName("NhomCN").HasMaxLength(250);
                        
                            entity.Property(e => e.Root).HasColumnName("Root");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenChiNhanh).HasColumnName("TenChiNhanh").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<DM_CHIPHI>(entity =>
                    {
                        entity.HasKey(e => e.IDCP);
                        entity.ToTable("DM_CHIPHI");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(100);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GiaBan).HasColumnName("GiaBan");
                        
                            entity.Property(e => e.IDCP).HasColumnName("IDCP");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.LaChiPhiCD).HasColumnName("LaChiPhiCD");
                        
                            entity.Property(e => e.LaNhom).HasColumnName("LaNhom");
                        
                            entity.Property(e => e.LoaiCP).HasColumnName("LoaiCP").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiCT).HasColumnName("LoaiCT").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiDV).HasColumnName("LoaiDV").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCP).HasColumnName("MaCP").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaThue).HasColumnName("MaThue").HasMaxLength(150);
                        
                            entity.Property(e => e.MaTK).HasColumnName("MaTK").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTK2).HasColumnName("MaTK2").HasMaxLength(50);
                        
                            entity.Property(e => e.NghiepVu).HasColumnName("NghiepVu").HasMaxLength(150);
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NhomCap).HasColumnName("NhomCap");
                        
                            entity.Property(e => e.NhomCP).HasColumnName("NhomCP").HasMaxLength(150);
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.PhanHe).HasColumnName("PhanHe").HasMaxLength(150);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenCP).HasColumnName("TenCP").HasMaxLength(250);
                        
                            entity.Property(e => e.ThueSuat).HasColumnName("ThueSuat");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TuDongThemQT).HasColumnName("TuDongThemQT");
                        
                            entity.Property(e => e.TuDongThemTU).HasColumnName("TuDongThemTU");
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<DM_CHUNG_KHAC>(entity =>
                    {
                        entity.HasKey(e => e.ID);
                        entity.ToTable("DM_CHUNG KHAC");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(-1);
                        
                            entity.Property(e => e.DMKCKTruong1).HasColumnName("DMKCKTruong1");
                        
                            entity.Property(e => e.DMKCKTruong2).HasColumnName("DMKCKTruong2");
                        
                            entity.Property(e => e.DMKCKTruong3).HasColumnName("DMKCKTruong3");
                        
                            entity.Property(e => e.DMKCKTruong4).HasColumnName("DMKCKTruong4");
                        
                            entity.Property(e => e.DMKCKTruong5).HasColumnName("DMKCKTruong5");
                        
                            entity.Property(e => e.DMKDTruong1).HasColumnName("DMKDTruong1");
                        
                            entity.Property(e => e.DMKDTruong2).HasColumnName("DMKDTruong2");
                        
                            entity.Property(e => e.DMKDTruong3).HasColumnName("DMKDTruong3");
                        
                            entity.Property(e => e.DMKDTruong4).HasColumnName("DMKDTruong4");
                        
                            entity.Property(e => e.DMKDTruong5).HasColumnName("DMKDTruong5");
                        
                            entity.Property(e => e.DMKNITruong1).HasColumnName("DMKNITruong1");
                        
                            entity.Property(e => e.DMKNITruong2).HasColumnName("DMKNITruong2");
                        
                            entity.Property(e => e.DMKNITruong3).HasColumnName("DMKNITruong3");
                        
                            entity.Property(e => e.DMKNITruong4).HasColumnName("DMKNITruong4");
                        
                            entity.Property(e => e.DMKNITruong5).HasColumnName("DMKNITruong5");
                        
                            entity.Property(e => e.DMKNTruong1).HasColumnName("DMKNTruong1");
                        
                            entity.Property(e => e.DMKNTruong10).HasColumnName("DMKNTruong10");
                        
                            entity.Property(e => e.DMKNTruong2).HasColumnName("DMKNTruong2");
                        
                            entity.Property(e => e.DMKNTruong3).HasColumnName("DMKNTruong3");
                        
                            entity.Property(e => e.DMKNTruong4).HasColumnName("DMKNTruong4");
                        
                            entity.Property(e => e.DMKNTruong5).HasColumnName("DMKNTruong5");
                        
                            entity.Property(e => e.DMKNTruong6).HasColumnName("DMKNTruong6");
                        
                            entity.Property(e => e.DMKNTruong7).HasColumnName("DMKNTruong7");
                        
                            entity.Property(e => e.DMKNTruong8).HasColumnName("DMKNTruong8");
                        
                            entity.Property(e => e.DMKNTruong9).HasColumnName("DMKNTruong9");
                        
                            entity.Property(e => e.DMKSTruong1).HasColumnName("DMKSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.DMKSTruong10).HasColumnName("DMKSTruong10").HasMaxLength(250);
                        
                            entity.Property(e => e.DMKSTruong2).HasColumnName("DMKSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.DMKSTruong3).HasColumnName("DMKSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.DMKSTruong4).HasColumnName("DMKSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.DMKSTruong5).HasColumnName("DMKSTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.DMKSTruong6).HasColumnName("DMKSTruong6").HasMaxLength(250);
                        
                            entity.Property(e => e.DMKSTruong7).HasColumnName("DMKSTruong7").HasMaxLength(250);
                        
                            entity.Property(e => e.DMKSTruong8).HasColumnName("DMKSTruong8").HasMaxLength(250);
                        
                            entity.Property(e => e.DMKSTruong9).HasColumnName("DMKSTruong9").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(-1);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.ID).HasColumnName("ID");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(-1);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(-1);
                        
                            entity.Property(e => e.KyHieu).HasColumnName("KyHieu").HasMaxLength(250);
                        
                            entity.Property(e => e.LCO_2_20).HasColumnName("LCO_2_20");
                        
                            entity.Property(e => e.LCO_20).HasColumnName("LCO_20");
                        
                            entity.Property(e => e.LCO_40).HasColumnName("LCO_40");
                        
                            entity.Property(e => e.LCO_45).HasColumnName("LCO_45");
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.LXE_LX01).HasColumnName("LXE_LX01");
                        
                            entity.Property(e => e.LXE_LX02).HasColumnName("LXE_LX02");
                        
                            entity.Property(e => e.LXE_LX03).HasColumnName("LXE_LX03");
                        
                            entity.Property(e => e.LXE_LX04).HasColumnName("LXE_LX04");
                        
                            entity.Property(e => e.LXE_LX05).HasColumnName("LXE_LX05");
                        
                            entity.Property(e => e.LXE_LX06).HasColumnName("LXE_LX06");
                        
                            entity.Property(e => e.LXE_LX07).HasColumnName("LXE_LX07");
                        
                            entity.Property(e => e.LXE_LX10).HasColumnName("LXE_LX10");
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNhom).HasColumnName("MaNhom").HasMaxLength(100);
                        
                            entity.Property(e => e.MoTa).HasColumnName("MoTa").HasMaxLength(-1);
                        
                            entity.Property(e => e.NoiDung).HasColumnName("NoiDung").HasMaxLength(250);
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(-1);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.SE13).HasColumnName("SE13");
                        
                            entity.Property(e => e.SoKMDN).HasColumnName("SoKMDN");
                        
                            entity.Property(e => e.SoXDDNTH).HasColumnName("SoXDDNTH");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.VaVoCA).HasColumnName("VaVoCA");
                        
                            entity.Property(e => e.VE01).HasColumnName("VE01");
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(-1);
                        
                    });
                    
                    modelBuilder.Entity<DM_CHUNG_TU>(entity =>
                    {
                        entity.HasKey(e => e.LoaiCT);
                        entity.ToTable("DM_CHUNG TU");
                        
                            entity.Property(e => e.ACTIVE).HasColumnName("ACTIVE");
                        
                            entity.Property(e => e.ChuDau).HasColumnName("ChuDau").HasMaxLength(50);
                        
                            entity.Property(e => e.DuyetChungTu).HasColumnName("DuyetChungTu");
                        
                            entity.Property(e => e.FieldCTView).HasColumnName("FieldCTView").HasMaxLength(-1);
                        
                            entity.Property(e => e.FieldDPTTK).HasColumnName("FieldDPTTK").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.KyHieuMau).HasColumnName("KyHieuMau").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiCT).HasColumnName("LoaiCT").HasMaxLength(20);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaHoaDon).HasColumnName("MaHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.MaSo).HasColumnName("MaSo").HasMaxLength(20);
                        
                            entity.Property(e => e.NhomCap).HasColumnName("NhomCap");
                        
                            entity.Property(e => e.NhomCT).HasColumnName("NhomCT").HasMaxLength(50);
                        
                            entity.Property(e => e.SetSoPhieu).HasColumnName("SetSoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.Sokytu).HasColumnName("Sokytu");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenCT).HasColumnName("TenCT").HasMaxLength(150);
                        
                            entity.Property(e => e.TenCTChinese).HasColumnName("TenCTChinese").HasMaxLength(150);
                        
                            entity.Property(e => e.TenCTFrench).HasColumnName("TenCTFrench").HasMaxLength(150);
                        
                            entity.Property(e => e.TenCTKorean).HasColumnName("TenCTKorean").HasMaxLength(150);
                        
                            entity.Property(e => e.TenCTOther).HasColumnName("TenCTOther").HasMaxLength(250);
                        
                            entity.Property(e => e.TenEnglish).HasColumnName("TenEnglish").HasMaxLength(150);
                        
                            entity.Property(e => e.TenJapanese).HasColumnName("TenJapanese").HasMaxLength(150);
                        
                            entity.Property(e => e.TKCoNgamDinh).HasColumnName("TKCoNgamDinh").HasMaxLength(30);
                        
                            entity.Property(e => e.TKNoNgamDinh).HasColumnName("TKNoNgamDinh").HasMaxLength(30);
                        
                            entity.Property(e => e.TuDongLap).HasColumnName("TuDongLap");
                        
                            entity.Property(e => e.ViewDPTTKhac).HasColumnName("ViewDPTTKhac");
                        
                    });
                    
                    modelBuilder.Entity<DM_DUAN>(entity =>
                    {
                        entity.HasKey(e => e.MaDuAn);
                        entity.ToTable("DM_DUAN");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CacDichVu).HasColumnName("CacDichVu").HasMaxLength(-1);
                        
                            entity.Property(e => e.ChucVuHD).HasColumnName("ChucVuHD").HasMaxLength(100);
                        
                            entity.Property(e => e.ChucVuMB).HasColumnName("ChucVuMB").HasMaxLength(150);
                        
                            entity.Property(e => e.ConPhaiThuHoaDon).HasColumnName("ConPhaiThuHoaDon");
                        
                            entity.Property(e => e.ConPhaiThuThucTe).HasColumnName("ConPhaiThuThucTe");
                        
                            entity.Property(e => e.DaiDienMB).HasColumnName("DaiDienMB").HasMaxLength(150);
                        
                            entity.Property(e => e.Date1).HasColumnName("Date1");
                        
                            entity.Property(e => e.Date2).HasColumnName("Date2");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DienThoaiMB).HasColumnName("DienThoaiMB").HasMaxLength(150);
                        
                            entity.Property(e => e.DMDACKTruong1).HasColumnName("DMDACKTruong1");
                        
                            entity.Property(e => e.DMDACKTruong2).HasColumnName("DMDACKTruong2");
                        
                            entity.Property(e => e.DMDACKTruong3).HasColumnName("DMDACKTruong3");
                        
                            entity.Property(e => e.DMDACKTruong4).HasColumnName("DMDACKTruong4");
                        
                            entity.Property(e => e.DMDADTruong1).HasColumnName("DMDADTruong1");
                        
                            entity.Property(e => e.DMDADTruong2).HasColumnName("DMDADTruong2");
                        
                            entity.Property(e => e.DMDADTruong3).HasColumnName("DMDADTruong3");
                        
                            entity.Property(e => e.DMDADTruong4).HasColumnName("DMDADTruong4");
                        
                            entity.Property(e => e.DMDADTruong5).HasColumnName("DMDADTruong5");
                        
                            entity.Property(e => e.DMDANTruong1).HasColumnName("DMDANTruong1");
                        
                            entity.Property(e => e.DMDANTruong2).HasColumnName("DMDANTruong2");
                        
                            entity.Property(e => e.DMDANTruong3).HasColumnName("DMDANTruong3");
                        
                            entity.Property(e => e.DMDANTruong4).HasColumnName("DMDANTruong4");
                        
                            entity.Property(e => e.DMDANTruong5).HasColumnName("DMDANTruong5");
                        
                            entity.Property(e => e.DMDASTruong1).HasColumnName("DMDASTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.DMDASTruong2).HasColumnName("DMDASTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.DMDASTruong3).HasColumnName("DMDASTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.DMDASTruong4).HasColumnName("DMDASTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.DMDASTruong5).HasColumnName("DMDASTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.DonDatHang).HasColumnName("DonDatHang").HasMaxLength(100);
                        
                            entity.Property(e => e.DuongDan).HasColumnName("DuongDan").HasMaxLength(250);
                        
                            entity.Property(e => e.DuToan).HasColumnName("DuToan");
                        
                            entity.Property(e => e.FaxMB).HasColumnName("FaxMB").HasMaxLength(150);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GiaHanDen).HasColumnName("GiaHanDen");
                        
                            entity.Property(e => e.GiaTriHopDong).HasColumnName("GiaTriHopDong");
                        
                            entity.Property(e => e.GiaTriHopDongNTe).HasColumnName("GiaTriHopDongNTe");
                        
                            entity.Property(e => e.GiaTriNThu).HasColumnName("GiaTriNThu");
                        
                            entity.Property(e => e.HanThanhToan).HasColumnName("HanThanhToan");
                        
                            entity.Property(e => e.KhuVuc).HasColumnName("KhuVuc").HasMaxLength(250);
                        
                            entity.Property(e => e.LaiGop).HasColumnName("LaiGop");
                        
                            entity.Property(e => e.LaiXuat).HasColumnName("LaiXuat");
                        
                            entity.Property(e => e.LenhDX).HasColumnName("LenhDX").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiDuAn).HasColumnName("LoaiDuAn").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiFile).HasColumnName("LoaiFile").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiLaiSuat).HasColumnName("LoaiLaiSuat").HasMaxLength(50);
                        
                            entity.Property(e => e.LyDoKT).HasColumnName("LyDoKT").HasMaxLength(250);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDTTHCP).HasColumnName("MaDTTHCP").HasMaxLength(150);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(50);
                        
                            entity.Property(e => e.MoTaCongViec).HasColumnName("MoTaCongViec").HasMaxLength(-1);
                        
                            entity.Property(e => e.MoTaKhachHang).HasColumnName("MoTaKhachHang").HasMaxLength(-1);
                        
                            entity.Property(e => e.NgayBatDau).HasColumnName("NgayBatDau");
                        
                            entity.Property(e => e.NgayBOB).HasColumnName("NgayBOB");
                        
                            entity.Property(e => e.NgayDonHang).HasColumnName("NgayDonHang");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayHopDong).HasColumnName("NgayHopDong");
                        
                            entity.Property(e => e.NgayKyHopDong).HasColumnName("NgayKyHopDong");
                        
                            entity.Property(e => e.NgayTatToan).HasColumnName("NgayTatToan");
                        
                            entity.Property(e => e.NguoiKyHD).HasColumnName("NguoiKyHD").HasMaxLength(100);
                        
                            entity.Property(e => e.NhomDuAn).HasColumnName("NhomDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.NoiDung).HasColumnName("NoiDung").HasMaxLength(-1);
                        
                            entity.Property(e => e.NoiDungDA).HasColumnName("NoiDungDA").HasMaxLength(-1);
                        
                            entity.Property(e => e.Number1).HasColumnName("Number1");
                        
                            entity.Property(e => e.Number2).HasColumnName("Number2");
                        
                            entity.Property(e => e.Number3).HasColumnName("Number3");
                        
                            entity.Property(e => e.PhuongThucThanhToan).HasColumnName("PhuongThucThanhToan").HasMaxLength(250);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.SoBienNhan).HasColumnName("SoBienNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.SoHD).HasColumnName("SoHD").HasMaxLength(100);
                        
                            entity.Property(e => e.SoNgayThucHien).HasColumnName("SoNgayThucHien");
                        
                            entity.Property(e => e.SoTienBienNhan).HasColumnName("SoTienBienNhan");
                        
                            entity.Property(e => e.SoTienHD).HasColumnName("SoTienHD");
                        
                            entity.Property(e => e.TaiKhoan).HasColumnName("TaiKhoan").HasMaxLength(50);
                        
                            entity.Property(e => e.TaiNH).HasColumnName("TaiNH").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDuAn).HasColumnName("TenDuAn").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenFile).HasColumnName("TenFile").HasMaxLength(250);
                        
                            entity.Property(e => e.TenKH).HasColumnName("TenKH").HasMaxLength(250);
                        
                            entity.Property(e => e.TenLoai).HasColumnName("TenLoai").HasMaxLength(250);
                        
                            entity.Property(e => e.Text1).HasColumnName("Text1").HasMaxLength(250);
                        
                            entity.Property(e => e.Text2).HasColumnName("Text2").HasMaxLength(250);
                        
                            entity.Property(e => e.Text3).HasColumnName("Text3").HasMaxLength(250);
                        
                            entity.Property(e => e.TheoDoiGT).HasColumnName("TheoDoiGT");
                        
                            entity.Property(e => e.ThucHienDenNgay).HasColumnName("ThucHienDenNgay");
                        
                            entity.Property(e => e.ThucHienTuNgay).HasColumnName("ThucHienTuNgay");
                        
                            entity.Property(e => e.TienLai).HasColumnName("TienLai");
                        
                            entity.Property(e => e.TinhTrangDuAn).HasColumnName("TinhTrangDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.TongChiPhi).HasColumnName("TongChiPhi");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.XuatHoaDon).HasColumnName("XuatHoaDon");
                        
                    });
                    
                    modelBuilder.Entity<DM_DUAN_CT>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("DM_DUAN_CT");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.DonDatHang).HasColumnName("DonDatHang").HasMaxLength(100);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.DonGiaNT).HasColumnName("DonGiaNT");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(-1);
                        
                            entity.Property(e => e.GiaMuaMoi).HasColumnName("GiaMuaMoi");
                        
                            entity.Property(e => e.GiaTriDGHT).HasColumnName("GiaTriDGHT");
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.LoaiCT).HasColumnName("LoaiCT").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKho2).HasColumnName("MaKho2").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(250);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(100);
                        
                            entity.Property(e => e.MoTa).HasColumnName("MoTa").HasMaxLength(-1);
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NgoaiTeCK).HasColumnName("NgoaiTeCK");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoLuongDG).HasColumnName("SoLuongDG");
                        
                            entity.Property(e => e.SoLuongYC).HasColumnName("SoLuongYC");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(-1);
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TienVNDCK).HasColumnName("TienVNDCK");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyLeCK).HasColumnName("TyLeCK");
                        
                    });
                    
                    modelBuilder.Entity<DM_DVT>(entity =>
                    {
                        entity.HasKey(e => e.IDDVT);
                        entity.ToTable("DM_DVT");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDDVT).HasColumnName("IDDVT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenDVT).HasColumnName("TenDVT").HasMaxLength(50);
                        
                    });
                    
                    modelBuilder.Entity<DM_HOPDONG_NVI>(entity =>
                    {
                        entity.HasKey(e => e.IDHD);
                        entity.ToTable("DM_HOPDONG_NVI");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.ChucDanh).HasColumnName("ChucDanh").HasMaxLength(100);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DonViCTac).HasColumnName("DonViCTac").HasMaxLength(100);
                        
                            entity.Property(e => e.FileDinhKem).HasColumnName("FileDinhKem").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(100);
                        
                            entity.Property(e => e.HDNVNTruong1).HasColumnName("HDNVNTruong1");
                        
                            entity.Property(e => e.HDNVNTruong2).HasColumnName("HDNVNTruong2");
                        
                            entity.Property(e => e.HDNVNTruong3).HasColumnName("HDNVNTruong3");
                        
                            entity.Property(e => e.HDNVNTruong4).HasColumnName("HDNVNTruong4");
                        
                            entity.Property(e => e.HDNVNTruong5).HasColumnName("HDNVNTruong5");
                        
                            entity.Property(e => e.HDNVSTruong1).HasColumnName("HDNVSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.HDNVSTruong2).HasColumnName("HDNVSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.HDNVSTruong3).HasColumnName("HDNVSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.HDNVSTruong4).HasColumnName("HDNVSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.HDNVSTruong5).HasColumnName("HDNVSTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.HinhThucLViec).HasColumnName("HinhThucLViec").HasMaxLength(100);
                        
                            entity.Property(e => e.HoTenNLD).HasColumnName("HoTenNLD").HasMaxLength(100);
                        
                            entity.Property(e => e.IDHD).HasColumnName("IDHD");
                        
                            entity.Property(e => e.LoaiHD).HasColumnName("LoaiHD").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(150);
                        
                            entity.Property(e => e.LuongCB).HasColumnName("LuongCB");
                        
                            entity.Property(e => e.LuongDongBH).HasColumnName("LuongDongBH");
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(100);
                        
                            entity.Property(e => e.MaPhuCap).HasColumnName("MaPhuCap").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayCoHL).HasColumnName("NgayCoHL");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayHetHL).HasColumnName("NgayHetHL");
                        
                            entity.Property(e => e.NgayKy).HasColumnName("NgayKy");
                        
                            entity.Property(e => e.NgungTheoDoi).HasColumnName("NgungTheoDoi");
                        
                            entity.Property(e => e.NguoiDaiDienCTyKy).HasColumnName("NguoiDaiDienCTyKy").HasMaxLength(100);
                        
                            entity.Property(e => e.NhomHD).HasColumnName("NhomHD").HasMaxLength(150);
                        
                            entity.Property(e => e.SoHD).HasColumnName("SoHD").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenDinhKem).HasColumnName("TenDinhKem").HasMaxLength(250);
                        
                            entity.Property(e => e.TenHD).HasColumnName("TenHD").HasMaxLength(250);
                        
                            entity.Property(e => e.ThoiHanHD).HasColumnName("ThoiHanHD").HasMaxLength(100);
                        
                            entity.Property(e => e.TrangThaiHD).HasColumnName("TrangThaiHD").HasMaxLength(100);
                        
                            entity.Property(e => e.TrichYeu).HasColumnName("TrichYeu").HasMaxLength(-1);
                        
                            entity.Property(e => e.TyLeHuongLuong).HasColumnName("TyLeHuongLuong");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.ViTriCViec).HasColumnName("ViTriCViec").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<DM_KETCHUYEN>(entity =>
                    {
                        entity.HasKey(e => e.ID);
                        entity.ToTable("DM_KETCHUYEN");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.Chon).HasColumnName("Chon");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.ID).HasColumnName("ID");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.KCDenTK).HasColumnName("KCDenTK").HasMaxLength(100);
                        
                            entity.Property(e => e.KCTuTK).HasColumnName("KCTuTK").HasMaxLength(100);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.Loai).HasColumnName("Loai");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTKKC).HasColumnName("MaTKKC").HasMaxLength(50);
                        
                            entity.Property(e => e.MaXL).HasColumnName("MaXL");
                        
                            entity.Property(e => e.NoDoiUng).HasColumnName("NoDoiUng");
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.TyLe).HasColumnName("TyLe");
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<DM_KHACHHANG>(entity =>
                    {
                        entity.HasKey(e => e.MaKH);
                        entity.ToTable("DM_KHACHHANG");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CaNhan).HasColumnName("CaNhan");
                        
                            entity.Property(e => e.ChucVu).HasColumnName("ChucVu").HasMaxLength(50);
                        
                            entity.Property(e => e.Date1).HasColumnName("Date1");
                        
                            entity.Property(e => e.Date2).HasColumnName("Date2");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiKHTA).HasColumnName("DiaChiKHTA").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaChiKHTH).HasColumnName("DiaChiKHTH").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaChiKHTK).HasColumnName("DiaChiKHTK").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaChiKHTN).HasColumnName("DiaChiKHTN").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaChiKHTP).HasColumnName("DiaChiKHTP").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaChiKHTT).HasColumnName("DiaChiKHTT").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaChiNLH).HasColumnName("DiaChiNLH").HasMaxLength(250);
                        
                            entity.Property(e => e.DiemTichLuy).HasColumnName("DiemTichLuy");
                        
                            entity.Property(e => e.DienThoai).HasColumnName("DienThoai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienThoaiDD).HasColumnName("DienThoaiDD").HasMaxLength(50);
                        
                            entity.Property(e => e.DieuKhoanTT).HasColumnName("DieuKhoanTT").HasMaxLength(100);
                        
                            entity.Property(e => e.DTNhaRieng).HasColumnName("DTNhaRieng").HasMaxLength(50);
                        
                            entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(250);
                        
                            entity.Property(e => e.EmailNLH).HasColumnName("EmailNLH").HasMaxLength(100);
                        
                            entity.Property(e => e.Fax).HasColumnName("Fax").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.HanMucNo).HasColumnName("HanMucNo");
                        
                            entity.Property(e => e.HetHanThe).HasColumnName("HetHanThe");
                        
                            entity.Property(e => e.IDKH).HasColumnName("IDKH").HasMaxLength(100);
                        
                            entity.Property(e => e.KhuVuc).HasColumnName("KhuVuc").HasMaxLength(100);
                        
                            entity.Property(e => e.KyHanNo).HasColumnName("KyHanNo");
                        
                            entity.Property(e => e.LaNhom).HasColumnName("LaNhom");
                        
                            entity.Property(e => e.Latitude).HasColumnName("Latitude");
                        
                            entity.Property(e => e.LoaiKH).HasColumnName("LoaiKH").HasMaxLength(20);
                        
                            entity.Property(e => e.LoaiTToan).HasColumnName("LoaiTToan").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.Logo).HasColumnName("Logo").HasMaxLength(2147483647);
                        
                            entity.Property(e => e.Longitude).HasColumnName("Longitude");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTK).HasColumnName("MaTK").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTKNH).HasColumnName("MaTKNH").HasMaxLength(50);
                        
                            entity.Property(e => e.MST).HasColumnName("MST").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayCap).HasColumnName("NgayCap").HasMaxLength(20);
                        
                            entity.Property(e => e.NgayCapGPKD).HasColumnName("NgayCapGPKD");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(250);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(250);
                        
                            entity.Property(e => e.NgaySinh).HasColumnName("NgaySinh");
                        
                            entity.Property(e => e.NgayVaoSo).HasColumnName("NgayVaoSo");
                        
                            entity.Property(e => e.NguoiLienHe).HasColumnName("NguoiLienHe").HasMaxLength(250);
                        
                            entity.Property(e => e.NhomCap).HasColumnName("NhomCap");
                        
                            entity.Property(e => e.NhomGia).HasColumnName("NhomGia").HasMaxLength(100);
                        
                            entity.Property(e => e.NhomKH).HasColumnName("NhomKH").HasMaxLength(50);
                        
                            entity.Property(e => e.NoiCap).HasColumnName("NoiCap").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiCapGPKD).HasColumnName("NoiCapGPKD").HasMaxLength(250);
                        
                            entity.Property(e => e.Number1).HasColumnName("Number1");
                        
                            entity.Property(e => e.Number2).HasColumnName("Number2");
                        
                            entity.Property(e => e.Number3).HasColumnName("Number3");
                        
                            entity.Property(e => e.NVPhuTrach).HasColumnName("NVPhuTrach").HasMaxLength(100);
                        
                            entity.Property(e => e.Password).HasColumnName("Password").HasMaxLength(50);
                        
                            entity.Property(e => e.QuanHuyen).HasColumnName("QuanHuyen").HasMaxLength(100);
                        
                            entity.Property(e => e.QuocGia).HasColumnName("QuocGia").HasMaxLength(100);
                        
                            entity.Property(e => e.SoCMND).HasColumnName("SoCMND").HasMaxLength(50);
                        
                            entity.Property(e => e.SoCoPhieu).HasColumnName("SoCoPhieu");
                        
                            entity.Property(e => e.TenKH).HasColumnName("TenKH").HasMaxLength(250);
                        
                            entity.Property(e => e.TenKHTA).HasColumnName("TenKHTA").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenKHTH).HasColumnName("TenKHTH").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenKHTK).HasColumnName("TenKHTK").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenKHTN).HasColumnName("TenKHTN").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenKHTP).HasColumnName("TenKHTP").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenKHTT).HasColumnName("TenKHTT").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenTKNH).HasColumnName("TenTKNH").HasMaxLength(250);
                        
                            entity.Property(e => e.Text1).HasColumnName("Text1").HasMaxLength(250);
                        
                            entity.Property(e => e.Text2).HasColumnName("Text2").HasMaxLength(250);
                        
                            entity.Property(e => e.Text3).HasColumnName("Text3").HasMaxLength(250);
                        
                            entity.Property(e => e.ThanhVien).HasColumnName("ThanhVien").HasMaxLength(100);
                        
                            entity.Property(e => e.ThanThiet).HasColumnName("ThanThiet");
                        
                            entity.Property(e => e.ThongTinKhac).HasColumnName("ThongTinKhac").HasMaxLength(250);
                        
                            entity.Property(e => e.TinhThanh).HasColumnName("TinhThanh").HasMaxLength(100);
                        
                            entity.Property(e => e.ToChuc).HasColumnName("ToChuc");
                        
                            entity.Property(e => e.TyLeHuongCP).HasColumnName("TyLeHuongCP");
                        
                            entity.Property(e => e.TyLeHuongLai).HasColumnName("TyLeHuongLai");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.XaPhuong).HasColumnName("XaPhuong").HasMaxLength(100);
                        
                            entity.Property(e => e.XungHo).HasColumnName("XungHo").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<DM_KHEN_THUONG>(entity =>
                    {
                        entity.HasKey(e => e.MaKT);
                        entity.ToTable("DM_KHEN THUONG");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.ApDungCho).HasColumnName("ApDungCho").HasMaxLength(200);
                        
                            entity.Property(e => e.BangLoi).HasColumnName("BangLoi");
                        
                            entity.Property(e => e.BangVB).HasColumnName("BangVB");
                        
                            entity.Property(e => e.CanCuKhenThuong).HasColumnName("CanCuKhenThuong").HasMaxLength(-1);
                        
                            entity.Property(e => e.CapKhenThuong).HasColumnName("CapKhenThuong").HasMaxLength(100);
                        
                            entity.Property(e => e.ChucDanh).HasColumnName("ChucDanh").HasMaxLength(100);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DoiTuong).HasColumnName("DoiTuong").HasMaxLength(100);
                        
                            entity.Property(e => e.GiaTriKT).HasColumnName("GiaTriKT");
                        
                            entity.Property(e => e.HinhThuc).HasColumnName("HinhThuc").HasMaxLength(100);
                        
                            entity.Property(e => e.KTNVNTruong1).HasColumnName("KTNVNTruong1");
                        
                            entity.Property(e => e.KTNVNTruong2).HasColumnName("KTNVNTruong2");
                        
                            entity.Property(e => e.KTNVNTruong3).HasColumnName("KTNVNTruong3");
                        
                            entity.Property(e => e.KTNVNTruong4).HasColumnName("KTNVNTruong4");
                        
                            entity.Property(e => e.KTNVNTruong5).HasColumnName("KTNVNTruong5");
                        
                            entity.Property(e => e.KTNVSTruong1).HasColumnName("KTNVSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.KTNVSTruong2).HasColumnName("KTNVSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.KTNVSTruong3).HasColumnName("KTNVSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.KTNVSTruong4).HasColumnName("KTNVSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.KTNVSTruong5).HasColumnName("KTNVSTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiKT).HasColumnName("LoaiKT").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(100);
                        
                            entity.Property(e => e.LyDo).HasColumnName("LyDo").HasMaxLength(-1);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKT).HasColumnName("MaKT").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKTLQ).HasColumnName("MaKTLQ").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayKhenThuong).HasColumnName("NgayKhenThuong");
                        
                            entity.Property(e => e.NgayQuyetDinh).HasColumnName("NgayQuyetDinh");
                        
                            entity.Property(e => e.NgungTheoDoi).HasColumnName("NgungTheoDoi");
                        
                            entity.Property(e => e.NguoiKyQD).HasColumnName("NguoiKyQD").HasMaxLength(100);
                        
                            entity.Property(e => e.NguonNSKT).HasColumnName("NguonNSKT").HasMaxLength(100);
                        
                            entity.Property(e => e.NhomKT).HasColumnName("NhomKT").HasMaxLength(150);
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(200);
                        
                            entity.Property(e => e.SoQuyetDinh).HasColumnName("SoQuyetDinh").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenNVien).HasColumnName("TenNVien").HasMaxLength(100);
                        
                            entity.Property(e => e.TongGiaTri).HasColumnName("TongGiaTri");
                        
                            entity.Property(e => e.TrangThai).HasColumnName("TrangThai").HasMaxLength(100);
                        
                            entity.Property(e => e.TrichYeu).HasColumnName("TrichYeu").HasMaxLength(-1);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.ViTriCViec).HasColumnName("ViTriCViec").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<DM_KHOHANG>(entity =>
                    {
                        entity.HasKey(e => e.MaKho);
                        entity.ToTable("DM_KHOHANG");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DienThoai).HasColumnName("DienThoai").HasMaxLength(30);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.KhoCap).HasColumnName("KhoCap");
                        
                            entity.Property(e => e.LaMooc).HasColumnName("LaMooc");
                        
                            entity.Property(e => e.LaXe).HasColumnName("LaXe");
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NguoiQLy).HasColumnName("NguoiQLy").HasMaxLength(50);
                        
                            entity.Property(e => e.NhomKho).HasColumnName("NhomKho").HasMaxLength(50);
                        
                            entity.Property(e => e.TenKho).HasColumnName("TenKho").HasMaxLength(250);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<DM_KHUVUC>(entity =>
                    {
                        entity.HasKey(e => e.IDKV);
                        entity.ToTable("DM_KHUVUC");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.CoTonKho).HasColumnName("CoTonKho");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DienThoai).HasColumnName("DienThoai").HasMaxLength(150);
                        
                            entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(150);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.Facebook).HasColumnName("Facebook").HasMaxLength(150);
                        
                            entity.Property(e => e.Fax).HasColumnName("Fax").HasMaxLength(150);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.IDKV).HasColumnName("IDKV");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.LaNhom).HasColumnName("LaNhom");
                        
                            entity.Property(e => e.LoaiKV).HasColumnName("LoaiKV").HasMaxLength(100);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKV).HasColumnName("MaKV").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVienPhuTrach).HasColumnName("MaNVienPhuTrach").HasMaxLength(50);
                        
                            entity.Property(e => e.MaXL).HasColumnName("MaXL").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NhomCap).HasColumnName("NhomCap");
                        
                            entity.Property(e => e.NhomKV).HasColumnName("NhomKV").HasMaxLength(150);
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenKV).HasColumnName("TenKV").HasMaxLength(250);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                            entity.Property(e => e.Website).HasColumnName("Website").HasMaxLength(150);
                        
                            entity.Property(e => e.Zalo).HasColumnName("Zalo").HasMaxLength(150);
                        
                    });
                    
                    modelBuilder.Entity<DM_LOAI_THE>(entity =>
                    {
                        entity.HasKey(e => e.IDTHE);
                        entity.ToTable("DM_LOAI THE");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.IDTHE).HasColumnName("IDTHE");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaThe).HasColumnName("MaThe").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayPhatHanh).HasColumnName("NgayPhatHanh");
                        
                            entity.Property(e => e.NhomCap).HasColumnName("NhomCap");
                        
                            entity.Property(e => e.NhomThe).HasColumnName("NhomThe").HasMaxLength(150);
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenThe).HasColumnName("TenThe").HasMaxLength(250);
                        
                            entity.Property(e => e.TheCheck1).HasColumnName("TheCheck1");
                        
                            entity.Property(e => e.TheCheck2).HasColumnName("TheCheck2");
                        
                            entity.Property(e => e.TheCheck3).HasColumnName("TheCheck3");
                        
                            entity.Property(e => e.TheDate1).HasColumnName("TheDate1");
                        
                            entity.Property(e => e.TheDate2).HasColumnName("TheDate2");
                        
                            entity.Property(e => e.TheDate3).HasColumnName("TheDate3");
                        
                            entity.Property(e => e.TheNumber1).HasColumnName("TheNumber1");
                        
                            entity.Property(e => e.TheNumber2).HasColumnName("TheNumber2");
                        
                            entity.Property(e => e.TheNumber3).HasColumnName("TheNumber3");
                        
                            entity.Property(e => e.TheNumber4).HasColumnName("TheNumber4");
                        
                            entity.Property(e => e.TheNumber5).HasColumnName("TheNumber5");
                        
                            entity.Property(e => e.TheString1).HasColumnName("TheString1").HasMaxLength(250);
                        
                            entity.Property(e => e.TheString2).HasColumnName("TheString2").HasMaxLength(250);
                        
                            entity.Property(e => e.TheString3).HasColumnName("TheString3").HasMaxLength(250);
                        
                            entity.Property(e => e.TheString4).HasColumnName("TheString4").HasMaxLength(250);
                        
                            entity.Property(e => e.TheString5).HasColumnName("TheString5").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<DM_LOTDATE>(entity =>
                    {
                        entity.HasKey(e => e.IDLOT);
                        entity.ToTable("DM_LOTDATE");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.BenNiemPhong).HasColumnName("BenNiemPhong").HasMaxLength(250);
                        
                            entity.Property(e => e.CangCT).HasColumnName("CangCT").HasMaxLength(150);
                        
                            entity.Property(e => e.CangDen).HasColumnName("CangDen").HasMaxLength(250);
                        
                            entity.Property(e => e.CangDi).HasColumnName("CangDi").HasMaxLength(250);
                        
                            entity.Property(e => e.CangDo).HasColumnName("CangDo").HasMaxLength(250);
                        
                            entity.Property(e => e.CangXep).HasColumnName("CangXep").HasMaxLength(250);
                        
                            entity.Property(e => e.ChiCucHQ).HasColumnName("ChiCucHQ").HasMaxLength(250);
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.ChucVuDD).HasColumnName("ChucVuDD").HasMaxLength(250);
                        
                            entity.Property(e => e.ChucVuDDNN).HasColumnName("ChucVuDDNN").HasMaxLength(250);
                        
                            entity.Property(e => e.ChuoiCacCont).HasColumnName("ChuoiCacCont").HasMaxLength(-1);
                        
                            entity.Property(e => e.ChuoiHienThi).HasColumnName("ChuoiHienThi").HasMaxLength(-1);
                        
                            entity.Property(e => e.ChuyenBay).HasColumnName("ChuyenBay").HasMaxLength(50);
                        
                            entity.Property(e => e.Cont20).HasColumnName("Cont20");
                        
                            entity.Property(e => e.Cont40).HasColumnName("Cont40");
                        
                            entity.Property(e => e.ContBangChu).HasColumnName("ContBangChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.ContT1).HasColumnName("ContT1");
                        
                            entity.Property(e => e.ContT2).HasColumnName("ContT2");
                        
                            entity.Property(e => e.ContT3).HasColumnName("ContT3");
                        
                            entity.Property(e => e.CuaKhau).HasColumnName("CuaKhau").HasMaxLength(100);
                        
                            entity.Property(e => e.CucHaiQuan).HasColumnName("CucHaiQuan").HasMaxLength(250);
                        
                            entity.Property(e => e.CuocVC).HasColumnName("CuocVC");
                        
                            entity.Property(e => e.DeNghi).HasColumnName("DeNghi").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiCCHQ).HasColumnName("DiaChiCCHQ").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiCHQ).HasColumnName("DiaChiCHQ").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiDLNN).HasColumnName("DiaChiDLNN").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiKG).HasColumnName("DiaChiKG").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiKN).HasColumnName("DiaChiKN").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNDD).HasColumnName("DiaChiNDD").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNDDNN).HasColumnName("DiaChiNDDNN").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNDL).HasColumnName("DiaChiNDL").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNNK).HasColumnName("DiaChiNNK").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNUT).HasColumnName("DiaChiNUT").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNXK).HasColumnName("DiaChiNXK").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiTB).HasColumnName("DiaChiTB").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiTB2).HasColumnName("DiaChiTB2").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiTV).HasColumnName("DiaChiTV").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaDiemDo).HasColumnName("DiaDiemDo").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaDiemXep).HasColumnName("DiaDiemXep").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DienThoaiDLNN).HasColumnName("DienThoaiDLNN").HasMaxLength(100);
                        
                            entity.Property(e => e.DienThoaiDLTN).HasColumnName("DienThoaiDLTN").HasMaxLength(100);
                        
                            entity.Property(e => e.DienThoaiLHG).HasColumnName("DienThoaiLHG").HasMaxLength(150);
                        
                            entity.Property(e => e.DienThoaiLHN).HasColumnName("DienThoaiLHN").HasMaxLength(150);
                        
                            entity.Property(e => e.DienThoaiLHTB).HasColumnName("DienThoaiLHTB").HasMaxLength(150);
                        
                            entity.Property(e => e.DienThoaiLHTB2).HasColumnName("DienThoaiLHTB2").HasMaxLength(150);
                        
                            entity.Property(e => e.DTKHGui).HasColumnName("DTKHGui").HasMaxLength(100);
                        
                            entity.Property(e => e.DTKHNhan).HasColumnName("DTKHNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.DTKHTB).HasColumnName("DTKHTB").HasMaxLength(100);
                        
                            entity.Property(e => e.DTKHTB2).HasColumnName("DTKHTB2").HasMaxLength(100);
                        
                            entity.Property(e => e.EmailLHG).HasColumnName("EmailLHG").HasMaxLength(150);
                        
                            entity.Property(e => e.EmailLHN).HasColumnName("EmailLHN").HasMaxLength(150);
                        
                            entity.Property(e => e.EmailLHTB).HasColumnName("EmailLHTB").HasMaxLength(150);
                        
                            entity.Property(e => e.EmailLHTB2).HasColumnName("EmailLHTB2").HasMaxLength(150);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.FaxDLNN).HasColumnName("FaxDLNN").HasMaxLength(100);
                        
                            entity.Property(e => e.FaxDLTN).HasColumnName("FaxDLTN").HasMaxLength(100);
                        
                            entity.Property(e => e.FaxGui).HasColumnName("FaxGui").HasMaxLength(100);
                        
                            entity.Property(e => e.FaxNhan).HasColumnName("FaxNhan").HasMaxLength(50);
                        
                            entity.Property(e => e.FaxTB).HasColumnName("FaxTB").HasMaxLength(50);
                        
                            entity.Property(e => e.FaxTB2).HasColumnName("FaxTB2").HasMaxLength(50);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuNG).HasColumnName("GhiChuNG").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuSeal).HasColumnName("GhiChuSeal").HasMaxLength(-1);
                        
                            entity.Property(e => e.GioCatMang).HasColumnName("GioCatMang");
                        
                            entity.Property(e => e.HanDung).HasColumnName("HanDung");
                        
                            entity.Property(e => e.HangRoi).HasColumnName("HangRoi");
                        
                            entity.Property(e => e.HangVT).HasColumnName("HangVT").HasMaxLength(250);
                        
                            entity.Property(e => e.HanLuuCont).HasColumnName("HanLuuCont");
                        
                            entity.Property(e => e.IDLOT).HasColumnName("IDLOT");
                        
                            entity.Property(e => e.ImportCode).HasColumnName("ImportCode").HasMaxLength(100);
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.KhoHang).HasColumnName("KhoHang").HasMaxLength(100);
                        
                            entity.Property(e => e.KhuVuc).HasColumnName("KhuVuc").HasMaxLength(150);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.LienHeGui).HasColumnName("LienHeGui").HasMaxLength(150);
                        
                            entity.Property(e => e.LienHeNhan).HasColumnName("LienHeNhan").HasMaxLength(150);
                        
                            entity.Property(e => e.LienHeTB).HasColumnName("LienHeTB").HasMaxLength(150);
                        
                            entity.Property(e => e.LienHeTB2).HasColumnName("LienHeTB2").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiBL).HasColumnName("LoaiBL").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiContMax).HasColumnName("LoaiContMax").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiDV).HasColumnName("LoaiDV").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiHang).HasColumnName("LoaiHang").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiKien).HasColumnName("LoaiKien").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiNX).HasColumnName("LoaiNX").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.LoaiPT).HasColumnName("LoaiPT").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.LotBit1).HasColumnName("LotBit1");
                        
                            entity.Property(e => e.LotBit2).HasColumnName("LotBit2");
                        
                            entity.Property(e => e.LotBit3).HasColumnName("LotBit3");
                        
                            entity.Property(e => e.LotDate1).HasColumnName("LotDate1");
                        
                            entity.Property(e => e.LotDate2).HasColumnName("LotDate2");
                        
                            entity.Property(e => e.LotDate3).HasColumnName("LotDate3");
                        
                            entity.Property(e => e.LotDate4).HasColumnName("LotDate4");
                        
                            entity.Property(e => e.LotDate5).HasColumnName("LotDate5");
                        
                            entity.Property(e => e.LotInt1).HasColumnName("LotInt1");
                        
                            entity.Property(e => e.LotInt2).HasColumnName("LotInt2");
                        
                            entity.Property(e => e.LotInt3).HasColumnName("LotInt3");
                        
                            entity.Property(e => e.LotInt4).HasColumnName("LotInt4");
                        
                            entity.Property(e => e.LotInt5).HasColumnName("LotInt5");
                        
                            entity.Property(e => e.LotNumber1).HasColumnName("LotNumber1");
                        
                            entity.Property(e => e.LotNumber2).HasColumnName("LotNumber2");
                        
                            entity.Property(e => e.LotNumber3).HasColumnName("LotNumber3");
                        
                            entity.Property(e => e.LotNumber4).HasColumnName("LotNumber4");
                        
                            entity.Property(e => e.LotNumber5).HasColumnName("LotNumber5");
                        
                            entity.Property(e => e.LotString1).HasColumnName("LotString1").HasMaxLength(50);
                        
                            entity.Property(e => e.LotString10).HasColumnName("LotString10").HasMaxLength(-1);
                        
                            entity.Property(e => e.LotString2).HasColumnName("LotString2").HasMaxLength(50);
                        
                            entity.Property(e => e.LotString3).HasColumnName("LotString3").HasMaxLength(50);
                        
                            entity.Property(e => e.LotString4).HasColumnName("LotString4").HasMaxLength(100);
                        
                            entity.Property(e => e.LotString5).HasColumnName("LotString5").HasMaxLength(100);
                        
                            entity.Property(e => e.LotString6).HasColumnName("LotString6").HasMaxLength(100);
                        
                            entity.Property(e => e.LotString7).HasColumnName("LotString7").HasMaxLength(250);
                        
                            entity.Property(e => e.LotString8).HasColumnName("LotString8").HasMaxLength(250);
                        
                            entity.Property(e => e.LotString9).HasColumnName("LotString9").HasMaxLength(250);
                        
                            entity.Property(e => e.MaBangGia).HasColumnName("MaBangGia").HasMaxLength(100);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChuPT).HasColumnName("MaChuPT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaDaiLyNN).HasColumnName("MaDaiLyNN").HasMaxLength(50);
                        
                            entity.Property(e => e.MaDiemTV).HasColumnName("MaDiemTV").HasMaxLength(100);
                        
                            entity.Property(e => e.MailDLNN).HasColumnName("MailDLNN").HasMaxLength(100);
                        
                            entity.Property(e => e.MailDLTN).HasColumnName("MailDLTN").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKHBK).HasColumnName("MaKHBK").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKHGui).HasColumnName("MaKHGui").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKHNhan).HasColumnName("MaKHNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKHTB).HasColumnName("MaKHTB").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKHTB2).HasColumnName("MaKHTB2").HasMaxLength(100);
                        
                            entity.Property(e => e.MaLichTau).HasColumnName("MaLichTau");
                        
                            entity.Property(e => e.MaLOT).HasColumnName("MaLOT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNguoiDD).HasColumnName("MaNguoiDD").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNguoiDDNN).HasColumnName("MaNguoiDDNN").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNguoiDL).HasColumnName("MaNguoiDL").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNguoiNK).HasColumnName("MaNguoiNK").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNguoiUT).HasColumnName("MaNguoiUT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNguoiXK).HasColumnName("MaNguoiXK").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVienKD).HasColumnName("MaNVienKD").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MoTaHH).HasColumnName("MoTaHH").HasMaxLength(-1);
                        
                            entity.Property(e => e.MSTGui).HasColumnName("MSTGui").HasMaxLength(100);
                        
                            entity.Property(e => e.MSTNhan).HasColumnName("MSTNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MSTTB).HasColumnName("MSTTB").HasMaxLength(100);
                        
                            entity.Property(e => e.MSTTB2).HasColumnName("MSTTB2").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayBOB).HasColumnName("NgayBOB");
                        
                            entity.Property(e => e.NgayBooking).HasColumnName("NgayBooking");
                        
                            entity.Property(e => e.NgayCatMang).HasColumnName("NgayCatMang");
                        
                            entity.Property(e => e.NgayCTLH).HasColumnName("NgayCTLH");
                        
                            entity.Property(e => e.NgayDen).HasColumnName("NgayDen");
                        
                            entity.Property(e => e.NgayDoHang).HasColumnName("NgayDoHang");
                        
                            entity.Property(e => e.NgayDongLay).HasColumnName("NgayDongLay");
                        
                            entity.Property(e => e.NgayGiaoHa).HasColumnName("NgayGiaoHa");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayHetHD).HasColumnName("NgayHetHD");
                        
                            entity.Property(e => e.NgayHoaDon).HasColumnName("NgayHoaDon");
                        
                            entity.Property(e => e.NgayHopDong).HasColumnName("NgayHopDong");
                        
                            entity.Property(e => e.NgayKH).HasColumnName("NgayKH");
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.NgayMasterBL).HasColumnName("NgayMasterBL");
                        
                            entity.Property(e => e.NgayPhatHanh).HasColumnName("NgayPhatHanh");
                        
                            entity.Property(e => e.NgayTLyHD).HasColumnName("NgayTLyHD");
                        
                            entity.Property(e => e.NgayToKhai).HasColumnName("NgayToKhai");
                        
                            entity.Property(e => e.NgayTraVo).HasColumnName("NgayTraVo");
                        
                            entity.Property(e => e.NgayXepHang).HasColumnName("NgayXepHang");
                        
                            entity.Property(e => e.NguoiGui).HasColumnName("NguoiGui").HasMaxLength(250);
                        
                            entity.Property(e => e.NguoiNhan).HasColumnName("NguoiNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.NhapBangChu).HasColumnName("NhapBangChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.NhomCap).HasColumnName("NhomCap");
                        
                            entity.Property(e => e.NhomLOT).HasColumnName("NhomLOT").HasMaxLength(150);
                        
                            entity.Property(e => e.NoiHa).HasColumnName("NoiHa").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiNhan).HasColumnName("NoiNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiPhatHanh).HasColumnName("NoiPhatHanh").HasMaxLength(250);
                        
                            entity.Property(e => e.NopCho).HasColumnName("NopCho").HasMaxLength(250);
                        
                            entity.Property(e => e.NuocNX).HasColumnName("NuocNX").HasMaxLength(100);
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.PhiBaoHiem).HasColumnName("PhiBaoHiem");
                        
                            entity.Property(e => e.PTTT).HasColumnName("PTTT").HasMaxLength(50);
                        
                            entity.Property(e => e.QuocTichPTVT).HasColumnName("QuocTichPTVT").HasMaxLength(150);
                        
                            entity.Property(e => e.RecBKN).HasColumnName("RecBKN").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RecMasterBL).HasColumnName("RecMasterBL").HasMaxLength(100);
                        
                            entity.Property(e => e.RECXL).HasColumnName("RECXL").HasMaxLength(50);
                        
                            entity.Property(e => e.SHKienCont).HasColumnName("SHKienCont").HasMaxLength(100);
                        
                            entity.Property(e => e.SLBLGoc).HasColumnName("SLBLGoc");
                        
                            entity.Property(e => e.SLCont).HasColumnName("SLCont");
                        
                            entity.Property(e => e.SLSeal).HasColumnName("SLSeal");
                        
                            entity.Property(e => e.SoBLGoc).HasColumnName("SoBLGoc").HasMaxLength(100);
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(50);
                        
                            entity.Property(e => e.SoBooking).HasColumnName("SoBooking").HasMaxLength(100);
                        
                            entity.Property(e => e.SoCTLH).HasColumnName("SoCTLH").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHieuChuyen).HasColumnName("SoHieuChuyen").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHoaDon).HasColumnName("SoHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHopDong).HasColumnName("SoHopDong").HasMaxLength(50);
                        
                            entity.Property(e => e.SoKhoi).HasColumnName("SoKhoi");
                        
                            entity.Property(e => e.SoKien).HasColumnName("SoKien");
                        
                            entity.Property(e => e.SoMasterBL).HasColumnName("SoMasterBL").HasMaxLength(100);
                        
                            entity.Property(e => e.SoNgay).HasColumnName("SoNgay");
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.SoThem1).HasColumnName("SoThem1");
                        
                            entity.Property(e => e.SoThem2).HasColumnName("SoThem2");
                        
                            entity.Property(e => e.SoToKhai).HasColumnName("SoToKhai").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenChuPT).HasColumnName("TenChuPT").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDaiLyNN).HasColumnName("TenDaiLyNN").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDiemTV).HasColumnName("TenDiemTV").HasMaxLength(250);
                        
                            entity.Property(e => e.TenKHBK).HasColumnName("TenKHBK").HasMaxLength(250);
                        
                            entity.Property(e => e.TenKHGui).HasColumnName("TenKHGui").HasMaxLength(250);
                        
                            entity.Property(e => e.TenKHNhan).HasColumnName("TenKHNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.TenKHTB).HasColumnName("TenKHTB").HasMaxLength(250);
                        
                            entity.Property(e => e.TenKHTB2).HasColumnName("TenKHTB2").HasMaxLength(250);
                        
                            entity.Property(e => e.TenLoaiNX).HasColumnName("TenLoaiNX").HasMaxLength(150);
                        
                            entity.Property(e => e.TenLOT).HasColumnName("TenLOT").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiDD).HasColumnName("TenNguoiDD").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiDDNN).HasColumnName("TenNguoiDDNN").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiDL).HasColumnName("TenNguoiDL").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiNK).HasColumnName("TenNguoiNK").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiUT).HasColumnName("TenNguoiUT").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiXK).HasColumnName("TenNguoiXK").HasMaxLength(250);
                        
                            entity.Property(e => e.TenSHPT).HasColumnName("TenSHPT").HasMaxLength(50);
                        
                            entity.Property(e => e.ThamChieuHBL).HasColumnName("ThamChieuHBL").HasMaxLength(-1);
                        
                            entity.Property(e => e.ThamChieuKhac).HasColumnName("ThamChieuKhac").HasMaxLength(-1);
                        
                            entity.Property(e => e.ThamChieuMBL).HasColumnName("ThamChieuMBL").HasMaxLength(-1);
                        
                            entity.Property(e => e.TheoDonGia).HasColumnName("TheoDonGia");
                        
                            entity.Property(e => e.TheoSoLuong).HasColumnName("TheoSoLuong");
                        
                            entity.Property(e => e.ThoiGianCT).HasColumnName("ThoiGianCT");
                        
                            entity.Property(e => e.ThongTinThem).HasColumnName("ThongTinThem").HasMaxLength(-1);
                        
                            entity.Property(e => e.ThueGTGT).HasColumnName("ThueGTGT");
                        
                            entity.Property(e => e.ThueNK).HasColumnName("ThueNK");
                        
                            entity.Property(e => e.ThueTTDB).HasColumnName("ThueTTDB");
                        
                            entity.Property(e => e.ThuKhac).HasColumnName("ThuKhac");
                        
                            entity.Property(e => e.TienBangChu).HasColumnName("TienBangChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.TienGTGT).HasColumnName("TienGTGT");
                        
                            entity.Property(e => e.TienThueNK).HasColumnName("TienThueNK");
                        
                            entity.Property(e => e.TienThueTTDB).HasColumnName("TienThueTTDB");
                        
                            entity.Property(e => e.TienThuKhac).HasColumnName("TienThuKhac");
                        
                            entity.Property(e => e.TongSoTien).HasColumnName("TongSoTien");
                        
                            entity.Property(e => e.TongTienThue).HasColumnName("TongTienThue");
                        
                            entity.Property(e => e.TrangThai).HasColumnName("TrangThai").HasMaxLength(250);
                        
                            entity.Property(e => e.TrongLuong).HasColumnName("TrongLuong");
                        
                            entity.Property(e => e.TrongLuongTC).HasColumnName("TrongLuongTC");
                        
                            entity.Property(e => e.TuPhanBo).HasColumnName("TuPhanBo");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<DM_NGHANH>(entity =>
                    {
                        entity.HasKey(e => e.IDNN);
                        entity.ToTable("DM_NGHANH");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.DacDiem).HasColumnName("DacDiem").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienThoai).HasColumnName("DienThoai").HasMaxLength(150);
                        
                            entity.Property(e => e.DoiTuong).HasColumnName("DoiTuong").HasMaxLength(250);
                        
                            entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(150);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.IDNN).HasColumnName("IDNN");
                        
                            entity.Property(e => e.LaNhom).HasColumnName("LaNhom");
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(30);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(150);
                        
                            entity.Property(e => e.NguoiQuanLy).HasColumnName("NguoiQuanLy").HasMaxLength(250);
                        
                            entity.Property(e => e.NhomNghanh).HasColumnName("NhomNghanh").HasMaxLength(250);
                        
                            entity.Property(e => e.NNCKTruong1).HasColumnName("NNCKTruong1");
                        
                            entity.Property(e => e.NNCKTruong2).HasColumnName("NNCKTruong2");
                        
                            entity.Property(e => e.NNCKTruong3).HasColumnName("NNCKTruong3");
                        
                            entity.Property(e => e.NNDTruong1).HasColumnName("NNDTruong1");
                        
                            entity.Property(e => e.NNDTruong2).HasColumnName("NNDTruong2");
                        
                            entity.Property(e => e.NNDTruong3).HasColumnName("NNDTruong3");
                        
                            entity.Property(e => e.NNNTruong1).HasColumnName("NNNTruong1");
                        
                            entity.Property(e => e.NNNTruong2).HasColumnName("NNNTruong2");
                        
                            entity.Property(e => e.NNNTruong3).HasColumnName("NNNTruong3");
                        
                            entity.Property(e => e.NNNTruong4).HasColumnName("NNNTruong4");
                        
                            entity.Property(e => e.NNNTruong5).HasColumnName("NNNTruong5");
                        
                            entity.Property(e => e.NNSTruong1).HasColumnName("NNSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.NNSTruong2).HasColumnName("NNSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.NNSTruong3).HasColumnName("NNSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.NNSTruong4).HasColumnName("NNSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.NNSTruong5).HasColumnName("NNSTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenNghanh).HasColumnName("TenNghanh").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<DM_NGHIEPVU>(entity =>
                    {
                        entity.HasKey(e => e.MaNVu);
                        entity.ToTable("DM_NGHIEPVU");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiNVu).HasColumnName("LoaiNVu").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(30);
                        
                            entity.Property(e => e.MacDinh).HasColumnName("MacDinh");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MaKHCo).HasColumnName("MaKHCo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKHNo).HasColumnName("MaKHNo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVu).HasColumnName("MaNVu").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKCo).HasColumnName("MaTKCo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKNo).HasColumnName("MaTKNo").HasMaxLength(50);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                    });
                    
                    modelBuilder.Entity<DM_NHANVIEN>(entity =>
                    {
                        entity.HasKey(e => e.MaNVien);
                        entity.ToTable("DM_NHANVIEN");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.Bac).HasColumnName("Bac").HasMaxLength(50);
                        
                            entity.Property(e => e.BacLuong).HasColumnName("BacLuong").HasMaxLength(50);
                        
                            entity.Property(e => e.BenhTat).HasColumnName("BenhTat").HasMaxLength(250);
                        
                            entity.Property(e => e.BHTNThamGiaDen).HasColumnName("BHTNThamGiaDen");
                        
                            entity.Property(e => e.BHTNThamGiaTu).HasColumnName("BHTNThamGiaTu");
                        
                            entity.Property(e => e.BHXHThamGiaDen).HasColumnName("BHXHThamGiaDen");
                        
                            entity.Property(e => e.BHXHThamGiaTu).HasColumnName("BHXHThamGiaTu");
                        
                            entity.Property(e => e.BHYTNgayHetHan).HasColumnName("BHYTNgayHetHan");
                        
                            entity.Property(e => e.BHYTNgayThamGia).HasColumnName("BHYTNgayThamGia");
                        
                            entity.Property(e => e.BinhChung).HasColumnName("BinhChung").HasMaxLength(100);
                        
                            entity.Property(e => e.CanLuuY).HasColumnName("CanLuuY").HasMaxLength(-1);
                        
                            entity.Property(e => e.CanNang).HasColumnName("CanNang").HasMaxLength(20);
                        
                            entity.Property(e => e.CapBac).HasColumnName("CapBac").HasMaxLength(100);
                        
                            entity.Property(e => e.CapCongViec).HasColumnName("CapCongViec").HasMaxLength(50);
                        
                            entity.Property(e => e.CDoanThamGiaTu).HasColumnName("CDoanThamGiaTu");
                        
                            entity.Property(e => e.ChieuCao).HasColumnName("ChieuCao").HasMaxLength(20);
                        
                            entity.Property(e => e.ChucVu).HasColumnName("ChucVu").HasMaxLength(255);
                        
                            entity.Property(e => e.ChucVuDang).HasColumnName("ChucVuDang").HasMaxLength(150);
                        
                            entity.Property(e => e.ChucVuDoan).HasColumnName("ChucVuDoan").HasMaxLength(150);
                        
                            entity.Property(e => e.ChuyenNghanh).HasColumnName("ChuyenNghanh").HasMaxLength(250);
                        
                            entity.Property(e => e.CongTinhTheo).HasColumnName("CongTinhTheo").HasMaxLength(100);
                        
                            entity.Property(e => e.CoNguoiQuenCT).HasColumnName("CoNguoiQuenCT");
                        
                            entity.Property(e => e.DaGuiThuMoi).HasColumnName("DaGuiThuMoi");
                        
                            entity.Property(e => e.DaLamCTyDT).HasColumnName("DaLamCTyDT");
                        
                            entity.Property(e => e.DanToc).HasColumnName("DanToc").HasMaxLength(150);
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(255);
                        
                            entity.Property(e => e.DiaChiDT).HasColumnName("DiaChiDT").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaDiemLV).HasColumnName("DiaDiemLV").HasMaxLength(250);
                        
                            entity.Property(e => e.DiemManh).HasColumnName("DiemManh").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiemYeu).HasColumnName("DiemYeu").HasMaxLength(-1);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(255);
                        
                            entity.Property(e => e.DongBHK1).HasColumnName("DongBHK1");
                        
                            entity.Property(e => e.DongBHK2).HasColumnName("DongBHK2");
                        
                            entity.Property(e => e.DongBHK3).HasColumnName("DongBHK3");
                        
                            entity.Property(e => e.DongBHTN).HasColumnName("DongBHTN");
                        
                            entity.Property(e => e.DongBHXH).HasColumnName("DongBHXH");
                        
                            entity.Property(e => e.DongBHYT).HasColumnName("DongBHYT");
                        
                            entity.Property(e => e.DonVi).HasColumnName("DonVi").HasMaxLength(120);
                        
                            entity.Property(e => e.DonViCTNQ).HasColumnName("DonViCTNQ").HasMaxLength(250);
                        
                            entity.Property(e => e.DotTuyenDung).HasColumnName("DotTuyenDung").HasMaxLength(250);
                        
                            entity.Property(e => e.DTCoQuan).HasColumnName("DTCoQuan").HasMaxLength(100);
                        
                            entity.Property(e => e.DTDD).HasColumnName("DTDD").HasMaxLength(20);
                        
                            entity.Property(e => e.DTKhac).HasColumnName("DTKhac").HasMaxLength(100);
                        
                            entity.Property(e => e.DTNRieng).HasColumnName("DTNRieng").HasMaxLength(20);
                        
                            entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(50);
                        
                            entity.Property(e => e.EmailCoQuan).HasColumnName("EmailCoQuan").HasMaxLength(100);
                        
                            entity.Property(e => e.EmailKhac).HasColumnName("EmailKhac").HasMaxLength(100);
                        
                            entity.Property(e => e.FacebookID).HasColumnName("FacebookID").HasMaxLength(100);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuUT).HasColumnName("GhiChuUT").HasMaxLength(-1);
                        
                            entity.Property(e => e.GiamTruGiaCanh).HasColumnName("GiamTruGiaCanh");
                        
                            entity.Property(e => e.GioiTinh).HasColumnName("GioiTinh").HasMaxLength(50);
                        
                            entity.Property(e => e.GTalkID).HasColumnName("GTalkID").HasMaxLength(100);
                        
                            entity.Property(e => e.HangTT).HasColumnName("HangTT").HasMaxLength(100);
                        
                            entity.Property(e => e.HeSoLuong).HasColumnName("HeSoLuong");
                        
                            entity.Property(e => e.HinhAnh).HasColumnName("HinhAnh").HasMaxLength(2147483647);
                        
                            entity.Property(e => e.HKDiaChi).HasColumnName("HKDiaChi").HasMaxLength(200);
                        
                            entity.Property(e => e.HKQuanHuyen).HasColumnName("HKQuanHuyen").HasMaxLength(100);
                        
                            entity.Property(e => e.HKQuocGia).HasColumnName("HKQuocGia").HasMaxLength(100);
                        
                            entity.Property(e => e.HKTinhThanh).HasColumnName("HKTinhThanh").HasMaxLength(100);
                        
                            entity.Property(e => e.HKXaPhuong).HasColumnName("HKXaPhuong").HasMaxLength(100);
                        
                            entity.Property(e => e.HoSoDK).HasColumnName("HoSoDK").HasMaxLength(50);
                        
                            entity.Property(e => e.HoVaDem).HasColumnName("HoVaDem").HasMaxLength(100);
                        
                            entity.Property(e => e.HoVaTenNQ).HasColumnName("HoVaTenNQ").HasMaxLength(100);
                        
                            entity.Property(e => e.HuongCheDo).HasColumnName("HuongCheDo");
                        
                            entity.Property(e => e.IDHS).HasColumnName("IDHS").HasMaxLength(100);
                        
                            entity.Property(e => e.KCDiaChi).HasColumnName("KCDiaChi").HasMaxLength(200);
                        
                            entity.Property(e => e.KCDTDD).HasColumnName("KCDTDD").HasMaxLength(100);
                        
                            entity.Property(e => e.KCDTNhaRieng).HasColumnName("KCDTNhaRieng").HasMaxLength(100);
                        
                            entity.Property(e => e.KCEmail).HasColumnName("KCEmail").HasMaxLength(100);
                        
                            entity.Property(e => e.KCHoVaTen).HasColumnName("KCHoVaTen").HasMaxLength(200);
                        
                            entity.Property(e => e.KCQuanHe).HasColumnName("KCQuanHe").HasMaxLength(100);
                        
                            entity.Property(e => e.KenhTuyenDung).HasColumnName("KenhTuyenDung").HasMaxLength(250);
                        
                            entity.Property(e => e.KhoaDaoTao).HasColumnName("KhoaDaoTao").HasMaxLength(250);
                        
                            entity.Property(e => e.LaDangVien).HasColumnName("LaDangVien");
                        
                            entity.Property(e => e.LaDoanVien).HasColumnName("LaDoanVien");
                        
                            entity.Property(e => e.LaKH).HasColumnName("LaKH");
                        
                            entity.Property(e => e.LaLaiXe).HasColumnName("LaLaiXe");
                        
                            entity.Property(e => e.LamDenNgayDT).HasColumnName("LamDenNgayDT");
                        
                            entity.Property(e => e.LamTuNgayDT).HasColumnName("LamTuNgayDT");
                        
                            entity.Property(e => e.LaNCC).HasColumnName("LaNCC");
                        
                            entity.Property(e => e.LaNguoiKT).HasColumnName("LaNguoiKT");
                        
                            entity.Property(e => e.LaNVKD).HasColumnName("LaNVKD");
                        
                            entity.Property(e => e.LaoDongGiam).HasColumnName("LaoDongGiam");
                        
                            entity.Property(e => e.LaoDongTang).HasColumnName("LaoDongTang");
                        
                            entity.Property(e => e.LaPhongBan).HasColumnName("LaPhongBan");
                        
                            entity.Property(e => e.LaQuanNhan).HasColumnName("LaQuanNhan");
                        
                            entity.Property(e => e.LaTBBenhBinh).HasColumnName("LaTBBenhBinh");
                        
                            entity.Property(e => e.LHKhacID).HasColumnName("LHKhacID").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiHopDong).HasColumnName("LoaiHopDong").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiHS).HasColumnName("LoaiHS").HasMaxLength(100);
                        
                            entity.Property(e => e.LuongCoBan).HasColumnName("LuongCoBan");
                        
                            entity.Property(e => e.LuongDongBH).HasColumnName("LuongDongBH");
                        
                            entity.Property(e => e.LuongTheoDS).HasColumnName("LuongTheoDS");
                        
                            entity.Property(e => e.LuongThuViec).HasColumnName("LuongThuViec");
                        
                            entity.Property(e => e.LyDoNghi).HasColumnName("LyDoNghi").HasMaxLength(250);
                        
                            entity.Property(e => e.LyDoNghiDT).HasColumnName("LyDoNghiDT").HasMaxLength(-1);
                        
                            entity.Property(e => e.LyDoXuatNgu).HasColumnName("LyDoXuatNgu").HasMaxLength(-1);
                        
                            entity.Property(e => e.MaChamCong).HasColumnName("MaChamCong").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTinhCap).HasColumnName("MaTinhCap").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKNH).HasColumnName("MaTKNH").HasMaxLength(50);
                        
                            entity.Property(e => e.MaUngVien).HasColumnName("MaUngVien").HasMaxLength(50);
                        
                            entity.Property(e => e.MoTaCVDT).HasColumnName("MoTaCVDT").HasMaxLength(-1);
                        
                            entity.Property(e => e.MSNID).HasColumnName("MSNID").HasMaxLength(100);
                        
                            entity.Property(e => e.MSTCN).HasColumnName("MSTCN").HasMaxLength(30);
                        
                            entity.Property(e => e.MucLuongDT).HasColumnName("MucLuongDT");
                        
                            entity.Property(e => e.MucLuongYCDen).HasColumnName("MucLuongYCDen");
                        
                            entity.Property(e => e.MucLuongYCTu).HasColumnName("MucLuongYCTu");
                        
                            entity.Property(e => e.MucTieuCN).HasColumnName("MucTieuCN").HasMaxLength(-1);
                        
                            entity.Property(e => e.NamTN).HasColumnName("NamTN");
                        
                            entity.Property(e => e.NgayBD).HasColumnName("NgayBD");
                        
                            entity.Property(e => e.NgayCapCMND).HasColumnName("NgayCapCMND");
                        
                            entity.Property(e => e.NgayCapHC).HasColumnName("NgayCapHC");
                        
                            entity.Property(e => e.NgayCoTheLV).HasColumnName("NgayCoTheLV");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(150);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(150);
                        
                            entity.Property(e => e.NgayHetHanHC).HasColumnName("NgayHetHanHC");
                        
                            entity.Property(e => e.NgayKT).HasColumnName("NgayKT");
                        
                            entity.Property(e => e.NgayMoi).HasColumnName("NgayMoi");
                        
                            entity.Property(e => e.NgayNghiViec).HasColumnName("NgayNghiViec");
                        
                            entity.Property(e => e.NgayNhanHS).HasColumnName("NgayNhanHS");
                        
                            entity.Property(e => e.NgayNhapNgu).HasColumnName("NgayNhapNgu");
                        
                            entity.Property(e => e.NgaySinh).HasColumnName("NgaySinh");
                        
                            entity.Property(e => e.NgayThamGiaCM).HasColumnName("NgayThamGiaCM");
                        
                            entity.Property(e => e.NgayThuViec).HasColumnName("NgayThuViec");
                        
                            entity.Property(e => e.NgayTiepNhan).HasColumnName("NgayTiepNhan");
                        
                            entity.Property(e => e.NgayVaoDang).HasColumnName("NgayVaoDang");
                        
                            entity.Property(e => e.NgayVaoDoan).HasColumnName("NgayVaoDoan");
                        
                            entity.Property(e => e.NgayXuatNgu).HasColumnName("NgayXuatNgu");
                        
                            entity.Property(e => e.NgheNghiep).HasColumnName("NgheNghiep").HasMaxLength(100);
                        
                            entity.Property(e => e.NguoiDuyetNViec).HasColumnName("NguoiDuyetNViec").HasMaxLength(100);
                        
                            entity.Property(e => e.NguonTuyenDung).HasColumnName("NguonTuyenDung").HasMaxLength(250);
                        
                            entity.Property(e => e.NguyenQuan).HasColumnName("NguyenQuan").HasMaxLength(-1);
                        
                            entity.Property(e => e.NhomCap).HasColumnName("NhomCap");
                        
                            entity.Property(e => e.NhomMau).HasColumnName("NhomMau").HasMaxLength(20);
                        
                            entity.Property(e => e.NODiaChi).HasColumnName("NODiaChi").HasMaxLength(200);
                        
                            entity.Property(e => e.NoiCapBHTN).HasColumnName("NoiCapBHTN").HasMaxLength(150);
                        
                            entity.Property(e => e.NoiCapBHYT).HasColumnName("NoiCapBHYT").HasMaxLength(150);
                        
                            entity.Property(e => e.NoiCapCMND).HasColumnName("NoiCapCMND").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiCapHC).HasColumnName("NoiCapHC").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiDaoTao).HasColumnName("NoiDaoTao").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiDKKCB).HasColumnName("NoiDKKCB").HasMaxLength(50);
                        
                            entity.Property(e => e.NoiKetNapDang).HasColumnName("NoiKetNapDang").HasMaxLength(150);
                        
                            entity.Property(e => e.NoiKetNapDoan).HasColumnName("NoiKetNapDoan").HasMaxLength(150);
                        
                            entity.Property(e => e.NoiLVMongMuon).HasColumnName("NoiLVMongMuon").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiSinh).HasColumnName("NoiSinh").HasMaxLength(250);
                        
                            entity.Property(e => e.NOQuanHuyen).HasColumnName("NOQuanHuyen").HasMaxLength(100);
                        
                            entity.Property(e => e.NOQuocGia).HasColumnName("NOQuocGia").HasMaxLength(100);
                        
                            entity.Property(e => e.NOTinhThanh).HasColumnName("NOTinhThanh").HasMaxLength(100);
                        
                            entity.Property(e => e.NOXaPhuong).HasColumnName("NOXaPhuong").HasMaxLength(100);
                        
                            entity.Property(e => e.NVDTruong1).HasColumnName("NVDTruong1");
                        
                            entity.Property(e => e.NVDTruong2).HasColumnName("NVDTruong2");
                        
                            entity.Property(e => e.NVDTruong3).HasColumnName("NVDTruong3");
                        
                            entity.Property(e => e.NVDTruong4).HasColumnName("NVDTruong4");
                        
                            entity.Property(e => e.NVNTruong1).HasColumnName("NVNTruong1");
                        
                            entity.Property(e => e.NVNTruong2).HasColumnName("NVNTruong2");
                        
                            entity.Property(e => e.NVNTruong3).HasColumnName("NVNTruong3");
                        
                            entity.Property(e => e.NVNTruong4).HasColumnName("NVNTruong4");
                        
                            entity.Property(e => e.NVSTruong1).HasColumnName("NVSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.NVSTruong2).HasColumnName("NVSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.NVSTruong3).HasColumnName("NVSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.NVSTruong4).HasColumnName("NVSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(255);
                        
                            entity.Property(e => e.PhuCapLX).HasColumnName("PhuCapLX");
                        
                            entity.Property(e => e.QuanLyGianTiep).HasColumnName("QuanLyGianTiep").HasMaxLength(100);
                        
                            entity.Property(e => e.QuanLyTrucTiep).HasColumnName("QuanLyTrucTiep").HasMaxLength(100);
                        
                            entity.Property(e => e.QuocTich).HasColumnName("QuocTich").HasMaxLength(150);
                        
                            entity.Property(e => e.SKypeID).HasColumnName("SKypeID").HasMaxLength(100);
                        
                            entity.Property(e => e.SoCMND).HasColumnName("SoCMND").HasMaxLength(50);
                        
                            entity.Property(e => e.SoCongChuan).HasColumnName("SoCongChuan");
                        
                            entity.Property(e => e.SoHoChieu).HasColumnName("SoHoChieu").HasMaxLength(50);
                        
                            entity.Property(e => e.SoNamKN).HasColumnName("SoNamKN");
                        
                            entity.Property(e => e.SoNgayPhepDH).HasColumnName("SoNgayPhepDH");
                        
                            entity.Property(e => e.SoNgayThuViec).HasColumnName("SoNgayThuViec");
                        
                            entity.Property(e => e.SoSoDongBHTN).HasColumnName("SoSoDongBHTN").HasMaxLength(150);
                        
                            entity.Property(e => e.SoSoDongBHXH).HasColumnName("SoSoDongBHXH").HasMaxLength(50);
                        
                            entity.Property(e => e.SoSoLD).HasColumnName("SoSoLD").HasMaxLength(50);
                        
                            entity.Property(e => e.SoTheBHYT).HasColumnName("SoTheBHYT").HasMaxLength(100);
                        
                            entity.Property(e => e.SoThich).HasColumnName("SoThich").HasMaxLength(-1);
                        
                            entity.Property(e => e.Ten).HasColumnName("Ten").HasMaxLength(50);
                        
                            entity.Property(e => e.TenCongTyDT).HasColumnName("TenCongTyDT").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNganHang).HasColumnName("TenNganHang").HasMaxLength(255);
                        
                            entity.Property(e => e.TenNVien).HasColumnName("TenNVien").HasMaxLength(255);
                        
                            entity.Property(e => e.TenTinhCap).HasColumnName("TenTinhCap").HasMaxLength(150);
                        
                            entity.Property(e => e.ThamGiaCDoan).HasColumnName("ThamGiaCDoan");
                        
                            entity.Property(e => e.TinhLuongVC).HasColumnName("TinhLuongVC");
                        
                            entity.Property(e => e.TinhThanh).HasColumnName("TinhThanh").HasMaxLength(100);
                        
                            entity.Property(e => e.TinhTrangSK).HasColumnName("TinhTrangSK").HasMaxLength(150);
                        
                            entity.Property(e => e.TonGiao).HasColumnName("TonGiao").HasMaxLength(150);
                        
                            entity.Property(e => e.TPBanThan).HasColumnName("TPBanThan").HasMaxLength(150);
                        
                            entity.Property(e => e.TPGiaDinh).HasColumnName("TPGiaDinh").HasMaxLength(150);
                        
                            entity.Property(e => e.TrangThaiLV).HasColumnName("TrangThaiLV").HasMaxLength(150);
                        
                            entity.Property(e => e.TrangThaiUT).HasColumnName("TrangThaiUT").HasMaxLength(250);
                        
                            entity.Property(e => e.TrinhDoHocVan).HasColumnName("TrinhDoHocVan").HasMaxLength(50);
                        
                            entity.Property(e => e.TrinhDoNgoaiNgu).HasColumnName("TrinhDoNgoaiNgu").HasMaxLength(50);
                        
                            entity.Property(e => e.TrinhDoVH).HasColumnName("TrinhDoVH").HasMaxLength(150);
                        
                            entity.Property(e => e.TTHonNhan).HasColumnName("TTHonNhan").HasMaxLength(150);
                        
                            entity.Property(e => e.TuDongTangPTN).HasColumnName("TuDongTangPTN");
                        
                            entity.Property(e => e.TyLeDongBH).HasColumnName("TyLeDongBH");
                        
                            entity.Property(e => e.TyLeHuongDS).HasColumnName("TyLeHuongDS");
                        
                            entity.Property(e => e.TyLeHuongLuong).HasColumnName("TyLeHuongLuong");
                        
                            entity.Property(e => e.TyLeHuongTP).HasColumnName("TyLeHuongTP");
                        
                            entity.Property(e => e.TyLeSGLD).HasColumnName("TyLeSGLD");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.ViTriCVDT).HasColumnName("ViTriCVDT").HasMaxLength(250);
                        
                            entity.Property(e => e.ViTriCViec).HasColumnName("ViTriCViec").HasMaxLength(200);
                        
                            entity.Property(e => e.ViTriCVNQ).HasColumnName("ViTriCVNQ").HasMaxLength(200);
                        
                            entity.Property(e => e.ViTriMongMuon).HasColumnName("ViTriMongMuon").HasMaxLength(250);
                        
                            entity.Property(e => e.ViTriUT).HasColumnName("ViTriUT").HasMaxLength(250);
                        
                            entity.Property(e => e.XepLoai).HasColumnName("XepLoai").HasMaxLength(50);
                        
                            entity.Property(e => e.YahooID).HasColumnName("YahooID").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<DM_NHAXE>(entity =>
                    {
                        entity.HasKey(e => e.IDNX);
                        entity.ToTable("DM_NHAXE");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DienThoai).HasColumnName("DienThoai").HasMaxLength(150);
                        
                            entity.Property(e => e.Fax).HasColumnName("Fax").HasMaxLength(150);
                        
                            entity.Property(e => e.GiaTriXL).HasColumnName("GiaTriXL").HasMaxLength(250);
                        
                            entity.Property(e => e.IDNX).HasColumnName("IDNX");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNXe).HasColumnName("MaNXe").HasMaxLength(150);
                        
                            entity.Property(e => e.NhomNX).HasColumnName("NhomNX").HasMaxLength(250);
                        
                            entity.Property(e => e.Number1).HasColumnName("Number1");
                        
                            entity.Property(e => e.Number2).HasColumnName("Number2");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TaiXe).HasColumnName("TaiXe").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNXe).HasColumnName("TenNXe").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<DM_PHUONGTHUCVC>(entity =>
                    {
                        entity.HasKey(e => e.IDPT);
                        entity.ToTable("DM_PHUONGTHUCVC");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.GiaTriXL).HasColumnName("GiaTriXL").HasMaxLength(250);
                        
                            entity.Property(e => e.IDPT).HasColumnName("IDPT");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaPT).HasColumnName("MaPT").HasMaxLength(150);
                        
                            entity.Property(e => e.NhomVC).HasColumnName("NhomVC").HasMaxLength(250);
                        
                            entity.Property(e => e.Number1).HasColumnName("Number1");
                        
                            entity.Property(e => e.Number2).HasColumnName("Number2");
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenPT).HasColumnName("TenPT").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    //Unable to generate entity type for table 'dbo.DM_PTHUC TTOAN'. table have no primary key
                    
                    modelBuilder.Entity<DM_SU_CO>(entity =>
                    {
                        entity.HasKey(e => e.MaSuCo);
                        entity.ToTable("DM_SU CO");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.ChucDanh).HasColumnName("ChucDanh").HasMaxLength(150);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DonViLienQuan).HasColumnName("DonViLienQuan").HasMaxLength(150);
                        
                            entity.Property(e => e.FileDinhKem).HasColumnName("FileDinhKem").HasMaxLength(-1);
                        
                            entity.Property(e => e.GiaTriDuocBT).HasColumnName("GiaTriDuocBT");
                        
                            entity.Property(e => e.GiaTriPhaiBT).HasColumnName("GiaTriPhaiBT");
                        
                            entity.Property(e => e.HinhThucXL).HasColumnName("HinhThucXL").HasMaxLength(150);
                        
                            entity.Property(e => e.HoVaTen).HasColumnName("HoVaTen").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiQuyetDinh).HasColumnName("LoaiQuyetDinh").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiSC).HasColumnName("LoaiSC").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiSuCo).HasColumnName("LoaiSuCo").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(150);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSuCo).HasColumnName("MaSuCo").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSuCoLQ).HasColumnName("MaSuCoLQ").HasMaxLength(200);
                        
                            entity.Property(e => e.MoTaSCLQ).HasColumnName("MoTaSCLQ").HasMaxLength(-1);
                        
                            entity.Property(e => e.MoTaSucCo).HasColumnName("MoTaSucCo").HasMaxLength(-1);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayHieuLuc).HasColumnName("NgayHieuLuc");
                        
                            entity.Property(e => e.NgayQuyetDinh).HasColumnName("NgayQuyetDinh");
                        
                            entity.Property(e => e.NgaySayRa).HasColumnName("NgaySayRa");
                        
                            entity.Property(e => e.NgungTheoDoi).HasColumnName("NgungTheoDoi");
                        
                            entity.Property(e => e.NguoiKyQD).HasColumnName("NguoiKyQD").HasMaxLength(150);
                        
                            entity.Property(e => e.NguyenNhan).HasColumnName("NguyenNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.NhomSC).HasColumnName("NhomSC").HasMaxLength(150);
                        
                            entity.Property(e => e.NoiDungQD).HasColumnName("NoiDungQD").HasMaxLength(-1);
                        
                            entity.Property(e => e.NoiSayRa).HasColumnName("NoiSayRa").HasMaxLength(250);
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(150);
                        
                            entity.Property(e => e.SCNVNTruong1).HasColumnName("SCNVNTruong1");
                        
                            entity.Property(e => e.SCNVNTruong2).HasColumnName("SCNVNTruong2");
                        
                            entity.Property(e => e.SCNVNTruong3).HasColumnName("SCNVNTruong3");
                        
                            entity.Property(e => e.SCNVNTruong4).HasColumnName("SCNVNTruong4");
                        
                            entity.Property(e => e.SCNVNTruong5).HasColumnName("SCNVNTruong5");
                        
                            entity.Property(e => e.SCNVSTruong1).HasColumnName("SCNVSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.SCNVSTruong2).HasColumnName("SCNVSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.SCNVSTruong3).HasColumnName("SCNVSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.SCNVSTruong4).HasColumnName("SCNVSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.SCNVSTruong5).HasColumnName("SCNVSTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.SoQuyetDinh).HasColumnName("SoQuyetDinh").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenDinhKem).HasColumnName("TenDinhKem").HasMaxLength(250);
                        
                            entity.Property(e => e.TenSuCo).HasColumnName("TenSuCo").HasMaxLength(250);
                        
                            entity.Property(e => e.TongGTBoiThuong).HasColumnName("TongGTBoiThuong");
                        
                            entity.Property(e => e.TongGTThietHai).HasColumnName("TongGTThietHai");
                        
                            entity.Property(e => e.TrangThai).HasColumnName("TrangThai").HasMaxLength(200);
                        
                            entity.Property(e => e.TrangThaiLQ).HasColumnName("TrangThaiLQ").HasMaxLength(200);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.ViTriCViec).HasColumnName("ViTriCViec").HasMaxLength(150);
                        
                    });
                    
                    modelBuilder.Entity<DM_TAIKHOAN>(entity =>
                    {
                        entity.HasKey(e => e.MaTK);
                        entity.ToTable("DM_TAIKHOAN");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.LaTKCha).HasColumnName("LaTKCha");
                        
                            entity.Property(e => e.LaTKCNo).HasColumnName("LaTKCNo");
                        
                            entity.Property(e => e.LaTKHopDong).HasColumnName("LaTKHopDong");
                        
                            entity.Property(e => e.LaTKKho).HasColumnName("LaTKKho");
                        
                            entity.Property(e => e.LaTKNganHang).HasColumnName("LaTKNganHang");
                        
                            entity.Property(e => e.LaTKNgoaiTe).HasColumnName("LaTKNgoaiTe");
                        
                            entity.Property(e => e.LaTKSanXuat).HasColumnName("LaTKSanXuat");
                        
                            entity.Property(e => e.LoaiTK).HasColumnName("LoaiTK").HasMaxLength(20);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTK).HasColumnName("MaTK").HasMaxLength(50);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(150);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(150);
                        
                            entity.Property(e => e.NhomCap).HasColumnName("NhomCap");
                        
                            entity.Property(e => e.NhomTK).HasColumnName("NhomTK").HasMaxLength(30);
                        
                            entity.Property(e => e.TenTKC).HasColumnName("TenTKC").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKE).HasColumnName("TenTKE").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKF).HasColumnName("TenTKF").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKJ).HasColumnName("TenTKJ").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKK).HasColumnName("TenTKK").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKO).HasColumnName("TenTKO").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKV).HasColumnName("TenTKV").HasMaxLength(250);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<DM_TAKCHUNG>(entity =>
                    {
                        entity.HasKey(e => e.IDKT);
                        entity.ToTable("DM_TAKCHUNG");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.IDKT).HasColumnName("IDKT").HasMaxLength(100);
                        
                            entity.Property(e => e.LaTKCha).HasColumnName("LaTKCha");
                        
                            entity.Property(e => e.LaTKCNo).HasColumnName("LaTKCNo");
                        
                            entity.Property(e => e.LaTKHopDong).HasColumnName("LaTKHopDong");
                        
                            entity.Property(e => e.LaTKKho).HasColumnName("LaTKKho");
                        
                            entity.Property(e => e.LaTKNganHang).HasColumnName("LaTKNganHang");
                        
                            entity.Property(e => e.LaTKNgoaiTe).HasColumnName("LaTKNgoaiTe");
                        
                            entity.Property(e => e.LaTKSanXuat).HasColumnName("LaTKSanXuat");
                        
                            entity.Property(e => e.LoaiQD).HasColumnName("LoaiQD").HasMaxLength(20);
                        
                            entity.Property(e => e.LoaiTK).HasColumnName("LoaiTK").HasMaxLength(20);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTK).HasColumnName("MaTK").HasMaxLength(50);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(150);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(150);
                        
                            entity.Property(e => e.NhomCap).HasColumnName("NhomCap");
                        
                            entity.Property(e => e.NhomTK).HasColumnName("NhomTK").HasMaxLength(30);
                        
                            entity.Property(e => e.TenTKC).HasColumnName("TenTKC").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKE).HasColumnName("TenTKE").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKF).HasColumnName("TenTKF").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKJ).HasColumnName("TenTKJ").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKK).HasColumnName("TenTKK").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKO).HasColumnName("TenTKO").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKV).HasColumnName("TenTKV").HasMaxLength(250);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<DM_THONGKE>(entity =>
                    {
                        entity.HasKey(e => e.IDTKE);
                        entity.ToTable("DM_THONGKE");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.BHTNDS).HasColumnName("BHTNDS").HasMaxLength(10);
                        
                            entity.Property(e => e.BHVatChat).HasColumnName("BHVatChat").HasMaxLength(50);
                        
                            entity.Property(e => e.BienSoCu).HasColumnName("BienSoCu").HasMaxLength(50);
                        
                            entity.Property(e => e.ChatLuong).HasColumnName("ChatLuong").HasMaxLength(50);
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.CongSuat).HasColumnName("CongSuat");
                        
                            entity.Property(e => e.DangKyL1).HasColumnName("DangKyL1");
                        
                            entity.Property(e => e.DauChenhLech).HasColumnName("DauChenhLech");
                        
                            entity.Property(e => e.DauDauThang).HasColumnName("DauDauThang");
                        
                            entity.Property(e => e.DauMuaVao).HasColumnName("DauMuaVao");
                        
                            entity.Property(e => e.DauTieuHao).HasColumnName("DauTieuHao");
                        
                            entity.Property(e => e.DauTonCuoi).HasColumnName("DauTonCuoi");
                        
                            entity.Property(e => e.DauTonDau).HasColumnName("DauTonDau");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DonGiaDauBQ).HasColumnName("DonGiaDauBQ");
                        
                            entity.Property(e => e.DungTichXiLanh).HasColumnName("DungTichXiLanh");
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.GiaTriHD).HasColumnName("GiaTriHD");
                        
                            entity.Property(e => e.GiaTriTTe).HasColumnName("GiaTriTTe");
                        
                            entity.Property(e => e.HanBHTNDS).HasColumnName("HanBHTNDS");
                        
                            entity.Property(e => e.HanBHVC).HasColumnName("HanBHVC");
                        
                            entity.Property(e => e.HanKiemDinh).HasColumnName("HanKiemDinh").HasMaxLength(50);
                        
                            entity.Property(e => e.IDTKE).HasColumnName("IDTKE");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.KhuVuc).HasColumnName("KhuVuc").HasMaxLength(150);
                        
                            entity.Property(e => e.KichThuocBao).HasColumnName("KichThuocBao").HasMaxLength(100);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.LaMooc).HasColumnName("LaMooc");
                        
                            entity.Property(e => e.Latitude).HasColumnName("Latitude");
                        
                            entity.Property(e => e.LePhiTBST).HasColumnName("LePhiTBST");
                        
                            entity.Property(e => e.LichKiemDinh).HasColumnName("LichKiemDinh");
                        
                            entity.Property(e => e.LoaiNhienLieu).HasColumnName("LoaiNhienLieu").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiPT).HasColumnName("LoaiPT").HasMaxLength(150);
                        
                            entity.Property(e => e.Longitude).HasColumnName("Longitude");
                        
                            entity.Property(e => e.LopTruc1).HasColumnName("LopTruc1").HasMaxLength(50);
                        
                            entity.Property(e => e.LopTruc2).HasColumnName("LopTruc2").HasMaxLength(50);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNCCCNG).HasColumnName("MaNCCCNG").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTKe).HasColumnName("MaTKe").HasMaxLength(50);
                        
                            entity.Property(e => e.MauSac).HasColumnName("MauSac").HasMaxLength(250);
                        
                            entity.Property(e => e.MucTHNL).HasColumnName("MucTHNL");
                        
                            entity.Property(e => e.MucTHNLDN).HasColumnName("MucTHNLDN");
                        
                            entity.Property(e => e.MucTHNLKT).HasColumnName("MucTHNLKT");
                        
                            entity.Property(e => e.NamHetHan).HasColumnName("NamHetHan");
                        
                            entity.Property(e => e.NamSX).HasColumnName("NamSX");
                        
                            entity.Property(e => e.NgayGioTTX).HasColumnName("NgayGioTTX");
                        
                            entity.Property(e => e.NhomCap).HasColumnName("NhomCap");
                        
                            entity.Property(e => e.NhomTKe).HasColumnName("NhomTKe").HasMaxLength(150);
                        
                            entity.Property(e => e.NuocSX).HasColumnName("NuocSX").HasMaxLength(50);
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.SoChuyenLK).HasColumnName("SoChuyenLK");
                        
                            entity.Property(e => e.SoDangKy).HasColumnName("SoDangKy").HasMaxLength(50);
                        
                            entity.Property(e => e.SoKhung).HasColumnName("SoKhung").HasMaxLength(50);
                        
                            entity.Property(e => e.SoKMChay).HasColumnName("SoKMChay");
                        
                            entity.Property(e => e.SoKMLK).HasColumnName("SoKMLK");
                        
                            entity.Property(e => e.SoKMTTThangHT).HasColumnName("SoKMTTThangHT");
                        
                            entity.Property(e => e.SoMay).HasColumnName("SoMay").HasMaxLength(50);
                        
                            entity.Property(e => e.SoMooc).HasColumnName("SoMooc").HasMaxLength(50);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.Tai0105T).HasColumnName("Tai0105T");
                        
                            entity.Property(e => e.Tai0610T).HasColumnName("Tai0610T");
                        
                            entity.Property(e => e.Tai1115T).HasColumnName("Tai1115T");
                        
                            entity.Property(e => e.Tai1620T).HasColumnName("Tai1620T");
                        
                            entity.Property(e => e.Tai2125T).HasColumnName("Tai2125T");
                        
                            entity.Property(e => e.Tai2631T).HasColumnName("Tai2631T");
                        
                            entity.Property(e => e.Tai3235T).HasColumnName("Tai3235T");
                        
                            entity.Property(e => e.TaiTren35T).HasColumnName("TaiTren35T");
                        
                            entity.Property(e => e.TaiTrong).HasColumnName("TaiTrong");
                        
                            entity.Property(e => e.TenNCCCNG).HasColumnName("TenNCCCNG").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKe).HasColumnName("TenTKe").HasMaxLength(250);
                        
                            entity.Property(e => e.ThemXD1KMDN).HasColumnName("ThemXD1KMDN");
                        
                            entity.Property(e => e.ThoiDiemCG).HasColumnName("ThoiDiemCG");
                        
                            entity.Property(e => e.ThoiGianKH).HasColumnName("ThoiGianKH");
                        
                            entity.Property(e => e.TienDauCL).HasColumnName("TienDauCL");
                        
                            entity.Property(e => e.TienDauDauThang).HasColumnName("TienDauDauThang");
                        
                            entity.Property(e => e.TienDauDM).HasColumnName("TienDauDM");
                        
                            entity.Property(e => e.TienDauMuaVao).HasColumnName("TienDauMuaVao");
                        
                            entity.Property(e => e.TienDauTieuHao).HasColumnName("TienDauTieuHao");
                        
                            entity.Property(e => e.TienDauTonCuoi).HasColumnName("TienDauTonCuoi");
                        
                            entity.Property(e => e.TienDauTonDau).HasColumnName("TienDauTonDau");
                        
                            entity.Property(e => e.TinhDenNgay).HasColumnName("TinhDenNgay");
                        
                            entity.Property(e => e.TinhTrang).HasColumnName("TinhTrang").HasMaxLength(150);
                        
                            entity.Property(e => e.TinhTrangDC).HasColumnName("TinhTrangDC").HasMaxLength(50);
                        
                            entity.Property(e => e.TongDauDM).HasColumnName("TongDauDM");
                        
                            entity.Property(e => e.TongLVCThang).HasColumnName("TongLVCThang");
                        
                            entity.Property(e => e.TrongLuongALL).HasColumnName("TrongLuongALL");
                        
                            entity.Property(e => e.TuTrong).HasColumnName("TuTrong");
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                            entity.Property(e => e.XeNgoai).HasColumnName("XeNgoai");
                        
                    });
                    
                    modelBuilder.Entity<DM_TKNGANHANG>(entity =>
                    {
                        entity.HasKey(e => e.SoTK);
                        entity.ToTable("DM_TKNGANHANG");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.Logo).HasColumnName("Logo").HasMaxLength(2147483647);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(30);
                        
                            entity.Property(e => e.MaTK).HasColumnName("MaTK").HasMaxLength(20);
                        
                            entity.Property(e => e.MatKhau).HasColumnName("MatKhau").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTruyCap).HasColumnName("MaTruyCap").HasMaxLength(50);
                        
                            entity.Property(e => e.MKTucThoi).HasColumnName("MKTucThoi");
                        
                            entity.Property(e => e.MoTaiNH).HasColumnName("MoTaiNH").HasMaxLength(250);
                        
                            entity.Property(e => e.NhomNH).HasColumnName("NhomNH").HasMaxLength(50);
                        
                            entity.Property(e => e.SoDuCo).HasColumnName("SoDuCo");
                        
                            entity.Property(e => e.SoDuNo).HasColumnName("SoDuNo");
                        
                            entity.Property(e => e.SoTK).HasColumnName("SoTK").HasMaxLength(50);
                        
                            entity.Property(e => e.TenNH).HasColumnName("TenNH").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<DM_TO_KHAI_HQ>(entity =>
                    {
                        entity.HasKey(e => e.IDTK);
                        entity.ToTable("DM_TO_KHAI_HQ");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CangDen).HasColumnName("CangDen").HasMaxLength(250);
                        
                            entity.Property(e => e.CangDi).HasColumnName("CangDi").HasMaxLength(250);
                        
                            entity.Property(e => e.CangDo).HasColumnName("CangDo").HasMaxLength(250);
                        
                            entity.Property(e => e.CangXep).HasColumnName("CangXep").HasMaxLength(250);
                        
                            entity.Property(e => e.ChiCucHQ).HasColumnName("ChiCucHQ").HasMaxLength(250);
                        
                            entity.Property(e => e.ChucVuDD).HasColumnName("ChucVuDD").HasMaxLength(100);
                        
                            entity.Property(e => e.ChucVuDDNN).HasColumnName("ChucVuDDNN").HasMaxLength(250);
                        
                            entity.Property(e => e.Cont20).HasColumnName("Cont20");
                        
                            entity.Property(e => e.Cont40).HasColumnName("Cont40");
                        
                            entity.Property(e => e.ContT1).HasColumnName("ContT1");
                        
                            entity.Property(e => e.ContT2).HasColumnName("ContT2");
                        
                            entity.Property(e => e.ContT3).HasColumnName("ContT3");
                        
                            entity.Property(e => e.CoThue).HasColumnName("CoThue");
                        
                            entity.Property(e => e.CuaKhau).HasColumnName("CuaKhau").HasMaxLength(250);
                        
                            entity.Property(e => e.CucHaiQuan).HasColumnName("CucHaiQuan").HasMaxLength(250);
                        
                            entity.Property(e => e.CuocVC).HasColumnName("CuocVC");
                        
                            entity.Property(e => e.DeNghi).HasColumnName("DeNghi").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiCCHQ).HasColumnName("DiaChiCCHQ").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiCHQ).HasColumnName("DiaChiCHQ").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiDLNN).HasColumnName("DiaChiDLNN").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNDD).HasColumnName("DiaChiNDD").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNDDNN).HasColumnName("DiaChiNDDNN").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNDL).HasColumnName("DiaChiNDL").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNNK).HasColumnName("DiaChiNNK").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNUT).HasColumnName("DiaChiNUT").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNUT2).HasColumnName("DiaChiNUT2").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNXK).HasColumnName("DiaChiNXK").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaDiemDo).HasColumnName("DiaDiemDo").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaDiemXep).HasColumnName("DiaDiemXep").HasMaxLength(250);
                        
                            entity.Property(e => e.DiemLuuKho).HasColumnName("DiemLuuKho").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuVBPQ).HasColumnName("GhiChuVBPQ").HasMaxLength(50);
                        
                            entity.Property(e => e.GhiChuVBPQ2).HasColumnName("GhiChuVBPQ2").HasMaxLength(50);
                        
                            entity.Property(e => e.GhiChuVBPQ3).HasColumnName("GhiChuVBPQ3").HasMaxLength(50);
                        
                            entity.Property(e => e.GhiChuVBPQ4).HasColumnName("GhiChuVBPQ4").HasMaxLength(50);
                        
                            entity.Property(e => e.GhiChuVBPQ5).HasColumnName("GhiChuVBPQ5").HasMaxLength(50);
                        
                            entity.Property(e => e.GPXNK).HasColumnName("GPXNK").HasMaxLength(50);
                        
                            entity.Property(e => e.GPXNK2).HasColumnName("GPXNK2").HasMaxLength(50);
                        
                            entity.Property(e => e.GPXNK3).HasColumnName("GPXNK3").HasMaxLength(50);
                        
                            entity.Property(e => e.GPXNK4).HasColumnName("GPXNK4").HasMaxLength(50);
                        
                            entity.Property(e => e.GPXNK5).HasColumnName("GPXNK5").HasMaxLength(50);
                        
                            entity.Property(e => e.IDTK).HasColumnName("IDTK");
                        
                            entity.Property(e => e.KyHieuSHBB).HasColumnName("KyHieuSHBB").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiHang).HasColumnName("LoaiHang").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiHinh).HasColumnName("LoaiHinh").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiHinhKhac).HasColumnName("LoaiHinhKhac").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiKhach).HasColumnName("LoaiKhach").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiNX).HasColumnName("LoaiNX").HasMaxLength(10);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.LoaiPT).HasColumnName("LoaiPT").HasMaxLength(100);
                        
                            entity.Property(e => e.MaBPXL).HasColumnName("MaBPXL").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDaiLyNN).HasColumnName("MaDaiLyNN").HasMaxLength(50);
                        
                            entity.Property(e => e.MaDKGH).HasColumnName("MaDKGH").HasMaxLength(250);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNguoiDD).HasColumnName("MaNguoiDD").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNguoiDDNN).HasColumnName("MaNguoiDDNN").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNguoiDL).HasColumnName("MaNguoiDL").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNguoiNK).HasColumnName("MaNguoiNK").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNguoiUT).HasColumnName("MaNguoiUT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNguoiUT2).HasColumnName("MaNguoiUT2").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNguoiXK).HasColumnName("MaNguoiXK").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVienKD).HasColumnName("MaNVienKD").HasMaxLength(50);
                        
                            entity.Property(e => e.MaPLKT).HasColumnName("MaPLKT").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVBPQ).HasColumnName("MaVBPQ").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVBPQ2).HasColumnName("MaVBPQ2").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVBPQ3).HasColumnName("MaVBPQ3").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVBPQ4).HasColumnName("MaVBPQ4").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVBPQ5).HasColumnName("MaVBPQ5").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayBill).HasColumnName("NgayBill");
                        
                            entity.Property(e => e.NgayBill2).HasColumnName("NgayBill2");
                        
                            entity.Property(e => e.NgayBill3).HasColumnName("NgayBill3");
                        
                            entity.Property(e => e.NgayBill4).HasColumnName("NgayBill4");
                        
                            entity.Property(e => e.NgayBill5).HasColumnName("NgayBill5");
                        
                            entity.Property(e => e.NgayCTLH).HasColumnName("NgayCTLH");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayHetHan).HasColumnName("NgayHetHan");
                        
                            entity.Property(e => e.NgayHetHD).HasColumnName("NgayHetHD");
                        
                            entity.Property(e => e.NgayHetHHX).HasColumnName("NgayHetHHX");
                        
                            entity.Property(e => e.NgayHoaDon).HasColumnName("NgayHoaDon");
                        
                            entity.Property(e => e.NgayHoatDong).HasColumnName("NgayHoatDong");
                        
                            entity.Property(e => e.NgayHopDong).HasColumnName("NgayHopDong");
                        
                            entity.Property(e => e.NgayTiepNhan).HasColumnName("NgayTiepNhan");
                        
                            entity.Property(e => e.NgayTLyHD).HasColumnName("NgayTLyHD");
                        
                            entity.Property(e => e.NgayToKhai).HasColumnName("NgayToKhai");
                        
                            entity.Property(e => e.NguoiGui).HasColumnName("NguoiGui").HasMaxLength(250);
                        
                            entity.Property(e => e.NguoiNhan).HasColumnName("NguoiNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.NhapBangChu).HasColumnName("NhapBangChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.NoiHa).HasColumnName("NoiHa").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiNhan).HasColumnName("NoiNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.NopCho).HasColumnName("NopCho").HasMaxLength(250);
                        
                            entity.Property(e => e.NuocNX).HasColumnName("NuocNX").HasMaxLength(50);
                        
                            entity.Property(e => e.PhanHoiHQ).HasColumnName("PhanHoiHQ");
                        
                            entity.Property(e => e.PhanLoaiXBC).HasColumnName("PhanLoaiXBC").HasMaxLength(50);
                        
                            entity.Property(e => e.PhiBaoHiem).HasColumnName("PhiBaoHiem");
                        
                            entity.Property(e => e.PTTT).HasColumnName("PTTT").HasMaxLength(50);
                        
                            entity.Property(e => e.RecBOB).HasColumnName("RecBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(50);
                        
                            entity.Property(e => e.RecLOT).HasColumnName("RecLOT").HasMaxLength(100);
                        
                            entity.Property(e => e.RecPH).HasColumnName("RecPH").HasMaxLength(50);
                        
                            entity.Property(e => e.RECXL).HasColumnName("RECXL").HasMaxLength(50);
                        
                            entity.Property(e => e.SHKienCont).HasColumnName("SHKienCont").HasMaxLength(100);
                        
                            entity.Property(e => e.SLCont).HasColumnName("SLCont");
                        
                            entity.Property(e => e.SLToKhai).HasColumnName("SLToKhai");
                        
                            entity.Property(e => e.SoBill).HasColumnName("SoBill").HasMaxLength(50);
                        
                            entity.Property(e => e.SoBill2).HasColumnName("SoBill2").HasMaxLength(50);
                        
                            entity.Property(e => e.SoBill3).HasColumnName("SoBill3").HasMaxLength(50);
                        
                            entity.Property(e => e.SoBill4).HasColumnName("SoBill4").HasMaxLength(50);
                        
                            entity.Property(e => e.SoBill5).HasColumnName("SoBill5").HasMaxLength(50);
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.SoCTLH).HasColumnName("SoCTLH").HasMaxLength(50);
                        
                            entity.Property(e => e.SoGPKD).HasColumnName("SoGPKD").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHoaDon).HasColumnName("SoHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHopDong).HasColumnName("SoHopDong").HasMaxLength(50);
                        
                            entity.Property(e => e.SoKien).HasColumnName("SoKien");
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoThamChieu).HasColumnName("SoThamChieu").HasMaxLength(50);
                        
                            entity.Property(e => e.SoThem1).HasColumnName("SoThem1");
                        
                            entity.Property(e => e.SoThem2).HasColumnName("SoThem2");
                        
                            entity.Property(e => e.SoTiepNhan).HasColumnName("SoTiepNhan").HasMaxLength(50);
                        
                            entity.Property(e => e.SoToKhai).HasColumnName("SoToKhai").HasMaxLength(50);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenDaiLyNN).HasColumnName("TenDaiLyNN").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDKGH).HasColumnName("TenDKGH").HasMaxLength(250);
                        
                            entity.Property(e => e.TenLoaiHinh).HasColumnName("TenLoaiHinh").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiDD).HasColumnName("TenNguoiDD").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiDDNN).HasColumnName("TenNguoiDDNN").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiDL).HasColumnName("TenNguoiDL").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiNK).HasColumnName("TenNguoiNK").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiUT).HasColumnName("TenNguoiUT").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiUT2).HasColumnName("TenNguoiUT2").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiXK).HasColumnName("TenNguoiXK").HasMaxLength(250);
                        
                            entity.Property(e => e.TenSHPT).HasColumnName("TenSHPT").HasMaxLength(100);
                        
                            entity.Property(e => e.TheoDonGia).HasColumnName("TheoDonGia");
                        
                            entity.Property(e => e.TheoSoLuong).HasColumnName("TheoSoLuong");
                        
                            entity.Property(e => e.ThoiHanTaiNX).HasColumnName("ThoiHanTaiNX");
                        
                            entity.Property(e => e.ThoiHanTNX).HasColumnName("ThoiHanTNX");
                        
                            entity.Property(e => e.ThueGTGT).HasColumnName("ThueGTGT");
                        
                            entity.Property(e => e.ThueNK).HasColumnName("ThueNK");
                        
                            entity.Property(e => e.ThueTTDB).HasColumnName("ThueTTDB");
                        
                            entity.Property(e => e.ThuKhac).HasColumnName("ThuKhac");
                        
                            entity.Property(e => e.TienBangChu).HasColumnName("TienBangChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.TienGTGT).HasColumnName("TienGTGT");
                        
                            entity.Property(e => e.TienThueNK).HasColumnName("TienThueNK");
                        
                            entity.Property(e => e.TienThueTTDB).HasColumnName("TienThueTTDB");
                        
                            entity.Property(e => e.TienThuKhac).HasColumnName("TienThuKhac");
                        
                            entity.Property(e => e.ToKBit1).HasColumnName("ToKBit1");
                        
                            entity.Property(e => e.ToKBit2).HasColumnName("ToKBit2");
                        
                            entity.Property(e => e.ToKBit3).HasColumnName("ToKBit3");
                        
                            entity.Property(e => e.ToKDate1).HasColumnName("ToKDate1");
                        
                            entity.Property(e => e.ToKDate2).HasColumnName("ToKDate2");
                        
                            entity.Property(e => e.ToKDate3).HasColumnName("ToKDate3");
                        
                            entity.Property(e => e.ToKDate4).HasColumnName("ToKDate4");
                        
                            entity.Property(e => e.ToKDate5).HasColumnName("ToKDate5");
                        
                            entity.Property(e => e.ToKInt1).HasColumnName("ToKInt1");
                        
                            entity.Property(e => e.ToKInt2).HasColumnName("ToKInt2");
                        
                            entity.Property(e => e.ToKInt3).HasColumnName("ToKInt3");
                        
                            entity.Property(e => e.ToKInt4).HasColumnName("ToKInt4");
                        
                            entity.Property(e => e.ToKInt5).HasColumnName("ToKInt5");
                        
                            entity.Property(e => e.ToKNumber1).HasColumnName("ToKNumber1");
                        
                            entity.Property(e => e.ToKNumber2).HasColumnName("ToKNumber2");
                        
                            entity.Property(e => e.ToKNumber3).HasColumnName("ToKNumber3");
                        
                            entity.Property(e => e.ToKNumber4).HasColumnName("ToKNumber4");
                        
                            entity.Property(e => e.ToKNumber5).HasColumnName("ToKNumber5");
                        
                            entity.Property(e => e.ToKString1).HasColumnName("ToKString1").HasMaxLength(50);
                        
                            entity.Property(e => e.ToKString10).HasColumnName("ToKString10").HasMaxLength(-1);
                        
                            entity.Property(e => e.ToKString2).HasColumnName("ToKString2").HasMaxLength(50);
                        
                            entity.Property(e => e.ToKString3).HasColumnName("ToKString3").HasMaxLength(50);
                        
                            entity.Property(e => e.ToKString4).HasColumnName("ToKString4").HasMaxLength(100);
                        
                            entity.Property(e => e.ToKString5).HasColumnName("ToKString5").HasMaxLength(100);
                        
                            entity.Property(e => e.ToKString6).HasColumnName("ToKString6").HasMaxLength(100);
                        
                            entity.Property(e => e.ToKString7).HasColumnName("ToKString7").HasMaxLength(250);
                        
                            entity.Property(e => e.ToKString8).HasColumnName("ToKString8").HasMaxLength(250);
                        
                            entity.Property(e => e.ToKString9).HasColumnName("ToKString9").HasMaxLength(250);
                        
                            entity.Property(e => e.TongSoTien).HasColumnName("TongSoTien");
                        
                            entity.Property(e => e.TongTienThue).HasColumnName("TongTienThue");
                        
                            entity.Property(e => e.TrangThai).HasColumnName("TrangThai").HasMaxLength(150);
                        
                            entity.Property(e => e.TrongLuong).HasColumnName("TrongLuong").HasMaxLength(100);
                        
                            entity.Property(e => e.TuPhanBo).HasColumnName("TuPhanBo");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<DM_TYGIA>(entity =>
                    {
                        entity.HasKey(e => e.MaTienTe);
                        entity.ToTable("DM_TYGIA");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.Date1).HasColumnName("Date1");
                        
                            entity.Property(e => e.Date2).HasColumnName("Date2");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(30);
                        
                            entity.Property(e => e.Ngay).HasColumnName("Ngay");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(30);
                        
                            entity.Property(e => e.Number1).HasColumnName("Number1");
                        
                            entity.Property(e => e.Number2).HasColumnName("Number2");
                        
                            entity.Property(e => e.Number3).HasColumnName("Number3");
                        
                            entity.Property(e => e.TenTienTe).HasColumnName("TenTienTe").HasMaxLength(250);
                        
                            entity.Property(e => e.Text1).HasColumnName("Text1").HasMaxLength(250);
                        
                            entity.Property(e => e.Text2).HasColumnName("Text2").HasMaxLength(250);
                        
                            entity.Property(e => e.Text3).HasColumnName("Text3").HasMaxLength(250);
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(30);
                        
                    });
                    
                    modelBuilder.Entity<DM_VANDON>(entity =>
                    {
                        entity.HasKey(e => e.IDVD);
                        entity.ToTable("DM_VANDON");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.BenNiemPhong).HasColumnName("BenNiemPhong").HasMaxLength(250);
                        
                            entity.Property(e => e.BLBit1).HasColumnName("BLBit1");
                        
                            entity.Property(e => e.BLBit2).HasColumnName("BLBit2");
                        
                            entity.Property(e => e.BLBit3).HasColumnName("BLBit3");
                        
                            entity.Property(e => e.BLDate1).HasColumnName("BLDate1");
                        
                            entity.Property(e => e.BLDate2).HasColumnName("BLDate2");
                        
                            entity.Property(e => e.BLDate3).HasColumnName("BLDate3");
                        
                            entity.Property(e => e.BLDate4).HasColumnName("BLDate4");
                        
                            entity.Property(e => e.BLDate5).HasColumnName("BLDate5");
                        
                            entity.Property(e => e.BLInt1).HasColumnName("BLInt1");
                        
                            entity.Property(e => e.BLInt2).HasColumnName("BLInt2");
                        
                            entity.Property(e => e.BLInt3).HasColumnName("BLInt3");
                        
                            entity.Property(e => e.BLInt4).HasColumnName("BLInt4");
                        
                            entity.Property(e => e.BLInt5).HasColumnName("BLInt5");
                        
                            entity.Property(e => e.BLNumber1).HasColumnName("BLNumber1");
                        
                            entity.Property(e => e.BLNumber2).HasColumnName("BLNumber2");
                        
                            entity.Property(e => e.BLNumber3).HasColumnName("BLNumber3");
                        
                            entity.Property(e => e.BLNumber4).HasColumnName("BLNumber4");
                        
                            entity.Property(e => e.BLNumber5).HasColumnName("BLNumber5");
                        
                            entity.Property(e => e.BLString1).HasColumnName("BLString1").HasMaxLength(50);
                        
                            entity.Property(e => e.BLString10).HasColumnName("BLString10").HasMaxLength(-1);
                        
                            entity.Property(e => e.BLString2).HasColumnName("BLString2").HasMaxLength(50);
                        
                            entity.Property(e => e.BLString3).HasColumnName("BLString3").HasMaxLength(50);
                        
                            entity.Property(e => e.BLString4).HasColumnName("BLString4").HasMaxLength(100);
                        
                            entity.Property(e => e.BLString5).HasColumnName("BLString5").HasMaxLength(100);
                        
                            entity.Property(e => e.BLString6).HasColumnName("BLString6").HasMaxLength(100);
                        
                            entity.Property(e => e.BLString7).HasColumnName("BLString7").HasMaxLength(250);
                        
                            entity.Property(e => e.BLString8).HasColumnName("BLString8").HasMaxLength(250);
                        
                            entity.Property(e => e.BLString9).HasColumnName("BLString9").HasMaxLength(250);
                        
                            entity.Property(e => e.CangCT).HasColumnName("CangCT").HasMaxLength(100);
                        
                            entity.Property(e => e.CangDen).HasColumnName("CangDen").HasMaxLength(250);
                        
                            entity.Property(e => e.CangDi).HasColumnName("CangDi").HasMaxLength(250);
                        
                            entity.Property(e => e.CangDo).HasColumnName("CangDo").HasMaxLength(250);
                        
                            entity.Property(e => e.CangXep).HasColumnName("CangXep").HasMaxLength(250);
                        
                            entity.Property(e => e.CatKienBan).HasColumnName("CatKienBan");
                        
                            entity.Property(e => e.CatSLBan).HasColumnName("CatSLBan");
                        
                            entity.Property(e => e.ChiCucHQ).HasColumnName("ChiCucHQ").HasMaxLength(100);
                        
                            entity.Property(e => e.ChucVuDD).HasColumnName("ChucVuDD").HasMaxLength(250);
                        
                            entity.Property(e => e.ChucVuDDNN).HasColumnName("ChucVuDDNN").HasMaxLength(250);
                        
                            entity.Property(e => e.ChuoiCacCont).HasColumnName("ChuoiCacCont").HasMaxLength(-1);
                        
                            entity.Property(e => e.Cont20).HasColumnName("Cont20");
                        
                            entity.Property(e => e.Cont40).HasColumnName("Cont40");
                        
                            entity.Property(e => e.Cont45).HasColumnName("Cont45");
                        
                            entity.Property(e => e.ContT1).HasColumnName("ContT1");
                        
                            entity.Property(e => e.ContT2).HasColumnName("ContT2");
                        
                            entity.Property(e => e.ContT3).HasColumnName("ContT3");
                        
                            entity.Property(e => e.CoTheTraTai).HasColumnName("CoTheTraTai").HasMaxLength(250);
                        
                            entity.Property(e => e.CP_CE01).HasColumnName("CP_CE01");
                        
                            entity.Property(e => e.CP_CE02).HasColumnName("CP_CE02");
                        
                            entity.Property(e => e.CP_CE03).HasColumnName("CP_CE03");
                        
                            entity.Property(e => e.CP_CE04).HasColumnName("CP_CE04");
                        
                            entity.Property(e => e.CP_CE05).HasColumnName("CP_CE05");
                        
                            entity.Property(e => e.CP_CE06).HasColumnName("CP_CE06");
                        
                            entity.Property(e => e.CP_CE07).HasColumnName("CP_CE07");
                        
                            entity.Property(e => e.CP_CE08).HasColumnName("CP_CE08");
                        
                            entity.Property(e => e.CP_CE09).HasColumnName("CP_CE09");
                        
                            entity.Property(e => e.CP_CE10).HasColumnName("CP_CE10");
                        
                            entity.Property(e => e.CP_CE11).HasColumnName("CP_CE11");
                        
                            entity.Property(e => e.CP_CE12).HasColumnName("CP_CE12");
                        
                            entity.Property(e => e.CP_CE13).HasColumnName("CP_CE13");
                        
                            entity.Property(e => e.CP_CE14).HasColumnName("CP_CE14");
                        
                            entity.Property(e => e.CP_CE15).HasColumnName("CP_CE15");
                        
                            entity.Property(e => e.CP_CE16).HasColumnName("CP_CE16");
                        
                            entity.Property(e => e.CP_CE17).HasColumnName("CP_CE17");
                        
                            entity.Property(e => e.CP_CE18).HasColumnName("CP_CE18");
                        
                            entity.Property(e => e.CP_CE19).HasColumnName("CP_CE19");
                        
                            entity.Property(e => e.CP_CE20).HasColumnName("CP_CE20");
                        
                            entity.Property(e => e.CP_CE21).HasColumnName("CP_CE21");
                        
                            entity.Property(e => e.CP_CE22).HasColumnName("CP_CE22");
                        
                            entity.Property(e => e.CP_CE23).HasColumnName("CP_CE23");
                        
                            entity.Property(e => e.CP_CE24).HasColumnName("CP_CE24");
                        
                            entity.Property(e => e.CP_CE25).HasColumnName("CP_CE25");
                        
                            entity.Property(e => e.CP_CE26).HasColumnName("CP_CE26");
                        
                            entity.Property(e => e.CP_RE01).HasColumnName("CP_RE01");
                        
                            entity.Property(e => e.CP_RE03).HasColumnName("CP_RE03");
                        
                            entity.Property(e => e.CP_TE01).HasColumnName("CP_TE01");
                        
                            entity.Property(e => e.CP_TE02).HasColumnName("CP_TE02");
                        
                            entity.Property(e => e.CP_VE02).HasColumnName("CP_VE02");
                        
                            entity.Property(e => e.CP_VE10).HasColumnName("CP_VE10");
                        
                            entity.Property(e => e.CuaKhau).HasColumnName("CuaKhau").HasMaxLength(100);
                        
                            entity.Property(e => e.CucHaiQuan).HasColumnName("CucHaiQuan").HasMaxLength(100);
                        
                            entity.Property(e => e.CuocTraSau).HasColumnName("CuocTraSau");
                        
                            entity.Property(e => e.CuocTraTruoc).HasColumnName("CuocTraTruoc");
                        
                            entity.Property(e => e.CuocVC).HasColumnName("CuocVC");
                        
                            entity.Property(e => e.DaBocLenTau).HasColumnName("DaBocLenTau").HasMaxLength(100);
                        
                            entity.Property(e => e.DeNghi).HasColumnName("DeNghi").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiDL).HasColumnName("DiaChiDL").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiDLNN).HasColumnName("DiaChiDLNN").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiGiao).HasColumnName("DiaChiGiao").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaChiKG).HasColumnName("DiaChiKG").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaChiKN).HasColumnName("DiaChiKN").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaChiNDD).HasColumnName("DiaChiNDD").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNDDNN).HasColumnName("DiaChiNDDNN").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNhan).HasColumnName("DiaChiNhan").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaChiNK).HasColumnName("DiaChiNK").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaChiTB).HasColumnName("DiaChiTB").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaChiTB2).HasColumnName("DiaChiTB2").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaChiXK).HasColumnName("DiaChiXK").HasMaxLength(-1);
                        
                            entity.Property(e => e.DiaDiemDo).HasColumnName("DiaDiemDo").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaDiemXep).HasColumnName("DiaDiemXep").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(-1);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(-1);
                        
                            entity.Property(e => e.DienGiaiVCL).HasColumnName("DienGiaiVCL").HasMaxLength(-1);
                        
                            entity.Property(e => e.DienThoaiLHG).HasColumnName("DienThoaiLHG").HasMaxLength(150);
                        
                            entity.Property(e => e.DienThoaiLHN).HasColumnName("DienThoaiLHN").HasMaxLength(150);
                        
                            entity.Property(e => e.DienThoaiLHNK).HasColumnName("DienThoaiLHNK").HasMaxLength(150);
                        
                            entity.Property(e => e.DienThoaiLHTB).HasColumnName("DienThoaiLHTB").HasMaxLength(150);
                        
                            entity.Property(e => e.DienThoaiLHTB2).HasColumnName("DienThoaiLHTB2").HasMaxLength(150);
                        
                            entity.Property(e => e.DienThoaiLHXK).HasColumnName("DienThoaiLHXK").HasMaxLength(150);
                        
                            entity.Property(e => e.DienThoaiNK).HasColumnName("DienThoaiNK").HasMaxLength(100);
                        
                            entity.Property(e => e.DienThoaiTX).HasColumnName("DienThoaiTX").HasMaxLength(100);
                        
                            entity.Property(e => e.DienThoaiXK).HasColumnName("DienThoaiXK").HasMaxLength(100);
                        
                            entity.Property(e => e.DieuKienGH).HasColumnName("DieuKienGH").HasMaxLength(-1);
                        
                            entity.Property(e => e.DieuKienNH).HasColumnName("DieuKienNH").HasMaxLength(-1);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.DonGiaBan).HasColumnName("DonGiaBan");
                        
                            entity.Property(e => e.DonGiaBanNT).HasColumnName("DonGiaBanNT");
                        
                            entity.Property(e => e.DonGiaMua).HasColumnName("DonGiaMua");
                        
                            entity.Property(e => e.DonGiaMuaNT).HasColumnName("DonGiaMuaNT");
                        
                            entity.Property(e => e.DonGiaVC).HasColumnName("DonGiaVC");
                        
                            entity.Property(e => e.DonHangNgay).HasColumnName("DonHangNgay");
                        
                            entity.Property(e => e.DonHangSo).HasColumnName("DonHangSo").HasMaxLength(50);
                        
                            entity.Property(e => e.DTKHGui).HasColumnName("DTKHGui").HasMaxLength(100);
                        
                            entity.Property(e => e.DTKHNhan).HasColumnName("DTKHNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.DTKHTB).HasColumnName("DTKHTB").HasMaxLength(100);
                        
                            entity.Property(e => e.DTKHTB2).HasColumnName("DTKHTB2").HasMaxLength(100);
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(100);
                        
                            entity.Property(e => e.DVTBan).HasColumnName("DVTBan").HasMaxLength(100);
                        
                            entity.Property(e => e.DVTBook).HasColumnName("DVTBook").HasMaxLength(100);
                        
                            entity.Property(e => e.DVTMua).HasColumnName("DVTMua").HasMaxLength(100);
                        
                            entity.Property(e => e.EmailLHG).HasColumnName("EmailLHG").HasMaxLength(150);
                        
                            entity.Property(e => e.EmailLHN).HasColumnName("EmailLHN").HasMaxLength(150);
                        
                            entity.Property(e => e.EmailLHNK).HasColumnName("EmailLHNK").HasMaxLength(150);
                        
                            entity.Property(e => e.EmailLHTB).HasColumnName("EmailLHTB").HasMaxLength(150);
                        
                            entity.Property(e => e.EmailLHTB2).HasColumnName("EmailLHTB2").HasMaxLength(150);
                        
                            entity.Property(e => e.EmailLHXK).HasColumnName("EmailLHXK").HasMaxLength(150);
                        
                            entity.Property(e => e.EmailNK).HasColumnName("EmailNK").HasMaxLength(150);
                        
                            entity.Property(e => e.EmailXK).HasColumnName("EmailXK").HasMaxLength(150);
                        
                            entity.Property(e => e.FaxGui).HasColumnName("FaxGui").HasMaxLength(100);
                        
                            entity.Property(e => e.FaxNhan).HasColumnName("FaxNhan").HasMaxLength(50);
                        
                            entity.Property(e => e.FaxNK).HasColumnName("FaxNK").HasMaxLength(100);
                        
                            entity.Property(e => e.FaxTB).HasColumnName("FaxTB").HasMaxLength(50);
                        
                            entity.Property(e => e.FaxTB2).HasColumnName("FaxTB2").HasMaxLength(50);
                        
                            entity.Property(e => e.FaxXK).HasColumnName("FaxXK").HasMaxLength(100);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuBan).HasColumnName("GhiChuBan").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuMua).HasColumnName("GhiChuMua").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuNG).HasColumnName("GhiChuNG").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuSeal).HasColumnName("GhiChuSeal").HasMaxLength(-1);
                        
                            entity.Property(e => e.GiaTriHopDong).HasColumnName("GiaTriHopDong");
                        
                            entity.Property(e => e.GioCatMang).HasColumnName("GioCatMang");
                        
                            entity.Property(e => e.HangRoi).HasColumnName("HangRoi");
                        
                            entity.Property(e => e.HangTau).HasColumnName("HangTau").HasMaxLength(250);
                        
                            entity.Property(e => e.HanLuuCont).HasColumnName("HanLuuCont");
                        
                            entity.Property(e => e.IDVD).HasColumnName("IDVD");
                        
                            entity.Property(e => e.ImportCode).HasColumnName("ImportCode").HasMaxLength(100);
                        
                            entity.Property(e => e.KhoHang).HasColumnName("KhoHang").HasMaxLength(100);
                        
                            entity.Property(e => e.KhuVuc).HasColumnName("KhuVuc").HasMaxLength(150);
                        
                            entity.Property(e => e.LaiLo).HasColumnName("LaiLo");
                        
                            entity.Property(e => e.LaiLoNT).HasColumnName("LaiLoNT");
                        
                            entity.Property(e => e.LienHeGui).HasColumnName("LienHeGui").HasMaxLength(150);
                        
                            entity.Property(e => e.LienHeNhan).HasColumnName("LienHeNhan").HasMaxLength(150);
                        
                            entity.Property(e => e.LienHeNK).HasColumnName("LienHeNK").HasMaxLength(150);
                        
                            entity.Property(e => e.LienHeTB).HasColumnName("LienHeTB").HasMaxLength(150);
                        
                            entity.Property(e => e.LienHeTB2).HasColumnName("LienHeTB2").HasMaxLength(150);
                        
                            entity.Property(e => e.LienHeXK).HasColumnName("LienHeXK").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiBL).HasColumnName("LoaiBL").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiDV).HasColumnName("LoaiDV").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiGiaBan).HasColumnName("LoaiGiaBan").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiGiaMua).HasColumnName("LoaiGiaMua").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiHang).HasColumnName("LoaiHang").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiKien).HasColumnName("LoaiKien").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiNX).HasColumnName("LoaiNX").HasMaxLength(20);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.LoaiPT).HasColumnName("LoaiPT").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiThueBan).HasColumnName("LoaiThueBan").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiThueMua).HasColumnName("LoaiThueMua").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(20);
                        
                            entity.Property(e => e.MaBGBan).HasColumnName("MaBGBan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaBGMua).HasColumnName("MaBGMua").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChuPT).HasColumnName("MaChuPT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaCP).HasColumnName("MaCP").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDaiLy).HasColumnName("MaDaiLy").HasMaxLength(50);
                        
                            entity.Property(e => e.MaDaiLyNN).HasColumnName("MaDaiLyNN").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKHGui).HasColumnName("MaKHGui").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKHNhan).HasColumnName("MaKHNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKHNK).HasColumnName("MaKHNK").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKHTB).HasColumnName("MaKHTB").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKHTB2).HasColumnName("MaKHTB2").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKHXK).HasColumnName("MaKHXK").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNCC).HasColumnName("MaNCC").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNgoaiTe).HasColumnName("MaNgoaiTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaNguoiDD).HasColumnName("MaNguoiDD").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNguoiDDNN).HasColumnName("MaNguoiDDNN").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNoiGiao).HasColumnName("MaNoiGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNoiNhan).HasColumnName("MaNoiNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(150);
                        
                            entity.Property(e => e.MaNVienKD).HasColumnName("MaNVienKD").HasMaxLength(150);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTienTeBan).HasColumnName("MaTienTeBan").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTienTeMua).HasColumnName("MaTienTeMua").HasMaxLength(50);
                        
                            entity.Property(e => e.MoTaHH).HasColumnName("MoTaHH").HasMaxLength(-1);
                        
                            entity.Property(e => e.MSTGui).HasColumnName("MSTGui").HasMaxLength(100);
                        
                            entity.Property(e => e.MSTNhan).HasColumnName("MSTNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MSTNK).HasColumnName("MSTNK").HasMaxLength(100);
                        
                            entity.Property(e => e.MSTTB).HasColumnName("MSTTB").HasMaxLength(100);
                        
                            entity.Property(e => e.MSTTB2).HasColumnName("MSTTB2").HasMaxLength(100);
                        
                            entity.Property(e => e.MSTXK).HasColumnName("MSTXK").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayBL).HasColumnName("NgayBL");
                        
                            entity.Property(e => e.NgayBooking).HasColumnName("NgayBooking");
                        
                            entity.Property(e => e.NgayCatMang).HasColumnName("NgayCatMang");
                        
                            entity.Property(e => e.NgayCTLH).HasColumnName("NgayCTLH");
                        
                            entity.Property(e => e.NgayDen).HasColumnName("NgayDen");
                        
                            entity.Property(e => e.NgayDoHang).HasColumnName("NgayDoHang");
                        
                            entity.Property(e => e.NgayDongLay).HasColumnName("NgayDongLay");
                        
                            entity.Property(e => e.NgayGiaoHa).HasColumnName("NgayGiaoHa");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayHetHD).HasColumnName("NgayHetHD");
                        
                            entity.Property(e => e.NgayHoaDon).HasColumnName("NgayHoaDon");
                        
                            entity.Property(e => e.NgayHopDong).HasColumnName("NgayHopDong");
                        
                            entity.Property(e => e.NgayKH).HasColumnName("NgayKH");
                        
                            entity.Property(e => e.NgayLot).HasColumnName("NgayLot");
                        
                            entity.Property(e => e.NgayMasterBL).HasColumnName("NgayMasterBL");
                        
                            entity.Property(e => e.NgayPhatHanh).HasColumnName("NgayPhatHanh");
                        
                            entity.Property(e => e.NgayTLyHD).HasColumnName("NgayTLyHD");
                        
                            entity.Property(e => e.NgayToKhai).HasColumnName("NgayToKhai");
                        
                            entity.Property(e => e.NgayXepHang).HasColumnName("NgayXepHang");
                        
                            entity.Property(e => e.NgoaiTeBan).HasColumnName("NgoaiTeBan");
                        
                            entity.Property(e => e.NgoaiTeMua).HasColumnName("NgoaiTeMua");
                        
                            entity.Property(e => e.NhapBangChu).HasColumnName("NhapBangChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.NoiPhatHanh).HasColumnName("NoiPhatHanh").HasMaxLength(250);
                        
                            entity.Property(e => e.NopCho).HasColumnName("NopCho").HasMaxLength(250);
                        
                            entity.Property(e => e.NuocNX).HasColumnName("NuocNX").HasMaxLength(100);
                        
                            entity.Property(e => e.PhiBaoHiem).HasColumnName("PhiBaoHiem");
                        
                            entity.Property(e => e.PhuPhi).HasColumnName("PhuPhi");
                        
                            entity.Property(e => e.PTTT).HasColumnName("PTTT").HasMaxLength(50);
                        
                            entity.Property(e => e.PTTTBB).HasColumnName("PTTTBB").HasMaxLength(100);
                        
                            entity.Property(e => e.QuocTichPTVT).HasColumnName("QuocTichPTVT").HasMaxLength(150);
                        
                            entity.Property(e => e.RecDHL).HasColumnName("RecDHL").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLBG).HasColumnName("RecLBG").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLDX).HasColumnName("RecLDX").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLOT).HasColumnName("RecLOT").HasMaxLength(100);
                        
                            entity.Property(e => e.RecMasterBL).HasColumnName("RecMasterBL").HasMaxLength(100);
                        
                            entity.Property(e => e.RECXL).HasColumnName("RECXL").HasMaxLength(50);
                        
                            entity.Property(e => e.SHKienCont).HasColumnName("SHKienCont").HasMaxLength(100);
                        
                            entity.Property(e => e.SLBLGoc).HasColumnName("SLBLGoc");
                        
                            entity.Property(e => e.SLCanCangBan).HasColumnName("SLCanCangBan");
                        
                            entity.Property(e => e.SLCanCangMua).HasColumnName("SLCanCangMua");
                        
                            entity.Property(e => e.SLCont).HasColumnName("SLCont");
                        
                            entity.Property(e => e.SLSeal).HasColumnName("SLSeal");
                        
                            entity.Property(e => e.SoBL).HasColumnName("SoBL").HasMaxLength(50);
                        
                            entity.Property(e => e.SoBLGoc).HasColumnName("SoBLGoc").HasMaxLength(100);
                        
                            entity.Property(e => e.SoBooking).HasColumnName("SoBooking").HasMaxLength(100);
                        
                            entity.Property(e => e.SoCTLH).HasColumnName("SoCTLH").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHieuChuyen).HasColumnName("SoHieuChuyen").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHoaDon).HasColumnName("SoHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHopDong).HasColumnName("SoHopDong").HasMaxLength(50);
                        
                            entity.Property(e => e.SoKhoi).HasColumnName("SoKhoi");
                        
                            entity.Property(e => e.SoKien).HasColumnName("SoKien");
                        
                            entity.Property(e => e.SoKienBan).HasColumnName("SoKienBan");
                        
                            entity.Property(e => e.SoKienBook).HasColumnName("SoKienBook");
                        
                            entity.Property(e => e.SoKienMua).HasColumnName("SoKienMua");
                        
                            entity.Property(e => e.SoLDX).HasColumnName("SoLDX").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoLuongBan).HasColumnName("SoLuongBan");
                        
                            entity.Property(e => e.SoLuongBook).HasColumnName("SoLuongBook");
                        
                            entity.Property(e => e.SoLuongMua).HasColumnName("SoLuongMua");
                        
                            entity.Property(e => e.SoMasterBL).HasColumnName("SoMasterBL").HasMaxLength(50);
                        
                            entity.Property(e => e.SoThem1).HasColumnName("SoThem1");
                        
                            entity.Property(e => e.SoThem2).HasColumnName("SoThem2");
                        
                            entity.Property(e => e.SoToKhai).HasColumnName("SoToKhai").HasMaxLength(100);
                        
                            entity.Property(e => e.SoXe).HasColumnName("SoXe").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TaiXe).HasColumnName("TaiXe").HasMaxLength(100);
                        
                            entity.Property(e => e.TenChuPT).HasColumnName("TenChuPT").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenCP).HasColumnName("TenCP").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDaiLy).HasColumnName("TenDaiLy").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDaiLyNN).HasColumnName("TenDaiLyNN").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenKH).HasColumnName("TenKH").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenKHGui).HasColumnName("TenKHGui").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenKHNhan).HasColumnName("TenKHNhan").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenKHNK).HasColumnName("TenKHNK").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenKHTB).HasColumnName("TenKHTB").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenKHTB2).HasColumnName("TenKHTB2").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenKHXK).HasColumnName("TenKHXK").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenLoaiNX).HasColumnName("TenLoaiNX").HasMaxLength(150);
                        
                            entity.Property(e => e.TenNCC).HasColumnName("TenNCC").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenNguoiDD).HasColumnName("TenNguoiDD").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenNguoiDDNN).HasColumnName("TenNguoiDDNN").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenNoiGiao).HasColumnName("TenNoiGiao").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenNoiNhan).HasColumnName("TenNoiNhan").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenSHPT).HasColumnName("TenSHPT").HasMaxLength(150);
                        
                            entity.Property(e => e.ThanhTienBan).HasColumnName("ThanhTienBan");
                        
                            entity.Property(e => e.ThanhTienMua).HasColumnName("ThanhTienMua");
                        
                            entity.Property(e => e.ThanhTienVC).HasColumnName("ThanhTienVC");
                        
                            entity.Property(e => e.TheoDonGia).HasColumnName("TheoDonGia");
                        
                            entity.Property(e => e.TheoSoLuong).HasColumnName("TheoSoLuong");
                        
                            entity.Property(e => e.ThoiGianCT).HasColumnName("ThoiGianCT");
                        
                            entity.Property(e => e.ThongTinThem).HasColumnName("ThongTinThem").HasMaxLength(-1);
                        
                            entity.Property(e => e.ThongTinVT).HasColumnName("ThongTinVT").HasMaxLength(-1);
                        
                            entity.Property(e => e.ThueGTGT).HasColumnName("ThueGTGT");
                        
                            entity.Property(e => e.ThueNK).HasColumnName("ThueNK");
                        
                            entity.Property(e => e.ThueSuatBan).HasColumnName("ThueSuatBan");
                        
                            entity.Property(e => e.ThueSuatMua).HasColumnName("ThueSuatMua");
                        
                            entity.Property(e => e.ThueTTDB).HasColumnName("ThueTTDB");
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.ThuKhac).HasColumnName("ThuKhac");
                        
                            entity.Property(e => e.ThuTucYCVDG).HasColumnName("ThuTucYCVDG").HasMaxLength(100);
                        
                            entity.Property(e => e.TienBangChu).HasColumnName("TienBangChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.TienGTGT).HasColumnName("TienGTGT");
                        
                            entity.Property(e => e.TienHoaHong).HasColumnName("TienHoaHong");
                        
                            entity.Property(e => e.TienHoaHongNT).HasColumnName("TienHoaHongNT");
                        
                            entity.Property(e => e.TienThueBan).HasColumnName("TienThueBan");
                        
                            entity.Property(e => e.TienThueBanNT).HasColumnName("TienThueBanNT");
                        
                            entity.Property(e => e.TienThueMua).HasColumnName("TienThueMua");
                        
                            entity.Property(e => e.TienThueMuaNT).HasColumnName("TienThueMuaNT");
                        
                            entity.Property(e => e.TienThueNX).HasColumnName("TienThueNX");
                        
                            entity.Property(e => e.TienThueTTDB).HasColumnName("TienThueTTDB");
                        
                            entity.Property(e => e.TienThuKhac).HasColumnName("TienThuKhac");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TienVNDCK).HasColumnName("TienVNDCK");
                        
                            entity.Property(e => e.TongDoanhThu).HasColumnName("TongDoanhThu");
                        
                            entity.Property(e => e.TongKhoiLuong).HasColumnName("TongKhoiLuong");
                        
                            entity.Property(e => e.TongSoTien).HasColumnName("TongSoTien");
                        
                            entity.Property(e => e.TongThanhToan).HasColumnName("TongThanhToan");
                        
                            entity.Property(e => e.TongTien).HasColumnName("TongTien");
                        
                            entity.Property(e => e.TongTienBan).HasColumnName("TongTienBan");
                        
                            entity.Property(e => e.TongTienBanNT).HasColumnName("TongTienBanNT");
                        
                            entity.Property(e => e.TongTienMua).HasColumnName("TongTienMua");
                        
                            entity.Property(e => e.TongTienMuaNT).HasColumnName("TongTienMuaNT");
                        
                            entity.Property(e => e.TongTienThue).HasColumnName("TongTienThue");
                        
                            entity.Property(e => e.TrangThai).HasColumnName("TrangThai").HasMaxLength(250);
                        
                            entity.Property(e => e.TraTruocTai).HasColumnName("TraTruocTai").HasMaxLength(250);
                        
                            entity.Property(e => e.TrongLuong).HasColumnName("TrongLuong");
                        
                            entity.Property(e => e.TuPhanBo).HasColumnName("TuPhanBo");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyGiaBan).HasColumnName("TyGiaBan");
                        
                            entity.Property(e => e.TyGiaMua).HasColumnName("TyGiaMua");
                        
                            entity.Property(e => e.TyGiaNT).HasColumnName("TyGiaNT");
                        
                            entity.Property(e => e.TyLeCK).HasColumnName("TyLeCK");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.ViTri).HasColumnName("ViTri").HasMaxLength(150);
                        
                    });
                    
                    modelBuilder.Entity<DM_VANDON_PMB>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("DM_VANDON_PMB");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(-1);
                        
                            entity.Property(e => e.DonGiaBan).HasColumnName("DonGiaBan");
                        
                            entity.Property(e => e.DonGiaBanNT).HasColumnName("DonGiaBanNT");
                        
                            entity.Property(e => e.DonGiaMua).HasColumnName("DonGiaMua");
                        
                            entity.Property(e => e.DonGiaMuaNT).HasColumnName("DonGiaMuaNT");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(100);
                        
                            entity.Property(e => e.DVTBan).HasColumnName("DVTBan").HasMaxLength(100);
                        
                            entity.Property(e => e.DVTMua).HasColumnName("DVTMua").HasMaxLength(100);
                        
                            entity.Property(e => e.GhiChuBan).HasColumnName("GhiChuBan").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuMua).HasColumnName("GhiChuMua").HasMaxLength(-1);
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.ImportCode).HasColumnName("ImportCode").HasMaxLength(100);
                        
                            entity.Property(e => e.LaiLo).HasColumnName("LaiLo");
                        
                            entity.Property(e => e.LaiLoNT).HasColumnName("LaiLoNT");
                        
                            entity.Property(e => e.LoaiCT).HasColumnName("LoaiCT").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiGiaBan).HasColumnName("LoaiGiaBan").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiGiaMua).HasColumnName("LoaiGiaMua").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiThueBan).HasColumnName("LoaiThueBan").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiThueMua).HasColumnName("LoaiThueMua").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.MaBGBan).HasColumnName("MaBGBan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaBGMua).HasColumnName("MaBGMua").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCP).HasColumnName("MaCP").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNCC).HasColumnName("MaNCC").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTeBan).HasColumnName("MaTienTeBan").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTienTeMua).HasColumnName("MaTienTeMua").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(100);
                        
                            entity.Property(e => e.NgoaiTeBan).HasColumnName("NgoaiTeBan");
                        
                            entity.Property(e => e.NgoaiTeMua).HasColumnName("NgoaiTeMua");
                        
                            entity.Property(e => e.PTTT).HasColumnName("PTTT").HasMaxLength(100);
                        
                            entity.Property(e => e.PTTTBB).HasColumnName("PTTTBB").HasMaxLength(100);
                        
                            entity.Property(e => e.RecDHL).HasColumnName("RecDHL").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLDX).HasColumnName("RecLDX").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLOT).HasColumnName("RecLOT").HasMaxLength(100);
                        
                            entity.Property(e => e.SLCanCangBan).HasColumnName("SLCanCangBan");
                        
                            entity.Property(e => e.SLCanCangMua).HasColumnName("SLCanCangMua");
                        
                            entity.Property(e => e.SoKienBan).HasColumnName("SoKienBan");
                        
                            entity.Property(e => e.SoKienMua).HasColumnName("SoKienMua");
                        
                            entity.Property(e => e.SoLuongBan).HasColumnName("SoLuongBan");
                        
                            entity.Property(e => e.SoLuongMua).HasColumnName("SoLuongMua");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenCP).HasColumnName("TenCP").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenKH).HasColumnName("TenKH").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenNCC).HasColumnName("TenNCC").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(-1);
                        
                            entity.Property(e => e.ThanhTienBan).HasColumnName("ThanhTienBan");
                        
                            entity.Property(e => e.ThanhTienMua).HasColumnName("ThanhTienMua");
                        
                            entity.Property(e => e.ThueSuatBan).HasColumnName("ThueSuatBan");
                        
                            entity.Property(e => e.ThueSuatMua).HasColumnName("ThueSuatMua");
                        
                            entity.Property(e => e.TienHoaHong).HasColumnName("TienHoaHong");
                        
                            entity.Property(e => e.TienHoaHongNT).HasColumnName("TienHoaHongNT");
                        
                            entity.Property(e => e.TienThueBan).HasColumnName("TienThueBan");
                        
                            entity.Property(e => e.TienThueBanNT).HasColumnName("TienThueBanNT");
                        
                            entity.Property(e => e.TienThueMua).HasColumnName("TienThueMua");
                        
                            entity.Property(e => e.TienThueMuaNT).HasColumnName("TienThueMuaNT");
                        
                            entity.Property(e => e.TongTienBan).HasColumnName("TongTienBan");
                        
                            entity.Property(e => e.TongTienBanNT).HasColumnName("TongTienBanNT");
                        
                            entity.Property(e => e.TongTienMua).HasColumnName("TongTienMua");
                        
                            entity.Property(e => e.TongTienMuaNT).HasColumnName("TongTienMuaNT");
                        
                            entity.Property(e => e.TyGiaBan).HasColumnName("TyGiaBan");
                        
                            entity.Property(e => e.TyGiaMua).HasColumnName("TyGiaMua");
                        
                            entity.Property(e => e.VANDONCTB1).HasColumnName("VANDONCTB1");
                        
                            entity.Property(e => e.VANDONCTB2).HasColumnName("VANDONCTB2");
                        
                            entity.Property(e => e.VANDONCTB3).HasColumnName("VANDONCTB3");
                        
                            entity.Property(e => e.VANDONCTD1).HasColumnName("VANDONCTD1");
                        
                            entity.Property(e => e.VANDONCTD2).HasColumnName("VANDONCTD2");
                        
                            entity.Property(e => e.VANDONCTD3).HasColumnName("VANDONCTD3");
                        
                            entity.Property(e => e.VANDONCTD4).HasColumnName("VANDONCTD4");
                        
                            entity.Property(e => e.VANDONCTD5).HasColumnName("VANDONCTD5");
                        
                            entity.Property(e => e.VANDONCTI1).HasColumnName("VANDONCTI1");
                        
                            entity.Property(e => e.VANDONCTI2).HasColumnName("VANDONCTI2");
                        
                            entity.Property(e => e.VANDONCTI3).HasColumnName("VANDONCTI3");
                        
                            entity.Property(e => e.VANDONCTN1).HasColumnName("VANDONCTN1");
                        
                            entity.Property(e => e.VANDONCTN10).HasColumnName("VANDONCTN10");
                        
                            entity.Property(e => e.VANDONCTN2).HasColumnName("VANDONCTN2");
                        
                            entity.Property(e => e.VANDONCTN3).HasColumnName("VANDONCTN3");
                        
                            entity.Property(e => e.VANDONCTN4).HasColumnName("VANDONCTN4");
                        
                            entity.Property(e => e.VANDONCTN5).HasColumnName("VANDONCTN5");
                        
                            entity.Property(e => e.VANDONCTN6).HasColumnName("VANDONCTN6");
                        
                            entity.Property(e => e.VANDONCTN7).HasColumnName("VANDONCTN7");
                        
                            entity.Property(e => e.VANDONCTN8).HasColumnName("VANDONCTN8");
                        
                            entity.Property(e => e.VANDONCTN9).HasColumnName("VANDONCTN9");
                        
                            entity.Property(e => e.VANDONCTS1).HasColumnName("VANDONCTS1").HasMaxLength(100);
                        
                            entity.Property(e => e.VANDONCTS2).HasColumnName("VANDONCTS2").HasMaxLength(100);
                        
                            entity.Property(e => e.VANDONCTS3).HasColumnName("VANDONCTS3").HasMaxLength(150);
                        
                            entity.Property(e => e.VANDONCTS4).HasColumnName("VANDONCTS4").HasMaxLength(150);
                        
                            entity.Property(e => e.VANDONCTS5).HasColumnName("VANDONCTS5").HasMaxLength(250);
                        
                            entity.Property(e => e.VANDONCTS6).HasColumnName("VANDONCTS6").HasMaxLength(250);
                        
                            entity.Property(e => e.VANDONCTS7).HasColumnName("VANDONCTS7").HasMaxLength(-1);
                        
                            entity.Property(e => e.VANDONCTS8).HasColumnName("VANDONCTS8").HasMaxLength(-1);
                        
                    });
                    
                    modelBuilder.Entity<DM_VATTU>(entity =>
                    {
                        entity.HasKey(e => e.MaVT);
                        entity.ToTable("DM_VATTU");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.Barcode).HasColumnName("Barcode").HasMaxLength(255);
                        
                            entity.Property(e => e.CoMaPhu).HasColumnName("CoMaPhu");
                        
                            entity.Property(e => e.CoTonKho).HasColumnName("CoTonKho");
                        
                            entity.Property(e => e.Date1).HasColumnName("Date1");
                        
                            entity.Property(e => e.Date2).HasColumnName("Date2");
                        
                            entity.Property(e => e.DoCao).HasColumnName("DoCao");
                        
                            entity.Property(e => e.DoDai).HasColumnName("DoDai");
                        
                            entity.Property(e => e.DoRong).HasColumnName("DoRong");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.DVT2).HasColumnName("DVT2").HasMaxLength(50);
                        
                            entity.Property(e => e.DVTP1).HasColumnName("DVTP1").HasMaxLength(100);
                        
                            entity.Property(e => e.DVTP2).HasColumnName("DVTP2").HasMaxLength(100);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(255);
                        
                            entity.Property(e => e.GiaBan).HasColumnName("GiaBan");
                        
                            entity.Property(e => e.GiaBan2).HasColumnName("GiaBan2");
                        
                            entity.Property(e => e.GiaNhapKho).HasColumnName("GiaNhapKho");
                        
                            entity.Property(e => e.HinhAnh).HasColumnName("HinhAnh").HasMaxLength(-1);
                        
                            entity.Property(e => e.KhoNgamDinh).HasColumnName("KhoNgamDinh").HasMaxLength(100);
                        
                            entity.Property(e => e.LaCCDC).HasColumnName("LaCCDC");
                        
                            entity.Property(e => e.LaNhom).HasColumnName("LaNhom");
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKV).HasColumnName("MaKV").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNCC).HasColumnName("MaNCC").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTK).HasColumnName("MaTK").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKCP).HasColumnName("MaTKCP").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKDT).HasColumnName("MaTKDT").HasMaxLength(50);
                        
                            entity.Property(e => e.Mau).HasColumnName("Mau").HasMaxLength(255);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(100);
                        
                            entity.Property(e => e.Model).HasColumnName("Model").HasMaxLength(255);
                        
                            entity.Property(e => e.MoTa).HasColumnName("MoTa").HasMaxLength(-1);
                        
                            entity.Property(e => e.MucCao).HasColumnName("MucCao");
                        
                            entity.Property(e => e.MucThap).HasColumnName("MucThap");
                        
                            entity.Property(e => e.NamSanXuat).HasColumnName("NamSanXuat").HasMaxLength(255);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayHetHan).HasColumnName("NgayHetHan");
                        
                            entity.Property(e => e.NhanHieu).HasColumnName("NhanHieu").HasMaxLength(255);
                        
                            entity.Property(e => e.NhomCap).HasColumnName("NhomCap");
                        
                            entity.Property(e => e.NhomVT).HasColumnName("NhomVT").HasMaxLength(26);
                        
                            entity.Property(e => e.Number1).HasColumnName("Number1");
                        
                            entity.Property(e => e.Number2).HasColumnName("Number2");
                        
                            entity.Property(e => e.Number3).HasColumnName("Number3");
                        
                            entity.Property(e => e.PhanTramHaoHut).HasColumnName("PhanTramHaoHut");
                        
                            entity.Property(e => e.QuiCach).HasColumnName("QuiCach").HasMaxLength(255);
                        
                            entity.Property(e => e.Size).HasColumnName("Size").HasMaxLength(255);
                        
                            entity.Property(e => e.SoSerial).HasColumnName("SoSerial").HasMaxLength(100);
                        
                            entity.Property(e => e.TenFileHinh).HasColumnName("TenFileHinh").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(250);
                        
                            entity.Property(e => e.TenVT2).HasColumnName("TenVT2").HasMaxLength(250);
                        
                            entity.Property(e => e.TenVT3).HasColumnName("TenVT3").HasMaxLength(250);
                        
                            entity.Property(e => e.TenVT4).HasColumnName("TenVT4").HasMaxLength(250);
                        
                            entity.Property(e => e.Text1).HasColumnName("Text1").HasMaxLength(250);
                        
                            entity.Property(e => e.Text2).HasColumnName("Text2").HasMaxLength(250);
                        
                            entity.Property(e => e.Text3).HasColumnName("Text3").HasMaxLength(250);
                        
                            entity.Property(e => e.ThoiHanBH).HasColumnName("ThoiHanBH").HasMaxLength(200);
                        
                            entity.Property(e => e.ThueTTDB).HasColumnName("ThueTTDB");
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TinhChat).HasColumnName("TinhChat").HasMaxLength(250);
                        
                            entity.Property(e => e.TLQD1).HasColumnName("TLQD1");
                        
                            entity.Property(e => e.TLQD2).HasColumnName("TLQD2");
                        
                            entity.Property(e => e.TrongLuong).HasColumnName("TrongLuong");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.XuatXu).HasColumnName("XuatXu").HasMaxLength(255);
                        
                    });
                    
                    modelBuilder.Entity<DM_VATTU_QD>(entity =>
                    {
                        entity.HasKey(e => e.IDQD);
                        entity.ToTable("DM_VATTU_QD");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DVTQD).HasColumnName("DVTQD").HasMaxLength(50);
                        
                            entity.Property(e => e.GiaBan1).HasColumnName("GiaBan1");
                        
                            entity.Property(e => e.GiaBan2).HasColumnName("GiaBan2");
                        
                            entity.Property(e => e.GiaBan3).HasColumnName("GiaBan3");
                        
                            entity.Property(e => e.GiaBan4).HasColumnName("GiaBan4");
                        
                            entity.Property(e => e.GiaBanCD).HasColumnName("GiaBanCD");
                        
                            entity.Property(e => e.IDQD).HasColumnName("IDQD").HasMaxLength(50);
                        
                            entity.Property(e => e.MaBangGia).HasColumnName("MaBangGia").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(100);
                        
                            entity.Property(e => e.PhepTinh).HasColumnName("PhepTinh").HasMaxLength(3);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TLQDDVC).HasColumnName("TLQDDVC");
                        
                    });
                    
                    modelBuilder.Entity<DM_VI_TRI_CV>(entity =>
                    {
                        entity.HasKey(e => e.MaVT);
                        entity.ToTable("DM_VI TRI CV");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CapVT).HasColumnName("CapVT").HasMaxLength(100);
                        
                            entity.Property(e => e.ChucDanh).HasColumnName("ChucDanh").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DonViCTac).HasColumnName("DonViCTac").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.LaNhom).HasColumnName("LaNhom");
                        
                            entity.Property(e => e.LoaiVT).HasColumnName("LoaiVT").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(200);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(100);
                        
                            entity.Property(e => e.MoTaCongViec).HasColumnName("MoTaCongViec").HasMaxLength(-1);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NhomVT).HasColumnName("NhomVT").HasMaxLength(250);
                        
                            entity.Property(e => e.SoNgayPhepDH).HasColumnName("SoNgayPhepDH");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenViTri).HasColumnName("TenViTri").HasMaxLength(250);
                        
                            entity.Property(e => e.TenViTri2).HasColumnName("TenViTri2").HasMaxLength(250);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.VTCVNTruong1).HasColumnName("VTCVNTruong1");
                        
                            entity.Property(e => e.VTCVNTruong2).HasColumnName("VTCVNTruong2");
                        
                            entity.Property(e => e.VTCVNTruong3).HasColumnName("VTCVNTruong3");
                        
                            entity.Property(e => e.VTCVNTruong4).HasColumnName("VTCVNTruong4");
                        
                            entity.Property(e => e.VTCVNTruong5).HasColumnName("VTCVNTruong5");
                        
                            entity.Property(e => e.VTCVSTruong1).HasColumnName("VTCVSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.VTCVSTruong2).HasColumnName("VTCVSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.VTCVSTruong3).HasColumnName("VTCVSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.VTCVSTruong4).HasColumnName("VTCVSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.VTCVSTruong5).HasColumnName("VTCVSTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.YeuCauTuyenDung).HasColumnName("YeuCauTuyenDung").HasMaxLength(-1);
                        
                    });
                    
                    modelBuilder.Entity<ImportExcel>(entity =>
                    {
                        entity.HasKey(e => e.IDIP);
                        entity.ToTable("ImportExcel");
                        
                            entity.Property(e => e.Barcode).HasColumnName("Barcode").HasMaxLength(100);
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(-1);
                        
                            entity.Property(e => e.DienThoai).HasColumnName("DienThoai").HasMaxLength(100);
                        
                            entity.Property(e => e.DonDatHang).HasColumnName("DonDatHang").HasMaxLength(100);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.DonGiaNT).HasColumnName("DonGiaNT");
                        
                            entity.Property(e => e.DTLienHe).HasColumnName("DTLienHe").HasMaxLength(150);
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(100);
                        
                            entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.HanTra).HasColumnName("HanTra");
                        
                            entity.Property(e => e.HopDong).HasColumnName("HopDong").HasMaxLength(50);
                        
                            entity.Property(e => e.IDIP).HasColumnName("IDIP");
                        
                            entity.Property(e => e.IPCheck1).HasColumnName("IPCheck1");
                        
                            entity.Property(e => e.IPCheck2).HasColumnName("IPCheck2");
                        
                            entity.Property(e => e.IPCheck3).HasColumnName("IPCheck3");
                        
                            entity.Property(e => e.IPCheck4).HasColumnName("IPCheck4");
                        
                            entity.Property(e => e.IPCheck5).HasColumnName("IPCheck5");
                        
                            entity.Property(e => e.IPDate1).HasColumnName("IPDate1");
                        
                            entity.Property(e => e.IPDate2).HasColumnName("IPDate2");
                        
                            entity.Property(e => e.IPDate3).HasColumnName("IPDate3");
                        
                            entity.Property(e => e.IPDate4).HasColumnName("IPDate4");
                        
                            entity.Property(e => e.IPDate5).HasColumnName("IPDate5");
                        
                            entity.Property(e => e.IPNumber1).HasColumnName("IPNumber1");
                        
                            entity.Property(e => e.IPNumber10).HasColumnName("IPNumber10");
                        
                            entity.Property(e => e.IPNumber11).HasColumnName("IPNumber11");
                        
                            entity.Property(e => e.IPNumber12).HasColumnName("IPNumber12");
                        
                            entity.Property(e => e.IPNumber13).HasColumnName("IPNumber13");
                        
                            entity.Property(e => e.IPNumber14).HasColumnName("IPNumber14");
                        
                            entity.Property(e => e.IPNumber15).HasColumnName("IPNumber15");
                        
                            entity.Property(e => e.IPNumber16).HasColumnName("IPNumber16");
                        
                            entity.Property(e => e.IPNumber17).HasColumnName("IPNumber17");
                        
                            entity.Property(e => e.IPNumber18).HasColumnName("IPNumber18");
                        
                            entity.Property(e => e.IPNumber19).HasColumnName("IPNumber19");
                        
                            entity.Property(e => e.IPNumber2).HasColumnName("IPNumber2");
                        
                            entity.Property(e => e.IPNumber20).HasColumnName("IPNumber20");
                        
                            entity.Property(e => e.IPNumber3).HasColumnName("IPNumber3");
                        
                            entity.Property(e => e.IPNumber4).HasColumnName("IPNumber4");
                        
                            entity.Property(e => e.IPNumber5).HasColumnName("IPNumber5");
                        
                            entity.Property(e => e.IPNumber6).HasColumnName("IPNumber6");
                        
                            entity.Property(e => e.IPNumber7).HasColumnName("IPNumber7");
                        
                            entity.Property(e => e.IPNumber8).HasColumnName("IPNumber8");
                        
                            entity.Property(e => e.IPNumber9).HasColumnName("IPNumber9");
                        
                            entity.Property(e => e.IPText1).HasColumnName("IPText1").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText10).HasColumnName("IPText10").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText11).HasColumnName("IPText11").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText12).HasColumnName("IPText12").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText13).HasColumnName("IPText13").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText14).HasColumnName("IPText14").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText15).HasColumnName("IPText15").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText16).HasColumnName("IPText16").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText17).HasColumnName("IPText17").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText18).HasColumnName("IPText18").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText19).HasColumnName("IPText19").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText2).HasColumnName("IPText2").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText20).HasColumnName("IPText20").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText21).HasColumnName("IPText21").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText22).HasColumnName("IPText22").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText23).HasColumnName("IPText23").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText24).HasColumnName("IPText24").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText25).HasColumnName("IPText25").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText3).HasColumnName("IPText3").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText4).HasColumnName("IPText4").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText5).HasColumnName("IPText5").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText6).HasColumnName("IPText6").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText7).HasColumnName("IPText7").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText8).HasColumnName("IPText8").HasMaxLength(-1);
                        
                            entity.Property(e => e.IPText9).HasColumnName("IPText9").HasMaxLength(-1);
                        
                            entity.Property(e => e.KyHieuHD).HasColumnName("KyHieuHD").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSo).HasColumnName("MaSo").HasMaxLength(250);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTKCo).HasColumnName("MaTKCo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKNo).HasColumnName("MaTKNo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(100);
                        
                            entity.Property(e => e.MST).HasColumnName("MST").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayBOB).HasColumnName("NgayBOB");
                        
                            entity.Property(e => e.NgayDonHang).HasColumnName("NgayDonHang");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.NgayNX).HasColumnName("NgayNX");
                        
                            entity.Property(e => e.NgayToKhai).HasColumnName("NgayToKhai");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NgoaiTeCK).HasColumnName("NgoaiTeCK");
                        
                            entity.Property(e => e.NguoiLienHe).HasColumnName("NguoiLienHe").HasMaxLength(150);
                        
                            entity.Property(e => e.NguoiTao).HasColumnName("NguoiTao").HasMaxLength(150);
                        
                            entity.Property(e => e.NhomKH).HasColumnName("NhomKH").HasMaxLength(100);
                        
                            entity.Property(e => e.NhomVT).HasColumnName("NhomVT").HasMaxLength(100);
                        
                            entity.Property(e => e.NoiDung1).HasColumnName("NoiDung1").HasMaxLength(-1);
                        
                            entity.Property(e => e.NoiDung2).HasColumnName("NoiDung2").HasMaxLength(-1);
                        
                            entity.Property(e => e.NoiDung3).HasColumnName("NoiDung3").HasMaxLength(-1);
                        
                            entity.Property(e => e.PhiVC).HasColumnName("PhiVC");
                        
                            entity.Property(e => e.PTTT).HasColumnName("PTTT").HasMaxLength(100);
                        
                            entity.Property(e => e.PTVC).HasColumnName("PTVC").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RECXL).HasColumnName("RECXL").HasMaxLength(100);
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHD).HasColumnName("SoHD").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoNgayNo).HasColumnName("SoNgayNo");
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(100);
                        
                            entity.Property(e => e.SoToKhai).HasColumnName("SoToKhai").HasMaxLength(50);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenKH).HasColumnName("TenKH").HasMaxLength(250);
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(250);
                        
                            entity.Property(e => e.ThucThu).HasColumnName("ThucThu");
                        
                            entity.Property(e => e.ThucThu2).HasColumnName("ThucThu2");
                        
                            entity.Property(e => e.ThueSuat).HasColumnName("ThueSuat");
                        
                            entity.Property(e => e.TienCK).HasColumnName("TienCK");
                        
                            entity.Property(e => e.TienKM).HasColumnName("TienKM");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyLeCK).HasColumnName("TyLeCK");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<L01_FIELDS>(entity =>
                    {
                        entity.HasKey(e => e.ID);
                        entity.ToTable("L01_FIELDS");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(-1);
                        
                            entity.Property(e => e.DORONGCOT).HasColumnName("DORONGCOT");
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(-1);
                        
                            entity.Property(e => e.FNAME).HasColumnName("FNAME").HasMaxLength(250);
                        
                            entity.Property(e => e.FormCTu).HasColumnName("FormCTu").HasMaxLength(50);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(-1);
                        
                            entity.Property(e => e.GHICHU).HasColumnName("GHICHU").HasMaxLength(250);
                        
                            entity.Property(e => e.ID).HasColumnName("ID");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(-1);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(-1);
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(-1);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(-1);
                        
                    });
                    
                    modelBuilder.Entity<L02_COMMON>(entity =>
                    {
                        entity.HasKey(e => e.ID);
                        entity.ToTable("L02_COMMON");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.GHICHU).HasColumnName("GHICHU").HasMaxLength(250);
                        
                            entity.Property(e => e.ID).HasColumnName("ID");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<L04_MESSAGES>(entity =>
                    {
                        entity.HasKey(e => e.ID);
                        entity.ToTable("L04_MESSAGES");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.GHICHU).HasColumnName("GHICHU").HasMaxLength(250);
                        
                            entity.Property(e => e.ID).HasColumnName("ID");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<L06_MENU>(entity =>
                    {
                        entity.HasKey(e => e.MAMUC);
                        entity.ToTable("L06_MENU");
                        
                            entity.Property(e => e.BienDong).HasColumnName("BienDong").HasMaxLength(50);
                        
                            entity.Property(e => e.CAPMENU).HasColumnName("CAPMENU").HasMaxLength(10);
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.HinhAnh).HasColumnName("HinhAnh").HasMaxLength(2147483647);
                        
                            entity.Property(e => e.IconSo).HasColumnName("IconSo");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(50);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.KyHieuPH).HasColumnName("KyHieuPH").HasMaxLength(20);
                        
                            entity.Property(e => e.LaPhieu).HasColumnName("LaPhieu");
                        
                            entity.Property(e => e.LoaiXem).HasColumnName("LoaiXem").HasMaxLength(20);
                        
                            entity.Property(e => e.MAMUC).HasColumnName("MAMUC");
                        
                            entity.Property(e => e.MENU).HasColumnName("MENU").HasMaxLength(150);
                        
                            entity.Property(e => e.NhomMenu).HasColumnName("NhomMenu").HasMaxLength(150);
                        
                            entity.Property(e => e.NhomTree).HasColumnName("NhomTree");
                        
                            entity.Property(e => e.OrderBy).HasColumnName("OrderBy");
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.SoftType).HasColumnName("SoftType").HasMaxLength(20);
                        
                            entity.Property(e => e.TempClient).HasColumnName("TempClient").HasMaxLength(30);
                        
                            entity.Property(e => e.TenNhom).HasColumnName("TenNhom").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<L06_REPORT>(entity =>
                    {
                        entity.HasKey(e => e.IDCODE);
                        entity.ToTable("L06_REPORT");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.GHICHU).HasColumnName("GHICHU").HasMaxLength(250);
                        
                            entity.Property(e => e.IDCODE).HasColumnName("IDCODE");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(-1);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiQD).HasColumnName("LoaiQD").HasMaxLength(10);
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.TENPARA).HasColumnName("TENPARA").HasMaxLength(250);
                        
                            entity.Property(e => e.TENREPORT).HasColumnName("TENREPORT").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<P11THU_CHI>(entity =>
                    {
                        entity.HasKey(e => e.RECKEY);
                        entity.ToTable("P11THU CHI");
                        
                            entity.Property(e => e.CTGS).HasColumnName("CTGS").HasMaxLength(50);
                        
                            entity.Property(e => e.CTTrung).HasColumnName("CTTrung");
                        
                            entity.Property(e => e.DaGhiSo).HasColumnName("DaGhiSo");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DonHang).HasColumnName("DonHang").HasMaxLength(50);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuDuyet).HasColumnName("GhiChuDuyet").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChuGS).HasColumnName("GhiChuGS").HasMaxLength(-1);
                        
                            entity.Property(e => e.HanTra).HasColumnName("HanTra");
                        
                            entity.Property(e => e.LaPCMDV).HasColumnName("LaPCMDV");
                        
                            entity.Property(e => e.LoaiCDGui).HasColumnName("LoaiCDGui").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiLOT).HasColumnName("LoaiLOT").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(100);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVienGS).HasColumnName("MaNVienGS").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVu).HasColumnName("MaNVu").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKNH).HasColumnName("MaTKNH").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayCTGS).HasColumnName("NgayCTGS");
                        
                            entity.Property(e => e.NgayDA).HasColumnName("NgayDA");
                        
                            entity.Property(e => e.NgayDonHang).HasColumnName("NgayDonHang");
                        
                            entity.Property(e => e.NgayGioDuyet).HasColumnName("NgayGioDuyet");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(30);
                        
                            entity.Property(e => e.NgayHT).HasColumnName("NgayHT");
                        
                            entity.Property(e => e.NgayLH).HasColumnName("NgayLH");
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.NgayLPCD).HasColumnName("NgayLPCD");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NguoiDuyet).HasColumnName("NguoiDuyet").HasMaxLength(50);
                        
                            entity.Property(e => e.NguoiTC).HasColumnName("NguoiTC").HasMaxLength(250);
                        
                            entity.Property(e => e.P11CKTruong1).HasColumnName("P11CKTruong1");
                        
                            entity.Property(e => e.P11CKTruong2).HasColumnName("P11CKTruong2");
                        
                            entity.Property(e => e.P11DTruong1).HasColumnName("P11DTruong1");
                        
                            entity.Property(e => e.P11DTruong2).HasColumnName("P11DTruong2");
                        
                            entity.Property(e => e.P11DTruong3).HasColumnName("P11DTruong3");
                        
                            entity.Property(e => e.P11DTruong4).HasColumnName("P11DTruong4");
                        
                            entity.Property(e => e.P11NTruong1).HasColumnName("P11NTruong1");
                        
                            entity.Property(e => e.P11NTruong2).HasColumnName("P11NTruong2");
                        
                            entity.Property(e => e.P11NTruong3).HasColumnName("P11NTruong3");
                        
                            entity.Property(e => e.P11NTruong4).HasColumnName("P11NTruong4");
                        
                            entity.Property(e => e.P11STruong1).HasColumnName("P11STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P11STruong2).HasColumnName("P11STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P11STruong3).HasColumnName("P11STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P11STruong4).HasColumnName("P11STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.RecBOL).HasColumnName("RecBOL").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.RECKEYLQ).HasColumnName("RECKEYLQ").HasMaxLength(50);
                        
                            entity.Property(e => e.RecLDX).HasColumnName("RecLDX").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLOT).HasColumnName("RecLOT").HasMaxLength(100);
                        
                            entity.Property(e => e.RecSTK).HasColumnName("RecSTK").HasMaxLength(100);
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.SoCTLH).HasColumnName("SoCTLH").HasMaxLength(50);
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoMTB).HasColumnName("SoMTB").HasMaxLength(100);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(30);
                        
                            entity.Property(e => e.SoPhieuCD).HasColumnName("SoPhieuCD").HasMaxLength(50);
                        
                            entity.Property(e => e.TenKH).HasColumnName("TenKH").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKNH).HasColumnName("TenTKNH").HasMaxLength(250);
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TinhTrang).HasColumnName("TinhTrang").HasMaxLength(100);
                        
                            entity.Property(e => e.TrenSo).HasColumnName("TrenSo").HasMaxLength(100);
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(30);
                        
                            entity.Property(e => e.VaoRecy).HasColumnName("VaoRecy");
                        
                    });
                    
                    modelBuilder.Entity<P12_DK_THU_CHI>(entity =>
                    {
                        entity.HasKey(e => e.IDP12);
                        entity.ToTable("P12 DK THU CHI");
                        
                            entity.Property(e => e.CPhiMua).HasColumnName("CPhiMua");
                        
                            entity.Property(e => e.CTTRUNG).HasColumnName("CTTRUNG");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(255);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(255);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.DonGiaGoc).HasColumnName("DonGiaGoc");
                        
                            entity.Property(e => e.DonGiaNT).HasColumnName("DonGiaNT");
                        
                            entity.Property(e => e.DonGiaNTGoc).HasColumnName("DonGiaNTGoc");
                        
                            entity.Property(e => e.DTTHChiPhi).HasColumnName("DTTHChiPhi").HasMaxLength(150);
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(100);
                        
                            entity.Property(e => e.GiaChuaThue).HasColumnName("GiaChuaThue");
                        
                            entity.Property(e => e.GiaMua).HasColumnName("GiaMua");
                        
                            entity.Property(e => e.GiaThanhToan).HasColumnName("GiaThanhToan");
                        
                            entity.Property(e => e.IDP12).HasColumnName("IDP12");
                        
                            entity.Property(e => e.LoaiCP).HasColumnName("LoaiCP").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCP).HasColumnName("MaCP").HasMaxLength(150);
                        
                            entity.Property(e => e.MaCTLQ).HasColumnName("MaCTLQ").HasMaxLength(3);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKHCo).HasColumnName("MaKHCo").HasMaxLength(30);
                        
                            entity.Property(e => e.MaKHNo).HasColumnName("MaKHNo").HasMaxLength(30);
                        
                            entity.Property(e => e.MaNVu).HasColumnName("MaNVu").HasMaxLength(50);
                        
                            entity.Property(e => e.MaThongKe).HasColumnName("MaThongKe").HasMaxLength(150);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKCo).HasColumnName("MaTKCo").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTKNo).HasColumnName("MaTKNo").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTS).HasColumnName("MaTS").HasMaxLength(50);
                        
                            entity.Property(e => e.MucChi).HasColumnName("MucChi").HasMaxLength(150);
                        
                            entity.Property(e => e.NgayBOB).HasColumnName("NgayBOB");
                        
                            entity.Property(e => e.NgayHoaDon).HasColumnName("NgayHoaDon");
                        
                            entity.Property(e => e.NgayLot).HasColumnName("NgayLot");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.P12CKTruong1).HasColumnName("P12CKTruong1");
                        
                            entity.Property(e => e.P12CKTruong2).HasColumnName("P12CKTruong2");
                        
                            entity.Property(e => e.P12DTruong1).HasColumnName("P12DTruong1");
                        
                            entity.Property(e => e.P12DTruong2).HasColumnName("P12DTruong2");
                        
                            entity.Property(e => e.P12NTruong1).HasColumnName("P12NTruong1");
                        
                            entity.Property(e => e.P12NTruong2).HasColumnName("P12NTruong2");
                        
                            entity.Property(e => e.P12STruong1).HasColumnName("P12STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P12STruong2).HasColumnName("P12STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(50);
                        
                            entity.Property(e => e.SoCTLQ).HasColumnName("SoCTLQ").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHoaDon).HasColumnName("SoHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.SoKheUoc).HasColumnName("SoKheUoc").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoMTB).HasColumnName("SoMTB").HasMaxLength(100);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(30);
                        
                            entity.Property(e => e.TenNganHang).HasColumnName("TenNganHang").HasMaxLength(-1);
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TienVNDGoc).HasColumnName("TienVNDGoc");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                    });
                    
                    modelBuilder.Entity<P13_CHI_TIET_DK>(entity =>
                    {
                        entity.HasKey(e => e.IDP13);
                        entity.ToTable("P13 CHI TIET DK");
                        
                            entity.Property(e => e.Chon).HasColumnName("Chon");
                        
                            entity.Property(e => e.DateLot).HasColumnName("DateLot");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(255);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(255);
                        
                            entity.Property(e => e.IDP11).HasColumnName("IDP11");
                        
                            entity.Property(e => e.IDP13).HasColumnName("IDP13");
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(3);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCP).HasColumnName("MaCP").HasMaxLength(50);
                        
                            entity.Property(e => e.MaDTTHCP).HasColumnName("MaDTTHCP").HasMaxLength(50);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKHCo).HasColumnName("MaKHCo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKHNo).HasColumnName("MaKHNo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTKCo).HasColumnName("MaTKCo").HasMaxLength(10);
                        
                            entity.Property(e => e.MaTKNo).HasColumnName("MaTKNo").HasMaxLength(10);
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NgoaiTeChon).HasColumnName("NgoaiTeChon");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.RecXuLy).HasColumnName("RecXuLy").HasMaxLength(50);
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(50);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.STChenhLech).HasColumnName("STChenhLech");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TienConLaiNT).HasColumnName("TienConLaiNT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TienVNDChon).HasColumnName("TienVNDChon");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyGiaDHT).HasColumnName("TyGiaDHT");
                        
                    });
                    
                    modelBuilder.Entity<P21_NHAP_XUAT>(entity =>
                    {
                        entity.HasKey(e => e.RECKEY);
                        entity.ToTable("P21 NHAP XUAT");
                        
                            entity.Property(e => e.BangDM).HasColumnName("BangDM").HasMaxLength(50);
                        
                            entity.Property(e => e.ChiCucHQ).HasColumnName("ChiCucHQ").HasMaxLength(250);
                        
                            entity.Property(e => e.CTGS).HasColumnName("CTGS").HasMaxLength(50);
                        
                            entity.Property(e => e.CTTRUNG).HasColumnName("CTTRUNG");
                        
                            entity.Property(e => e.CucHaiQuan).HasColumnName("CucHaiQuan").HasMaxLength(250);
                        
                            entity.Property(e => e.DaGhiSo).HasColumnName("DaGhiSo");
                        
                            entity.Property(e => e.DaHT).HasColumnName("DaHT");
                        
                            entity.Property(e => e.DaNhanHD).HasColumnName("DaNhanHD");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DieuKhoanTT).HasColumnName("DieuKhoanTT").HasMaxLength(50);
                        
                            entity.Property(e => e.DonDatHang).HasColumnName("DonDatHang").HasMaxLength(50);
                        
                            entity.Property(e => e.DTTHChiPhi).HasColumnName("DTTHChiPhi").HasMaxLength(150);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuDuyet).HasColumnName("GhiChuDuyet").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChuGS).HasColumnName("GhiChuGS").HasMaxLength(-1);
                        
                            entity.Property(e => e.HanTra).HasColumnName("HanTra");
                        
                            entity.Property(e => e.KhuVuc).HasColumnName("KhuVuc").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiNX).HasColumnName("LoaiNX").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.MaBangGia).HasColumnName("MaBangGia").HasMaxLength(50);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDT).HasColumnName("MaDT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKho2).HasColumnName("MaKho2").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNvien2).HasColumnName("MaNvien2").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVienGS).HasColumnName("MaNVienGS").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVu).HasColumnName("MaNVu").HasMaxLength(50);
                        
                            entity.Property(e => e.MaThongKe).HasColumnName("MaThongKe").HasMaxLength(150);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTKNH).HasColumnName("MaTKNH").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTP).HasColumnName("MaTP").HasMaxLength(50);
                        
                            entity.Property(e => e.MST).HasColumnName("MST").HasMaxLength(20);
                        
                            entity.Property(e => e.MucChi).HasColumnName("MucChi").HasMaxLength(150);
                        
                            entity.Property(e => e.NgayCTGS).HasColumnName("NgayCTGS");
                        
                            entity.Property(e => e.NgayDH).HasColumnName("NgayDH");
                        
                            entity.Property(e => e.NgayGioDuyet).HasColumnName("NgayGioDuyet");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(30);
                        
                            entity.Property(e => e.NgayHDXuat).HasColumnName("NgayHDXuat").HasMaxLength(30);
                        
                            entity.Property(e => e.NgayHT).HasColumnName("NgayHT");
                        
                            entity.Property(e => e.NgayLienHe).HasColumnName("NgayLienHe");
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.NgayLPCD).HasColumnName("NgayLPCD");
                        
                            entity.Property(e => e.NgayToKhai).HasColumnName("NgayToKhai");
                        
                            entity.Property(e => e.NguoiDuyet).HasColumnName("NguoiDuyet").HasMaxLength(50);
                        
                            entity.Property(e => e.NguoiLienHe).HasColumnName("NguoiLienHe").HasMaxLength(250);
                        
                            entity.Property(e => e.NoCu).HasColumnName("NoCu");
                        
                            entity.Property(e => e.P21DTruong1).HasColumnName("P21DTruong1");
                        
                            entity.Property(e => e.P21DTruong2).HasColumnName("P21DTruong2");
                        
                            entity.Property(e => e.P21DTruong3).HasColumnName("P21DTruong3");
                        
                            entity.Property(e => e.P21DTruong4).HasColumnName("P21DTruong4");
                        
                            entity.Property(e => e.P21NTruong1).HasColumnName("P21NTruong1");
                        
                            entity.Property(e => e.P21NTruong2).HasColumnName("P21NTruong2");
                        
                            entity.Property(e => e.P21NTruong3).HasColumnName("P21NTruong3");
                        
                            entity.Property(e => e.P21NTruong4).HasColumnName("P21NTruong4");
                        
                            entity.Property(e => e.P21STruong1).HasColumnName("P21STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P21STruong2).HasColumnName("P21STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P21STruong3).HasColumnName("P21STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P21STruong4).HasColumnName("P21STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.PTTT).HasColumnName("PTTT").HasMaxLength(50);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.RECKEYHD).HasColumnName("RECKEYHD").HasMaxLength(50);
                        
                            entity.Property(e => e.SoCTLH).HasColumnName("SoCTLH").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHDXuat).HasColumnName("SoHDXuat").HasMaxLength(30);
                        
                            entity.Property(e => e.SoHoaDon).HasColumnName("SoHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.SoLuongTP).HasColumnName("SoLuongTP");
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.SoPhieuCD).HasColumnName("SoPhieuCD").HasMaxLength(50);
                        
                            entity.Property(e => e.SoToKhai).HasColumnName("SoToKhai").HasMaxLength(50);
                        
                            entity.Property(e => e.TenKH).HasColumnName("TenKH").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKNH).HasColumnName("TenTKNH").HasMaxLength(250);
                        
                            entity.Property(e => e.ThamChieu).HasColumnName("ThamChieu").HasMaxLength(250);
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TinhTrang).HasColumnName("TinhTrang").HasMaxLength(50);
                        
                            entity.Property(e => e.TinhTrangDH).HasColumnName("TinhTrangDH").HasMaxLength(50);
                        
                            entity.Property(e => e.TrenSo).HasColumnName("TrenSo").HasMaxLength(100);
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyLeCK).HasColumnName("TyLeCK");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(30);
                        
                            entity.Property(e => e.VaoRecy).HasColumnName("VaoRecy");
                        
                            entity.Property(e => e.XeGiao).HasColumnName("XeGiao").HasMaxLength(50);
                        
                            entity.Property(e => e.XuatTheoDM).HasColumnName("XuatTheoDM");
                        
                    });
                    
                    modelBuilder.Entity<P22_CHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.IDP22);
                        entity.ToTable("P22 CHI TIET");
                        
                            entity.Property(e => e.ChiPhiMua).HasColumnName("ChiPhiMua");
                        
                            entity.Property(e => e.DateLot).HasColumnName("DateLot").HasMaxLength(20);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DoCao).HasColumnName("DoCao");
                        
                            entity.Property(e => e.DoDai).HasColumnName("DoDai");
                        
                            entity.Property(e => e.DonDatHang).HasColumnName("DonDatHang").HasMaxLength(100);
                        
                            entity.Property(e => e.DonDatTu).HasColumnName("DonDatTu").HasMaxLength(100);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.DonGiaBan).HasColumnName("DonGiaBan");
                        
                            entity.Property(e => e.DonGiaGoc).HasColumnName("DonGiaGoc");
                        
                            entity.Property(e => e.DonGiaNT).HasColumnName("DonGiaNT");
                        
                            entity.Property(e => e.DonGiaVC).HasColumnName("DonGiaVC");
                        
                            entity.Property(e => e.DoRong).HasColumnName("DoRong");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(30);
                        
                            entity.Property(e => e.GiaNhapNgay).HasColumnName("GiaNhapNgay");
                        
                            entity.Property(e => e.IDP22).HasColumnName("IDP22");
                        
                            entity.Property(e => e.IDPFF).HasColumnName("IDPFF");
                        
                            entity.Property(e => e.IDSerial).HasColumnName("IDSerial").HasMaxLength(150);
                        
                            entity.Property(e => e.KhoiLuong).HasColumnName("KhoiLuong");
                        
                            entity.Property(e => e.LoaiCont).HasColumnName("LoaiCont").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiMau).HasColumnName("LoaiMau").HasMaxLength(30);
                        
                            entity.Property(e => e.LoaiPNK).HasColumnName("LoaiPNK").HasMaxLength(30);
                        
                            entity.Property(e => e.LuanChuyen).HasColumnName("LuanChuyen");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(30);
                        
                            entity.Property(e => e.MaKho2).HasColumnName("MaKho2").HasMaxLength(30);
                        
                            entity.Property(e => e.MaThanhPham).HasColumnName("MaThanhPham").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTKCP).HasColumnName("MaTKCP").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKVT).HasColumnName("MaTKVT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(50);
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NgoaiTeCK).HasColumnName("NgoaiTeCK");
                        
                            entity.Property(e => e.NgoaiTeGoc).HasColumnName("NgoaiTeGoc");
                        
                            entity.Property(e => e.P22CKTruong1).HasColumnName("P22CKTruong1");
                        
                            entity.Property(e => e.P22CKTruong2).HasColumnName("P22CKTruong2");
                        
                            entity.Property(e => e.P22CKTruong3).HasColumnName("P22CKTruong3");
                        
                            entity.Property(e => e.P22CKTruong4).HasColumnName("P22CKTruong4");
                        
                            entity.Property(e => e.P22DTruong1).HasColumnName("P22DTruong1");
                        
                            entity.Property(e => e.P22DTruong2).HasColumnName("P22DTruong2");
                        
                            entity.Property(e => e.P22DTruong3).HasColumnName("P22DTruong3");
                        
                            entity.Property(e => e.P22DTruong4).HasColumnName("P22DTruong4");
                        
                            entity.Property(e => e.P22NTruong1).HasColumnName("P22NTruong1");
                        
                            entity.Property(e => e.P22NTruong10).HasColumnName("P22NTruong10");
                        
                            entity.Property(e => e.P22NTruong2).HasColumnName("P22NTruong2");
                        
                            entity.Property(e => e.P22NTruong3).HasColumnName("P22NTruong3");
                        
                            entity.Property(e => e.P22NTruong4).HasColumnName("P22NTruong4");
                        
                            entity.Property(e => e.P22NTruong5).HasColumnName("P22NTruong5");
                        
                            entity.Property(e => e.P22NTruong6).HasColumnName("P22NTruong6");
                        
                            entity.Property(e => e.P22NTruong7).HasColumnName("P22NTruong7");
                        
                            entity.Property(e => e.P22NTruong8).HasColumnName("P22NTruong8");
                        
                            entity.Property(e => e.P22NTruong9).HasColumnName("P22NTruong9");
                        
                            entity.Property(e => e.P22STruong1).HasColumnName("P22STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P22STruong10).HasColumnName("P22STruong10").HasMaxLength(250);
                        
                            entity.Property(e => e.P22STruong2).HasColumnName("P22STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P22STruong3).HasColumnName("P22STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P22STruong4).HasColumnName("P22STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.P22STruong5).HasColumnName("P22STruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.P22STruong6).HasColumnName("P22STruong6").HasMaxLength(250);
                        
                            entity.Property(e => e.P22STruong7).HasColumnName("P22STruong7").HasMaxLength(250);
                        
                            entity.Property(e => e.P22STruong8).HasColumnName("P22STruong8").HasMaxLength(250);
                        
                            entity.Property(e => e.P22STruong9).HasColumnName("P22STruong9").HasMaxLength(250);
                        
                            entity.Property(e => e.PhiBoiDuong).HasColumnName("PhiBoiDuong");
                        
                            entity.Property(e => e.PhiKhac).HasColumnName("PhiKhac");
                        
                            entity.Property(e => e.PhiLuuBai).HasColumnName("PhiLuuBai");
                        
                            entity.Property(e => e.PhiLuuCont).HasColumnName("PhiLuuCont");
                        
                            entity.Property(e => e.PhiNangHa).HasColumnName("PhiNangHa");
                        
                            entity.Property(e => e.PhiPhuThuNangCont).HasColumnName("PhiPhuThuNangCont");
                        
                            entity.Property(e => e.PhiSuaChua).HasColumnName("PhiSuaChua");
                        
                            entity.Property(e => e.PhiVanChuyen).HasColumnName("PhiVanChuyen");
                        
                            entity.Property(e => e.PhiVeSinh).HasColumnName("PhiVeSinh");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.RecP32).HasColumnName("RecP32").HasMaxLength(10);
                        
                            entity.Property(e => e.SLCont).HasColumnName("SLCont");
                        
                            entity.Property(e => e.SLMat).HasColumnName("SLMat");
                        
                            entity.Property(e => e.SLPhu).HasColumnName("SLPhu");
                        
                            entity.Property(e => e.SLTraLai).HasColumnName("SLTraLai");
                        
                            entity.Property(e => e.SLTruBi).HasColumnName("SLTruBi");
                        
                            entity.Property(e => e.SoBao).HasColumnName("SoBao");
                        
                            entity.Property(e => e.SoChuyen).HasColumnName("SoChuyen");
                        
                            entity.Property(e => e.SoCont).HasColumnName("SoCont").HasMaxLength(150);
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoLuongGiao).HasColumnName("SoLuongGiao");
                        
                            entity.Property(e => e.SoLuongXHD).HasColumnName("SoLuongXHD");
                        
                            entity.Property(e => e.SoPNK).HasColumnName("SoPNK").HasMaxLength(50);
                        
                            entity.Property(e => e.SoXe).HasColumnName("SoXe").HasMaxLength(150);
                        
                            entity.Property(e => e.STT).HasColumnName("STT").HasMaxLength(10);
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(250);
                        
                            entity.Property(e => e.TenYeuCau).HasColumnName("TenYeuCau").HasMaxLength(250);
                        
                            entity.Property(e => e.ThanhTienChiHo).HasColumnName("ThanhTienChiHo");
                        
                            entity.Property(e => e.ThueNK).HasColumnName("ThueNK");
                        
                            entity.Property(e => e.ThueTTDB).HasColumnName("ThueTTDB");
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TienBan).HasColumnName("TienBan");
                        
                            entity.Property(e => e.TienQuyDoi).HasColumnName("TienQuyDoi");
                        
                            entity.Property(e => e.TienThueNK).HasColumnName("TienThueNK");
                        
                            entity.Property(e => e.TienThueTTDB).HasColumnName("TienThueTTDB");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TienVNDCK).HasColumnName("TienVNDCK");
                        
                            entity.Property(e => e.TienVNDGoc).HasColumnName("TienVNDGoc");
                        
                            entity.Property(e => e.TienVNDVC).HasColumnName("TienVNDVC");
                        
                            entity.Property(e => e.TLHaoHut).HasColumnName("TLHaoHut");
                        
                            entity.Property(e => e.TLTruBi).HasColumnName("TLTruBi");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyLeCK).HasColumnName("TyLeCK");
                        
                    });
                    
                    modelBuilder.Entity<P23_CHI_TIET_FIFO>(entity =>
                    {
                        entity.HasKey(e => e.IDP23);
                        entity.ToTable("P23 CHI TIET FIFO");
                        
                            entity.Property(e => e.DateLot).HasColumnName("DateLot").HasMaxLength(20);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.DonGiaBan).HasColumnName("DonGiaBan");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.GiaNhapNgay).HasColumnName("GiaNhapNgay");
                        
                            entity.Property(e => e.IDP22).HasColumnName("IDP22");
                        
                            entity.Property(e => e.IDP23).HasColumnName("IDP23");
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(3);
                        
                            entity.Property(e => e.LuanChuyen).HasColumnName("LuanChuyen");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(30);
                        
                            entity.Property(e => e.MaKho2).HasColumnName("MaKho2").HasMaxLength(30);
                        
                            entity.Property(e => e.MaThanhPham).HasColumnName("MaThanhPham").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaXL).HasColumnName("MaXL").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoLuongChon).HasColumnName("SoLuongChon");
                        
                            entity.Property(e => e.SoLuongTon).HasColumnName("SoLuongTon");
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(250);
                        
                            entity.Property(e => e.TienBan).HasColumnName("TienBan");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TienVNDChon).HasColumnName("TienVNDChon");
                        
                            entity.Property(e => e.TienVNDTon).HasColumnName("TienVNDTon");
                        
                            entity.Property(e => e.TongSeChon).HasColumnName("TongSeChon");
                        
                    });
                    
                    modelBuilder.Entity<P23_DINH_KHOAN>(entity =>
                    {
                        entity.HasKey(e => e.IDP23);
                        entity.ToTable("P23 DINH KHOAN");
                        
                            entity.Property(e => e.CTTRUNG).HasColumnName("CTTRUNG");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(255);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(255);
                        
                            entity.Property(e => e.DTTHChiPhi).HasColumnName("DTTHChiPhi").HasMaxLength(150);
                        
                            entity.Property(e => e.GiaChuaThue).HasColumnName("GiaChuaThue");
                        
                            entity.Property(e => e.GiaThanhToan).HasColumnName("GiaThanhToan");
                        
                            entity.Property(e => e.IDP23).HasColumnName("IDP23");
                        
                            entity.Property(e => e.LoaiCP).HasColumnName("LoaiCP").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCP).HasColumnName("MaCP").HasMaxLength(150);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKHCo).HasColumnName("MaKHCo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKHNo).HasColumnName("MaKHNo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaThongKe).HasColumnName("MaThongKe").HasMaxLength(150);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTKCo).HasColumnName("MaTKCo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKNo).HasColumnName("MaTKNo").HasMaxLength(50);
                        
                            entity.Property(e => e.MucChi).HasColumnName("MucChi").HasMaxLength(150);
                        
                            entity.Property(e => e.NgayHoaDon).HasColumnName("NgayHoaDon");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.P23DTruong1).HasColumnName("P23DTruong1");
                        
                            entity.Property(e => e.P23NTruong1).HasColumnName("P23NTruong1");
                        
                            entity.Property(e => e.P23STruong1).HasColumnName("P23STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.SoHoaDon).HasColumnName("SoHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                    });
                    
                    modelBuilder.Entity<P31_BAN_HANG>(entity =>
                    {
                        entity.HasKey(e => e.RECKEY);
                        entity.ToTable("P31 BAN HANG");
                        
                            entity.Property(e => e.Ban).HasColumnName("Ban").HasMaxLength(50);
                        
                            entity.Property(e => e.ChiCucHQ).HasColumnName("ChiCucHQ").HasMaxLength(250);
                        
                            entity.Property(e => e.ChiNhanh).HasColumnName("ChiNhanh").HasMaxLength(250);
                        
                            entity.Property(e => e.CTGS).HasColumnName("CTGS").HasMaxLength(50);
                        
                            entity.Property(e => e.CTTRUNG).HasColumnName("CTTRUNG");
                        
                            entity.Property(e => e.CucHaiQuan).HasColumnName("CucHaiQuan").HasMaxLength(250);
                        
                            entity.Property(e => e.DaGhiSo).HasColumnName("DaGhiSo");
                        
                            entity.Property(e => e.DaGiaoHD).HasColumnName("DaGiaoHD");
                        
                            entity.Property(e => e.DaHT).HasColumnName("DaHT");
                        
                            entity.Property(e => e.DaLapHD).HasColumnName("DaLapHD");
                        
                            entity.Property(e => e.DaThanhToan).HasColumnName("DaThanhToan");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiGiao).HasColumnName("DiaChiGiao").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNhan).HasColumnName("DiaChiNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.DichVuVC).HasColumnName("DichVuVC").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(-1);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(-1);
                        
                            entity.Property(e => e.DieuKhoanTT).HasColumnName("DieuKhoanTT").HasMaxLength(50);
                        
                            entity.Property(e => e.DonDatHang).HasColumnName("DonDatHang").HasMaxLength(50);
                        
                            entity.Property(e => e.DTLHGiao).HasColumnName("DTLHGiao").HasMaxLength(250);
                        
                            entity.Property(e => e.DTLHNhan).HasColumnName("DTLHNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.DTTHChiPhi).HasColumnName("DTTHChiPhi").HasMaxLength(100);
                        
                            entity.Property(e => e.EmailGiao).HasColumnName("EmailGiao").HasMaxLength(250);
                        
                            entity.Property(e => e.EMailNhan).HasColumnName("EMailNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.FaxLHGiao).HasColumnName("FaxLHGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.FaxLHNhan).HasColumnName("FaxLHNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuDuyet).HasColumnName("GhiChuDuyet").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChuGS).HasColumnName("GhiChuGS").HasMaxLength(-1);
                        
                            entity.Property(e => e.HanCuoiDi).HasColumnName("HanCuoiDi").HasMaxLength(250);
                        
                            entity.Property(e => e.HanTra).HasColumnName("HanTra");
                        
                            entity.Property(e => e.ImportCode).HasColumnName("ImportCode").HasMaxLength(100);
                        
                            entity.Property(e => e.KhachDua).HasColumnName("KhachDua");
                        
                            entity.Property(e => e.KhuVuc).HasColumnName("KhuVuc").HasMaxLength(100);
                        
                            entity.Property(e => e.KyHieuMau).HasColumnName("KyHieuMau").HasMaxLength(50);
                        
                            entity.Property(e => e.LapKemHD).HasColumnName("LapKemHD");
                        
                            entity.Property(e => e.LoaiBH).HasColumnName("LoaiBH").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiHang).HasColumnName("LoaiHang").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.LoiNhan).HasColumnName("LoiNhan").HasMaxLength(500);
                        
                            entity.Property(e => e.MaBangGia).HasColumnName("MaBangGia").HasMaxLength(50);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDT).HasColumnName("MaDT").HasMaxLength(150);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MaHoaDon).HasColumnName("MaHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKho2).HasColumnName("MaKho2").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNoiGiao).HasColumnName("MaNoiGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNoiNhan).HasColumnName("MaNoiNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVCN).HasColumnName("MaNVCN").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVGiao).HasColumnName("MaNVGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVienGS).HasColumnName("MaNVienGS").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVQL).HasColumnName("MaNVQL").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVu).HasColumnName("MaNVu").HasMaxLength(50);
                        
                            entity.Property(e => e.MaThongKe).HasColumnName("MaThongKe").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTKNH).HasColumnName("MaTKNH").HasMaxLength(50);
                        
                            entity.Property(e => e.MST).HasColumnName("MST").HasMaxLength(20);
                        
                            entity.Property(e => e.NgayBOB).HasColumnName("NgayBOB");
                        
                            entity.Property(e => e.NgayCTGS).HasColumnName("NgayCTGS");
                        
                            entity.Property(e => e.NgayDonHang).HasColumnName("NgayDonHang");
                        
                            entity.Property(e => e.NgayGioDuyet).HasColumnName("NgayGioDuyet");
                        
                            entity.Property(e => e.NgayGioGiao).HasColumnName("NgayGioGiao");
                        
                            entity.Property(e => e.NgayGioNhan).HasColumnName("NgayGioNhan");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayHT).HasColumnName("NgayHT");
                        
                            entity.Property(e => e.NgayLienHe).HasColumnName("NgayLienHe");
                        
                            entity.Property(e => e.NgayLot).HasColumnName("NgayLot");
                        
                            entity.Property(e => e.NgayLp).HasColumnName("NgayLp");
                        
                            entity.Property(e => e.NgayLPCD).HasColumnName("NgayLPCD");
                        
                            entity.Property(e => e.NgayToKhai).HasColumnName("NgayToKhai");
                        
                            entity.Property(e => e.NguoiDuyet).HasColumnName("NguoiDuyet").HasMaxLength(50);
                        
                            entity.Property(e => e.NguoiLHGiao).HasColumnName("NguoiLHGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.NguoiLHNhan).HasColumnName("NguoiLHNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.NguoiMua).HasColumnName("NguoiMua").HasMaxLength(250);
                        
                            entity.Property(e => e.NoCu).HasColumnName("NoCu");
                        
                            entity.Property(e => e.P31CKTruong1).HasColumnName("P31CKTruong1");
                        
                            entity.Property(e => e.P31CKTruong2).HasColumnName("P31CKTruong2");
                        
                            entity.Property(e => e.P31CKTruong3).HasColumnName("P31CKTruong3");
                        
                            entity.Property(e => e.P31CKTruong4).HasColumnName("P31CKTruong4");
                        
                            entity.Property(e => e.P31CKTruong5).HasColumnName("P31CKTruong5");
                        
                            entity.Property(e => e.P31DTruong1).HasColumnName("P31DTruong1");
                        
                            entity.Property(e => e.P31DTruong10).HasColumnName("P31DTruong10");
                        
                            entity.Property(e => e.P31DTruong2).HasColumnName("P31DTruong2");
                        
                            entity.Property(e => e.P31DTruong3).HasColumnName("P31DTruong3");
                        
                            entity.Property(e => e.P31DTruong4).HasColumnName("P31DTruong4");
                        
                            entity.Property(e => e.P31DTruong5).HasColumnName("P31DTruong5");
                        
                            entity.Property(e => e.P31DTruong6).HasColumnName("P31DTruong6");
                        
                            entity.Property(e => e.P31DTruong7).HasColumnName("P31DTruong7");
                        
                            entity.Property(e => e.P31DTruong8).HasColumnName("P31DTruong8");
                        
                            entity.Property(e => e.P31DTruong9).HasColumnName("P31DTruong9");
                        
                            entity.Property(e => e.P31NTruong1).HasColumnName("P31NTruong1");
                        
                            entity.Property(e => e.P31NTruong10).HasColumnName("P31NTruong10");
                        
                            entity.Property(e => e.P31NTruong2).HasColumnName("P31NTruong2");
                        
                            entity.Property(e => e.P31NTruong3).HasColumnName("P31NTruong3");
                        
                            entity.Property(e => e.P31NTruong4).HasColumnName("P31NTruong4");
                        
                            entity.Property(e => e.P31NTruong5).HasColumnName("P31NTruong5");
                        
                            entity.Property(e => e.P31NTruong6).HasColumnName("P31NTruong6");
                        
                            entity.Property(e => e.P31NTruong7).HasColumnName("P31NTruong7");
                        
                            entity.Property(e => e.P31NTruong8).HasColumnName("P31NTruong8");
                        
                            entity.Property(e => e.P31NTruong9).HasColumnName("P31NTruong9");
                        
                            entity.Property(e => e.P31STruong1).HasColumnName("P31STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong10).HasColumnName("P31STruong10").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong11).HasColumnName("P31STruong11").HasMaxLength(-1);
                        
                            entity.Property(e => e.P31STruong12).HasColumnName("P31STruong12").HasMaxLength(-1);
                        
                            entity.Property(e => e.P31STruong13).HasColumnName("P31STruong13").HasMaxLength(-1);
                        
                            entity.Property(e => e.P31STruong14).HasColumnName("P31STruong14").HasMaxLength(-1);
                        
                            entity.Property(e => e.P31STruong15).HasColumnName("P31STruong15").HasMaxLength(-1);
                        
                            entity.Property(e => e.P31STruong2).HasColumnName("P31STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong3).HasColumnName("P31STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong4).HasColumnName("P31STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong5).HasColumnName("P31STruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong6).HasColumnName("P31STruong6").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong7).HasColumnName("P31STruong7").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong8).HasColumnName("P31STruong8").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong9).HasColumnName("P31STruong9").HasMaxLength(250);
                        
                            entity.Property(e => e.PTTT).HasColumnName("PTTT").HasMaxLength(50);
                        
                            entity.Property(e => e.QuanHuyenGiao).HasColumnName("QuanHuyenGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.QuanHuyenNhan).HasColumnName("QuanHuyenNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.Quay).HasColumnName("Quay").HasMaxLength(50);
                        
                            entity.Property(e => e.QuocGiaGiao).HasColumnName("QuocGiaGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.QuocGiaNhan).HasColumnName("QuocGiaNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.RaLuc).HasColumnName("RaLuc");
                        
                            entity.Property(e => e.RecBOB).HasColumnName("RecBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYPN).HasColumnName("RECKEYPN").HasMaxLength(50);
                        
                            entity.Property(e => e.RECKEYPX).HasColumnName("RECKEYPX").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLDX).HasColumnName("RecLDX").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLOT).HasColumnName("RecLOT").HasMaxLength(100);
                        
                            entity.Property(e => e.SNTDNoiGiao).HasColumnName("SNTDNoiGiao").HasMaxLength(250);
                        
                            entity.Property(e => e.SNTDNoiNhan).HasColumnName("SNTDNoiNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(50);
                        
                            entity.Property(e => e.SoCTLH).HasColumnName("SoCTLH").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHoaDon).HasColumnName("SoHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.SoKyHieu).HasColumnName("SoKyHieu").HasMaxLength(30);
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoNgayNo).HasColumnName("SoNgayNo");
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.SoPhieuCD).HasColumnName("SoPhieuCD").HasMaxLength(50);
                        
                            entity.Property(e => e.SoPhieuXuat).HasColumnName("SoPhieuXuat").HasMaxLength(30);
                        
                            entity.Property(e => e.SoToKhai).HasColumnName("SoToKhai").HasMaxLength(50);
                        
                            entity.Property(e => e.TenDT).HasColumnName("TenDT").HasMaxLength(250);
                        
                            entity.Property(e => e.TenKH).HasColumnName("TenKH").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenNoiGiao).HasColumnName("TenNoiGiao").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNoiNhan).HasColumnName("TenNoiNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKNH).HasColumnName("TenTKNH").HasMaxLength(250);
                        
                            entity.Property(e => e.ThamChieu).HasColumnName("ThamChieu").HasMaxLength(250);
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT").HasMaxLength(30);
                        
                            entity.Property(e => e.TienCK).HasColumnName("TienCK");
                        
                            entity.Property(e => e.TienCKOP).HasColumnName("TienCKOP");
                        
                            entity.Property(e => e.TienCKTT).HasColumnName("TienCKTT");
                        
                            entity.Property(e => e.TienConLai).HasColumnName("TienConLai");
                        
                            entity.Property(e => e.TienHang).HasColumnName("TienHang");
                        
                            entity.Property(e => e.TienPhi).HasColumnName("TienPhi");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TinhThanhGiao).HasColumnName("TinhThanhGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.TinhThanhNhan).HasColumnName("TinhThanhNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.TinhTrang).HasColumnName("TinhTrang").HasMaxLength(50);
                        
                            entity.Property(e => e.TinhTrangDH).HasColumnName("TinhTrangDH").HasMaxLength(50);
                        
                            entity.Property(e => e.TinhTrangOrder).HasColumnName("TinhTrangOrder").HasMaxLength(150);
                        
                            entity.Property(e => e.TongKien).HasColumnName("TongKien");
                        
                            entity.Property(e => e.TongKL).HasColumnName("TongKL");
                        
                            entity.Property(e => e.TongNgoaiTe).HasColumnName("TongNgoaiTe");
                        
                            entity.Property(e => e.TongSL).HasColumnName("TongSL");
                        
                            entity.Property(e => e.TongTien).HasColumnName("TongTien");
                        
                            entity.Property(e => e.TrenSo).HasColumnName("TrenSo").HasMaxLength(100);
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyLeCK).HasColumnName("TyLeCK");
                        
                            entity.Property(e => e.TyLeCKOP).HasColumnName("TyLeCKOP");
                        
                            entity.Property(e => e.TyLeCKTT).HasColumnName("TyLeCKTT");
                        
                            entity.Property(e => e.TyLeCP).HasColumnName("TyLeCP");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.VaoLuc).HasColumnName("VaoLuc");
                        
                            entity.Property(e => e.VaoRecy).HasColumnName("VaoRecy");
                        
                            entity.Property(e => e.XaPhuongGiao).HasColumnName("XaPhuongGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.XaPhuongNhan).HasColumnName("XaPhuongNhan").HasMaxLength(100);
                        
                            entity.Property(e => e.XeGiao).HasColumnName("XeGiao").HasMaxLength(50);
                        
                    });
                    
                    modelBuilder.Entity<P31TMP_BAN_HANG>(entity =>
                    {
                        entity.HasKey(e => e.RECKEY);
                        entity.ToTable("P31TMP BAN HANG");
                        
                            entity.Property(e => e.Ban).HasColumnName("Ban").HasMaxLength(50);
                        
                            entity.Property(e => e.ChiCucHQ).HasColumnName("ChiCucHQ").HasMaxLength(250);
                        
                            entity.Property(e => e.ChiNhanh).HasColumnName("ChiNhanh").HasMaxLength(150);
                        
                            entity.Property(e => e.CTGS).HasColumnName("CTGS").HasMaxLength(50);
                        
                            entity.Property(e => e.CTTRUNG).HasColumnName("CTTRUNG");
                        
                            entity.Property(e => e.CucHaiQuan).HasColumnName("CucHaiQuan").HasMaxLength(250);
                        
                            entity.Property(e => e.DaGhiSo).HasColumnName("DaGhiSo");
                        
                            entity.Property(e => e.DaGiaoHD).HasColumnName("DaGiaoHD");
                        
                            entity.Property(e => e.DaHT).HasColumnName("DaHT");
                        
                            entity.Property(e => e.DaLapHD).HasColumnName("DaLapHD");
                        
                            entity.Property(e => e.DaThanhToan).HasColumnName("DaThanhToan");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DieuKhoanTT).HasColumnName("DieuKhoanTT").HasMaxLength(50);
                        
                            entity.Property(e => e.DonDatHang).HasColumnName("DonDatHang").HasMaxLength(50);
                        
                            entity.Property(e => e.DTTHChiPhi).HasColumnName("DTTHChiPhi").HasMaxLength(100);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuDuyet).HasColumnName("GhiChuDuyet").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChuGS).HasColumnName("GhiChuGS").HasMaxLength(-1);
                        
                            entity.Property(e => e.HanTra).HasColumnName("HanTra");
                        
                            entity.Property(e => e.ImportCode).HasColumnName("ImportCode").HasMaxLength(100);
                        
                            entity.Property(e => e.KhachDua).HasColumnName("KhachDua");
                        
                            entity.Property(e => e.KhuVuc).HasColumnName("KhuVuc").HasMaxLength(100);
                        
                            entity.Property(e => e.KyHieuMau).HasColumnName("KyHieuMau").HasMaxLength(50);
                        
                            entity.Property(e => e.LapKemHD).HasColumnName("LapKemHD");
                        
                            entity.Property(e => e.LoaiBH).HasColumnName("LoaiBH").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.MaBangGia).HasColumnName("MaBangGia").HasMaxLength(10);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDT).HasColumnName("MaDT").HasMaxLength(150);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.MaHoaDon).HasColumnName("MaHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(20);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(20);
                        
                            entity.Property(e => e.MaKho2).HasColumnName("MaKho2").HasMaxLength(20);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVGiao).HasColumnName("MaNVGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVienGS).HasColumnName("MaNVienGS").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVu).HasColumnName("MaNVu").HasMaxLength(20);
                        
                            entity.Property(e => e.MaThongKe).HasColumnName("MaThongKe").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTKNH).HasColumnName("MaTKNH").HasMaxLength(50);
                        
                            entity.Property(e => e.MST).HasColumnName("MST").HasMaxLength(20);
                        
                            entity.Property(e => e.NgayBOB).HasColumnName("NgayBOB");
                        
                            entity.Property(e => e.NgayCTGS).HasColumnName("NgayCTGS");
                        
                            entity.Property(e => e.NgayDonHang).HasColumnName("NgayDonHang");
                        
                            entity.Property(e => e.NgayGioDuyet).HasColumnName("NgayGioDuyet");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(60);
                        
                            entity.Property(e => e.NgayHT).HasColumnName("NgayHT");
                        
                            entity.Property(e => e.NgayLienHe).HasColumnName("NgayLienHe");
                        
                            entity.Property(e => e.NgayLot).HasColumnName("NgayLot");
                        
                            entity.Property(e => e.NgayLp).HasColumnName("NgayLp");
                        
                            entity.Property(e => e.NgayLPCD).HasColumnName("NgayLPCD");
                        
                            entity.Property(e => e.NgayToKhai).HasColumnName("NgayToKhai");
                        
                            entity.Property(e => e.NguoiDuyet).HasColumnName("NguoiDuyet").HasMaxLength(50);
                        
                            entity.Property(e => e.NguoiMua).HasColumnName("NguoiMua").HasMaxLength(100);
                        
                            entity.Property(e => e.NoCu).HasColumnName("NoCu");
                        
                            entity.Property(e => e.P31CKTruong1).HasColumnName("P31CKTruong1");
                        
                            entity.Property(e => e.P31CKTruong2).HasColumnName("P31CKTruong2");
                        
                            entity.Property(e => e.P31CKTruong3).HasColumnName("P31CKTruong3");
                        
                            entity.Property(e => e.P31CKTruong4).HasColumnName("P31CKTruong4");
                        
                            entity.Property(e => e.P31CKTruong5).HasColumnName("P31CKTruong5");
                        
                            entity.Property(e => e.P31DTruong1).HasColumnName("P31DTruong1");
                        
                            entity.Property(e => e.P31DTruong10).HasColumnName("P31DTruong10");
                        
                            entity.Property(e => e.P31DTruong2).HasColumnName("P31DTruong2");
                        
                            entity.Property(e => e.P31DTruong3).HasColumnName("P31DTruong3");
                        
                            entity.Property(e => e.P31DTruong4).HasColumnName("P31DTruong4");
                        
                            entity.Property(e => e.P31DTruong5).HasColumnName("P31DTruong5");
                        
                            entity.Property(e => e.P31DTruong6).HasColumnName("P31DTruong6");
                        
                            entity.Property(e => e.P31DTruong7).HasColumnName("P31DTruong7");
                        
                            entity.Property(e => e.P31DTruong8).HasColumnName("P31DTruong8");
                        
                            entity.Property(e => e.P31DTruong9).HasColumnName("P31DTruong9");
                        
                            entity.Property(e => e.P31NTruong1).HasColumnName("P31NTruong1");
                        
                            entity.Property(e => e.P31NTruong10).HasColumnName("P31NTruong10");
                        
                            entity.Property(e => e.P31NTruong2).HasColumnName("P31NTruong2");
                        
                            entity.Property(e => e.P31NTruong3).HasColumnName("P31NTruong3");
                        
                            entity.Property(e => e.P31NTruong4).HasColumnName("P31NTruong4");
                        
                            entity.Property(e => e.P31NTruong5).HasColumnName("P31NTruong5");
                        
                            entity.Property(e => e.P31NTruong6).HasColumnName("P31NTruong6");
                        
                            entity.Property(e => e.P31NTruong7).HasColumnName("P31NTruong7");
                        
                            entity.Property(e => e.P31NTruong8).HasColumnName("P31NTruong8");
                        
                            entity.Property(e => e.P31NTruong9).HasColumnName("P31NTruong9");
                        
                            entity.Property(e => e.P31STruong1).HasColumnName("P31STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong10).HasColumnName("P31STruong10").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong11).HasColumnName("P31STruong11").HasMaxLength(-1);
                        
                            entity.Property(e => e.P31STruong12).HasColumnName("P31STruong12").HasMaxLength(-1);
                        
                            entity.Property(e => e.P31STruong13).HasColumnName("P31STruong13").HasMaxLength(-1);
                        
                            entity.Property(e => e.P31STruong14).HasColumnName("P31STruong14").HasMaxLength(-1);
                        
                            entity.Property(e => e.P31STruong15).HasColumnName("P31STruong15").HasMaxLength(-1);
                        
                            entity.Property(e => e.P31STruong2).HasColumnName("P31STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong3).HasColumnName("P31STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong4).HasColumnName("P31STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong5).HasColumnName("P31STruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong6).HasColumnName("P31STruong6").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong7).HasColumnName("P31STruong7").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong8).HasColumnName("P31STruong8").HasMaxLength(250);
                        
                            entity.Property(e => e.P31STruong9).HasColumnName("P31STruong9").HasMaxLength(250);
                        
                            entity.Property(e => e.PTTT).HasColumnName("PTTT").HasMaxLength(50);
                        
                            entity.Property(e => e.Quay).HasColumnName("Quay").HasMaxLength(50);
                        
                            entity.Property(e => e.RaLuc).HasColumnName("RaLuc");
                        
                            entity.Property(e => e.RecBOB).HasColumnName("RecBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.RECKEYPN).HasColumnName("RECKEYPN").HasMaxLength(50);
                        
                            entity.Property(e => e.RECKEYPX).HasColumnName("RECKEYPX").HasMaxLength(50);
                        
                            entity.Property(e => e.RecLDX).HasColumnName("RecLDX").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLOT).HasColumnName("RecLOT").HasMaxLength(100);
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(50);
                        
                            entity.Property(e => e.SoCTLH).HasColumnName("SoCTLH").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHoaDon).HasColumnName("SoHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.SoKyHieu).HasColumnName("SoKyHieu").HasMaxLength(30);
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoNgayNo).HasColumnName("SoNgayNo");
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.SoPhieuCD).HasColumnName("SoPhieuCD").HasMaxLength(50);
                        
                            entity.Property(e => e.SoPhieuXuat).HasColumnName("SoPhieuXuat").HasMaxLength(30);
                        
                            entity.Property(e => e.SoToKhai).HasColumnName("SoToKhai").HasMaxLength(50);
                        
                            entity.Property(e => e.TenDT).HasColumnName("TenDT").HasMaxLength(250);
                        
                            entity.Property(e => e.TenKH).HasColumnName("TenKH").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKNH).HasColumnName("TenTKNH").HasMaxLength(250);
                        
                            entity.Property(e => e.ThamChieu).HasColumnName("ThamChieu").HasMaxLength(250);
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TienCK).HasColumnName("TienCK");
                        
                            entity.Property(e => e.TienCKOP).HasColumnName("TienCKOP");
                        
                            entity.Property(e => e.TienCKTT).HasColumnName("TienCKTT");
                        
                            entity.Property(e => e.TienConLai).HasColumnName("TienConLai");
                        
                            entity.Property(e => e.TienHang).HasColumnName("TienHang");
                        
                            entity.Property(e => e.TienPhi).HasColumnName("TienPhi");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TinhTrang).HasColumnName("TinhTrang").HasMaxLength(50);
                        
                            entity.Property(e => e.TinhTrangDH).HasColumnName("TinhTrangDH").HasMaxLength(50);
                        
                            entity.Property(e => e.TinhTrangOrder).HasColumnName("TinhTrangOrder").HasMaxLength(150);
                        
                            entity.Property(e => e.TongNgoaiTe).HasColumnName("TongNgoaiTe");
                        
                            entity.Property(e => e.TongTien).HasColumnName("TongTien");
                        
                            entity.Property(e => e.TrenSo).HasColumnName("TrenSo").HasMaxLength(100);
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyLeCK).HasColumnName("TyLeCK");
                        
                            entity.Property(e => e.TyLeCKOP).HasColumnName("TyLeCKOP");
                        
                            entity.Property(e => e.TyLeCKTT).HasColumnName("TyLeCKTT");
                        
                            entity.Property(e => e.TyLeCP).HasColumnName("TyLeCP");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(30);
                        
                            entity.Property(e => e.VaoLuc).HasColumnName("VaoLuc");
                        
                            entity.Property(e => e.VaoRecy).HasColumnName("VaoRecy");
                        
                            entity.Property(e => e.XeGiao).HasColumnName("XeGiao").HasMaxLength(50);
                        
                    });
                    
                    modelBuilder.Entity<P32_CHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.IDP32);
                        entity.ToTable("P32 CHI TIET");
                        
                            entity.Property(e => e.CtuKMTraSau).HasColumnName("CtuKMTraSau").HasMaxLength(250);
                        
                            entity.Property(e => e.DateLot).HasColumnName("DateLot").HasMaxLength(20);
                        
                            entity.Property(e => e.DaTraKMSau).HasColumnName("DaTraKMSau");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DoanhThuXN).HasColumnName("DoanhThuXN");
                        
                            entity.Property(e => e.DoCao).HasColumnName("DoCao");
                        
                            entity.Property(e => e.DoDai).HasColumnName("DoDai");
                        
                            entity.Property(e => e.DonDatHang).HasColumnName("DonDatHang").HasMaxLength(100);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.DonGiaBan).HasColumnName("DonGiaBan");
                        
                            entity.Property(e => e.DonGiaGoc).HasColumnName("DonGiaGoc");
                        
                            entity.Property(e => e.DonGiaNT).HasColumnName("DonGiaNT");
                        
                            entity.Property(e => e.DonGiaTX).HasColumnName("DonGiaTX");
                        
                            entity.Property(e => e.DonGiaVC).HasColumnName("DonGiaVC");
                        
                            entity.Property(e => e.DonGiaXN).HasColumnName("DonGiaXN");
                        
                            entity.Property(e => e.DoRong).HasColumnName("DoRong");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(20);
                        
                            entity.Property(e => e.DVTKien).HasColumnName("DVTKien").HasMaxLength(100);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GiaBaoKH).HasColumnName("GiaBaoKH");
                        
                            entity.Property(e => e.IDLichTau).HasColumnName("IDLichTau");
                        
                            entity.Property(e => e.IDP32).HasColumnName("IDP32");
                        
                            entity.Property(e => e.IDSerial).HasColumnName("IDSerial").HasMaxLength(150);
                        
                            entity.Property(e => e.KhoiLuong).HasColumnName("KhoiLuong");
                        
                            entity.Property(e => e.LaiSuat).HasColumnName("LaiSuat");
                        
                            entity.Property(e => e.LoaiCont).HasColumnName("LoaiCont").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiKM).HasColumnName("LoaiKM").HasMaxLength(30);
                        
                            entity.Property(e => e.LoaiMau).HasColumnName("LoaiMau").HasMaxLength(30);
                        
                            entity.Property(e => e.LoaiTai).HasColumnName("LoaiTai").HasMaxLength(100);
                        
                            entity.Property(e => e.LuanChuyen).HasColumnName("LuanChuyen");
                        
                            entity.Property(e => e.LuongTXVC).HasColumnName("LuongTXVC");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCP).HasColumnName("MaCP").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKho2).HasColumnName("MaKho2").HasMaxLength(50);
                        
                            entity.Property(e => e.MaThanhPham).HasColumnName("MaThanhPham").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(10);
                        
                            entity.Property(e => e.MaTKCP).HasColumnName("MaTKCP").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKDT).HasColumnName("MaTKDT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(30);
                        
                            entity.Property(e => e.NgayGiao).HasColumnName("NgayGiao");
                        
                            entity.Property(e => e.NgayGioHa).HasColumnName("NgayGioHa");
                        
                            entity.Property(e => e.NgayGioLay).HasColumnName("NgayGioLay");
                        
                            entity.Property(e => e.NgayLay).HasColumnName("NgayLay");
                        
                            entity.Property(e => e.NgayXuatCuoi).HasColumnName("NgayXuatCuoi");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NgoaiTeCK).HasColumnName("NgoaiTeCK");
                        
                            entity.Property(e => e.NgoaiTeGoc).HasColumnName("NgoaiTeGoc");
                        
                            entity.Property(e => e.NoiGiao).HasColumnName("NoiGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.NoiHaRong).HasColumnName("NoiHaRong").HasMaxLength(100);
                        
                            entity.Property(e => e.NoiLay).HasColumnName("NoiLay").HasMaxLength(100);
                        
                            entity.Property(e => e.NoiLayCont).HasColumnName("NoiLayCont").HasMaxLength(100);
                        
                            entity.Property(e => e.P32CKTruong1).HasColumnName("P32CKTruong1");
                        
                            entity.Property(e => e.P32CKTruong2).HasColumnName("P32CKTruong2");
                        
                            entity.Property(e => e.P32CKTruong3).HasColumnName("P32CKTruong3");
                        
                            entity.Property(e => e.P32CKTruong4).HasColumnName("P32CKTruong4");
                        
                            entity.Property(e => e.P32DTruong1).HasColumnName("P32DTruong1");
                        
                            entity.Property(e => e.P32DTruong2).HasColumnName("P32DTruong2");
                        
                            entity.Property(e => e.P32DTruong3).HasColumnName("P32DTruong3");
                        
                            entity.Property(e => e.P32DTruong4).HasColumnName("P32DTruong4");
                        
                            entity.Property(e => e.P32NITruong1).HasColumnName("P32NITruong1");
                        
                            entity.Property(e => e.P32NITruong2).HasColumnName("P32NITruong2");
                        
                            entity.Property(e => e.P32NITruong3).HasColumnName("P32NITruong3");
                        
                            entity.Property(e => e.P32NITruong4).HasColumnName("P32NITruong4");
                        
                            entity.Property(e => e.P32NTruong1).HasColumnName("P32NTruong1");
                        
                            entity.Property(e => e.P32NTruong10).HasColumnName("P32NTruong10");
                        
                            entity.Property(e => e.P32NTruong2).HasColumnName("P32NTruong2");
                        
                            entity.Property(e => e.P32NTruong3).HasColumnName("P32NTruong3");
                        
                            entity.Property(e => e.P32NTruong4).HasColumnName("P32NTruong4");
                        
                            entity.Property(e => e.P32NTruong5).HasColumnName("P32NTruong5");
                        
                            entity.Property(e => e.P32NTruong6).HasColumnName("P32NTruong6");
                        
                            entity.Property(e => e.P32NTruong7).HasColumnName("P32NTruong7");
                        
                            entity.Property(e => e.P32NTruong8).HasColumnName("P32NTruong8");
                        
                            entity.Property(e => e.P32NTruong9).HasColumnName("P32NTruong9");
                        
                            entity.Property(e => e.P32STruong1).HasColumnName("P32STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong10).HasColumnName("P32STruong10").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong2).HasColumnName("P32STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong3).HasColumnName("P32STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong4).HasColumnName("P32STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong5).HasColumnName("P32STruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong6).HasColumnName("P32STruong6").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong7).HasColumnName("P32STruong7").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong8).HasColumnName("P32STruong8").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong9).HasColumnName("P32STruong9").HasMaxLength(250);
                        
                            entity.Property(e => e.PhiCauDuong).HasColumnName("PhiCauDuong");
                        
                            entity.Property(e => e.PTTT).HasColumnName("PTTT").HasMaxLength(50);
                        
                            entity.Property(e => e.RecBOB).HasColumnName("RecBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.RecHaRong).HasColumnName("RecHaRong").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.RECKEYP32).HasColumnName("RECKEYP32").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLayCont).HasColumnName("RecLayCont").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLOT).HasColumnName("RecLOT").HasMaxLength(100);
                        
                            entity.Property(e => e.RecNoiGiao).HasColumnName("RecNoiGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.RecNoiLay).HasColumnName("RecNoiLay").HasMaxLength(100);
                        
                            entity.Property(e => e.RecTuyen).HasColumnName("RecTuyen").HasMaxLength(100);
                        
                            entity.Property(e => e.SLPhu).HasColumnName("SLPhu");
                        
                            entity.Property(e => e.SLTraLai).HasColumnName("SLTraLai");
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.SoChuyen).HasColumnName("SoChuyen");
                        
                            entity.Property(e => e.SoCont).HasColumnName("SoCont").HasMaxLength(100);
                        
                            entity.Property(e => e.SoKhoi).HasColumnName("SoKhoi");
                        
                            entity.Property(e => e.SoKien).HasColumnName("SoKien");
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoLuongCon).HasColumnName("SoLuongCon");
                        
                            entity.Property(e => e.SoLuongGiao).HasColumnName("SoLuongGiao");
                        
                            entity.Property(e => e.SoSeal).HasColumnName("SoSeal").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT").HasMaxLength(10);
                        
                            entity.Property(e => e.TaiNang).HasColumnName("TaiNang");
                        
                            entity.Property(e => e.TenYeuCau).HasColumnName("TenYeuCau").HasMaxLength(250);
                        
                            entity.Property(e => e.ThanhTienVC).HasColumnName("ThanhTienVC");
                        
                            entity.Property(e => e.ThanhTienXN).HasColumnName("ThanhTienXN");
                        
                            entity.Property(e => e.ThueNK).HasColumnName("ThueNK");
                        
                            entity.Property(e => e.ThueTTDB).HasColumnName("ThueTTDB");
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT").HasMaxLength(30);
                        
                            entity.Property(e => e.TienBan).HasColumnName("TienBan");
                        
                            entity.Property(e => e.TienCKTT).HasColumnName("TienCKTT");
                        
                            entity.Property(e => e.TienCoVAT).HasColumnName("TienCoVAT");
                        
                            entity.Property(e => e.TienGiamGia).HasColumnName("TienGiamGia");
                        
                            entity.Property(e => e.TienKM).HasColumnName("TienKM");
                        
                            entity.Property(e => e.TienKMTraSau).HasColumnName("TienKMTraSau");
                        
                            entity.Property(e => e.TienLai).HasColumnName("TienLai");
                        
                            entity.Property(e => e.TienLePhi).HasColumnName("TienLePhi");
                        
                            entity.Property(e => e.TienQuyDoi).HasColumnName("TienQuyDoi");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TienVNDCK).HasColumnName("TienVNDCK");
                        
                            entity.Property(e => e.TienVNDCon).HasColumnName("TienVNDCon");
                        
                            entity.Property(e => e.TienVNDGoc).HasColumnName("TienVNDGoc");
                        
                            entity.Property(e => e.TLGiamGia).HasColumnName("TLGiamGia");
                        
                            entity.Property(e => e.TongSL).HasColumnName("TongSL");
                        
                            entity.Property(e => e.TraTienKM).HasColumnName("TraTienKM");
                        
                            entity.Property(e => e.TuyenDuong).HasColumnName("TuyenDuong").HasMaxLength(100);
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyLeCK).HasColumnName("TyLeCK");
                        
                            entity.Property(e => e.TyLeCKTT).HasColumnName("TyLeCKTT");
                        
                    });
                    
                    modelBuilder.Entity<P32TMP_CHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.IDP32);
                        entity.ToTable("P32TMP CHI TIET");
                        
                            entity.Property(e => e.CtuKMTraSau).HasColumnName("CtuKMTraSau").HasMaxLength(250);
                        
                            entity.Property(e => e.DateLot).HasColumnName("DateLot").HasMaxLength(20);
                        
                            entity.Property(e => e.DaTraKMSau).HasColumnName("DaTraKMSau");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DoCao).HasColumnName("DoCao");
                        
                            entity.Property(e => e.DoDai).HasColumnName("DoDai");
                        
                            entity.Property(e => e.DonDatHang).HasColumnName("DonDatHang").HasMaxLength(100);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.DonGiaBan).HasColumnName("DonGiaBan");
                        
                            entity.Property(e => e.DonGiaGoc).HasColumnName("DonGiaGoc");
                        
                            entity.Property(e => e.DonGiaNT).HasColumnName("DonGiaNT");
                        
                            entity.Property(e => e.DonGiaVC).HasColumnName("DonGiaVC");
                        
                            entity.Property(e => e.DoRong).HasColumnName("DoRong");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(20);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.IDP32).HasColumnName("IDP32");
                        
                            entity.Property(e => e.IDSerial).HasColumnName("IDSerial").HasMaxLength(150);
                        
                            entity.Property(e => e.KhoiLuong).HasColumnName("KhoiLuong");
                        
                            entity.Property(e => e.LaiSuat).HasColumnName("LaiSuat");
                        
                            entity.Property(e => e.LoaiKM).HasColumnName("LoaiKM").HasMaxLength(30);
                        
                            entity.Property(e => e.LoaiMau).HasColumnName("LoaiMau").HasMaxLength(30);
                        
                            entity.Property(e => e.LuanChuyen).HasColumnName("LuanChuyen");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKho2).HasColumnName("MaKho2").HasMaxLength(50);
                        
                            entity.Property(e => e.MaThanhPham).HasColumnName("MaThanhPham").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(10);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(30);
                        
                            entity.Property(e => e.NgayXuatCuoi).HasColumnName("NgayXuatCuoi");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NgoaiTeCK).HasColumnName("NgoaiTeCK");
                        
                            entity.Property(e => e.NgoaiTeGoc).HasColumnName("NgoaiTeGoc");
                        
                            entity.Property(e => e.P32CKTruong1).HasColumnName("P32CKTruong1");
                        
                            entity.Property(e => e.P32CKTruong2).HasColumnName("P32CKTruong2");
                        
                            entity.Property(e => e.P32CKTruong3).HasColumnName("P32CKTruong3");
                        
                            entity.Property(e => e.P32CKTruong4).HasColumnName("P32CKTruong4");
                        
                            entity.Property(e => e.P32DTruong1).HasColumnName("P32DTruong1");
                        
                            entity.Property(e => e.P32DTruong2).HasColumnName("P32DTruong2");
                        
                            entity.Property(e => e.P32DTruong3).HasColumnName("P32DTruong3");
                        
                            entity.Property(e => e.P32DTruong4).HasColumnName("P32DTruong4");
                        
                            entity.Property(e => e.P32NITruong1).HasColumnName("P32NITruong1");
                        
                            entity.Property(e => e.P32NITruong2).HasColumnName("P32NITruong2");
                        
                            entity.Property(e => e.P32NITruong3).HasColumnName("P32NITruong3");
                        
                            entity.Property(e => e.P32NITruong4).HasColumnName("P32NITruong4");
                        
                            entity.Property(e => e.P32NTruong1).HasColumnName("P32NTruong1");
                        
                            entity.Property(e => e.P32NTruong10).HasColumnName("P32NTruong10");
                        
                            entity.Property(e => e.P32NTruong2).HasColumnName("P32NTruong2");
                        
                            entity.Property(e => e.P32NTruong3).HasColumnName("P32NTruong3");
                        
                            entity.Property(e => e.P32NTruong4).HasColumnName("P32NTruong4");
                        
                            entity.Property(e => e.P32NTruong5).HasColumnName("P32NTruong5");
                        
                            entity.Property(e => e.P32NTruong6).HasColumnName("P32NTruong6");
                        
                            entity.Property(e => e.P32NTruong7).HasColumnName("P32NTruong7");
                        
                            entity.Property(e => e.P32NTruong8).HasColumnName("P32NTruong8");
                        
                            entity.Property(e => e.P32NTruong9).HasColumnName("P32NTruong9");
                        
                            entity.Property(e => e.P32STruong1).HasColumnName("P32STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong10).HasColumnName("P32STruong10").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong2).HasColumnName("P32STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong3).HasColumnName("P32STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong4).HasColumnName("P32STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong5).HasColumnName("P32STruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong6).HasColumnName("P32STruong6").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong7).HasColumnName("P32STruong7").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong8).HasColumnName("P32STruong8").HasMaxLength(250);
                        
                            entity.Property(e => e.P32STruong9).HasColumnName("P32STruong9").HasMaxLength(250);
                        
                            entity.Property(e => e.PTTT).HasColumnName("PTTT").HasMaxLength(50);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.RECKEYP32).HasColumnName("RECKEYP32").HasMaxLength(100);
                        
                            entity.Property(e => e.SLPhu).HasColumnName("SLPhu");
                        
                            entity.Property(e => e.SLTraLai).HasColumnName("SLTraLai");
                        
                            entity.Property(e => e.SoChuyen).HasColumnName("SoChuyen");
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoLuongCon).HasColumnName("SoLuongCon");
                        
                            entity.Property(e => e.SoLuongGiao).HasColumnName("SoLuongGiao");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenYeuCau).HasColumnName("TenYeuCau").HasMaxLength(250);
                        
                            entity.Property(e => e.ThanhTienVC).HasColumnName("ThanhTienVC");
                        
                            entity.Property(e => e.ThueNK).HasColumnName("ThueNK");
                        
                            entity.Property(e => e.ThueTTDB).HasColumnName("ThueTTDB");
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TienBan).HasColumnName("TienBan");
                        
                            entity.Property(e => e.TienCKTT).HasColumnName("TienCKTT");
                        
                            entity.Property(e => e.TienCoVAT).HasColumnName("TienCoVAT");
                        
                            entity.Property(e => e.TienGiamGia).HasColumnName("TienGiamGia");
                        
                            entity.Property(e => e.TienKM).HasColumnName("TienKM");
                        
                            entity.Property(e => e.TienKMTraSau).HasColumnName("TienKMTraSau");
                        
                            entity.Property(e => e.TienLai).HasColumnName("TienLai");
                        
                            entity.Property(e => e.TienLePhi).HasColumnName("TienLePhi");
                        
                            entity.Property(e => e.TienQuyDoi).HasColumnName("TienQuyDoi");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TienVNDCK).HasColumnName("TienVNDCK");
                        
                            entity.Property(e => e.TienVNDCon).HasColumnName("TienVNDCon");
                        
                            entity.Property(e => e.TienVNDGoc).HasColumnName("TienVNDGoc");
                        
                            entity.Property(e => e.TLGiamGia).HasColumnName("TLGiamGia");
                        
                            entity.Property(e => e.TongSL).HasColumnName("TongSL");
                        
                            entity.Property(e => e.TraTienKM).HasColumnName("TraTienKM");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyLeCK).HasColumnName("TyLeCK");
                        
                            entity.Property(e => e.TyLeCKTT).HasColumnName("TyLeCKTT");
                        
                    });
                    
                    modelBuilder.Entity<P33_DINH_KHOAN>(entity =>
                    {
                        entity.HasKey(e => e.IDP33);
                        entity.ToTable("P33 DINH KHOAN");
                        
                            entity.Property(e => e.CTTRUNG).HasColumnName("CTTRUNG");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(255);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(255);
                        
                            entity.Property(e => e.DTruong).HasColumnName("DTruong");
                        
                            entity.Property(e => e.DTTHChiPhi).HasColumnName("DTTHChiPhi").HasMaxLength(150);
                        
                            entity.Property(e => e.GiaChuaThue).HasColumnName("GiaChuaThue");
                        
                            entity.Property(e => e.GiaThanhToan).HasColumnName("GiaThanhToan");
                        
                            entity.Property(e => e.IDP33).HasColumnName("IDP33");
                        
                            entity.Property(e => e.LoaiCP).HasColumnName("LoaiCP").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCP).HasColumnName("MaCP").HasMaxLength(150);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(70);
                        
                            entity.Property(e => e.MaKHCo).HasColumnName("MaKHCo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKHNo).HasColumnName("MaKHNo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaThongKe).HasColumnName("MaThongKe").HasMaxLength(150);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(10);
                        
                            entity.Property(e => e.MaTKCo).HasColumnName("MaTKCo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKNo).HasColumnName("MaTKNo").HasMaxLength(50);
                        
                            entity.Property(e => e.MucChi).HasColumnName("MucChi").HasMaxLength(150);
                        
                            entity.Property(e => e.NgayHoaDon).HasColumnName("NgayHoaDon");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NTruong).HasColumnName("NTruong");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHoaDon).HasColumnName("SoHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.STruong).HasColumnName("STruong").HasMaxLength(250);
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                    });
                    
                    modelBuilder.Entity<P34_CHI_TIET_VC>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("P34_CHI_TIET_VC");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.BaiHaCX).HasColumnName("BaiHaCX").HasMaxLength(250);
                        
                            entity.Property(e => e.BuTruDau).HasColumnName("BuTruDau");
                        
                            entity.Property(e => e.CangCT).HasColumnName("CangCT").HasMaxLength(250);
                        
                            entity.Property(e => e.CangDo).HasColumnName("CangDo").HasMaxLength(250);
                        
                            entity.Property(e => e.CangXep).HasColumnName("CangXep").HasMaxLength(250);
                        
                            entity.Property(e => e.CapThucTe).HasColumnName("CapThucTe");
                        
                            entity.Property(e => e.ChuVanDon).HasColumnName("ChuVanDon").HasMaxLength(250);
                        
                            entity.Property(e => e.ContRong).HasColumnName("ContRong");
                        
                            entity.Property(e => e.CuLy).HasColumnName("CuLy");
                        
                            entity.Property(e => e.DGDau).HasColumnName("DGDau");
                        
                            entity.Property(e => e.DiaChiLayCont).HasColumnName("DiaChiLayCont").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiTraCont).HasColumnName("DiaChiTraCont").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiTraVo).HasColumnName("DiaChiTraVo").HasMaxLength(250);
                        
                            entity.Property(e => e.DiemLayCont).HasColumnName("DiemLayCont").HasMaxLength(100);
                        
                            entity.Property(e => e.DiemTraCont).HasColumnName("DiemTraCont").HasMaxLength(100);
                        
                            entity.Property(e => e.DiemTraVo).HasColumnName("DiemTraVo").HasMaxLength(100);
                        
                            entity.Property(e => e.DonDatHang).HasColumnName("DonDatHang").HasMaxLength(100);
                        
                            entity.Property(e => e.DongHang).HasColumnName("DongHang").HasMaxLength(-1);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.DonGiaNT).HasColumnName("DonGiaNT");
                        
                            entity.Property(e => e.DonGiaTX).HasColumnName("DonGiaTX");
                        
                            entity.Property(e => e.DonGiaVC).HasColumnName("DonGiaVC");
                        
                            entity.Property(e => e.DonGiaXN).HasColumnName("DonGiaXN");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.GhiChuCont).HasColumnName("GhiChuCont").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuHH).HasColumnName("GhiChuHH").HasMaxLength(-1);
                        
                            entity.Property(e => e.GioCatMang).HasColumnName("GioCatMang");
                        
                            entity.Property(e => e.GioDongLay).HasColumnName("GioDongLay");
                        
                            entity.Property(e => e.GioGiaoHa).HasColumnName("GioGiaoHa");
                        
                            entity.Property(e => e.Gioramang).HasColumnName("Gioramang").HasMaxLength(50);
                        
                            entity.Property(e => e.Giovaomang).HasColumnName("Giovaomang").HasMaxLength(50);
                        
                            entity.Property(e => e.HangTau).HasColumnName("HangTau").HasMaxLength(250);
                        
                            entity.Property(e => e.HanLuuBai).HasColumnName("HanLuuBai");
                        
                            entity.Property(e => e.HanLuuCont).HasColumnName("HanLuuCont");
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.IDCTBL).HasColumnName("IDCTBL").HasMaxLength(30);
                        
                            entity.Property(e => e.KhoiLuong).HasColumnName("KhoiLuong");
                        
                            entity.Property(e => e.LapLXD).HasColumnName("LapLXD");
                        
                            entity.Property(e => e.LoaiCont).HasColumnName("LoaiCont").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiCT).HasColumnName("LoaiCT").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiHang).HasColumnName("LoaiHang").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiNX).HasColumnName("LoaiNX").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiPT).HasColumnName("LoaiPT").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiVC).HasColumnName("LoaiVC").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.LuongTXVC).HasColumnName("LuongTXVC");
                        
                            entity.Property(e => e.MaBangGia).HasColumnName("MaBangGia").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChuPT).HasColumnName("MaChuPT").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKHTB).HasColumnName("MaKHTB").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVienCT).HasColumnName("MaNVienCT").HasMaxLength(150);
                        
                            entity.Property(e => e.MaNVienKD).HasColumnName("MaNVienKD").HasMaxLength(150);
                        
                            entity.Property(e => e.MaSoHang).HasColumnName("MaSoHang").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(100);
                        
                            entity.Property(e => e.MoTaHH).HasColumnName("MoTaHH").HasMaxLength(-1);
                        
                            entity.Property(e => e.NgayBOB).HasColumnName("NgayBOB");
                        
                            entity.Property(e => e.NgayCapDau).HasColumnName("NgayCapDau");
                        
                            entity.Property(e => e.NgayCatMang).HasColumnName("NgayCatMang");
                        
                            entity.Property(e => e.NgayDen).HasColumnName("NgayDen");
                        
                            entity.Property(e => e.NgayDongLay).HasColumnName("NgayDongLay");
                        
                            entity.Property(e => e.NgayGiaoHa).HasColumnName("NgayGiaoHa");
                        
                            entity.Property(e => e.NgayKH).HasColumnName("NgayKH");
                        
                            entity.Property(e => e.NgayLayCont).HasColumnName("NgayLayCont");
                        
                            entity.Property(e => e.NgayTamUng).HasColumnName("NgayTamUng");
                        
                            entity.Property(e => e.NgayTiepNhan).HasColumnName("NgayTiepNhan");
                        
                            entity.Property(e => e.NgayTraCont).HasColumnName("NgayTraCont");
                        
                            entity.Property(e => e.NgayTraVo).HasColumnName("NgayTraVo");
                        
                            entity.Property(e => e.NgayXeChay).HasColumnName("NgayXeChay");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NoiGiao).HasColumnName("NoiGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.NoiLay).HasColumnName("NoiLay").HasMaxLength(100);
                        
                            entity.Property(e => e.P34CTB1).HasColumnName("P34CTB1");
                        
                            entity.Property(e => e.P34CTB2).HasColumnName("P34CTB2");
                        
                            entity.Property(e => e.P34CTB3).HasColumnName("P34CTB3");
                        
                            entity.Property(e => e.P34CTB4).HasColumnName("P34CTB4");
                        
                            entity.Property(e => e.P34CTB5).HasColumnName("P34CTB5");
                        
                            entity.Property(e => e.P34CTD1).HasColumnName("P34CTD1");
                        
                            entity.Property(e => e.P34CTD2).HasColumnName("P34CTD2");
                        
                            entity.Property(e => e.P34CTD3).HasColumnName("P34CTD3");
                        
                            entity.Property(e => e.P34CTD4).HasColumnName("P34CTD4");
                        
                            entity.Property(e => e.P34CTD5).HasColumnName("P34CTD5");
                        
                            entity.Property(e => e.P34CTI1).HasColumnName("P34CTI1");
                        
                            entity.Property(e => e.P34CTI2).HasColumnName("P34CTI2");
                        
                            entity.Property(e => e.P34CTI3).HasColumnName("P34CTI3");
                        
                            entity.Property(e => e.P34CTI4).HasColumnName("P34CTI4");
                        
                            entity.Property(e => e.P34CTI5).HasColumnName("P34CTI5");
                        
                            entity.Property(e => e.P34CTN1).HasColumnName("P34CTN1");
                        
                            entity.Property(e => e.P34CTN2).HasColumnName("P34CTN2");
                        
                            entity.Property(e => e.P34CTN3).HasColumnName("P34CTN3");
                        
                            entity.Property(e => e.P34CTN4).HasColumnName("P34CTN4");
                        
                            entity.Property(e => e.P34CTN5).HasColumnName("P34CTN5");
                        
                            entity.Property(e => e.P34CTS1).HasColumnName("P34CTS1").HasMaxLength(100);
                        
                            entity.Property(e => e.P34CTS2).HasColumnName("P34CTS2").HasMaxLength(100);
                        
                            entity.Property(e => e.P34CTS3).HasColumnName("P34CTS3").HasMaxLength(100);
                        
                            entity.Property(e => e.P34CTS4).HasColumnName("P34CTS4").HasMaxLength(150);
                        
                            entity.Property(e => e.P34CTS5).HasColumnName("P34CTS5").HasMaxLength(150);
                        
                            entity.Property(e => e.RecBL).HasColumnName("RecBL").HasMaxLength(100);
                        
                            entity.Property(e => e.RECCT).HasColumnName("RECCT").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLDX).HasColumnName("RecLDX").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLot).HasColumnName("RecLot").HasMaxLength(100);
                        
                            entity.Property(e => e.RecNoiGiao).HasColumnName("RecNoiGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.RecNoiLay).HasColumnName("RecNoiLay").HasMaxLength(100);
                        
                            entity.Property(e => e.RecPNX).HasColumnName("RecPNX").HasMaxLength(100);
                        
                            entity.Property(e => e.RecToKhai).HasColumnName("RecToKhai").HasMaxLength(100);
                        
                            entity.Property(e => e.RecTuyen).HasColumnName("RecTuyen").HasMaxLength(100);
                        
                            entity.Property(e => e.SLDauDo).HasColumnName("SLDauDo");
                        
                            entity.Property(e => e.SLGross).HasColumnName("SLGross");
                        
                            entity.Property(e => e.SLNhan).HasColumnName("SLNhan");
                        
                            entity.Property(e => e.SoBL).HasColumnName("SoBL").HasMaxLength(100);
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.SoCont).HasColumnName("SoCont").HasMaxLength(100);
                        
                            entity.Property(e => e.SoDauDM).HasColumnName("SoDauDM");
                        
                            entity.Property(e => e.SoDauTT).HasColumnName("SoDauTT");
                        
                            entity.Property(e => e.SoHieuChuyen).HasColumnName("SoHieuChuyen").HasMaxLength(150);
                        
                            entity.Property(e => e.SoKhoi).HasColumnName("SoKhoi");
                        
                            entity.Property(e => e.SoKien).HasColumnName("SoKien").HasMaxLength(150);
                        
                            entity.Property(e => e.SoLDX).HasColumnName("SoLDX").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoLuongCont).HasColumnName("SoLuongCont");
                        
                            entity.Property(e => e.SoLuongGiao).HasColumnName("SoLuongGiao");
                        
                            entity.Property(e => e.SoPhieuDau).HasColumnName("SoPhieuDau").HasMaxLength(100);
                        
                            entity.Property(e => e.SoSeal).HasColumnName("SoSeal").HasMaxLength(150);
                        
                            entity.Property(e => e.SoToKhai).HasColumnName("SoToKhai").HasMaxLength(100);
                        
                            entity.Property(e => e.SoXe).HasColumnName("SoXe").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TaiXe).HasColumnName("TaiXe").HasMaxLength(100);
                        
                            entity.Property(e => e.TenChuPT).HasColumnName("TenChuPT").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenCont).HasColumnName("TenCont").HasMaxLength(250);
                        
                            entity.Property(e => e.TenKH).HasColumnName("TenKH").HasMaxLength(250);
                        
                            entity.Property(e => e.TenKHTB).HasColumnName("TenKHTB").HasMaxLength(250);
                        
                            entity.Property(e => e.TenSHPT).HasColumnName("TenSHPT").HasMaxLength(150);
                        
                            entity.Property(e => e.TenTau).HasColumnName("TenTau").HasMaxLength(250);
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(250);
                        
                            entity.Property(e => e.ThanhTienVC).HasColumnName("ThanhTienVC");
                        
                            entity.Property(e => e.ThanhTienXN).HasColumnName("ThanhTienXN");
                        
                            entity.Property(e => e.ThueKhac).HasColumnName("ThueKhac");
                        
                            entity.Property(e => e.ThueNK).HasColumnName("ThueNK");
                        
                            entity.Property(e => e.ThueTTDB).HasColumnName("ThueTTDB");
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TienDau).HasColumnName("TienDau");
                        
                            entity.Property(e => e.TienKhac).HasColumnName("TienKhac");
                        
                            entity.Property(e => e.TienThueNK).HasColumnName("TienThueNK");
                        
                            entity.Property(e => e.TienThueTTDB).HasColumnName("TienThueTTDB");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TinhTrang).HasColumnName("TinhTrang").HasMaxLength(250);
                        
                            entity.Property(e => e.TriGiaTinhThue).HasColumnName("TriGiaTinhThue");
                        
                            entity.Property(e => e.TuyenDuong).HasColumnName("TuyenDuong").HasMaxLength(100);
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.XeNgoai).HasColumnName("XeNgoai");
                        
                            entity.Property(e => e.XuatXu).HasColumnName("XuatXu").HasMaxLength(150);
                        
                    });
                    
                    modelBuilder.Entity<P41_SO_TONG_HOP>(entity =>
                    {
                        entity.HasKey(e => e.RECKEY);
                        entity.ToTable("P41 SO TONG HOP");
                        
                            entity.Property(e => e.CTGS).HasColumnName("CTGS").HasMaxLength(50);
                        
                            entity.Property(e => e.CTTrung).HasColumnName("CTTrung");
                        
                            entity.Property(e => e.DaGhiSo).HasColumnName("DaGhiSo");
                        
                            entity.Property(e => e.DaHT).HasColumnName("DaHT");
                        
                            entity.Property(e => e.DaNhanHD).HasColumnName("DaNhanHD");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(-1);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuDuyet).HasColumnName("GhiChuDuyet").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChuGS).HasColumnName("GhiChuGS").HasMaxLength(-1);
                        
                            entity.Property(e => e.HanTra).HasColumnName("HanTra");
                        
                            entity.Property(e => e.HoTen).HasColumnName("HoTen").HasMaxLength(250);
                        
                            entity.Property(e => e.ImportCode).HasColumnName("ImportCode").HasMaxLength(100);
                        
                            entity.Property(e => e.KhachTra).HasColumnName("KhachTra");
                        
                            entity.Property(e => e.KyKetChuyen).HasColumnName("KyKetChuyen").HasMaxLength(-1);
                        
                            entity.Property(e => e.LoaiGT).HasColumnName("LoaiGT").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.LoaiTH).HasColumnName("LoaiTH").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(100);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDT).HasColumnName("MaDT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MaKHCo).HasColumnName("MaKHCo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKHNo).HasColumnName("MaKHNo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNvien).HasColumnName("MaNvien").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVienGS).HasColumnName("MaNVienGS").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVu).HasColumnName("MaNVu").HasMaxLength(50);
                        
                            entity.Property(e => e.MaThongKe).HasColumnName("MaThongKe").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTKNH).HasColumnName("MaTKNH").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayBOB).HasColumnName("NgayBOB");
                        
                            entity.Property(e => e.NgayCTGS).HasColumnName("NgayCTGS");
                        
                            entity.Property(e => e.NgayGioDuyet).HasColumnName("NgayGioDuyet");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(50);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayHT).HasColumnName("NgayHT");
                        
                            entity.Property(e => e.NgayLot).HasColumnName("NgayLot");
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.NgayLPCD).HasColumnName("NgayLPCD");
                        
                            entity.Property(e => e.NgayToKhai).HasColumnName("NgayToKhai");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NguoiDuyet).HasColumnName("NguoiDuyet").HasMaxLength(50);
                        
                            entity.Property(e => e.NhanVienChi).HasColumnName("NhanVienChi").HasMaxLength(100);
                        
                            entity.Property(e => e.NoCu).HasColumnName("NoCu");
                        
                            entity.Property(e => e.NoMoi).HasColumnName("NoMoi");
                        
                            entity.Property(e => e.P41DTruong1).HasColumnName("P41DTruong1");
                        
                            entity.Property(e => e.P41DTruong2).HasColumnName("P41DTruong2");
                        
                            entity.Property(e => e.P41NTruong1).HasColumnName("P41NTruong1");
                        
                            entity.Property(e => e.P41NTruong2).HasColumnName("P41NTruong2");
                        
                            entity.Property(e => e.P41STruong1).HasColumnName("P41STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P41STruong2).HasColumnName("P41STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.QToanPVC).HasColumnName("QToanPVC");
                        
                            entity.Property(e => e.RecBOL).HasColumnName("RecBOL").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(50);
                        
                            entity.Property(e => e.RecLDX).HasColumnName("RecLDX").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLOT).HasColumnName("RecLOT").HasMaxLength(100);
                        
                            entity.Property(e => e.RecSTK).HasColumnName("RecSTK").HasMaxLength(100);
                        
                            entity.Property(e => e.RecXL).HasColumnName("RecXL").HasMaxLength(50);
                        
                            entity.Property(e => e.RecZKy).HasColumnName("RecZKy").HasMaxLength(100);
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(50);
                        
                            entity.Property(e => e.SoCont).HasColumnName("SoCont").HasMaxLength(50);
                        
                            entity.Property(e => e.SoConts).HasColumnName("SoConts").HasMaxLength(-1);
                        
                            entity.Property(e => e.SoHoaDon).HasColumnName("SoHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.SoLDX).HasColumnName("SoLDX").HasMaxLength(50);
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(50);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(30);
                        
                            entity.Property(e => e.SoPhieuCD).HasColumnName("SoPhieuCD").HasMaxLength(50);
                        
                            entity.Property(e => e.SoToKhai).HasColumnName("SoToKhai").HasMaxLength(50);
                        
                            entity.Property(e => e.TenDT).HasColumnName("TenDT").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTKNH).HasColumnName("TenTKNH").HasMaxLength(250);
                        
                            entity.Property(e => e.ThamChieu).HasColumnName("ThamChieu").HasMaxLength(250);
                        
                            entity.Property(e => e.TienLai).HasColumnName("TienLai");
                        
                            entity.Property(e => e.TienLaiNoCu).HasColumnName("TienLaiNoCu");
                        
                            entity.Property(e => e.TienLaiNoMoi).HasColumnName("TienLaiNoMoi");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TinhTrang).HasColumnName("TinhTrang").HasMaxLength(50);
                        
                            entity.Property(e => e.TrenSo).HasColumnName("TrenSo").HasMaxLength(100);
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(50);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(50);
                        
                            entity.Property(e => e.VaoRecy).HasColumnName("VaoRecy");
                        
                    });
                    
                    modelBuilder.Entity<P42_CHI_TIET_TH>(entity =>
                    {
                        entity.HasKey(e => e.IDP42);
                        entity.ToTable("P42 CHI TIET TH");
                        
                            entity.Property(e => e.CPhiMua).HasColumnName("CPhiMua");
                        
                            entity.Property(e => e.CTTRUNG).HasColumnName("CTTRUNG");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(255);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(255);
                        
                            entity.Property(e => e.DonHangSo).HasColumnName("DonHangSo").HasMaxLength(100);
                        
                            entity.Property(e => e.DTTHChiPhi).HasColumnName("DTTHChiPhi").HasMaxLength(150);
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GiaChuaThue).HasColumnName("GiaChuaThue");
                        
                            entity.Property(e => e.GiaMua).HasColumnName("GiaMua");
                        
                            entity.Property(e => e.GiaThanhToan).HasColumnName("GiaThanhToan");
                        
                            entity.Property(e => e.GTCLChenhLech).HasColumnName("GTCLChenhLech");
                        
                            entity.Property(e => e.GTCLSauDC).HasColumnName("GTCLSauDC");
                        
                            entity.Property(e => e.GTCLTruocDC).HasColumnName("GTCLTruocDC");
                        
                            entity.Property(e => e.GTKHChenhLech).HasColumnName("GTKHChenhLech");
                        
                            entity.Property(e => e.GTKHSauDC).HasColumnName("GTKHSauDC");
                        
                            entity.Property(e => e.GTKHThangSauDC).HasColumnName("GTKHThangSauDC");
                        
                            entity.Property(e => e.GTKHThangTLSDC).HasColumnName("GTKHThangTLSDC");
                        
                            entity.Property(e => e.GTKHTKDGL).HasColumnName("GTKHTKDGL");
                        
                            entity.Property(e => e.GTKHTruocDC).HasColumnName("GTKHTruocDC");
                        
                            entity.Property(e => e.HMLKChenhLech).HasColumnName("HMLKChenhLech");
                        
                            entity.Property(e => e.HMLKSauDC).HasColumnName("HMLKSauDC");
                        
                            entity.Property(e => e.HMLKTKChiPhi).HasColumnName("HMLKTKChiPhi");
                        
                            entity.Property(e => e.HMLKTruocDC).HasColumnName("HMLKTruocDC");
                        
                            entity.Property(e => e.HopDong).HasColumnName("HopDong").HasMaxLength(250);
                        
                            entity.Property(e => e.IDP42).HasColumnName("IDP42");
                        
                            entity.Property(e => e.LoaiCP).HasColumnName("LoaiCP").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCP).HasColumnName("MaCP").HasMaxLength(150);
                        
                            entity.Property(e => e.MaCTLQ).HasColumnName("MaCTLQ").HasMaxLength(10);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MaKHCo).HasColumnName("MaKHCo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKHNo).HasColumnName("MaKHNo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVu).HasColumnName("MaNVu").HasMaxLength(50);
                        
                            entity.Property(e => e.MaThongKe).HasColumnName("MaThongKe").HasMaxLength(150);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTKCo).HasColumnName("MaTKCo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKNo).HasColumnName("MaTKNo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTS).HasColumnName("MaTS").HasMaxLength(100);
                        
                            entity.Property(e => e.MucChi).HasColumnName("MucChi").HasMaxLength(150);
                        
                            entity.Property(e => e.NgayHD).HasColumnName("NgayHD").HasMaxLength(20);
                        
                            entity.Property(e => e.NgayHoaDon).HasColumnName("NgayHoaDon");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.P42CKTruong1).HasColumnName("P42CKTruong1");
                        
                            entity.Property(e => e.P42CKTruong2).HasColumnName("P42CKTruong2");
                        
                            entity.Property(e => e.P42DTruong1).HasColumnName("P42DTruong1");
                        
                            entity.Property(e => e.P42DTruong2).HasColumnName("P42DTruong2");
                        
                            entity.Property(e => e.P42DTruong3).HasColumnName("P42DTruong3");
                        
                            entity.Property(e => e.P42DTruong4).HasColumnName("P42DTruong4");
                        
                            entity.Property(e => e.P42NTruong1).HasColumnName("P42NTruong1");
                        
                            entity.Property(e => e.P42NTruong10).HasColumnName("P42NTruong10");
                        
                            entity.Property(e => e.P42NTruong2).HasColumnName("P42NTruong2");
                        
                            entity.Property(e => e.P42NTruong3).HasColumnName("P42NTruong3");
                        
                            entity.Property(e => e.P42NTruong4).HasColumnName("P42NTruong4");
                        
                            entity.Property(e => e.P42NTruong5).HasColumnName("P42NTruong5");
                        
                            entity.Property(e => e.P42NTruong6).HasColumnName("P42NTruong6");
                        
                            entity.Property(e => e.P42NTruong7).HasColumnName("P42NTruong7");
                        
                            entity.Property(e => e.P42NTruong8).HasColumnName("P42NTruong8");
                        
                            entity.Property(e => e.P42NTruong9).HasColumnName("P42NTruong9");
                        
                            entity.Property(e => e.P42STruong1).HasColumnName("P42STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P42STruong10).HasColumnName("P42STruong10").HasMaxLength(250);
                        
                            entity.Property(e => e.P42STruong2).HasColumnName("P42STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P42STruong3).HasColumnName("P42STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P42STruong4).HasColumnName("P42STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.P42STruong5).HasColumnName("P42STruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.P42STruong6).HasColumnName("P42STruong6").HasMaxLength(250);
                        
                            entity.Property(e => e.P42STruong7).HasColumnName("P42STruong7").HasMaxLength(250);
                        
                            entity.Property(e => e.P42STruong8).HasColumnName("P42STruong8").HasMaxLength(250);
                        
                            entity.Property(e => e.P42STruong9).HasColumnName("P42STruong9").HasMaxLength(250);
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(100);
                        
                            entity.Property(e => e.Q1).HasColumnName("Q1");
                        
                            entity.Property(e => e.Q2).HasColumnName("Q2");
                        
                            entity.Property(e => e.Q3).HasColumnName("Q3");
                        
                            entity.Property(e => e.Q4).HasColumnName("Q4");
                        
                            entity.Property(e => e.RecBOB).HasColumnName("RecBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.RecDHS).HasColumnName("RecDHS").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLDX).HasColumnName("RecLDX").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLOT).HasColumnName("RecLOT").HasMaxLength(100);
                        
                            entity.Property(e => e.RecSTK).HasColumnName("RecSTK").HasMaxLength(100);
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(50);
                        
                            entity.Property(e => e.SoCont).HasColumnName("SoCont").HasMaxLength(50);
                        
                            entity.Property(e => e.SoCTLQ).HasColumnName("SoCTLQ").HasMaxLength(50);
                        
                            entity.Property(e => e.SoDuCoNgoaiTe).HasColumnName("SoDuCoNgoaiTe");
                        
                            entity.Property(e => e.SoDuCoTienVND).HasColumnName("SoDuCoTienVND");
                        
                            entity.Property(e => e.SoDuNoNgoaiTe).HasColumnName("SoDuNoNgoaiTe");
                        
                            entity.Property(e => e.SoDuNoTienVND).HasColumnName("SoDuNoTienVND");
                        
                            entity.Property(e => e.SoHoaDon).HasColumnName("SoHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.SoKheUoc).HasColumnName("SoKheUoc").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLDX).HasColumnName("SoLDX").HasMaxLength(50);
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(50);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoTienPBKy).HasColumnName("SoTienPBKy");
                        
                            entity.Property(e => e.SoTienQTCL).HasColumnName("SoTienQTCL");
                        
                            entity.Property(e => e.SoTienTUCL).HasColumnName("SoTienTUCL");
                        
                            entity.Property(e => e.SoToKhai).HasColumnName("SoToKhai").HasMaxLength(50);
                        
                            entity.Property(e => e.T1).HasColumnName("T1");
                        
                            entity.Property(e => e.T10).HasColumnName("T10");
                        
                            entity.Property(e => e.T11).HasColumnName("T11");
                        
                            entity.Property(e => e.T12).HasColumnName("T12");
                        
                            entity.Property(e => e.T2).HasColumnName("T2");
                        
                            entity.Property(e => e.T3).HasColumnName("T3");
                        
                            entity.Property(e => e.T4).HasColumnName("T4");
                        
                            entity.Property(e => e.T5).HasColumnName("T5");
                        
                            entity.Property(e => e.T6).HasColumnName("T6");
                        
                            entity.Property(e => e.T7).HasColumnName("T7");
                        
                            entity.Property(e => e.T8).HasColumnName("T8");
                        
                            entity.Property(e => e.T9).HasColumnName("T9");
                        
                            entity.Property(e => e.TenNganHang).HasColumnName("TenNganHang").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenTS).HasColumnName("TenTS").HasMaxLength(250);
                        
                            entity.Property(e => e.TGCLChenhLech).HasColumnName("TGCLChenhLech");
                        
                            entity.Property(e => e.TGCLSauDC).HasColumnName("TGCLSauDC");
                        
                            entity.Property(e => e.TGCLTruocDC).HasColumnName("TGCLTruocDC");
                        
                            entity.Property(e => e.ThanhTien).HasColumnName("ThanhTien");
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TienTamUng).HasColumnName("TienTamUng");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyGiaCuoiKy).HasColumnName("TyGiaCuoiKy");
                        
                            entity.Property(e => e.TyLeQTCL).HasColumnName("TyLeQTCL");
                        
                            entity.Property(e => e.TyLeTUCL).HasColumnName("TyLeTUCL");
                        
                    });
                    
                    modelBuilder.Entity<P43_CHI_TIET_TS>(entity =>
                    {
                        entity.HasKey(e => e.IDP43);
                        entity.ToTable("P43 CHI TIET TS");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(255);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(255);
                        
                            entity.Property(e => e.GiaTriKHThang).HasColumnName("GiaTriKHThang").HasMaxLength(50);
                        
                            entity.Property(e => e.GiaTriTinhKH).HasColumnName("GiaTriTinhKH");
                        
                            entity.Property(e => e.IDP43).HasColumnName("IDP43");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKCo).HasColumnName("MaTKCo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKNo).HasColumnName("MaTKNo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTS).HasColumnName("MaTS").HasMaxLength(100);
                        
                            entity.Property(e => e.NguyenGia).HasColumnName("NguyenGia");
                        
                            entity.Property(e => e.NoiDat).HasColumnName("NoiDat").HasMaxLength(150);
                        
                            entity.Property(e => e.P43CKTruong1).HasColumnName("P43CKTruong1");
                        
                            entity.Property(e => e.P43CKTruong2).HasColumnName("P43CKTruong2");
                        
                            entity.Property(e => e.P43DTruong1).HasColumnName("P43DTruong1");
                        
                            entity.Property(e => e.P43DTruong2).HasColumnName("P43DTruong2");
                        
                            entity.Property(e => e.P43DTruong3).HasColumnName("P43DTruong3");
                        
                            entity.Property(e => e.P43DTruong4).HasColumnName("P43DTruong4");
                        
                            entity.Property(e => e.P43NTruong1).HasColumnName("P43NTruong1");
                        
                            entity.Property(e => e.P43NTruong2).HasColumnName("P43NTruong2");
                        
                            entity.Property(e => e.P43NTruong3).HasColumnName("P43NTruong3");
                        
                            entity.Property(e => e.P43NTruong4).HasColumnName("P43NTruong4");
                        
                            entity.Property(e => e.P43STruong1).HasColumnName("P43STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P43STruong2).HasColumnName("P43STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P43STruong3).HasColumnName("P43STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P43STruong4).HasColumnName("P43STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(3);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.SoKheUoc).HasColumnName("SoKheUoc").HasMaxLength(100);
                        
                            entity.Property(e => e.TenNganHang).HasColumnName("TenNganHang").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenTS).HasColumnName("TenTS").HasMaxLength(250);
                        
                            entity.Property(e => e.TyLeKHThang).HasColumnName("TyLeKHThang");
                        
                    });
                    
                    modelBuilder.Entity<P51_BANG_GIA>(entity =>
                    {
                        entity.HasKey(e => e.IDP51);
                        entity.ToTable("P51 BANG GIA");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CauHinhGia).HasColumnName("CauHinhGia");
                        
                            entity.Property(e => e.CongVaoGia).HasColumnName("CongVaoGia");
                        
                            entity.Property(e => e.DenGio).HasColumnName("DenGio");
                        
                            entity.Property(e => e.FieldChon).HasColumnName("FieldChon").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.HieuLucDen).HasColumnName("HieuLucDen");
                        
                            entity.Property(e => e.HieuLucTu).HasColumnName("HieuLucTu");
                        
                            entity.Property(e => e.IDP51).HasColumnName("IDP51");
                        
                            entity.Property(e => e.KeThuaTu).HasColumnName("KeThuaTu").HasMaxLength(50);
                        
                            entity.Property(e => e.KhongHienThi).HasColumnName("KhongHienThi");
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(10);
                        
                            entity.Property(e => e.LoaiTinhGia).HasColumnName("LoaiTinhGia").HasMaxLength(20);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(20);
                        
                            entity.Property(e => e.MaBangGia).HasColumnName("MaBangGia").HasMaxLength(20);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(60);
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.Reckey).HasColumnName("Reckey").HasMaxLength(30);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(30);
                        
                            entity.Property(e => e.SoTienApGia).HasColumnName("SoTienApGia");
                        
                            entity.Property(e => e.TaoCotGia).HasColumnName("TaoCotGia");
                        
                            entity.Property(e => e.TenBangGia).HasColumnName("TenBangGia").HasMaxLength(250);
                        
                            entity.Property(e => e.TenCotGia).HasColumnName("TenCotGia").HasMaxLength(100);
                        
                            entity.Property(e => e.TienCongThem).HasColumnName("TienCongThem");
                        
                            entity.Property(e => e.TinhTheo).HasColumnName("TinhTheo").HasMaxLength(20);
                        
                            entity.Property(e => e.TuGio).HasColumnName("TuGio");
                        
                            entity.Property(e => e.TyLeApGia).HasColumnName("TyLeApGia");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(30);
                        
                            entity.Property(e => e.VaoNgay).HasColumnName("VaoNgay").HasMaxLength(100);
                        
                            entity.Property(e => e.VaoThu).HasColumnName("VaoThu").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<P52_CHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.IDP52);
                        entity.ToTable("P52 CHI TIET");
                        
                            entity.Property(e => e.CBM_CBM01).HasColumnName("CBM_CBM01");
                        
                            entity.Property(e => e.CBM_CBM02).HasColumnName("CBM_CBM02");
                        
                            entity.Property(e => e.CBM_CBM04).HasColumnName("CBM_CBM04");
                        
                            entity.Property(e => e.CBM_CBM05).HasColumnName("CBM_CBM05");
                        
                            entity.Property(e => e.CBM_CBM06).HasColumnName("CBM_CBM06");
                        
                            entity.Property(e => e.CBM_CBM07).HasColumnName("CBM_CBM07");
                        
                            entity.Property(e => e.CBM_CBM08).HasColumnName("CBM_CBM08");
                        
                            entity.Property(e => e.CBM_CBM10).HasColumnName("CBM_CBM10");
                        
                            entity.Property(e => e.CBM_CMB03).HasColumnName("CBM_CMB03");
                        
                            entity.Property(e => e.CBM_CMB06).HasColumnName("CBM_CMB06");
                        
                            entity.Property(e => e.ChuongTrinhKM).HasColumnName("ChuongTrinhKM").HasMaxLength(250);
                        
                            entity.Property(e => e.CTNoiGiao).HasColumnName("CTNoiGiao").HasMaxLength(-1);
                        
                            entity.Property(e => e.CTNoiLay).HasColumnName("CTNoiLay").HasMaxLength(-1);
                        
                            entity.Property(e => e.CuocVCHC20CT).HasColumnName("CuocVCHC20CT");
                        
                            entity.Property(e => e.CuocVCHC20NX).HasColumnName("CuocVCHC20NX");
                        
                            entity.Property(e => e.CuocVCHC20OTCT).HasColumnName("CuocVCHC20OTCT");
                        
                            entity.Property(e => e.CuocVCHC20OTNX).HasColumnName("CuocVCHC20OTNX");
                        
                            entity.Property(e => e.CuocVCHC20RFCT).HasColumnName("CuocVCHC20RFCT");
                        
                            entity.Property(e => e.CuocVCHC20RFNX).HasColumnName("CuocVCHC20RFNX");
                        
                            entity.Property(e => e.CuocVCHC40CT).HasColumnName("CuocVCHC40CT");
                        
                            entity.Property(e => e.CuocVCHC40NX).HasColumnName("CuocVCHC40NX");
                        
                            entity.Property(e => e.CuocVCHC40OTCT).HasColumnName("CuocVCHC40OTCT");
                        
                            entity.Property(e => e.CuocVCHC40OTNX).HasColumnName("CuocVCHC40OTNX");
                        
                            entity.Property(e => e.CuocVCHC40RFCT).HasColumnName("CuocVCHC40RFCT");
                        
                            entity.Property(e => e.CuocVCHC40RFNX).HasColumnName("CuocVCHC40RFNX");
                        
                            entity.Property(e => e.CuocVCHC45CT).HasColumnName("CuocVCHC45CT");
                        
                            entity.Property(e => e.CuocVCHC45NX).HasColumnName("CuocVCHC45NX");
                        
                            entity.Property(e => e.CuocVCHC45OTCT).HasColumnName("CuocVCHC45OTCT");
                        
                            entity.Property(e => e.CuocVCHC45OTNX).HasColumnName("CuocVCHC45OTNX");
                        
                            entity.Property(e => e.CuocVCHC45RFCT).HasColumnName("CuocVCHC45RFCT");
                        
                            entity.Property(e => e.CuocVCHC45RFNX).HasColumnName("CuocVCHC45RFNX");
                        
                            entity.Property(e => e.CuocVCHCCT).HasColumnName("CuocVCHCCT");
                        
                            entity.Property(e => e.CuocVCHCNX).HasColumnName("CuocVCHCNX");
                        
                            entity.Property(e => e.CuocVCHRCT).HasColumnName("CuocVCHRCT");
                        
                            entity.Property(e => e.CuocVCHRNX).HasColumnName("CuocVCHRNX");
                        
                            entity.Property(e => e.DacDiem).HasColumnName("DacDiem").HasMaxLength(250);
                        
                            entity.Property(e => e.DenGiaTri).HasColumnName("DenGiaTri");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.DVTHangTang).HasColumnName("DVTHangTang").HasMaxLength(50);
                        
                            entity.Property(e => e.GiaBanDM).HasColumnName("GiaBanDM");
                        
                            entity.Property(e => e.GiaBanKH).HasColumnName("GiaBanKH");
                        
                            entity.Property(e => e.GiaBanMD).HasColumnName("GiaBanMD");
                        
                            entity.Property(e => e.GiaCauHinh).HasColumnName("GiaCauHinh");
                        
                            entity.Property(e => e.GiaGio).HasColumnName("GiaGio");
                        
                            entity.Property(e => e.GiaKhac).HasColumnName("GiaKhac");
                        
                            entity.Property(e => e.GiaKhac2).HasColumnName("GiaKhac2");
                        
                            entity.Property(e => e.GiaLeVND).HasColumnName("GiaLeVND");
                        
                            entity.Property(e => e.GiaLeVNDVAT).HasColumnName("GiaLeVNDVAT");
                        
                            entity.Property(e => e.GiaMua).HasColumnName("GiaMua");
                        
                            entity.Property(e => e.GiaNgay).HasColumnName("GiaNgay");
                        
                            entity.Property(e => e.GiaNTe1).HasColumnName("GiaNTe1");
                        
                            entity.Property(e => e.GiaNTe2).HasColumnName("GiaNTe2");
                        
                            entity.Property(e => e.GiaSiVND).HasColumnName("GiaSiVND");
                        
                            entity.Property(e => e.GiaSiVNDVAT).HasColumnName("GiaSiVNDVAT");
                        
                            entity.Property(e => e.GiaThang).HasColumnName("GiaThang");
                        
                            entity.Property(e => e.GiaUSD).HasColumnName("GiaUSD");
                        
                            entity.Property(e => e.GiaVon).HasColumnName("GiaVon");
                        
                            entity.Property(e => e.Hang1Loai).HasColumnName("Hang1Loai");
                        
                            entity.Property(e => e.HangGhep).HasColumnName("HangGhep");
                        
                            entity.Property(e => e.HangKem).HasColumnName("HangKem");
                        
                            entity.Property(e => e.HangTang).HasColumnName("HangTang");
                        
                            entity.Property(e => e.IDP52).HasColumnName("IDP52");
                        
                            entity.Property(e => e.KhongTai).HasColumnName("KhongTai");
                        
                            entity.Property(e => e.KhuVuc).HasColumnName("KhuVuc").HasMaxLength(250);
                        
                            entity.Property(e => e.KhuyenMai).HasColumnName("KhuyenMai");
                        
                            entity.Property(e => e.LaiKyVong).HasColumnName("LaiKyVong");
                        
                            entity.Property(e => e.LoaiGia).HasColumnName("LoaiGia").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiKM).HasColumnName("LoaiKM").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiPhong).HasColumnName("LoaiPhong").HasMaxLength(250);
                        
                            entity.Property(e => e.LuongTXVC).HasColumnName("LuongTXVC");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaHangTang).HasColumnName("MaHangTang").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKM).HasColumnName("MaKM").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(10);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayApGia).HasColumnName("NgayApGia");
                        
                            entity.Property(e => e.NgayHetHan).HasColumnName("NgayHetHan");
                        
                            entity.Property(e => e.NghanhHang).HasColumnName("NghanhHang").HasMaxLength(100);
                        
                            entity.Property(e => e.NgoaiTeCK).HasColumnName("NgoaiTeCK");
                        
                            entity.Property(e => e.NhomKH).HasColumnName("NhomKH").HasMaxLength(100);
                        
                            entity.Property(e => e.NhomKM).HasColumnName("NhomKM").HasMaxLength(100);
                        
                            entity.Property(e => e.NhomVT).HasColumnName("NhomVT").HasMaxLength(100);
                        
                            entity.Property(e => e.NoiGiao).HasColumnName("NoiGiao").HasMaxLength(-1);
                        
                            entity.Property(e => e.NoiLay).HasColumnName("NoiLay").HasMaxLength(-1);
                        
                            entity.Property(e => e.P52CKTruong1).HasColumnName("P52CKTruong1");
                        
                            entity.Property(e => e.P52CKTruong2).HasColumnName("P52CKTruong2");
                        
                            entity.Property(e => e.PhongSo).HasColumnName("PhongSo").HasMaxLength(150);
                        
                            entity.Property(e => e.PhuCapTN).HasColumnName("PhuCapTN");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.ReckeyP52).HasColumnName("ReckeyP52").HasMaxLength(30);
                        
                            entity.Property(e => e.RecNoiGiao).HasColumnName("RecNoiGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.RecNoiLay).HasColumnName("RecNoiLay").HasMaxLength(100);
                        
                            entity.Property(e => e.RecTuyen).HasColumnName("RecTuyen").HasMaxLength(100);
                        
                            entity.Property(e => e.SLDinhMuc).HasColumnName("SLDinhMuc");
                        
                            entity.Property(e => e.SLKhongChe).HasColumnName("SLKhongChe");
                        
                            entity.Property(e => e.SLQuyDinh).HasColumnName("SLQuyDinh");
                        
                            entity.Property(e => e.SoTienApGia).HasColumnName("SoTienApGia");
                        
                            entity.Property(e => e.STKhongChe).HasColumnName("STKhongChe");
                        
                            entity.Property(e => e.STT).HasColumnName("STT").HasMaxLength(10);
                        
                            entity.Property(e => e.TenHangTang).HasColumnName("TenHangTang").HasMaxLength(250);
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(250);
                        
                            entity.Property(e => e.TienDoiCont).HasColumnName("TienDoiCont");
                        
                            entity.Property(e => e.TienDuongHC).HasColumnName("TienDuongHC");
                        
                            entity.Property(e => e.TienDuongHR).HasColumnName("TienDuongHR");
                        
                            entity.Property(e => e.TienVNDCK).HasColumnName("TienVNDCK");
                        
                            entity.Property(e => e.TLSLKhongChe).HasColumnName("TLSLKhongChe");
                        
                            entity.Property(e => e.TLSTKhongChe).HasColumnName("TLSTKhongChe");
                        
                            entity.Property(e => e.TonCK_DG).HasColumnName("TonCK_DG");
                        
                            entity.Property(e => e.TonCK_SL).HasColumnName("TonCK_SL");
                        
                            entity.Property(e => e.TonCK_ST).HasColumnName("TonCK_ST");
                        
                            entity.Property(e => e.TongChiPhi).HasColumnName("TongChiPhi");
                        
                            entity.Property(e => e.TuGiaTri).HasColumnName("TuGiaTri");
                        
                            entity.Property(e => e.TuyenDuong).HasColumnName("TuyenDuong").HasMaxLength(100);
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyLeApGia).HasColumnName("TyLeApGia");
                        
                            entity.Property(e => e.TyLeCK).HasColumnName("TyLeCK");
                        
                            entity.Property(e => e.TyLeCP).HasColumnName("TyLeCP");
                        
                    });
                    
                    modelBuilder.Entity<P52Detail_ChiTiet>(entity =>
                    {
                        entity.HasKey(e => e.Id);
                        entity.ToTable("P52Detail_ChiTiet");
                        
                            entity.Property(e => e.Dvt).HasColumnName("Dvt").HasMaxLength(50);
                        
                            entity.Property(e => e.GiaCuoc).HasColumnName("GiaCuoc");
                        
                            entity.Property(e => e.GiaCuoc_USD).HasColumnName("GiaCuoc_USD");
                        
                            entity.Property(e => e.Id).HasColumnName("Id");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.Reckey).HasColumnName("Reckey").HasMaxLength(30);
                        
                            entity.Property(e => e.RecKeyP52).HasColumnName("RecKeyP52").HasMaxLength(30);
                        
                    });
                    
                    modelBuilder.Entity<P53_DIEU_KIEN>(entity =>
                    {
                        entity.HasKey(e => e.IDP53);
                        entity.ToTable("P53 DIEU KIEN");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDP53).HasColumnName("IDP53").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiDieuKien).HasColumnName("LoaiDieuKien").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKH1).HasColumnName("MaKH1").HasMaxLength(30);
                        
                            entity.Property(e => e.MaKH2).HasColumnName("MaKH2").HasMaxLength(30);
                        
                            entity.Property(e => e.NoiDung).HasColumnName("NoiDung").HasMaxLength(250);
                        
                            entity.Property(e => e.Reckey).HasColumnName("Reckey").HasMaxLength(30);
                        
                            entity.Property(e => e.TyLe).HasColumnName("TyLe");
                        
                    });
                    
                    //Unable to generate entity type for table 'dbo.P61 DAT PHONG'. table have no primary key
                    
                    modelBuilder.Entity<P71_DINH_MUC>(entity =>
                    {
                        entity.HasKey(e => e.RECKEY);
                        entity.ToTable("P71 DINH MUC");
                        
                            entity.Property(e => e.DenNgay).HasColumnName("DenNgay");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.HopDong).HasColumnName("HopDong").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(10);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDM).HasColumnName("MaDM").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(50);
                        
                            entity.Property(e => e.MaKho2).HasColumnName("MaKho2").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNvien).HasColumnName("MaNvien").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTP).HasColumnName("MaTP").HasMaxLength(50);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(30);
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.NgungTheoDoi).HasColumnName("NgungTheoDoi");
                        
                            entity.Property(e => e.P71CKTruong1).HasColumnName("P71CKTruong1");
                        
                            entity.Property(e => e.P71CKTruong2).HasColumnName("P71CKTruong2");
                        
                            entity.Property(e => e.P71DTruong1).HasColumnName("P71DTruong1");
                        
                            entity.Property(e => e.P71DTruong2).HasColumnName("P71DTruong2");
                        
                            entity.Property(e => e.P71DTruong3).HasColumnName("P71DTruong3");
                        
                            entity.Property(e => e.P71DTruong4).HasColumnName("P71DTruong4");
                        
                            entity.Property(e => e.P71NTruong1).HasColumnName("P71NTruong1");
                        
                            entity.Property(e => e.P71NTruong2).HasColumnName("P71NTruong2");
                        
                            entity.Property(e => e.P71NTruong3).HasColumnName("P71NTruong3");
                        
                            entity.Property(e => e.P71NTruong4).HasColumnName("P71NTruong4");
                        
                            entity.Property(e => e.P71STruong1).HasColumnName("P71STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P71STruong2).HasColumnName("P71STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P71STruong3).HasColumnName("P71STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P71STruong4).HasColumnName("P71STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.TenDM).HasColumnName("TenDM").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTP).HasColumnName("TenTP").HasMaxLength(250);
                        
                            entity.Property(e => e.TuNgay).HasColumnName("TuNgay");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(30);
                        
                    });
                    
                    modelBuilder.Entity<P72_CHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.IDP72);
                        entity.ToTable("P72 CHI TIET");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DonViChuyenDoi).HasColumnName("DonViChuyenDoi");
                        
                            entity.Property(e => e.DTTHCP).HasColumnName("DTTHCP").HasMaxLength(100);
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(20);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDP71).HasColumnName("IDP71");
                        
                            entity.Property(e => e.IDP72).HasColumnName("IDP72");
                        
                            entity.Property(e => e.MaCD).HasColumnName("MaCD").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKhoNVL).HasColumnName("MaKhoNVL").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKhoTP).HasColumnName("MaKhoTP").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVL).HasColumnName("MaNVL").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTP).HasColumnName("MaTP").HasMaxLength(100);
                        
                            entity.Property(e => e.PhanBo).HasColumnName("PhanBo");
                        
                            entity.Property(e => e.PhanBo1).HasColumnName("PhanBo1");
                        
                            entity.Property(e => e.PhanBo10).HasColumnName("PhanBo10");
                        
                            entity.Property(e => e.PhanBo2).HasColumnName("PhanBo2");
                        
                            entity.Property(e => e.PhanBo3).HasColumnName("PhanBo3");
                        
                            entity.Property(e => e.PhanBo4).HasColumnName("PhanBo4");
                        
                            entity.Property(e => e.PhanBo5).HasColumnName("PhanBo5");
                        
                            entity.Property(e => e.PhanBo6).HasColumnName("PhanBo6");
                        
                            entity.Property(e => e.PhanBo7).HasColumnName("PhanBo7");
                        
                            entity.Property(e => e.PhanBo8).HasColumnName("PhanBo8");
                        
                            entity.Property(e => e.PhanBo9).HasColumnName("PhanBo9");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoLuongChuyenDoi).HasColumnName("SoLuongChuyenDoi");
                        
                            entity.Property(e => e.STT).HasColumnName("STT").HasMaxLength(10);
                        
                            entity.Property(e => e.TenNVL).HasColumnName("TenNVL").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTP).HasColumnName("TenTP").HasMaxLength(250);
                        
                            entity.Property(e => e.TongPhanBo1).HasColumnName("TongPhanBo1");
                        
                            entity.Property(e => e.TongPhanBo2).HasColumnName("TongPhanBo2");
                        
                            entity.Property(e => e.TongPhanBo3).HasColumnName("TongPhanBo3");
                        
                            entity.Property(e => e.TongPhanBo4).HasColumnName("TongPhanBo4");
                        
                            entity.Property(e => e.TongPhanBo5).HasColumnName("TongPhanBo5");
                        
                            entity.Property(e => e.TongPhanBo6).HasColumnName("TongPhanBo6");
                        
                            entity.Property(e => e.TongPhanBo7).HasColumnName("TongPhanBo7");
                        
                            entity.Property(e => e.TongPhanBo8).HasColumnName("TongPhanBo8");
                        
                            entity.Property(e => e.TongPhanBo9).HasColumnName("TongPhanBo9");
                        
                            entity.Property(e => e.TyLeChuyenDoi).HasColumnName("TyLeChuyenDoi");
                        
                    });
                    
                    modelBuilder.Entity<P73_DINH_MUC_SX>(entity =>
                    {
                        entity.HasKey(e => e.IDDM);
                        entity.ToTable("P73 DINH MUC SX");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CongSoTien).HasColumnName("CongSoTien");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.IDDM).HasColumnName("IDDM");
                        
                            entity.Property(e => e.LoaiCT).HasColumnName("LoaiCT").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiGT).HasColumnName("LoaiGT").HasMaxLength(150);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDTTHCP).HasColumnName("MaDTTHCP").HasMaxLength(150);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTP).HasColumnName("MaTP").HasMaxLength(150);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.P73CKTruong1).HasColumnName("P73CKTruong1");
                        
                            entity.Property(e => e.P73CKTruong2).HasColumnName("P73CKTruong2");
                        
                            entity.Property(e => e.P73CKTruong3).HasColumnName("P73CKTruong3");
                        
                            entity.Property(e => e.P73DTruong1).HasColumnName("P73DTruong1");
                        
                            entity.Property(e => e.P73DTruong2).HasColumnName("P73DTruong2");
                        
                            entity.Property(e => e.P73DTruong3).HasColumnName("P73DTruong3");
                        
                            entity.Property(e => e.P73NTruong1).HasColumnName("P73NTruong1");
                        
                            entity.Property(e => e.P73NTruong2).HasColumnName("P73NTruong2");
                        
                            entity.Property(e => e.P73NTruong3).HasColumnName("P73NTruong3");
                        
                            entity.Property(e => e.P73NTruong4).HasColumnName("P73NTruong4");
                        
                            entity.Property(e => e.P73NTruong5).HasColumnName("P73NTruong5");
                        
                            entity.Property(e => e.P73STruong1).HasColumnName("P73STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P73STruong2).HasColumnName("P73STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P73STruong3).HasColumnName("P73STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P73STruong4).HasColumnName("P73STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.P73STruong5).HasColumnName("P73STruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenDTTHCP).HasColumnName("TenDTTHCP").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDTTHCP2).HasColumnName("TenDTTHCP2").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTP).HasColumnName("TenTP").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTP2).HasColumnName("TenTP2").HasMaxLength(250);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<P73_TINH_GIA_THANH>(entity =>
                    {
                        entity.HasKey(e => e.IDP73);
                        entity.ToTable("P73 TINH GIA THANH");
                        
                            entity.Property(e => e.CPSXChungCKy).HasColumnName("CPSXChungCKy");
                        
                            entity.Property(e => e.CPSXChungDKy).HasColumnName("CPSXChungDKy");
                        
                            entity.Property(e => e.CPSXChungPB).HasColumnName("CPSXChungPB");
                        
                            entity.Property(e => e.CPSXChungTT).HasColumnName("CPSXChungTT");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.GiaThanhDonVi).HasColumnName("GiaThanhDonVi");
                        
                            entity.Property(e => e.IDP71).HasColumnName("IDP71");
                        
                            entity.Property(e => e.IDP73).HasColumnName("IDP73");
                        
                            entity.Property(e => e.Khác).HasColumnName("Khác");
                        
                            entity.Property(e => e.KhauHaoCKy).HasColumnName("KhauHaoCKy");
                        
                            entity.Property(e => e.KhauHaoDKy).HasColumnName("KhauHaoDKy");
                        
                            entity.Property(e => e.KhauHaoPhanBo).HasColumnName("KhauHaoPhanBo");
                        
                            entity.Property(e => e.KhauHaoTT).HasColumnName("KhauHaoTT");
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCD).HasColumnName("MaCD").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(50);
                        
                            entity.Property(e => e.MayThiCongCKy).HasColumnName("MayThiCongCKy");
                        
                            entity.Property(e => e.MayThiCongDKy).HasColumnName("MayThiCongDKy");
                        
                            entity.Property(e => e.MayThiCongPBo).HasColumnName("MayThiCongPBo");
                        
                            entity.Property(e => e.MayThiCongTT).HasColumnName("MayThiCongTT");
                        
                            entity.Property(e => e.NhanCongCKy).HasColumnName("NhanCongCKy");
                        
                            entity.Property(e => e.NhanCongDKy).HasColumnName("NhanCongDKy");
                        
                            entity.Property(e => e.NhanCongPhanBo).HasColumnName("NhanCongPhanBo");
                        
                            entity.Property(e => e.NhanCongTT).HasColumnName("NhanCongTT");
                        
                            entity.Property(e => e.PhanTramHoanThanhCKy).HasColumnName("PhanTramHoanThanhCKy");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.SLHoanThanhCKy).HasColumnName("SLHoanThanhCKy");
                        
                            entity.Property(e => e.SLSanPhamDDCKy).HasColumnName("SLSanPhamDDCKy");
                        
                            entity.Property(e => e.SLSanPhamDDDKy).HasColumnName("SLSanPhamDDDKy");
                        
                            entity.Property(e => e.SLXuatKhac).HasColumnName("SLXuatKhac");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.STXuatKhac).HasColumnName("STXuatKhac");
                        
                            entity.Property(e => e.TieuThucPhanBo).HasColumnName("TieuThucPhanBo").HasMaxLength(250);
                        
                            entity.Property(e => e.TongGiaThanh).HasColumnName("TongGiaThanh");
                        
                            entity.Property(e => e.VLChinhCKy).HasColumnName("VLChinhCKy");
                        
                            entity.Property(e => e.VLChinhDKy).HasColumnName("VLChinhDKy");
                        
                            entity.Property(e => e.VLChinhPhanBo).HasColumnName("VLChinhPhanBo");
                        
                            entity.Property(e => e.VLChinhTT).HasColumnName("VLChinhTT");
                        
                            entity.Property(e => e.VLPhuCuoiKy).HasColumnName("VLPhuCuoiKy");
                        
                            entity.Property(e => e.VLPhuDKy).HasColumnName("VLPhuDKy");
                        
                            entity.Property(e => e.VLPhuPhanBo).HasColumnName("VLPhuPhanBo");
                        
                            entity.Property(e => e.VLPhuTT).HasColumnName("VLPhuTT");
                        
                    });
                    
                    modelBuilder.Entity<P74_CONG_DOAN_SX>(entity =>
                    {
                        entity.HasKey(e => e.IDCD);
                        entity.ToTable("P74 CONG DOAN SX");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDCD).HasColumnName("IDCD");
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCD).HasColumnName("MaCD").HasMaxLength(150);
                        
                            entity.Property(e => e.MacDinh).HasColumnName("MacDinh");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.NhomCD).HasColumnName("NhomCD").HasMaxLength(150);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenCD).HasColumnName("TenCD").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<P75_KY_TINH_GT>(entity =>
                    {
                        entity.HasKey(e => e.IDKY);
                        entity.ToTable("P75 KY TINH GT");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.DenNgay).HasColumnName("DenNgay");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiaiKyGT).HasColumnName("DienGiaiKyGT").HasMaxLength(250);
                        
                            entity.Property(e => e.DoDangCK).HasColumnName("DoDangCK");
                        
                            entity.Property(e => e.DoDangDK).HasColumnName("DoDangDK");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDKY).HasColumnName("IDKY");
                        
                            entity.Property(e => e.KhoanGiamTru).HasColumnName("KhoanGiamTru");
                        
                            entity.Property(e => e.KyTinhGT).HasColumnName("KyTinhGT");
                        
                            entity.Property(e => e.LoaiGT).HasColumnName("LoaiGT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.PPTinhGT).HasColumnName("PPTinhGT").HasMaxLength(250);
                        
                            entity.Property(e => e.PSTrongKy).HasColumnName("PSTrongKy");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.TenKyGT).HasColumnName("TenKyGT").HasMaxLength(100);
                        
                            entity.Property(e => e.TenKyGT2).HasColumnName("TenKyGT2").HasMaxLength(100);
                        
                            entity.Property(e => e.TongGiaThanh).HasColumnName("TongGiaThanh");
                        
                            entity.Property(e => e.TuNgay).HasColumnName("TuNgay");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<P75_ZCHI_TIET_CP>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("P75 ZCHI TIET CP");
                        
                            entity.Property(e => e.CongSoTien).HasColumnName("CongSoTien");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DoDangCK).HasColumnName("DoDangCK");
                        
                            entity.Property(e => e.DoDangDK).HasColumnName("DoDangDK");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.KhoanGiamTru).HasColumnName("KhoanGiamTru");
                        
                            entity.Property(e => e.LoaiCT).HasColumnName("LoaiCT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDTTHCP).HasColumnName("MaDTTHCP").HasMaxLength(150);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(150);
                        
                            entity.Property(e => e.NghiemThu).HasColumnName("NghiemThu");
                        
                            entity.Property(e => e.P75ChonLoc).HasColumnName("P75ChonLoc");
                        
                            entity.Property(e => e.PSTrongKy).HasColumnName("PSTrongKy");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenDTTHCP).HasColumnName("TenDTTHCP").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDTTHCP2).HasColumnName("TenDTTHCP2").HasMaxLength(250);
                        
                            entity.Property(e => e.TongGiaThanh).HasColumnName("TongGiaThanh");
                        
                    });
                    
                    modelBuilder.Entity<P75_ZCHI_TIET_GT>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("P75 ZCHI TIET GT");
                        
                            entity.Property(e => e.CongSoTien).HasColumnName("CongSoTien");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.GiaThanh).HasColumnName("GiaThanh");
                        
                            entity.Property(e => e.GiaThanhDV).HasColumnName("GiaThanhDV");
                        
                            entity.Property(e => e.HeSo).HasColumnName("HeSo");
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.LoaiCT).HasColumnName("LoaiCT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaCD).HasColumnName("MaCD").HasMaxLength(150);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDTTHCP).HasColumnName("MaDTTHCP").HasMaxLength(150);
                        
                            entity.Property(e => e.MaTP).HasColumnName("MaTP").HasMaxLength(150);
                        
                            entity.Property(e => e.P75ChonLoc).HasColumnName("P75ChonLoc");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuongTP).HasColumnName("SoLuongTP");
                        
                            entity.Property(e => e.SoLuongTP2).HasColumnName("SoLuongTP2");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenTP).HasColumnName("TenTP").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTP2).HasColumnName("TenTP2").HasMaxLength(250);
                        
                            entity.Property(e => e.TieuChuanPB).HasColumnName("TieuChuanPB");
                        
                    });
                    
                    modelBuilder.Entity<P76_DT_TAP_HOP_CP>(entity =>
                    {
                        entity.HasKey(e => e.RECKEY);
                        entity.ToTable("P76 DT TAP HOP CP");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.GiaTriHD).HasColumnName("GiaTriHD");
                        
                            entity.Property(e => e.Loai).HasColumnName("Loai").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiGT).HasColumnName("LoaiGT").HasMaxLength(150);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDTTHCP).HasColumnName("MaDTTHCP").HasMaxLength(150);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(150);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayBD).HasColumnName("NgayBD");
                        
                            entity.Property(e => e.NgayKT).HasColumnName("NgayKT");
                        
                            entity.Property(e => e.NhomDT).HasColumnName("NhomDT").HasMaxLength(150);
                        
                            entity.Property(e => e.P76CKTruong1).HasColumnName("P76CKTruong1");
                        
                            entity.Property(e => e.P76CKTruong2).HasColumnName("P76CKTruong2");
                        
                            entity.Property(e => e.P76CKTruong3).HasColumnName("P76CKTruong3");
                        
                            entity.Property(e => e.P76DTruong1).HasColumnName("P76DTruong1");
                        
                            entity.Property(e => e.P76DTruong2).HasColumnName("P76DTruong2");
                        
                            entity.Property(e => e.P76DTruong3).HasColumnName("P76DTruong3");
                        
                            entity.Property(e => e.P76NTruong1).HasColumnName("P76NTruong1");
                        
                            entity.Property(e => e.P76NTruong2).HasColumnName("P76NTruong2");
                        
                            entity.Property(e => e.P76NTruong3).HasColumnName("P76NTruong3");
                        
                            entity.Property(e => e.P76NTruong4).HasColumnName("P76NTruong4");
                        
                            entity.Property(e => e.P76NTruong5).HasColumnName("P76NTruong5");
                        
                            entity.Property(e => e.P76STruong1).HasColumnName("P76STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P76STruong2).HasColumnName("P76STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P76STruong3).HasColumnName("P76STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P76STruong4).HasColumnName("P76STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.P76STruong5).HasColumnName("P76STruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.Root).HasColumnName("Root");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenDTTHCP).HasColumnName("TenDTTHCP").HasMaxLength(250);
                        
                            entity.Property(e => e.TenKH).HasColumnName("TenKH").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<P76_ZCHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.ID76);
                        entity.ToTable("P76 ZCHI TIET");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.ID76).HasColumnName("ID76");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTP).HasColumnName("MaTP").HasMaxLength(150);
                        
                            entity.Property(e => e.P76CTCKTruong1).HasColumnName("P76CTCKTruong1");
                        
                            entity.Property(e => e.P76CTCKTruong2).HasColumnName("P76CTCKTruong2");
                        
                            entity.Property(e => e.P76CTCKTruong3).HasColumnName("P76CTCKTruong3");
                        
                            entity.Property(e => e.P76CTDTruong1).HasColumnName("P76CTDTruong1");
                        
                            entity.Property(e => e.P76CTDTruong2).HasColumnName("P76CTDTruong2");
                        
                            entity.Property(e => e.P76CTDTruong3).HasColumnName("P76CTDTruong3");
                        
                            entity.Property(e => e.P76CTNTruong1).HasColumnName("P76CTNTruong1");
                        
                            entity.Property(e => e.P76CTNTruong2).HasColumnName("P76CTNTruong2");
                        
                            entity.Property(e => e.P76CTNTruong3).HasColumnName("P76CTNTruong3");
                        
                            entity.Property(e => e.P76CTNTruong4).HasColumnName("P76CTNTruong4");
                        
                            entity.Property(e => e.P76CTNTruong5).HasColumnName("P76CTNTruong5");
                        
                            entity.Property(e => e.P76CTSTruong1).HasColumnName("P76CTSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P76CTSTruong2).HasColumnName("P76CTSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P76CTSTruong3).HasColumnName("P76CTSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P76CTSTruong4).HasColumnName("P76CTSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.P76CTSTruong5).HasColumnName("P76CTSTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuongTP).HasColumnName("SoLuongTP");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenTP).HasColumnName("TenTP").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<P77_PHAN_BO_CP>(entity =>
                    {
                        entity.HasKey(e => e.IDPB);
                        entity.ToTable("P77 PHAN BO CP");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDPB).HasColumnName("IDPB");
                        
                            entity.Property(e => e.LoaiGT).HasColumnName("LoaiGT").HasMaxLength(250);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTK).HasColumnName("MaTK").HasMaxLength(50);
                        
                            entity.Property(e => e.P77CKTruong1).HasColumnName("P77CKTruong1");
                        
                            entity.Property(e => e.P77CKTruong2).HasColumnName("P77CKTruong2");
                        
                            entity.Property(e => e.P77CKTruong3).HasColumnName("P77CKTruong3");
                        
                            entity.Property(e => e.P77DTruong1).HasColumnName("P77DTruong1");
                        
                            entity.Property(e => e.P77DTruong2).HasColumnName("P77DTruong2");
                        
                            entity.Property(e => e.P77DTruong3).HasColumnName("P77DTruong3");
                        
                            entity.Property(e => e.P77NTruong1).HasColumnName("P77NTruong1");
                        
                            entity.Property(e => e.P77NTruong2).HasColumnName("P77NTruong2");
                        
                            entity.Property(e => e.P77NTruong3).HasColumnName("P77NTruong3");
                        
                            entity.Property(e => e.P77NTruong4).HasColumnName("P77NTruong4");
                        
                            entity.Property(e => e.P77NTruong5).HasColumnName("P77NTruong5");
                        
                            entity.Property(e => e.P77STruong1).HasColumnName("P77STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P77STruong2).HasColumnName("P77STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P77STruong3).HasColumnName("P77STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P77STruong4).HasColumnName("P77STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.P77STruong5).HasColumnName("P77STruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.SoChuaPhanBo).HasColumnName("SoChuaPhanBo");
                        
                            entity.Property(e => e.SoPhanBo).HasColumnName("SoPhanBo");
                        
                            entity.Property(e => e.TyLePhanBo).HasColumnName("TyLePhanBo");
                        
                    });
                    
                    modelBuilder.Entity<P77_ZCHI_TIET_PB>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("P77 ZCHI TIET PB");
                        
                            entity.Property(e => e.CongSoTien).HasColumnName("CongSoTien");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DinhMuc).HasColumnName("DinhMuc");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.LoaiCT).HasColumnName("LoaiCT").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDTTHCP).HasColumnName("MaDTTHCP").HasMaxLength(150);
                        
                            entity.Property(e => e.MaTK).HasColumnName("MaTK").HasMaxLength(50);
                        
                            entity.Property(e => e.P77ChonLoc).HasColumnName("P77ChonLoc");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenDTTHCP).HasColumnName("TenDTTHCP").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDTTHCP2).HasColumnName("TenDTTHCP2").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<P81_BIEU_THUE_TN>(entity =>
                    {
                        entity.HasKey(e => e.IDP81);
                        entity.ToTable("P81 BIEU THUE TN");
                        
                            entity.Property(e => e.BacLuong).HasColumnName("BacLuong");
                        
                            entity.Property(e => e.HieuLucDen).HasColumnName("HieuLucDen");
                        
                            entity.Property(e => e.HieuLucTu).HasColumnName("HieuLucTu");
                        
                            entity.Property(e => e.IDP81).HasColumnName("IDP81");
                        
                            entity.Property(e => e.LoaiThue).HasColumnName("LoaiThue").HasMaxLength(250);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.SoTienTru).HasColumnName("SoTienTru");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenThue).HasColumnName("TenThue").HasMaxLength(250);
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.ThuNhapDen).HasColumnName("ThuNhapDen");
                        
                            entity.Property(e => e.ThuNhapTu).HasColumnName("ThuNhapTu");
                        
                    });
                    
                    modelBuilder.Entity<P81_KHOAN_TN_KT>(entity =>
                    {
                        entity.HasKey(e => e.IDKH);
                        entity.ToTable("P81 KHOAN TN KT");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CongThucLuong).HasColumnName("CongThucLuong").HasMaxLength(-1);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.GiaTriXL).HasColumnName("GiaTriXL").HasMaxLength(100);
                        
                            entity.Property(e => e.IDKH).HasColumnName("IDKH");
                        
                            entity.Property(e => e.IDLDXCT).HasColumnName("IDLDXCT");
                        
                            entity.Property(e => e.KyLuong).HasColumnName("KyLuong");
                        
                            entity.Property(e => e.LoaiChiuThue).HasColumnName("LoaiChiuThue").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiKhoan).HasColumnName("LoaiKhoan").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKhoan).HasColumnName("MaKhoan").HasMaxLength(150);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(150);
                        
                            entity.Property(e => e.NgayTNKT).HasColumnName("NgayTNKT");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYCT).HasColumnName("RECKEYCT").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYDP).HasColumnName("RECKEYDP").HasMaxLength(100);
                        
                            entity.Property(e => e.RECLDX).HasColumnName("RECLDX").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHopDong).HasColumnName("SoHopDong").HasMaxLength(50);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenKhoan).HasColumnName("TenKhoan").HasMaxLength(250);
                        
                            entity.Property(e => e.TheoNgayCong).HasColumnName("TheoNgayCong");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                    });
                    
                    modelBuilder.Entity<P81_KY_HIEU_CCONG>(entity =>
                    {
                        entity.HasKey(e => e.IDP81);
                        entity.ToTable("P81 KY HIEU CCONG");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.ChiuThue).HasColumnName("ChiuThue").HasMaxLength(250);
                        
                            entity.Property(e => e.CongThuc).HasColumnName("CongThuc").HasMaxLength(-1);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GiamTruKhiTinhThue).HasColumnName("GiamTruKhiTinhThue");
                        
                            entity.Property(e => e.HieuLucDen).HasColumnName("HieuLucDen");
                        
                            entity.Property(e => e.HieuLucTu).HasColumnName("HieuLucTu");
                        
                            entity.Property(e => e.IDP81).HasColumnName("IDP81");
                        
                            entity.Property(e => e.KyHieuCong).HasColumnName("KyHieuCong").HasMaxLength(250);
                        
                            entity.Property(e => e.LaThuNhap).HasColumnName("LaThuNhap");
                        
                            entity.Property(e => e.LoaiKhoanLuong).HasColumnName("LoaiKhoanLuong").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.MacDinh).HasColumnName("MacDinh");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TinhChat).HasColumnName("TinhChat").HasMaxLength(250);
                        
                            entity.Property(e => e.TyLeHuongLuong).HasColumnName("TyLeHuongLuong");
                        
                    });
                    
                    modelBuilder.Entity<P81_LOAI_BAO_HIEM>(entity =>
                    {
                        entity.HasKey(e => e.IDP81);
                        entity.ToTable("P81 LOAI BAO HIEM");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDP81).HasColumnName("IDP81");
                        
                            entity.Property(e => e.LoaiBH).HasColumnName("LoaiBH").HasMaxLength(30);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TyLe).HasColumnName("TyLe");
                        
                    });
                    
                    modelBuilder.Entity<P81_MUC_LUONG>(entity =>
                    {
                        entity.HasKey(e => e.IDP81);
                        entity.ToTable("P81 MUC LUONG");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(255);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(255);
                        
                            entity.Property(e => e.IDP81).HasColumnName("IDP81");
                        
                            entity.Property(e => e.LoaiLuong).HasColumnName("LoaiLuong").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(30);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.Nam).HasColumnName("Nam").HasMaxLength(10);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(60);
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.P81CKTruong1).HasColumnName("P81CKTruong1");
                        
                            entity.Property(e => e.P81CKTruong2).HasColumnName("P81CKTruong2");
                        
                            entity.Property(e => e.P81DTruong1).HasColumnName("P81DTruong1");
                        
                            entity.Property(e => e.P81DTruong2).HasColumnName("P81DTruong2");
                        
                            entity.Property(e => e.P81DTruong3).HasColumnName("P81DTruong3");
                        
                            entity.Property(e => e.P81DTruong4).HasColumnName("P81DTruong4");
                        
                            entity.Property(e => e.P81NTruong1).HasColumnName("P81NTruong1");
                        
                            entity.Property(e => e.P81NTruong2).HasColumnName("P81NTruong2");
                        
                            entity.Property(e => e.P81NTruong3).HasColumnName("P81NTruong3");
                        
                            entity.Property(e => e.P81NTruong4).HasColumnName("P81NTruong4");
                        
                            entity.Property(e => e.P81STruong1).HasColumnName("P81STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P81STruong2).HasColumnName("P81STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P81STruong3).HasColumnName("P81STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P81STruong4).HasColumnName("P81STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(150);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(50);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.TenPB).HasColumnName("TenPB").HasMaxLength(250);
                        
                            entity.Property(e => e.Thang).HasColumnName("Thang").HasMaxLength(10);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(30);
                        
                    });
                    
                    modelBuilder.Entity<P81_CAP_PHAT_TSNS>(entity =>
                    {
                        entity.HasKey(e => e.MaCP);
                        entity.ToTable("P81_CAP PHAT TSNS");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CapCP).HasColumnName("CapCP");
                        
                            entity.Property(e => e.ChoPhepDKTT).HasColumnName("ChoPhepDKTT");
                        
                            entity.Property(e => e.CPTSNTruong1).HasColumnName("CPTSNTruong1");
                        
                            entity.Property(e => e.CPTSNTruong2).HasColumnName("CPTSNTruong2");
                        
                            entity.Property(e => e.CPTSNTruong3).HasColumnName("CPTSNTruong3");
                        
                            entity.Property(e => e.CPTSNTruong4).HasColumnName("CPTSNTruong4");
                        
                            entity.Property(e => e.CPTSNTruong5).HasColumnName("CPTSNTruong5");
                        
                            entity.Property(e => e.CPTSSTruong1).HasColumnName("CPTSSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.CPTSSTruong2).HasColumnName("CPTSSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.CPTSSTruong3).HasColumnName("CPTSSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.CPTSSTruong4).HasColumnName("CPTSSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.CPTSSTruong5).HasColumnName("CPTSSTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.DenNgay).HasColumnName("DenNgay");
                        
                            entity.Property(e => e.DenThangNam).HasColumnName("DenThangNam");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DonViCTac).HasColumnName("DonViCTac").HasMaxLength(250);
                        
                            entity.Property(e => e.Dot).HasColumnName("Dot");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(-1);
                        
                            entity.Property(e => e.IconSo).HasColumnName("IconSo");
                        
                            entity.Property(e => e.KhauTruNS).HasColumnName("KhauTruNS");
                        
                            entity.Property(e => e.LaNhom).HasColumnName("LaNhom");
                        
                            entity.Property(e => e.LoaiCP).HasColumnName("LoaiCP").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(200);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCP).HasColumnName("MaCP").HasMaxLength(100);
                        
                            entity.Property(e => e.Nam).HasColumnName("Nam");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NhomCP).HasColumnName("NhomCP").HasMaxLength(250);
                        
                            entity.Property(e => e.SoTienKHThang).HasColumnName("SoTienKHThang");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TaiSanCP).HasColumnName("TaiSanCP").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDotCP).HasColumnName("TenDotCP").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDotCP2).HasColumnName("TenDotCP2").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNhom).HasColumnName("TenNhom").HasMaxLength(250);
                        
                            entity.Property(e => e.Thang).HasColumnName("Thang");
                        
                            entity.Property(e => e.TuDongThemNV).HasColumnName("TuDongThemNV");
                        
                            entity.Property(e => e.TuNgay).HasColumnName("TuNgay");
                        
                            entity.Property(e => e.TuThangNam).HasColumnName("TuThangNam");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<P81_DC_CHI_TIET_TGNS>(entity =>
                    {
                        entity.HasKey(e => e.MaDC);
                        entity.ToTable("P81_DC CHI TIET TGNS");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.BHXHThamGiaDen).HasColumnName("BHXHThamGiaDen");
                        
                            entity.Property(e => e.BHXHThamGiaTu).HasColumnName("BHXHThamGiaTu");
                        
                            entity.Property(e => e.BHYTNgayHetHan).HasColumnName("BHYTNgayHetHan");
                        
                            entity.Property(e => e.BHYTNgayThamGia).HasColumnName("BHYTNgayThamGia");
                        
                            entity.Property(e => e.CapDC).HasColumnName("CapDC");
                        
                            entity.Property(e => e.DaTraThe).HasColumnName("DaTraThe");
                        
                            entity.Property(e => e.DCLDCTNTruong1).HasColumnName("DCLDCTNTruong1");
                        
                            entity.Property(e => e.DCLDCTNTruong2).HasColumnName("DCLDCTNTruong2");
                        
                            entity.Property(e => e.DCLDCTNTruong3).HasColumnName("DCLDCTNTruong3");
                        
                            entity.Property(e => e.DCLDCTNTruong4).HasColumnName("DCLDCTNTruong4");
                        
                            entity.Property(e => e.DCLDCTNTruong5).HasColumnName("DCLDCTNTruong5");
                        
                            entity.Property(e => e.DCLDCTSTruong1).HasColumnName("DCLDCTSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.DCLDCTSTruong2).HasColumnName("DCLDCTSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.DCLDCTSTruong3).HasColumnName("DCLDCTSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.DCLDCTSTruong4).HasColumnName("DCLDCTSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.DCLDCTSTruong5).HasColumnName("DCLDCTSTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DonViCTac).HasColumnName("DonViCTac").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(-1);
                        
                            entity.Property(e => e.GioiTinh).HasColumnName("GioiTinh").HasMaxLength(50);
                        
                            entity.Property(e => e.IconSo).HasColumnName("IconSo");
                        
                            entity.Property(e => e.LaNhom).HasColumnName("LaNhom");
                        
                            entity.Property(e => e.LoaiDC).HasColumnName("LoaiDC").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(200);
                        
                            entity.Property(e => e.LuongCoBan).HasColumnName("LuongCoBan");
                        
                            entity.Property(e => e.LuongDongBH).HasColumnName("LuongDongBH");
                        
                            entity.Property(e => e.LuongDongBHCu).HasColumnName("LuongDongBHCu");
                        
                            entity.Property(e => e.LuongDongBHMoi).HasColumnName("LuongDongBHMoi");
                        
                            entity.Property(e => e.LyDoGiam).HasColumnName("LyDoGiam").HasMaxLength(250);
                        
                            entity.Property(e => e.LyDoTang).HasColumnName("LyDoTang").HasMaxLength(250);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDC).HasColumnName("MaDC").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDCLQ).HasColumnName("MaDCLQ").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDCRec).HasColumnName("MaDCRec").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgaySinh).HasColumnName("NgaySinh");
                        
                            entity.Property(e => e.NgayTG).HasColumnName("NgayTG");
                        
                            entity.Property(e => e.NhomDC).HasColumnName("NhomDC").HasMaxLength(250);
                        
                            entity.Property(e => e.SoCMND).HasColumnName("SoCMND").HasMaxLength(50);
                        
                            entity.Property(e => e.SoSoDongBHXH).HasColumnName("SoSoDongBHXH").HasMaxLength(50);
                        
                            entity.Property(e => e.SoTheBHYT).HasColumnName("SoTheBHYT").HasMaxLength(50);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenNVien).HasColumnName("TenNVien").HasMaxLength(150);
                        
                            entity.Property(e => e.TyLeDongBH).HasColumnName("TyLeDongBH");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.ViTriCViec).HasColumnName("ViTriCViec").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<P81_DIEU_CHINH_TGNS>(entity =>
                    {
                        entity.HasKey(e => e.MaDC);
                        entity.ToTable("P81_DIEU CHINH TGNS");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CapDC).HasColumnName("CapDC");
                        
                            entity.Property(e => e.DaLapDauKy).HasColumnName("DaLapDauKy");
                        
                            entity.Property(e => e.DCLDNTruong1).HasColumnName("DCLDNTruong1");
                        
                            entity.Property(e => e.DCLDNTruong2).HasColumnName("DCLDNTruong2");
                        
                            entity.Property(e => e.DCLDNTruong3).HasColumnName("DCLDNTruong3");
                        
                            entity.Property(e => e.DCLDNTruong4).HasColumnName("DCLDNTruong4");
                        
                            entity.Property(e => e.DCLDNTruong5).HasColumnName("DCLDNTruong5");
                        
                            entity.Property(e => e.DCLDSTruong1).HasColumnName("DCLDSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.DCLDSTruong2).HasColumnName("DCLDSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.DCLDSTruong3).HasColumnName("DCLDSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.DCLDSTruong4).HasColumnName("DCLDSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.DCLDSTruong5).HasColumnName("DCLDSTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DonViCTac).HasColumnName("DonViCTac").HasMaxLength(250);
                        
                            entity.Property(e => e.Dot).HasColumnName("Dot");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(-1);
                        
                            entity.Property(e => e.IconSo).HasColumnName("IconSo");
                        
                            entity.Property(e => e.LaNhom).HasColumnName("LaNhom");
                        
                            entity.Property(e => e.LoaiDC).HasColumnName("LoaiDC").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(200);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDC).HasColumnName("MaDC").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDCRec).HasColumnName("MaDCRec").HasMaxLength(100);
                        
                            entity.Property(e => e.Nam).HasColumnName("Nam");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NhomDC).HasColumnName("NhomDC").HasMaxLength(250);
                        
                            entity.Property(e => e.SoLDThamGiaBHTN).HasColumnName("SoLDThamGiaBHTN");
                        
                            entity.Property(e => e.SoLDThamGiaBHXH).HasColumnName("SoLDThamGiaBHXH");
                        
                            entity.Property(e => e.SoLDThamGiaBHYT).HasColumnName("SoLDThamGiaBHYT");
                        
                            entity.Property(e => e.SoTienDongBHTN).HasColumnName("SoTienDongBHTN");
                        
                            entity.Property(e => e.SoTienDongBHXH).HasColumnName("SoTienDongBHXH");
                        
                            entity.Property(e => e.SoTienDongBHYT).HasColumnName("SoTienDongBHYT");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenDieuChinh).HasColumnName("TenDieuChinh").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDotBC).HasColumnName("TenDotBC").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDotBC2).HasColumnName("TenDotBC2").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNhom).HasColumnName("TenNhom").HasMaxLength(250);
                        
                            entity.Property(e => e.Thang).HasColumnName("Thang");
                        
                            entity.Property(e => e.TongQuyLuongBHTN).HasColumnName("TongQuyLuongBHTN");
                        
                            entity.Property(e => e.TongQuyLuongBHXH).HasColumnName("TongQuyLuongBHXH");
                        
                            entity.Property(e => e.TongQuyLuongBHYT).HasColumnName("TongQuyLuongBHYT");
                        
                            entity.Property(e => e.TrongDoNuBHXH).HasColumnName("TrongDoNuBHXH");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<P81_LICH_SU_LUONG>(entity =>
                    {
                        entity.HasKey(e => e.IDLS);
                        entity.ToTable("P81_LICH SU LUONG");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDLS).HasColumnName("IDLS");
                        
                            entity.Property(e => e.KyLuong).HasColumnName("KyLuong");
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.LuongCoBan).HasColumnName("LuongCoBan");
                        
                            entity.Property(e => e.LuongCoBanCu).HasColumnName("LuongCoBanCu");
                        
                            entity.Property(e => e.LuongDongBH).HasColumnName("LuongDongBH");
                        
                            entity.Property(e => e.LuongDongBHCu).HasColumnName("LuongDongBHCu");
                        
                            entity.Property(e => e.MaBangLuong).HasColumnName("MaBangLuong").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaLS).HasColumnName("MaLS").HasMaxLength(150);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(150);
                        
                            entity.Property(e => e.MaTNKT).HasColumnName("MaTNKT").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayThayDoi).HasColumnName("NgayThayDoi");
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(150);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.ViTriCViec).HasColumnName("ViTriCViec").HasMaxLength(150);
                        
                    });
                    
                    modelBuilder.Entity<P81_LICH_SU_LUONG_TMP>(entity =>
                    {
                        entity.HasKey(e => e.IDLS);
                        entity.ToTable("P81_LICH SU LUONG TMP");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDLS).HasColumnName("IDLS");
                        
                            entity.Property(e => e.KyLuong).HasColumnName("KyLuong");
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.LuongCoBan).HasColumnName("LuongCoBan");
                        
                            entity.Property(e => e.LuongCoBanCu).HasColumnName("LuongCoBanCu");
                        
                            entity.Property(e => e.LuongDongBH).HasColumnName("LuongDongBH");
                        
                            entity.Property(e => e.LuongDongBHCu).HasColumnName("LuongDongBHCu");
                        
                            entity.Property(e => e.MaBangLuong).HasColumnName("MaBangLuong").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaLS).HasColumnName("MaLS").HasMaxLength(150);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(150);
                        
                            entity.Property(e => e.MaTNKT).HasColumnName("MaTNKT").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayThayDoi).HasColumnName("NgayThayDoi");
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(150);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.ViTriCViec).HasColumnName("ViTriCViec").HasMaxLength(150);
                        
                    });
                    
                    modelBuilder.Entity<P812_CHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.IDP81CT);
                        entity.ToTable("P812 CHI TIET");
                        
                            entity.Property(e => e.ChucVu).HasColumnName("ChucVu").HasMaxLength(150);
                        
                            entity.Property(e => e.CongTacPhi).HasColumnName("CongTacPhi");
                        
                            entity.Property(e => e.CongTacPhi2).HasColumnName("CongTacPhi2");
                        
                            entity.Property(e => e.CongTacPhi3).HasColumnName("CongTacPhi3");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(255);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(255);
                        
                            entity.Property(e => e.GiamTruGiaCanh).HasColumnName("GiamTruGiaCanh");
                        
                            entity.Property(e => e.HeSoLuong).HasColumnName("HeSoLuong");
                        
                            entity.Property(e => e.IDP81CT).HasColumnName("IDP81CT");
                        
                            entity.Property(e => e.LoaiLuong).HasColumnName("LoaiLuong").HasMaxLength(250);
                        
                            entity.Property(e => e.LuongCoBan).HasColumnName("LuongCoBan");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(50);
                        
                            entity.Property(e => e.P81CTCKTruong1).HasColumnName("P81CTCKTruong1");
                        
                            entity.Property(e => e.P81CTCKTruong2).HasColumnName("P81CTCKTruong2");
                        
                            entity.Property(e => e.P81CTDTruong1).HasColumnName("P81CTDTruong1");
                        
                            entity.Property(e => e.P81CTDTruong2).HasColumnName("P81CTDTruong2");
                        
                            entity.Property(e => e.P81CTDTruong3).HasColumnName("P81CTDTruong3");
                        
                            entity.Property(e => e.P81CTDTruong4).HasColumnName("P81CTDTruong4");
                        
                            entity.Property(e => e.P81CTNTruong1).HasColumnName("P81CTNTruong1");
                        
                            entity.Property(e => e.P81CTNTruong2).HasColumnName("P81CTNTruong2");
                        
                            entity.Property(e => e.P81CTNTruong3).HasColumnName("P81CTNTruong3");
                        
                            entity.Property(e => e.P81CTNTruong4).HasColumnName("P81CTNTruong4");
                        
                            entity.Property(e => e.P81CTSTruong1).HasColumnName("P81CTSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P81CTSTruong2).HasColumnName("P81CTSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P81CTSTruong3).HasColumnName("P81CTSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P81CTSTruong4).HasColumnName("P81CTSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(150);
                        
                            entity.Property(e => e.PhuCapChucVu).HasColumnName("PhuCapChucVu");
                        
                            entity.Property(e => e.PhuCapDocHai).HasColumnName("PhuCapDocHai");
                        
                            entity.Property(e => e.PhuCapKhac).HasColumnName("PhuCapKhac");
                        
                            entity.Property(e => e.PhuCapKhac2).HasColumnName("PhuCapKhac2");
                        
                            entity.Property(e => e.PhuCapQuyLuong).HasColumnName("PhuCapQuyLuong");
                        
                            entity.Property(e => e.PhuCapSinhHoat).HasColumnName("PhuCapSinhHoat");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(50);
                        
                            entity.Property(e => e.TenNVien).HasColumnName("TenNVien").HasMaxLength(255);
                        
                            entity.Property(e => e.TenPB).HasColumnName("TenPB").HasMaxLength(250);
                        
                            entity.Property(e => e.ThuongLeTet).HasColumnName("ThuongLeTet");
                        
                            entity.Property(e => e.XangXeCTac).HasColumnName("XangXeCTac");
                        
                    });
                    
                    //Unable to generate entity type for table 'dbo.P84 KHEN THUONG KL'. table have no primary key
                    
                    modelBuilder.Entity<P85_CHAM_CONG>(entity =>
                    {
                        entity.HasKey(e => e.RECKEY);
                        entity.ToTable("P85 CHAM CONG");
                        
                            entity.Property(e => e.DaLapPLuong).HasColumnName("DaLapPLuong");
                        
                            entity.Property(e => e.DenNgay).HasColumnName("DenNgay");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(200);
                        
                            entity.Property(e => e.LoaiCong).HasColumnName("LoaiCong").HasMaxLength(200);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(10);
                        
                            entity.Property(e => e.LoaiXLC).HasColumnName("LoaiXLC").HasMaxLength(50);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.Nam).HasColumnName("Nam");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(60);
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(-1);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.SoNgay).HasColumnName("SoNgay");
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(30);
                        
                            entity.Property(e => e.SoPhieuLuong).HasColumnName("SoPhieuLuong").HasMaxLength(30);
                        
                            entity.Property(e => e.TenPB).HasColumnName("TenPB").HasMaxLength(250);
                        
                            entity.Property(e => e.Thang).HasColumnName("Thang");
                        
                            entity.Property(e => e.TuNgay).HasColumnName("TuNgay");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(30);
                        
                    });
                    
                    modelBuilder.Entity<P85_CHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.IDP85);
                        entity.ToTable("P85 CHI TIET");
                        
                            entity.Property(e => e._01).HasColumnName("01").HasMaxLength(20);
                        
                            entity.Property(e => e._02).HasColumnName("02").HasMaxLength(20);
                        
                            entity.Property(e => e._03).HasColumnName("03").HasMaxLength(20);
                        
                            entity.Property(e => e._04).HasColumnName("04").HasMaxLength(20);
                        
                            entity.Property(e => e._05).HasColumnName("05").HasMaxLength(20);
                        
                            entity.Property(e => e._06).HasColumnName("06").HasMaxLength(20);
                        
                            entity.Property(e => e._07).HasColumnName("07").HasMaxLength(20);
                        
                            entity.Property(e => e._08).HasColumnName("08").HasMaxLength(20);
                        
                            entity.Property(e => e._09).HasColumnName("09").HasMaxLength(20);
                        
                            entity.Property(e => e._10).HasColumnName("10").HasMaxLength(20);
                        
                            entity.Property(e => e._11).HasColumnName("11").HasMaxLength(20);
                        
                            entity.Property(e => e._12).HasColumnName("12").HasMaxLength(20);
                        
                            entity.Property(e => e._13).HasColumnName("13").HasMaxLength(20);
                        
                            entity.Property(e => e._14).HasColumnName("14").HasMaxLength(20);
                        
                            entity.Property(e => e._15).HasColumnName("15").HasMaxLength(20);
                        
                            entity.Property(e => e._16).HasColumnName("16").HasMaxLength(20);
                        
                            entity.Property(e => e._17).HasColumnName("17").HasMaxLength(20);
                        
                            entity.Property(e => e._18).HasColumnName("18").HasMaxLength(20);
                        
                            entity.Property(e => e._19).HasColumnName("19").HasMaxLength(20);
                        
                            entity.Property(e => e._20).HasColumnName("20").HasMaxLength(20);
                        
                            entity.Property(e => e._21).HasColumnName("21").HasMaxLength(20);
                        
                            entity.Property(e => e._22).HasColumnName("22").HasMaxLength(20);
                        
                            entity.Property(e => e._23).HasColumnName("23").HasMaxLength(20);
                        
                            entity.Property(e => e._24).HasColumnName("24").HasMaxLength(20);
                        
                            entity.Property(e => e._25).HasColumnName("25").HasMaxLength(20);
                        
                            entity.Property(e => e._26).HasColumnName("26").HasMaxLength(20);
                        
                            entity.Property(e => e._27).HasColumnName("27").HasMaxLength(20);
                        
                            entity.Property(e => e._28).HasColumnName("28").HasMaxLength(20);
                        
                            entity.Property(e => e._29).HasColumnName("29").HasMaxLength(20);
                        
                            entity.Property(e => e._30).HasColumnName("30").HasMaxLength(20);
                        
                            entity.Property(e => e._31).HasColumnName("31").HasMaxLength(20);
                        
                            entity.Property(e => e.CongNgay1).HasColumnName("CongNgay1");
                        
                            entity.Property(e => e.CongNgay2).HasColumnName("CongNgay2");
                        
                            entity.Property(e => e.CongNgay3).HasColumnName("CongNgay3");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.GhiChu1).HasColumnName("GhiChu1").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.GiaThanhPham).HasColumnName("GiaThanhPham");
                        
                            entity.Property(e => e.IDP85).HasColumnName("IDP85");
                        
                            entity.Property(e => e.KhongHuong100).HasColumnName("KhongHuong100");
                        
                            entity.Property(e => e.KhuVuc).HasColumnName("KhuVuc").HasMaxLength(-1);
                        
                            entity.Property(e => e.LoaiCong).HasColumnName("LoaiCong").HasMaxLength(100);
                        
                            entity.Property(e => e.LuongHuong100).HasColumnName("LuongHuong100");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(200);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(150);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(200);
                        
                            entity.Property(e => e.NgayTinh).HasColumnName("NgayTinh");
                        
                            entity.Property(e => e.P85CHECK1).HasColumnName("P85CHECK1");
                        
                            entity.Property(e => e.P85CHECK2).HasColumnName("P85CHECK2");
                        
                            entity.Property(e => e.P85DATE1).HasColumnName("P85DATE1");
                        
                            entity.Property(e => e.P85DATE2).HasColumnName("P85DATE2");
                        
                            entity.Property(e => e.P85DATE3).HasColumnName("P85DATE3");
                        
                            entity.Property(e => e.P85DATE4).HasColumnName("P85DATE4");
                        
                            entity.Property(e => e.P85DATE5).HasColumnName("P85DATE5");
                        
                            entity.Property(e => e.P85NUMBER1).HasColumnName("P85NUMBER1");
                        
                            entity.Property(e => e.P85NUMBER2).HasColumnName("P85NUMBER2");
                        
                            entity.Property(e => e.P85NUMBER3).HasColumnName("P85NUMBER3");
                        
                            entity.Property(e => e.P85NUMBER4).HasColumnName("P85NUMBER4");
                        
                            entity.Property(e => e.P85NUMBER5).HasColumnName("P85NUMBER5");
                        
                            entity.Property(e => e.P85TRING1).HasColumnName("P85TRING1").HasMaxLength(250);
                        
                            entity.Property(e => e.P85TRING2).HasColumnName("P85TRING2").HasMaxLength(250);
                        
                            entity.Property(e => e.P85TRING3).HasColumnName("P85TRING3").HasMaxLength(250);
                        
                            entity.Property(e => e.P85TRING4).HasColumnName("P85TRING4").HasMaxLength(250);
                        
                            entity.Property(e => e.P85TRING5).HasColumnName("P85TRING5").HasMaxLength(250);
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(200);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.SoGioCongHuong100).HasColumnName("SoGioCongHuong100");
                        
                            entity.Property(e => e.SoGioCongKHuong100).HasColumnName("SoGioCongKHuong100");
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoNgayCongHuong100).HasColumnName("SoNgayCongHuong100");
                        
                            entity.Property(e => e.SoNgayCongKHuong100).HasColumnName("SoNgayCongKHuong100");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenNVien).HasColumnName("TenNVien").HasMaxLength(200);
                        
                            entity.Property(e => e.TenPB).HasColumnName("TenPB").HasMaxLength(250);
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                    });
                    
                    modelBuilder.Entity<P89_BANG_LUONG>(entity =>
                    {
                        entity.HasKey(e => e.RECKEY);
                        entity.ToTable("P89 BANG LUONG");
                        
                            entity.Property(e => e.DenNgay).HasColumnName("DenNgay");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(255);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(255);
                        
                            entity.Property(e => e.LoaiCong).HasColumnName("LoaiCong").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.LoaiXLC).HasColumnName("LoaiXLC").HasMaxLength(250);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.Nam).HasColumnName("Nam");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(50);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.P89CKTruong1).HasColumnName("P89CKTruong1");
                        
                            entity.Property(e => e.P89CKTruong2).HasColumnName("P89CKTruong2");
                        
                            entity.Property(e => e.P89DTruong1).HasColumnName("P89DTruong1");
                        
                            entity.Property(e => e.P89DTruong2).HasColumnName("P89DTruong2");
                        
                            entity.Property(e => e.P89DTruong3).HasColumnName("P89DTruong3");
                        
                            entity.Property(e => e.P89DTruong4).HasColumnName("P89DTruong4");
                        
                            entity.Property(e => e.P89NTruong1).HasColumnName("P89NTruong1");
                        
                            entity.Property(e => e.P89NTruong2).HasColumnName("P89NTruong2");
                        
                            entity.Property(e => e.P89NTruong3).HasColumnName("P89NTruong3");
                        
                            entity.Property(e => e.P89NTruong4).HasColumnName("P89NTruong4");
                        
                            entity.Property(e => e.P89STruong1).HasColumnName("P89STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.P89STruong2).HasColumnName("P89STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.P89STruong3).HasColumnName("P89STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.P89STruong4).HasColumnName("P89STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.PhieuCCSo).HasColumnName("PhieuCCSo").HasMaxLength(50);
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(-1);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(50);
                        
                            entity.Property(e => e.SoNgay).HasColumnName("SoNgay");
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.TenPB).HasColumnName("TenPB").HasMaxLength(250);
                        
                            entity.Property(e => e.Thang).HasColumnName("Thang");
                        
                            entity.Property(e => e.TuNgay).HasColumnName("TuNgay");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(50);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(50);
                        
                    });
                    
                    modelBuilder.Entity<P89_CHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.IDP89);
                        entity.ToTable("P89 CHI TIET");
                        
                            entity.Property(e => e._01).HasColumnName("01").HasMaxLength(20);
                        
                            entity.Property(e => e._02).HasColumnName("02").HasMaxLength(20);
                        
                            entity.Property(e => e._03).HasColumnName("03").HasMaxLength(20);
                        
                            entity.Property(e => e._04).HasColumnName("04").HasMaxLength(20);
                        
                            entity.Property(e => e._05).HasColumnName("05").HasMaxLength(20);
                        
                            entity.Property(e => e._06).HasColumnName("06").HasMaxLength(20);
                        
                            entity.Property(e => e._07).HasColumnName("07").HasMaxLength(20);
                        
                            entity.Property(e => e._08).HasColumnName("08").HasMaxLength(20);
                        
                            entity.Property(e => e._09).HasColumnName("09").HasMaxLength(20);
                        
                            entity.Property(e => e._10).HasColumnName("10").HasMaxLength(20);
                        
                            entity.Property(e => e._11).HasColumnName("11").HasMaxLength(20);
                        
                            entity.Property(e => e._12).HasColumnName("12").HasMaxLength(20);
                        
                            entity.Property(e => e._13).HasColumnName("13").HasMaxLength(20);
                        
                            entity.Property(e => e._14).HasColumnName("14").HasMaxLength(20);
                        
                            entity.Property(e => e._15).HasColumnName("15").HasMaxLength(20);
                        
                            entity.Property(e => e._16).HasColumnName("16").HasMaxLength(20);
                        
                            entity.Property(e => e._17).HasColumnName("17").HasMaxLength(20);
                        
                            entity.Property(e => e._18).HasColumnName("18").HasMaxLength(20);
                        
                            entity.Property(e => e._19).HasColumnName("19").HasMaxLength(20);
                        
                            entity.Property(e => e._20).HasColumnName("20").HasMaxLength(20);
                        
                            entity.Property(e => e._21).HasColumnName("21").HasMaxLength(20);
                        
                            entity.Property(e => e._22).HasColumnName("22").HasMaxLength(20);
                        
                            entity.Property(e => e._23).HasColumnName("23").HasMaxLength(20);
                        
                            entity.Property(e => e._24).HasColumnName("24").HasMaxLength(20);
                        
                            entity.Property(e => e._25).HasColumnName("25").HasMaxLength(20);
                        
                            entity.Property(e => e._26).HasColumnName("26").HasMaxLength(20);
                        
                            entity.Property(e => e._27).HasColumnName("27").HasMaxLength(20);
                        
                            entity.Property(e => e._28).HasColumnName("28").HasMaxLength(20);
                        
                            entity.Property(e => e._29).HasColumnName("29").HasMaxLength(20);
                        
                            entity.Property(e => e._30).HasColumnName("30").HasMaxLength(20);
                        
                            entity.Property(e => e._31).HasColumnName("31").HasMaxLength(20);
                        
                            entity.Property(e => e.ChonTra).HasColumnName("ChonTra");
                        
                            entity.Property(e => e.ChucVu).HasColumnName("ChucVu").HasMaxLength(50);
                        
                            entity.Property(e => e.ChuyenKhoan).HasColumnName("ChuyenKhoan");
                        
                            entity.Property(e => e.CongHanhChinh).HasColumnName("CongHanhChinh");
                        
                            entity.Property(e => e.CongHuong100).HasColumnName("CongHuong100");
                        
                            entity.Property(e => e.CongKhac100).HasColumnName("CongKhac100");
                        
                            entity.Property(e => e.CongLeTet).HasColumnName("CongLeTet");
                        
                            entity.Property(e => e.CongNgayNghi).HasColumnName("CongNgayNghi");
                        
                            entity.Property(e => e.CongPhep).HasColumnName("CongPhep");
                        
                            entity.Property(e => e.CongTacPhi).HasColumnName("CongTacPhi");
                        
                            entity.Property(e => e.CongTacPhi2).HasColumnName("CongTacPhi2");
                        
                            entity.Property(e => e.CongTacPhi3).HasColumnName("CongTacPhi3");
                        
                            entity.Property(e => e.CongTangCaLeTet).HasColumnName("CongTangCaLeTet");
                        
                            entity.Property(e => e.CongTangCaThuong).HasColumnName("CongTangCaThuong");
                        
                            entity.Property(e => e.DenNgay).HasColumnName("DenNgay");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(255);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(255);
                        
                            entity.Property(e => e.DonGiaGioCong).HasColumnName("DonGiaGioCong");
                        
                            entity.Property(e => e.DonGiaNgayCong).HasColumnName("DonGiaNgayCong");
                        
                            entity.Property(e => e.GiamTruGiaCanh).HasColumnName("GiamTruGiaCanh");
                        
                            entity.Property(e => e.HeSoLuong).HasColumnName("HeSoLuong");
                        
                            entity.Property(e => e.IDP89).HasColumnName("IDP89");
                        
                            entity.Property(e => e.KhauTru).HasColumnName("KhauTru");
                        
                            entity.Property(e => e.KyNhan).HasColumnName("KyNhan");
                        
                            entity.Property(e => e.LaoDongGiam).HasColumnName("LaoDongGiam");
                        
                            entity.Property(e => e.LaoDongTang).HasColumnName("LaoDongTang");
                        
                            entity.Property(e => e.LuongCoBan).HasColumnName("LuongCoBan");
                        
                            entity.Property(e => e.LuongDongBH).HasColumnName("LuongDongBH");
                        
                            entity.Property(e => e.LuongHuong100).HasColumnName("LuongHuong100");
                        
                            entity.Property(e => e.LuongKHuong100).HasColumnName("LuongKHuong100");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(50);
                        
                            entity.Property(e => e.MoTaiNH).HasColumnName("MoTaiNH").HasMaxLength(250);
                        
                            entity.Property(e => e.Nam).HasColumnName("Nam");
                        
                            entity.Property(e => e.P85LC1).HasColumnName("P85LC1").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC10).HasColumnName("P85LC10").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC11).HasColumnName("P85LC11").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC12).HasColumnName("P85LC12").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC13).HasColumnName("P85LC13").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC14).HasColumnName("P85LC14").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC15).HasColumnName("P85LC15").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC16).HasColumnName("P85LC16").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC17).HasColumnName("P85LC17").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC18).HasColumnName("P85LC18").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC19).HasColumnName("P85LC19").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC2).HasColumnName("P85LC2").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC20).HasColumnName("P85LC20").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC21).HasColumnName("P85LC21").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC22).HasColumnName("P85LC22").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC23).HasColumnName("P85LC23").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC24).HasColumnName("P85LC24").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC25).HasColumnName("P85LC25").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC3).HasColumnName("P85LC3").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC4).HasColumnName("P85LC4").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC5).HasColumnName("P85LC5").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC6).HasColumnName("P85LC6").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC7).HasColumnName("P85LC7").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC8).HasColumnName("P85LC8").HasMaxLength(50);
                        
                            entity.Property(e => e.P85LC9).HasColumnName("P85LC9").HasMaxLength(50);
                        
                            entity.Property(e => e.P89CKTruong1).HasColumnName("P89CKTruong1");
                        
                            entity.Property(e => e.P89CKTruong2).HasColumnName("P89CKTruong2");
                        
                            entity.Property(e => e.P89CKTruong3).HasColumnName("P89CKTruong3");
                        
                            entity.Property(e => e.P89DTruong1).HasColumnName("P89DTruong1");
                        
                            entity.Property(e => e.P89DTruong2).HasColumnName("P89DTruong2");
                        
                            entity.Property(e => e.P89DTruong3).HasColumnName("P89DTruong3");
                        
                            entity.Property(e => e.P89DTruong4).HasColumnName("P89DTruong4");
                        
                            entity.Property(e => e.P89NTruong1).HasColumnName("P89NTruong1");
                        
                            entity.Property(e => e.P89NTruong10).HasColumnName("P89NTruong10");
                        
                            entity.Property(e => e.P89NTruong2).HasColumnName("P89NTruong2");
                        
                            entity.Property(e => e.P89NTruong3).HasColumnName("P89NTruong3");
                        
                            entity.Property(e => e.P89NTruong4).HasColumnName("P89NTruong4");
                        
                            entity.Property(e => e.P89NTruong5).HasColumnName("P89NTruong5");
                        
                            entity.Property(e => e.P89NTruong6).HasColumnName("P89NTruong6");
                        
                            entity.Property(e => e.P89NTruong7).HasColumnName("P89NTruong7");
                        
                            entity.Property(e => e.P89NTruong8).HasColumnName("P89NTruong8");
                        
                            entity.Property(e => e.P89NTruong9).HasColumnName("P89NTruong9");
                        
                            entity.Property(e => e.P89STruong1).HasColumnName("P89STruong1").HasMaxLength(255);
                        
                            entity.Property(e => e.P89STruong10).HasColumnName("P89STruong10").HasMaxLength(255);
                        
                            entity.Property(e => e.P89STruong2).HasColumnName("P89STruong2").HasMaxLength(255);
                        
                            entity.Property(e => e.P89STruong3).HasColumnName("P89STruong3").HasMaxLength(255);
                        
                            entity.Property(e => e.P89STruong4).HasColumnName("P89STruong4").HasMaxLength(255);
                        
                            entity.Property(e => e.P89STruong5).HasColumnName("P89STruong5").HasMaxLength(255);
                        
                            entity.Property(e => e.P89STruong6).HasColumnName("P89STruong6").HasMaxLength(255);
                        
                            entity.Property(e => e.P89STruong7).HasColumnName("P89STruong7").HasMaxLength(255);
                        
                            entity.Property(e => e.P89STruong8).HasColumnName("P89STruong8").HasMaxLength(255);
                        
                            entity.Property(e => e.P89STruong9).HasColumnName("P89STruong9").HasMaxLength(255);
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(150);
                        
                            entity.Property(e => e.PhuCapBHXH).HasColumnName("PhuCapBHXH");
                        
                            entity.Property(e => e.PhuCapChucVu).HasColumnName("PhuCapChucVu");
                        
                            entity.Property(e => e.PhuCapChuyenCan).HasColumnName("PhuCapChuyenCan");
                        
                            entity.Property(e => e.PhuCapDocHai).HasColumnName("PhuCapDocHai");
                        
                            entity.Property(e => e.PhuCapKhac).HasColumnName("PhuCapKhac");
                        
                            entity.Property(e => e.PhuCapKhac2).HasColumnName("PhuCapKhac2");
                        
                            entity.Property(e => e.PhuCapQuyLuong).HasColumnName("PhuCapQuyLuong");
                        
                            entity.Property(e => e.PhuCapSinhHoat).HasColumnName("PhuCapSinhHoat");
                        
                            entity.Property(e => e.PTTT).HasColumnName("PTTT").HasMaxLength(150);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.RECKEYPK).HasColumnName("RECKEYPK").HasMaxLength(100);
                        
                            entity.Property(e => e.SoGioHuong100).HasColumnName("SoGioHuong100");
                        
                            entity.Property(e => e.SoGioKhac100).HasColumnName("SoGioKhac100");
                        
                            entity.Property(e => e.SoGioTrongThang).HasColumnName("SoGioTrongThang");
                        
                            entity.Property(e => e.SoNgayTrongThang).HasColumnName("SoNgayTrongThang");
                        
                            entity.Property(e => e.SoTienCong).HasColumnName("SoTienCong");
                        
                            entity.Property(e => e.STConPhaiTra).HasColumnName("STConPhaiTra");
                        
                            entity.Property(e => e.STDaTra).HasColumnName("STDaTra");
                        
                            entity.Property(e => e.TenNVien).HasColumnName("TenNVien").HasMaxLength(255);
                        
                            entity.Property(e => e.TenPB).HasColumnName("TenPB").HasMaxLength(250);
                        
                            entity.Property(e => e.ThamNien).HasColumnName("ThamNien");
                        
                            entity.Property(e => e.Thang).HasColumnName("Thang");
                        
                            entity.Property(e => e.ThucLanh).HasColumnName("ThucLanh");
                        
                            entity.Property(e => e.ThuNhapTinhThue).HasColumnName("ThuNhapTinhThue");
                        
                            entity.Property(e => e.ThuongCongViec).HasColumnName("ThuongCongViec");
                        
                            entity.Property(e => e.ThuongLeTet).HasColumnName("ThuongLeTet");
                        
                            entity.Property(e => e.TienBHTN).HasColumnName("TienBHTN");
                        
                            entity.Property(e => e.TienBHTNCT).HasColumnName("TienBHTNCT");
                        
                            entity.Property(e => e.TienBHXH).HasColumnName("TienBHXH");
                        
                            entity.Property(e => e.TienBHXHCT).HasColumnName("TienBHXHCT");
                        
                            entity.Property(e => e.TienBHYT).HasColumnName("TienBHYT");
                        
                            entity.Property(e => e.TienBHYTCT).HasColumnName("TienBHYTCT");
                        
                            entity.Property(e => e.TienCDoanCT).HasColumnName("TienCDoanCT");
                        
                            entity.Property(e => e.TienCom).HasColumnName("TienCom");
                        
                            entity.Property(e => e.TienCongDoan).HasColumnName("TienCongDoan");
                        
                            entity.Property(e => e.TienTamUng).HasColumnName("TienTamUng");
                        
                            entity.Property(e => e.TienThueTN).HasColumnName("TienThueTN");
                        
                            entity.Property(e => e.TienTruKhac).HasColumnName("TienTruKhac");
                        
                            entity.Property(e => e.TienTruKhac2).HasColumnName("TienTruKhac2");
                        
                            entity.Property(e => e.TKNganHang).HasColumnName("TKNganHang").HasMaxLength(100);
                        
                            entity.Property(e => e.TongKhoanKT).HasColumnName("TongKhoanKT");
                        
                            entity.Property(e => e.TongKhoanPC).HasColumnName("TongKhoanPC");
                        
                            entity.Property(e => e.TongLuong).HasColumnName("TongLuong");
                        
                            entity.Property(e => e.TongLuongTV).HasColumnName("TongLuongTV");
                        
                            entity.Property(e => e.TongLuongVC).HasColumnName("TongLuongVC");
                        
                            entity.Property(e => e.TongTNPC).HasColumnName("TongTNPC");
                        
                            entity.Property(e => e.TuNgay).HasColumnName("TuNgay");
                        
                            entity.Property(e => e.XangXeCTac).HasColumnName("XangXeCTac");
                        
                    });
                    
                    //Unable to generate entity type for table 'dbo.P89 LUONG CONG'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.P91 TAI SAN'. table have no primary key
                    
                    modelBuilder.Entity<P92_CTIET_TSAN>(entity =>
                    {
                        entity.HasKey(e => e.RECKEY);
                        entity.ToTable("P92 CTIET TSAN");
                        
                            entity.Property(e => e.CongSuat).HasColumnName("CongSuat").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GiaTriGiam).HasColumnName("GiaTriGiam");
                        
                            entity.Property(e => e.GiaTriTang).HasColumnName("GiaTriTang");
                        
                            entity.Property(e => e.LyDoDinhChi).HasColumnName("LyDoDinhChi").HasMaxLength(250);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTS).HasColumnName("MaTS").HasMaxLength(50);
                        
                            entity.Property(e => e.NGAY).HasColumnName("NGAY");
                        
                            entity.Property(e => e.NgayDinhChi).HasColumnName("NgayDinhChi");
                        
                            entity.Property(e => e.NgayLH).HasColumnName("NgayLH");
                        
                            entity.Property(e => e.NgayTinhLaiKH).HasColumnName("NgayTinhLaiKH");
                        
                            entity.Property(e => e.NghiepVu).HasColumnName("NghiepVu").HasMaxLength(50);
                        
                            entity.Property(e => e.NguonVon).HasColumnName("NguonVon").HasMaxLength(50);
                        
                            entity.Property(e => e.NoiDat).HasColumnName("NoiDat").HasMaxLength(50);
                        
                            entity.Property(e => e.PhuongThucKH).HasColumnName("PhuongThucKH").HasMaxLength(150);
                        
                            entity.Property(e => e.PhuTung).HasColumnName("PhuTung").HasMaxLength(250);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.SoCTLH).HasColumnName("SoCTLH").HasMaxLength(50);
                        
                            entity.Property(e => e.TinhChat).HasColumnName("TinhChat").HasMaxLength(150);
                        
                            entity.Property(e => e.TKCoKH).HasColumnName("TKCoKH").HasMaxLength(30);
                        
                            entity.Property(e => e.TKNoKH).HasColumnName("TKNoKH").HasMaxLength(30);
                        
                            entity.Property(e => e.TKNoTS).HasColumnName("TKNoTS").HasMaxLength(30);
                        
                            entity.Property(e => e.TyLeKH).HasColumnName("TyLeKH");
                        
                            entity.Property(e => e.TyLePBKH).HasColumnName("TyLePBKH");
                        
                    });
                    
                    modelBuilder.Entity<P93_DIEU_CHUYEN>(entity =>
                    {
                        entity.HasKey(e => e.RECKEY);
                        entity.ToTable("P93 DIEU CHUYEN");
                        
                            entity.Property(e => e.CTGS).HasColumnName("CTGS").HasMaxLength(50);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(30);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(100);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVu).HasColumnName("MaNVu").HasMaxLength(50);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.P93DBit1).HasColumnName("P93DBit1");
                        
                            entity.Property(e => e.P93DBit2).HasColumnName("P93DBit2");
                        
                            entity.Property(e => e.P93DBit3).HasColumnName("P93DBit3");
                        
                            entity.Property(e => e.P93DBit4).HasColumnName("P93DBit4");
                        
                            entity.Property(e => e.P93DBit5).HasColumnName("P93DBit5");
                        
                            entity.Property(e => e.P93DDate1).HasColumnName("P93DDate1");
                        
                            entity.Property(e => e.P93DDate2).HasColumnName("P93DDate2");
                        
                            entity.Property(e => e.P93DDate3).HasColumnName("P93DDate3");
                        
                            entity.Property(e => e.P93DDate4).HasColumnName("P93DDate4");
                        
                            entity.Property(e => e.P93DDate5).HasColumnName("P93DDate5");
                        
                            entity.Property(e => e.P93DInt1).HasColumnName("P93DInt1");
                        
                            entity.Property(e => e.P93DInt2).HasColumnName("P93DInt2");
                        
                            entity.Property(e => e.P93DInt3).HasColumnName("P93DInt3");
                        
                            entity.Property(e => e.P93DInt4).HasColumnName("P93DInt4");
                        
                            entity.Property(e => e.P93DInt5).HasColumnName("P93DInt5");
                        
                            entity.Property(e => e.P93DNumber1).HasColumnName("P93DNumber1");
                        
                            entity.Property(e => e.P93DNumber2).HasColumnName("P93DNumber2");
                        
                            entity.Property(e => e.P93DNumber3).HasColumnName("P93DNumber3");
                        
                            entity.Property(e => e.P93DNumber4).HasColumnName("P93DNumber4");
                        
                            entity.Property(e => e.P93DNumber5).HasColumnName("P93DNumber5");
                        
                            entity.Property(e => e.P93DString1).HasColumnName("P93DString1").HasMaxLength(250);
                        
                            entity.Property(e => e.P93DString2).HasColumnName("P93DString2").HasMaxLength(250);
                        
                            entity.Property(e => e.P93DString3).HasColumnName("P93DString3").HasMaxLength(250);
                        
                            entity.Property(e => e.P93DString4).HasColumnName("P93DString4").HasMaxLength(250);
                        
                            entity.Property(e => e.P93DString5).HasColumnName("P93DString5").HasMaxLength(250);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RecXL).HasColumnName("RecXL").HasMaxLength(100);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<P93_ZCHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("P93 ZCHI TIET");
                        
                            entity.Property(e => e.ChenhLech).HasColumnName("ChenhLech").HasMaxLength(250);
                        
                            entity.Property(e => e.DenPhongBan).HasColumnName("DenPhongBan").HasMaxLength(150);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.GiaTriHienTai).HasColumnName("GiaTriHienTai").HasMaxLength(250);
                        
                            entity.Property(e => e.GiaTriMoi).HasColumnName("GiaTriMoi").HasMaxLength(250);
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(30);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDTTHCP).HasColumnName("MaDTTHCP").HasMaxLength(100);
                        
                            entity.Property(e => e.MaThongKe).HasColumnName("MaThongKe").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(30);
                        
                            entity.Property(e => e.MaTKCP).HasColumnName("MaTKCP").HasMaxLength(30);
                        
                            entity.Property(e => e.MaTS).HasColumnName("MaTS").HasMaxLength(150);
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NguyenGia).HasColumnName("NguyenGia");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RecXL).HasColumnName("RecXL").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.TenQuyCach).HasColumnName("TenQuyCach").HasMaxLength(250);
                        
                            entity.Property(e => e.ThoiGianBH).HasColumnName("ThoiGianBH").HasMaxLength(250);
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TuPhongBan).HasColumnName("TuPhongBan").HasMaxLength(150);
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                    });
                    
                    modelBuilder.Entity<PALL_LENH_DX>(entity =>
                    {
                        entity.HasKey(e => e.IDP);
                        entity.ToTable("PALL LENH DX");
                        
                            entity.Property(e => e.CangCT).HasColumnName("CangCT").HasMaxLength(250);
                        
                            entity.Property(e => e.CangDen).HasColumnName("CangDen").HasMaxLength(250);
                        
                            entity.Property(e => e.CangDi).HasColumnName("CangDi").HasMaxLength(250);
                        
                            entity.Property(e => e.ChuHang).HasColumnName("ChuHang").HasMaxLength(150);
                        
                            entity.Property(e => e.DauThucTe).HasColumnName("DauThucTe");
                        
                            entity.Property(e => e.DGDau).HasColumnName("DGDau");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DMDau).HasColumnName("DMDau");
                        
                            entity.Property(e => e.DonDatHang).HasColumnName("DonDatHang").HasMaxLength(150);
                        
                            entity.Property(e => e.DongHang).HasColumnName("DongHang").HasMaxLength(250);
                        
                            entity.Property(e => e.DonGiaVC).HasColumnName("DonGiaVC");
                        
                            entity.Property(e => e.DonGiaXN).HasColumnName("DonGiaXN");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(150);
                        
                            entity.Property(e => e.GioGiao).HasColumnName("GioGiao");
                        
                            entity.Property(e => e.GioNhan).HasColumnName("GioNhan");
                        
                            entity.Property(e => e.HangTau).HasColumnName("HangTau").HasMaxLength(250);
                        
                            entity.Property(e => e.IDP).HasColumnName("IDP");
                        
                            entity.Property(e => e.KhoiLuong).HasColumnName("KhoiLuong");
                        
                            entity.Property(e => e.LoaiNX).HasColumnName("LoaiNX").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(10);
                        
                            entity.Property(e => e.MaBangGia).HasColumnName("MaBangGia").HasMaxLength(150);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVienDX).HasColumnName("MaNVienDX").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayBOB).HasColumnName("NgayBOB");
                        
                            entity.Property(e => e.NgayCatMang).HasColumnName("NgayCatMang");
                        
                            entity.Property(e => e.NgayDi).HasColumnName("NgayDi");
                        
                            entity.Property(e => e.NgayDXTC).HasColumnName("NgayDXTC");
                        
                            entity.Property(e => e.NgayGiao).HasColumnName("NgayGiao");
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.NgayNhan).HasColumnName("NgayNhan");
                        
                            entity.Property(e => e.NgayVe).HasColumnName("NgayVe");
                        
                            entity.Property(e => e.NhomHang).HasColumnName("NhomHang").HasMaxLength(150);
                        
                            entity.Property(e => e.NoiHa).HasColumnName("NoiHa").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiNhan).HasColumnName("NoiNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.PhuXe).HasColumnName("PhuXe").HasMaxLength(250);
                        
                            entity.Property(e => e.RecDX).HasColumnName("RecDX").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RecXL).HasColumnName("RecXL").HasMaxLength(100);
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.SoXe).HasColumnName("SoXe").HasMaxLength(50);
                        
                            entity.Property(e => e.TaiXe).HasColumnName("TaiXe").HasMaxLength(100);
                        
                            entity.Property(e => e.TamUng).HasColumnName("TamUng");
                        
                            entity.Property(e => e.TamUngTX).HasColumnName("TamUngTX");
                        
                            entity.Property(e => e.TauChuyenTai).HasColumnName("TauChuyenTai").HasMaxLength(250);
                        
                            entity.Property(e => e.TenTau).HasColumnName("TenTau").HasMaxLength(250);
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(250);
                        
                            entity.Property(e => e.ThanhTienVC).HasColumnName("ThanhTienVC");
                        
                            entity.Property(e => e.ThanhTienXN).HasColumnName("ThanhTienXN");
                        
                            entity.Property(e => e.TongSL).HasColumnName("TongSL");
                        
                            entity.Property(e => e.TrangThaiLDX).HasColumnName("TrangThaiLDX").HasMaxLength(250);
                        
                            entity.Property(e => e.TuyenDuong).HasColumnName("TuyenDuong").HasMaxLength(250);
                        
                            entity.Property(e => e.VaoThu).HasColumnName("VaoThu").HasMaxLength(150);
                        
                            entity.Property(e => e.XeNgoai).HasColumnName("XeNgoai");
                        
                    });
                    
                    modelBuilder.Entity<PALL_TO_KHAI_CT>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("PALL TO KHAI CT");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.ContRong).HasColumnName("ContRong");
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.DonGiaNT).HasColumnName("DonGiaNT");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.DVTKien).HasColumnName("DVTKien").HasMaxLength(100);
                        
                            entity.Property(e => e.GhiChuCont).HasColumnName("GhiChuCont").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuHH).HasColumnName("GhiChuHH").HasMaxLength(-1);
                        
                            entity.Property(e => e.HangGhep).HasColumnName("HangGhep");
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.KhoiLuong).HasColumnName("KhoiLuong");
                        
                            entity.Property(e => e.LoaiCont).HasColumnName("LoaiCont").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiCT).HasColumnName("LoaiCT").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiKien).HasColumnName("LoaiKien").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVienKD).HasColumnName("MaNVienKD").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSoHang).HasColumnName("MaSoHang").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayGiao).HasColumnName("NgayGiao");
                        
                            entity.Property(e => e.NgayLay).HasColumnName("NgayLay");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NoiGiao).HasColumnName("NoiGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.NoiLay).HasColumnName("NoiLay").HasMaxLength(100);
                        
                            entity.Property(e => e.PALLTKCTB1).HasColumnName("PALLTKCTB1");
                        
                            entity.Property(e => e.PALLTKCTB2).HasColumnName("PALLTKCTB2");
                        
                            entity.Property(e => e.PALLTKCTB3).HasColumnName("PALLTKCTB3");
                        
                            entity.Property(e => e.PALLTKCTB4).HasColumnName("PALLTKCTB4");
                        
                            entity.Property(e => e.PALLTKCTB5).HasColumnName("PALLTKCTB5");
                        
                            entity.Property(e => e.PALLTKCTD1).HasColumnName("PALLTKCTD1");
                        
                            entity.Property(e => e.PALLTKCTD2).HasColumnName("PALLTKCTD2");
                        
                            entity.Property(e => e.PALLTKCTD3).HasColumnName("PALLTKCTD3");
                        
                            entity.Property(e => e.PALLTKCTD4).HasColumnName("PALLTKCTD4");
                        
                            entity.Property(e => e.PALLTKCTD5).HasColumnName("PALLTKCTD5");
                        
                            entity.Property(e => e.PALLTKCTI1).HasColumnName("PALLTKCTI1");
                        
                            entity.Property(e => e.PALLTKCTI2).HasColumnName("PALLTKCTI2");
                        
                            entity.Property(e => e.PALLTKCTI3).HasColumnName("PALLTKCTI3");
                        
                            entity.Property(e => e.PALLTKCTI4).HasColumnName("PALLTKCTI4");
                        
                            entity.Property(e => e.PALLTKCTI5).HasColumnName("PALLTKCTI5");
                        
                            entity.Property(e => e.PALLTKCTN1).HasColumnName("PALLTKCTN1");
                        
                            entity.Property(e => e.PALLTKCTN10).HasColumnName("PALLTKCTN10");
                        
                            entity.Property(e => e.PALLTKCTN2).HasColumnName("PALLTKCTN2");
                        
                            entity.Property(e => e.PALLTKCTN3).HasColumnName("PALLTKCTN3");
                        
                            entity.Property(e => e.PALLTKCTN4).HasColumnName("PALLTKCTN4");
                        
                            entity.Property(e => e.PALLTKCTN5).HasColumnName("PALLTKCTN5");
                        
                            entity.Property(e => e.PALLTKCTN6).HasColumnName("PALLTKCTN6");
                        
                            entity.Property(e => e.PALLTKCTN7).HasColumnName("PALLTKCTN7");
                        
                            entity.Property(e => e.PALLTKCTN8).HasColumnName("PALLTKCTN8");
                        
                            entity.Property(e => e.PALLTKCTN9).HasColumnName("PALLTKCTN9");
                        
                            entity.Property(e => e.PALLTKCTS1).HasColumnName("PALLTKCTS1").HasMaxLength(100);
                        
                            entity.Property(e => e.PALLTKCTS10).HasColumnName("PALLTKCTS10").HasMaxLength(250);
                        
                            entity.Property(e => e.PALLTKCTS11).HasColumnName("PALLTKCTS11").HasMaxLength(250);
                        
                            entity.Property(e => e.PALLTKCTS12).HasColumnName("PALLTKCTS12").HasMaxLength(-1);
                        
                            entity.Property(e => e.PALLTKCTS13).HasColumnName("PALLTKCTS13").HasMaxLength(-1);
                        
                            entity.Property(e => e.PALLTKCTS14).HasColumnName("PALLTKCTS14").HasMaxLength(-1);
                        
                            entity.Property(e => e.PALLTKCTS15).HasColumnName("PALLTKCTS15").HasMaxLength(-1);
                        
                            entity.Property(e => e.PALLTKCTS2).HasColumnName("PALLTKCTS2").HasMaxLength(100);
                        
                            entity.Property(e => e.PALLTKCTS3).HasColumnName("PALLTKCTS3").HasMaxLength(100);
                        
                            entity.Property(e => e.PALLTKCTS4).HasColumnName("PALLTKCTS4").HasMaxLength(150);
                        
                            entity.Property(e => e.PALLTKCTS5).HasColumnName("PALLTKCTS5").HasMaxLength(150);
                        
                            entity.Property(e => e.PALLTKCTS6).HasColumnName("PALLTKCTS6").HasMaxLength(150);
                        
                            entity.Property(e => e.PALLTKCTS7).HasColumnName("PALLTKCTS7").HasMaxLength(250);
                        
                            entity.Property(e => e.PALLTKCTS8).HasColumnName("PALLTKCTS8").HasMaxLength(250);
                        
                            entity.Property(e => e.PALLTKCTS9).HasColumnName("PALLTKCTS9").HasMaxLength(250);
                        
                            entity.Property(e => e.RecHaRong).HasColumnName("RecHaRong").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYBK).HasColumnName("RECKEYBK").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYCK).HasColumnName("RECKEYCK").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYCT).HasColumnName("RECKEYCT").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYHH).HasColumnName("RECKEYHH").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYLH).HasColumnName("RECKEYLH").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLayCont).HasColumnName("RecLayCont").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLoaiCont).HasColumnName("RecLoaiCont").HasMaxLength(100);
                        
                            entity.Property(e => e.RecNoiGiao).HasColumnName("RecNoiGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.RecNoiLay).HasColumnName("RecNoiLay").HasMaxLength(100);
                        
                            entity.Property(e => e.RecSoBOB).HasColumnName("RecSoBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.RecSoTK).HasColumnName("RecSoTK").HasMaxLength(100);
                        
                            entity.Property(e => e.RecTuyen).HasColumnName("RecTuyen").HasMaxLength(100);
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.SoCont).HasColumnName("SoCont").HasMaxLength(100);
                        
                            entity.Property(e => e.SoKhoi).HasColumnName("SoKhoi");
                        
                            entity.Property(e => e.SoKien).HasColumnName("SoKien").HasMaxLength(150);
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoLuongCont).HasColumnName("SoLuongCont");
                        
                            entity.Property(e => e.SoSeal).HasColumnName("SoSeal").HasMaxLength(150);
                        
                            entity.Property(e => e.SoToKhai).HasColumnName("SoToKhai").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenCont).HasColumnName("TenCont").HasMaxLength(250);
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(250);
                        
                            entity.Property(e => e.ThueKhac).HasColumnName("ThueKhac");
                        
                            entity.Property(e => e.ThueNK).HasColumnName("ThueNK");
                        
                            entity.Property(e => e.ThueTTDB).HasColumnName("ThueTTDB");
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TienHoaHong).HasColumnName("TienHoaHong");
                        
                            entity.Property(e => e.TienKhac).HasColumnName("TienKhac");
                        
                            entity.Property(e => e.TienThueNK).HasColumnName("TienThueNK");
                        
                            entity.Property(e => e.TienThueTTDB).HasColumnName("TienThueTTDB");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TriGiaTinhThue).HasColumnName("TriGiaTinhThue");
                        
                            entity.Property(e => e.TuyenDuong).HasColumnName("TuyenDuong").HasMaxLength(100);
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyLeHH).HasColumnName("TyLeHH");
                        
                            entity.Property(e => e.XuatXu).HasColumnName("XuatXu").HasMaxLength(150);
                        
                    });
                    
                    modelBuilder.Entity<PALL_VAT_BAN_RA>(entity =>
                    {
                        entity.HasKey(e => e.IDP);
                        entity.ToTable("PALL VAT BAN RA");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(255);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(50);
                        
                            entity.Property(e => e.GiaChuaThue).HasColumnName("GiaChuaThue");
                        
                            entity.Property(e => e.GiaThanhToan).HasColumnName("GiaThanhToan");
                        
                            entity.Property(e => e.IDP).HasColumnName("IDP");
                        
                            entity.Property(e => e.KyHieu).HasColumnName("KyHieu").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(100);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSoThue).HasColumnName("MaSoThue").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTien).HasColumnName("MaTien").HasMaxLength(40);
                        
                            entity.Property(e => e.MaTinhThue).HasColumnName("MaTinhThue").HasMaxLength(1);
                        
                            entity.Property(e => e.Mau).HasColumnName("Mau").HasMaxLength(2);
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.NguyenTe).HasColumnName("NguyenTe");
                        
                            entity.Property(e => e.NoiDung).HasColumnName("NoiDung").HasMaxLength(255);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(50);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.SoTien).HasColumnName("SoTien");
                        
                            entity.Property(e => e.TenKH).HasColumnName("TenKH").HasMaxLength(255);
                        
                            entity.Property(e => e.Thang).HasColumnName("Thang").HasMaxLength(2);
                        
                            entity.Property(e => e.ThueSuat).HasColumnName("ThueSuat");
                        
                    });
                    
                    modelBuilder.Entity<PALL_VAT_MUA_VAO>(entity =>
                    {
                        entity.HasKey(e => e.IDP);
                        entity.ToTable("PALL VAT MUA VAO");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(255);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GiaChuaThue).HasColumnName("GiaChuaThue");
                        
                            entity.Property(e => e.GiaThanhToan).HasColumnName("GiaThanhToan");
                        
                            entity.Property(e => e.IDP).HasColumnName("IDP");
                        
                            entity.Property(e => e.KyHieu).HasColumnName("KyHieu").HasMaxLength(50);
                        
                            entity.Property(e => e.KyHieuMau).HasColumnName("KyHieuMau").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(100);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaHoaDon).HasColumnName("MaHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSoThue).HasColumnName("MaSoThue").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(40);
                        
                            entity.Property(e => e.MaTinhThue).HasColumnName("MaTinhThue").HasMaxLength(2);
                        
                            entity.Property(e => e.Mau).HasColumnName("Mau").HasMaxLength(2);
                        
                            entity.Property(e => e.NgayHD).HasColumnName("NgayHD");
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.NguyenTe).HasColumnName("NguyenTe");
                        
                            entity.Property(e => e.NoiDung).HasColumnName("NoiDung").HasMaxLength(255);
                        
                            entity.Property(e => e.PALLCKTruong1).HasColumnName("PALLCKTruong1");
                        
                            entity.Property(e => e.PALLCKTruong2).HasColumnName("PALLCKTruong2");
                        
                            entity.Property(e => e.PALLCKTruong3).HasColumnName("PALLCKTruong3");
                        
                            entity.Property(e => e.PALLDTruong1).HasColumnName("PALLDTruong1");
                        
                            entity.Property(e => e.PALLDTruong2).HasColumnName("PALLDTruong2");
                        
                            entity.Property(e => e.PALLDTruong3).HasColumnName("PALLDTruong3");
                        
                            entity.Property(e => e.PALLNTruong1).HasColumnName("PALLNTruong1");
                        
                            entity.Property(e => e.PALLNTruong2).HasColumnName("PALLNTruong2");
                        
                            entity.Property(e => e.PALLNTruong3).HasColumnName("PALLNTruong3");
                        
                            entity.Property(e => e.PALLNTruong4).HasColumnName("PALLNTruong4");
                        
                            entity.Property(e => e.PALLNTruong5).HasColumnName("PALLNTruong5");
                        
                            entity.Property(e => e.PALLSTruong1).HasColumnName("PALLSTruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.PALLSTruong2).HasColumnName("PALLSTruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.PALLSTruong3).HasColumnName("PALLSTruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.PALLSTruong4).HasColumnName("PALLSTruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.PALLSTruong5).HasColumnName("PALLSTruong5").HasMaxLength(250);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(50);
                        
                            entity.Property(e => e.SoHoaDon).HasColumnName("SoHoaDon").HasMaxLength(50);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(30);
                        
                            entity.Property(e => e.TenKH).HasColumnName("TenKH").HasMaxLength(255);
                        
                            entity.Property(e => e.Thang).HasColumnName("Thang").HasMaxLength(2);
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                    });
                    
                    modelBuilder.Entity<PALL_VAN_DON_CT>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("PALL_VAN_DON_CT");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.ChuVanDon).HasColumnName("ChuVanDon").HasMaxLength(100);
                        
                            entity.Property(e => e.ContRong).HasColumnName("ContRong");
                        
                            entity.Property(e => e.DiaChiLayCont).HasColumnName("DiaChiLayCont").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiTraCont).HasColumnName("DiaChiTraCont").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiTraVo).HasColumnName("DiaChiTraVo").HasMaxLength(250);
                        
                            entity.Property(e => e.DiemLayCont).HasColumnName("DiemLayCont").HasMaxLength(100);
                        
                            entity.Property(e => e.DiemTraCont).HasColumnName("DiemTraCont").HasMaxLength(100);
                        
                            entity.Property(e => e.DiemTraVo).HasColumnName("DiemTraVo").HasMaxLength(100);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.DonGiaNT).HasColumnName("DonGiaNT");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.DVTKien).HasColumnName("DVTKien").HasMaxLength(100);
                        
                            entity.Property(e => e.GhiChuCont).HasColumnName("GhiChuCont").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChuHH).HasColumnName("GhiChuHH").HasMaxLength(-1);
                        
                            entity.Property(e => e.HangGhep).HasColumnName("HangGhep");
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.KhoiLuong).HasColumnName("KhoiLuong");
                        
                            entity.Property(e => e.LoaiCont).HasColumnName("LoaiCont").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiCT).HasColumnName("LoaiCT").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVienKD).HasColumnName("MaNVienKD").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSoHang).HasColumnName("MaSoHang").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(50);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(100);
                        
                            entity.Property(e => e.MoTaHH).HasColumnName("MoTaHH").HasMaxLength(-1);
                        
                            entity.Property(e => e.NgayGiao).HasColumnName("NgayGiao");
                        
                            entity.Property(e => e.NgayLay).HasColumnName("NgayLay");
                        
                            entity.Property(e => e.NgayLayCont).HasColumnName("NgayLayCont");
                        
                            entity.Property(e => e.NgayTraCont).HasColumnName("NgayTraCont");
                        
                            entity.Property(e => e.NgayTraVo).HasColumnName("NgayTraVo");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NoiGiao).HasColumnName("NoiGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.NoiLay).HasColumnName("NoiLay").HasMaxLength(100);
                        
                            entity.Property(e => e.PALLVDCTB1).HasColumnName("PALLVDCTB1");
                        
                            entity.Property(e => e.PALLVDCTB2).HasColumnName("PALLVDCTB2");
                        
                            entity.Property(e => e.PALLVDCTB3).HasColumnName("PALLVDCTB3");
                        
                            entity.Property(e => e.PALLVDCTB4).HasColumnName("PALLVDCTB4");
                        
                            entity.Property(e => e.PALLVDCTB5).HasColumnName("PALLVDCTB5");
                        
                            entity.Property(e => e.PALLVDCTD1).HasColumnName("PALLVDCTD1");
                        
                            entity.Property(e => e.PALLVDCTD2).HasColumnName("PALLVDCTD2");
                        
                            entity.Property(e => e.PALLVDCTD3).HasColumnName("PALLVDCTD3");
                        
                            entity.Property(e => e.PALLVDCTD4).HasColumnName("PALLVDCTD4");
                        
                            entity.Property(e => e.PALLVDCTD5).HasColumnName("PALLVDCTD5");
                        
                            entity.Property(e => e.PALLVDCTI1).HasColumnName("PALLVDCTI1");
                        
                            entity.Property(e => e.PALLVDCTI2).HasColumnName("PALLVDCTI2");
                        
                            entity.Property(e => e.PALLVDCTI3).HasColumnName("PALLVDCTI3");
                        
                            entity.Property(e => e.PALLVDCTI4).HasColumnName("PALLVDCTI4");
                        
                            entity.Property(e => e.PALLVDCTI5).HasColumnName("PALLVDCTI5");
                        
                            entity.Property(e => e.PALLVDCTN1).HasColumnName("PALLVDCTN1");
                        
                            entity.Property(e => e.PALLVDCTN10).HasColumnName("PALLVDCTN10");
                        
                            entity.Property(e => e.PALLVDCTN2).HasColumnName("PALLVDCTN2");
                        
                            entity.Property(e => e.PALLVDCTN3).HasColumnName("PALLVDCTN3");
                        
                            entity.Property(e => e.PALLVDCTN4).HasColumnName("PALLVDCTN4");
                        
                            entity.Property(e => e.PALLVDCTN5).HasColumnName("PALLVDCTN5");
                        
                            entity.Property(e => e.PALLVDCTN6).HasColumnName("PALLVDCTN6");
                        
                            entity.Property(e => e.PALLVDCTN7).HasColumnName("PALLVDCTN7");
                        
                            entity.Property(e => e.PALLVDCTN8).HasColumnName("PALLVDCTN8");
                        
                            entity.Property(e => e.PALLVDCTN9).HasColumnName("PALLVDCTN9");
                        
                            entity.Property(e => e.PALLVDCTS1).HasColumnName("PALLVDCTS1").HasMaxLength(100);
                        
                            entity.Property(e => e.PALLVDCTS10).HasColumnName("PALLVDCTS10").HasMaxLength(250);
                        
                            entity.Property(e => e.PALLVDCTS11).HasColumnName("PALLVDCTS11").HasMaxLength(250);
                        
                            entity.Property(e => e.PALLVDCTS12).HasColumnName("PALLVDCTS12").HasMaxLength(-1);
                        
                            entity.Property(e => e.PALLVDCTS13).HasColumnName("PALLVDCTS13").HasMaxLength(-1);
                        
                            entity.Property(e => e.PALLVDCTS14).HasColumnName("PALLVDCTS14").HasMaxLength(-1);
                        
                            entity.Property(e => e.PALLVDCTS15).HasColumnName("PALLVDCTS15").HasMaxLength(-1);
                        
                            entity.Property(e => e.PALLVDCTS2).HasColumnName("PALLVDCTS2").HasMaxLength(100);
                        
                            entity.Property(e => e.PALLVDCTS3).HasColumnName("PALLVDCTS3").HasMaxLength(100);
                        
                            entity.Property(e => e.PALLVDCTS4).HasColumnName("PALLVDCTS4").HasMaxLength(150);
                        
                            entity.Property(e => e.PALLVDCTS5).HasColumnName("PALLVDCTS5").HasMaxLength(150);
                        
                            entity.Property(e => e.PALLVDCTS6).HasColumnName("PALLVDCTS6").HasMaxLength(150);
                        
                            entity.Property(e => e.PALLVDCTS7).HasColumnName("PALLVDCTS7").HasMaxLength(250);
                        
                            entity.Property(e => e.PALLVDCTS8).HasColumnName("PALLVDCTS8").HasMaxLength(250);
                        
                            entity.Property(e => e.PALLVDCTS9).HasColumnName("PALLVDCTS9").HasMaxLength(250);
                        
                            entity.Property(e => e.RecHaRong).HasColumnName("RecHaRong").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYBK).HasColumnName("RECKEYBK").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYCK).HasColumnName("RECKEYCK").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYCT).HasColumnName("RECKEYCT").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYHH).HasColumnName("RECKEYHH").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYVD).HasColumnName("RECKEYVD").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLayCont).HasColumnName("RecLayCont").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLoaiCont).HasColumnName("RecLoaiCont").HasMaxLength(100);
                        
                            entity.Property(e => e.RecNoiGiao).HasColumnName("RecNoiGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.RecNoiLay).HasColumnName("RecNoiLay").HasMaxLength(100);
                        
                            entity.Property(e => e.RecTuyen).HasColumnName("RecTuyen").HasMaxLength(100);
                        
                            entity.Property(e => e.SLGross).HasColumnName("SLGross");
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(100);
                        
                            entity.Property(e => e.SoCont).HasColumnName("SoCont").HasMaxLength(100);
                        
                            entity.Property(e => e.SoKhoi).HasColumnName("SoKhoi");
                        
                            entity.Property(e => e.SoKien).HasColumnName("SoKien");
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.SoLuongCont).HasColumnName("SoLuongCont");
                        
                            entity.Property(e => e.SoSeal).HasColumnName("SoSeal").HasMaxLength(150);
                        
                            entity.Property(e => e.SoToKhai).HasColumnName("SoToKhai").HasMaxLength(100);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenCont).HasColumnName("TenCont").HasMaxLength(250);
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(250);
                        
                            entity.Property(e => e.ThueKhac).HasColumnName("ThueKhac");
                        
                            entity.Property(e => e.ThueNK).HasColumnName("ThueNK");
                        
                            entity.Property(e => e.ThueTTDB).HasColumnName("ThueTTDB");
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT");
                        
                            entity.Property(e => e.TienHoaHong).HasColumnName("TienHoaHong");
                        
                            entity.Property(e => e.TienKhac).HasColumnName("TienKhac");
                        
                            entity.Property(e => e.TienThueNK).HasColumnName("TienThueNK");
                        
                            entity.Property(e => e.TienThueTTDB).HasColumnName("TienThueTTDB");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TriGiaTinhThue).HasColumnName("TriGiaTinhThue");
                        
                            entity.Property(e => e.TuyenDuong).HasColumnName("TuyenDuong").HasMaxLength(100);
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.TyLeHH).HasColumnName("TyLeHH");
                        
                            entity.Property(e => e.XuatXu).HasColumnName("XuatXu").HasMaxLength(150);
                        
                    });
                    
                    modelBuilder.Entity<PG11_CHUNG_TU_GS>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("PG11 CHUNG TU GS");
                        
                            entity.Property(e => e.CTGS).HasColumnName("CTGS").HasMaxLength(50);
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCT).HasColumnName("MaCT").HasMaxLength(20);
                        
                            entity.Property(e => e.NgayCT).HasColumnName("NgayCT");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.NoiDung).HasColumnName("NoiDung").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiDung2).HasColumnName("NoiDung2").HasMaxLength(250);
                        
                            entity.Property(e => e.PG11Check1).HasColumnName("PG11Check1");
                        
                            entity.Property(e => e.PG11Check2).HasColumnName("PG11Check2");
                        
                            entity.Property(e => e.PG11Check3).HasColumnName("PG11Check3");
                        
                            entity.Property(e => e.PG11Date1).HasColumnName("PG11Date1");
                        
                            entity.Property(e => e.PG11Date2).HasColumnName("PG11Date2");
                        
                            entity.Property(e => e.PG11Date3).HasColumnName("PG11Date3");
                        
                            entity.Property(e => e.PG11Number1).HasColumnName("PG11Number1");
                        
                            entity.Property(e => e.PG11Number2).HasColumnName("PG11Number2");
                        
                            entity.Property(e => e.PG11Number3).HasColumnName("PG11Number3");
                        
                            entity.Property(e => e.PG11Number4).HasColumnName("PG11Number4");
                        
                            entity.Property(e => e.PG11Number5).HasColumnName("PG11Number5");
                        
                            entity.Property(e => e.PG11String1).HasColumnName("PG11String1").HasMaxLength(250);
                        
                            entity.Property(e => e.PG11String2).HasColumnName("PG11String2").HasMaxLength(250);
                        
                            entity.Property(e => e.PG11String3).HasColumnName("PG11String3").HasMaxLength(250);
                        
                            entity.Property(e => e.PG11String4).HasColumnName("PG11String4").HasMaxLength(250);
                        
                            entity.Property(e => e.PG11String5).HasColumnName("PG11String5").HasMaxLength(250);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(50);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<PG12_CHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("PG12 CHI TIET");
                        
                            entity.Property(e => e.CTGS).HasColumnName("CTGS").HasMaxLength(50);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.GP12Check1).HasColumnName("GP12Check1");
                        
                            entity.Property(e => e.GP12Check2).HasColumnName("GP12Check2");
                        
                            entity.Property(e => e.GP12Check3).HasColumnName("GP12Check3");
                        
                            entity.Property(e => e.GP12Date1).HasColumnName("GP12Date1");
                        
                            entity.Property(e => e.GP12Date2).HasColumnName("GP12Date2");
                        
                            entity.Property(e => e.GP12Date3).HasColumnName("GP12Date3");
                        
                            entity.Property(e => e.GP12Number1).HasColumnName("GP12Number1");
                        
                            entity.Property(e => e.GP12Number2).HasColumnName("GP12Number2");
                        
                            entity.Property(e => e.GP12Number3).HasColumnName("GP12Number3");
                        
                            entity.Property(e => e.GP12Number4).HasColumnName("GP12Number4");
                        
                            entity.Property(e => e.GP12Number5).HasColumnName("GP12Number5");
                        
                            entity.Property(e => e.GP12String1).HasColumnName("GP12String1").HasMaxLength(250);
                        
                            entity.Property(e => e.GP12String2).HasColumnName("GP12String2").HasMaxLength(250);
                        
                            entity.Property(e => e.GP12String3).HasColumnName("GP12String3").HasMaxLength(250);
                        
                            entity.Property(e => e.GP12String4).HasColumnName("GP12String4").HasMaxLength(250);
                        
                            entity.Property(e => e.GP12String5).HasColumnName("GP12String5").HasMaxLength(250);
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCT).HasColumnName("MaCT").HasMaxLength(20);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKCo).HasColumnName("MaTKCo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTKNo).HasColumnName("MaTKNo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaXL).HasColumnName("MaXL").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayCT).HasColumnName("NgayCT");
                        
                            entity.Property(e => e.NgayHT).HasColumnName("NgayHT");
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(50);
                        
                            entity.Property(e => e.SoCT).HasColumnName("SoCT").HasMaxLength(50);
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                    });
                    
                    //Unable to generate entity type for table 'dbo.PG21 LIST CT'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.PG21 LIST CTTH'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.PNX CHON LOT'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.PTC CHON TTOAN '. table have no primary key
                    
                    modelBuilder.Entity<PZ11_KIEM_KE>(entity =>
                    {
                        entity.HasKey(e => e.IDPZ11);
                        entity.ToTable("PZ11 KIEM KE");
                        
                            entity.Property(e => e.DaDieuChinh).HasColumnName("DaDieuChinh");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.GiaTri).HasColumnName("GiaTri");
                        
                            entity.Property(e => e.IDPZ11).HasColumnName("IDPZ11");
                        
                            entity.Property(e => e.KhoAll).HasColumnName("KhoAll");
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(10);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(60);
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.Reckey).HasColumnName("Reckey").HasMaxLength(30);
                        
                            entity.Property(e => e.ReckeyPNK).HasColumnName("ReckeyPNK").HasMaxLength(100);
                        
                            entity.Property(e => e.ReckeyPXK).HasColumnName("ReckeyPXK").HasMaxLength(100);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(30);
                        
                            entity.Property(e => e.TKGhiGiam).HasColumnName("TKGhiGiam").HasMaxLength(50);
                        
                            entity.Property(e => e.TKGhiTang).HasColumnName("TKGhiTang").HasMaxLength(50);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(30);
                        
                    });
                    
                    modelBuilder.Entity<PZ12_CHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.IDPZ12);
                        entity.ToTable("PZ12 CHI TIET");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.IDPZ12).HasColumnName("IDPZ12");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(100);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(50);
                        
                            entity.Property(e => e.Reckey).HasColumnName("Reckey").HasMaxLength(30);
                        
                            entity.Property(e => e.SLChenhLech).HasColumnName("SLChenhLech");
                        
                            entity.Property(e => e.SLDau).HasColumnName("SLDau");
                        
                            entity.Property(e => e.SLNhap).HasColumnName("SLNhap");
                        
                            entity.Property(e => e.SLThucTe).HasColumnName("SLThucTe");
                        
                            entity.Property(e => e.SLTon).HasColumnName("SLTon");
                        
                            entity.Property(e => e.SLXuat).HasColumnName("SLXuat");
                        
                            entity.Property(e => e.STChenhLech).HasColumnName("STChenhLech");
                        
                            entity.Property(e => e.STT).HasColumnName("STT").HasMaxLength(10);
                        
                            entity.Property(e => e.STThucTe).HasColumnName("STThucTe");
                        
                            entity.Property(e => e.STTon).HasColumnName("STTon");
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<PZ21_SO_DU>(entity =>
                    {
                        entity.HasKey(e => e.IDPZ21);
                        entity.ToTable("PZ21 SO DU");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDPZ21).HasColumnName("IDPZ21");
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaKH).HasColumnName("MaKH").HasMaxLength(150);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(150);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(150);
                        
                            entity.Property(e => e.MaNVu).HasColumnName("MaNVu").HasMaxLength(150);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(150);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(60);
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.Reckey).HasColumnName("Reckey").HasMaxLength(30);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(30);
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(30);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(30);
                        
                    });
                    
                    modelBuilder.Entity<PZ22_CHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.IDPZ22);
                        entity.ToTable("PZ22 CHI TIET");
                        
                            entity.Property(e => e.CTTRUNG).HasColumnName("CTTRUNG");
                        
                            entity.Property(e => e.DateLot).HasColumnName("DateLot").HasMaxLength(50);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(255);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(255);
                        
                            entity.Property(e => e.DonGia).HasColumnName("DonGia");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.HopDong).HasColumnName("HopDong").HasMaxLength(50);
                        
                            entity.Property(e => e.IDPZ22).HasColumnName("IDPZ22");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaCTLQ).HasColumnName("MaCTLQ").HasMaxLength(3);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MaKHCo).HasColumnName("MaKHCo").HasMaxLength(150);
                        
                            entity.Property(e => e.MaKHNo).HasColumnName("MaKHNo").HasMaxLength(150);
                        
                            entity.Property(e => e.MaKho).HasColumnName("MaKho").HasMaxLength(250);
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVu).HasColumnName("MaNVu").HasMaxLength(50);
                        
                            entity.Property(e => e.MaTienTe).HasColumnName("MaTienTe").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTKCo).HasColumnName("MaTKCo").HasMaxLength(20);
                        
                            entity.Property(e => e.MaTKNo).HasColumnName("MaTKNo").HasMaxLength(20);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(250);
                        
                            entity.Property(e => e.NgayHD).HasColumnName("NgayHD").HasMaxLength(20);
                        
                            entity.Property(e => e.NgoaiTe).HasColumnName("NgoaiTe");
                        
                            entity.Property(e => e.PZ22CKTruong1).HasColumnName("PZ22CKTruong1");
                        
                            entity.Property(e => e.PZ22CKTruong2).HasColumnName("PZ22CKTruong2");
                        
                            entity.Property(e => e.PZ22DTruong1).HasColumnName("PZ22DTruong1");
                        
                            entity.Property(e => e.PZ22DTruong2).HasColumnName("PZ22DTruong2");
                        
                            entity.Property(e => e.PZ22DTruong3).HasColumnName("PZ22DTruong3");
                        
                            entity.Property(e => e.PZ22DTruong4).HasColumnName("PZ22DTruong4");
                        
                            entity.Property(e => e.PZ22NTruong1).HasColumnName("PZ22NTruong1");
                        
                            entity.Property(e => e.PZ22NTruong2).HasColumnName("PZ22NTruong2");
                        
                            entity.Property(e => e.PZ22NTruong3).HasColumnName("PZ22NTruong3");
                        
                            entity.Property(e => e.PZ22NTruong4).HasColumnName("PZ22NTruong4");
                        
                            entity.Property(e => e.PZ22STruong1).HasColumnName("PZ22STruong1").HasMaxLength(250);
                        
                            entity.Property(e => e.PZ22STruong2).HasColumnName("PZ22STruong2").HasMaxLength(250);
                        
                            entity.Property(e => e.PZ22STruong3).HasColumnName("PZ22STruong3").HasMaxLength(250);
                        
                            entity.Property(e => e.PZ22STruong4).HasColumnName("PZ22STruong4").HasMaxLength(250);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(30);
                        
                            entity.Property(e => e.SoCTLQ).HasColumnName("SoCTLQ").HasMaxLength(50);
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(250);
                        
                            entity.Property(e => e.SoLuong).HasColumnName("SoLuong");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(250);
                        
                            entity.Property(e => e.TienVND).HasColumnName("TienVND");
                        
                            entity.Property(e => e.TonCK_NgoaiTeCo).HasColumnName("TonCK_NgoaiTeCo");
                        
                            entity.Property(e => e.TonCK_NgoaiTeNo).HasColumnName("TonCK_NgoaiTeNo");
                        
                            entity.Property(e => e.TonCK_SL).HasColumnName("TonCK_SL");
                        
                            entity.Property(e => e.TonCK_TienVNDCo).HasColumnName("TonCK_TienVNDCo");
                        
                            entity.Property(e => e.TonCK_TienVNDNo).HasColumnName("TonCK_TienVNDNo");
                        
                            entity.Property(e => e.TyGia).HasColumnName("TyGia");
                        
                    });
                    
                    modelBuilder.Entity<PZP_CHI_TIET>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("PZP CHI TIET");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CongSoTien).HasColumnName("CongSoTien");
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.PZPCTBit1).HasColumnName("PZPCTBit1");
                        
                            entity.Property(e => e.PZPCTBit2).HasColumnName("PZPCTBit2");
                        
                            entity.Property(e => e.PZPCTBit3).HasColumnName("PZPCTBit3");
                        
                            entity.Property(e => e.PZPCTBit4).HasColumnName("PZPCTBit4");
                        
                            entity.Property(e => e.PZPCTBit5).HasColumnName("PZPCTBit5");
                        
                            entity.Property(e => e.PZPCTDate1).HasColumnName("PZPCTDate1");
                        
                            entity.Property(e => e.PZPCTDate10).HasColumnName("PZPCTDate10");
                        
                            entity.Property(e => e.PZPCTDate2).HasColumnName("PZPCTDate2");
                        
                            entity.Property(e => e.PZPCTDate3).HasColumnName("PZPCTDate3");
                        
                            entity.Property(e => e.PZPCTDate4).HasColumnName("PZPCTDate4");
                        
                            entity.Property(e => e.PZPCTDate5).HasColumnName("PZPCTDate5");
                        
                            entity.Property(e => e.PZPCTDate6).HasColumnName("PZPCTDate6");
                        
                            entity.Property(e => e.PZPCTDate7).HasColumnName("PZPCTDate7");
                        
                            entity.Property(e => e.PZPCTDate8).HasColumnName("PZPCTDate8");
                        
                            entity.Property(e => e.PZPCTDate9).HasColumnName("PZPCTDate9");
                        
                            entity.Property(e => e.PZPCTInt1).HasColumnName("PZPCTInt1");
                        
                            entity.Property(e => e.PZPCTInt2).HasColumnName("PZPCTInt2");
                        
                            entity.Property(e => e.PZPCTInt3).HasColumnName("PZPCTInt3");
                        
                            entity.Property(e => e.PZPCTInt4).HasColumnName("PZPCTInt4");
                        
                            entity.Property(e => e.PZPCTInt5).HasColumnName("PZPCTInt5");
                        
                            entity.Property(e => e.PZPCTNumber1).HasColumnName("PZPCTNumber1");
                        
                            entity.Property(e => e.PZPCTNumber10).HasColumnName("PZPCTNumber10");
                        
                            entity.Property(e => e.PZPCTNumber11).HasColumnName("PZPCTNumber11");
                        
                            entity.Property(e => e.PZPCTNumber12).HasColumnName("PZPCTNumber12");
                        
                            entity.Property(e => e.PZPCTNumber13).HasColumnName("PZPCTNumber13");
                        
                            entity.Property(e => e.PZPCTNumber14).HasColumnName("PZPCTNumber14");
                        
                            entity.Property(e => e.PZPCTNumber15).HasColumnName("PZPCTNumber15");
                        
                            entity.Property(e => e.PZPCTNumber16).HasColumnName("PZPCTNumber16");
                        
                            entity.Property(e => e.PZPCTNumber17).HasColumnName("PZPCTNumber17");
                        
                            entity.Property(e => e.PZPCTNumber18).HasColumnName("PZPCTNumber18");
                        
                            entity.Property(e => e.PZPCTNumber19).HasColumnName("PZPCTNumber19");
                        
                            entity.Property(e => e.PZPCTNumber2).HasColumnName("PZPCTNumber2");
                        
                            entity.Property(e => e.PZPCTNumber20).HasColumnName("PZPCTNumber20");
                        
                            entity.Property(e => e.PZPCTNumber3).HasColumnName("PZPCTNumber3");
                        
                            entity.Property(e => e.PZPCTNumber4).HasColumnName("PZPCTNumber4");
                        
                            entity.Property(e => e.PZPCTNumber5).HasColumnName("PZPCTNumber5");
                        
                            entity.Property(e => e.PZPCTNumber6).HasColumnName("PZPCTNumber6");
                        
                            entity.Property(e => e.PZPCTNumber7).HasColumnName("PZPCTNumber7");
                        
                            entity.Property(e => e.PZPCTNumber8).HasColumnName("PZPCTNumber8");
                        
                            entity.Property(e => e.PZPCTNumber9).HasColumnName("PZPCTNumber9");
                        
                            entity.Property(e => e.PZPCTString1).HasColumnName("PZPCTString1").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPCTString10).HasColumnName("PZPCTString10").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPCTString11).HasColumnName("PZPCTString11").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPCTString12).HasColumnName("PZPCTString12").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPCTString13).HasColumnName("PZPCTString13").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPCTString14).HasColumnName("PZPCTString14").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPCTString15).HasColumnName("PZPCTString15").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPCTString16).HasColumnName("PZPCTString16").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPCTString17).HasColumnName("PZPCTString17").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPCTString18).HasColumnName("PZPCTString18").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPCTString19).HasColumnName("PZPCTString19").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPCTString2).HasColumnName("PZPCTString2").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPCTString20).HasColumnName("PZPCTString20").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPCTString21).HasColumnName("PZPCTString21").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPCTString22).HasColumnName("PZPCTString22").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPCTString23).HasColumnName("PZPCTString23").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPCTString24).HasColumnName("PZPCTString24").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPCTString25).HasColumnName("PZPCTString25").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPCTString26).HasColumnName("PZPCTString26").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPCTString27).HasColumnName("PZPCTString27").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPCTString28).HasColumnName("PZPCTString28").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPCTString29).HasColumnName("PZPCTString29").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPCTString3).HasColumnName("PZPCTString3").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPCTString30).HasColumnName("PZPCTString30").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPCTString4).HasColumnName("PZPCTString4").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPCTString5).HasColumnName("PZPCTString5").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPCTString6).HasColumnName("PZPCTString6").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPCTString7).HasColumnName("PZPCTString7").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPCTString8).HasColumnName("PZPCTString8").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPCTString9).HasColumnName("PZPCTString9").HasMaxLength(150);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<PZP_TONG_HOP>(entity =>
                    {
                        entity.HasKey(e => e.RECKEY);
                        entity.ToTable("PZP TONG HOP");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CongSoTien).HasColumnName("CongSoTien");
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(30);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(100);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.PZPBit1).HasColumnName("PZPBit1");
                        
                            entity.Property(e => e.PZPBit2).HasColumnName("PZPBit2");
                        
                            entity.Property(e => e.PZPBit3).HasColumnName("PZPBit3");
                        
                            entity.Property(e => e.PZPBit4).HasColumnName("PZPBit4");
                        
                            entity.Property(e => e.PZPBit5).HasColumnName("PZPBit5");
                        
                            entity.Property(e => e.PZPDate1).HasColumnName("PZPDate1");
                        
                            entity.Property(e => e.PZPDate10).HasColumnName("PZPDate10");
                        
                            entity.Property(e => e.PZPDate2).HasColumnName("PZPDate2");
                        
                            entity.Property(e => e.PZPDate3).HasColumnName("PZPDate3");
                        
                            entity.Property(e => e.PZPDate4).HasColumnName("PZPDate4");
                        
                            entity.Property(e => e.PZPDate5).HasColumnName("PZPDate5");
                        
                            entity.Property(e => e.PZPDate6).HasColumnName("PZPDate6");
                        
                            entity.Property(e => e.PZPDate7).HasColumnName("PZPDate7");
                        
                            entity.Property(e => e.PZPDate8).HasColumnName("PZPDate8");
                        
                            entity.Property(e => e.PZPDate9).HasColumnName("PZPDate9");
                        
                            entity.Property(e => e.PZPInt1).HasColumnName("PZPInt1");
                        
                            entity.Property(e => e.PZPInt2).HasColumnName("PZPInt2");
                        
                            entity.Property(e => e.PZPInt3).HasColumnName("PZPInt3");
                        
                            entity.Property(e => e.PZPInt4).HasColumnName("PZPInt4");
                        
                            entity.Property(e => e.PZPInt5).HasColumnName("PZPInt5");
                        
                            entity.Property(e => e.PZPNumber1).HasColumnName("PZPNumber1");
                        
                            entity.Property(e => e.PZPNumber10).HasColumnName("PZPNumber10");
                        
                            entity.Property(e => e.PZPNumber11).HasColumnName("PZPNumber11");
                        
                            entity.Property(e => e.PZPNumber12).HasColumnName("PZPNumber12");
                        
                            entity.Property(e => e.PZPNumber13).HasColumnName("PZPNumber13");
                        
                            entity.Property(e => e.PZPNumber14).HasColumnName("PZPNumber14");
                        
                            entity.Property(e => e.PZPNumber15).HasColumnName("PZPNumber15");
                        
                            entity.Property(e => e.PZPNumber16).HasColumnName("PZPNumber16");
                        
                            entity.Property(e => e.PZPNumber17).HasColumnName("PZPNumber17");
                        
                            entity.Property(e => e.PZPNumber18).HasColumnName("PZPNumber18");
                        
                            entity.Property(e => e.PZPNumber19).HasColumnName("PZPNumber19");
                        
                            entity.Property(e => e.PZPNumber2).HasColumnName("PZPNumber2");
                        
                            entity.Property(e => e.PZPNumber20).HasColumnName("PZPNumber20");
                        
                            entity.Property(e => e.PZPNumber3).HasColumnName("PZPNumber3");
                        
                            entity.Property(e => e.PZPNumber4).HasColumnName("PZPNumber4");
                        
                            entity.Property(e => e.PZPNumber5).HasColumnName("PZPNumber5");
                        
                            entity.Property(e => e.PZPNumber6).HasColumnName("PZPNumber6");
                        
                            entity.Property(e => e.PZPNumber7).HasColumnName("PZPNumber7");
                        
                            entity.Property(e => e.PZPNumber8).HasColumnName("PZPNumber8");
                        
                            entity.Property(e => e.PZPNumber9).HasColumnName("PZPNumber9");
                        
                            entity.Property(e => e.PZPString1).HasColumnName("PZPString1").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPString10).HasColumnName("PZPString10").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPString11).HasColumnName("PZPString11").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPString12).HasColumnName("PZPString12").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPString13).HasColumnName("PZPString13").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPString14).HasColumnName("PZPString14").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPString15).HasColumnName("PZPString15").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPString16).HasColumnName("PZPString16").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPString17).HasColumnName("PZPString17").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPString18).HasColumnName("PZPString18").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPString19).HasColumnName("PZPString19").HasMaxLength(250);
                        
                            entity.Property(e => e.PZPString2).HasColumnName("PZPString2").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPString20).HasColumnName("PZPString20").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPString21).HasColumnName("PZPString21").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPString22).HasColumnName("PZPString22").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPString23).HasColumnName("PZPString23").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPString24).HasColumnName("PZPString24").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPString25).HasColumnName("PZPString25").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPString26).HasColumnName("PZPString26").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPString27).HasColumnName("PZPString27").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPString28).HasColumnName("PZPString28").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPString29).HasColumnName("PZPString29").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPString3).HasColumnName("PZPString3").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPString30).HasColumnName("PZPString30").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZPString4).HasColumnName("PZPString4").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPString5).HasColumnName("PZPString5").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPString6).HasColumnName("PZPString6").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPString7).HasColumnName("PZPString7").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPString8).HasColumnName("PZPString8").HasMaxLength(150);
                        
                            entity.Property(e => e.PZPString9).HasColumnName("PZPString9").HasMaxLength(150);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RecXL).HasColumnName("RecXL").HasMaxLength(100);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(100);
                        
                    });
                    
                    //Unable to generate entity type for table 'dbo.PZR IN PLIEN'. table have no primary key
                    
                    modelBuilder.Entity<PZT_CHI_TIET_LDX>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("PZT CHI TIET LDX");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.ChuHang).HasColumnName("ChuHang").HasMaxLength(150);
                        
                            entity.Property(e => e.ChuyenDiem).HasColumnName("ChuyenDiem");
                        
                            entity.Property(e => e.ContRong).HasColumnName("ContRong");
                        
                            entity.Property(e => e.CuLy).HasColumnName("CuLy");
                        
                            entity.Property(e => e.DGBoiThuong).HasColumnName("DGBoiThuong");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DoanhThuXN).HasColumnName("DoanhThuXN");
                        
                            entity.Property(e => e.DonDatHang).HasColumnName("DonDatHang").HasMaxLength(50);
                        
                            entity.Property(e => e.DongHang).HasColumnName("DongHang").HasMaxLength(250);
                        
                            entity.Property(e => e.DonGiaTX).HasColumnName("DonGiaTX");
                        
                            entity.Property(e => e.DonGiaVC).HasColumnName("DonGiaVC");
                        
                            entity.Property(e => e.DonGiaXN).HasColumnName("DonGiaXN");
                        
                            entity.Property(e => e.DVT).HasColumnName("DVT").HasMaxLength(50);
                        
                            entity.Property(e => e.DVT2).HasColumnName("DVT2").HasMaxLength(50);
                        
                            entity.Property(e => e.DVTKien).HasColumnName("DVTKien").HasMaxLength(100);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GiaBaoKH).HasColumnName("GiaBaoKH");
                        
                            entity.Property(e => e.GiaTinhLTX).HasColumnName("GiaTinhLTX");
                        
                            entity.Property(e => e.GiaTinhOP1).HasColumnName("GiaTinhOP1");
                        
                            entity.Property(e => e.GiaTinhOP2).HasColumnName("GiaTinhOP2");
                        
                            entity.Property(e => e.GioGiao).HasColumnName("GioGiao");
                        
                            entity.Property(e => e.GioLay).HasColumnName("GioLay");
                        
                            entity.Property(e => e.HangGhep).HasColumnName("HangGhep");
                        
                            entity.Property(e => e.HangRoi).HasColumnName("HangRoi");
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.KhoiLuong).HasColumnName("KhoiLuong");
                        
                            entity.Property(e => e.LoaiCont).HasColumnName("LoaiCont").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiPT).HasColumnName("LoaiPT").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiTai).HasColumnName("LoaiTai").HasMaxLength(100);
                        
                            entity.Property(e => e.LuongTXVC).HasColumnName("LuongTXVC");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVienKD).HasColumnName("MaNVienKD").HasMaxLength(100);
                        
                            entity.Property(e => e.MaVT).HasColumnName("MaVT").HasMaxLength(100);
                        
                            entity.Property(e => e.MST).HasColumnName("MST").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayBOB).HasColumnName("NgayBOB");
                        
                            entity.Property(e => e.NgayGiao).HasColumnName("NgayGiao");
                        
                            entity.Property(e => e.NgayGioHa).HasColumnName("NgayGioHa");
                        
                            entity.Property(e => e.NgayGioLay).HasColumnName("NgayGioLay");
                        
                            entity.Property(e => e.NgayHopDong).HasColumnName("NgayHopDong");
                        
                            entity.Property(e => e.NgayLay).HasColumnName("NgayLay");
                        
                            entity.Property(e => e.NoiGiao).HasColumnName("NoiGiao").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiHaRong).HasColumnName("NoiHaRong").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiLay).HasColumnName("NoiLay").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiLayCont).HasColumnName("NoiLayCont").HasMaxLength(250);
                        
                            entity.Property(e => e.PhiCauDuong).HasColumnName("PhiCauDuong");
                        
                            entity.Property(e => e.PhiDiDuong).HasColumnName("PhiDiDuong");
                        
                            entity.Property(e => e.PhuCapTN).HasColumnName("PhuCapTN");
                        
                            entity.Property(e => e.PTHHCTChoPhep).HasColumnName("PTHHCTChoPhep");
                        
                            entity.Property(e => e.PTHHTXChoPhep).HasColumnName("PTHHTXChoPhep");
                        
                            entity.Property(e => e.PZTLDXCTB1).HasColumnName("PZTLDXCTB1");
                        
                            entity.Property(e => e.PZTLDXCTB2).HasColumnName("PZTLDXCTB2");
                        
                            entity.Property(e => e.PZTLDXCTB3).HasColumnName("PZTLDXCTB3");
                        
                            entity.Property(e => e.PZTLDXCTB4).HasColumnName("PZTLDXCTB4");
                        
                            entity.Property(e => e.PZTLDXCTB5).HasColumnName("PZTLDXCTB5");
                        
                            entity.Property(e => e.PZTLDXCTD1).HasColumnName("PZTLDXCTD1");
                        
                            entity.Property(e => e.PZTLDXCTD10).HasColumnName("PZTLDXCTD10");
                        
                            entity.Property(e => e.PZTLDXCTD2).HasColumnName("PZTLDXCTD2");
                        
                            entity.Property(e => e.PZTLDXCTD3).HasColumnName("PZTLDXCTD3");
                        
                            entity.Property(e => e.PZTLDXCTD4).HasColumnName("PZTLDXCTD4");
                        
                            entity.Property(e => e.PZTLDXCTD5).HasColumnName("PZTLDXCTD5");
                        
                            entity.Property(e => e.PZTLDXCTD6).HasColumnName("PZTLDXCTD6");
                        
                            entity.Property(e => e.PZTLDXCTD7).HasColumnName("PZTLDXCTD7");
                        
                            entity.Property(e => e.PZTLDXCTD8).HasColumnName("PZTLDXCTD8");
                        
                            entity.Property(e => e.PZTLDXCTD9).HasColumnName("PZTLDXCTD9");
                        
                            entity.Property(e => e.PZTLDXCTI1).HasColumnName("PZTLDXCTI1");
                        
                            entity.Property(e => e.PZTLDXCTI2).HasColumnName("PZTLDXCTI2");
                        
                            entity.Property(e => e.PZTLDXCTI3).HasColumnName("PZTLDXCTI3");
                        
                            entity.Property(e => e.PZTLDXCTI4).HasColumnName("PZTLDXCTI4");
                        
                            entity.Property(e => e.PZTLDXCTI5).HasColumnName("PZTLDXCTI5");
                        
                            entity.Property(e => e.PZTLDXCTN1).HasColumnName("PZTLDXCTN1");
                        
                            entity.Property(e => e.PZTLDXCTN10).HasColumnName("PZTLDXCTN10");
                        
                            entity.Property(e => e.PZTLDXCTN11).HasColumnName("PZTLDXCTN11");
                        
                            entity.Property(e => e.PZTLDXCTN12).HasColumnName("PZTLDXCTN12");
                        
                            entity.Property(e => e.PZTLDXCTN13).HasColumnName("PZTLDXCTN13");
                        
                            entity.Property(e => e.PZTLDXCTN14).HasColumnName("PZTLDXCTN14");
                        
                            entity.Property(e => e.PZTLDXCTN15).HasColumnName("PZTLDXCTN15");
                        
                            entity.Property(e => e.PZTLDXCTN16).HasColumnName("PZTLDXCTN16");
                        
                            entity.Property(e => e.PZTLDXCTN17).HasColumnName("PZTLDXCTN17");
                        
                            entity.Property(e => e.PZTLDXCTN18).HasColumnName("PZTLDXCTN18");
                        
                            entity.Property(e => e.PZTLDXCTN19).HasColumnName("PZTLDXCTN19");
                        
                            entity.Property(e => e.PZTLDXCTN2).HasColumnName("PZTLDXCTN2");
                        
                            entity.Property(e => e.PZTLDXCTN20).HasColumnName("PZTLDXCTN20");
                        
                            entity.Property(e => e.PZTLDXCTN3).HasColumnName("PZTLDXCTN3");
                        
                            entity.Property(e => e.PZTLDXCTN4).HasColumnName("PZTLDXCTN4");
                        
                            entity.Property(e => e.PZTLDXCTN5).HasColumnName("PZTLDXCTN5");
                        
                            entity.Property(e => e.PZTLDXCTN6).HasColumnName("PZTLDXCTN6");
                        
                            entity.Property(e => e.PZTLDXCTN7).HasColumnName("PZTLDXCTN7");
                        
                            entity.Property(e => e.PZTLDXCTN8).HasColumnName("PZTLDXCTN8");
                        
                            entity.Property(e => e.PZTLDXCTN9).HasColumnName("PZTLDXCTN9");
                        
                            entity.Property(e => e.PZTLDXCTS1).HasColumnName("PZTLDXCTS1").HasMaxLength(150);
                        
                            entity.Property(e => e.PZTLDXCTS10).HasColumnName("PZTLDXCTS10").HasMaxLength(250);
                        
                            entity.Property(e => e.PZTLDXCTS11).HasColumnName("PZTLDXCTS11").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZTLDXCTS12).HasColumnName("PZTLDXCTS12").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZTLDXCTS13).HasColumnName("PZTLDXCTS13").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZTLDXCTS14).HasColumnName("PZTLDXCTS14").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZTLDXCTS15).HasColumnName("PZTLDXCTS15").HasMaxLength(-1);
                        
                            entity.Property(e => e.PZTLDXCTS2).HasColumnName("PZTLDXCTS2").HasMaxLength(150);
                        
                            entity.Property(e => e.PZTLDXCTS3).HasColumnName("PZTLDXCTS3").HasMaxLength(150);
                        
                            entity.Property(e => e.PZTLDXCTS4).HasColumnName("PZTLDXCTS4").HasMaxLength(150);
                        
                            entity.Property(e => e.PZTLDXCTS5).HasColumnName("PZTLDXCTS5").HasMaxLength(150);
                        
                            entity.Property(e => e.PZTLDXCTS6).HasColumnName("PZTLDXCTS6").HasMaxLength(250);
                        
                            entity.Property(e => e.PZTLDXCTS7).HasColumnName("PZTLDXCTS7").HasMaxLength(250);
                        
                            entity.Property(e => e.PZTLDXCTS8).HasColumnName("PZTLDXCTS8").HasMaxLength(250);
                        
                            entity.Property(e => e.PZTLDXCTS9).HasColumnName("PZTLDXCTS9").HasMaxLength(250);
                        
                            entity.Property(e => e.RecHaRong).HasColumnName("RecHaRong").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKHVCCT).HasColumnName("RECKHVCCT").HasMaxLength(150);
                        
                            entity.Property(e => e.RecLayCont).HasColumnName("RecLayCont").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLoaiCont).HasColumnName("RecLoaiCont").HasMaxLength(100);
                        
                            entity.Property(e => e.RecNoiGiao).HasColumnName("RecNoiGiao").HasMaxLength(100);
                        
                            entity.Property(e => e.RecNoiLay).HasColumnName("RecNoiLay").HasMaxLength(100);
                        
                            entity.Property(e => e.RecTuyen).HasColumnName("RecTuyen").HasMaxLength(100);
                        
                            entity.Property(e => e.SLCanCang).HasColumnName("SLCanCang");
                        
                            entity.Property(e => e.SLChenhLech).HasColumnName("SLChenhLech");
                        
                            entity.Property(e => e.SLHHCTBoiThuong).HasColumnName("SLHHCTBoiThuong");
                        
                            entity.Property(e => e.SLHHCTChoPhep).HasColumnName("SLHHCTChoPhep");
                        
                            entity.Property(e => e.SLHHTXBoiThuong).HasColumnName("SLHHTXBoiThuong");
                        
                            entity.Property(e => e.SLHHTXChoPhep).HasColumnName("SLHHTXChoPhep");
                        
                            entity.Property(e => e.SLMat).HasColumnName("SLMat");
                        
                            entity.Property(e => e.SLNet).HasColumnName("SLNet");
                        
                            entity.Property(e => e.SLNhan).HasColumnName("SLNhan");
                        
                            entity.Property(e => e.SLNhapKho).HasColumnName("SLNhapKho");
                        
                            entity.Property(e => e.SLPhu).HasColumnName("SLPhu");
                        
                            entity.Property(e => e.SLPhu2).HasColumnName("SLPhu2");
                        
                            entity.Property(e => e.SLTruBi).HasColumnName("SLTruBi");
                        
                            entity.Property(e => e.SoBao).HasColumnName("SoBao");
                        
                            entity.Property(e => e.SoBOB).HasColumnName("SoBOB").HasMaxLength(50);
                        
                            entity.Property(e => e.SoChuyen).HasColumnName("SoChuyen");
                        
                            entity.Property(e => e.SoCont).HasColumnName("SoCont").HasMaxLength(100);
                        
                            entity.Property(e => e.SoCont2).HasColumnName("SoCont2").HasMaxLength(100);
                        
                            entity.Property(e => e.SoDauDM).HasColumnName("SoDauDM");
                        
                            entity.Property(e => e.SoDauTT).HasColumnName("SoDauTT");
                        
                            entity.Property(e => e.SoHopDong).HasColumnName("SoHopDong").HasMaxLength(50);
                        
                            entity.Property(e => e.SoKHVC).HasColumnName("SoKHVC").HasMaxLength(50);
                        
                            entity.Property(e => e.SoKien).HasColumnName("SoKien").HasMaxLength(250);
                        
                            entity.Property(e => e.SoKMDB).HasColumnName("SoKMDB");
                        
                            entity.Property(e => e.SoKMDN).HasColumnName("SoKMDN");
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(250);
                        
                            entity.Property(e => e.SoLuongGiao).HasColumnName("SoLuongGiao");
                        
                            entity.Property(e => e.SoSeal).HasColumnName("SoSeal").HasMaxLength(250);
                        
                            entity.Property(e => e.SoSeal2).HasColumnName("SoSeal2").HasMaxLength(250);
                        
                            entity.Property(e => e.SoXe).HasColumnName("SoXe").HasMaxLength(50);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TaiNang).HasColumnName("TaiNang");
                        
                            entity.Property(e => e.TenChu).HasColumnName("TenChu").HasMaxLength(250);
                        
                            entity.Property(e => e.TenCont).HasColumnName("TenCont").HasMaxLength(250);
                        
                            entity.Property(e => e.TenCont2).HasColumnName("TenCont2").HasMaxLength(250);
                        
                            entity.Property(e => e.TenVT).HasColumnName("TenVT").HasMaxLength(250);
                        
                            entity.Property(e => e.ThanhTienDC).HasColumnName("ThanhTienDC");
                        
                            entity.Property(e => e.ThanhTienGT).HasColumnName("ThanhTienGT");
                        
                            entity.Property(e => e.ThanhTienVC).HasColumnName("ThanhTienVC");
                        
                            entity.Property(e => e.ThanhTienXN).HasColumnName("ThanhTienXN");
                        
                            entity.Property(e => e.ThoiGianChoCP).HasColumnName("ThoiGianChoCP");
                        
                            entity.Property(e => e.ThoiGianChoQH).HasColumnName("ThoiGianChoQH");
                        
                            entity.Property(e => e.ThoiGianChoTT).HasColumnName("ThoiGianChoTT");
                        
                            entity.Property(e => e.ThueVAT).HasColumnName("ThueVAT").HasMaxLength(30);
                        
                            entity.Property(e => e.TienCTBTHH).HasColumnName("TienCTBTHH");
                        
                            entity.Property(e => e.TienHoaHong).HasColumnName("TienHoaHong");
                        
                            entity.Property(e => e.TienKhoan).HasColumnName("TienKhoan");
                        
                            entity.Property(e => e.TienLuuCa).HasColumnName("TienLuuCa");
                        
                            entity.Property(e => e.TienTXBTHH).HasColumnName("TienTXBTHH");
                        
                            entity.Property(e => e.TienVAT).HasColumnName("TienVAT");
                        
                            entity.Property(e => e.TienVNDCK).HasColumnName("TienVNDCK");
                        
                            entity.Property(e => e.TrongLuong).HasColumnName("TrongLuong");
                        
                            entity.Property(e => e.TuyenDuong).HasColumnName("TuyenDuong").HasMaxLength(250);
                        
                            entity.Property(e => e.TyLeCK).HasColumnName("TyLeCK");
                        
                            entity.Property(e => e.TyLeHH).HasColumnName("TyLeHH");
                        
                            entity.Property(e => e.YeuCauTX).HasColumnName("YeuCauTX").HasMaxLength(-1);
                        
                    });
                    
                    modelBuilder.Entity<PZT_LENH_DX>(entity =>
                    {
                        entity.HasKey(e => e.IDDX);
                        entity.ToTable("PZT LENH DX");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CangCT).HasColumnName("CangCT").HasMaxLength(250);
                        
                            entity.Property(e => e.CangDen).HasColumnName("CangDen").HasMaxLength(250);
                        
                            entity.Property(e => e.CangDi).HasColumnName("CangDi").HasMaxLength(250);
                        
                            entity.Property(e => e.ChucVuDD).HasColumnName("ChucVuDD").HasMaxLength(250);
                        
                            entity.Property(e => e.ChucVuDDNN).HasColumnName("ChucVuDDNN").HasMaxLength(250);
                        
                            entity.Property(e => e.ChuHang).HasColumnName("ChuHang").HasMaxLength(250);
                        
                            entity.Property(e => e.Cont20).HasColumnName("Cont20");
                        
                            entity.Property(e => e.Cont40).HasColumnName("Cont40");
                        
                            entity.Property(e => e.Cont45).HasColumnName("Cont45");
                        
                            entity.Property(e => e.CuLy).HasColumnName("CuLy");
                        
                            entity.Property(e => e.DauThucTe).HasColumnName("DauThucTe");
                        
                            entity.Property(e => e.DGDau).HasColumnName("DGDau");
                        
                            entity.Property(e => e.DiaChi).HasColumnName("DiaChi").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiDL).HasColumnName("DiaChiDL").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiDLNN).HasColumnName("DiaChiDLNN").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNDD).HasColumnName("DiaChiNDD").HasMaxLength(250);
                        
                            entity.Property(e => e.DiaChiNDDNN).HasColumnName("DiaChiNDDNN").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DMDau).HasColumnName("DMDau");
                        
                            entity.Property(e => e.DonDatHang).HasColumnName("DonDatHang").HasMaxLength(100);
                        
                            entity.Property(e => e.DongHang).HasColumnName("DongHang").HasMaxLength(250);
                        
                            entity.Property(e => e.DonGiaCT).HasColumnName("DonGiaCT");
                        
                            entity.Property(e => e.DonGiaVC).HasColumnName("DonGiaVC");
                        
                            entity.Property(e => e.GioCatMang).HasColumnName("GioCatMang");
                        
                            entity.Property(e => e.GioLayHang).HasColumnName("GioLayHang");
                        
                            entity.Property(e => e.HangTau).HasColumnName("HangTau").HasMaxLength(250);
                        
                            entity.Property(e => e.HuyLenhDX).HasColumnName("HuyLenhDX");
                        
                            entity.Property(e => e.IDDX).HasColumnName("IDDX");
                        
                            entity.Property(e => e.KhoHang).HasColumnName("KhoHang").HasMaxLength(100);
                        
                            entity.Property(e => e.KhoiLuong).HasColumnName("KhoiLuong");
                        
                            entity.Property(e => e.KhuVuc).HasColumnName("KhuVuc").HasMaxLength(250);
                        
                            entity.Property(e => e.LenhMotChieu).HasColumnName("LenhMotChieu");
                        
                            entity.Property(e => e.LoaiCont).HasColumnName("LoaiCont").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiHang).HasColumnName("LoaiHang").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiKien).HasColumnName("LoaiKien").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiNX).HasColumnName("LoaiNX").HasMaxLength(150);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(20);
                        
                            entity.Property(e => e.LoaiPT).HasColumnName("LoaiPT").HasMaxLength(100);
                        
                            entity.Property(e => e.LuongTXVC).HasColumnName("LuongTXVC");
                        
                            entity.Property(e => e.LyDoHuy).HasColumnName("LyDoHuy").HasMaxLength(-1);
                        
                            entity.Property(e => e.MaBangGia).HasColumnName("MaBangGia").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChuPT).HasColumnName("MaChuPT").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDaiLy).HasColumnName("MaDaiLy").HasMaxLength(50);
                        
                            entity.Property(e => e.MaDaiLyNN).HasColumnName("MaDaiLyNN").HasMaxLength(50);
                        
                            entity.Property(e => e.MaIDCTChon).HasColumnName("MaIDCTChon").HasMaxLength(50);
                        
                            entity.Property(e => e.MaLichTau).HasColumnName("MaLichTau").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNguoiDD).HasColumnName("MaNguoiDD").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNguoiDDNN).HasColumnName("MaNguoiDDNN").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNVienDX).HasColumnName("MaNVienDX").HasMaxLength(50);
                        
                            entity.Property(e => e.MaNVienKD).HasColumnName("MaNVienKD").HasMaxLength(100);
                        
                            entity.Property(e => e.MST).HasColumnName("MST").HasMaxLength(50);
                        
                            entity.Property(e => e.NgayBill).HasColumnName("NgayBill");
                        
                            entity.Property(e => e.NgayCatMang).HasColumnName("NgayCatMang");
                        
                            entity.Property(e => e.NgayDi).HasColumnName("NgayDi");
                        
                            entity.Property(e => e.NgayDXTC).HasColumnName("NgayDXTC");
                        
                            entity.Property(e => e.NgayGiao).HasColumnName("NgayGiao");
                        
                            entity.Property(e => e.NgayGioSua).HasColumnName("NgayGioSua").HasMaxLength(150);
                        
                            entity.Property(e => e.NgayGioThem).HasColumnName("NgayGioThem").HasMaxLength(150);
                        
                            entity.Property(e => e.NgayHetHan).HasColumnName("NgayHetHan");
                        
                            entity.Property(e => e.NgayLapLT).HasColumnName("NgayLapLT");
                        
                            entity.Property(e => e.NgayLayLenh).HasColumnName("NgayLayLenh");
                        
                            entity.Property(e => e.NgayLP).HasColumnName("NgayLP");
                        
                            entity.Property(e => e.NgayTauCap).HasColumnName("NgayTauCap");
                        
                            entity.Property(e => e.NgayVe).HasColumnName("NgayVe");
                        
                            entity.Property(e => e.NhaXe).HasColumnName("NhaXe").HasMaxLength(100);
                        
                            entity.Property(e => e.NoiHa).HasColumnName("NoiHa").HasMaxLength(250);
                        
                            entity.Property(e => e.NoiNhan).HasColumnName("NoiNhan").HasMaxLength(250);
                        
                            entity.Property(e => e.PhuXe).HasColumnName("PhuXe").HasMaxLength(250);
                        
                            entity.Property(e => e.RecBK).HasColumnName("RecBK").HasMaxLength(100);
                        
                            entity.Property(e => e.RecBL).HasColumnName("RecBL").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYBH).HasColumnName("RECKEYBH").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYLQ).HasColumnName("RECKEYLQ").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYPN).HasColumnName("RECKEYPN").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYPX).HasColumnName("RECKEYPX").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYTC).HasColumnName("RECKEYTC").HasMaxLength(100);
                        
                            entity.Property(e => e.RECKEYTH).HasColumnName("RECKEYTH").HasMaxLength(100);
                        
                            entity.Property(e => e.RecLOT).HasColumnName("RecLOT").HasMaxLength(100);
                        
                            entity.Property(e => e.SLCont).HasColumnName("SLCont");
                        
                            entity.Property(e => e.SoBill).HasColumnName("SoBill").HasMaxLength(30);
                        
                            entity.Property(e => e.SoBooking).HasColumnName("SoBooking").HasMaxLength(100);
                        
                            entity.Property(e => e.SoChuyen).HasColumnName("SoChuyen").HasMaxLength(50);
                        
                            entity.Property(e => e.SoCont).HasColumnName("SoCont").HasMaxLength(50);
                        
                            entity.Property(e => e.SoKhoi).HasColumnName("SoKhoi");
                        
                            entity.Property(e => e.SoKHVC).HasColumnName("SoKHVC").HasMaxLength(100);
                        
                            entity.Property(e => e.SoKien).HasColumnName("SoKien");
                        
                            entity.Property(e => e.SoLanVC).HasColumnName("SoLanVC");
                        
                            entity.Property(e => e.SoLot).HasColumnName("SoLot").HasMaxLength(100);
                        
                            entity.Property(e => e.SoMooc).HasColumnName("SoMooc").HasMaxLength(50);
                        
                            entity.Property(e => e.SoPhieu).HasColumnName("SoPhieu").HasMaxLength(50);
                        
                            entity.Property(e => e.SoPhieuDau).HasColumnName("SoPhieuDau").HasMaxLength(30);
                        
                            entity.Property(e => e.SoSeal).HasColumnName("SoSeal").HasMaxLength(100);
                        
                            entity.Property(e => e.SoXe).HasColumnName("SoXe").HasMaxLength(50);
                        
                            entity.Property(e => e.SoXeTC).HasColumnName("SoXeTC").HasMaxLength(20);
                        
                            entity.Property(e => e.SuaBoi).HasColumnName("SuaBoi").HasMaxLength(50);
                        
                            entity.Property(e => e.TaiXe).HasColumnName("TaiXe").HasMaxLength(100);
                        
                            entity.Property(e => e.TamUngKH).HasColumnName("TamUngKH");
                        
                            entity.Property(e => e.TamUngTX).HasColumnName("TamUngTX");
                        
                            entity.Property(e => e.TauChuyenTai).HasColumnName("TauChuyenTai").HasMaxLength(250);
                        
                            entity.Property(e => e.TenChuPT).HasColumnName("TenChuPT").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDaiLy).HasColumnName("TenDaiLy").HasMaxLength(250);
                        
                            entity.Property(e => e.TenDaiLyNN).HasColumnName("TenDaiLyNN").HasMaxLength(250);
                        
                            entity.Property(e => e.TenHieu).HasColumnName("TenHieu").HasMaxLength(250);
                        
                            entity.Property(e => e.TenLoaiPT).HasColumnName("TenLoaiPT").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiDD).HasColumnName("TenNguoiDD").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNguoiDDNN).HasColumnName("TenNguoiDDNN").HasMaxLength(250);
                        
                            entity.Property(e => e.TenSHPT).HasColumnName("TenSHPT").HasMaxLength(100);
                        
                            entity.Property(e => e.TenTau).HasColumnName("TenTau").HasMaxLength(250);
                        
                            entity.Property(e => e.ThanhTienVC).HasColumnName("ThanhTienVC");
                        
                            entity.Property(e => e.TheoKHVC).HasColumnName("TheoKHVC");
                        
                            entity.Property(e => e.TongSoDau).HasColumnName("TongSoDau");
                        
                            entity.Property(e => e.TrangThaiLDX).HasColumnName("TrangThaiLDX").HasMaxLength(50);
                        
                            entity.Property(e => e.TrungChuyenLDX).HasColumnName("TrungChuyenLDX").HasMaxLength(30);
                        
                            entity.Property(e => e.TuyenDuong).HasColumnName("TuyenDuong").HasMaxLength(150);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(50);
                        
                            entity.Property(e => e.VaoThu).HasColumnName("VaoThu").HasMaxLength(150);
                        
                            entity.Property(e => e.XeNgoai).HasColumnName("XeNgoai");
                        
                            entity.Property(e => e.YCCongTy).HasColumnName("YCCongTy").HasMaxLength(-1);
                        
                    });
                    
                    modelBuilder.Entity<R99_TEN_REPORT>(entity =>
                    {
                        entity.HasKey(e => e.TenReport);
                        entity.ToTable("R99 TEN REPORT");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(-1);
                        
                            entity.Property(e => e.IDRP).HasColumnName("IDRP");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.LoaiPhieu).HasColumnName("LoaiPhieu").HasMaxLength(250);
                        
                            entity.Property(e => e.MacDinh).HasColumnName("MacDinh");
                        
                            entity.Property(e => e.MayInRieng).HasColumnName("MayInRieng").HasMaxLength(250);
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.SoTrangIn).HasColumnName("SoTrangIn");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenReport).HasColumnName("TenReport").HasMaxLength(150);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    //Unable to generate entity type for table 'dbo.RP BAO CAO TS'. table have no primary key
                    
                    modelBuilder.Entity<RP_BCKQKD>(entity =>
                    {
                        entity.HasKey(e => e.ID);
                        entity.ToTable("RP BCKQKD");
                        
                            entity.Property(e => e.BenNo).HasColumnName("BenNo");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.CongThuc).HasColumnName("CongThuc").HasMaxLength(250);
                        
                            entity.Property(e => e.DieuKienKhac).HasColumnName("DieuKienKhac").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.ID).HasColumnName("ID");
                        
                            entity.Property(e => e.InDam).HasColumnName("InDam");
                        
                            entity.Property(e => e.InNghieng).HasColumnName("InNghieng");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.KyNay).HasColumnName("KyNay");
                        
                            entity.Property(e => e.KyNayNgoaiTe).HasColumnName("KyNayNgoaiTe");
                        
                            entity.Property(e => e.KyTruoc).HasColumnName("KyTruoc");
                        
                            entity.Property(e => e.KyTruocNgoaiTe).HasColumnName("KyTruocNgoaiTe");
                        
                            entity.Property(e => e.LuyKeTuDauNam).HasColumnName("LuyKeTuDauNam");
                        
                            entity.Property(e => e.LuyKeTuDauNamNgoaiTe).HasColumnName("LuyKeTuDauNamNgoaiTe");
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MAIN).HasColumnName("MAIN").HasMaxLength(1);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSo).HasColumnName("MaSo").HasMaxLength(50);
                        
                            entity.Property(e => e.OrderBy).HasColumnName("OrderBy");
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.ThuyetMinh).HasColumnName("ThuyetMinh").HasMaxLength(50);
                        
                            entity.Property(e => e.TKXL).HasColumnName("TKXL").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                            entity.Property(e => e.ZORDER).HasColumnName("ZORDER");
                        
                            entity.Property(e => e.ZORDERCONGTHUC).HasColumnName("ZORDERCONGTHUC");
                        
                    });
                    
                    modelBuilder.Entity<RP_BCKQKD_200>(entity =>
                    {
                        entity.HasKey(e => e.ID);
                        entity.ToTable("RP BCKQKD 200");
                        
                            entity.Property(e => e.BenNo).HasColumnName("BenNo");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.CongThuc).HasColumnName("CongThuc").HasMaxLength(250);
                        
                            entity.Property(e => e.DieuKienKhac).HasColumnName("DieuKienKhac").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.ID).HasColumnName("ID");
                        
                            entity.Property(e => e.InDam).HasColumnName("InDam");
                        
                            entity.Property(e => e.InNghieng).HasColumnName("InNghieng");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.KyNay).HasColumnName("KyNay");
                        
                            entity.Property(e => e.KyNayNgoaiTe).HasColumnName("KyNayNgoaiTe");
                        
                            entity.Property(e => e.KyTruoc).HasColumnName("KyTruoc");
                        
                            entity.Property(e => e.KyTruocNgoaiTe).HasColumnName("KyTruocNgoaiTe");
                        
                            entity.Property(e => e.LuyKeTuDauNam).HasColumnName("LuyKeTuDauNam");
                        
                            entity.Property(e => e.LuyKeTuDauNamNgoaiTe).HasColumnName("LuyKeTuDauNamNgoaiTe");
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MAIN).HasColumnName("MAIN").HasMaxLength(10);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSo).HasColumnName("MaSo").HasMaxLength(50);
                        
                            entity.Property(e => e.OrderBy).HasColumnName("OrderBy");
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.ThuyetMinh).HasColumnName("ThuyetMinh").HasMaxLength(50);
                        
                            entity.Property(e => e.TKXL).HasColumnName("TKXL").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                            entity.Property(e => e.ZORDER).HasColumnName("ZORDER");
                        
                            entity.Property(e => e.ZORDERCONGTHUC).HasColumnName("ZORDERCONGTHUC");
                        
                    });
                    
                    modelBuilder.Entity<RP_BCKQKD_48>(entity =>
                    {
                        entity.HasKey(e => e.ID);
                        entity.ToTable("RP BCKQKD 48");
                        
                            entity.Property(e => e.BenNo).HasColumnName("BenNo");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.CongThuc).HasColumnName("CongThuc").HasMaxLength(250);
                        
                            entity.Property(e => e.DieuKienKhac).HasColumnName("DieuKienKhac").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.ID).HasColumnName("ID");
                        
                            entity.Property(e => e.InDam).HasColumnName("InDam");
                        
                            entity.Property(e => e.InNghieng).HasColumnName("InNghieng");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.KhongIn).HasColumnName("KhongIn");
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.KyNay).HasColumnName("KyNay");
                        
                            entity.Property(e => e.KyNayNgoaiTe).HasColumnName("KyNayNgoaiTe");
                        
                            entity.Property(e => e.KyTruoc).HasColumnName("KyTruoc");
                        
                            entity.Property(e => e.KyTruocNgoaiTe).HasColumnName("KyTruocNgoaiTe");
                        
                            entity.Property(e => e.LuyKeTuDauNam).HasColumnName("LuyKeTuDauNam");
                        
                            entity.Property(e => e.LuyKeTuDauNamNgoaiTe).HasColumnName("LuyKeTuDauNamNgoaiTe");
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSo).HasColumnName("MaSo").HasMaxLength(50);
                        
                            entity.Property(e => e.OrderBy).HasColumnName("OrderBy");
                        
                            entity.Property(e => e.OrderByCongThuc).HasColumnName("OrderByCongThuc");
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.ThuyetMinh).HasColumnName("ThuyetMinh").HasMaxLength(50);
                        
                            entity.Property(e => e.TKXL).HasColumnName("TKXL").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    //Unable to generate entity type for table 'dbo.RP CAN DOI PS'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP CAN DOI PS TMP'. table have no primary key
                    
                    modelBuilder.Entity<RP_CD_KE_TOAN>(entity =>
                    {
                        entity.HasKey(e => e.ID);
                        entity.ToTable("RP CD KE TOAN");
                        
                            entity.Property(e => e.BenNo).HasColumnName("BenNo");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.CuoiKy).HasColumnName("CuoiKy");
                        
                            entity.Property(e => e.CuoiKyNgoaiTe).HasColumnName("CuoiKyNgoaiTe");
                        
                            entity.Property(e => e.DauKy).HasColumnName("DauKy");
                        
                            entity.Property(e => e.DauKyNgoaiTe).HasColumnName("DauKyNgoaiTe");
                        
                            entity.Property(e => e.DauNam).HasColumnName("DauNam");
                        
                            entity.Property(e => e.DauNamNgoaiTe).HasColumnName("DauNamNgoaiTe");
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.ID).HasColumnName("ID");
                        
                            entity.Property(e => e.InDam).HasColumnName("InDam");
                        
                            entity.Property(e => e.InNghieng).HasColumnName("InNghieng");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.KhongIn).HasColumnName("KhongIn");
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MAIN).HasColumnName("MAIN").HasMaxLength(1);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSo).HasColumnName("MaSo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaXL).HasColumnName("MaXL").HasMaxLength(100);
                        
                            entity.Property(e => e.Muc).HasColumnName("Muc");
                        
                            entity.Property(e => e.NgoaiBang).HasColumnName("NgoaiBang");
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.SoThuTu).HasColumnName("SoThuTu");
                        
                            entity.Property(e => e.ThuyetMinh).HasColumnName("ThuyetMinh").HasMaxLength(50);
                        
                            entity.Property(e => e.TKXL).HasColumnName("TKXL").HasMaxLength(250);
                        
                            entity.Property(e => e.TKXLBUTRU).HasColumnName("TKXLBUTRU").HasMaxLength(250);
                        
                            entity.Property(e => e.TKXLNGUOC).HasColumnName("TKXLNGUOC").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<RP_CD_KE_TOAN_200>(entity =>
                    {
                        entity.HasKey(e => e.ID);
                        entity.ToTable("RP CD KE TOAN 200");
                        
                            entity.Property(e => e.BenNo).HasColumnName("BenNo");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.CongThuc).HasColumnName("CongThuc").HasMaxLength(250);
                        
                            entity.Property(e => e.CuoiKy).HasColumnName("CuoiKy");
                        
                            entity.Property(e => e.CuoiKyNgoaiTe).HasColumnName("CuoiKyNgoaiTe");
                        
                            entity.Property(e => e.DauKy).HasColumnName("DauKy");
                        
                            entity.Property(e => e.DauKyNgoaiTe).HasColumnName("DauKyNgoaiTe");
                        
                            entity.Property(e => e.DauNam).HasColumnName("DauNam");
                        
                            entity.Property(e => e.DauNamNgoaiTe).HasColumnName("DauNamNgoaiTe");
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.ID).HasColumnName("ID");
                        
                            entity.Property(e => e.InDam).HasColumnName("InDam");
                        
                            entity.Property(e => e.InNghieng).HasColumnName("InNghieng");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.KhongIn).HasColumnName("KhongIn");
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MAIN).HasColumnName("MAIN").HasMaxLength(1);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSo).HasColumnName("MaSo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaXL).HasColumnName("MaXL").HasMaxLength(100);
                        
                            entity.Property(e => e.Muc).HasColumnName("Muc");
                        
                            entity.Property(e => e.NgoaiBang).HasColumnName("NgoaiBang");
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.SoThuTu).HasColumnName("SoThuTu");
                        
                            entity.Property(e => e.ThuyetMinh).HasColumnName("ThuyetMinh").HasMaxLength(50);
                        
                            entity.Property(e => e.TKXL).HasColumnName("TKXL").HasMaxLength(250);
                        
                            entity.Property(e => e.TKXLBUTRU).HasColumnName("TKXLBUTRU").HasMaxLength(250);
                        
                            entity.Property(e => e.TKXLNGUOC).HasColumnName("TKXLNGUOC").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<RP_CD_KE_TOAN_48>(entity =>
                    {
                        entity.HasKey(e => e.ID);
                        entity.ToTable("RP CD KE TOAN 48");
                        
                            entity.Property(e => e.BenNo).HasColumnName("BenNo");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.CuoiKy).HasColumnName("CuoiKy");
                        
                            entity.Property(e => e.CuoiKyNgoaiTe).HasColumnName("CuoiKyNgoaiTe");
                        
                            entity.Property(e => e.DauKy).HasColumnName("DauKy");
                        
                            entity.Property(e => e.DauKyNgoaiTe).HasColumnName("DauKyNgoaiTe");
                        
                            entity.Property(e => e.DauNam).HasColumnName("DauNam");
                        
                            entity.Property(e => e.DauNamNgoaiTe).HasColumnName("DauNamNgoaiTe");
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.ID).HasColumnName("ID");
                        
                            entity.Property(e => e.InDam).HasColumnName("InDam");
                        
                            entity.Property(e => e.InNghieng).HasColumnName("InNghieng");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.KhongIn).HasColumnName("KhongIn");
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSo).HasColumnName("MaSo").HasMaxLength(50);
                        
                            entity.Property(e => e.MaXL).HasColumnName("MaXL").HasMaxLength(100);
                        
                            entity.Property(e => e.Muc).HasColumnName("Muc");
                        
                            entity.Property(e => e.NgoaiBang).HasColumnName("NgoaiBang");
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.SoThuTu).HasColumnName("SoThuTu");
                        
                            entity.Property(e => e.ThuyetMinh).HasColumnName("ThuyetMinh").HasMaxLength(50);
                        
                            entity.Property(e => e.TKXL).HasColumnName("TKXL").HasMaxLength(250);
                        
                            entity.Property(e => e.TKXLBUTRU).HasColumnName("TKXLBUTRU").HasMaxLength(250);
                        
                            entity.Property(e => e.TKXLNGUOC).HasColumnName("TKXLNGUOC").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<RP_LUU_CHUYEN_TTE>(entity =>
                    {
                        entity.HasKey(e => e.ID);
                        entity.ToTable("RP LUU CHUYEN TTE");
                        
                            entity.Property(e => e.BenNo).HasColumnName("BenNo");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.CongThuc).HasColumnName("CongThuc").HasMaxLength(250);
                        
                            entity.Property(e => e.DieuKienKhac).HasColumnName("DieuKienKhac").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.ID).HasColumnName("ID");
                        
                            entity.Property(e => e.InDam).HasColumnName("InDam");
                        
                            entity.Property(e => e.InNghieng).HasColumnName("InNghieng");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.KhongIn).HasColumnName("KhongIn");
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.KyNay).HasColumnName("KyNay");
                        
                            entity.Property(e => e.KyNayNgoaiTe).HasColumnName("KyNayNgoaiTe");
                        
                            entity.Property(e => e.KyNayNTe).HasColumnName("KyNayNTe");
                        
                            entity.Property(e => e.KyTruoc).HasColumnName("KyTruoc");
                        
                            entity.Property(e => e.KyTruocNgoaiTe).HasColumnName("KyTruocNgoaiTe");
                        
                            entity.Property(e => e.KyTruocNTe).HasColumnName("KyTruocNTe");
                        
                            entity.Property(e => e.LuyKeTuDauNam).HasColumnName("LuyKeTuDauNam");
                        
                            entity.Property(e => e.LuyKeTuDauNamNgoaiTe).HasColumnName("LuyKeTuDauNamNgoaiTe");
                        
                            entity.Property(e => e.LuyKeTuDauNamNTe).HasColumnName("LuyKeTuDauNamNTe");
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MAIN).HasColumnName("MAIN").HasMaxLength(1);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MASO).HasColumnName("MASO").HasMaxLength(50);
                        
                            entity.Property(e => e.OrderBy).HasColumnName("OrderBy");
                        
                            entity.Property(e => e.OrderByCongThuc).HasColumnName("OrderByCongThuc");
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.ThuyetMinh).HasColumnName("ThuyetMinh").HasMaxLength(50);
                        
                            entity.Property(e => e.TKXL).HasColumnName("TKXL").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<RP_LUU_CHUYEN_TTE_200>(entity =>
                    {
                        entity.HasKey(e => e.ID);
                        entity.ToTable("RP LUU CHUYEN TTE 200");
                        
                            entity.Property(e => e.BenNo).HasColumnName("BenNo");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.CongThuc).HasColumnName("CongThuc").HasMaxLength(250);
                        
                            entity.Property(e => e.DieuKienKhac).HasColumnName("DieuKienKhac").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.ID).HasColumnName("ID");
                        
                            entity.Property(e => e.InDam).HasColumnName("InDam");
                        
                            entity.Property(e => e.InNghieng).HasColumnName("InNghieng");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.KhongIn).HasColumnName("KhongIn");
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.KyNay).HasColumnName("KyNay");
                        
                            entity.Property(e => e.KyNayNgoaiTe).HasColumnName("KyNayNgoaiTe");
                        
                            entity.Property(e => e.KyNayNTe).HasColumnName("KyNayNTe");
                        
                            entity.Property(e => e.KyTruoc).HasColumnName("KyTruoc");
                        
                            entity.Property(e => e.KyTruocNgoaiTe).HasColumnName("KyTruocNgoaiTe");
                        
                            entity.Property(e => e.KyTruocNTe).HasColumnName("KyTruocNTe");
                        
                            entity.Property(e => e.LuyKeTuDauNam).HasColumnName("LuyKeTuDauNam");
                        
                            entity.Property(e => e.LuyKeTuDauNamNgoaiTe).HasColumnName("LuyKeTuDauNamNgoaiTe");
                        
                            entity.Property(e => e.LuyKeTuDauNamNTe).HasColumnName("LuyKeTuDauNamNTe");
                        
                            entity.Property(e => e.MaBoPhan).HasColumnName("MaBoPhan").HasMaxLength(100);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDiaDiem).HasColumnName("MaDiaDiem").HasMaxLength(100);
                        
                            entity.Property(e => e.MaDuAn).HasColumnName("MaDuAn").HasMaxLength(250);
                        
                            entity.Property(e => e.MAIN).HasColumnName("MAIN").HasMaxLength(1);
                        
                            entity.Property(e => e.MaNghanh).HasColumnName("MaNghanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MASO).HasColumnName("MASO").HasMaxLength(50);
                        
                            entity.Property(e => e.OrderBy).HasColumnName("OrderBy");
                        
                            entity.Property(e => e.OrderByCongThuc).HasColumnName("OrderByCongThuc");
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.ThuyetMinh).HasColumnName("ThuyetMinh").HasMaxLength(50);
                        
                            entity.Property(e => e.TKXL).HasColumnName("TKXL").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    //Unable to generate entity type for table 'dbo.RP NHAT KY CHUNG'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP SO CAI'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP SO CAI TONG HOP'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP THUEVAT RA'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP THUEVAT VAO'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP TRUY VAN ALL'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP11 CHI TIET'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP12SOQUY'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP21 CHI TIET'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP22 CHUNG TU'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP31 CHI TIET'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP32 CHUNG TU'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP33 BAO CAO'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP33 BAO CAO TMP'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP33_BAO_CAO_VC'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP34 THONG KE'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP35 PTBHANG '. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP35 PTBHANG TMP'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP42 CHUNG TU'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP51 CHI TIET NXT'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP51 TON KHO'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP51 TON KHO TMP'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP61 CNO CTRINH'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP61 CONG NO'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP61 CONG NO TMP'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP71 BC SAN XUAT'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP79 THE TINH GT'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP81 CHI TIET'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RP89 CHI TIET'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RPG CHUNG TU GS'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.RZP BAO CAO'. table have no primary key
                    
                    modelBuilder.Entity<S01_USERS>(entity =>
                    {
                        entity.HasKey(e => e.UserID);
                        entity.ToTable("S01_USERS");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.AdminType).HasColumnName("AdminType");
                        
                            entity.Property(e => e.ChoPhepDCT).HasColumnName("ChoPhepDCT");
                        
                            entity.Property(e => e.ChucVu).HasColumnName("ChucVu").HasMaxLength(250);
                        
                            entity.Property(e => e.Current_Status).HasColumnName("Current_Status");
                        
                            entity.Property(e => e.DCCoQuan).HasColumnName("DCCoQuan").HasMaxLength(250);
                        
                            entity.Property(e => e.DCNhaRieng).HasColumnName("DCNhaRieng").HasMaxLength(250);
                        
                            entity.Property(e => e.DTCoQuan).HasColumnName("DTCoQuan").HasMaxLength(100);
                        
                            entity.Property(e => e.DTDD).HasColumnName("DTDD").HasMaxLength(100);
                        
                            entity.Property(e => e.DTNhaRieng).HasColumnName("DTNhaRieng").HasMaxLength(100);
                        
                            entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(100);
                        
                            entity.Property(e => e.Fax).HasColumnName("Fax").HasMaxLength(100);
                        
                            entity.Property(e => e.Fullname).HasColumnName("Fullname").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChuDuyet).HasColumnName("GhiChuDuyet").HasMaxLength(-1);
                        
                            entity.Property(e => e.HanMucDCTTD).HasColumnName("HanMucDCTTD");
                        
                            entity.Property(e => e.HanMucDCTTT).HasColumnName("HanMucDCTTT");
                        
                            entity.Property(e => e.HinhAnh).HasColumnName("HinhAnh").HasMaxLength(2147483647);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(250);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaHoaTT).HasColumnName("MaHoaTT");
                        
                            entity.Property(e => e.MaNVien).HasColumnName("MaNVien").HasMaxLength(50);
                        
                            entity.Property(e => e.MaPhanHe).HasColumnName("MaPhanHe").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayBDHLD).HasColumnName("NgayBDHLD");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(150);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(150);
                        
                            entity.Property(e => e.NgayKTHLD).HasColumnName("NgayKTHLD");
                        
                            entity.Property(e => e.NhomCap).HasColumnName("NhomCap");
                        
                            entity.Property(e => e.NhomUser).HasColumnName("NhomUser").HasMaxLength(100);
                        
                            entity.Property(e => e.ODCheck1).HasColumnName("ODCheck1");
                        
                            entity.Property(e => e.ODCheck10).HasColumnName("ODCheck10");
                        
                            entity.Property(e => e.ODCheck2).HasColumnName("ODCheck2");
                        
                            entity.Property(e => e.ODCheck3).HasColumnName("ODCheck3");
                        
                            entity.Property(e => e.ODCheck4).HasColumnName("ODCheck4");
                        
                            entity.Property(e => e.ODCheck5).HasColumnName("ODCheck5");
                        
                            entity.Property(e => e.ODCheck6).HasColumnName("ODCheck6");
                        
                            entity.Property(e => e.ODCheck7).HasColumnName("ODCheck7");
                        
                            entity.Property(e => e.ODCheck8).HasColumnName("ODCheck8");
                        
                            entity.Property(e => e.ODCheck9).HasColumnName("ODCheck9");
                        
                            entity.Property(e => e.OPCheck1).HasColumnName("OPCheck1");
                        
                            entity.Property(e => e.OPCheck10).HasColumnName("OPCheck10");
                        
                            entity.Property(e => e.OPCheck2).HasColumnName("OPCheck2");
                        
                            entity.Property(e => e.OPCheck3).HasColumnName("OPCheck3");
                        
                            entity.Property(e => e.OPCheck4).HasColumnName("OPCheck4");
                        
                            entity.Property(e => e.OPCheck5).HasColumnName("OPCheck5");
                        
                            entity.Property(e => e.OPCheck6).HasColumnName("OPCheck6");
                        
                            entity.Property(e => e.OPCheck7).HasColumnName("OPCheck7");
                        
                            entity.Property(e => e.OPCheck8).HasColumnName("OPCheck8");
                        
                            entity.Property(e => e.OPCheck9).HasColumnName("OPCheck9");
                        
                            entity.Property(e => e.Password).HasColumnName("Password").HasMaxLength(100);
                        
                            entity.Property(e => e.PhongBan).HasColumnName("PhongBan").HasMaxLength(250);
                        
                            entity.Property(e => e.Status_Text).HasColumnName("Status_Text").HasMaxLength(500);
                        
                            entity.Property(e => e.SuaDenNgay).HasColumnName("SuaDenNgay");
                        
                            entity.Property(e => e.SuaTuNgay).HasColumnName("SuaTuNgay");
                        
                            entity.Property(e => e.TenNVien).HasColumnName("TenNVien").HasMaxLength(250);
                        
                            entity.Property(e => e.ThemDenNgay).HasColumnName("ThemDenNgay");
                        
                            entity.Property(e => e.ThemTuNgay).HasColumnName("ThemTuNgay");
                        
                            entity.Property(e => e.ThuaLenh).HasColumnName("ThuaLenh").HasMaxLength(250);
                        
                            entity.Property(e => e.Usercode).HasColumnName("Usercode").HasMaxLength(100);
                        
                            entity.Property(e => e.UserID).HasColumnName("UserID").HasMaxLength(100);
                        
                            entity.Property(e => e.Username).HasColumnName("Username").HasMaxLength(100);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(150);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(150);
                        
                            entity.Property(e => e.Website).HasColumnName("Website").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<S02_PHANQUYEN>(entity =>
                    {
                        entity.HasKey(e => e.MaPhanQuyen);
                        entity.ToTable("S02_PHANQUYEN");
                        
                            entity.Property(e => e.DuocIn).HasColumnName("DuocIn");
                        
                            entity.Property(e => e.DuocSua).HasColumnName("DuocSua");
                        
                            entity.Property(e => e.DuocThem).HasColumnName("DuocThem");
                        
                            entity.Property(e => e.DuocXoa).HasColumnName("DuocXoa");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChuKhac).HasColumnName("GhiChuKhac").HasMaxLength(250);
                        
                            entity.Property(e => e.HienThi).HasColumnName("HienThi");
                        
                            entity.Property(e => e.LaPhieu).HasColumnName("LaPhieu");
                        
                            entity.Property(e => e.LoaiXem).HasColumnName("LoaiXem").HasMaxLength(20);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaPhanQuyen).HasColumnName("MaPhanQuyen");
                        
                            entity.Property(e => e.MENU).HasColumnName("MENU").HasMaxLength(150);
                        
                            entity.Property(e => e.NhomMenu).HasColumnName("NhomMenu").HasMaxLength(150);
                        
                            entity.Property(e => e.Root).HasColumnName("Root");
                        
                            entity.Property(e => e.SoftType).HasColumnName("SoftType").HasMaxLength(20);
                        
                            entity.Property(e => e.TempClient).HasColumnName("TempClient").HasMaxLength(30);
                        
                            entity.Property(e => e.TenMuc).HasColumnName("TenMuc").HasMaxLength(250);
                        
                            entity.Property(e => e.TenNhom).HasColumnName("TenNhom").HasMaxLength(250);
                        
                            entity.Property(e => e.UserID).HasColumnName("UserID").HasMaxLength(50);
                        
                    });
                    
                    modelBuilder.Entity<S02_THIETLAP>(entity =>
                    {
                        entity.HasKey(e => e.IDTC);
                        entity.ToTable("S02_THIETLAP");
                        
                            entity.Property(e => e.CaiDat).HasColumnName("CaiDat").HasMaxLength(30);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDTC).HasColumnName("IDTC");
                        
                            entity.Property(e => e.Loai).HasColumnName("Loai").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.TuyChon).HasColumnName("TuyChon").HasMaxLength(250);
                        
                    });
                    
                    //Unable to generate entity type for table 'dbo.S03_HISTORY'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.S04_USERLOG'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.S06_GENSET'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.S06_RESET'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.S07_DATA BACKUP'. table have no primary key
                    
                    modelBuilder.Entity<S07_SET_HOP_DATA>(entity =>
                    {
                        entity.HasKey(e => e.IDHN);
                        entity.ToTable("S07_SET HOP DATA");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CacBang).HasColumnName("CacBang").HasMaxLength(-1);
                        
                            entity.Property(e => e.DenNgay).HasColumnName("DenNgay");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DieuKien).HasColumnName("DieuKien").HasMaxLength(50);
                        
                            entity.Property(e => e.GiaTri).HasColumnName("GiaTri").HasMaxLength(250);
                        
                            entity.Property(e => e.IDHN).HasColumnName("IDHN");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaHN).HasColumnName("MaHN").HasMaxLength(250);
                        
                            entity.Property(e => e.NhomHN).HasColumnName("NhomHN").HasMaxLength(150);
                        
                            entity.Property(e => e.Number1).HasColumnName("Number1");
                        
                            entity.Property(e => e.Number2).HasColumnName("Number2");
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenHN).HasColumnName("TenHN").HasMaxLength(250);
                        
                            entity.Property(e => e.Truong).HasColumnName("Truong").HasMaxLength(50);
                        
                            entity.Property(e => e.TuNgay).HasColumnName("TuNgay");
                        
                    });
                    
                    modelBuilder.Entity<S07_SET_HOP_SERVER>(entity =>
                    {
                        entity.HasKey(e => e.IDHN);
                        entity.ToTable("S07_SET HOP SERVER");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.CacBang).HasColumnName("CacBang").HasMaxLength(-1);
                        
                            entity.Property(e => e.CacDanhMuc).HasColumnName("CacDanhMuc").HasMaxLength(-1);
                        
                            entity.Property(e => e.CacNgay).HasColumnName("CacNgay").HasMaxLength(250);
                        
                            entity.Property(e => e.DaLuu).HasColumnName("DaLuu").HasMaxLength(100);
                        
                            entity.Property(e => e.DenNgay).HasColumnName("DenNgay");
                        
                            entity.Property(e => e.DiaChiIP).HasColumnName("DiaChiIP").HasMaxLength(150);
                        
                            entity.Property(e => e.DiaChiIPLocal).HasColumnName("DiaChiIPLocal").HasMaxLength(150);
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DieuKien).HasColumnName("DieuKien").HasMaxLength(50);
                        
                            entity.Property(e => e.GiaTri).HasColumnName("GiaTri").HasMaxLength(250);
                        
                            entity.Property(e => e.IDHN).HasColumnName("IDHN");
                        
                            entity.Property(e => e.KhacServer).HasColumnName("KhacServer");
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaHN).HasColumnName("MaHN").HasMaxLength(250);
                        
                            entity.Property(e => e.NhomSV).HasColumnName("NhomSV").HasMaxLength(150);
                        
                            entity.Property(e => e.PassServer).HasColumnName("PassServer").HasMaxLength(100);
                        
                            entity.Property(e => e.PassServerLocal).HasColumnName("PassServerLocal").HasMaxLength(100);
                        
                            entity.Property(e => e.PortServer).HasColumnName("PortServer").HasMaxLength(15);
                        
                            entity.Property(e => e.PortServerLocal).HasColumnName("PortServerLocal").HasMaxLength(15);
                        
                            entity.Property(e => e.S07CK1).HasColumnName("S07CK1");
                        
                            entity.Property(e => e.S07CK2).HasColumnName("S07CK2");
                        
                            entity.Property(e => e.S07CK3).HasColumnName("S07CK3");
                        
                            entity.Property(e => e.S07Data1).HasColumnName("S07Data1");
                        
                            entity.Property(e => e.S07Data2).HasColumnName("S07Data2");
                        
                            entity.Property(e => e.S07Data3).HasColumnName("S07Data3");
                        
                            entity.Property(e => e.S07Number1).HasColumnName("S07Number1");
                        
                            entity.Property(e => e.S07Number2).HasColumnName("S07Number2");
                        
                            entity.Property(e => e.S07Number3).HasColumnName("S07Number3");
                        
                            entity.Property(e => e.S07Number4).HasColumnName("S07Number4");
                        
                            entity.Property(e => e.S07Number5).HasColumnName("S07Number5");
                        
                            entity.Property(e => e.S07String1).HasColumnName("S07String1").HasMaxLength(250);
                        
                            entity.Property(e => e.S07String2).HasColumnName("S07String2").HasMaxLength(250);
                        
                            entity.Property(e => e.S07String3).HasColumnName("S07String3").HasMaxLength(250);
                        
                            entity.Property(e => e.S07String4).HasColumnName("S07String4").HasMaxLength(250);
                        
                            entity.Property(e => e.S07String5).HasColumnName("S07String5").HasMaxLength(-1);
                        
                            entity.Property(e => e.SauKhoang).HasColumnName("SauKhoang").HasMaxLength(20);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TatCaDM).HasColumnName("TatCaDM");
                        
                            entity.Property(e => e.TenDuLieu).HasColumnName("TenDuLieu").HasMaxLength(200);
                        
                            entity.Property(e => e.TenDuLieuLocal).HasColumnName("TenDuLieuLocal").HasMaxLength(200);
                        
                            entity.Property(e => e.TenServer).HasColumnName("TenServer").HasMaxLength(100);
                        
                            entity.Property(e => e.TenServerLocal).HasColumnName("TenServerLocal").HasMaxLength(100);
                        
                            entity.Property(e => e.TheoNgay).HasColumnName("TheoNgay");
                        
                            entity.Property(e => e.ThoiGian).HasColumnName("ThoiGian");
                        
                            entity.Property(e => e.TinhTheo).HasColumnName("TinhTheo").HasMaxLength(100);
                        
                            entity.Property(e => e.Truong).HasColumnName("Truong").HasMaxLength(50);
                        
                            entity.Property(e => e.TuNgay).HasColumnName("TuNgay");
                        
                            entity.Property(e => e.UserServer).HasColumnName("UserServer").HasMaxLength(100);
                        
                            entity.Property(e => e.UserServerLocal).HasColumnName("UserServerLocal").HasMaxLength(100);
                        
                            entity.Property(e => e.VaoLuc).HasColumnName("VaoLuc").HasMaxLength(50);
                        
                            entity.Property(e => e.XoaCuChepDe).HasColumnName("XoaCuChepDe");
                        
                    });
                    
                    modelBuilder.Entity<S08_DK_KHOA_SO>(entity =>
                    {
                        entity.HasKey(e => e.IDDK);
                        entity.ToTable("S08_DK KHOA SO");
                        
                            entity.Property(e => e.CaiDat).HasColumnName("CaiDat").HasMaxLength(30);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.IDDK).HasColumnName("IDDK");
                        
                            entity.Property(e => e.Loai).HasColumnName("Loai").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.TaoSoDu).HasColumnName("TaoSoDu");
                        
                    });
                    
                    modelBuilder.Entity<S11_KIEM_TRA_DB>(entity =>
                    {
                        entity.HasKey(e => e.IDKT);
                        entity.ToTable("S11_KIEM TRA DB");
                        
                            entity.Property(e => e.Chinese).HasColumnName("Chinese").HasMaxLength(250);
                        
                            entity.Property(e => e.Chon).HasColumnName("Chon");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.English).HasColumnName("English").HasMaxLength(250);
                        
                            entity.Property(e => e.French).HasColumnName("French").HasMaxLength(250);
                        
                            entity.Property(e => e.IDKT).HasColumnName("IDKT");
                        
                            entity.Property(e => e.Japanese).HasColumnName("Japanese").HasMaxLength(250);
                        
                            entity.Property(e => e.Korean).HasColumnName("Korean").HasMaxLength(250);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaTK).HasColumnName("MaTK").HasMaxLength(50);
                        
                            entity.Property(e => e.MaXuLy).HasColumnName("MaXuLy").HasMaxLength(150);
                        
                            entity.Property(e => e.NoiDungLoi).HasColumnName("NoiDungLoi").HasMaxLength(-1);
                        
                            entity.Property(e => e.Other).HasColumnName("Other").HasMaxLength(250);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenXuLy).HasColumnName("TenXuLy").HasMaxLength(250);
                        
                            entity.Property(e => e.Vietnamese).HasColumnName("Vietnamese").HasMaxLength(250);
                        
                    });
                    
                    modelBuilder.Entity<S12_CONG_THU>(entity =>
                    {
                        entity.HasKey(e => e.IDCT);
                        entity.ToTable("S12_CONG_THU");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDCT).HasColumnName("IDCT");
                        
                            entity.Property(e => e.Loai).HasColumnName("Loai").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.NoiDung).HasColumnName("NoiDung").HasMaxLength(-1);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.Truong).HasColumnName("Truong").HasMaxLength(100);
                        
                    });
                    
                    modelBuilder.Entity<S13_VIEW_FIELD>(entity =>
                    {
                        entity.HasKey(e => e.IDVF);
                        entity.ToTable("S13_VIEW_FIELD");
                        
                            entity.Property(e => e.Active).HasColumnName("Active");
                        
                            entity.Property(e => e.DienGiai).HasColumnName("DienGiai").HasMaxLength(250);
                        
                            entity.Property(e => e.DienGiai2).HasColumnName("DienGiai2").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(250);
                        
                            entity.Property(e => e.GhiChu2).HasColumnName("GhiChu2").HasMaxLength(250);
                        
                            entity.Property(e => e.IDVF).HasColumnName("IDVF");
                        
                            entity.Property(e => e.Loai).HasColumnName("Loai").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.NoiDungSQL).HasColumnName("NoiDungSQL").HasMaxLength(-1);
                        
                            entity.Property(e => e.PhanHe).HasColumnName("PhanHe").HasMaxLength(50);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TieuDe).HasColumnName("TieuDe").HasMaxLength(250);
                        
                            entity.Property(e => e.TruongHT).HasColumnName("TruongHT").HasMaxLength(-1);
                        
                            entity.Property(e => e.TruongHT2).HasColumnName("TruongHT2").HasMaxLength(-1);
                        
                            entity.Property(e => e.TruongHT3).HasColumnName("TruongHT3").HasMaxLength(-1);
                        
                            entity.Property(e => e.TruongHT4).HasColumnName("TruongHT4").HasMaxLength(-1);
                        
                    });
                    
                    modelBuilder.Entity<S14_FILES_DATA>(entity =>
                    {
                        entity.HasKey(e => e.IDFD);
                        entity.ToTable("S14_FILES_DATA");
                        
                            entity.Property(e => e.Data).HasColumnName("Data").HasMaxLength(-1);
                        
                            entity.Property(e => e.DuocXem).HasColumnName("DuocXem");
                        
                            entity.Property(e => e.DuocXoa).HasColumnName("DuocXoa");
                        
                            entity.Property(e => e.DuongDan).HasColumnName("DuongDan").HasMaxLength(-1);
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.IDFD).HasColumnName("IDFD");
                        
                            entity.Property(e => e.LoaiCT).HasColumnName("LoaiCT").HasMaxLength(50);
                        
                            entity.Property(e => e.LoaiFile).HasColumnName("LoaiFile").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayCT).HasColumnName("NgayCT");
                        
                            entity.Property(e => e.NGAYGIOSUA).HasColumnName("NGAYGIOSUA").HasMaxLength(100);
                        
                            entity.Property(e => e.NGAYGIOTHEM).HasColumnName("NGAYGIOTHEM").HasMaxLength(100);
                        
                            entity.Property(e => e.NoiDung).HasColumnName("NoiDung").HasMaxLength(-1);
                        
                            entity.Property(e => e.RECKEY).HasColumnName("RECKEY").HasMaxLength(100);
                        
                            entity.Property(e => e.SoCT).HasColumnName("SoCT").HasMaxLength(50);
                        
                            entity.Property(e => e.TenFile).HasColumnName("TenFile").HasMaxLength(-1);
                        
                            entity.Property(e => e.TenLoai).HasColumnName("TenLoai").HasMaxLength(250);
                        
                            entity.Property(e => e.USERSUA).HasColumnName("USERSUA").HasMaxLength(50);
                        
                            entity.Property(e => e.USERTHEM).HasColumnName("USERTHEM").HasMaxLength(50);
                        
                    });
                    
                    modelBuilder.Entity<S15_IMPORT_INFO>(entity =>
                    {
                        entity.HasKey(e => e.IDIP);
                        entity.ToTable("S15_IMPORT_INFO");
                        
                            entity.Property(e => e.GhiChu).HasColumnName("GhiChu").HasMaxLength(-1);
                        
                            entity.Property(e => e.IDIP).HasColumnName("IDIP");
                        
                            entity.Property(e => e.Loai).HasColumnName("Loai").HasMaxLength(100);
                        
                            entity.Property(e => e.LoaiXL).HasColumnName("LoaiXL").HasMaxLength(50);
                        
                            entity.Property(e => e.MaChiNhanh).HasColumnName("MaChiNhanh").HasMaxLength(100);
                        
                            entity.Property(e => e.MaSo).HasColumnName("MaSo").HasMaxLength(100);
                        
                            entity.Property(e => e.NgayGio).HasColumnName("NgayGio");
                        
                            entity.Property(e => e.NoiDung).HasColumnName("NoiDung").HasMaxLength(-1);
                        
                            entity.Property(e => e.PhanHe).HasColumnName("PhanHe").HasMaxLength(50);
                        
                            entity.Property(e => e.STT).HasColumnName("STT");
                        
                            entity.Property(e => e.TenMayTinh).HasColumnName("TenMayTinh").HasMaxLength(100);
                        
                            entity.Property(e => e.TieuDe).HasColumnName("TieuDe").HasMaxLength(250);
                        
                            entity.Property(e => e.Username).HasColumnName("Username").HasMaxLength(100);
                        
                    });
                    
                    //Unable to generate entity type for table 'dbo.SUMTONGTMP'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.TABLE_AUTO'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.TABLETMP_AUTO'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.tempsum'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.THONG TIN DV'. table have no primary key
                    
                    //Unable to generate entity type for table 'dbo.ZFILTERDATA'. table have no primary key
                    
                    }
                }
            }
            