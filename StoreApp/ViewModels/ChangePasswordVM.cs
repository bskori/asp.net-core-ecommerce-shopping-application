﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.ViewModels
{
    public class ChangePasswordVM
    {
        [Required(ErrorMessage ="Old Password Required!")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage ="New Password Required!")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage ="Confirm New Password Required!")]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage ="Passwords Not Matched!")]
        public string ConfirmNewPassword { get; set; }
    }
}
