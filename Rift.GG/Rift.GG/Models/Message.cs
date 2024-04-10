using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rift.GG.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public string Content { get; set; }
        public DateTime DateSent { get; set; }
    }
}
