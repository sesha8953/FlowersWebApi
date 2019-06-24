using FlowersWebApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlowersWebApi.Models.ResourceModels
{
    public class ManagerResourceModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? Birthdate { get; set; }

        public ManagerResourceModel(Manager manager)
        {
            Id = manager.Id;
            FirstName = manager.FirstName;
            LastName = manager.LastName;
            Birthdate = manager.Bdate;
        }

        public Manager ConvertToEnity()
        {
            return new Manager
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Bdate = Birthdate
            };
        }
    }
}