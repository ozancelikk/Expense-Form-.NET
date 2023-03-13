using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ExpenceDetailDto
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string ExpenceId { get; set; }
        public string DocumentDate { get; set; }
        public string VouncherNo { get; set; }
        public string Company { get; set; }
        public string VouncherType { get; set; }
        public double TaxRate { get; set; }
        public double Total { get; set; }
        public double TaxTotal { get; set; }
        public double TaxSum { get; set; }
        public string VouncherImage { get; set; }
    }
}
