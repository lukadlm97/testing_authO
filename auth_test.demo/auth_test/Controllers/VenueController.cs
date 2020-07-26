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
        private readonly ITables _tableService;

        public VenueController(IDataService<Venue> venueService,IUserService userService,ITables tablesServices)
        {
            _venueService = venueService;
            _userService = userService;
            _tableService = tablesServices;
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
            venue.DateJoined = DateTime.Now;

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

            var setedAdmins = _userService.SetUsers(model.Admins);
            if (setedAdmins == null)
                return NotFound(new
                {
                    message = "Error with admins privilage"
                });
            venue.Admins = setedAdmins;

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
        [HttpGet("{id}")]
        [Authorize(Roles =Role.Admin+","+Role.SuperAdmin)]
        public async Task<IActionResult> GetTablesForVenue(int id)
        {
            var venue = _venueService.GetById(id);

            if (venue == null)
                return NotFound(new
                {
                    message = "Venue with this id doesn't find."
                });

            return Ok(venue);
        }
        [HttpPost("{id}/addtable")]
        [Authorize(Roles = Role.Admin + "," + Role.SuperAdmin)]
        public async Task<IActionResult> AddNewTable(int id,[FromBody] TableModel model)
        {
            var table = (TablePlace)model;

            var createdTable = _tableService.AddNewTable(table, id);

            if (createdTable == null)
                return BadRequest(new
                {
                    message = "Can't add table"
                });

            return Ok(createdTable);
        }
        [HttpPut("{idVenue}/tables/{idTable}")]
        [Authorize(Roles = Role.Admin + "," + Role.SuperAdmin)]
        public async Task<IActionResult> UpdateTable(int idVenue,int idTable,[FromBody] TableModel model)
        {
            var table = (TablePlace)model;

            var updatedTable = _tableService.UpdatedTable(idVenue,idTable,table);

            if (updatedTable == null)
                return BadRequest(new
                {
                    message = "Can't update table"
                });

            return Ok(updatedTable);
        }
        [HttpDelete("{idVenue}/tables/{idTable}")]
        [Authorize(Roles = Role.Admin + "," + Role.SuperAdmin)]
        public async Task<IActionResult> DeleteTable(int idVenue,int idTable)
        {
            if (_tableService.DeleteTable(idVenue, idTable))
                return Ok();
            return BadRequest(new
            {
                message = "Can't delete table"
            });
        }
    }
}