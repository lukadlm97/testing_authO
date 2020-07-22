using auth_test.demo.Domain.Models;
using auth_test.demo.Domain.Services;
using auth_test.demo.Entityframework;
using auth_test.demo.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace auth_test.demo.Services
{
    public class VenueService : IDataService<Venue>
    {
        private readonly AuthContext _context;
        private readonly NonQueryDataService<Venue> _nonQueryDataService;

        public VenueService(AuthContext context)
        {
            _context = context;
            _nonQueryDataService = new NonQueryDataService<Venue>(context);
        }
        public bool Delete(int id)
        {
            return _nonQueryDataService.Delete(id).Result;
        }

        public IEnumerable<Venue> GetAll()
        {
            return _context.Venues
                            .Include(x=>x.Admins);
        }

        public Venue Insert(Venue entity)
        {
            return _nonQueryDataService
                            .Create(entity).Result;
        }

        public Venue Update(int id, Venue entity)
        {
            return _nonQueryDataService
                             .Update(id, entity).Result;
        }
    }
}
