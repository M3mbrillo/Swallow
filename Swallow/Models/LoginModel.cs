using System;
using System.ComponentModel.DataAnnotations;

namespace Swallow.Models
{
    public class LoginModel
    {
        [Required]
        [MaxLength(20)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Password")]        
        public string Password { get; set; }
    }
}