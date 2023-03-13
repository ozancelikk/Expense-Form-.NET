using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UploadFileDto
    {
        public string VoucherId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
