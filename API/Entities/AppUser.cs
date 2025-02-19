using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using API.Extensions;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public  byte[] PasswordHash { get; set; } = [];
        public  byte[] PasswordSalt { get; set; } = [];
        public DateOnly  DateOfBirth { get; set; }
        public required string KnownAs { get; set; }
        public DateTime Created {get; set;} = DateTime.UtcNow;
        public DateTime LastActive {get; set;} = DateTime.UtcNow;
        public required string Gender { get; set; }
        public string? Introduction { get; set; }
        public string? Interests { get; set; }
        public string? LookingFor { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        public List<Photo> Photos { get; set; } = [];
        public List<UserLike> LikedByUsers {get;set;} = [];
        public List<UserLike> LikedUsers {get;set;} = [];
        public List<Message> MessageSent {get;set;} = [];
        public List<Message> MessageReceived {get;set;} = [];
    }
}