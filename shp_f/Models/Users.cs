using System;
using System.Collections.Generic;

namespace shp_f.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserMail { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }
    }
}
