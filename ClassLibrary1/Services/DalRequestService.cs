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
    public class DalRequestService : IDalRequest
    {
        dbcontext data;

        public DalRequestService(dbcontext data)
        {
            this.data = data;
        }

        public int Add(Request request)
        {
            request.ChavrutaCode = null;//*****
            var x=  data.Requests.Add(request);
            data.SaveChanges();
            return x.Entity.Code;
        }

        public void Delete(int code)
        {
            data.Requests.Remove(data.Requests.ToList().Find(x => x.Code == code));
            data.SaveChanges();
        }

        public List<Request> Get()
        {
            return data.Requests.ToList();
        }

        public Request GetByCode(int code)
        {
            return data.Requests.ToList().Find(x => x.Code == code);
        }

        public void Update(Request request, int code)
        {
            Request r = data.Requests.Find(code);
            if (r != null)
            {
                r.PersonId = request.PersonId;
                r.Book = request.Book;
                r.Subject = request.Subject;
                r.Mode = request.Mode;
                r.ChavrutaCode = request.ChavrutaCode;
                data.SaveChanges();
            }
            
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
    public class DalRequestService : IDalRequest
    {
        dbcontext data;
        
        public DalRequestService(dbcontext data)
        {
            this.data = data;
        }

        public async Task<int> Add(Request request)
        {
            try
            {
                request.ChavrutaCode = null;//*****
                var x = await data.Requests.AddAsync(request);
                await data.SaveChangesAsync();
                return x.Entity.Code;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add request: {ex.Message}", ex);
            }
        }

        public async Task<bool> Delete(int code)
        {
            try
            {
                var request = await data.Requests.FirstOrDefaultAsync(x => x.Code == code);
                if (request != null)
                {
                    data.Requests.Remove(request);
                    await data.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete request: {ex.Message}", ex);
            }
        }

        public async Task<List<Request>> Get()
        {
            try
            {
                return await data.Requests.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get requests: {ex.Message}", ex);
            }
        }

        public async Task<Request> GetByCode(int code)
        {
            try
            {
                return await data.Requests.FirstOrDefaultAsync(x => x.Code == code);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get request by code: {ex.Message}", ex);
            }
        }

        public async Task<bool> Update(Request request, int code)
        {
            try
            {
                Request r = await data.Requests.FindAsync(code);
                if (r != null)
                {
                    r.PersonId = request.PersonId;
                    r.Book = request.Book;
                    r.Subject = request.Subject;
                    r.Mode = request.Mode;
                    r.ChavrutaCode = request.ChavrutaCode;
                    await data.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update request: {ex.Message}", ex);
            }
        }
    }
}