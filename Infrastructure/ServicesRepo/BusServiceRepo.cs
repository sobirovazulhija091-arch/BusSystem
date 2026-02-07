using System.Net;
using Microsoft.EntityFrameworkCore;

public class BusServiceRepo(ApplicationDbcontext dbcontext):IBusServiceRepo
{
    private readonly ApplicationDbcontext context = dbcontext;

    public async Task<int> AddRepoAsync(Bus bus)
    {
        await context.Buses.AddAsync(bus);
        await  context.SaveChangesAsync();
        return bus.Id;
    }

    public async Task<bool> DeleteRepoAsync(int busid)
    {
        var del =  await context.Buses.FindAsync(busid);
        if(del==null){return false;}
        context.Buses.Remove(del);
        return true;
    }

    public async Task<Bus> GetBusByIdRepoAsync(int busid)
    {
       return await context.Buses.FindAsync(busid);
    }

    public async Task<List<Bus>> GetBusesRepoAsync()
    {
         return await context.Buses.ToListAsync();
    }

    public async Task<bool> UpdateRepoAsync(int busid, Bus bus)
    {
        
        context.Buses.Update(bus);
        await context.SaveChangesAsync();
        return true;
    }

}