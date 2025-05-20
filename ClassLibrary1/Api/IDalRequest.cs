//בס"ד
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    /*public interface IDalRequest
    {
        List<Request> Get();
        Request GetByCode(int code);
        void Delete(int code);
        int Add(Request request); 
        void Update(Request request, int code);
    }*/
    public interface IDalRequest
    {
        Task<int> Add(Request request);
        Task<bool> Delete(int code);
        Task<List<Request>> Get();
        Task<Request> GetByCode(int code);
        Task<bool> Update(Request request, int code);
    }
}
