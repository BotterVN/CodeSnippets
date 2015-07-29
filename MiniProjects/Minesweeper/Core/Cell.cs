using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Cell
    {
        public bool IsOpened { get; set; }
        public bool IsFlagged { get; set; }
        public int Value { get; set; }

        public Cell()
        {
            IsOpened = false;
            IsFlagged = false;
            Value = 0;
        }
    }
}
