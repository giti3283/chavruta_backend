//בס"ד
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    /*public interface IDalSchedule
    {
        List<Schedule> Get();
        Schedule GetByCode(int code);
        void Delete(int code);
        void Add(Schedule schedule);
        void Update(Schedule person, int code);
    }*/
    public interface IDalSchedule
    {
        Task<int> Add(Schedule schedule);
        Task<bool> Delete(int code);
        Task<List<Schedule>> Get();
        Task<Schedule> GetByCode(int code);
        Task<bool> Update(Schedule schedule, int code);
    }
}
