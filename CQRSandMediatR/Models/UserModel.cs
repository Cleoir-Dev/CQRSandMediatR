﻿using System.ComponentModel.DataAnnotations;

namespace CQRSandMediatR.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "User Name is required!")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "IsAdmin is required!")]
        public bool IsAdmin { get; set; } = false;

        [EmailAddress]
        [Required(ErrorMessage = "Email is required!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        public string? Password { get; set; }
    }
}
