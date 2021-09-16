using ControlCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControlCar.Services
{
    public class VehicleService
    {
        private AppDbContext _context;

        public VehicleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> VehicleValidationRules(string board, int renavam)
        {
            var vehicleAlreadyExists = await _context.Vehicle.FirstOrDefaultAsync(v => v.Board == board || v.Renavam == renavam);

            return vehicleAlreadyExists != null ? false : true;
        }
    }
}
