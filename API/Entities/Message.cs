using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string? SenderUsername { get; set; }
        public string? RecipientUsrname { get; set; }
        public string? Content { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; } = DateTime.UtcNow;
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }

        //navigation property
        public int SenderId { get; set; }
        public AppUser Sender { get; set; } = null!;
        public int RecipientId { get; set; }
        public AppUser Recipient { get; set; } = null!;
    }
}