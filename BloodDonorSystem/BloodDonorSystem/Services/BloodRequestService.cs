using BloodDonorSystem.Data;
using BloodDonorSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BloodRequestService
{
    private readonly AppDbContext _context;

    public BloodRequestService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BloodRequest>> GetAllBloodRequestsAsync()
    {
        return await _context.BloodRequests.AsNoTracking().ToListAsync();
    }

    public async Task<BloodRequest> GetBloodRequestAsync(int id)
    {
        return await _context.BloodRequests.AsNoTracking().FirstOrDefaultAsync(br => br.Id == id);
    }

    public async Task<BloodRequest> CreateBloodRequestAsync(BloodRequest bloodRequest)
    {
        _context.BloodRequests.Add(bloodRequest);
        await _context.SaveChangesAsync();
        return bloodRequest;
    }

    public async Task UpdateBloodRequestAsync(int id, BloodRequest bloodRequest)
    {
        var existingBloodRequest = await _context.BloodRequests.FindAsync(id);
        if (existingBloodRequest == null)
        {
            throw new KeyNotFoundException("BloodRequest not found.");
        }

        existingBloodRequest.RequestorHospital = bloodRequest.RequestorHospital;
        existingBloodRequest.BloodType = bloodRequest.BloodType;
        

        _context.Entry(existingBloodRequest).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBloodRequestAsync(int id)
    {
        var bloodRequest = await _context.BloodRequests.FindAsync(id);
        if (bloodRequest == null)
        {
            throw new KeyNotFoundException("BloodRequest not found.");
        }

        _context.BloodRequests.Remove(bloodRequest);
        await _context.SaveChangesAsync();
    }
}