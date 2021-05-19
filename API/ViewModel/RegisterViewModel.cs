using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        public string UserName { get; set; }
        public long? FacebookId { get; set; }
        public string PictureUrl { get; set; }
        [Required]
        [StringLength(50, MinimumLength =5)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
