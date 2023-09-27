using Microsoft.AspNetCore.Mvc;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;
using SeatManagement2.DTOs;
using Microsoft.AspNetCore.Authorization;
using SeatManagement2.Exceptions;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomController : ControllerBase
    {
        private readonly IMeetingRoomService _meetingRoomService;

        public MeetingRoomController(IMeetingRoomService meetingRoomService)
        {
            _meetingRoomService = meetingRoomService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_meetingRoomService.GetAllMeetingRooms());
        }

        [HttpPost]
        public IActionResult Add(MeetingRoomDTO meetingRoomDTO)
        {
            try
            {
                _meetingRoomService.AddMeetingRoom(meetingRoomDTO);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{meetingRoomId}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int meetingRoomId)
        {
            try
            {
                _meetingRoomService.DeleteMeetingRoom(meetingRoomId);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //api/meetingroom/{3}/amenity

    }
}
