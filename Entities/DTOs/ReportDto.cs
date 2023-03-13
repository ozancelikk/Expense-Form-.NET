using Core.Entities.Concrete;
using Core.Entities.Concrete.DBEntities;

namespace Entities.DTOs
{
    public class ReportDto
    {
        public Schedule Schedule { get; set; }
        public bool IsEnabled { get; set; }
        public Report Report { get; set; }
        public ReportGroup ReportGroup { get; set; }
        public string ReportStoreId { get; set; }
        public string UsedDeviceID { get; set; }
        public string Function { get; set; }
    }
}

