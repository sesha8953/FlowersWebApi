using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowersWebApi.Models.Entities
{
    public class OrderFlowers
    {
        public int Id { get; set; }
        
        public long Count { get; set; }

        public int FlowerId { get; set; }
        public int OrderId { get; set; }

        public virtual Flower Flower { get; set; }
        public virtual Order Order { get; set; }
    }
}