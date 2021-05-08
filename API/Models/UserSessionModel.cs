using System;
namespace API.Models
{
    public class UserSession
    {
        public Guid User_Id { get; set; }

        public Guid Session_Id { get; set; }
    }
}
