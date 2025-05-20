//בס"ד
using Bl.Api;
using Bl.Services;
using Dal;
using Dal.Api;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class BLManager : IBL
    {
        public IBLOffers Offers { get; }

        public IBLPerson Person { get; }

        public IBLRequests Requests { get; }

        public IBLSchedule Schedule { get; }
        public BLManager()
        {
            //IDal dal=new DalManager();
           // Offers=new BLOffersService(dal);
          /*  Person=new BLPersonService(dal);
            Requests=new BLRequestsService(dal, Offers);
            Schedule=new BLScheduleService(dal);*/

            ServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddSingleton<IBLOffers, BLOffersService>();
            serviceDescriptors.AddSingleton<IDal,DalManager>();
            serviceDescriptors.AddSingleton<IBLPerson,BLPersonService>();
            serviceDescriptors.AddSingleton<IBLSchedule,BLScheduleService>(); 
            serviceDescriptors.AddSingleton<IBLRequests,BLRequestsService>();

            ServiceProvider provider = serviceDescriptors.BuildServiceProvider();
            Offers=provider.GetRequiredService<IBLOffers>();
            Person=provider.GetRequiredService<IBLPerson>();
            Schedule=provider.GetRequiredService<IBLSchedule>();
            Requests=provider.GetRequiredService<IBLRequests>();
        }
    }
}
