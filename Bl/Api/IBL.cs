//בס"ד
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBL
    {
        IBLOffers Offers { get;}
        IBLPerson Person { get;}
        IBLRequests Requests { get;}
        IBLSchedule Schedule { get; }
    }

}
