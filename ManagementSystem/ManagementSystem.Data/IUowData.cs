using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Data
{
    public interface IUowData : IDisposable
    {
        IRepository<Issue> Issues { get; }

        IRepository<IssueType> IssueTypes { get; }

        IRepository<Status> Statuses { get; }

        IRepository<Comment> Comments { get; }

        IRepository<CommentType> CommentTypes { get; }

        int SaveChanges();
    }
}
