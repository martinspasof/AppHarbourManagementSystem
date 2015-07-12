using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Models
{
    public class Issue
    {        
        private ICollection<Comment> comments;        
       
        public Issue()
        {           
            this.comments = new HashSet<Comment>();          
            
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime RequiredByDate { get; set; }

        [Required]
        public string Description { get; set; }       

        [Required]
        public DateTime NextActionDate { get; set; }        

        [Required]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

       
        public string UserId { get; set; }

        public virtual ApplicationUser Users { get; set; }

        [Required]
        public int IssueTypeId { get; set; }
        public virtual IssueType IssueType { get; set; }
        
        
    }
}
