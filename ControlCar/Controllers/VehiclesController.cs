using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlCar.Models;
using ControlCar.Services;

namespace ControlCar.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly AppDbContext _context;
        private VehicleService _vehicleService;

        public VehiclesController(AppDbContext context)
        {
            _context = context;
            _vehicleService = new VehicleService(context);
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Vehicle.Include(v => v.IdStatusVehicleNavigation);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.IdStatusVehicleNavigation)
                .FirstOrDefaultAsync(m => m.IdVehicle == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            ViewData["IdStatusVehicle"] = new SelectList(_context.StatusVehicle, "IdstatusVehicle", "Description");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVehicle,Model,Km,Board,Type,Brand,Color,Year,Renavam,Chassi,IdStatusVehicle,Observation")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdStatusVehicle"] = new SelectList(_context.StatusVehicle, "IdstatusVehicle", "Description", vehicle.IdStatusVehicle);
            
            return View(vehicle);
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> VerifyVehicleCreationRules(string board, int renavam)
        {
            var isValid = await _vehicleService.VehicleValidationRules(board, renavam);

            if (!isValid)
            {
                return Json($"Placa ou renavam informados já existem.");
            }

            return Json(true);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["IdStatusVehicle"] = new SelectList(_context.StatusVehicle, "IdstatusVehicle", "Description", vehicle.IdStatusVehicle);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVehicle,Model,Km,Board,Type,Brand,Color,Year,Renavam,Chassi,IdStatusVehicle,Observation")] Vehicle vehicle)
        {
            if (id != vehicle.IdVehicle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.IdVehicle))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdStatusVehicle"] = new SelectList(_context.StatusVehicle, "IdstatusVehicle", "Description", vehicle.IdStatusVehicle);

            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.alreadySchedule = _context.Scheduling.Any(e => e.IdVehicle == id);

            var vehicle = await _context.Vehicle.Include(v => v.IdStatusVehicleNavigation).FirstOrDefaultAsync(m => m.IdVehicle == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            
            _context.Vehicle.Remove(vehicle);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.IdVehicle == id);
        }
    }
}
