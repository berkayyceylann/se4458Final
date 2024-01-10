using BloodDonorSystem.Data;
using BloodDonorSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DonorService
{
    private readonly AppDbContext _context;

    public DonorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Donor>> GetAllDonorsAsync()
    {
        return await _context.Donors.AsNoTracking().ToListAsync();
    }

    public async Task<Donor> GetDonorAsync(int id)
    {
        return await _context.Donors.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Donor> CreateDonorAsync(Donor donor)
    {
       

        _context.Donors.Add(donor);
        await _context.SaveChangesAsync();
        return donor;
    }

    public async Task UpdateDonorAsync(int id, Donor donor)
    {
      
        
        var existingDonor = await _context.Donors.FindAsync(id);
        if (existingDonor == null)
        {
            throw new KeyNotFoundException("Donor not found.");
        }

        
        existingDonor.FullName = donor.FullName;
        existingDonor.BloodType = donor.BloodType;
        existingDonor.City = donor.City;
        existingDonor.Town = donor.Town;
        existingDonor.PhoneNumber = donor.PhoneNumber;

        _context.Entry(existingDonor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDonorAsync(int id)
    {
        var donor = await _context.Donors.FindAsync(id);
        if (donor == null)
        {
            throw new KeyNotFoundException("Donor not found.");
        }

        _context.Donors.Remove(donor);
        await _context.SaveChangesAsync();
    }

    
}
