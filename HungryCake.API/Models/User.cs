using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HungryCake.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public int Level { get; set; } = 0;
    }
}