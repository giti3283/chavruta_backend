//בס"ד
using Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    /*public interface IBLRequests
    {
        List<BLRequest> Get();
        BLRequest GetByCode(int code);
        List<BLRequest> GetByBook(string book);
        List<BLRequest> GetBySubject(string subject);
        void Delete(int code);
        void Add(BLRequest request);
        void Update(BLRequest request, int code);
        //Dictionary<BLOffer, List<BLSchedule>> FindChavruta(int code);
        List<ChavrutaMatch> FindChavruta(int code);
        void SelectChavruta(string id, int reqCode, int chaCode, int reqScheduleCode, int chaScheduleCode);
    }*/
    public interface IBLRequests
    {
        Task<List<BLRequest>> Get();
        Task<BLRequest> GetByCode(int code);
        Task<List<BLRequest>> GetByBook(string book);
        Task<List<BLRequest>> GetBySubject(string subject);
        Task<bool> Add(BLRequest request);
        Task<bool> Update(BLRequest request, int code);
        Task<bool> Delete(int code);
        Task<List<ChavrutaMatch>> FindChavruta(int code);
        /*Task<bool> SelectChavruta(string id, int reqCode, int chaCode, int chaScheduleCode);*/
        Task<bool> SelectChavruta( int reqCode, int chaCode, int chaScheduleCode);
    }
}
