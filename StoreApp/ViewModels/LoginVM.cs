using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Emaidl Id Required!")]
        [EmailAddress(ErrorMessage ="Inavlid Email Address")]
        public string EmailID { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
