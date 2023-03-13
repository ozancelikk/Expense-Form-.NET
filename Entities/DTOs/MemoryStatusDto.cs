using Core.Utilities.HardwareInfo.Components;

namespace Entities.DTOs
{
    public class MemoryStatusDto
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public MemoryStatus MemoryStatus { get; set; }
    }
}
