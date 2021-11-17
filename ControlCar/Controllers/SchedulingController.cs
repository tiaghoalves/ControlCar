using ControlCar.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                        .Select(s => new Scheduling()
                        {
                            IdScheduling = s.IdScheduling,
                            ExpectedStartDate = s.ExpectedStartDate,
                            ExpectedEndDate = s.ExpectedEndDate,
                            StartDatePerformed = s.StartDatePerformed,
                            EndDatePerformed = s.EndDatePerformed,
                            EndKm = s.EndKm,
                            IdDriverNavigation = driver,
                            IdVehicleNavigation = vehicle,
                            IdRouteNavigation = route
                        });

            return View("Index", query);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
