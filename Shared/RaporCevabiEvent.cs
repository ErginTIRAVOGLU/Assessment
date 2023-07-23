using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class RaporCevabiEvent
    {
        public Guid UUID { get; set; }
        public List<RaporIcerik> RaporIcerigi { get; set; }
    }
}
