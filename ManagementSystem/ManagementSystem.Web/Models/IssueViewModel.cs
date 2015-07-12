using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ManagementSystem.Web.Models
{
    public class IssueViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime RequiredByDate { get; set; }

        public DateTime NextActionDate { get; set; }

        public string Status { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}