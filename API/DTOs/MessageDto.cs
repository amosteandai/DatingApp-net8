using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string? SenderUsername { get; set; }
        public required string SenderPhotoUrl { get; set; }
        public int RecipientId { get; set; }
        public required string RecipientPhotoUrl { get; set; }
        public string? RecipientUsrname { get; set; }
        public string? Content { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; }
    }
}