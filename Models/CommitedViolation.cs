namespace Websters.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Websters.Models;

    public partial class CommitedViolation
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string userID { get; set; }

        [Required]
        public int violationID { get; set; }

        public bool isPaid { get; set; }

        public DateTime dateAdded { get; set; }

        public virtual Violation Violation { get; set; }
    }
}
