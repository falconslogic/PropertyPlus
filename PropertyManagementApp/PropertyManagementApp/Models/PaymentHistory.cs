using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropertyManagementApp.Models
{
    public partial class PaymentHistory
    {
        public PaymentHistory()
        {
            Property = new HashSet<Property>();
        }

        public int PaymentId { get; set; }

        [Display(Name = "Total Payments")]
        public int? TotalPayments { get; set; }

        [Display(Name = "Total Paid")]
        public int? TotalPaid { get; set; }

        [Display(Name = "Total Late")]
        public int? TotalLate { get; set; }

        [Display(Name = "Total Months")]
        public int? TotalMonths { get; set; }

        public virtual ICollection<Property> Property { get; set; }
    }
}
