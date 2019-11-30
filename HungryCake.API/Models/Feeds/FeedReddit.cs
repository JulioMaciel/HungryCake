using System;
using System.Collections.Generic;
using HungryCake.API.Helpers;

namespace HungryCake.API.Models
{
    public class FeedReddit : Feed
    {
        public string reddit { get; set; }
        public int Users { get; set; }
        public IEnumerable<ColumnReddit> ColumnsReddit { get; set; }
    }
}