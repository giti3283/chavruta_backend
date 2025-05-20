//בס"ד
using Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    /*public interface IBLSchedule
    {
        List<BLSchedule> Get();
        List<BLSchedule> GetById(string id);
        BLSchedule GetByCode(int code);
        List<BLSchedule> GetByDay(string day);
        void DeleteById(string id);
        public void Delete(int code);
        void Add(BLSchedule schedule);
        void Update(BLSchedule person, int code);
        List<BLSchedule> MatchSchedule(string rId, string oId);
        List<BLSchedule> MatchSchedule(int sch, string oId);
        void FixSchedule(int off);
       // void FixSchedule(int req, int off);

    }*/
    public interface IBLSchedule
    {
        Task<List<BLSchedule>> Get();
        Task<List<BLSchedule>> GetByDay(string day);
        Task<List<BLSchedule>> GetById(string id);
        Task<BLSchedule> GetByCode(int code);
        Task<bool> Update(BLSchedule schedule, int code);
        Task<int> Add(BLSchedule schedule);
        Task<bool> DeleteById(string id);
        Task<List<BLSchedule>> MatchSchedule(string rId, string oId);
        Task<List<BLSchedule>> MatchSchedule(int sch, string oId);
        Task<bool> FixSchedule(int req, int off);
        Task<bool> Delete(int code);
        Task<bool> FixSchedule(int off);
    }
}
