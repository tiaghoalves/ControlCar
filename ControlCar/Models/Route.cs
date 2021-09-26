﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ControlCar.Models
{
    public partial class Route
    {
        public Route()
        {
            Scheduling = new HashSet<Scheduling>();
        }

        public int IdRoute { get; set; }

        [Remote(action: "VerifyRouteCreationRules", controller: "Routes", AdditionalFields = nameof(Destiny))]
        public string Source { get; set; }

        [Remote(action: "VerifyRouteCreationRules", controller: "Routes", AdditionalFields = nameof(Source))]
        public string Destiny { get; set; }
        public double? KmPattern { get; set; }

        public virtual ICollection<Scheduling> Scheduling { get; set; }
    }
}
