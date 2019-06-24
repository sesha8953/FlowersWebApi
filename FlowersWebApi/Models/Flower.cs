using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowersWebApi.Models
{
    public class Flower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsAvailable { get; set; }
        public virtual ICollection<OrderFlowers> OrderFlowers { get; set; }
    }
}