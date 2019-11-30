using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HungryCake.API.Helpers;
using HungryCake.API.Models;

namespace HungryCake.API.Dtos
{
    public class GridLogin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GridLogin(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}