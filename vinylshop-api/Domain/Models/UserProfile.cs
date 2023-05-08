using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }

        // Add a foreign key to the User model
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
