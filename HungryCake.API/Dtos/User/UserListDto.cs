using System;
using System.Collections.Generic;

namespace HungryCake.API.Dtos
{
    public class UserListDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
    }
}