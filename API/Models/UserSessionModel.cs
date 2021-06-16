using System;
using AutoMapper;
using Core.Models;

namespace API.Models
{
    public class UserSessionModel
    {
        public virtual Guid SessionId { get; set; }

        public virtual string UserId { get; set; }

        public virtual string Username { get; set; }
    }

    public class UserSessionProfile : Profile
    {
        public UserSessionProfile()
        {
            CreateMap<UserSession, UserSessionModel>();
        }
    }
}
