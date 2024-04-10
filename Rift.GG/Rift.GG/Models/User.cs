using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rift.GG.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        //Navigation properties
        public virtual ICollection<UserMatch> UserMatches { get; set; }
        public virtual UserStats UserStats { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
