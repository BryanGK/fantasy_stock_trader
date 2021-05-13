using System;
using System.Collections.Generic;

namespace Core.Entities.IEXModels
{
    public class NewsModel
    {
        public string headline { get; set; }

        public string source { get; set; }

        public string url { get; set; }

        public string summary { get; set; }

        public string image { get; set; }

        public bool hasPaywall { get; set; }
    }
}

