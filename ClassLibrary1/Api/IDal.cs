//בס"ד
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDal
    {
        public IDalOffer Offer { get ; }
        public IDalPerson Person { get; }
        public IDalRequest Request { get; }
        public IDalSchedule Schedule { get; }

    }
}
