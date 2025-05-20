/*//בס"ד
using Dal.Api;
using Dal.Models;
using Dal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalManager : IDal
    {
        public IDalOffer Offer { get ; }
        public IDalPerson Person { get ; }
        public IDalRequest Request { get ; }
        public IDalSchedule Schedule { get ; }

        public DalManager()
        {
            dbcontext data = new dbcontext();
            Offer = new DalOfferService(data);
            Person = new DalPersonService(data);
            Request = new DalRequestService(data);
            Schedule = new DalScheduleService(data);
        }
    }
}
*/
using Dal.Api;
using Dal.Models;
using Dal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalManager : IDal
    {
        public IDalOffer Offer { get; }
        public IDalPerson Person { get; }
        public IDalRequest Request { get; }
        public IDalSchedule Schedule { get; }

        // שינוי הקונסטרקטור לקבל את ה-dbcontext מבחוץ
        public DalManager()
        {
            dbcontext data = new dbcontext();
            Offer = new DalOfferService(data);
            Person = new DalPersonService(data);
            Request = new DalRequestService(data);
            Schedule = new DalScheduleService(data);
        }
    }
}