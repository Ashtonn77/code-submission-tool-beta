using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Shared
{
    public class AppUser
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string PasswordHash { get; set; }

        public AppUser(string email, string role)
        {
            this.Email = email;
            this.Role = role;
        }

        public AppUser()
        {
            
        }


    }
}
