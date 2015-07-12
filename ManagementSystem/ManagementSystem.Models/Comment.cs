using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Models
{
    public class Comment
    {
       
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime ReminderDate { get; set; }

     
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int IssueId { get; set; }

        public virtual Issue Issue { get; set; }

        [Required]
        public string Content { get; set; }



        [Required]
        public int CommentTypeId { get; set; }
        public virtual CommentType CommentType { get; set; }
 

    }
}
