using System;
using AutoMapper;
using Core.Entities;

namespace API.Models
{
    public class TransactionModel
    {
        public virtual Guid TransactionId { get; set; }

        public virtual string UserId { get; set; }

        public virtual string Stock { get; set; }

        public virtual decimal Price { get; set; }

        public virtual int Quantity { get; set; }

        public virtual DateTime Date { get; set; }
    }

    public class TransactionModelProfile : Profile
    {
        public TransactionModelProfile()
        {
            CreateMap<TransactionEntity, TransactionModel>();
        }
    }
}
