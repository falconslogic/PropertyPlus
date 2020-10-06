using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropertyManagementApp.Models
{
    public partial class PropertyLeaser
    {
        public PropertyLeaser()
        {
            Property = new HashSet<Property>();
        }

        public int LeaserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? ZipCode { get; set; }
        public string Comments { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Property> Property { get; set; }
    }
}
