/*//בס"ד
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
    public class DalPersonService : IDalPerson
    {
        dbcontext data;

        public DalPersonService(dbcontext data)
        {
            this.data = data;
        }

        *//*public void Add(Person person)
        {
            data.People.Add(person);
            data.SaveChanges();
        }*//*
        
        public async Task<bool> Add(Person person)
        {
            try
            {
                data.People.Add(person);
                try
                {
                    // הוספת await לפני SaveChangesAsync
                    await data.SaveChangesAsync();
                }
                catch (Exception innerEx)
                {
                    data.People.Local.Remove(person);
                    throw new Exception($"Failed to save changes: {innerEx.Message}", innerEx);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Can't add person: {ex.Message}", ex);
            }
        }

        public void Delete(string id)
        {
            data.People.Remove(data.People.ToList().Find(x => x.Id == id));
            data.SaveChanges();
        }

        public List<Person> Get()
        {
            return data.People.Include(x => x.Offers).Include(x => x.Requests).Include(x => x.Schedules).ToList();
        }

        *//*public Person GetById(string id)
        {
            return data.People.Include(x => x.Offers).Include(x => x.Requests).Include(x => x.Schedules).ToList().Find(x => x.Id == id);
        }*//*
        public async Task<Person> GetById(string id)
        {
            return await data.People
                .Include(x => x.Offers)
                .Include(x => x.Requests)
                .Include(x => x.Schedules)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Person person, string id)
        {
            Person p = data.People.Find(id);
            if (p != null)
            {
                p.FirstName = person.FirstName;
                p.LastName = person.LastName;
                p.BirthDate = person.BirthDate;
                p.Gender = person.Gender;
                p.Status = person.Status;
                p.CellularTelephone = person.CellularTelephone;
                p.Telephone = person.Telephone;
                p.Country = person.Country;
                p.City = person.City;
                p.Email = person.Email;
                p.Denomination = person.Denomination;
                p.Role = person.Role;
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
    public class DalPersonService : IDalPerson
    {
        dbcontext data;

        public DalPersonService(dbcontext data)
        {
            this.data = data;
        }

        public async Task<bool> Add(Person person)
        {
            try
            {
                data.People.Add(person);
                try
                {
                    await data.SaveChangesAsync();
                }
                catch (Exception innerEx)
                {
                    data.People.Local.Remove(person);
                    throw new Exception($"Failed to save changes: {innerEx.Message}", innerEx);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Can't add person: {ex.Message}", ex);
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var person = await data.People.FirstOrDefaultAsync(x => x.Id == id);
                if (person != null)
                {
                    data.People.Remove(person);
                    await data.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete person: {ex.Message}", ex);
            }
        }

        public async Task<List<Person>> Get()
        {
            try
            {
                return await data.People
                    .Include(x => x.Offers)
                    .Include(x => x.Requests)
                    .Include(x => x.Schedules)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get people: {ex.Message}", ex);
            }
        }

        public async Task<Person> GetById(string id)
        {
            try
            {
                return await data.People
                    .Include(x => x.Offers)
                    .Include(x => x.Requests)
                    .Include(x => x.Schedules)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get person by ID: {ex.Message}", ex);
            }
        }

        public async Task<bool> Update(Person person, string id)
        {
            try
            {
                Person p = await data.People.FindAsync(id);
                if (p != null)
                {
                    p.FirstName = person.FirstName;
                    p.LastName = person.LastName;
                    p.BirthDate = person.BirthDate;
                    p.Gender = person.Gender;
                    p.Status = person.Status;
                    p.CellularTelephone = person.CellularTelephone;
                    p.Telephone = person.Telephone;
                    p.Country = person.Country;
                    p.City = person.City;
                    p.Email = person.Email;
                    p.Denomination = person.Denomination;
                    p.Role = person.Role;

                    await data.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update person: {ex.Message}", ex);
            }
        }
    }
}