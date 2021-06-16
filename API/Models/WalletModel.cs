using System;
using AutoMapper;
using Core.Entities;

namespace API.Models
{
    public class WalletModel
    {
        public virtual Guid WalletId { get; set; }

        public virtual string UserId { get; set; }

        public virtual decimal Cash { get; set; }
    }

    public class WalletModelProfile : Profile
    {
        public WalletModelProfile()
        {
            CreateMap<WalletEntity, WalletModel>();
        }
    }
}
