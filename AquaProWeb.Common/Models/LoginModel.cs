﻿using System.ComponentModel.DataAnnotations;

namespace AquaProWeb.Common.Models
{
    public class LoginModel
    {
        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string? Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
