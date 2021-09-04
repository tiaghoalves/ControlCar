using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ControlCar.Models
{
    public partial class Scheduling
    {
        public int IdScheduling { get; set; }
        public DateTime ExpectedStartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public int? IdRoute { get; set; }
        public int? IdVehicle { get; set; }
        public int? IdDriver { get; set; }
        public DateTime? StartDatePerformed { get; set; }
        public DateTime? EndDatePerformed { get; set; }
        public double? EndKm { get; set; }
        public int? IdStatusScheduling { get; set; }
        public int? IdAuthentication { get; set; }

        public virtual Driver IdDriverNavigation { get; set; }
        public virtual Route IdRouteNavigation { get; set; }
        public virtual Authentication IdSchedulingNavigation { get; set; }
        public virtual StatusScheduling IdStatusSchedulingNavigation { get; set; }
        public virtual Vehicle IdVehicleNavigation { get; set; }
    }
}
