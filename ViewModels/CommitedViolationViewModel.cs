using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Websters.Models;

namespace Websters.ViewModels
{
    public class CommitedViolationViewModel
    {
        public int Id { get; set; }
        public Violation Violation { get; set; }
    }
}