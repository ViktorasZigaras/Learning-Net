using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebAppRazorMVC.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Email { get; set; }
    }
}

