using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HungryCake.API.Helpers;
using HungryCake.API.Models;

namespace HungryCake.API.Dtos
{
    public class GridEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public int QuantColumns { get; set; }
        public int QuantRows { get; set; }
        public int FontSize { get; set; }
        public GridTemplate Template { get; set; }
        public int RowHeightLimit { get; set; }
        public IEnumerable<Column> Columns { get; set; }

    }
}