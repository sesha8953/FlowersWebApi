using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowersWebApi.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Bdate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}