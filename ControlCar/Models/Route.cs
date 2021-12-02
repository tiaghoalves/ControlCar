using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
       
        [Display(Name = "Origem")]
        public string Source { get; set; }

        [Remote(action: "VerifyRouteCreationRules", controller: "Routes", AdditionalFields = nameof(Source))]
       
        
        [Display(Name = "Destino")]
        public string Destiny { get; set; }

        [Display(Name = "Km Padrão")]
        public double? KmPattern { get; set; }

        public string RouteDesc {
            get 
            {
                return Source + " até " + Destiny;
            }
        }

        public virtual ICollection<Scheduling> Scheduling { get; set; }
    }
}
