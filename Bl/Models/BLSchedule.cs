//בס"ד
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public class BLSchedule
    {
        public int Code { get; set; }

        public string DayInWeek { get; set; } = null!;

        public TimeSpan FromTime { get; set; }

        public TimeSpan ToTime { get; set; }
        public bool? Available { get; set; }

        public string PersonId { get; set; } = null!;

        //public virtual Person Person { get; set; } = null!;
    }
}
