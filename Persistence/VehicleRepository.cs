using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Core;
using vega.Core.Models;
using vega.Models;

namespace vega.Persistence
{
  public class VehicleRepository : IVehicleRepository
  {
    private readonly VegaDbContext context;
    public VehicleRepository(VegaDbContext context)
    {
        this.context = context;
    }

    public async Task<Core.Models.Vehicle> GetVehicle(int id, bool includeRelated = true)
    {
        if (!includeRelated)
          return await context.Vehicles.FindAsync(id);

        return await context.Vehicles
          .Include(v => v.Features)
            .ThenInclude(vf => vf.Feature)
          .Include(v => v.Model)
            .ThenInclude(m => m.Make)
          .SingleOrDefaultAsync(v => v.Id == id);
     }

    public void Add(Core.Models.Vehicle vehicle) 
    {
      context.Vehicles.Add(vehicle);
    }

    public void Remove(Core.Models.Vehicle vehicle)
    {
      context.Remove(vehicle);
    }

        Task<Models.Vehicle> IVehicleRepository.GetVehicle(int id, bool includeRelated)
        {
            throw new NotImplementedException();
        }

        void IVehicleRepository.Add(Models.Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        void IVehicleRepository.Remove(Models.Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}