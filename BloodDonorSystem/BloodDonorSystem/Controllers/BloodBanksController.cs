
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodDonorSystem.Models;


namespace BloodDonorSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBanksController : ControllerBase
    {
        private readonly BloodBankService _bloodBankService;

        public BloodBanksController(BloodBankService bloodBankService)
        {
            _bloodBankService = bloodBankService;
        }

        // GET: api/BloodBanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloodBank>>> GetBloodBanks()
        {
            return Ok(await _bloodBankService.GetAllBloodBanksAsync());
        }

        // GET: api/BloodBanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BloodBank>> GetBloodBank(int id)
        {
            var bloodBank = await _bloodBankService.GetBloodBankAsync(id);
            if (bloodBank == null)
            {
                return NotFound();
            }
            return bloodBank;
        }

        // POST: api/BloodBanks
        [HttpPost]
        public async Task<ActionResult<BloodBank>> PostBloodBank(BloodBank bloodBank)
        {
            await _bloodBankService.CreateBloodBankAsync(bloodBank);
            return CreatedAtAction(nameof(GetBloodBank), new { id = bloodBank.Id }, bloodBank);
        }

        // PUT: api/BloodBanks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloodBank(int id, BloodBank bloodBank)
        {
            if (id != bloodBank.Id)
            {
                return BadRequest();
            }
            try
            {
                await _bloodBankService.UpdateBloodBankAsync(id, bloodBank);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/BloodBanks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBloodBank(int id)
        {
            try
            {
                await _bloodBankService.DeleteBloodBankAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
