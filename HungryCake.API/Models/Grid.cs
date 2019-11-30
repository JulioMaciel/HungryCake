using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HungryCake.API.Helpers;

namespace HungryCake.API.Models
{
    public class Grid
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = "Untitled Grid";
        public User User { get; set; }
        public int UserId { get; set; }
        public int QuantColumns { get; set; } = 1;
        public int QuantRows { get; set; } = 2;
        public int FontSize { get; set; } = 12;
        public GridTemplate Template { get; set; } = GridTemplate.Dark;
        public int RowHeightLimit { get; set; } = 50;
        public IEnumerable<Column> Columns { get; set; }
        // public IEnumerable<int> ColumnIds { get; set; }

        public Grid(int userId)
        {
            UserId = userId;
        }


    }
}