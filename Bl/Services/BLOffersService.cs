/*//בס"ד
using Azure.Core;
using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
{
    public class BLOffersService : IBLOffers
    {
        IDalOffer dal;
        IBLPerson person;

        public BLOffersService(IDal dal,IBLPerson person)
        {
            this.dal = dal.Offer;
            this.person = person;

        }

        public List<BLOffer> Get()
        {
            List<Offer> o = dal.Get();
            List<BLOffer> blo = new();
            o.ForEach(x => blo.Add(ToBLOffer(x)));
            return blo;
        }

        public List<BLOffer> GetByBook(string book)
        {
            List<Offer> o = dal.Get();
            List<BLOffer> blo = new();
            o.ForEach(x => {
                if(x.Book == book) { blo.Add(ToBLOffer(x)); }
                });
            return blo;
        }


        public List<BLOffer> GetBySubject(string subject)
        {
            List<Offer> o = dal.Get();
            List<BLOffer> blo = new();
            o.ForEach(x => {
                if (x.Subject == subject) { blo.Add(ToBLOffer(x)); }
            });
            return blo;
        }

        public BLOffer GetByCode(int code)
        {
            List<Offer> o = dal.Get();
            BLOffer blo = new();
            o.ForEach(x => {
                if (x.Code == code) { blo = ToBLOffer(x); }
            });
            return blo;
        }

        public void Update(BLOffer offer, int code)
        {
            dal.Update(ToOffer(offer), code);
        }
        public async void Add(BLOffer offer)
        {
            BLPerson p =await person.GetById(offer.PersonId); 
            if (p != null && p.Role == "offer")
            {
                dal.Add(ToOffer(offer));
            }
            else
                throw new Exception("ת.ז לא קיימת במערכת.");  
        }

        public void Delete(int code)
        {
            dal.Delete(code);
        }

        public Offer ToOffer(BLOffer bloffer) {
            return new Offer()
            {
                Code = bloffer.Code,
                PersonId = bloffer.PersonId,
                Book = bloffer.Book,
                Subject = bloffer.Subject,
                Mode = bloffer.Mode//,
                //Requests = bloffer.Requests,
                //Person = bloffer.Person
            };
        }

        public BLOffer ToBLOffer(Offer offer)
        {
            return new BLOffer()
            {
                Code = offer.Code,
                PersonId = offer.PersonId,
                Book = offer.Book,
                Subject = offer.Subject,
                Mode = offer.Mode//,
                //Requests = offer.Requests,
                //Person = offer.Person
            };
        }

    }
}
*/
//בס"ד
using Azure.Core;
using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
{
    public class BLOffersService : IBLOffers
    {
        IDalOffer dal;
        IBLPerson person;

        public BLOffersService(IDal dal, IBLPerson person)
        {
            this.dal = dal.Offer;
            this.person = person;
        }

        public async Task<List<BLOffer>> Get()
        {
            try
            {
                List<Offer> o = await dal.Get();
                List<BLOffer> blo = new();
                foreach (var offer in o)
                {
                    blo.Add(ToBLOffer(offer));
                }
                return blo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get offers: {ex.Message}", ex);
            }
        }

        public async Task<List<BLOffer>> GetByBook(string book)
        {
            try
            {
                List<Offer> o = await dal.Get();
                List<BLOffer> blo = new();
                foreach (var offer in o)
                {
                    if (offer.Book == book)
                    {
                        blo.Add(ToBLOffer(offer));
                    }
                }
                return blo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get offers by book: {ex.Message}", ex);
            }
        }

        public async Task<List<BLOffer>> GetBySubject(string subject)
        {
            try
            {
                List<Offer> o = await dal.Get();
                List<BLOffer> blo = new();
                foreach (var offer in o)
                {
                    if (offer.Subject == subject)
                    {
                        blo.Add(ToBLOffer(offer));
                    }
                }
                return blo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get offers by subject: {ex.Message}", ex);
            }
        }

        public async Task<BLOffer> GetByCode(int code)
        {
            try
            {
                Offer offer = await dal.GetByCode(code);
                if (offer != null)
                {
                    return ToBLOffer(offer);
                }
                throw new Exception($"Offer with code {code} not found");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get offer by code: {ex.Message}", ex);
            }
        }

        public async Task<bool> Update(BLOffer offer, int code)
        {
            try
            {
                await dal.Update(ToOffer(offer), code);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update offer: {ex.Message}", ex);
            }
        }

        public async Task<bool> Add(BLOffer offer)
        {
            try
            {
                BLPerson p = await person.GetById(offer.PersonId);
                if (p != null && p.Role == "offer")
                {
                    await dal.Add(ToOffer(offer));
                    return true;
                }
                else
                {
                    throw new Exception("ת.ז לא קיימת במערכת.");
                }
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
                await dal.Delete(code);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete offer: {ex.Message}", ex);
            }
        }

        public Offer ToOffer(BLOffer bloffer)
        {
            return new Offer()
            {
                Code = bloffer.Code,
                PersonId = bloffer.PersonId,
                Book = bloffer.Book,
                Subject = bloffer.Subject,
                Mode = bloffer.Mode
            };
        }

        public BLOffer ToBLOffer(Offer offer)
        {
            return new BLOffer()
            {
                Code = offer.Code,
                PersonId = offer.PersonId,
                Book = offer.Book,
                Subject = offer.Subject,
                Mode = offer.Mode
            };
        }
    }
}