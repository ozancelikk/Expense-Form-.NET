using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ColumnDefination
    {
        public string HeaderName { get; set; }
        public string Field { get; set; }
        public string Width { get; set; }
        public bool UnSortIcon { get; set; }
        public bool Sortable { get; set; }
        public string ValueGetter { get; set; }
        public string CellClass { get; set; }

    }
}
