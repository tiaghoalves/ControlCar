using ControlCar.Models;
using ControlCar.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ControlCar.Controllers
{
    public class SchedulingController : Controller
    {
        private readonly AppDbContext _context;

        public SchedulingController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var driver = _context.Driver.FirstOrDefault();
            var vehicle = _context.Vehicle.FirstOrDefault();
            var route = _context.Route.FirstOrDefault();
            var query = _context.Scheduling
                    .Include(s => s.IdStatusSchedulingNavigation)
                    .Include(s => s.IdRouteNavigation)
                    .ToList();

            return View("Index", query);
        }

        public IActionResult Create()
        {
            var model = new SchedulingViewModel()
            {
                Drivers = _context.Driver.ToList(),
                Vehicles = _context.Vehicle.ToList(),
                Routes = _context.Route.ToList()
            };

            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchedulingViewModel vm)
        {
            if (ModelState.IsValid)
            {
                double endKm = 0.0;
                var user = _context.Authentication.FirstOrDefault(user => user.Email == "admin@admin.com");
                var status = _context.StatusScheduling.FirstOrDefault(s => s.Description == "AGUARDANDO");
                var vehicle = _context.Vehicle.FirstOrDefault(v => v.IdVehicle == vm.IdVehicle);

                if (vehicle != null)
                {
                    endKm = vehicle.Km;
                }

                var scheduling = new Scheduling()
                {
                    ExpectedStartDate = vm.ExpectedStartDate,
                    ExpectedEndDate = vm.ExpectedEndDate,
                    StartDatePerformed = DateTime.Now,
                    EndKm = endKm,
                    IdDriver = vm.IdDriver,
                    IdVehicle = vm.IdVehicle,
                    IdRoute = vm.IdRoute,
                    IdAuthentication = user.IdAuthentication,
                    IdStatusScheduling = status.IdstatusScheduling
                };

                _context.Add(scheduling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduling = await _context.Scheduling
                .Include(s => s.IdVehicleNavigation)
                .Include(s => s.IdRouteNavigation)
                .Include(s => s.IdDriverNavigation)
                .Include(s => s.IdStatusSchedulingNavigation)
                .FirstOrDefaultAsync(s => s.IdScheduling == id);

            if (scheduling == null)
            {
                return NotFound();
            }

            var viewModel = new SchedulingEditViewModel()
            {
                IdScheduling = scheduling.IdScheduling,
                IdDriver = scheduling.IdDriver,
                IdVehicle = scheduling.IdVehicle,
                IdRoute = scheduling.IdRoute,
                IdStatusScheduling = scheduling.IdStatusScheduling,
                StartDatePerformed = scheduling.StartDatePerformed,
                EndDatePerformed = scheduling.EndDatePerformed,
                EndKm = scheduling.EndKm,
                ExpectedStartDate = scheduling.ExpectedStartDate,
                ExpectedEndDate = scheduling.ExpectedEndDate,
                Drivers = _context.Driver.ToList(),
                Vehicles = _context.Vehicle.ToList(),
                Routes = _context.Route.ToList(),
                Statuses = _context.StatusScheduling.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SchedulingEditViewModel vm)
        {
            if (vm.IdScheduling == 0)
            {
                return NotFound();
            }

            var statusFinish = _context.StatusScheduling.FirstOrDefault(s => s.Description == "FINALIZADO");
            var statusStarted = _context.StatusScheduling.FirstOrDefault(s => s.Description == "INICIADO");
            var scheduling = new Scheduling()
            {
                IdScheduling = vm.IdScheduling,
                IdDriver = vm.IdDriver,
                IdVehicle = vm.IdVehicle,
                IdRoute = vm.IdRoute,
                IdStatusScheduling = vm.IdStatusScheduling,
                StartDatePerformed = vm.StartDatePerformed,
                EndDatePerformed = vm.EndDatePerformed,
                EndKm = vm.EndKm,
                ExpectedStartDate = vm.ExpectedStartDate,
                ExpectedEndDate = vm.ExpectedEndDate
            };

            if (vm.IdStatusScheduling == statusFinish.IdstatusScheduling)
            {
                scheduling = await FinishSchedule(scheduling, statusFinish);
            }
            else if (vm.IdStatusScheduling == statusStarted.IdstatusScheduling)
            {
                scheduling = await StartSchedule(scheduling, statusStarted);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(scheduling);
        }

        public async Task<Scheduling> StartSchedule(Scheduling schedule, StatusScheduling statusStart)
        {
            try
            {
                var route = await _context.Route.FirstOrDefaultAsync(r => r.IdRoute == schedule.IdRoute);

                schedule.IdStatusScheduling = statusStart.IdstatusScheduling;
                schedule.StartDatePerformed = DateTime.Now;

                return schedule;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Scheduling> FinishSchedule(Scheduling schedule, StatusScheduling statusFinish)
        {
            try
            {
                var route = await _context.Route.FirstOrDefaultAsync(r => r.IdRoute == schedule.IdRoute);
                
                schedule.IdStatusScheduling = statusFinish.IdstatusScheduling;
                schedule.EndKm = route.KmPattern;
                schedule.EndDatePerformed = DateTime.Now;

                return schedule;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
