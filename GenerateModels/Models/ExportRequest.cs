using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenerateModels.Models
{
    public class ExportRequest
    {
        public string nameApp { get; set; }
        public string urlExcel { get; set; }
        public string urlFN { get; set; }
        public List<AvariablePrj.lstText> lstText { get; set; }
        public List<AvariablePrj.lstImage> lstImage { get; set; }
        public List<AvariablePrj.lstTextReplace> lstTextReplace { get; set; }
        public List<int> lstAutoSizeColumn { get; set; }
        public List<int> lstBlankRow { get; set; }
        public int endrow { get; set; }
        public int endColumn { get; set; }
    }
}