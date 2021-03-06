using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ControlCar.Models
{
    public partial class Authentication
    {
        public int IdAuthentication { get; set; }
        public string User { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Scheduling Scheduling { get; set; }
    }
}
