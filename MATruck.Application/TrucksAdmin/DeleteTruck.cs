﻿using MATruck.Database;
using System.Linq;
using System.Threading.Tasks;

namespace MATruck.Application.TrucksAdmin
{
    public class DeleteTruck
    {
        private readonly ApplicationDbContext _ctx;

        public DeleteTruck(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Do(int id)
        {
            var Truck = _ctx.Trucks.FirstOrDefault(x => x.Id == id);
            _ctx.Trucks.Remove(Truck);

            await _ctx.SaveChangesAsync();

            return true;
        }

    }
}
