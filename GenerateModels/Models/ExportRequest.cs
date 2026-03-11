using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenerateModels.Models
{
    public class ExportRequest
    {
        public string urlExcel { get; set; }
        public string urlFN { get; set; }
        public List<AvariablePrj.lstImage> lstImage { get; set; }
        public List<AvariablePrj.lstTextReplace> lstTextReplace { get; set; }
        public List<int> lstAutoSizeColumn { get; set; }
        public int endrow { get; set; }
        public int endColumn { get; set; }
    }
}