using BloodDonorSystem.Data;
using BloodDonorSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BloodBankService
{
    private readonly AppDbContext _context;

    public BloodBankService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BloodBank>> GetAllBloodBanksAsync()
    {
        return await _context.BloodBanks.AsNoTracking().ToListAsync();
    }

    public async Task<BloodBank> GetBloodBankAsync(int id)
    {
        return await _context.BloodBanks.AsNoTracking().FirstOrDefaultAsync(bb => bb.Id == id);
    }

    public async Task<BloodBank> CreateBloodBankAsync(BloodBank bloodBank)
    {
        _context.BloodBanks.Add(bloodBank);
        await _context.SaveChangesAsync();
        return bloodBank;
    }

    public async Task UpdateBloodBankAsync(int id, BloodBank bloodBank)
    {
        var existingBloodBank = await _context.BloodBanks.FindAsync(id);
        if (existingBloodBank == null)
        {
            throw new KeyNotFoundException("BloodBank not found.");
        }

        existingBloodBank.BranchName = bloodBank.BranchName;
        existingBloodBank.City = bloodBank.City;

        _context.Entry(existingBloodBank).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBloodBankAsync(int id)
    {
        var bloodBank = await _context.BloodBanks.FindAsync(id);
        if (bloodBank == null)
        {
            throw new KeyNotFoundException("BloodBank not found.");
        }

        _context.BloodBanks.Remove(bloodBank);
        await _context.SaveChangesAsync();
    }
}