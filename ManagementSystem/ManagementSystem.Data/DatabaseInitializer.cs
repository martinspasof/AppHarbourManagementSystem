using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Data
{
    public class DatabaseInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DatabaseInitializer()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
          
            if (context.Issues.Count() > 0)
            {
                return;
            }

            Random rand = new Random();           

            int size = rand.Next();
            for (int i = 1; i < 5; i++)
            {   

              var commenType = new CommentType();            
              var  commentTypetext = string.Format("{0}{1}", "commentType", i);
              commenType.Name = commentTypetext; 
              context.CommentTypes.Add(commenType);

              context.SaveChanges();
              base.Seed(context);

              var status = new Status();
              var statustext = string.Format("{0}{1}", "status", i);
              status.Name = statustext;
              context.Status.Add(status);

              context.SaveChanges();
              base.Seed(context);

              var issueType = new IssueType();            
              var issueTypetext = string.Format("{0}{1}", "issueType", i);
              issueType.Name = issueTypetext;      
              context.IssueTypes.Add(issueType);

              context.SaveChanges();
              base.Seed(context);    

              var statusId = i + 1;
              var taskId = i + 1;
              Issue issue = new Issue();
              var text = string.Format("{0}{1}", "Реорганизиране на печатни материали_", i);
              issue.CreatedDate = DateTime.ParseExact("2012-04-05", "yyyy-MM-dd", CultureInfo.InvariantCulture); ;
              issue.RequiredByDate = DateTime.ParseExact("2014-05-02", "yyyy-MM-dd", CultureInfo.InvariantCulture);
              issue.NextActionDate = DateTime.ParseExact("2014-09-20", "yyyy-MM-dd", CultureInfo.InvariantCulture);
              issue.Description = "this is description";
              issue.StatusId = statusId;
              issue.IssueTypeId = taskId;
              issue.Name = text;             
           
              context.Issues.Add(issue);
              context.SaveChanges();
              base.Seed(context);



            
           }
        }
    }
}
