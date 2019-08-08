using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace shp_f.Models
{
    public partial class Users
    {
        public Users()
        {
            Cart = new HashSet<Cart>();
        }
 
        public int UserId { get; set; }
        [Required]
        public string UserFullName { get; set; }
        [Required]
        public string UserMail { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public string UserPhone { get; set; }
        [Required]
        public string UserAddress { get; set; }
        [Required]

        public ICollection<Cart> Cart { get; set; }
    }
}
