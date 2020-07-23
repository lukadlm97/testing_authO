using System;
using System.Collections.Generic;
using System.Text;

namespace auth_test.demo.Domain.Models
{
    public class Venue:DomainObject
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string OpenTime { get; set; }
        public string ClosedTime { get; set; }
        public DateTime DateJoined { get; set; }
        public VenueType VenueType { get; set; }
        public IEnumerable<User> Admins { get; set; }
        public IEnumerable<TablePlace> Tables { get; set; }

    }
}
