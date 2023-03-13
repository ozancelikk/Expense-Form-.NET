using Core.Utilities.HardwareInfo.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CoreCpuListDto
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public List<CpuCore> CpuCoreList { get; set; }
    }
}
