/*//בס"ד
using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
{
    public class BLRequestsService : IBLRequests
    {
        IDalRequest dal;
        IBLOffers offers;
        IBLSchedule schedule;
        IBLPerson person;

        public BLRequestsService(IDal dal, IBLOffers offers, IBLSchedule schedule, IBLPerson person)
        {
            this.dal = dal.Request;
            this.offers = offers;
            this.schedule = schedule;
            this.person = person;
        }
        public List<BLRequest> Get()
        {
            List<Request> r = dal.Get();
            List<BLRequest> blr = new();
            r.ForEach(x => blr.Add(ToBLRequest(x)));
            return blr;
        }
        public BLRequest GetByCode(int code)
        {
            List<Request> r = dal.Get();
            BLRequest blr = new();
            r.ForEach(x => {
                if (x.Code == code) { blr = ToBLRequest(x); }
            });
            return blr;
        }

        public List<BLRequest> GetByBook(string book)
        {
            List<Request> o = dal.Get();
            List<BLRequest> blo = new();
            o.ForEach(x => {
                if (x.Book == book) { blo.Add(ToBLRequest(x)); }
            });
            return blo;
        }


        public List<BLRequest> GetBySubject(string subject)
        {
            List<Request> o = dal.Get();
            List<BLRequest> blo = new();
            o.ForEach(x => {
                if (x.Subject == subject) { blo.Add(ToBLRequest(x)); }
            });
            return blo;
        }

        public async void Add(BLRequest request)
        {
            BLPerson p =await person.GetById(request.PersonId);
            if (p != null && p.Role == "request")
            {
                dal.Add(ToRequest(request));
            }
            else
                throw new Exception("ת.ז לא קיימת במערכת.");
        }

        public void Update(BLRequest request, int code)
        {
            dal.Update(ToRequest(request), code);
        }
        public void Delete(int code)
        {
            dal.Delete(code);
        }

        //---------------------------------
        //public class ChavrutaMatch
        //{
        //    public BLOffer Offer { get; set; }
        //    public List<BLSchedule> Schedules { get; set; }
        //}

        public async List<ChavrutaMatch> FindChavruta(int code)
        {
            //r-הבקשה
            BLRequest r = ToBLRequest(dal.GetByCode(code));
            BLPerson pr =await person.GetById(r.PersonId);
            List<ChavrutaMatch> matches = new();

            //o-רשימת כל ההצעות המתאימות
            List<BLOffer> o = ((BLOffersService)offers).Get();
            o.ForEach(async (x) =>
            {
                var a = await person.GetById(x.PersonId);
                //List<BLSchedule> s = schedule.MatchSchedule(r.PersonId, x.PersonId);
                if (a.Gender == pr.Gender &&
                    x.Subject == r.Subject && x.Mode == r.Mode  
                    //person.GetById(x.PersonId).Denomination == pr.Denomination
                   // && s.Count > 0
                    && (r.Book == null || x.Book == null || r.Book == x.Book))
                {
                    matches.Add(new ChavrutaMatch
                    {
                        Offer = x,
                        Schedules = schedule.GetById(x.PersonId)
                    });
                }
            });

            return matches;
        }

        //---------------------------------

        //public Dictionary<BLOffer, List<BLSchedule>> FindChavruta(int code)
        //{
        //    //r-הבקשה
        //    BLRequest r = ToBLRequest(dal.GetByCode(code));
        //    BLPerson pr = person.GetById(r.PersonId);
        //    Dictionary<BLOffer, List<BLSchedule>> d = new();
        //    //o-רשימת כל ההצעות המתאימות
        //    List<BLOffer> o = ((BLOffersService)offers).Get();
        //    o.ForEach((x) =>
        //    {
        //        if (person.GetById(x.PersonId).Gender == pr.Gender &&
        //            x.Subject == r.Subject && x.Mode == r.Mode
        //            && schedule.MatchSchedule(r.PersonId, x.PersonId).Count > 0
        //            && (r.Book == null || x.Book == null || r.Book == x.Book))
        //            d.Add(x, schedule.MatchSchedule(r.PersonId, x.PersonId));
        //    });
        //    return d;
        //}

        //public Dictionary<BLOffer, List<BLSchedule>> FindChavruta(int code, int schCode)
        //{
        //    //r-הבקשה
        //    BLRequest r = ToBLRequest(dal.GetByCode(code));
        //    BLPerson pr = person.GetById(r.PersonId);
        //    Dictionary<BLOffer, List<BLSchedule>> d = new();
        //    //o-רשימת כל ההצעות המתאימות
        //    List<BLOffer> o = ((BLOffersService)offers).Get();
        //    o.ForEach((x) =>
        //    {
        //        if (person.GetById(x.PersonId).Gender == pr.Gender &&
        //            x.Subject == r.Subject && x.Mode == r.Mode
        //            && schedule.MatchSchedule(schCode, x.PersonId).Count > 0
        //            && (r.Book == null || x.Book == null || r.Book == x.Book))
        //            d.Add(x, schedule.MatchSchedule(r.PersonId, x.PersonId));
        //    });
        //    return d;
        //}

        //select chavruta-update schedule of offers

        //public void SelectChavruta(int offCode, int reqCode, int schCode, TimeSpan from, TimeSpan to)
        //{
        //    //קוד של הצעה וזמן התחלה וסיום של בקשה
        //    BLRequest blr = ToBLRequest(dal.GetByCode(reqCode));
        //    blr.ChavrutaCode = offCode;
        //    BLOffer blo = offers.GetByCode(offCode);
        //    schedule.FixSchedule(blo.PersonId, blr.PersonId, schCode, from, to);
        //}

        void SelectChavruta(string id, int reqCode, int chaCode, int chaScheduleCode)
        {
            BLRequest blr = ToBLRequest(dal.GetByCode(reqCode));
            blr.ChavrutaCode = chaCode;
            BLOffer blo = offers.GetByCode(chaCode);
            schedule.FixSchedule(chaScheduleCode);
            //schedule.FixSchedule(reqScheduleCode, chaScheduleCode);

        }

        private Request ToRequest(BLRequest blrequest)
        {
            return new Request()
            {
                Code = blrequest.Code,
                PersonId = blrequest.PersonId,
                Book = blrequest.Book,
                Subject = blrequest.Subject,
                Mode = blrequest.Mode,
                ChavrutaCode = blrequest.ChavrutaCode//,
                //ChavrutaCodeNavigation = blrequest.ChavrutaCodeNavigation,
                //Person = blrequest.Person
            };
        }

        private BLRequest ToBLRequest(Request request)
        {
            return new BLRequest()
            {
                Code = request.Code,
                PersonId = request.PersonId,
                Book = request.Book,
                Subject = request.Subject,
                Mode = request.Mode,
                ChavrutaCode = request.ChavrutaCode//,
                //ChavrutaCodeNavigation = request.ChavrutaCodeNavigation,
                //Person = request.Person
            };
        }

        void IBLRequests.SelectChavruta(string id, int reqCode, int chaCode, int reqScheduleCode, int chaScheduleCode)
        {
            throw new NotImplementedException();
        }
    }
}
*/
//בס"ד
using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
{
    public class BLRequestsService : IBLRequests
    {
        IDalRequest dal;
        IBLOffers offers;
        IBLSchedule schedule;
        IBLPerson person;

        public BLRequestsService(IDal dal, IBLOffers offers, IBLSchedule schedule, IBLPerson person)
        {
            this.dal = dal.Request;
            this.offers = offers;
            this.schedule = schedule;
            this.person = person;
        }

        public async Task<List<BLRequest>> Get()
        {
            try
            {
                List<Request> r = await dal.Get();
                List<BLRequest> blr = new();
                r.ForEach(x => blr.Add(ToBLRequest(x)));
                return blr;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get requests: {ex.Message}", ex);
            }
        }

        public async Task<BLRequest> GetByCode(int code)
        {
            try
            {
                Request r = await dal.GetByCode(code);
                if (r != null)
                {
                    return ToBLRequest(r);
                }
                throw new Exception($"Request with code {code} not found");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get request by code: {ex.Message}", ex);
            }
        }

        public async Task<List<BLRequest>> GetByBook(string book)
        {
            try
            {
                List<Request> requests = await dal.Get();
                List<BLRequest> filteredRequests = new();

                foreach (var request in requests)
                {
                    if (request.Book == book)
                    {
                        filteredRequests.Add(ToBLRequest(request));
                    }
                }

                return filteredRequests;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get requests by book: {ex.Message}", ex);
            }
        }

        public async Task<List<BLRequest>> GetBySubject(string subject)
        {
            try
            {
                List<Request> requests = await dal.Get();
                List<BLRequest> filteredRequests = new();

                foreach (var request in requests)
                {
                    if (request.Subject == subject)
                    {
                        filteredRequests.Add(ToBLRequest(request));
                    }
                }

                return filteredRequests;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get requests by subject: {ex.Message}", ex);
            }
        }

        public async Task<bool> Add(BLRequest request)
        {
            try
            {
                BLPerson p = await person.GetById(request.PersonId);
                if (p != null && p.Role == "request")
                {
                    await dal.Add(ToRequest(request));
                    return true;
                }
                else
                {
                    throw new Exception("ת.ז לא קיימת במערכת.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add request: {ex.Message}", ex);
            }
        }

        public async Task<bool> Update(BLRequest request, int code)
        {
            try
            {
                await dal.Update(ToRequest(request), code);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update request: {ex.Message}", ex);
            }
        }

        public async Task<bool> Delete(int code)
        {
            try
            {
                await dal.Delete(code);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete request: {ex.Message}", ex);
            }
        }

        public async Task<List<ChavrutaMatch>> FindChavruta(int code)
        {
            try
            {
                // r-הבקשה
                BLRequest r = ToBLRequest(await dal.GetByCode(code));
                BLPerson pr = await person.GetById(r.PersonId);
                List<ChavrutaMatch> matches = new();

                // o-רשימת כל ההצעות המתאימות
                List<BLOffer> o = await offers.Get();

                foreach (var offer in o)
                {
                    var offerPerson = await person.GetById(offer.PersonId);
                    List<BLSchedule> matchedSchedules = await schedule.GetById(offer.PersonId);

                    if (offerPerson.Gender == pr.Gender &&
                        offer.Subject == r.Subject &&
                        offer.Mode == r.Mode &&
                        (r.Book == null || offer.Book == null || r.Book == offer.Book) &&
                       (offer.Mode != "frontal" || (offer.Mode == "frontal" && pr.Country == offerPerson.Country)))
                    {
                        matches.Add(new ChavrutaMatch
                        {
                            Offer = offer,
                            Schedules = matchedSchedules
                        });
                    }
                }

                return matches;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to find chavruta: {ex.Message}", ex);
            }
        }

        public async Task<bool> SelectChavruta( int reqCode, int chaCode, int chaScheduleCode)
        {
            try
            {
                BLRequest blr = await GetByCode(reqCode);
                blr.ChavrutaCode = chaCode;

                BLOffer blo = await offers.GetByCode(chaCode);
                schedule.FixSchedule(chaScheduleCode);
                //schedule.Update(schedule.GetByCode(chaScheduleCode)) , chaCode);
                //await schedule.FixSchedule(chaScheduleCode);

                //await Update(blr, reqCode);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to select chavruta: {ex.Message}", ex);
            }
        }

        //public async Task<bool> SelectChavruta( int reqCode, int chaCode, int chaScheduleCode)
        //{
        //    try
        //    {
        //        BLRequest blr = await GetByCode(reqCode);
        //        blr.ChavrutaCode = chaCode;

        //        BLOffer blo = await offers.GetByCode(chaCode);
        //        // Assuming there's an implementation for this method
        //       // await schedule.FixSchedule(reqScheduleCode, chaScheduleCode);

        //        //await Update(blr, reqCode);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Failed to select chavruta with schedules: {ex.Message}", ex);
        //    }
        //}

        private Request ToRequest(BLRequest blrequest)
        {
            return new Request()
            {
                Code = blrequest.Code,
                PersonId = blrequest.PersonId,
                Book = blrequest.Book,
                Subject = blrequest.Subject,
                Mode = blrequest.Mode,
                ChavrutaCode = blrequest.ChavrutaCode
            };
        }

        private BLRequest ToBLRequest(Request request)
        {
            return new BLRequest()
            {
                Code = request.Code,
                PersonId = request.PersonId,
                Book = request.Book,
                Subject = request.Subject,
                Mode = request.Mode,
                ChavrutaCode = request.ChavrutaCode
            };
        }
    }
}



