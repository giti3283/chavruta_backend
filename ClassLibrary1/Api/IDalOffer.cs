//בס"ד
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    /*public interface IDalOffer
    {
        List<Offer> Get();
        Offer GetByCode(int code);
        void Delete(int code);
        void Add(Offer offer);

        void Update(Offer offer, int code);
    }*/
    public interface IDalOffer
    {
        Task<int> Add(Offer offer);
        Task<bool> Delete(int code);
        Task<List<Offer>> Get();
        Task<Offer> GetByCode(int code);
        Task<bool> Update(Offer offer, int code);
    }
}
