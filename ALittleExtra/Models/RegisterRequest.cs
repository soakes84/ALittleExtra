using System;
using System.ComponentModel.DataAnnotations;

namespace ALittleExtra.Models
{
    public class RegisterRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
