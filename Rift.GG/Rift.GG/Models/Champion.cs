using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rift.GG.Models
{
    public class Champion
    {
        [Key]
        public int ChampionId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }

    }
}
