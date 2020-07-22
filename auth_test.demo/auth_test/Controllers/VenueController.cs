using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_test.demo.Domain.Models;
using auth_test.demo.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace auth_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IDataService<Venue> _venueService;

        public VenueController(IDataService<Venue> venueService)
        {
            _venueService = venueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVenue()
        {
            var venues =  _venueService.GetAll();

            if (venues == null)
                return NotFound(new
                {
                    message="venues doesn't find"
                });

            return Ok(venues);
        }
    }
}