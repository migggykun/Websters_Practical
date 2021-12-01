using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Websters.ViewModels
{
    public class PaymentLogViewModel
    {
            
        [DisplayName("TransactionID")]
        public int transactionID { get; set; }


        [DisplayName("Violator")]
        public string violator { get; set; }

        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Price")]
        public double price { get; set; }

        [DisplayName("Amount tendered")]
        public double amountTendered { get; set; }

        [DisplayName("Date of Payment")]
        public DateTime dateCommitted { get; set; }

        [DisplayName("Date of Payment")]
        public DateTime datePaid { get; set; }
    }
}