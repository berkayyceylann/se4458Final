using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using BloodDonorSystem.Models;

namespace BloodDonorSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly DonorService _donorService;

        public DonorsController(DonorService donorService)
        {
            _donorService = donorService;
        }

        // GET: api/Donors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donor>>> GetDonors()
        {
            return Ok(await _donorService.GetAllDonorsAsync());
        }

        // GET: api/Donors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donor>> GetDonor(int id)
        {
            var donor = await _donorService.GetDonorAsync(id);

            if (donor == null)
            {
                return NotFound();
            }

            return donor;
        }

        // POST: api/Donors
        [HttpPost]
        public async Task<ActionResult<Donor>> PostDonor(Donor donor)
        {
            await _donorService.CreateDonorAsync(donor);
            return CreatedAtAction(nameof(GetDonor), new { id = donor.Id }, donor);
        }

        // PUT: api/Donors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonor(int id, Donor donor)
        {
            if (id != donor.Id)
            {
                return BadRequest();
            }

            try
            {
                await _donorService.UpdateDonorAsync(id, donor);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Donors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            try
            {
                await _donorService.DeleteDonorAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
