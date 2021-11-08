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
                int[] drivers = new int[1]
                {
                    vm.IdDriver
                };
  

                var schedulings = _context.Scheduling
                        .Where(s => s.ExpectedStartDate >= vm.InitialDate && s.ExpectedEndDate <= vm.EndDate)
                        .ToList();

                return View("Result", schedulings);
            }
            catch
            {
                return View("Index");
            }
        }

    }
}
