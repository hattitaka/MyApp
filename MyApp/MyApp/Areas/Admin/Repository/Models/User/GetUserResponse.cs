using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository.Models.GetUser
{
    public class GetUserResponse
    {
        public GetUserResponse(int id, string name, string address, string loginId)
        {
            Id = id;
            Name = name;
            Address = address;
            LoginId = loginId;
        }

        public GetUserResponse() { }

        public int Id { get; }

        public string Name { get; }

        public string Address { get; }

        public string LoginId { get; }
    }
}