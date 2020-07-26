using auth_test.demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace auth_test.ViewModels
{
    public class VenueModel
    {
        public string Name { get; set; }
        [StringLength(50, MinimumLength = 8)]
        [Required]
        public string Address { get; set; }
        public string OpenTime { get; set; }
        public string ClosedTime { get; set; }
        public DateTime DateJoined { get; set; }
        public IEnumerable<User> Admins { get; set; }
        public VenueType VenueType { get; set; }

        public static implicit operator Venue(VenueModel model)
        {
            return new Venue
            {
                Id = 0,
                Name = model.Name,
                Address = model.Address,
                OpenTime = model.OpenTime,
                ClosedTime = model.ClosedTime,
                DateJoined = model.DateJoined,
             //   Admins = model.Admins,
                VenueType = model.VenueType
            };
        }

    }
}
