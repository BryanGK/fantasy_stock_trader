﻿using System;
namespace Core.Entities.IEXModels
{
    public class CompanyModel
    {
        public string symbol { get; set; }

        public string companyName { get; set; }

        public string exchange { get; set; }

        public string industry { get; set; }

        public string website { get; set; }

        public string description { get; set; }

        public string CEO { get; set; }
    }
}