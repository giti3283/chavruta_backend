/*//בס"ד
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalScheduleService : IDalSchedule
    {
        dbcontext data;

        public DalScheduleService(dbcontext data)
        {
            this.data = data;
        }

        public void Add(Schedule schedule)
        {
            data.Schedules.Add(schedule);
            data.SaveChanges();
        }

        public void Delete(int code)
        {
            data.Schedules.Remove(data.Schedules.ToList().Find(x => x.Code == code));
            data.SaveChanges();
        }

        public List<Schedule> Get()
        {
            return data.Schedules.ToList();
        }

        public Schedule GetByCode(int code)
        {
            return data.Schedules.ToList().Find(x => x.Code == code);
        }

        public void Update(Schedule schedule, int code)
        {
            Schedule s = data.Schedules.Find(code);
            if (s != null)
            {
                s.DayInWeek = schedule.DayInWeek;
                s.FromTime = schedule.FromTime;
                s.ToTime = schedule.ToTime;
                s.PersonId = schedule.PersonId;
            }
            data.SaveChanges();
        }
    }
}
*/
//בס"ד
using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalScheduleService : IDalSchedule
    {
        dbcontext data;

        public DalScheduleService(dbcontext data)
        {
            this.data = data;
        }

        public async Task<int> Add(Schedule schedule)
        {
            try
            {
                var result = await data.Schedules.AddAsync(schedule);
                await data.SaveChangesAsync();
                return result.Entity.Code;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add schedule: {ex.Message}", ex);
            }
        }

        public async Task<bool> Delete(int code)
        {
            try
            {
                var schedule = await data.Schedules.FirstOrDefaultAsync(x => x.Code == code);
                if (schedule != null)
                {
                    data.Schedules.Remove(schedule);
                    await data.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete schedule: {ex.Message}", ex);
            }
        }

        public async Task<List<Schedule>> Get()
        {
            try
            {
                return await data.Schedules.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get schedules: {ex.Message}", ex);
            }
        }

        public async Task<Schedule> GetByCode(int code)
        {
            try
            {
                return await data.Schedules.FirstOrDefaultAsync(x => x.Code == code);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get schedule by code: {ex.Message}", ex);
            }
        }

        public async Task<bool> Update(Schedule schedule, int code)
        {
            try
            {
                Schedule s = await data.Schedules.FindAsync(code);
                if (s != null)
                {
                    s.DayInWeek = schedule.DayInWeek;
                    s.FromTime = schedule.FromTime;
                    s.ToTime = schedule.ToTime;
                    s.PersonId = schedule.PersonId;
                    s.Available = schedule.Available;
                    await data.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update schedule: {ex.Message}", ex);
            }
        }
    }
}
