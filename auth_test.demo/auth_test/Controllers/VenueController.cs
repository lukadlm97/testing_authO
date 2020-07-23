using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_test.demo.Domain.Models;
using auth_test.demo.Domain.Services;
using auth_test.ViewModels;
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
        private readonly IUserService _userService;

        public VenueController(IDataService<Venue> venueService,IUserService userService)
        {
            _venueService = venueService;
            _userService = userService;
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

        [HttpPost("create")]
        [Authorize(Roles = Role.SuperAdmin)]
        public async Task<IActionResult> CreateVenue([FromBody] VenueModel model)
        {
            var venue = (Venue)model;

            var setedAdmins = _userService.SetUsers(model.Admins);
            if (setedAdmins == null)
                return NotFound(new
                {
                    message = "Error with admins privilage"
                });
            venue.Admins = setedAdmins;

            var createdEntity = _venueService.Insert(venue);
            if (createdEntity == null)
                return BadRequest(new
                {
                    message = "problem with creating venue"
                });

            return Ok(createdEntity);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.SuperAdmin)]
        public async Task<IActionResult> DeleteVenue(int id)
        {
            if (_venueService.Delete(id))
            {
                return Ok(new
                {
                    message = "Venue has successfully deleted!"
                });
            }
            return BadRequest(new
            {
                message = "Venue has't successfully deleted!"
            });
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = Role.SuperAdmin)]
        public async Task<IActionResult> UpdateVenue(int id,[FromBody]VenueModel model)
        {
            var venue = (Venue)model;
            var updatedVenue = _venueService.Update(id, venue);

            if (updatedVenue == null)
            {
                return BadRequest(new
                {
                    message="Venue not updated!"
                });
            }

            return Ok(updatedVenue);
        }
    }
}