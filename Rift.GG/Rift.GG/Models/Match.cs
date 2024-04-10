using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rift.GG.Models
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public DateTime DatePlayed { get; set; }
        public string Outcome { get; set; }

        // Navigation properties
        public virtual ICollection<UserMatch> UserMatches { get; set; }
    }
}
