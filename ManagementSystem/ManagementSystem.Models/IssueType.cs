using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Models
{
    public class IssueType
    {
         private ICollection<Issue> issues;

       public IssueType()
        {
            this.issues = new HashSet<Issue>();       
         
        }

        [Key]
        public int Id { get; set; }   
     
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Issue> Issues
        {
            get { return this.issues; }
            set { this.issues = value; }
        }
        
    }
}
