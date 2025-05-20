/*//בס"ד
using Bl.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBLPerson
    {
        List<BLPerson> Get();
        Task<BLPerson> GetById(string id);
        List<BLRequest> GetRequests(string id);
        List<BLOffer> GetOffers(string id);
        void Delete(string id);
        void Update(BLPerson person, string id);
        Task<bool> Add(BLPerson person);
        //void DeleteDay(string id, string day);

    }
}
*/
using Bl.Models;

public interface IBLPerson
{
    Task<bool> Add(BLPerson person);
    Task<bool> Delete(string id);
    Task<List<BLPerson>> Get();
    Task<BLPerson> GetById(string id);
    Task<bool> Update(BLPerson person, string id);
    Task<List<BLOffer>> GetOffers(string id);
    Task<List<BLRequest>> GetRequests(string id);
}