using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Websters.ViewModels
{
    public class PaymentViewModel
    {
        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Price")]
        public double price { get; set; }

        [DisplayName("Amount tendered")]
        public double amountTendered { get; set; }

        [DisplayName("Committed Violation ID")]
        public int committedViolationId { get; set; }
    }
}