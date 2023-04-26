using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDemo
{
    public interface ISplit
    {
        public bool SplitEqually { get; set; }
        public bool SplitDifferently { get; set; }
    }
}
