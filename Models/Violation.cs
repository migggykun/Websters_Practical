using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Websters.Models
{
    public partial class Violation
    {

        public Violation()
        {
            CommitedViolations = new HashSet<CommitedViolation>();
        }

        [Key]
        public int id { get; set; }


        [Required]
        public string name { get; set; }

        [Required]
        public double price { get; set; }


        public virtual ICollection<CommitedViolation> CommitedViolations { get; set; }
    }
}
