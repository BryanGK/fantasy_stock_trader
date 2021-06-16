using System.Collections.Generic;
using AutoMapper;
using Core.Models;

namespace API.Models
{
    public class TotalHoldingsModel
    {
        public virtual decimal Value { get; set; }

        public virtual decimal Cash { get; set; }

        public List<HoldingModel> Holdings { get; set; }
    }

    public class HoldingModel
    {
        public virtual string Stock { get; set; }

        public virtual decimal Price { get; set; }

        public virtual decimal LatestPrice { get; set; }

        public virtual decimal TotalPrice { get; set; }

        public virtual int Quantity { get; set; }
    }

    public class TotalHoldingsModelProfile : Profile
    {
        public TotalHoldingsModelProfile()
        {
            CreateMap<TotalHoldings, TotalHoldingsModel>();
            CreateMap<Holding, HoldingModel>();
        }
    }
}
