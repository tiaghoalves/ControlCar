using ControlCar.Models;
using ControlCar.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCar.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ReportsController
        public ActionResult Index()
        {
            var model = new ParametersViewModel()
            {
                Drivers = _context.Driver.ToList(),
                Vehicles = _context.Vehicle.ToList(),
                Routes = _context.Route.ToList()
            };

            return View("Index", model);
        }

        // POST: ReportsController/Result
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Result(ParametersViewModel vm)
        {
            try
            {
                var driver = _context.Driver.FirstOrDefault(d => d.IdDriver == vm.IdDriver);
                var vehicle = _context.Vehicle.FirstOrDefault(d => d.IdVehicle == vm.IdVehicle);
                var route = _context.Route.FirstOrDefault(d => d.IdRoute == vm.IdRoute);
                var query = _context.Scheduling
                            .Select(s => new Report()
                            {
                                Id = s.IdScheduling,
                                ExpectedStartDate = s.ExpectedStartDate,
                                ExpectedEndDate = s.ExpectedEndDate,
                                StartDatePerformed = s.StartDatePerformed,
                                EndDatePerformed = s.EndDatePerformed,
                                EndKm = s.EndKm,
                                Driver = driver,
                                Vehicle = vehicle,
                                Route = route
                            })
                            .ToList();

                return View("Result", query);
            }
            catch
            {
                return View("Index");
            }
        }

    }
}
