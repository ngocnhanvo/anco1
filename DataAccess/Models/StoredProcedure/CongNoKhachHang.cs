using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAcess.StoredProcedure
{
    public class CongNoKhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public double? TonDauKyNo { get; set; }
        public double? TonDauKyCo { get; set; }
        public double? PhatSinhNoTK { get; set; }
        public double? PhatSinhCoTK { get; set; }
        public double? TonCuoiKyNo { get; set; }
        public double? TonCuoiKyCo { get; set; }
    }
}
