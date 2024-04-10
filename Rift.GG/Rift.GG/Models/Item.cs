using System.ComponentModel.DataAnnotations;
using Rift.GG.Models;
namespace Rift.GG.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
