using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HungryCake.API.Helpers;

namespace HungryCake.API.Models
{
    public class Feed
    {
        [Required]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastSuccess { get; set; }
        public DateTime LastFail { get; set; }
        public byte[] Icon { get; set; }
        public bool IsActive { get; set; }
    }
}