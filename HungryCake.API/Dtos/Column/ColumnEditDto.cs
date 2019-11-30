using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HungryCake.API.Helpers;
using HungryCake.API.Models;

namespace HungryCake.API.Dtos
{
    public class ColumnEditDto
    {
        public int Id { get; set; }
        public Grid Grid { get; set; }
        public string Name { get; set; }
        public IEnumerable<ColumnRegex> FeedsHtml { get; set; }
        public IEnumerable<ColumnReddit> FeedsReddit { get; set; }
        public IEnumerable<ColumnRss> FeedsRss { get; set; }
        public IEnumerable<ColumnTwitter> FeedsTwitter { get; set; }
        public int xPosition { get; set; }
        public int yPosition { get; set; }
        public int MaxItems { get; set; }
        public bool ShowRollbar { get; set; }
        public bool ShowImage { get; set; }
        public bool ShowSummary { get; set; }
        public bool ShowDateTime { get; set; }
        public string DateTimeFormat { get; set; }

    }
}