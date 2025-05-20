//בס"ד
using Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    /*public interface IBLOffers
    {
        List<BLOffer> Get();
        BLOffer GetByCode(int code);
        List<BLOffer> GetByBook(string book);
        List<BLOffer> GetBySubject(string subject);
        public void Delete(int code);
        void Add(BLOffer offer);
        void Update(BLOffer offer, int code);
    }*/
    public interface IBLOffers
    {
        Task<List<BLOffer>> Get();
        Task<List<BLOffer>> GetByBook(string book);
        Task<List<BLOffer>> GetBySubject(string subject);
        Task<BLOffer> GetByCode(int code);
        Task<bool> Update(BLOffer offer, int code);
        Task<bool> Add(BLOffer offer);
        Task<bool> Delete(int code);
    }
}