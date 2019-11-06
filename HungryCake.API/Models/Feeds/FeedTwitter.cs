using System;
using System.Collections.Generic;

namespace HungryCake.API.Models
{
    public class FeedTwitter : Feed
    {
        public string Twitter { get; set; }
        public IEnumerable<ColumnTwitter> ColumnsTwitter { get; set; }
    }
}