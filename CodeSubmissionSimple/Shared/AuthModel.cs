using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Shared
{
    public class LoginResult
    {
        public string Message { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string JwtBearer { get; set; }

        public bool Success { get; set; }

    }

    public class LoginModel
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

    public class RegisterModel : LoginModel
    {

        [Required(ErrorMessage = "User Role is required")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
