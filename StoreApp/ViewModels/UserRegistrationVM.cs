using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.ViewModels
{
    public class UserRegistrationVM
    {
        [Required(ErrorMessage ="First Name Required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="LastName Required!")]
        public string LastName { get; set; }
        public string Address { get; set; }
        
        
        public string EmailID { get; set; }
        public string MobileNo { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passwords are not matched!")]
        public string ConfirmPassword { get; set; }
    }
}
