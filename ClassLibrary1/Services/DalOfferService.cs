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
    public class DalOfferService : IDalOffer
    {
        dbcontext data;

        public DalOfferService(dbcontext data)
        {
            this.data = data;
        }

        public void Add(Offer offer)
        {
            //var offerr = data.Offers.Add(offer).Entity;
            data.Offers.Add(offer);
            data.SaveChanges();
            //return offerr.Code;
        }

        public void Delete(int code)
        {
            data.Offers.Remove(data.Offers.ToList().Find(x => x.Code == code));
            data.SaveChanges();
        }

        public List<Offer> Get()
        {
            return data.Offers.ToList();
        }

        public Offer GetByCode(int code)
        {
            return data.Offers.ToList().Find(x => x.Code == code);
        }

        public void Update(Offer offer, int code)
        {
            Offer o = data.Offers.Find(code);
            if (o != null)
            {
                o.PersonId = offer.PersonId;
                o.Book = offer.Book;
                o.Subject = offer.Subject;
                o.Mode = offer.Mode;
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
    public class DalOfferService : IDalOffer
    {
        dbcontext data;

        public DalOfferService(dbcontext data)
        {
            this.data = data;
        }

        public async Task<int> Add(Offer offer)
        {
            try
            {
                var result = await data.Offers.AddAsync(offer);
                await data.SaveChangesAsync();
                return result.Entity.Code;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add offer: {ex.Message}", ex);
            }
        }

        public async Task<bool> Delete(int code)
        {
            try
            {
                var offer = await data.Offers.FirstOrDefaultAsync(x => x.Code == code);
                if (offer != null)
                {
                    data.Offers.Remove(offer);
                    await data.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete offer: {ex.Message}", ex);
            }
        }

        public async Task<List<Offer>> Get()
        {
            try
            {
                return await data.Offers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get offers: {ex.Message}", ex);
            }
        }

        public async Task<Offer> GetByCode(int code)
        {
            try
            {
                return await data.Offers.FirstOrDefaultAsync(x => x.Code == code);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get offer by code: {ex.Message}", ex);
            }
        }

        public async Task<bool> Update(Offer offer, int code)
        {
            try
            {
                Offer o = await data.Offers.FindAsync(code);
                if (o != null)
                {
                    o.PersonId = offer.PersonId;
                    o.Book = offer.Book;
                    o.Subject = offer.Subject;
                    o.Mode = offer.Mode;
                    await data.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update offer: {ex.Message}", ex);
            }
        }
    }
}