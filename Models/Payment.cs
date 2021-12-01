using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Websters.Models
{
    public class Payment
    {
        public int id { get; set; }

        public int committedViolationId { get; set; }

        public double amountTendered { get; set; }

        public double change { get; set; }

        public DateTime datePaid { get; set; }
    }
}