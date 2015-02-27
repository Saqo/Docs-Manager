using System;

namespace Core.Models
{
    public class RegistrationUser
    {
        public Guid Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public Boolean IsAdmin { get; set; }

    }
}
