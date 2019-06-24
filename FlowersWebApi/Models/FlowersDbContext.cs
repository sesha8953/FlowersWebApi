using FlowersWebApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlowersWebApi.Models
{
    public class FlowersDbContext : DbContext
    {
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderFlowers> OrderFlowers { get; set; }

        public FlowersDbContext(): base("FlowersDbContext")
        {

        }
    }
}