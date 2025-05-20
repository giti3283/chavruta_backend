/*//בס"ד
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDalPerson
    {
        List<Person> Get();
        Task<Person> GetById(string id)
        void Delete(string id);
        void Update(Person person,string id);
        Task<bool> Add(Person person);
        
        
    }
}
*/
using Dal.Models;

public interface IDalPerson
{
    Task<bool> Add(Person person);
    Task<bool> Delete(string id);
    Task<List<Person>> Get();
    Task<Person> GetById(string id);
    Task<bool> Update(Person person, string id);
}