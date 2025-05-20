//בס"ד
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public class BLOffer
    {
        public int Code { get; set; }

        private string personId;
        
        public string PersonId
        {
            get => personId;
            set
            {
                if (value?.Length != 9)
                    throw new ArgumentException("ת.ז חייבת להכיל 9 ספרות");
                personId = value;
            }
        }
        public string? Book { get; set; }

        public string Subject { get; set; } = null!;

        public string? Mode { get; set; }

        //public virtual Person Person { get; set; } = null!;

        //public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
    }
}
