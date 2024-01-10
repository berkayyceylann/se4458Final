
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodDonorSystem.Models;


namespace BloodDonorSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodRequestsController : ControllerBase
    {
        private readonly BloodRequestService _bloodRequestService;

        public BloodRequestsController(BloodRequestService bloodRequestService)
        {
            _bloodRequestService = bloodRequestService;
        }

        // GET: api/BloodRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloodRequest>>> GetBloodRequests()
        {
            return Ok(await _bloodRequestService.GetAllBloodRequestsAsync());
        }

        // GET: api/BloodRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BloodRequest>> GetBloodRequest(int id)
        {
            var bloodRequest = await _bloodRequestService.GetBloodRequestAsync(id);
            if (bloodRequest == null)
            {
                return NotFound();
            }
            return bloodRequest;
        }

        // POST: api/BloodRequests
        [HttpPost]
        public async Task<ActionResult<BloodRequest>> PostBloodRequest(BloodRequest bloodRequest)
        {
            await _bloodRequestService.CreateBloodRequestAsync(bloodRequest);
            return CreatedAtAction(nameof(GetBloodRequest), new { id = bloodRequest.Id }, bloodRequest);
        }

        // PUT: api/BloodRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloodRequest(int id, BloodRequest bloodRequest)
        {
            if (id != bloodRequest.Id)
            {
                return BadRequest();
            }
            try
            {
                await _bloodRequestService.UpdateBloodRequestAsync(id, bloodRequest);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/BloodRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBloodRequest(int id)
        {
            try
            {
                await _bloodRequestService.DeleteBloodRequestAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
