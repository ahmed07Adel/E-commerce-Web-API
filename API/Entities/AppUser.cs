﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser : IdentityUser
    {
        public ICollection<ProductRating> rattings { get; set; }
        public ICollection<ProductinCart> ProductinCarts { get; set; }
    }
}
