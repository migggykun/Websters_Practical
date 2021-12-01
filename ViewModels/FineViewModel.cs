using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Websters.Models;

namespace Websters.ViewModels
{
    public class FineViewModel
    {
        public ViolatorViewModel Violator { get; set; }

        public Violation Violation { get; set; }
    }
}