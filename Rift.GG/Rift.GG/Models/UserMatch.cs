using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rift.GG.Models
{
    public class UserMatch
    {
        [Key]
        public int UserMatchId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int MatchId { get; set; }
        [ForeignKey("MatchId")]
        public Match Match { get; set; }
    }
}
