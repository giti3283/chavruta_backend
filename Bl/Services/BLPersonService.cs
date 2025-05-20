/*//בס"ד
using Azure.Core;
using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bl.Services
{
    public class BLPersonService : IBLPerson
    {
        IDalPerson dal;
        public BLPersonService(IDal dal)
        {
            this.dal = dal.Person;
        }

        *//*public void Add(BLPerson person)
        {
            if(dal.GetById(person.Id) != null)
                throw new Exception("ת.ז קיימת במערכת.");
            else
                dal.Add(ToPerson(person));
        }*//*
        public async Task<bool> Add(BLPerson person)
        {
            if (dal.GetById(person.Id) != null)
                throw new Exception("ת.ז קיימת במערכת.");
            else
                try
                {
                    // הוספת await לפני קריאה לפונקציה אסינכרונית
                    return await dal.Add(ToPerson(person));
                }
                catch (Exception ex)
                {
                    throw new Exception($"Can't add person (BL): {ex.Message}", ex);
                }
        }


        public void Delete(string id)
        {
            dal.Delete(id);      
        }

        public List<BLPerson> Get()
        {
            List<Person> p = dal.Get();
            List<BLPerson> blp = new();
            p.ForEach(x => blp.Add(ToBLPerson(x)));
            return blp;
        }

        *//*public BLPerson GetById(string id)
        {
            Person p = dal.GetById(id);
            if (p != null)
                return ToBLPerson(dal.GetById(id));
            else
                throw new Exception("person is not exist");
           
        }*//*

        public async Task<BLPerson> GetById(string id)
        {
            Person p = await dal.GetById(id);
            if (p != null)
                return ToBLPerson(p); // שים לב שהסרתי את הקריאה הכפולה ל-GetById
            else
                throw new Exception("person is not exist");
        }

        public void Update(BLPerson person, string id)
        {
            int ind = dal.Get().FindIndex(el => el.Id == id);
            if (ind != -1)
                dal.Update(ToPerson(person), id);
            else
                throw new Exception("ת.ז אינה קיימת במערכת.");
        }

        public async List<BLOffer> GetOffers(string id)
        {
            List<BLOffer> t = new ();
            Person p = await dal.GetById(id);
            if (p != null && p.Offers!=null)
            {
                foreach (var item in p.Offers)
                {
                    t.Add(new BLOffer()
                    {
                        Code = item.Code,
                        PersonId = item.PersonId,
                        Book = item.Book,
                        Subject = item.Subject,
                        Mode = item.Mode
                    });
                }
            }
            return t;
        }

        public async List<BLRequest> GetRequests(string id)
        {
            List<BLRequest> t = new List<BLRequest>();
            Person p =await dal.GetById(id);
            if (p != null && p.Requests != null)
            {
                foreach (var item in p.Requests)
                {
                    t.Add(new BLRequest()
                    {
                        Code = item.Code,
                        PersonId = item.PersonId,
                        Book = item.Book,
                        Subject = item.Subject,
                        Mode = item.Mode,
                        ChavrutaCode = item.ChavrutaCode
                    });
                }
            }
            return t;
        }

        private Person ToPerson(BLPerson blPerson)
        {
            return new Person()
            {
                Id = blPerson.Id,
                FirstName = blPerson.FirstName,
                LastName = blPerson.LastName,
                BirthDate = blPerson.BirthDate,
                Gender = blPerson.Gender,
                Status = blPerson.Status,
                CellularTelephone = blPerson.CellularTelephone,
                Telephone = blPerson.Telephone,
                City = blPerson.City,
                Country = blPerson.Country,
                Email = blPerson.Email,
                Role = blPerson.Role,
                Denomination = blPerson.Denomination
                //Requests = blPerson.Requests,
                //Offers = blPerson.Offers,
                //Schedules = blPerson.Schedules
            };
        }
        
        private BLPerson ToBLPerson(Person person)
        {
            return new BLPerson()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                BirthDate = person.BirthDate,
                Gender = person.Gender,
                Status = person.Status,
                CellularTelephone = person.CellularTelephone,
                Telephone = person.Telephone,
                City = person.City,
                Country = person.Country,
                Email = person.Email,
                Role = person.Role,
                Denomination = person.Denomination
                //Requests = person.Requests,
                //Offers = person.Offers,
                //Schedules = person.Schedules
            };
        }
    }
}
*/
//בס"ד
using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bl.Services
{
    public class BLPersonService : IBLPerson
    {
        IDalPerson dal;

        public BLPersonService(IDal dal)
        {
            this.dal = dal.Person;
        }

        public async Task<bool> Add(BLPerson person)
        {
            var existingPerson = await dal.GetById(person.Id);
            if (existingPerson != null)
                throw new Exception("ת.ז קיימת במערכת.");
            else
                try
                {
                    return await dal.Add(ToPerson(person));
                }
                catch (Exception ex)
                {
                    throw new Exception($"Can't add person (BL): {ex.Message}", ex);
                }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                return await dal.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete person: {ex.Message}", ex);
            }
        }

        public async Task<List<BLPerson>> Get()
        {
            try
            {
                List<Person> p = await dal.Get();
                List<BLPerson> blp = new();
                p.ForEach(x => blp.Add(ToBLPerson(x)));
                return blp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get people: {ex.Message}", ex);
            }
        }

        public async Task<BLPerson> GetById(string id)
        {
            try
            {
                Person p = await dal.GetById(id);
                if (p != null)
                    return ToBLPerson(p);
                else
                    throw new Exception("person is not exist");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get person by ID: {ex.Message}", ex);
            }
        }

        public async Task<bool> Update(BLPerson person, string id)
        {
            try
            {
                var people = await dal.Get();
                int ind = people.FindIndex(el => el.Id == id);
                if (ind != -1)
                    return await dal.Update(ToPerson(person), id);
                else
                    throw new Exception("ת.ז אינה קיימת במערכת.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update person: {ex.Message}", ex);
            }
        }

        public async Task<List<BLOffer>> GetOffers(string id)
        {
            try
            {
                List<BLOffer> t = new();
                Person p = await dal.GetById(id);
                if (p != null && p.Offers != null)
                {
                    foreach (var item in p.Offers)
                    {
                        t.Add(new BLOffer()
                        {
                            Code = item.Code,
                            PersonId = item.PersonId,
                            Book = item.Book,
                            Subject = item.Subject,
                            Mode = item.Mode
                        });
                    }
                }
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get offers: {ex.Message}", ex);
            }
        }

        public async Task<List<BLRequest>> GetRequests(string id)
        {
            try
            {
                List<BLRequest> t = new List<BLRequest>();
                Person p = await dal.GetById(id);
                if (p != null && p.Requests != null)
                {
                    foreach (var item in p.Requests)
                    {
                        t.Add(new BLRequest()
                        {
                            Code = item.Code,
                            PersonId = item.PersonId,
                            Book = item.Book,
                            Subject = item.Subject,
                            Mode = item.Mode,
                            ChavrutaCode = item.ChavrutaCode
                        });
                    }
                }
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get requests: {ex.Message}", ex);
            }
        }

        private Person ToPerson(BLPerson blPerson)
        {
            return new Person()
            {
                Id = blPerson.Id,
                FirstName = blPerson.FirstName,
                LastName = blPerson.LastName,
                BirthDate = blPerson.BirthDate,
                Gender = blPerson.Gender,
                Status = blPerson.Status,
                CellularTelephone = blPerson.CellularTelephone,
                Telephone = blPerson.Telephone,
                City = blPerson.City,
                Country = blPerson.Country,
                Email = blPerson.Email,
                Role = blPerson.Role,
                Denomination = blPerson.Denomination
                //Requests = blPerson.Requests,
                //Offers = blPerson.Offers,
                //Schedules = blPerson.Schedules
            };
        }

        private BLPerson ToBLPerson(Person person)
        {
            return new BLPerson()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                BirthDate = person.BirthDate,
                Gender = person.Gender,
                Status = person.Status,
                CellularTelephone = person.CellularTelephone,
                Telephone = person.Telephone,
                City = person.City,
                Country = person.Country,
                Email = person.Email,
                Role = person.Role,
                Denomination = person.Denomination
                //Requests = person.Requests,
                //Offers = person.Offers,
                //Schedules = person.Schedules
            };
        }
    }
}