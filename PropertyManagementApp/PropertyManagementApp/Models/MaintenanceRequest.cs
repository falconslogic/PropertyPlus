using System;
using System.Collections.Generic;

namespace PropertyManagementApp.Models
{
    public partial class MaintenanceRequest
    {
        public int MaintenanceId { get; set; }
        public int PropertyId { get; set; }
        public string Description { get; set; }
        public string Documents { get; set; }
        public bool? Priority { get; set; }

        public virtual Property Property { get; set; }
    }
}
