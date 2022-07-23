using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser : IdentityUser
    {
        
        public bool Active { get; set; }
        public int GenderId { get; set; }
        public UserGender UserGender { get; set; }
        public ICollection<ProductRating> rattings { get; set; }
        public ICollection<ProductinCart> ProductinCarts { get; set; }
    }
}
