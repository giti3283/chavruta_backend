//בס"ד
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public class BLPerson
    {

        private string id;
        private string cellularTelephone;
        private string email;

        public string Id 
        { 
            get => id;
            set
            {
                if (value?.Length != 9)
                    throw new ArgumentException("ת.ז חייבת להכיל 9 ספרות");
                id = value;
            }
        }

        public string CellularTelephone
        {
            get => cellularTelephone;
            set
            {
                if (value?.Length != 10)
                    throw new ArgumentException("מספר טלפון חייב להכיל 10 ספרות");
                cellularTelephone = value;
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (string.IsNullOrEmpty(value) || !value.Contains("@") || !value.EndsWith("gmail.com"))
                    throw new ArgumentException("כתובת אימייל לא תקינה");
                email = value;
            }
        }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string? Telephone { get; set; }

        public string? Country { get; set; } = null!;

        public string? City { get; set; }
        
        public string Role { get; set; }

        public string? Denomination { get; set; } = null!;
        //public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

        //public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

        //public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
