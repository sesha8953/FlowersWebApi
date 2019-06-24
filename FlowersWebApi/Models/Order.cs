using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowersWebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public DateTime Date { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual ICollection<OrderFlowers> OrderFlowers { get; set; }
    }
}