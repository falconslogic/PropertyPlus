using System;
using System.Collections.Generic;

namespace PropertyManagementApp.Models
{
    public partial class PropertyOwner
    {
        public PropertyOwner()
        {
            Property = new HashSet<Property>();
        }

        public int OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? ZipCode { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<Property> Property { get; set; }
    }
}
