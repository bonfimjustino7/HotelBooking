using Application.Guest.DTO;
using Application.Guest.Requests;
using Application.Ports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly ILogger<GuestController> _logger;
        private readonly IGuestManager _guestManager;

        public GuestController(ILogger<GuestController> logger, 
            IGuestManager guestManager)
        {
            _guestManager = guestManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<GuestDTO>> Post(GuestDTO guest)
        {
            var request = new CreateGuestRequest
            {
                Data = guest
            };


            var res = await _guestManager.CreateGuest(request);

            if (res.Success) return Created("", res.Data);
            if (res.ErrorCode == Application.ErrorCodes.NOT_FOUND)
            {
                return BadRequest(res);
            }
            
            _logger.LogError("Response with unknow ErrorCode Returned");
            return BadRequest(500);
        }
    }
}
