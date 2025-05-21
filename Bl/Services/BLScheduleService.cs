/*//בס"ד
using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bl.Services
{
    public class BLScheduleService : IBLSchedule
    {
        IDalSchedule dal;
        IBLPerson person;

        public BLScheduleService(IDal dal,IBLPerson person)
        {
            this.dal = dal.Schedule;
            this.person = person;
        }

        public List<BLSchedule> Get()
        {
            List<Schedule> s = dal.Get();
            List<BLSchedule> bls = new();
            s.ForEach(x => bls.Add(ToBLSchedule(x)));
            return bls;
        }

        public List<BLSchedule> GetByDay(string day)
        {
            List<Schedule> s = dal.Get();
            List<BLSchedule> bls = new();
            s.ForEach(x => {
                if (x.DayInWeek == day) { bls.Add(ToBLSchedule(x)); }
            });
            return bls;
        }

        public List<BLSchedule> GetById(string id)
        {
            List<Schedule> s = dal.Get();
            List<BLSchedule> bls = new();
            s.ForEach(x => {
                if (x.PersonId == id) { bls.Add(ToBLSchedule(x)); }
            });
            return bls;
        }
        public BLSchedule GetByCode(int code)
        {
            BLSchedule s = ToBLSchedule(dal.GetByCode(code));
            return s;
        }

        public void Update(BLSchedule schedule, int code)
        {
            dal.Update(ToSchedule(schedule), code);
        }
        public void Add(BLSchedule schedule)
        {
            dal.Add(ToSchedule(schedule));
        }

        public void DeleteById(string id)
        {
            List<BLSchedule> s = GetById(id);
            s.ForEach((x) => dal.Delete(x.Code));
        }
       
        public List<BLSchedule> MatchSchedule(string rId,string oId)
        {
            List<BLSchedule> sOff = GetById(oId);
            List<BLSchedule> sReq = GetById(rId);
            List<BLSchedule> match = new List<BLSchedule>();
            sReq.ForEach((r) =>
            {
                if (r.Available == true)
                    func(sOff, r, match);
            });
            return match;
        }

        public List<BLSchedule> MatchSchedule(int sch, string oId)
        {
            BLSchedule bls = GetByCode(sch);
            List<BLSchedule> sOff = GetById(oId);
            List<BLSchedule> match = new List<BLSchedule>();
            if(bls.Available == true)
                func(sOff,bls,match);
            return match;
        }
        
        private void func(List<BLSchedule> sOff,BLSchedule sReq, List<BLSchedule> match)
        {
            sOff.ForEach((o) =>
            {
                if (o.Available == true &&
                    sReq.DayInWeek == o.DayInWeek &&
                    (sReq.FromTime >= o.FromTime && sReq.ToTime <= o.ToTime) ||
                    (sReq.FromTime <= o.FromTime && sReq.ToTime >= o.FromTime) ||
                    (sReq.FromTime >= o.FromTime && sReq.FromTime <= o.ToTime))
                    match.Add(o);
            });
        }
        //לא בטוח שצריך את הפונקציה הזו , הורדנו את הלוח זמנים של המבקשים
        public void FixSchedule( int req,int off)
        {
            BLSchedule schOff = GetByCode(off);
            BLSchedule schReq = GetByCode(req);
            //אם הזמנים חופפים בדיוק
            //נסמן לשתיהם available = false
            if (schOff.FromTime == schReq.FromTime && schOff.ToTime == schReq.ToTime)
            {
                schOff.Available = false;
                schReq.Available = false;
            }
            //sReq.FromTime >= o.FromTime && sReq.ToTime <= o.ToTime
            //if (schOff.FromTime <= schReq.FromTime && s.FromTime <= to)
            //{
            //    if (to >= s.ToTime)
            //    {
            //        s.Available = false;
            //        Add(new BLSchedule() { DayInWeek = s.DayInWeek, FromTime = from, ToTime = s.FromTime, PersonId = offId });
            //        Add(new BLSchedule() { DayInWeek = s.DayInWeek, FromTime = s.ToTime, ToTime = to, PersonId = offId });
            //    }
            //}
            //if (s.FromTime <= from && s.FromTime >= to)
            //{
            //    if (to <= s.ToTime)
            //    {
            //        s.Available = false;
            //        Add(new BLSchedule() { DayInWeek = s.DayInWeek, FromTime = s.FromTime, ToTime = from, PersonId = offId });
            //        Add(new BLSchedule() { DayInWeek = s.DayInWeek, FromTime = to, ToTime = s.ToTime, PersonId = offId });
            //    }
            //    Add(new BLSchedule() { DayInWeek = s.DayInWeek, FromTime = s.FromTime, ToTime = from, PersonId = offId });
            //}
        }

        private Schedule ToSchedule(BLSchedule blschedule)
        {
            return new Schedule()
            {
//Code = blschedule.Code,
                DayInWeek = blschedule.DayInWeek,
                FromTime = blschedule.FromTime,
                ToTime = blschedule.ToTime,
                PersonId = blschedule.PersonId,
                Available = blschedule.Available
                //Person = blschedule.Person
            };
        }

        private BLSchedule ToBLSchedule(Schedule schedule)
        {
            return new BLSchedule()
            {
                Code = schedule.Code,
                DayInWeek = schedule.DayInWeek,
                FromTime = schedule.FromTime,
                ToTime = schedule.ToTime,
                PersonId = schedule.PersonId,
                Available= schedule.Available
                //Person= schedule.Person
            };
        }

        public void Delete(int code)
        {
            dal.Delete(code);
        }

        public void FixSchedule(int off)
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
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bl.Services
{
    public class BLScheduleService : IBLSchedule
    {
        IDalSchedule dal;
        IBLPerson person;

        public BLScheduleService(IDal dal, IBLPerson person)
        {
            this.dal = dal.Schedule;
            this.person = person;
        }

        public async Task<List<BLSchedule>> Get()
        {
            try
            {
                List<Schedule> s = await dal.Get();
                List<BLSchedule> bls = new();
                foreach (var schedule in s)
                {
                    bls.Add(ToBLSchedule(schedule));
                }
                return bls;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get schedules: {ex.Message}", ex);
            }
        }

        public async Task<List<BLSchedule>> GetByDay(string day)
        {
            try
            {
                List<Schedule> s = await dal.Get();
                List<BLSchedule> bls = new();
                foreach (var schedule in s)
                {
                    if (schedule.DayInWeek == day)
                    {
                        bls.Add(ToBLSchedule(schedule));
                    }
                }
                return bls;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get schedules by day: {ex.Message}", ex);
            }
        }

        public async Task<List<BLSchedule>> GetById(string id)
        {
            try
            {
                List<Schedule> s = await dal.Get();
                List<BLSchedule> bls = new();
                foreach (var schedule in s)
                {
                    if (schedule.PersonId == id)
                    {
                        bls.Add(ToBLSchedule(schedule));
                    }
                }
                return bls;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get schedules by ID: {ex.Message}", ex);
            }
        }

        public async Task<BLSchedule> GetByCode(int code)
        {
            try
            {
                Schedule schedule = await dal.GetByCode(code);
                if (schedule != null)
                {
                    return ToBLSchedule(schedule);
                }
                throw new Exception($"Schedule with code {code} not found");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get schedule by code: {ex.Message}", ex);
            }
        }

        public async Task<bool> Update(BLSchedule schedule, int code)
        {
            try
            {
                await dal.Update(ToSchedule(schedule), code);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update schedule: {ex.Message}", ex);
            }
        }

        public async Task<int> Add(BLSchedule schedule)
        {
            try
            {
                return await dal.Add(ToSchedule(schedule));
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add schedule: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteById(string id)
        {
            try
            {
                List<BLSchedule> schedules = await GetById(id);
                bool allDeleted = true;

                foreach (var schedule in schedules)
                {
                    bool deleted = await dal.Delete(schedule.Code);
                    if (!deleted)
                    {
                        allDeleted = false;
                    }
                }

                return allDeleted;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete schedules by ID: {ex.Message}", ex);
            }
        }

        public async Task<List<BLSchedule>> MatchSchedule(string rId, string oId)
        {
            try
            {
                List<BLSchedule> sOff = await GetById(oId);
                List<BLSchedule> sReq = await GetById(rId);
                List<BLSchedule> match = new List<BLSchedule>();

                foreach (var r in sReq)
                {
                    if (r.Available == true)
                    {
                        await FuncAsync(sOff, r, match);
                    }
                }

                return match;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to match schedules: {ex.Message}", ex);
            }
        }

        public async Task<List<BLSchedule>> MatchSchedule(int sch, string oId)
        {
            try
            {
                BLSchedule bls = await GetByCode(sch);
                List<BLSchedule> sOff = await GetById(oId);
                List<BLSchedule> match = new List<BLSchedule>();

                if (bls.Available == true)
                {
                    await FuncAsync(sOff, bls, match);
                }

                return match;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to match schedules: {ex.Message}", ex);
            }
        }

        private async Task FuncAsync(List<BLSchedule> sOff, BLSchedule sReq, List<BLSchedule> match)
        {
            foreach (var o in sOff)
            {
                if (o.Available == true &&
                    sReq.DayInWeek == o.DayInWeek &&
                    ((sReq.FromTime >= o.FromTime && sReq.ToTime <= o.ToTime) ||
                     (sReq.FromTime <= o.FromTime && sReq.ToTime >= o.FromTime) ||
                     (sReq.FromTime >= o.FromTime && sReq.FromTime <= o.ToTime)))
                {
                    match.Add(o);
                }
            }

            await Task.CompletedTask; // כדי להפוך את הפונקציה לאסינכרונית
        }

        public async Task<bool> FixSchedule(int req, int off)
        {
            try
            {
                BLSchedule schOff = await GetByCode(off);
                BLSchedule schReq = await GetByCode(req);

                // אם הזמנים חופפים בדיוק
                // נסמן לשתיהם available = false
                if (schOff.FromTime == schReq.FromTime && schOff.ToTime == schReq.ToTime)
                {
                    schOff.Available = false;
                    schReq.Available = false;

                    await Update(schOff, off);
                    await Update(schReq, req);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fix schedule: {ex.Message}", ex);
            }
        }

        public async Task<bool> Delete(int code)
        {
            try
            {
                return await dal.Delete(code);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete schedule: {ex.Message}", ex);
            }
        }

        public async Task<bool> FixSchedule(int schCode)
        {
            try
            {
                BLSchedule schedule = await GetByCode(schCode);
                schedule.Available = false;
                await Update(schedule, schCode);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fix schedule: {ex.Message}", ex);
            }
        }
                
        private static Schedule ToSchedule(BLSchedule blschedule)
        {
            return new Schedule()
            {
                // Code = blschedule.Code, // הערה: נראה שהקוד מקורי לא כלל את זה
                DayInWeek = blschedule.DayInWeek,
                FromTime = blschedule.FromTime,
                ToTime = blschedule.ToTime,
                PersonId = blschedule.PersonId,
                Available = blschedule.Available
            };
        }

        private BLSchedule ToBLSchedule(Schedule schedule)
        {
            return new BLSchedule()
            {
                Code = schedule.Code,
                DayInWeek = schedule.DayInWeek,
                FromTime = schedule.FromTime,
                ToTime = schedule.ToTime,
                PersonId = schedule.PersonId,
                Available = schedule.Available
            };
        }
    }
}