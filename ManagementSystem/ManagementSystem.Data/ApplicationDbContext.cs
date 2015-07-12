using ManagementSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<Issue> Issues { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<CommentType> CommentTypes { get; set; }
        public IDbSet<IssueType> IssueTypes { get; set; }

        public IDbSet<Status> Status { get; set; }
    }
}
