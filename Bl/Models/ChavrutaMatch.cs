using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public class ChavrutaMatch
    {
        public BLOffer Offer { get; set; }
        public List<BLSchedule> Schedules { get; set; }
    }
}
