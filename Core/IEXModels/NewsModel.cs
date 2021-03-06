using System;
using System.Collections.Generic;

namespace Core.IEXModels
{
    public class NewsModel
    {
        public string Headline { get; set; }

        public string Source { get; set; }

        public string Url { get; set; }

        public string Summary { get; set; }

        public string Image { get; set; }

        public bool HasPaywall { get; set; }
    }
}

