using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rift.GG.Models
{
    public class UserStats
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string Rank { get; set; }

        // Navigation property
        public virtual User User { get; set; }
    }
}
