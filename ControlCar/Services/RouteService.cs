using ControlCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCar.Services
{
    public class RouteService
    {
        private AppDbContext _context;

        public RouteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> VehicleValidationRules(string source, int destiny)
        {
            //var vehicleAlreadyExists = await _context.Route.FirstOrDefaultAsync(v => v.Board == board || v.Renavam == renavam);

            return true;
        }
    }
}
